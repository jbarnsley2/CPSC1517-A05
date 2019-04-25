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

    [Table("Player", Schema = "dbo")]
    public class Player
    {
       

        [Key]
        public int PlayerID { get; set; }

        public int TeamID { get; set; }
        public int GuardianID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
       

        [Required(ErrorMessage = "Age is required")]
        [Range(6, 14, ErrorMessage = "Age must between 6 and 14")]
        public int Age { get; set; }

        private string _Gender;

        public string AlbertaHealthCareNumber { get; set; }
        [Required(ErrorMessage = "Alberta Health care number is required")]
        [RegularExpression(@"^[1-9]{1}\d{9}", ErrorMessage = "Must be 10 digits with first digit starts with 1-9")]

        private string _MedicalAlertDetails;

        public string FullName { get { return LastName + ", " + FirstName; } }

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

        public string MedicalAlertDetails
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


