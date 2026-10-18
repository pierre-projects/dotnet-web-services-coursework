# Assignment 3 — WSDL Discovery Service

A WCF service that takes a URL, downloads the page, and returns every WSDL endpoint it can find
on it — a small service-discovery crawler.

## Design

`IService1` exposes one operation: `string[] getWsdlAddress(string url)`.

`Service1.svc.cs` implements it in two passes over the downloaded HTML:

1. **Attribute pass** — a compiled regex pulls URLs out of `href`, `src`, and `action` attributes.
2. **Plain-text pass** — a second regex catches absolute `http(s)://` URLs that aren't in an
   attribute, as a fallback.

Candidates are concatenated, then filtered by `LooksLikeWsdl`, which accepts anything containing
`.wsdl` or `?wsdl` (case-insensitive). Download failures and blank input return an empty array
rather than throwing across the service boundary.

## Running

Open `WcfService1.sln` and start it under IIS Express; the WCF Test Client will launch against
`Service1.svc`, where you can call `getWsdlAddress` with a URL directly.

Target framework: .NET Framework 4.7.2.
