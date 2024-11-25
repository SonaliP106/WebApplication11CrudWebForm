<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllRecordsGridview.aspx.cs" Inherits="WebApplication11CrudWebForm.AllRecordsGridview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">

            <Columns>

                <asp:BoundField DataField="Id" HeaderText ="ID" />
                <asp:BoundField DataField="employeeCode" HeaderText ="Employee Code" />
                <asp:BoundField DataField="name" HeaderText ="Name" />
                <asp:BoundField DataField="gender" HeaderText ="Gender" />
                <asp:BoundField DataField="doj" HeaderText ="Date Of Joining" />
                <asp:BoundField DataField="address" HeaderText ="Address" />

                

               
                <asp:ButtonField CommandName="edit" Text="edit" />
                <asp:ButtonField CommandName="delete" Text="delete" />

            </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
