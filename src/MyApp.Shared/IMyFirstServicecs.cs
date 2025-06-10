using MagicOnion;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Shared
{

    namespace MyApp.Shared
    {
        public interface IMyFirstService : IService<IMyFirstService>
        {
            UnaryResult<int> SumAsync(int x, int y);
        }
    }
}
