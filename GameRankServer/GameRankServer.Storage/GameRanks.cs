using System;
using System.Collections.Generic;
using System.Text;

namespace GameRankServer.Storage
{
    public class GameRanks : EFBase<long>
    {
        /// <summary>
        /// 游戏ID
        /// </summary>
        public long GameId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public long Userid { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public long Score { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
