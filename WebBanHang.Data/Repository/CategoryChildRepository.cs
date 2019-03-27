using WebBanHang.Data.Infrastructure;
using WebBanHang.Model.Entities;

namespace WebBanHang.Data.Repository
{
    public interface ICategoryChildRepository : IRepository<CategoryChild>
    {
    }

    public class CategoryChildRepository : RepositoryBase<CategoryChild>, ICategoryChildRepository
    {
        public CategoryChildRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}