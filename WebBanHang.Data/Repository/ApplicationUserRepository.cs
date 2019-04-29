using Microsoft.AspNet.Identity;
using System.Linq;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Model.Entities;

namespace WebBanHang.Data.Repository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetById(string id);
    }

    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public ApplicationUser GetById(string id)
        {
            var query = from user in DbContext.Users
                        where user.Id == id
                        select user;
            if (query != default(ApplicationUser))
            {
                return query.Single();
            }
            return null;
        }
    }
}