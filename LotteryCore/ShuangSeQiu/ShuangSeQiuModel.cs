using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryCore.ShuangSeQiu
{
    public class ShuangSeQiuModel : LotteryBaseModel
    {

        private static readonly string ShuangSeQiuName = "双色球";

        public ShuangSeQiuModel()
        {
            Name = ShuangSeQiuName;
        }

    }
}
