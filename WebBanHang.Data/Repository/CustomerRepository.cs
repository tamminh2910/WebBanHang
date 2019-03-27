using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Model.Entities;

namespace WebBanHang.Data.Repository
{
    public interface ICustomerRepository:IRepository<Customer>
    {

    }
    public class CustomerRepository: RepositoryBase<Customer>,ICustomerRepository
    {
        public CustomerRepository(DbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
