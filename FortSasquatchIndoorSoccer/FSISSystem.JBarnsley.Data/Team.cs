using System;
using System.Collections.Generic;
using System.Text;

#region
#endregion

namespace FSISSystem.JBarnsley.Data
{
    [Table("Team", Schema = "dbo")]
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Coach { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public string AssistantCoach { get; set; }
    }
}
