When cloning this project, you will very likely get the folloing error when attempting to run it for the first time:

Could not find a part of the path '~\CPIS-Senior-Project\roslyn\csc.exe'.

This occurs due to an issue with the way the NuGet Package Manager applies its package updates.
To resolve this in Visual Studio 2022, click Tools -->  NuGet Package Manager --> Package Manager Console.
When the console loads and you get a prompt showing "PM>", copy, paste and run the code below to update CSC to the required version:

Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
