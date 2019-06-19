using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace GameRankServer.Storage
{
    /// <summary>
    /// Dapper扩展
    /// </summary>
    public static class DapperExtensions
    {
        /// <summary>
        /// 注入服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddDapper<T>(this IServiceCollection service) where T : class, IDbConnection
        {
            service.AddScoped<IDbConnection, T>();
            return service;
        }


    }
    public static class DapperMiddleWareExtensions
    {
        public static IApplicationBuilder UseDapper(this IApplicationBuilder builder, Action<DapperOption> option = null)
        {
            DapperOption opt = new DapperOption();
            if (option != null)
            {
                option(opt);
            }
            return builder.UseMiddleware<DapperMiddleWare>(opt);
        }
    }

    public class DapperMiddleWare
    {

        private readonly RequestDelegate _next;
        private DapperOption _option;

        public DapperMiddleWare(RequestDelegate next, DapperOption option)
        {
            _next = next;
            this._option = option;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            var conn = context.RequestServices.GetService<IDbConnection>();

            if (_option != default(DapperOption))
            {
                if (!string.IsNullOrEmpty(_option.connStr))
                {
                    conn.ConnectionString = _option.connStr;
                }
            }
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
    public class DapperOption
    {
        /// <summary>
        /// 链接字符串
        /// </summary>
        public string connStr { get; set; }
    }
}
