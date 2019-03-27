using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Model.Entities;

namespace WebBanHang.Data.Repository
{
    public interface IStateRepository : IRepository<State>
    {

    }
    public class StateRepository:RepositoryBase<State>,IStateRepository
    {
        public StateRepository(DbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
