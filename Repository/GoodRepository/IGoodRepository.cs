using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entity;

namespace Repository.GoodRepository
{
    public interface IGoodRepository
    {
        public Task<IEnumerable<Good>> Get();
        public Task<Good> Get(int id);
        public Task<int> GetNumberOfGood();
    }
}
