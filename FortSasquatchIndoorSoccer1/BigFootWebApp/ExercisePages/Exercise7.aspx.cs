
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#region Additional Namespaces
using FSISSystem.JBarnsley.BLL;
using System.Data.Entity.Validation;
using FSISSystem.JBarnsley.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
#endregion

namespace BigFootWebApp.ExercisePages
{
    public partial class Exercise7 : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.DataSource = null;
            ErrorMessage.DataBind();
            if (!Page.IsPostBack)
            {
                BindPlayerList();
                BindTeamList();
                BindGuardian();
            }
        }

        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            ErrorMessage.CssClass = cssclass;
            ErrorMessage.DataSource = errormsglist;
            ErrorMessage.DataBind();
        }
        protected void BindPlayerList()
        {

            try
            {
                PlayerController sysmgr = new PlayerController();
                List<Player> info = sysmgr.Player_List();

                info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                PlayerList.DataSource = info;
                PlayerList.DataTextField = "FullName";
                PlayerList.DataValueField = "PlayerID";
                PlayerList.DataBind();
                PlayerList.Items.Insert(0, "Select a player");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindTeamList()
        {

            try
            {
                TeamController sysmgr = new TeamController();
                List<Team> info = sysmgr.Team_List();

                //info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = info;
                TeamList.DataTextField = "TeamName";
                TeamList.DataValueField = "TeamID";
                TeamList.DataBind();
                TeamList.Items.Insert(0, "Select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindGuardian()
        {
            try
            {
                GuardianController sysmgr = new GuardianController();
                List<Guardian> info = sysmgr.Guardian_List();

                info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                GuardianList.DataSource = info;
                GuardianList.DataTextField = "FullName";
                GuardianList.DataValueField = "GuardianID";
                GuardianList.DataBind();
                GuardianList.Items.Insert(0, "Select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select a player");
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            else
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();
                    Player info = null;
                    info = sysmgr.Player_Find(int.Parse(PlayerList.SelectedValue));
                    if (info == null)
                    {
                        errormsgs.Add("Player Not Found");
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    else
                    {
                        PlayerFirstName.Text = info.FirstName.ToString();
                        PlayerLastName.Text = info.LastName.ToString();
                        PlayerID.Text = info.PlayerID.ToString();
                        TeamList.SelectedValue = info.TeamID.ToString();
                        GuardianList.SelectedValue = info.GuardianID.ToString();
                        Age.Text = info.Age.ToString();
                        if (info.Gender.ToString() == "M")
                        {
                            Gender.SelectedIndex = 0;
                        }
                        else
                        {
                            Gender.SelectedIndex = 1;
                        }

                        ABHCNumber.Text = info.AlbertaHealthCareNumber.ToString();
                        MedicalAlert.Text = info.MedicalAlertDetails == null ? "None" : info.MedicalAlertDetails;
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
        protected void Clear_Click(object sender, EventArgs e)
        {
            PlayerList.SelectedIndex = 0;
            PlayerID.Text = "";
            TeamList.SelectedIndex = 0;
            GuardianList.SelectedIndex = 0;
            Age.Text = "";
            Gender.SelectedIndex = -1;
            ABHCNumber.Text = "";
            MedicalAlert.Text = "";
            PlayerFirstName.Text = "";
            PlayerLastName.Text = "";
        }

        private Player BuildPlayerFromUserInput()
        {
            Player info = new Player();
            info.FirstName = PlayerFirstName.Text.Trim();
            info.LastName = PlayerLastName.Text.Trim();
            if (int.TryParse(TeamList.SelectedValue, out int temp))
                info.TeamID = temp;
            if (int.TryParse(GuardianList.SelectedValue, out temp))
                info.GuardianID = temp;
            if (Gender.SelectedIndex == 0)
            {
                info.Gender = "M";
            }
            else
            {
                info.Gender = "F";
            }
            info.AlbertaHealthCareNumber = ABHCNumber.Text.ToString();
            if (!string.IsNullOrWhiteSpace(MedicalAlert.Text))
                info.MedicalAlertDetails = MedicalAlert.Text.Trim();
            if (int.TryParse(Age.Text, out int age))
                info.Age = age;

            return info;
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            // {
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select a Team");
            }
            if (GuardianList.SelectedIndex == 0)
            {
                errormsgs.Add("Please select a Guardian");
            }
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    Player info = BuildPlayerFromUserInput();
                    
                    var controller = new PlayerController();
                    int NewPlayerID = controller.Player_Add(info);
                    BindPlayerList();
                    PlayerID.Text = NewPlayerID.ToString();
                    errormsgs.Add($"{info.FullName} was successfully added");
                    LoadMessageDisplay(errormsgs, "alert alert-success");
                   
                
                
                }


                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        updateException.InnerException.Message.ToString();
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);

                    }
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }

                catch (Exception )
                {
                    errormsgs.Add("Please add player details");
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {

            int playerid;
            if (IsValid && int.TryParse(PlayerID.Text, out playerid))
            {
                try
                {
                    Player info = BuildPlayerFromUserInput();
                    info.PlayerID = playerid;
                    var controller = new PlayerController();
                    controller.Player_Update(info);
                    BindPlayerList();
                    PlayerList.SelectedValue = playerid.ToString();
                    errormsgs.Add($"{info.FullName} was successfully updated");
                    LoadMessageDisplay(errormsgs, "alert alert-success");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
            else
            {
                errormsgs.Add("Please select a player before attempting to update");
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerID.Text))
            {
                errormsgs.Add("Please select a player to update. Select and Search.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();
                    int rowsAffected = sysmgr.Player_Delete(int.Parse(PlayerID.Text));
                    BindPlayerList();
                    errormsgs.Add("Player Deleted successfully. ");
                    LoadMessageDisplay(errormsgs, "alert alert-warning");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
    }
}