# How to build
## Making changes to the wrapper
When done making changes to the wrapper, build the AnitomyNET_Wrapper project in x64 and x86 Release platform configurations. This will place them in the right folder.

## Building for NuGET
- Don't forget to change the version number via Properties => Package.
- Build the AnitomyNEt project in Release mode, this will make a NuGET package file.
- After you built the `.nupkg` package file, the `AnitomyNET_Wrapper_64.dll` and `AnitomyNET_Wrapper_86.dll` wrapper files are not included yet. 
- Open the `.nupkg` file in [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer):
- right mouse click -> `Add Build Folder`
- Place the 2 wrapper files and the `Anitomy.NET.props` (you can find them in the `netstandard1.*` folder) in the build folder.
It should look like this:
![Package contents screenshot](https://raw.githubusercontent.com/MikeYaye/anitomy.NET/master/CorrectPackageContentNuGet.png)

You should test it in a seperate project, install the NuGET package from the file with `Install-Package SomePackage -Source "path/to/nupkg-file"` in the Package Manager Console.  
After that, the package file is ready to upload to NuGET.