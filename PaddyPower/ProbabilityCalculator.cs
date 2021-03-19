using PaddyPower.Models;
using System;
using System.Collections.Generic;

namespace PaddyPower
{
    public static class ProbabilityCalculator
    {
        private const double OFFSET = 0.5;
        public static List<GameResult> results;
        static int resultsCount;
        public static void init()
        {
            resultsCount = results.Count;
        }

        public static double WinProbability()
        {
            var homeTeamCnt = results.FindAll(res => res.HomeTeamWinner).Count;
            var homeTeamProb = (double)homeTeamCnt / resultsCount;
            return Math.Round(homeTeamProb, 2);
        }

        static double CalcMedian()
        {
            results.Sort((x, y) => x.TotalPoints.CompareTo(y.TotalPoints));

            if (resultsCount % 2 == 0)
            {
                int midIndex = resultsCount / 2;
                var sum = results[midIndex - 1].TotalPoints + results[midIndex].TotalPoints;
                return sum / 2.0;

            }
            else
                return results[resultsCount / 2].TotalPoints;
        }


        public static double HalfPointsProbability()
        {
            var median = ProbabilityCalculator.CalcMedian() - OFFSET;
            var overLineCnt = results.FindAll(res => res.HomeTeamPoints + res.AwayTeamPoints > median ).Count;
            return Math.Round((double)overLineCnt / resultsCount, 2);
        }

        public static WinMarginResult WinMarginProbability()
        {
            var homeWinners = results.FindAll(res => res.HomeTeamWinner);
            var awayWinners = results.FindAll(res => res.AwayTeamWinner);

            var homeUpto10Pts = homeWinners.FindAll(res => (res.HomeTeamPoints - res.AwayTeamPoints) <= 10);
            var awayUpto10Pts = awayWinners.FindAll(res => (res.AwayTeamPoints - res.HomeTeamPoints) <= 10);

            var homeUpto10PtsProb = Math.Round((double)homeUpto10Pts.Count / homeWinners.Count, 2);
            var awayUpto10PtsProb = Math.Round((double)awayUpto10Pts.Count / awayWinners.Count, 2);

            return new WinMarginResult(homeUpto10PtsProb, awayUpto10PtsProb);
        }
    }
}
