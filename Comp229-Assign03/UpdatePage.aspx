<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="Comp229_Assign03.UpdatePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Update Page</h1>
    <table>
        <tr>
            <td>Student ID</td>
            <td>
                <asp:TextBox ID="studentIDTxt" ReadOnly="true" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox ID="lastNameTxt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="lastNameTxtReq" runat="server"
                    ControlToValidate="lastNameTxt"
                    ErrorMessage="This field is Required" />
            </td>
        </tr>

        <tr>

            <td>Middle Name</td>
            <td>
                <asp:TextBox ID="firstMidNameTxt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="firstMidNameReq" runat="server"
                    ControlToValidate="firstMidNameTxt"
                    ErrorMessage="This field is Required" />
            </td>
        </tr>
        <tr>
            <td>Enrollment Date</td>
            <td>
                <asp:TextBox ID="enrollmentDateTxt" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="enrollmentDateTxtReq" runat="server"
                    ControlToValidate="enrollmentDateTxt"
                    ErrorMessage="This field is Required" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="updateBtn" OnClick="UpdateBtn_Click" runat="server" Text="Update" />
            </td>
        </tr>
    </table>

</asp:Content>
