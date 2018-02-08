using System;
using System.Collections.Generic;
using System.Text;

namespace AnitomyNET
{
    public class AnitomyOptions
    {
        public string[] ignoredStrings = null;
        public string allowedDelimiters = " _.&+,|";
        public bool parseEpisodeNumber = true;
        public bool parseEpisodeTitle = true;
        public bool parseFileExtension = true;
        public bool parseReleaseGroup = true;
    }
}
