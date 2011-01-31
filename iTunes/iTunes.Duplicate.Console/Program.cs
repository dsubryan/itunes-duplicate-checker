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
            string searchString = "hold's it against me";
            Gui.iTunes iTunesApp = new Gui.iTunes();
            System.Console.WriteLine(iTunesApp.Search(searchString, ITPlaylistSearchField.ITPlaylistSearchFieldVisible).ToString());
        }
    }
}
