<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise11.aspx.cs" Inherits="BigFootWebApp.ExercisePages.Exercise11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="page-header">
        <h1>Team Maintenance</h1>
    </div>
            <asp:Label ID="Label1" runat="server" Text="Enter Age: "></asp:Label>
           <asp:TextBox ID="Age" runat="server"></asp:TextBox>
            <asp:RadioButtonList ID="Gender" runat="server">
                <asp:ListItem Value="1">Male</asp:ListItem>
                    <asp:ListItem Value="2">Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="Button1" runat="server" Text="Search" />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" AllowPaging="True">
             <Columns>
             <asp:BoundField DataField="PlayerID" HeaderText="ID" SortExpression="PlayerID" />
            <asp:BoundField DataField="FullName" HeaderText="Name" SortExpression="FullName" />
         <asp:TemplateField HeaderText="Team" SortExpression="TeamName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TeamName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource1" DataTextField="TeamName" DataValueField="TeamName" SelectedValue='<%# Bind("TeamName", "{0}") %>'>
                    </asp:DropDownList>
                    </ItemTemplate>
         </asp:TemplateField>
                      
             </Columns>
              <EmptyDataTemplate>
               No players with that age
            </EmptyDataTemplate>
             </asp:GridView>
    <br /> <br />
     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Player_GetByAgeGender" TypeName="FSISSystem.JBarnsley.BLL.PlayerController">
   <SelectParameters>
            <asp:ControlParameter ControlID="Age" Name="age" PropertyName="Text" Type="int32" />
            <asp:ControlParameter ControlID="Gender" Name="gender" PropertyName="SelectedValue" Type="string" />
        </SelectParameters>
         </asp:ObjectDataSource>
</asp:Content>
