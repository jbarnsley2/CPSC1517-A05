
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
    
        public class GuardianController
        {
            public List<Guardian> Guardian_List()
            {
                using (var context = new FSISContext())
                {
                    return context.Guardians.ToList();
                }
            }
            public Guardian Guardian_Find(int TeamID)
            {
                using (var context = new FSISContext())
                {
                    return context.Guardians.Find(TeamID);
                }
            }
        }
    
}
