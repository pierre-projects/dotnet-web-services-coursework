using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Asignment1part123
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public int c2f(int c)
        {
            return (int)((c * 9.0 / 5.0) + 32);
        }

        public int f2c(int f)
        {
            return (int)((f - 32) * 5.0 / 9.0);
        }

        public string sort(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;

            // split input
            double[] numbers = s.Split(',')
                                 .Select(n => double.Parse(n.Trim()))
                                 .ToArray();

            // bubble Sort 
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        
                        double temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            return string.Join(", ", numbers);
        }


    }
}
