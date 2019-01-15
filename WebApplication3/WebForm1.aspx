<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="border:1px solid black; font-family:Arial;text-align:center">
            <tr>
                <td>
                    Elevator1
                </td>
                <td>
                    Elevator2
                </td>
                <td>
                    Elevator3
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="150px" BackColor="Blue"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="150px" BackColor="Blue"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="150px" BackColor="Blue"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Floor1" runat="server" Text="Floor 1" Width="150px" OnClick="Floor1_Click" />
                </td>
                <td>
                    <asp:Button ID="Floor2" runat="server" Text="Floor 2" Width="150px" OnClick="Floor2_Click" />
                </td>
                <td>
                    <asp:Button ID="Floor3" runat="server" Text="Floor 3" Width="150px" OnClick="Floor3_Click" />
                </td>
                <td>
                    <asp:Button ID="Floor4" runat="server" Text="Floor 4" Width="150px" OnClick="Floor4_Click"/>
                </td>
                <td>
                    <asp:Button ID="Floor5" runat="server"  Text="Floor 5" Width="150px" OnClick="Floor5_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
        <td colspan="3">
            <asp:TextBox ID="display" Font-Size="Large" Width="500px" runat="server"
                        BackColor="#003300" ForeColor="White">
            </asp:TextBox>
        </td>
    </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:ListBox ID="ListBox1" Width="100px" Font-Size="Medium" runat="server"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="ListBox2" runat="server" Width="129px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                
                <td></td>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="PrintToken" Width="150px" OnClick="Button4_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
             <tr>
            <td colspan="3">
            <asp:Label ID="lblCurrentStatus" runat="server" Font-Size="Medium">
            </asp:Label>
        </td>
    </tr>

        </table>
    </div>
    </form>
</body>
</html>
