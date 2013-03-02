using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryCore.ShuangSeQiu
{
    public class ShuangSeQiuSelector
    {
        private readonly List<ShuangSeQiuModel> rawData;
        private readonly Dictionary<int, int> redBallFrequencyDic;
        private readonly Dictionary<int, int> blueBallFrequencyDic;

        public Dictionary<int, int> RedBallFrequencyDic
        {
            get
            {
                return redBallFrequencyDic;
            }
        }

        public Dictionary<int, int> BlueBallFrequencyDic
        {
            get
            {
                return blueBallFrequencyDic;
            }
        }

        public ShuangSeQiuSelector()
        {
            rawData = ShuangSeQiuDataReader.ReadData();
            redBallFrequencyDic = new Dictionary<int, int>();
            blueBallFrequencyDic = new Dictionary<int, int>();
            foreach (var dataItem in rawData)
            {
                foreach (var ballItem in dataItem.RedBalls)
                {
                    ProcessBall(ballItem, redBallFrequencyDic);
                }
                foreach (var ballItem in dataItem.BlueBalls)
                {
                    ProcessBall(ballItem, blueBallFrequencyDic);
                }
            }
            redBallFrequencyDic = redBallFrequencyDic.OrderBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            blueBallFrequencyDic = blueBallFrequencyDic.OrderBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
        }

        private void ProcessBall(int ballItem, Dictionary<int, int> ballDic)
        {
            var ballCount = 0;
            if (ballDic.ContainsKey(ballItem))
            {
                ballCount = ballDic[ballItem];
                ballDic.Remove(ballItem);
            }
            ballCount++;
            ballDic.Add(ballItem, ballCount);
        }

        public ShuangSeQiuModel GetTopComboModel(int redBallCount, int blueBallCount, bool isFrequecyDescending = false, bool isResultSorted = true)
        {
            var result = new ShuangSeQiuModel();
            Dictionary<int, int> redDic;
            Dictionary<int, int> blueDic;

            if (isFrequecyDescending)
            {
                redDic = redBallFrequencyDic.Reverse().ToDictionary(x => x.Key, y => y.Value);
                blueDic = blueBallFrequencyDic.Reverse().ToDictionary(x => x.Key, y => y.Value);
            }
            else
            {
                redDic = redBallFrequencyDic;
                blueDic = blueBallFrequencyDic;
            }

            var redBallsQuery = redDic.Take(redBallCount).Select(x => x.Key);
            var blueBallsQuery = blueDic.Take(blueBallCount).Select(x => x.Key);

            if (isResultSorted)
            {
                redBallsQuery = redBallsQuery.OrderBy(x => x);
                blueBallsQuery = blueBallsQuery.OrderBy(x => x);
            }

            result.RedBalls = redBallsQuery.ToList();
            result.BlueBalls = blueBallsQuery.ToList();

            return result;
        }

        public List<ShuangSeQiuModel> FindModelsInLibrary(ShuangSeQiuModel model)
        {
            var result = new List<ShuangSeQiuModel>();
            foreach (var item in rawData)
            {
                var isItemExisit = true;
                foreach (var ballItem in item.RedBalls)
                {
                    if (!model.RedBalls.Contains(ballItem))
                    {
                        isItemExisit = false;
                        break;
                    }
                }
                if (isItemExisit)
                {
                    foreach (var ballItem in item.BlueBalls)
                    {
                        if (!model.BlueBalls.Contains(ballItem))
                        {
                            isItemExisit = false;
                            break;
                        }
                    }
                }
                if (isItemExisit)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<ShuangSeQiuModel> SelectPerfectCombo(int mostHotCount, int mostRareCount, int mediumCount)
        {
            var result = new List<ShuangSeQiuModel>();

            return result;
        }

    }
}
