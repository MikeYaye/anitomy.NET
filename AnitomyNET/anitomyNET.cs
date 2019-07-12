/* This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. See the LICENCE file for more info.*/

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace AnitomyNET
{

    public class Anitomy
    {
        private static bool platformIs64 = IntPtr.Size == 8;

        private static class Platform64
        {
            [DllImport("AnitomyNET_Wrapper_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.SafeArray)]
            public static extern string[] parse_anime_file_name(string fileName, string[] ignoredStrings, int ignoredStringsLength, string allowedDelimiters, bool parseEpisodeNumber, bool parseEpisodeTitle, bool parseFileExtension, bool parseReleaseGroup);
        }

        private static class Platform86
        {
            [DllImport("AnitomyNET_Wrapper_86.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.SafeArray)]
            public static extern string[] parse_anime_file_name(string fileName, string[] ignoredStrings, int ignoredStringsLength, string allowedDelimiters, bool parseEpisodeNumber, bool parseEpisodeTitle, bool parseFileExtension, bool parseReleaseGroup);
        }


        /// <summary>
        /// Parses anime file name into an AnimeFile object
        /// </summary>
        public static AnimeFile Parse(string fileName, AnitomyOptions options = null)
        {
            if (options == null) options = new AnitomyOptions();

            string[] parsedResult = platformIs64 ? Platform64.parse_anime_file_name(
                    fileName,
                    options.ignoredStrings ?? new string[0],
                    options.ignoredStrings?.Length ?? 0,
                    options.allowedDelimiters,
                    options.parseEpisodeNumber,
                    options.parseEpisodeTitle,
                    options.parseFileExtension,
                    options.parseReleaseGroup
                )
                : Platform86.parse_anime_file_name(
                    fileName,
                    options.ignoredStrings ?? new string[0],
                    options.ignoredStrings?.Length ?? 0,
                    options.allowedDelimiters,
                    options.parseEpisodeNumber,
                    options.parseEpisodeTitle,
                    options.parseFileExtension,
                    options.parseReleaseGroup
                );
            return new AnimeFile(parsedResult);
        }
    }
}
