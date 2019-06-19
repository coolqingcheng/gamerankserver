using System;
using System.Collections.Generic;
using System.Text;

namespace GameRankServer.Storage
{
    public class EFBase<T>
    {
        public T Id { get; set; }
    }
}
