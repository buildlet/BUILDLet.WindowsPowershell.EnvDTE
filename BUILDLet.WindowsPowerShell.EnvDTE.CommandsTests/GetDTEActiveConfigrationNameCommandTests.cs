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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BUILDLet.WindowsPowerShell.EnvDTE.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;

namespace BUILDLet.WindowsPowerShell.EnvDTE.Commands.Tests
{
    [TestClass]
    public class GetDTEActiveConfigrationNameCommandTests
    {
        // Test Driver of ActiveConfigrationName property of GetDTEActiveConfigrationNameCommand class
        public class ActiveConfigrationNameTestDriver : GetDTEActiveConfigrationNameCommand
        {
            // GET ActiveConfigurationName
            public string GetActiveConfigurationNameBySolutionFile(string path) =>
                GetDTEActiveConfigrationNameCommand.GetDTEActiveConfigurationNameBySolutionFile(path);
        }


        [TestMethod]
        public void ActiveConfigurationNameTest()
        {
            // ARRANGE

            // SET File Path
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\BUILDLet.WindowsPowerShell.EnvDTE.sln");

            // SET Expected
            var expected =
#if DEBUG
                "Debug";
#else
                "Release";
#endif

            // ACT
            var actual = new ActiveConfigrationNameTestDriver().GetActiveConfigurationNameBySolutionFile(path);

            // Print Actual
            Console.WriteLine($"Solution File Path = \"{path}\"");
            Console.WriteLine($"Expected\t= \"{expected}\"");
            Console.WriteLine($"Actual\t= \"{actual}\"");

            // ASSERT
            Assert.AreEqual(expected, actual);
        }
    }
}