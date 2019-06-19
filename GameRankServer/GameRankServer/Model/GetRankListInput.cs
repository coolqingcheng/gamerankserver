using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameRankServer.Model
{
    public class GetRankListInput
    {
        public int GameId { get; set; }

        public string IdentityId { get; set; }

        public int Page { get; set; } = 1;

        [Range(1, 30, ErrorMessage = "页大小范围不能大于30!")]
        public int PageSize { get; set; } = 10;
    }
}
