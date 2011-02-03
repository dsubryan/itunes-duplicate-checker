using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunes.Duplicate.Gui;
using iTunesLib;

namespace iTunes.Duplicate.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchString = "right round fl";
            Gui.iTunes iTunesApp = new Gui.iTunes();
            iTunesApp.CheckLibraryForDuplicates(searchString);

            //System.Console.WriteLine(iTunesApp.Search(searchString, ITPlaylistSearchField.ITPlaylistSearchFieldVisible).ToString());
        }
    }
}
