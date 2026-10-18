# Assignment 1 — Service Publishing and Consumption

Two solutions. The first publishes a WCF service and consumes it from a web client; the second
consumes two *externally hosted* SOAP services from a desktop client.

## `parts-1-3-wcf-service/` — own service + web client

`Assignment1.sln` contains:

- **`Asignment1part123`** — the WCF service. `IService1` exposes three operations:
  - `int c2f(int c)` — Celsius to Fahrenheit
  - `int f2c(int f)` — Fahrenheit to Celsius
  - `string sort(string s)` — sorts a delimited list of numbers
- **`TempConvertAndStringSort`** — ASP.NET Web Forms client. `WebForm1.aspx` has three buttons,
  one per operation; each handler news up `ServiceReference1.Service1Client` and binds the
  result to a label.

## `parts-4-5-winforms-search-client/` — consuming third-party services

`SearchEngineWithServices.sln` contains a Windows Forms app that combines three things in one form:

- an embedded `WebBrowser` control driven by a URL text box (with scheme normalization, so
  `example.com` becomes `https://example.com`), plus `ScriptErrorsSuppressed` to keep the legacy
  control quiet;
- **encrypt / decrypt** against an external SOAP service, called through two different bindings
  (`BasicHttpsBinding_Encryption` and the default);
- a **stock quote** lookup against another external SOAP service
  (`BasicHttpsBinding_Stockquote`), with the call wrapped in exception handling.

The generated proxies are committed under `Connected Services/`, so the project compiles even
though the third-party endpoints it targeted in 2025 may no longer answer.

Target framework: .NET Framework 4.7.2 throughout.
