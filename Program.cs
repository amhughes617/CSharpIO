using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            var fileContents = ReadSoccerResults(fileName);

        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }
        public static List<GameResult> ReadSoccerResults(string fileName)
        {
            var soccerResults = new List<GameResult>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    GameResult gameResult = new GameResult();
                    //tryparse tries to parse the date if successful creates game
                    DateTime gameDate;
                    HomeOrAway homeOrAway;

                    if (DateTime.TryParse(columns[0], out gameDate) && Enum.TryParse(columns[2], out homeOrAway))
                    {
                        gameResult.GameDate = gameDate;
                        gameResult.TeamName = columns[1];
                        gameResult.HomeOrAway = homeOrAway;
                    }
                    int parseInt;
                    if (int.TryParse(columns[3], out parseInt))
                    {
                        gameResult.Goals = parseInt;
                    }
                    if (int.TryParse(columns[4], out parseInt))
                    {
                        gameResult.GoalAttempts = parseInt;
                    }
                    if (int.TryParse(columns[5], out parseInt))
                    {
                        gameResult.ShotsOnGoal = parseInt;
                    }
                    if(int.TryParse(columns[5], out parseInt))
                    {
                        gameResult.ShotsOffGoal = parseInt;
                    }
                    soccerResults.Add(gameResult);
                }
            }
            return soccerResults;
        }
    }
}

