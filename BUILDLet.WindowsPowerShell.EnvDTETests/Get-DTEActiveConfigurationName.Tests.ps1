<###############################################################################
 The MIT License (MIT)

 Copyright (c) 2020 Daiki Sakamoto

 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in
 all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 THE SOFTWARE.
################################################################################>

#
# This is a PowerShell Unit Test file.
# You need a unit test framework such as Pester to run PowerShell Unit tests. 
# You can download Pester from https://go.microsoft.com/fwlink/?LinkID=534084
#

# SET Active Configuration Name
$ActiveConfirutationName = 'Debug'

# GET Module Path
$module_name = 'BUILDLet.WindowsPowerShell.EnvDTE'
$module_filename = "$module_name.dll"
$module_path = $PSScriptRoot | Join-Path -ChildPath 'bin' | Join-Path -ChildPath $ActiveConfirutationName | Join-Path -ChildPath $module_filename

# Import Module
$module_path | Import-Module

Describe "Get-DTEActiveConfigurationName" {

	Context 'when Solution File Path is specified to $Path parameter' {

        $TestCases = @(

            # Absolute Path
            @{
                Expected = $ActiveConfirutationName
                InputPath = $PSScriptRoot | Join-Path -ChildPath '..\BUILDLet.WindowsPowerShell.EnvDTE.sln'
            }

            # Relative Path
            @{
                Expected = $ActiveConfirutationName
                InputPath = '..\BUILDLet.WindowsPowerShell.EnvDTE.sln'
            }
        )

		It "returns Active ConfigurationName" -TestCases $TestCases {
            
            # PARAMETER(S)
            Param($Expected, $InputPath)

            # ARRANGE
            $PSScriptRoot | Set-Location

            # ACT
            $actual = Get-DTEActiveConfigurationName -Path $InputPath

            # OUTPUT
            Write-Host "`t`t" + "Expected: `"$Expected`""
            Write-Host "`t`t" + "Actual  : `"$actual`""

            # ASSERT
            $actual | Should Be $Expected
		}
	}
}