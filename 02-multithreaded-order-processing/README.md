# Assignment 2 — Threads, Delegates, and a Bounded Buffer

A console simulation of a hotel selling rooms to travel agents, used to exercise C# threading,
the delegate/event model, and a producer–consumer buffer. All of it lives in `submission.cs`
(single-file layout required by the course autograder).

## Design

| Piece | Role |
| --- | --- |
| `Hotel` | Producer thread. Fluctuates the room price and raises `PriceCut` when it drops. |
| `TravelAgent` | Five consumer threads. On a price cut, each builds an `Order` and writes it into the shared buffer. |
| `MultiCellBuffer` | Bounded buffer of three cells. Two `Semaphore`s track filled vs. free cells; separate read and write lock objects, with `Monitor.TryEnter` on the read path so a blocked reader releases its permit instead of deadlocking. |
| `OrderProcessing` | Pulls orders out of the buffer and raises `OrderProcess` with the computed amount. |
| `Order` | The data record passed through the buffer. |

Three delegate types wire the pieces together without direct references:
`PriceCutEvent`, `OrderCreationEvent`, and `OrderProcessEvent`. `MainClass.Main` starts the hotel
thread, subscribes the handlers, starts five agent threads, then joins everything.

## Running

Open `ConsoleApp1.sln` and run. Output traces subscription, price cuts, order creation, and
order confirmation as the threads interleave — so it differs run to run.

Target framework: .NET Framework 4.7.2.
