<%@ Page Title ="Student Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="WebAppJBarnsley.StudentForm" %>

<asp:Content id="Content1" contentplaceholderid="MainContent" runat="server">
    <h1>Student - Activity 2 Assessment </h1>
    

     <div class="row">
        <div class="col-sm-offset-1 col-sm-10">
            <div class="alert alert-info">
                <blockquote style="font-style:italic">
                   This assessnent will test basic web form construction, validation, data collection and display
                </blockquote>
            </div>
        </div>
    </div>

    
                
                <asp:RequiredFieldValidator ID="RequiredFieldStudentID" runat="server" 
                 ErrorMessage="Student ID is required." ControlToValidate="StudentID"
                 Display="None" SetFocusOnError="true" ForeColor="Firebrick">
                </asp:RequiredFieldValidator>

                 <asp:RequiredFieldValidator ID="RequiredFieldStudentName" runat="server" 
                 ErrorMessage="Name is required." ControlToValidate="StudentName"
                 Display="None" SetFocusOnError="true" ForeColor="Firebrick">
                </asp:RequiredFieldValidator>

                 <asp:RequiredFieldValidator ID="RequiredFieldCredits" runat="server" 
                ErrorMessage="Credits is required." ControlToValidate="Credits"
                Display="None" SetFocusOnError="true" ForeColor="Firebrick">
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="RequiredFieldEmerPhoneNumber" runat="server" 
                ErrorMessage="Emergency Phone Number is required." ControlToValidate="EmergencyPhoneNumber"
                Display="None" SetFocusOnError="true" ForeColor="Firebrick">
                </asp:RequiredFieldValidator>
        <div class="row">
        <div class="col-sm-6">
            <fieldset class="form-horizontal">
                <legend>Student Data Entry</legend> 

                 <asp:Label ID="Label1" runat="server" Text="Student ID"
                     AssociatedControlID="StudentID"></asp:Label>
                <asp:TextBox ID="StudentID" runat="server" 
                    ToolTip="Enter Student ID." MaxLength="25"></asp:TextBox> 

                <asp:Label ID="Label6" runat="server" Text="Name"
                     AssociatedControlID="StudentName"></asp:Label>
                <asp:TextBox ID="StudentName" runat="server" 
                    ToolTip="Enter the student name." MaxLength="25"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" Text="Credits"
                     AssociatedControlID="Credits"></asp:Label>
                <asp:TextBox ID="Credits" runat="server" 
                    ToolTip="Enter credits." MaxLength="25"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" Text="Emergency Phone Number"
                     AssociatedControlID="EmergencyPhoneNumber"></asp:Label>
                <asp:TextBox ID="EmergencyPhoneNumber" runat="server" 
                    ToolTip="Enter your phone number." MaxLength="25"></asp:TextBox>

                </fieldset>
                </div>
         <div class="col-sm-6">
            <asp:Button ID="Submit" runat="server" Text="Add Student"
                 CssClass="btn btn-primary" OnClick="Submit_Click"/>&nbsp;&nbsp;
            <asp:Button ID="Clear" runat="server" Text="Clear"  CssClass="btn" OnClick="Clear_Click" /><br />
            <asp:Label ID="Message" runat="server" ></asp:Label>
            <br />
            <asp:GridView ID="JobApplicantList" runat="server"></asp:GridView>
            <hr style="width:3px;"/>
        </div>

        </div>
        <script src="Scripts/bootwrap-freecode.js"></script>

    </asp:Content>