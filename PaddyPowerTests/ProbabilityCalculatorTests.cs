using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaddyPower.Models;
using System.Collections.Generic;

namespace PaddyPower.Tests
{
    [TestClass()]
    public class ProbabilityCalculatorTests
    {
        [TestInitialize()]
        public void initTest()
        {
            var inp = new List<GameResult>() {
                new GameResult(true, false, 100, 75),
                new GameResult(true, false, 125, 75),
                new GameResult(true, false, 75, 70),
                new GameResult(false, true, 70, 75)
            };
            ProbabilityCalculator.results = inp;
            ProbabilityCalculator.init();

        }

        [TestMethod()]
        public void WinProbabilityTest()
        {
            var res = ProbabilityCalculator.WinProbability();
            Assert.AreEqual(res, 0.75);
        }
       

        [TestMethod()]
        public void HalfPointsProbabilityTest()
        {
            var res = ProbabilityCalculator.HalfPointsProbability();
            Assert.AreEqual(res, 0.50);
        }

        [TestMethod()]
        public void WinMarginProbabilityTest()
        {
            var res = ProbabilityCalculator.WinMarginProbability();
            Assert.AreEqual(res.Home, 0.33);
            Assert.AreEqual(res.Away, 1.0);
        }

        [TestMethod()]
        public void WinMarginProbabilityWithUpto10PointsTest()
        {
            var inp = new List<GameResult>() {
                new GameResult(true, false, 100, 90),
                new GameResult(true, false, 125, 120),
                new GameResult(true, false, 75, 25),
                new GameResult(false, true, 25, 30),
                new GameResult(false, true, 25, 35)
            };
            ProbabilityCalculator.results = inp;
            ProbabilityCalculator.init();

            var res = ProbabilityCalculator.WinMarginProbability();
            Assert.AreEqual(res.Home, 0.67);
            Assert.AreEqual(res.Away, 1.0);
        }
    }
}