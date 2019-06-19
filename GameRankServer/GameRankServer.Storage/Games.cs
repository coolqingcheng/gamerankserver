using System;
using System.Collections.Generic;
using System.Text;

namespace GameRankServer.Storage
{
    public class Games:EFBase<long>
    {
        /// <summary>
        /// 游戏Id
        /// </summary>
        public long GameId { get; set; }
        /// <summary>
        /// 游戏昵称
        /// </summary>
        public string GameName { get; set; }
    }
}
