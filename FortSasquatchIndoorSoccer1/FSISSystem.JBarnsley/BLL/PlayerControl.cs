
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using FSISSystem.JBarnsley.Data;
using FSISSystem.JBarnsley.DAL;
using System.Data.SqlClient;
#endregion

namespace FSISSystem.JBarnsley.BLL
{
   
        public class PlayerControl
        {
            public List<Player> Player_List()
            {
                using (var context = new FSISContext())
                {
                    return context.Players.ToList();
                }
            }
            public Player Player_Find(int PlayerID)
            {
                using (var context = new FSISContext())
                {
                    return context.Players.Find(PlayerID);
                }
            }

        public List<Player> Player_FindByTeamID(string teamID)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results = context.Database.SqlQuery<Player>
                    ("Player_GetByTeam @TeamID", new SqlParameter("TeamID", teamID));
                return results.ToList();
            }
        }
        

    }
}
