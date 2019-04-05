using WebBanHang.Data.Infrastructure;
using WebBanHang.Model.Entities;

namespace WebBanHang.Data.Repository
{
    public interface ICategoryParentRepository:IRepository<CategoryParent>
    {
    }

    public class CategoryParentRepository:RepositoryBase<CategoryParent>,ICategoryParentRepository
    {
        public CategoryParentRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}