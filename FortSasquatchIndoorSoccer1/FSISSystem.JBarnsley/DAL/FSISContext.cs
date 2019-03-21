using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using FSISSystem.JBarnsley.Data;
#endregion

namespace FSISSystem.JBarnsley.DAL
{
    internal class FSISContext : DbContext
    {


        public FSISContext() : base("FSIS_db")
        {

        }

        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
