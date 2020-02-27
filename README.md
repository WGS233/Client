# Client
All client-related projects (Launcher, EmuLib, Assembly-CSharp)

## Requirements
- Escape From Tarkov 0.12.3.5985
- Visual Studio 2017
- .NET Framework 4.6.1

## Projects:
- EmuLib: hooking additional functionality into Escape From Tarkov
- Launcher: a lightweight game launcher for proper starting of Escape From Tarkov with EmuTarkov

## Setup
The repository is self-contained; no setup is required.

## Build
1. VS2017 -> Build -> Rebuild project
2. Copy `EmuLib/bin/<target>/emulib.dll` into `<gamedir>/EscapeFromTarkov_Data/Managed/`
3. Copy `Launcher/bin/<target>/EmuTarkov-Launcher.exe` into `<gamedir>`

## Remarks
- Some referrences are shared across projects. These are located in `Shared/References`.
- EmuLib only works with a cleaned assembly-csharp.dll with edits as the project relies on the obfuscated DLL for proper hooking.
- Launcher depends on EmuLib for HttpUtils.
