namespace WebAppJBarnsley
{
    public class GridViewData
    {
        private string studentId;
        private string studentName;
        private string credits;
        private string emergencyPhoneNumber;

        public GridViewData(string studentId, string studentName, string credits, string emergencyPhoneNumber)
        {
            this.studentId = studentId;
            this.studentName = studentName;
            this.credits = credits;
            this.emergencyPhoneNumber = emergencyPhoneNumber;
        }
    }
}