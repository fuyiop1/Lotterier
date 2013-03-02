using LotteryCore.ShuangSeQiu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotterier
{
    class Program
    {
        static void Main(string[] args)
        {
            var selector = new ShuangSeQiuSelector();
            var redBallCount = 7;
            var blueBallCount = 1;

            var mostRareModel = selector.GetTopComboModel(redBallCount, blueBallCount, false, false);
            var mostRareSortedModel = selector.GetTopComboModel(redBallCount, blueBallCount);
            var mostRareModels = selector.FindModelsInLibrary(mostRareModel);
            Console.WriteLine("按出现频率最少排序");
            PrintModel(mostRareModel);
            Console.WriteLine("排序后");
            PrintModel(mostRareSortedModel);

            Console.WriteLine();

            var mostHotModel = selector.GetTopComboModel(redBallCount, blueBallCount, true, false);
            var mostHotSortedModel = selector.GetTopComboModel(redBallCount, blueBallCount, true);
            var mostHotModels = selector.FindModelsInLibrary(mostHotModel);
            Console.WriteLine("按出现频率最多排序");
            PrintModel(mostHotModel);
            Console.WriteLine("排序后");
            PrintModel(mostHotSortedModel);

            Console.WriteLine();

            Console.WriteLine("红球数据总览");
            PrintDic(selector.RedBallFrequencyDic);
            Console.WriteLine();
            Console.WriteLine("蓝球数据总览");
            PrintDic(selector.BlueBallFrequencyDic);

            var testModels = selector.FindModelsInLibrary(new ShuangSeQiuModel
            {
                RedBalls = new List<int> { 6, 10, 16, 20, 27, 32 },
                BlueBalls = new List<int> { 8 }
            });
        }

        private static void PrintDic(Dictionary<int, int> dic)
        {
            foreach (var item in dic)
            {
                Console.Write(string.Format("{0}({1})\t", item.Key, item.Value));
            }
            Console.WriteLine();
        }

        private static void PrintModel(ShuangSeQiuModel model)
        {
            Console.Write("红球:");
            foreach (var item in model.RedBalls)
            {
                Console.Write("\t" + item);
            }
            Console.WriteLine();
            Console.Write("蓝球:");
            foreach (var item in model.BlueBalls)
            {
                Console.Write("\t" + item);
            }
            Console.WriteLine();
        }
    }
}
