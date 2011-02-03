using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunes.Duplicate.Gui
{
    public class Track
    {
        private string title;
        private string artist;
        private TimeSpan time;
        private DateTime trackTime;
        private bool duplicate;
        private string path;
        private string searchText;

        public Track()
        {

        }

        public Track(string title, string artist, TimeSpan time, string path, bool duplicate, string searchText)
        {
            this.title = title;
            this.artist = artist;
            this.time = time;
            this.path = path;
            this.duplicate = duplicate;
            trackTime = new DateTime(time.Ticks);
            this.searchText = searchText;
        }

        public bool Duplicate
        {
            get { return duplicate; }
            set { duplicate = value; }
        }

        public string Title
        {
            get { return title; }
        }

        public string Artist
        {
            get { return artist; }
        }

        public string Time
        {
            get { return trackTime.ToString("mm:ss"); }
        }

        public string SearchText
        {
            get { return searchText; }
        }
        
        public string Path
        {
            get { return path; }
        }

    }
}
