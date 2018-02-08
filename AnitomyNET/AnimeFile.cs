namespace AnitomyNET
{
    public class AnimeFile
    {
        public string IterateFirst;
        public string AnimeSeasonPrefix;
        public string AnimeTitle;
        public string AnimeType;
        public string AnimeYear;
        public string AudioTerm;
        public string DeviceCompatibility;
        public string EpisodeNumber;
        public string EpisodeNumberAlt;
        public string EpisodePrefix;
        public string EpisodeTitle;
        public string FileChecksum;
        public string FileExtension;
        public string FileName;
        public string Language;
        public string Other;
        public string ReleaseGroup;
        public string ReleaseInformation;
        public string ReleaseVersion;
        public string Source;
        public string Subtitles;
        public string VideoResolution;
        public string VideoTerm;
        public string VolumeNumber;

        public AnimeFile(string[] items)
        {
            IterateFirst = items[0] == "" ? null : items[0];
            AnimeSeasonPrefix = items[1] == "" ? null : items[1];
            AnimeTitle = items[2] == "" ? null : items[2];
            AnimeType = items[3] == "" ? null : items[3];
            AnimeYear = items[4] == "" ? null : items[4];
            AudioTerm = items[5] == "" ? null : items[5];
            DeviceCompatibility = items[6] == "" ? null : items[6];
            EpisodeNumber = items[7] == "" ? null : items[7];
            EpisodeNumberAlt = items[8] == "" ? null : items[8];
            EpisodePrefix = items[9] == "" ? null : items[9];
            EpisodeTitle = items[10] == "" ? null : items[10];
            FileChecksum = items[11] == "" ? null : items[11];
            FileExtension = items[12] == "" ? null : items[12];
            FileName = items[13] == "" ? null : items[13];
            Language = items[14] == "" ? null : items[14];
            Other = items[15] == "" ? null : items[15];
            ReleaseGroup = items[16] == "" ? null : items[16];
            ReleaseInformation = items[17] == "" ? null : items[17];
            ReleaseVersion = items[18] == "" ? null : items[18];
            Source = items[19] == "" ? null : items[19];
            Subtitles = items[20] == "" ? null : items[20];
            VideoResolution = items[21] == "" ? null : items[21];
            VideoTerm = items[22] == "" ? null : items[22];
            VolumeNumber = items[23] == "" ? null : items[23];
    }
    }
}
