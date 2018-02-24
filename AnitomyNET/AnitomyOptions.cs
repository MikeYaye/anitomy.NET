/* This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. See the LICENCE file for more info.*/

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
