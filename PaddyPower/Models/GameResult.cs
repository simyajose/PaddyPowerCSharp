using System;
using System.Collections.Generic;
using System.Text;

namespace PaddyPower.Models
{
    public class GameResult
    {
        public bool HomeTeamWinner { get ; set ; }
        public bool AwayTeamWinner { get; set; }
        public int HomeTeamPoints { get; set; }
        public int AwayTeamPoints { get; set; }

        public long TotalPoints { get { return HomeTeamPoints + AwayTeamPoints; } }

        public GameResult(string[] input)
        {
            this.HomeTeamWinner = input[0] == "1" ? true : false;
            this.AwayTeamWinner = input[1] == "1" ? true : false;
            this.HomeTeamPoints = Int32.Parse(input[2]);
            this.AwayTeamPoints = Int32.Parse(input[3]);
        }

        public GameResult(bool homeTeamWinner, bool awayTeamWinner, int homeTeamPoints, int awayTeamPoints)
        {
            this.HomeTeamWinner = homeTeamWinner;
            this.AwayTeamWinner = awayTeamWinner;
            this.HomeTeamPoints = homeTeamPoints;
            this.AwayTeamPoints = awayTeamPoints;
        }
    }
}
