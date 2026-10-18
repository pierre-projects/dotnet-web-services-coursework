# Assignments 5–6 — ASMX Chord Service + Web Forms Site

The largest project here: a musical chord-analysis web service, published as ASMX and consumed by
an ASP.NET Web Forms site that adds authentication, role-separated areas, and a state-management
demo.

This was a **two-person assignment**. The component table on `Default.aspx` records who built what;
this copy is the author's portion, captured before the teammate's two components (a captcha user
control and a password-hashing DLL) were integrated — see *Known gaps* below.

## The service — `MusicKeyService.asmx`

`AnalyzeChord(string notes)` takes note names (`"C E G"`, `"A C# E"`) and returns the chord
quality. Internally:

- a `NoteMap` dictionary maps note names to semitone offsets from C, handling enharmonic
  equivalents (`C#`/`Db`, `D#`/`Eb`, …) via a case-insensitive comparer;
- `IsValidNoteToken` validates each token — a letter A–G, an optional `#` or `b`, and an explicit
  rejection of `B#`;
- intervals are derived from the semitone offsets to name the chord quality.

Invalid or empty input comes back as a readable message rather than an exception, so the SOAP
contract stays clean.

## The site

| Page | What it covers |
| --- | --- |
| `Default.aspx`, `About.aspx` | Site shell, master page, bundling |
| `analyzeChordTryIt.aspx` | Front end for the service, called through the `MusicKeyRef` generated proxy |
| `Register.aspx` | Account creation; credentials written to XML through `PassBroker` |
| `Login.aspx` | Runs the submitted password through `PassBroker` and matches it against the XML store; username compared case-insensitively, the stored value case-sensitively |
| `Member/Member.aspx`, `Staff/Staff.aspx` | Role-separated areas, each with its own `Web.config` authorization rules |
| `StateDemo.aspx` | Session state vs. cookies side by side — writes `Session["Demo*"]` values and a `UserProfile` `HttpCookie`, then reads them back on postback |
| `ViewSwitcher.ascx`, `Site.Mobile.Master` | Friendly URLs and desktop/mobile view switching |

Accounts are stored as XML in `App_Data/Members.xml` and `App_Data/Staff.xml` — seeded demo
accounts, not real credentials.

## Known gaps

This is the state the project was in, not a finished product:

- **`PassBroker.HashPassword` is a pass-through stub** — it returns the plaintext it was given, with
  a comment marking where the real DLL or service call goes. It exists as a seam: registration and
  login both route through it, so the real hashing implementation could drop in without touching
  either call site. In this copy, though, nothing is actually hashed, which is why the seeded
  accounts in `App_Data` are plaintext.
- **The captcha on `Register.aspx` is a placeholder**, awaiting the teammate's user control.
- The service reference points at the ASU course server
  (`webstrar39.fulton.asu.edu`), which is no longer expected to answer; the generated proxy under
  `Connected Services/MusicKeyRef/` is committed, so the project still compiles.

## Running

Open `WebApplication1.sln`, restore NuGet packages (Bootstrap 5, jQuery 3.7, ASP.NET Web
Optimization — `packages/` is not committed), then run under IIS Express. The service and the site
are the same project, so the `MusicKeyRef` proxy resolves locally.

Target framework: .NET Framework 4.8.
