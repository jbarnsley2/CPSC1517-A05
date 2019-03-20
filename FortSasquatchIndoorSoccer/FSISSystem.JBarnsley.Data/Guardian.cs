using System;

#region
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace FSISSystem.JBarnsley.Data
{
    [Table("Guardian", Schema = "dbo")]
    public class Guardian
    {
        [Key]
        public int GuardianID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string _EmergencyPhoneNumber;
        public string _EmailAddress;
        [NotMapped]
        public string FullName { get { return LastName + "," + FirstName; } }

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


    }
}
