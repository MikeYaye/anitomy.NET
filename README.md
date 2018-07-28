# Anitomy.NET
.NET wrapper for [Anitomy](https://github.com/erengy/anitomy), a library for parsing anime video filenames.

# Installation
Via [Nuget](https://www.nuget.org/packages/Anitomy.NET):
```
Install-Package Anitomy.NET 
```

## Compatibility
Because this library uses [.NET Standard](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/) 1.1, you can use it on a wide variety of platforms. See [this list](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.1.md#platform-support) for the minimum platform versions.

# C# Example
After putting `using AnitomyNET;` at the top of your code, you can parse a filename with the following code:
``` C#
var result = Anitomy.Parse("[TaigaSubs]_Toradora!_(2008)_-_01v2_-_Tiger_and_Dragon_[1280x720_H.264_FLAC][1234ABCD].mkv");
```
`result` now has the following:  
**AnimeTitle** *Toradora!*  
**AnimeYear** *2008*  
**AudioTerm** *FLAC*  
**EpisodeNumber** *01*  
**EpisodeTitle** *Tiger and Dragon*  
**FileChecksum** *1234ABCD*  
**FileExtension** *mkv*  
**FileName** *[Ouroboros]_Fullmetal_Alchemist_Brotherhood_-_01.mkv*  
**ReleaseGroup** *TaigaSubs*  
**ReleaseVersion** *2*  
**VideoResolution** *1280x720*  
**VideoTerm** *H.264*  

# Options
You can also give the `Parse` method options, an example:
``` C#
var options = new AnitomyOptions()
{
    ignoredStrings = new[] { "BOX" },
    parseReleaseGroup = false,
    allowedDelimiters = "-."
};

var result = Anitomy.Parse("[Ouroboros]_Fullmetal_Alchemist_BrotherhoodBOX_-_01.mkv", options);
```
`result` now has the following:  
**AnimeTitle** *_Fullmetal_Alchemist_Brotherhood*  
**EpisodeNumber** *01*  
**FileExtension** *mkv*  
**FileName** *[Ouroboros]_Fullmetal_Alchemist_Brotherhood_-_01.mkv*  
**ReleaseGroup** NULL  

As you can see, "BOX" is ignored, ReleaseGroup is not parsed  and `_` will not be used as a delimiter.
