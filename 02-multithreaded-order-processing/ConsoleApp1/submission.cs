using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 2.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
 * **/

namespace ConsoleApp1
{
    //delegate declaration for creating events
    public delegate void PriceCutEvent(double roomPrice, Thread agentThread);
    public delegate void OrderProcessEvent(Order order, double orderAmount);
    public delegate void OrderCreationEvent();

    public class MainClass
    {
        public static MultiCellBuffer buffer;
        public static Thread[] travelAgentThreads;
        public static bool hotelThreadRunning = true;
        public static void Main(string[] args)
        {

            Console.WriteLine("Inside Main");
            buffer = new MultiCellBuffer();

            Hotel hotel = new Hotel();
            TravelAgent travelAgent = new TravelAgent();

            Thread hotelThread = new Thread(new ThreadStart(hotel.hotelFun));
            hotelThread.Start();

            Hotel.PriceCut += new PriceCutEvent(travelAgent.agentOrder);
            Console.WriteLine("Price cut event has been subscribed");
            TravelAgent.orderCreation += new OrderCreationEvent(hotel.takeOrder);
            Console.WriteLine("Order creation event has been subscribed");
            OrderProcessing.OrderProcess += new OrderProcessEvent(travelAgent.orderProcessConfirm);
            Console.WriteLine("Order process event has been subscribed");

            travelAgentThreads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Creating  travel agent thread {0}", (i + 1));
                travelAgentThreads[i] = new Thread(travelAgent.agentFun);
                travelAgentThreads[i].Name = (i + 1).ToString();
                travelAgentThreads[i].Start();
            }
        }
    }
    public class MultiCellBuffer
    {
        // Each cell can contain an order object
        private const int bufferSize = 3; //buffer size
        int usedCells;
        private Order[] multiCells; // ? mark make the type nullable: allow to assign null value
        public static Semaphore getSemaph;
        public static Semaphore setSemaph;
        private readonly object write = new object();
        private readonly object read = new object();

        public MultiCellBuffer() //constructor 
        {
            multiCells = new Order[bufferSize];
            getSemaph = new Semaphore(0, bufferSize); //read not needed on intialization 
            setSemaph = new Semaphore(bufferSize, bufferSize);  //be able to write on any
        }

        public void SetOneCell(Order data)
        {

            if (!setSemaph.WaitOne(0)) return;
            bool hasBeenW = false;
            lock (write) 
            {
                for (int i = 0; i < multiCells.Length; i++)
                {
                    if (multiCells[i] == null)
                    {
                        multiCells[i] = data;
                        hasBeenW = true;
                        break;
                    }
                }
            }
            if (hasBeenW)
            {
                // another semaph able to be read
                getSemaph.Release(1);
            }
            else
            {
                // cant write semaph 
                setSemaph.Release(1);
            }

        }

        public Order GetOneCell()
        {
            if (!getSemaph.WaitOne(0)) return null;

            Order oneCell = null;
            bool lockTaken = false;

            try
            {
                if (!Monitor.TryEnter(read, 0))
                {
                    // couldn't get read permission
                    setSemaph.Release(1);
                    return null;
                }
                lockTaken = true;

                for (int i = 0; i < multiCells.Length; i++)
                {
                    if (multiCells[i] != null)
                    {
                        oneCell = multiCells[i];
                        multiCells[i] = null;
                        break;
                    }
                }
            }
            finally
            {
                if (lockTaken) Monitor.Exit(read);
            }

            // we freed one slot for writers
            setSemaph.Release(1);
            return oneCell;
        }

    }

    public class Order
    {
        //identity of sender of order
        private string senderId;
        //credit card number
        private long cardNo;
        //unit price of room from hotel
        private double unitPrice;
        //quantity of rooms to order
        private int quantity;

        //parametrized constructor
        public Order(string senderId, long cardNo, double unitPrice, int quantity)
        {
            this.senderId = senderId;
            this.cardNo = cardNo;
            this.unitPrice = unitPrice;
            this.quantity = quantity;
        }

        //getter methods
        public string getSenderId()
        {
            return senderId;
        }

        public long getCardNo()
        {
            return cardNo;
        }
        public double getUnitPrice()
        {
            return unitPrice;
        }
        public int getQuantity()
        {
            return quantity;
        }

    }
    public class OrderProcessing


    {

        private static readonly object randomLock = new object();
        private static readonly Random random = new Random();

        public static event OrderProcessEvent OrderProcess;
        //determinitiessitc credt card number check usinf is even or not



        public static bool creditCardCheck(long creditCardNumber)

        {
            return creditCardNumber % 2 == 0;
        }

        //method to calculate the final charge after adding taxes, location charges, etc
        public static double calculateCharge(double unitPrice, int quantity)
        {
            double taxRate, locationCharge;
            lock (randomLock)
            {
                taxRate = random.NextDouble() * 0.04 + 0.08;
                locationCharge = random.NextDouble() * 60 + 20;
            }

            double total = unitPrice * quantity * (1 + taxRate) + locationCharge;
            return Math.Round(total, 2);
        }

        //method to process the order
        public static void ProcessOrder(Order order)
        {
            try
            {
                if (!creditCardCheck(order.getCardNo()))
                {
                    OrderProcess?.Invoke(order, 0.0);
                    return;
                }

                // 
                double amount = calculateCharge(order.getUnitPrice(), order.getQuantity());
                OrderProcess?.Invoke(order, amount);
            }
            catch
            {
                //notify the agent with amount
                OrderProcess?.Invoke(order, 0.0);
            }
        }

    }
    public class TravelAgent
    {
        public static event OrderCreationEvent orderCreation;
        private double latestRoomPrice = 0.00;
        private readonly object priceLock = new object();

        private static readonly object rngLock = new object();
        private static readonly Random rng = new Random();


        public void agentFun()
        {
            while (MainClass.hotelThreadRunning)
            {
                Thread.Sleep(50);
            }
        }
        public void orderProcessConfirm(Order order, double orderAmount)
        {
            if (orderAmount <= 0)
                Console.WriteLine($"Agent {order.getSenderId()}: order rejected.");
            else
                Console.WriteLine($"Agent {order.getSenderId()}: order approved : ${orderAmount}");
        }


        private void createOrder(string senderId)
        {
            double price;
            lock (priceLock) { price = latestRoomPrice; }

            int quantity;
            long cardNo;
            lock (rngLock)
            {
                quantity = rng.Next(5, 21);
                cardNo = rng.Next(2000, 9000) * 2;
            }

            var order = new Order(senderId, cardNo, price, quantity);
            MainClass.buffer.SetOneCell(order);
            orderCreation?.Invoke();
        }

        public void agentOrder(double roomPrice, Thread travelAgentThread) //call back from thread
        {
            lock (priceLock)
            {
                latestRoomPrice = roomPrice;
            }
            createOrder(travelAgentThread?.Name ?? "");
        }
    }
    public class Hotel
    {
        static double currentRoomPrice = 100; //random current agent price
        static int threadNo = 0;
        static int eventCount = 0;
        private static int priceCutCount = 0;
        public static event PriceCutEvent PriceCut;

        private static readonly object rngLock = new object();
        private static readonly Random rng = new Random();

        public void hotelFun()
        {
            while (priceCutCount < 10)
            {
                double newPrice = pricingModel();
                updatePrice(newPrice);
                Thread.Sleep(80);
            }

            MainClass.hotelThreadRunning = false;
        }


        //using random method to generate random room prices
        public double pricingModel()
        {
            lock (rngLock)
            {
                return 80.0 + rng.NextDouble() * 80.0;
            }
        }

        public void updatePrice(double newRoomPrice)
        {
            Console.WriteLine($"New price is {Math.Round(newRoomPrice)}");

            if (newRoomPrice < currentRoomPrice)
            {
                Console.WriteLine("Updating the price and calling price cut event");
                currentRoomPrice = newRoomPrice;

                // Notify travel agents 
                PriceCut?.Invoke(currentRoomPrice, Thread.CurrentThread);

                // Count the cut
                priceCutCount++;
            }
            else
            {
                currentRoomPrice = newRoomPrice;
            }
        }


        public void takeOrder() // callback from travel agent
        {
            // Try to read  order 
            Order order = MainClass.buffer.GetOneCell();
            if (order == null)
            {
                return;
            }

            // process order
            var processor = new Thread(() => OrderProcessing.ProcessOrder(order));
            processor.Start();
        }
    }
}
