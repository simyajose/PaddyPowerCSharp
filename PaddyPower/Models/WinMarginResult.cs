
namespace PaddyPower.Models
{
    public class WinMarginResult
    {
        public double Home { get; set; }
        public double Away { get; set; }

        public WinMarginResult(double home, double away)
        {
            this.Home = home;
            this.Away = away;
        }
    }
}
