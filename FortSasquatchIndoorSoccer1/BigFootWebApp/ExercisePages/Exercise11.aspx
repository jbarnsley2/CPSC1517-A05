<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise11.aspx.cs" Inherits="BigFootWebApp.ExercisePages.Exercise11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="page-header">
        <h1>Team Maintenance</h1>

       
    </div>
      <asp:RequiredFieldValidator ID="RequiredFieldAge" runat="server" 
        ErrorMessage="Age is required." ControlToValidate="Age"
        Display="None" SetFocusOnError="true" ForeColor="Firebrick">
        </asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeAge" runat="server"
        ErrorMessage="Range is 6 to 14 as an age." ControlToValidate="Age" Display="None"
         SetFocusOnError="true" ForeColor="Firebrick" 
        Type="Integer" MaximumValue="14" MinimumValue="6">
        
    </asp:RangeValidator>

            <asp:Label ID="Label1" runat="server" Text="Enter Age: "></asp:Label>
           <asp:TextBox ID="Age" runat="server"></asp:TextBox>
     
            <asp:DropDownList ID="Gender" runat="server" Width="350px">
                <asp:ListItem Value="M">Male</asp:ListItem>
                   <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:DropDownList>
            <asp:LinkButton ID="Search" runat="server">Search</asp:LinkButton>
     <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" AllowPaging="True">
             <Columns>
             <asp:BoundField DataField="PlayerID" HeaderText="ID" SortExpression="PlayerID" />
            <asp:BoundField DataField="FullName" HeaderText="Name" SortExpression="FullName" />
         <asp:TemplateField HeaderText="Team" SortExpression="TeamID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TeamID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="TeamList" runat="server" 
                        DataSourceID="TeamListODS" 
                        DataTextField="TeamName" DataValueField="TeamID" 
                        SelectedValue='<%# Bind("TeamID", "{0}") %>'>
                    </asp:DropDownList>
                    </ItemTemplate>
         </asp:TemplateField>

                      
             </Columns>
              
             </asp:GridView>
    <br /> <br />
     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
         OldValuesParameterFormatString="original_{0}" 
         SelectMethod="Player_GetByAgeGender" 
         TypeName="FSISSystem.JBarnsley.BLL.PlayerController">
   <SelectParameters>
            <asp:ControlParameter ControlID="Age" Name="age" PropertyName="Text" Type="int32" />
            <asp:ControlParameter ControlID="Gender" Name="gender" PropertyName="SelectedValue" Type="string" />
        </SelectParameters>
         </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TeamListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="Team_List"
        TypeName="FSISSystem.JBarnsley.BLL.TeamController">
    </asp:ObjectDataSource>

</asp:Content>
