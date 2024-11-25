<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="WebApplication11CrudWebForm.EditEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <asp:Label ID="IdLabel0" runat="server" Text="Id" Visible="false"></asp:Label>
            <br />
            <br />
               <asp:Label ID="empcodeLabel1" runat="server" Text="Employee Code"></asp:Label>
            <asp:TextBox ID="empcodeTextBox1" runat="server"></asp:TextBox>
                
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorForCode" runat="server" ErrorMessage="code is required" ControlToValidate="empCodeTextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidatorForCode" runat="server" ErrorMessage="should be an integer" Operator="DataTypeCheck" Type="Integer" ControlToValidate="empcodeTextBox1" Display="Dynamic"></asp:CompareValidator>
            <br />
            <br />
             <asp:Label ID="empNameLabel2" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="empNameTextBox2" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorForName" runat="server" ErrorMessage="name is required" ControlToValidate="empNameTextBox2"></asp:RequiredFieldValidator>
            <br />
            <br />

             <asp:Label ID="empGenderLabel3" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Text="select" Value="-1"></asp:ListItem>
<asp:ListItem Text="male" Value="m"></asp:ListItem>
<asp:ListItem Text="female" Value="f"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorForddl" runat="server" ErrorMessage="select gender" ControlToValidate="DropDownList1" InitialValue="-1"></asp:RequiredFieldValidator>

            <br />
            <br />
            <asp:Label ID="dojLabel4" runat="server" Text="Date Of Joining"></asp:Label>
            <asp:TextBox ID="dojTextBox4" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorFordoj" runat="server" ErrorMessage="date is required" ControlToValidate="dojTextBox4" Display="Dynamic" ></asp:RequiredFieldValidator>
             <asp:CompareValidator ID="CompareValidatorFordoj" runat="server" ErrorMessage="should be date" Operator="DataTypeCheck" Type="Date" ControlToValidate="dojTextBox4" Display="Dynamic"></asp:CompareValidator>

            <br />
            <br />
                         <asp:Label ID="empAddressLabel5" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="empAddressTextBox5" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorForAddress" runat="server" ErrorMessage="address is required" ControlToValidate="empAddressTextBox5" ></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:Button ID="updateButton1" runat="server" Text="Update" OnClick="updateButton1_Click1"   />
        </div>
    </form>
</body>
</html>
