﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Model.Entities;

namespace WebBanHang.Data.Repository
{
    public interface ISupplierRepository : IRepository<Supplier>
    {

    }
    public class SupplierRepository:RepositoryBase<Supplier>,ISupplierRepository
    {
        public SupplierRepository(DbFactory dbFactory):base(dbFactory)
        {

        }
    }
}