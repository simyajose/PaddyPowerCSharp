using Microsoft.VisualBasic.FileIO;
using PaddyPower.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace PaddyPower
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculating probabilities!");

            try
            {
                var results = ReadGameResults();

                if (results != null)
                {
                    ProbabilityCalculator.results = results;
                    ProbabilityCalculator.init();

                    var winProb = ProbabilityCalculator.WinProbability();
                    Console.WriteLine($"probability for homeTeam to win is {winProb}");
                    Console.WriteLine($"probability for awayTeam to win is {1 - winProb}");

                    var halfPointProb = ProbabilityCalculator.HalfPointsProbability();
                    Console.WriteLine($"half point probability over the line is {halfPointProb}");
                    Console.WriteLine($"half point probability under the line is {1 - halfPointProb}");

                    var winMarginProb = ProbabilityCalculator.WinMarginProbability();
                    Console.WriteLine($"Home team winning margin probability with <=10pts is {winMarginProb.Home}");
                    Console.WriteLine($"Home team winning margin probability with >=11pts is {Math.Round(1 - winMarginProb.Home, 2)}");
                    Console.WriteLine($"Away team winning margin probability with <=10pts is {winMarginProb.Away}");
                    Console.WriteLine($"Away team winning margin probability with >=11pts is {Math.Round(1 - winMarginProb.Away, 2)}");

                    Console.WriteLine("calculations complete!");
                } 
                else
                    Console.WriteLine("Failed to calculate probabilities since no data found");
                
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to calculate probabilities due to exception {ex.Message}");
            }  
        }

        private static List<GameResult> ReadGameResults()
        {
            string inputFileName = Environment.CurrentDirectory + @"\Resources\GameResults_PPB.csv";
            var res = new List<GameResult>();

            using (TextFieldParser parser = new TextFieldParser(inputFileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                //remove header
                parser.ReadFields();

                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    res.Add(new GameResult(fields));
                 
                }
            }

            return res;
        }
    }
}
