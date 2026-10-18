# WCF Sum Service + Web Forms Client

A warm-up exercise: the smallest end-to-end WCF round trip, used to get the
service-reference/proxy workflow working before the graded assignments.

## Projects

- **`WcfService2`** — WCF service. `IService1` declares a single operation,
  `double GetSum(double a, double b)`, implemented in `Service1.svc.cs`.
- **`WebApplication1`** — ASP.NET Web Forms client. `WebForm1.aspx` takes two numbers;
  the code-behind calls the service through the generated `ServiceReference1.Service1Client`
  proxy and writes the result into a label.

Both projects live in `WcfService2.sln`.

## Running

Start `WcfService2` under IIS Express first, then run `WebApplication1`. If the service lands on a
different port than it did originally, update the endpoint address in
`WebApplication1/Web.config` to match.

Target framework: .NET Framework 4.7.2.
