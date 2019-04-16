
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using FSISSystem.JBarnsley.BLL;
using FSISSystem.JBarnsley.Data;

#endregion

namespace BigFootWebApp.ExercisePages
{
    public partial class Gridview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindTeamList();
            }
        }


        protected void BindTeamList()
        {
            try
            {
                TeamController sysmgr = new TeamController();
                List<Team> info = sysmgr.Team_List();
                info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = info;
                TeamList.DataTextField = "TeamName";
                TeamList.DataValueField = "TeamID";
                TeamList.DataBind();
                TeamList.Items.Insert(0, "Select a Team");
            }
            catch(Exception ex)
            {
                ErrorMsg.Text = ex.Message;
            }
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            if (TeamList.SelectedIndex == 0)
            {
                TeamGridView.DataSource = null;
                TeamGridView.DataBind();
            }
            else
            {
                try
                {
                    PlayerController sysmgrP = new PlayerController();
                    TeamController sysmgrT = new TeamController();
                    List<Player> infoP = sysmgrP.Player_FindByTeamID(TeamList.SelectedValue);
                    Team infoT = sysmgrT.Team_Find(int.Parse(TeamList.SelectedValue));
                    infoP.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                    TeamGridView.DataSource = infoP;
                    TeamGridView.DataBind();
                    Coach.Text = infoT.Coach;
                    AssistantCoach.Text = infoT.AssistantCoach;
                    Wins.Text = infoT.Wins == null ? "0" : infoT.Wins.ToString();
                    Losses.Text = infoT.Losses == null ? "0" : infoT.Losses.ToString();

                }
                catch (Exception ex)
                {
                    ErrorMsg.Text = ex.Message;
                }
            }
        }

        protected void TeamGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow agvrow = TeamGridView.Rows[TeamGridView.SelectedIndex];
            string PlayerName = (agvrow.FindControl("PlayerName") as Label).Text;
            string Age = (agvrow.FindControl("Age") as Label).Text;
            string Gender = (agvrow.FindControl("Gender") as Label).Text;// == "M" ? "Male" : "Female";
            string MedicalAlertDetails = (agvrow.FindControl("MedicalAlertDetails") as Label).Text;
        }

        protected void TeamList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TeamGridView.PageIndex = e.NewPageIndex;
            Search_Click(sender, e);

        }

    }
}