using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRankServer.Model
{
    public class BaseDto
    {
        /// <summary>
        /// 0成功1失败
        /// </summary>
        public int code { get; set; } = 0;
        /// <summary>
        /// 数据
        /// </summary>
        public object data { get; set; }
    }
}
