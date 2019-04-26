<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gridview.aspx.cs" Inherits="BigFootWebApp.ExercisePages.Gridview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <fieldset class="form-horizontal">
            <legend> Multiple Record Query - Code Behind </legend>
            <asp:Label ID="Label1" runat="server" Text="Teams"></asp:Label>
             <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>
            <asp:LinkButton ID="Search" runat="server" OnClick="Search_Click"> Search</asp:LinkButton><br />
            <asp:DataList ID="Message" runat="server" Enabled="False">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Coach: " AssociatedControlID="Coach"></asp:Label>
            <asp:Label ID="Coach" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label3" runat="server" Text="Assistant Coach: " AssociatedControlID="AssistantCoach"></asp:Label>
            <asp:Label ID="AssistantCoach" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label4" runat="server" Text="Wins" AssociatedControlID="Wins"></asp:Label>
            <asp:Label ID="Wins" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label6" runat="server" Text="Losses" AssociatedControlID="Losses"></asp:Label>
            <asp:Label ID="Losses" runat="server" Text=""></asp:Label><br />
            <br />
            <br />
        </fieldset>
    </div>
     <div class="col-md-12">
        <fieldset class="form-horizontal">
            <legend>Team Roster</legend>
            <asp:GridView ID="TeamGridView" runat="server" OnSelectedIndexChanged="TeamGridView_SelectedIndexChanged" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="TeamList_PageIndexChanging" PageSize="5" Width="940px">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="FullName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Age">
                        <ItemTemplate>
                            <asp:Label ID="Age" runat="server" Text='<%# Eval("Age") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label ID="Gender" runat="server" Text='<%# Eval("Gender").ToString()=="M" ? "Male" : "Female" %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Medical alert">
                        <ItemTemplate>
                            <asp:Label ID="MedicalAlertDetails" runat="server" Text='<%# Eval("MedicalAlertDetails") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                   <EmptyDataTemplate>
                    Please select a player. <br />
                       No data available
                </EmptyDataTemplate>
                   </asp:GridView>
            <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
            
        </fieldset>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
