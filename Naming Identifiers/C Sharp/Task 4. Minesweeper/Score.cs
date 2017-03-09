namespace Telerik.Homeworks.HighQualityCode.NamingIdentifiers.Task4
{
    using System;
    using System.Collections.Generic;

    public class Score
    {
        private static readonly int MaxScoresToKeep = 5;

        private static List<Score> topPlayers = new List<Score>(MaxScoresToKeep);

        public Score(string name, int turns)
        {
            this.Name = name;
            this.Turns = turns;
        }

        public string Name { get; private set; }

        public int Turns { get; private set; }

        public static void ShowScores()
        {
            Console.WriteLine("\nScores:");

            if (topPlayers.Count > 0)
            {
                for (int i = 0; i < topPlayers.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} squares swept",
                        i + 1,
                        topPlayers[i].Name,
                        topPlayers[i].Turns);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No record of scores\n");
            }
        }

        public static void Add(Score playerScore)
        {
            if (topPlayers.Count < MaxScoresToKeep)
            {
                topPlayers.Add(playerScore);
            }
            else
            {
                for (int i = 0; i < MaxScoresToKeep; i++)
                {
                    if (topPlayers[i].Turns < playerScore.Turns)
                    {
                        topPlayers.Insert(i, playerScore);
                        topPlayers.RemoveAt(topPlayers.Count - 1);
                        break;
                    }
                }
            }

            topPlayers.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
            topPlayers.Sort((Score r1, Score r2) => r2.Turns.CompareTo(r1.Turns));
        }
    }
}
