using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppJBarnsley
{
    public partial class StudentForm : System.Web.UI.Page
    {
        public static List<StudentData> StudentList;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                StudentList = new List<StudentData>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int studentID = StudentID.;
            string emailaddress = EmailAddress.Text;
            string phonenumber = PhoneNumber.Text;
            string fullorparttime = FullOrPartTime.SelectedValue;

            gvCollection.Add(new GridViewData(fullname, emailaddress,
                phonenumber, fullorparttime, jobs));

            JobApplicantList.DataSource = gvCollection;
            JobApplicantList.DataBind();
        }
    }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            PostalCode.Text = "";
            EmailAddress.Text = "";
            Province.ClearSelection();
            Terms.Checked = false;
            CheckAnswer.Text = "";
        }
    }


}