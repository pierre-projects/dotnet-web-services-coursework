# .NET Coursework Archive

Coursework from **CSE 445 — Distributed Software Development** (ASU), written in C# on the
.NET Framework with WCF, ASMX web services, ASP.NET Web Forms, and Windows Forms.

This repository is an archive kept for reference — it preserves the projects as they were
submitted, with build output and NuGet packages stripped out. It is not maintained, and the
projects are not meant to be run as a single application: each top-level folder is an
independent Visual Studio solution.

## Projects

| Folder | What it is | Stack |
| --- | --- | --- |
| [`00-lab-wcf-sum-service-and-client`](00-lab-wcf-sum-service-and-client) | Warm-up: a two-operand WCF arithmetic service plus a Web Forms page that consumes it through a generated proxy | WCF, Web Forms, .NET FW 4.7.2 |
| [`01-wcf-temperature-and-string-sort`](01-wcf-temperature-and-string-sort) | Assignment 1 — a WCF service exposing `c2f` / `f2c` / `sort`, a Web Forms client for it, and a Windows Forms client that consumes two *external* SOAP services | WCF, Web Forms, WinForms, .NET FW 4.7.2 |
| [`02-multithreaded-order-processing`](02-multithreaded-order-processing) | Assignment 2 — multithreaded hotel/travel-agent simulation: delegates and events, a bounded `MultiCellBuffer` guarded by semaphores, five concurrent agent threads | C# threading, delegates/events, .NET FW 4.7.2 |
| [`03-wsdl-discovery-service`](03-wsdl-discovery-service) | Assignment 3 — a WCF service that fetches a page and returns every WSDL endpoint it can find, via regex over link attributes and plain-text URLs | WCF, `WebClient`, regex, .NET FW 4.7.2 |
| [`05-06-chord-analysis-service-and-site`](05-06-chord-analysis-service-and-site) | Assignments 5–6 (two-person project) — an ASMX web service that identifies a musical chord from note names, wrapped in a Web Forms site with registration, login, role-separated Member/Staff areas, and a session/cookie state demo | ASMX, Web Forms, XML storage, .NET FW 4.8 |

Each folder has its own README with the detail.

## Building

These are **.NET Framework** projects (4.7.2 / 4.8), not .NET Core / .NET 5+. To open them:

1. Visual Studio 2022 with the **ASP.NET and web development** and **.NET desktop development**
   workloads, plus the .NET Framework 4.7.2 and 4.8 targeting packs.
2. Open the `.sln` in the folder you want.
3. Restore NuGet packages (`packages/` is intentionally not committed — right-click the solution →
   *Restore NuGet Packages*, or run `nuget restore`).
4. Service + client pairs expect the **service** to be running first, under IIS Express, before the
   client's generated proxy will resolve. The service address lives in the client's `Web.config` /
   `App.config` and will likely need to be repointed at whatever port IIS Express assigns locally.

The WinForms client in project 01 calls third-party SOAP endpoints that were live in 2025; those
calls will fail if the endpoints have since gone away. The service references and generated proxies
are committed, so the code still reads and compiles.

## Notes

- Projects were written between September and November 2025.
- Visual Studio template scaffolding (designer files, `Web.Debug.config`, generated service proxies)
  is left in place deliberately — removing it would stop the solutions from opening cleanly.
- The original folder names were things like `Asignment1part123` and `Assignmnet56`; top-level
  folders have been renamed to describe what they contain, but project, namespace, and class names
  inside each solution are untouched so the solutions still load.
- Project 05-06 was a two-person assignment. The copy here is this author's portion — the component
  table on its landing page shows the split, and the teammate's captcha control and password-hashing
  DLL were never integrated into this copy. Contributor names in the page have been replaced with
  "Author" and "Teammate".
- Credentials in `App_Data/*.xml` (project 05-06) are seeded demo accounts, not real secrets; they
  are stored in the clear because the hashing DLL they were meant to pass through was a stub at the
  time (see that project's README). A placeholder email address was replaced with `demo@example.com`.
- This is submitted coursework, published as a work sample. If you are currently enrolled in
  CSE 445, copying from it is an academic-integrity violation — read it, don't submit it.
