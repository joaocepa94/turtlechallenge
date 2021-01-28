using System.IO;
using System.Linq;
using Turtle.Library.Models;
using Turtle.Library.ReadModels;

namespace Turtle.Library
{
    public class FileReader
    {
        private const string FILE_PATH = "..\\..\\Settings\\settings.txt";

        #region Singleton
        private static FileReader fileReader;

        private FileReader() {}

        public static FileReader Instance()
        {
            return fileReader ?? (fileReader = new FileReader());
        }
        #endregion

        public Setting GetSettings()
        {
            string[] settingString = File.ReadAllLines(FILE_PATH);
            Setting settings = new Setting();
            string[] sizeStrings = settingString[0].Split(' ');
            int.TryParse(sizeStrings[0], out int sizeX);
            int.TryParse(sizeStrings[1], out int sizeY);
            settings.BoardSize = new Point(sizeX, sizeY);

            string[] minePointStrings = settingString[1].Split(' ');
            for(int i = 0; i < minePointStrings.Length; i++)
            {
                int.TryParse(minePointStrings[i].Split(',')[0], out int mineX);
                int.TryParse(minePointStrings[i].Split(',')[1], out int mineY);
                settings.MinePoints.Add(new Point(mineX, mineY));
            }

            string[] exitPointStrings = settingString[2].Split(' ');
            int.TryParse(exitPointStrings[0], out int exitX);
            int.TryParse(exitPointStrings[1], result: out int exitY);
            settings.ExitPoint = new Point(exitX, exitY);

            string[] startPositionStrings = settingString[3].Split(' ');
            int.TryParse(startPositionStrings[0], out int posX);
            int.TryParse(startPositionStrings[1], out int posY);
            settings.StartPoint = new Point(posX, posY);
            settings.Direction = startPositionStrings[2];

            for (int i = 4; i < settingString.Length; i++)
            {
                settings.Moves.AddRange(settingString[i].Split(' ').ToList());
            }

            return settings;
        }
    }
}