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

        public string FirstName { get; set; }
        [Required(ErrorMessage ="First Name is required.")]

        public string LastName { get; set; }
        [Required(ErrorMessage ="Last Name is required.")]

        public int Age { get; set; }
        [Range (6,int.MaxValue,14, ErrorMessage ="Age range must be betweeb 6 -14"]

        private string _Gender;

        public string AlbertaHealthCareNumber { get; set; }

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


