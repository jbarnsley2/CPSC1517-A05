
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using FSISSystem.JBarnsley.Data;
using FSISSystem.JBarnsley.DAL;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
#endregion

namespace FSISSystem.JBarnsley.BLL
{
   
        public class PlayerController
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

        public int Player_Add(Player info)
        {
            using (var context = new FSISContext())
            {
                Player addedItem = context.Players.Add(info);
                context.SaveChanges();
                return addedItem.PlayerID;
            }

        }
        public void Player_Update(Player info)
        {
            using (var context = new FSISContext())
            {
                DbEntityEntry<Player> existing = context.Entry(info);
                existing.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public int Player_Delete(int playerID)
        {
            using (var context = new FSISContext())
            {
                var exsisting = context.Players.Find(playerID);
                context.Players.Remove(exsisting);
                return context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Player> Player_GetByAgeGender(int age, string gender)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results = 
                    context.Database.SqlQuery<Player>("Player_GetByAgeGender @Age, @Gender",
                     new SqlParameter("Age", age),
                                    new SqlParameter("Gender", gender));
                return results.ToList();
            }
        }

    }
}
