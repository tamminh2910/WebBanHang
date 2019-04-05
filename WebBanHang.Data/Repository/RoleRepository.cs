using WebBanHang.Data.Infrastructure;
using WebBanHang.Model.Entities;

namespace WebBanHang.Data.Repository
{
    public interface IRoleRepository : IRepository<Role>
    {
    }

    public class RoleRepository:RepositoryBase<Role>,IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}