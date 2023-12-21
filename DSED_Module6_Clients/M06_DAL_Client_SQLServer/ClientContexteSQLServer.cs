using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace M06_DAL_Client_SQLServer
{
    public class ClientContexteSQLServer : IdentityDbContext
    {
        public ClientContexteSQLServer(DbContextOptions<ClientContexteSQLServer> options) : base(options)
        {
            ;
        }
        public DbSet<ClientSQLServerDTO> Client { get; set; }
    }
}
