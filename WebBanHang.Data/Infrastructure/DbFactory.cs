using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanHang.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private WebBanHangDbContext dbContext;
        public WebBanHangDbContext Init()
        {
            return dbContext ?? (dbContext = new WebBanHangDbContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
