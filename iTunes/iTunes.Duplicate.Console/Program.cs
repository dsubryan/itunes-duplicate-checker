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
            try
            {
                string sourceDirectory = @"C:\Music\";
                string destinationDirectory = @"C:\Music\test";
                Gui.iTunes iTunesApp = new Gui.iTunes(sourceDirectory, destinationDirectory, Properties.Settings.Default.TitleFilters);
                iTunesApp.CheckLibraryForDuplicates();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);

            }


        }
    }
}
