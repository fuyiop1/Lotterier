using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryCore
{
    public abstract class LotteryBaseModel
    {
        public string Name { get; set; }
        public string Issue { get; set; }
        public DateTime Date { get; set; }
        public int BallTotalOccurrencyCount { get; set; }
        public List<int> RedBalls { get; set; }
        public List<int> BlueBalls { get; set; }
    }
}
