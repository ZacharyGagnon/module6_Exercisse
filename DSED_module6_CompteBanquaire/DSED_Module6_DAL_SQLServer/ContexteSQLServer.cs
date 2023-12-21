using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DSED_Module6_DAL_SQLServer
{
    public class ContexteSQLServer : IdentityDbContext
    {
        public ContexteSQLServer(DbContextOptions<ContexteSQLServer> options) : base(options)
        {
            ;
        }
        public DbSet<CompteSQLServerDTO> Compte { get; set; }
        public DbSet<TransactionsSQLServerDTO> Transactions { get; set; }
    }
}