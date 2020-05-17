/***************************************************************************************************
The MIT License (MIT)

Copyright 2020 Daiki Sakamoto

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
associated documentation files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, 
sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is 
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or 
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT 
NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
***************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management.Automation;   // for PowerShell
using System.Runtime.InteropServices; // for Mashall Class
using EnvDTE;

namespace BUILDLet.WindowsPowerShell.EnvDTE.Commands
{
    [Cmdlet(VerbsCommon.Get, "DTEActiveConfigurationName")]
    [CmdletBinding()]
    [OutputType(typeof(string))]
    public class GetDTEActiveConfigrationNameCommand : PSCmdlet
    {
        // ----------------------------------------------------------------------------------------------------
        // Parameter(s)
        // ----------------------------------------------------------------------------------------------------

        // .PARAMETER Path
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, HelpMessage = "Specifies the path of the location of Visual Studio Solution file (*.sln).")]
        [Alias("PSPath")]
        public string Path { get; set; }


        // ----------------------------------------------------------------------------------------------------
        // Pre-Processing Operations
        // ----------------------------------------------------------------------------------------------------
        // protected override void BeginProcessing() { }


        // ----------------------------------------------------------------------------------------------------
        // Input-Process Operations
        // ----------------------------------------------------------------------------------------------------
        protected override void ProcessRecord()
        {
            // Convert Path
            if (!System.IO.Path.IsPathRooted(this.Path))
            {
                this.Path = System.IO.Path.Combine(this.SessionState.Path.CurrentFileSystemLocation.Path, this.GetResolvedProviderPathFromPSPath(this.Path, out _)[0]);
            }

            // Validation (File Exsistence)
            if (!File.Exists(this.Path)) { throw new FileNotFoundException(); }

            // OUTPUT
            this.WriteObject(GetDTEActiveConfigrationNameCommand.GetDTEActiveConfigurationNameBySolutionFile(this.Path));
        }


        // ----------------------------------------------------------------------------------------------------
        // Post-Processing Operations
        // ----------------------------------------------------------------------------------------------------
        // protected override void EndProcessing() { }


        // ----------------------------------------------------------------------------------------------------
        // Static Method(s)
        // ----------------------------------------------------------------------------------------------------

        // Active Configuration Name
        protected static string GetDTEActiveConfigurationNameBySolutionFile(string path) => ((dynamic)Marshal.BindToMoniker(path)).SolutionBuild.ActiveConfiguration.Name;
    }
}
