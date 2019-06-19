using System;
using System.Collections.Generic;
using System.Text;

namespace GameRankServer.Storage
{
    public class GameUser:EFBase<long>
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 唯一识别码
        /// </summary>
        public string IdentityId { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string Avatar { get; set; }

        public long RegisterGameId { get; set; }
    }
}
