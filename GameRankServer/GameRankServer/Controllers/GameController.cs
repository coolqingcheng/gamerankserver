using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRankServer.Model;
using GameRankServer.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace GameRankServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        GameRankContext _context;

        IDbConnection _conn;

        public GameController()
        {

        }

        #region 提交分数
        /// <summary>
        /// 提交分数
        /// </summary>
        /// <param name="input"></param>
        /// <returns>0成功 1 失败</returns>
        [HttpPost]
        public async Task<BaseDto> submitScore([FromBody]SubmitScoreInput input)
        {
            BaseDto dto = new BaseDto();
            var gameany = await _context.games.Where(a => a.GameId == input.GameId).AnyAsync();
            if (!gameany)
            {
                dto.code = 1;
                return dto;
            }
            var user = await _context.users.Where(a => a.IdentityId == input.IdentityId).FirstOrDefaultAsync();
            if (user == null)
            {
                dto.code = 1;
                return dto;
            }
            var rank = await _context.gameranks.Where(a => a.GameId == input.GameId && a.Userid == user.Id).FirstOrDefaultAsync();
            if (rank == null)
            {
                await _context.gameranks.AddAsync(new GameRanks()
                {
                    GameId = input.GameId,
                    Userid = user.Id,
                    Score = input.Score
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                if (input.Score > rank.Score)
                {
                    rank.Score = input.Score;
                    await _context.SaveChangesAsync();
                }
            }


            return dto;
        }
        #endregion

        #region 获取排行榜

        [HttpPost]
        public async Task<BaseDto> GetRankList([FromBody]GetRankListInput input)
        {
            BaseDto dto = new BaseDto();
            var user = await _context.users.Where(a => a.IdentityId == input.IdentityId).FirstOrDefaultAsync();
            if (user == null)
            {
                dto.code = 1;
                return dto;
            }
            GetRankListDto rankListDto = new GetRankListDto();
            //加载正常的排行榜

            string getranklistsql = @"SELECT  d.nickname,d.avatar,d.score,d.rownum
FROM  (
select * from (
select a.userid,a.score,@rownum:=@rownum+1 AS rownum  from (select @rownum:=0 ) c, (
select * from gameranks where gameid = @gameid order by score desc LIMIT 1000) as a
) as r
INNER JOIN users as u on u.id  = r.userid order by r.score desc
) as d  limit @skip,@take
";
            var list = await _conn.QueryAsync<GetRankListItem>(getranklistsql, new
            {
                @gameid = input.GameId,
                @skip = (input.Page - 1) * input.PageSize,
                @take = input.PageSize
            });

            //判断我在第几位
            string getmyNumSql = @"SELECT * from (
select a.userid,a.score,@rownum:= @rownum + 1 AS rownum  from(select @rownum:= 0) c, (
  select * from gameranks where gameid = @gameid order by score desc LIMIT 1000) as a
) as d where d.userid = @userid";
            var myrank = await _conn.QueryFirstAsync<MyRank>(getmyNumSql, new
            {
                @gameid = input.GameId,
                @userid = user.Id
            });
            rankListDto.MyRanking = myrank == null ? -1 : myrank.rownum;
            rankListDto.data = list.ToList();

            return new BaseDto()
            {
                data = rankListDto
            };
        }
        #endregion


        #region 简单注册玩家
        /// <summary>
        /// 简单注册玩家
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task<BaseDto> AddPlayer([FromBody]AddPlayerInput input)
        {
            var guid = Guid.NewGuid().ToString("N");

            await _context.users.AddAsync(new GameUser()
            {
                Avatar = input.AvatarUrl,
                IdentityId = guid,
                RegisterGameId = input.GameId
            });
            return new BaseDto()
            {
                data = guid
            };

        }
        #endregion

    }
}