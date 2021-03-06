﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using FSISSystem.JBarnsley.Data;
using FSISSystem.JBarnsley.DAL;
#endregion

namespace FSISSystem.JBarnsley.BLL
{
    public class TeamController
    {
        public List<Team> Team_List()
        {
            using (var context = new FSISContext())
            {
                return context.Teams.ToList();
            }
        }
        public Team Team_Find (int TeamID)
        {
            using (var context = new FSISContext())
            {
                return context.Teams.Find(TeamID);
            }
        }

    }
}
