using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namspace
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace FSISSystem.JBarnsley.Data
{
  
        [Table("Guardian", Schema = "dbo")]
        public class Guardian
        {
        private string _EmergencyPhoneNumber;
        private string _EmailAddress;
        [Key]
            public int GuardianID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            
           

            public string EmergencyPhoneNumber
            {
                get
                {
                    return _EmergencyPhoneNumber;

                }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        _EmergencyPhoneNumber = null;
                    }
                    else
                    {
                        _EmergencyPhoneNumber = value;
                    }
                }
            }

            public string EmailAddress
            {
                get
                {
                    return _EmailAddress;
                }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        _EmailAddress = null;
                    }
                    else
                    {
                        _EmailAddress = value;
                    }
                }
            }

        [NotMapped]
        public string FullName { get { return LastName + "," + FirstName; } }
    }
    }

