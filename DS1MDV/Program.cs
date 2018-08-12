using Microsoft.Win32;
using Microsoft.Xna.Framework;
using System;

namespace XnaTestThing
{
    internal class Program
    {
        public Program()
        {
        }

        [STAThread]
        private static void Main(string[] args)
        {
            //MEOW DEBUG//
            //args = new string[] { @"G:\SteamLibrary\steamapps\common\Dark Souls Prepare to Die Edition\DATA\chr\c2430.chrbnd" };
            /////////////

            using (MyGame game = new MyGame())
            {
                if (args.Length != 0)
                {
                    game.inputFiles = args;
                }
                else
                {
                    OpenFileDialog browseDlg = new OpenFileDialog()
                    {
                        Title = "Open Model File",
                        CheckFileExists = true,
                        CheckPathExists = true,
                        Multiselect = true,
                    };
                    bool? nullable = browseDlg.ShowDialog();
                    if ((nullable.GetValueOrDefault() ? !nullable.HasValue : true))
                    {
                        return;
                    }
                    else
                    {
                        if (browseDlg.FileNames.Length > 0)
                            game.inputFiles = browseDlg.FileNames;
                        else
                            game.inputFiles = new string[] { browseDlg.FileName };
                    }
                }
                game.Run(GameRunBehavior.Synchronous);
            }
        }
    }
}