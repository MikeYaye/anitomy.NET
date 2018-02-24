/* This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. See the LICENCE file for more info.*/

using System.Runtime.InteropServices;

namespace AnitomyNET
{

    public class Anitomy
    {
        [DllImport("AnitomyNET_Wrapper.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.SafeArray)]
        private static extern string[] parse_anime_file_name(string fileName, string[] ignoredStrings, int ignoredStringsLength, string allowedDelimiters, bool parseEpisodeNumber, bool parseEpisodeTitle, bool parseFileExtension, bool parseReleaseGroup);

        /// <summary>
        /// Parses anime file name into an AnimeFile object
        /// </summary>
        public static AnimeFile Parse(string fileName, AnitomyOptions options = null)
        {
            if (options == null)
                options = new AnitomyOptions();

            string[] parsedResult = parse_anime_file_name(
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
