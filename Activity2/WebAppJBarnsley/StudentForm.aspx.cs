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
        public static List<Student> StudentList;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                StudentList = new List<Student>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string studentID = StudentID.Text;
            string studentName = StudentName.Text;
            string credits = Credits.Text;
            string emerPhoneNumber = EmerPhoneNumber.Text;
            

            StudentList.Add(new Student(studentID, studentName,
                credits, emerPhoneNumber));

            StudentFormList.DataSource = StudentList;
            StudentFormList.DataBind();
        }
    }

        protected void Clear_Click(object sender, EventArgs e)
        {
            StudentID.Text = "";
            StudentName.Text = "";
            Credits.Text = "";
            EmerPhoneNumber.Text = "";
         
        }
    


}