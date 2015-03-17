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
                string searchString = "dog days flo";
                string sourceDirectory = @"C:\Users\subryad\Downloads\VA-Hed_Kandi_Presents_Athmes_and_Artwork-(HEDK001BOX)-4CD-Retail-2011-HFT";
                string destinationDirectory = @"C:\";
                Gui.iTunes iTunesApp = new Gui.iTunes(sourceDirectory, destinationDirectory, Properties.Settings.Default.TitleFilters);
                iTunesApp.CheckLibraryForDuplicates(searchString);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);

            }


        }
    }
}
