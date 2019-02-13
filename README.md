If you get the error

> Could not find a part of the path … bin\roslyn\csc.exe

run this in the Package Manager Console:

`Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r`
