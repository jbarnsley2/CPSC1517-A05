using System;
using System.Collections.Generic;
using System.Text;

#region Additional Namespaces

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion


namespace FSISSystem.JBarnsley.Data
{
    [Table("Player", Schema = "dbo")]
    public class Player
    {
        public int? GuardianID { get; set; }
        [Key]
        public int PlayerID { get; set; }

        public int? TeamID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public int Age { get; set; }

        private string _Gender;

        public string AlbertaHealthCareNumber { get; set; }

        private string _MedicalAlertDetails;

        [NotMapped]
        public string FullName { get { return LastName + "," + FirstName; } }

        public string Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value.ToUpper();
            }
        }
        public string  MedicalAlertDetails
        {
            get
            {
                return _MedicalAlertDetails;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _MedicalAlertDetails = null;
                }
                else
                {
                    _MedicalAlertDetails = value;

                }
            }
        }
     }
}
