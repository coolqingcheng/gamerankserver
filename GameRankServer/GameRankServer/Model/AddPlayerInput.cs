using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRankServer.Model
{
    public class AddPlayerInput
    {
        public string NickName { get; set; }


        public string AvatarUrl { get; set; }


        public long GameId { get; set; }

    }
}
