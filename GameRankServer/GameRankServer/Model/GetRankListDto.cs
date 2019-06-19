using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRankServer.Model
{
    public class GetRankListDto
    {
        /// <summary>
        /// 我的名次
        /// </summary>
        public long MyRanking { get; set; }


        /// <summary>
        /// 列表
        /// </summary>
        public List<GetRankListItem> data { get; set; }
    }

    public class GetRankListItem
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }


        /// <summary>
        /// 排名
        /// </summary>
        public long Score { get; set; }

        /// <summary>
        /// 排名
        /// </summary>
        public long rownum { get; set; }
    }

    class MyRank {

        public long UserId { get; set; }

        public long Score { get; set; }


        public long rownum { get; set; }
    }
}
