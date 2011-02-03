using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using iTunesLib;
using TagLib;

namespace iTunes.Duplicate.Gui
{
    public class iTunes
    {
        private FileInfo[] arryTracks;
        private ArrayList arryTrackTitles;
        private ArrayList arryTrackArtists;
        private ArrayList arryTrackLength;
        public ArrayList Tracks = new ArrayList();
        private DirectoryInfo destinationDir;
        private DirectoryInfo sourceDir;
        private System.Collections.Specialized.StringCollection collectionTitleFilters;

        public iTunes()
        {

        }

        public iTunes(string sourceDirectory, string destinationDirectory, System.Collections.Specialized.StringCollection collectionTitleFilters)
        {
            destinationDir = new DirectoryInfo(destinationDirectory);
            sourceDir = new DirectoryInfo(sourceDirectory);
            
            this.collectionTitleFilters = collectionTitleFilters;

            if (!sourceDir.Exists)
            {
                Exception ex = new Exception("Source directory does not exist.");
                throw ex;
            }

            if (!destinationDir.Exists)
            {
                Exception ex = new Exception("Destination directory does not exist.");
                throw ex;
            }

            CheckSourceDirectory(sourceDirectory);
        }

        private string FormatTitle(string trackTitle)
        {
            try
            {
                StringBuilder newTitle = new StringBuilder(trackTitle);

                foreach (string filter in collectionTitleFilters)
                {
                    newTitle.Replace(filter, "");
                }

                return newTitle.ToString().ToLower();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ArrayList FormatTitle()
        {
            try
            {
                ArrayList newArryTrackTitles = new ArrayList();

                foreach (string title in arryTrackTitles)
                {
                    StringBuilder newTitle = new StringBuilder(title);

                    foreach (string filter in collectionTitleFilters)
                    {
                        newTitle.Replace(filter, "");
                    }
                    newArryTrackTitles.Add(newTitle.ToString().ToLower());
                }

                return newArryTrackTitles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddFolderToLibrary()
        {
            StringBuilder folderPath = new StringBuilder();
            folderPath.Append(destinationDir.FullName);

            if (destinationDir.FullName.ToString().Substring(folderPath.Length - 1, 1) != "\\")
                folderPath.Append("\\");

            folderPath.Append(sourceDir.Name);

            DirectoryInfo newPath = new DirectoryInfo(folderPath.ToString());
            if (!newPath.Exists)
            {
                Exception ex = new Exception("Can not locate folder to import into library.");
                throw ex;
            }

            FileInfo[] tracks = newPath.GetFiles("*.mp3");

            foreach (FileInfo track in tracks)
            {
                if (!AddFileToLibrary(track.FullName))
                {
                    continue;
                }
            }
        }

        private bool AddFileToLibrary(string path)
        {
            try
            {
                iTunesAppClass iTunesLib = new iTunesAppClass();
                IITOperationStatus status = iTunesLib.LibraryPlaylist.AddFile(path);

                while (status.InProgress)
                {
                    System.Threading.Thread.Sleep(10);
                }

                if ((status.Tracks != null) && (status.Tracks.Count > 0))
                {
                    // successfully imported raw file without conversion
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        /// <summary>
        /// Experimental search function.
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="searchFields"></param>
        /// <returns></returns>
        private IITTrackCollection Search(string searchText, ITPlaylistSearchField searchFields)
        {
            iTunesAppClass iTunesLib = new iTunesAppClass();
            IITTrackCollection results = iTunesLib.LibraryPlaylist.Search(searchText, searchFields);

            if (results != null)
            {
                return results;
                //foreach (IITTrack track in results)
                //{
                //    if (track != null)
                //    {
                //        return true;
                //    }
                //}
            }
            return null;
        }

        public void CheckLibraryForDuplicates(string searchText)
        {
            State.StateID state = new State.StateID();
            IITTrackCollection resultTracks = null;
            StringBuilder newTrackTitle;
            string newTitle = null;

            foreach (string title in arryTrackTitles)
            {
                if (title.Contains('(') && title.Contains(')'))
                {
                    int start = title.IndexOf("("); //16
                    int end = title.IndexOf(")"); //36
                    newTrackTitle = new StringBuilder(title.Substring(0, start).Trim());
                }
                else
                    newTrackTitle = new StringBuilder(title.Trim());

                newTrackTitle.Append(" ");
                newTrackTitle.Append(FormatArtists(arryTrackArtists[arryTrackTitles.IndexOf(title)].ToString()));

                state = State.StateID.ReadyToCheckTitles;

                if (state == State.StateID.ReadyToCheckTitles)
                {
                    resultTracks = Search(newTrackTitle.ToString(), ITPlaylistSearchField.ITPlaylistSearchFieldVisible);
                    if (resultTracks != null)
                        state = State.StateID.ReadyToCheckTime;
                }

                if (state == State.StateID.ReadyToCheckTime)
                {
                    foreach (IITTrack resultTrack in resultTracks)
                    {
                        TimeSpan trackLength = (TimeSpan)arryTrackLength[arryTrackTitles.IndexOf(title)];
                        TimeSpan libraryTrackLengh = FormatTrackTime(resultTrack.Time);

                        TimeSpan difference = trackLength.Subtract(libraryTrackLengh);

                        if (difference.TotalSeconds <= 2)
                        {
                            Track track = (Track)Tracks[arryTrackTitles.IndexOf(title)];
                            track.Duplicate = true;
                        }
                    }
                }
            }
        }

        private TimeSpan FormatTrackTime(string trackTime)
        {
            TimeSpan trackLength = TimeSpan.Parse(trackTime);

            if (trackLength.TotalHours >= 1)
                return TimeSpan.Parse("00:" + trackTime);
            else
                return trackLength;
        }

        public void CheckLibraryForDuplicates()
        {
            try
            {
                iTunesAppClass iTunesLib = new iTunesAppClass();
                IITTrackCollection tracks = iTunesLib.LibraryPlaylist.Tracks;
                Dictionary<string, IITTrack> trackCollection = new Dictionary<string, IITTrack>();
                int trackCount = tracks.Count;

                for (int i = trackCount; i > 0; i--)
                {
                    if (tracks[i].Kind == ITTrackKind.ITTrackKindFile)
                    {
                        string trackName = FormatTitle(tracks[i].Name);
                        string trackArtist = FormatArtists(tracks[i].Artist);
                        TimeSpan trackTime = FormatTime(tracks[i].Time);
                        CheckDuplicate(trackName.Trim(), trackArtist.Trim(), trackTime);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CheckDuplicate(string trackName, string trackArtist, TimeSpan libraryTrackLength)
        {
            try
            {
                State.StateID state = new State.StateID();
                state = State.StateID.ReadyToCheckTitles;

                //1. Check if Titles are the Same
                if (state == State.StateID.ReadyToCheckTitles)
                {
                    if (arryTrackTitles.Contains(trackName))
                        state = State.StateID.ReadyToCheckArtists;
                }

                //2. Check first two chars of artist are the same.
                if (state == State.StateID.ReadyToCheckArtists)
                {
                    string formattedArtist = FormatArtists(arryTrackArtists[arryTrackTitles.IndexOf(trackName)].ToString());
                    if (formattedArtist == trackArtist)
                        state = State.StateID.ReadyToCheckTime;
                }

                //3. Check if Times are same +- 2 seconds
                if (state == State.StateID.ReadyToCheckTime)
                {
                    TimeSpan trackLength = (TimeSpan)arryTrackLength[arryTrackTitles.IndexOf(trackName)];
                    TimeSpan difference = trackLength.Subtract(libraryTrackLength);

                    if (difference.TotalSeconds <= 2)
                    {
                        foreach (Track track in Tracks)
                        {
                            if (track.Title == trackName)
                                track.Duplicate = true;
                        }

                        state = State.StateID.Finished;
                    }
                    else
                        state = State.StateID.Finished;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MoveToDestination(string destinationDirectory)
        {
            try
            {
                StringBuilder destDirName = new StringBuilder(destinationDirectory);

                if (destinationDirectory.Substring(destinationDirectory.Length - 1, 1) != "\\")
                    destDirName.Append("\\");

                destDirName.Append(sourceDir.Name);
                copyDirectory(sourceDir.FullName, destDirName.ToString());
                sourceDir.Delete(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void copyDirectory(string Src, string Dst)
        {
            try
            {
                String[] Files;

                if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                    Dst += Path.DirectorySeparatorChar;
                if (!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
                Files = Directory.GetFileSystemEntries(Src);
                foreach (string Element in Files)
                {
                    // Sub directories
                    if (Directory.Exists(Element))
                        copyDirectory(Element, Dst + Path.GetFileName(Element));
                    // Files in directory
                    else
                        System.IO.File.Copy(Element, Dst + Path.GetFileName(Element), true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void DeleteDuplicates()
        {
            foreach (Track track in Tracks)
            {
                if (track.Duplicate)
                    DeleteTrack(track.Path);
            }
        }

        private void DeleteTrack(string fileName)
        {
            try
            {
                FileInfo file = new FileInfo(fileName);
                file.Delete();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void CheckSourceDirectory(string sourceDirectory)
        {
            try
            {
                arryTrackTitles = new ArrayList();
                arryTrackArtists = new ArrayList();
                arryTrackLength = new ArrayList();
                DirectoryInfo sourceDir = new DirectoryInfo(sourceDirectory);
                arryTracks = sourceDir.GetFiles("*.mp3");

                if (arryTracks.Length > 0)
                {

                    foreach (FileInfo track in arryTracks)
                    {
                        TagLib.File f = TagLib.File.Create(track.FullName);
                        string title = StringCleanUp(f.Tag.Title);
                        string artist = StringCleanUp(f.Tag.JoinedPerformers);
                        TimeSpan trackTime = f.Properties.Duration;

                        if (String.IsNullOrEmpty(title))
                        {
                            Exception ex = new Exception("No Mp3 tag information found. Please add manually.");
                            throw ex;
                        }

                        arryTrackTitles.Add(title);
                        arryTrackArtists.Add(artist);
                        arryTrackLength.Add(trackTime);
                        Tracks.Add(new Track(FormatTitle(title), artist, trackTime, track.FullName, false));
                    }
                }
                else
                {
                    Exception ex = new Exception("No Mp3 files found.");
                    throw ex;
                }

                arryTrackTitles = FormatTitle();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string StringCleanUp(string title)
        {
            if (title != null)
            {
                StringBuilder titleChar = new StringBuilder(title.Length);

                foreach (char s in title)
                {
                    titleChar.Append(Char.IsControl(s) ? '\'' : s);
                }

                return titleChar.ToString();
            }
            return null;
        }

        private string FormatArtists(string artist)
        {
            try
            {
                if (artist.Length >= 2)
                    return artist.Substring(0, 2).ToLower();
                else
                    return artist.ToLower();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TimeSpan FormatTime(string trackLength)
        {
            try
            {
                string[] arryTrackLength = trackLength.Split(':');

                if (arryTrackLength.Length == 0)
                {
                    return TimeSpan.MinValue;
                }
                else if (arryTrackLength.Length == 2)
                {
                    TimeSpan ts = new TimeSpan(0, Convert.ToInt32(arryTrackLength[0]), Convert.ToInt32(arryTrackLength[1]));
                    return ts;
                }
                else if (arryTrackLength.Length == 3)
                {
                    TimeSpan ts = new TimeSpan(Convert.ToInt32(arryTrackLength[0]), Convert.ToInt32(arryTrackLength[1]), Convert.ToInt32(arryTrackLength[2]));
                    return ts;
                }
                return TimeSpan.MinValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    class State
    {
        public enum StateID
        {
            TimesEqual,
            ReadyToRemove,
            ReadyToCheckTitles,
            ReadyToParseTracks,
            ReadyToCheckArtists,
            ReadyToCheckTime,
            Finished,
            Error
        }
    }
}
