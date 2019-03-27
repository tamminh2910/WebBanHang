namespace WebBanHang.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private WebBanHangDbContext dbContext;
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public WebBanHangDbContext DbContext
        {
            get { return dbContext ?? (dbContext = new WebBanHangDbContext()); }
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}