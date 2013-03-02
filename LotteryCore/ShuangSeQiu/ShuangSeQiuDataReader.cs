using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryCore.ShuangSeQiu
{
    public static class ShuangSeQiuDataReader
    {
        private static readonly string FileName = "ShuangSeQiu\\ShuangSeQiu.txt";
        private static readonly string DateFormat = "yyyy-MM-dd";
        private static readonly char[] StringSpliters = new char[] { '\t' };
        private static readonly int DataItemLength = 9;

        public static List<ShuangSeQiuModel> ReadData()
        {
            var result = new List<ShuangSeQiuModel>();

            var fileFullPath = Path.Combine(Environment.CurrentDirectory, FileName);
            if (File.Exists(fileFullPath))
            {
                using (var reader = new StreamReader(fileFullPath))
                {
                    var lineIndex = 0;
                    while (true)
                    {
                        lineIndex++;
                        var lineString = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(lineString))
                        {
                            break;
                        }
                        var dataItemStrings = lineString.Split(StringSpliters, StringSplitOptions.RemoveEmptyEntries);
                        if (dataItemStrings.Length == DataItemLength)
                        {
                            DateTime issueTime;
                            DateTime.TryParseExact(dataItemStrings[1], DateFormat, null, System.Globalization.DateTimeStyles.None, out issueTime);
                            var model = new ShuangSeQiuModel
                            {
                                Issue = dataItemStrings[0],
                                Date = issueTime,
                                RedBalls = new List<int>(),
                                BlueBalls = new List<int>()
                            };
                            for (int i = 2; i < dataItemStrings.Length - 1; i++)
                            {
                                model.RedBalls.Add(Convert.ToInt32(dataItemStrings[i]));
                            }
                            model.BlueBalls.Add(Convert.ToInt32(dataItemStrings.LastOrDefault()));
                            result.Add(model);
                        }
                        else
                        {
                            //TODO add error log here
                        }
                    }
                }
            }

            return result;
        }
    }
}
