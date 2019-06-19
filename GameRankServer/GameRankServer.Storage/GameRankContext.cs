using Microsoft.EntityFrameworkCore;
using System;

namespace GameRankServer.Storage
{
    public class GameRankContext : DbContext
    {
        public GameRankContext(DbContextOptions<GameRankContext> options)
            : base(options)
        { }
        /// <summary>
        /// 游戏列表
        /// </summary>
        public DbSet<Games> games { get; set; }
        /// <summary>
        /// 玩家表
        /// </summary>
        public DbSet<GameUser> users { get; set; }
        /// <summary>
        /// 游戏排行榜
        /// </summary>
        public DbSet<GameRanks> gameranks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Games>().HasIndex(a => a.GameId).IsUnique();
        }
    }
}
