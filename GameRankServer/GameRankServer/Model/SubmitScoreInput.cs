using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRankServer.Model
{
    public class SubmitScoreInput
    {
        /// <summary>
        /// 玩家的ID
        /// </summary>
        public string IdentityId { get; set; }


        /// <summary>
        /// 分数
        /// </summary>
        public long Score { get; set; }


        /// <summary>
        /// 终端
        /// </summary>
        public string clientId { get; set; }

        /// <summary>
        /// 游戏Id
        /// </summary>
        public long GameId { get; set; }
    }
}
