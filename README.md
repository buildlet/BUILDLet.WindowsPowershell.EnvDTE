BUILDLet Utilities (EnvDTE) for Windows PowerShell
==================================================

## Introduction 
This project provides a Cmdlet for Windows PowerShwll to obtain Active Configuration Name, which is generally "Debug" or "Release", of Visual Studio Solution.

## Getting Started
Deliverable of this project is only a DLL file, which is including a Windows PowerShell Cmdlet named "Get-DTEActiveConfigurationName".  
In order to use it, please do the followings.

  1. Put the file "BUILDLet.WindowsPowerShell.EnvDTE.dll" onto your workspace.
  2. Import this DLL file as the module as the following.

```PowerShell
Import-Module .\BUILDLet.WindowsPowerShell.EnvDTE.dll
```
  3. Use the Cmdlet as the following for example.

```PowerShell
Get-DTEActiveConfigurationName -Path ..\MySolution.sln
```

## Build and Test
This project (Visual Studio Solution) is built and tested on Visual Studio.

## License
This project is licensed under the [MIT](https://opensource.org/licenses/MIT) License.
