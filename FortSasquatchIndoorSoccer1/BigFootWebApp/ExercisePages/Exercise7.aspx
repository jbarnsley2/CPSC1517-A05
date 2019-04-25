<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise7.aspx.cs" Inherits="BigFootWebApp.ExercisePages.Exercise7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Exercise 7B</h1>
    </div>
    <div class="col-md-12">
    </div>
    <div class="col-md-12">
        <%----%>
        <asp:Label ID="Label1" runat="server" Text="Select a player"></asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="PlayerList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:LinkButton ID="Search" runat="server" Font-Size="X-Large" OnClick="Search_Click">Search</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="Clear" runat="server" Font-Size="X-Large" OnClick="Clear_Click">Clear</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="Add" runat="server" Font-Size="X-Large" OnClick="Add_Click">Add</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="Update" runat="server" Font-Size="X-Large" OnClick="Update_Click">Update</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="Delete" runat="server" Font-Size="X-Large" OnClick="Delete_Click" CausesValidation="false" OnClientClick="return confirm('Are you sure you wish to delete this player?')">Delete</asp:LinkButton>

        <br />
        <br />
        <asp:DataList ID="ErrorMessage" runat="server">
            <ItemTemplate>
                <%#Container.DataItem %>
            </ItemTemplate>
        </asp:DataList>
        </div>
    <div class="col-md-12">
        <fieldset class="form-horizontal">
            <legend>Player Information</legend>
             <%-- PlayerID--%>
            <asp:Label ID="Label2" runat="server" Text="PlayerID" AssociatedControlID="PlayerID"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="PlayerID" runat="server"></asp:Label><br />
            <%--First Name--%>
            <asp:Label ID="Label9" runat="server" Text="First Name" AssociatedControlID="PlayerFirstName"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="PlayerFirstName" runat="server" Width="350px"></asp:TextBox><br />
            <%-- Last Name--%>
            <asp:Label ID="Label10" runat="server" Text="Last Name" AssociatedControlID="PlayerLastName"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="PlayerLastName" runat="server" Width="350px"></asp:TextBox><br />
            <%--Team Name --%>
            <asp:Label ID="Label3" runat="server" Text="Team Name" AssociatedControlID="TeamList"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="TeamList" runat="server" Width="350px"></asp:DropDownList><br />
            <%--Guardian Name --%>
            <asp:Label ID="Label4" runat="server" Text="Guardian Name" AssociatedControlID="GuardianList"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="GuardianList" runat="server" Width="350px"></asp:DropDownList><br />
            <%--Age --%>
            <asp:Label ID="Label5" runat="server" Text="Age" AssociatedControlID="Age"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Age" runat="server" Width="350px"></asp:TextBox><br />
            <%--Gender --%>
            <asp:Label ID="Label6" runat="server" Text="Gender" AssociatedControlID="Gender"></asp:Label>
            <asp:RadioButtonList ID="Gender" runat="server">
                <asp:ListItem Value="male">Male</asp:ListItem>
                <asp:ListItem Value="female">Female</asp:ListItem>
            </asp:RadioButtonList>
            <%--Health Care Number --%>
            <asp:Label ID="Label7" runat="server" Text="Alberta Health Care Number" AssociatedControlID="ABHCNumber"></asp:Label>
            &nbsp;
            <asp:TextBox ID="ABHCNumber" runat="server" Width="350px"></asp:TextBox><br />
            <%--Medical Alert Detail --%>
            <asp:Label ID="Label8" runat="server" Text="Medical Alert Detail" AssociatedControlID="MedicalAlert"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="MedicalAlert" runat="server" Width="350px"></asp:TextBox><br />

        </fieldset>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
