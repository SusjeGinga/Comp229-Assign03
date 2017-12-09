<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp229_Assign03._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Landing Page</h1>

    <%--Display the list of all students--%>
    <asp:GridView ID="StudentsGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <%--Student ID will link to StudentPage--%>
            <asp:HyperLinkField DataTextField="StudentID" HeaderText="Student ID" DataNavigateUrlFields="StudentID" 
                DataNavigateUrlFormatString="StudentPage.aspx?StudentID={0}" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="FirstMidName" HeaderText="First Mid Name" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" DataFormatString="{0:MM-dd-yyyy}" />
        </Columns>
    </asp:GridView>
    <br /><br />

    <%--Function that allows user to add student--%>
    <fieldset>
        <legend>Register</legend>
        <p>Note: Please fill your information to all the blanks</p>
        <table>
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

            <td>Enrollment date</td>
                <td>
                    <asp:TextBox ID="enrollmentDateTxt" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="enrollmentDateReq" runat="server"
                        ControlToValidate="enrollmentDateTxt"
                        ErrorMessage="This field is Required" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="registerBtn" OnClick="RegisterBtn_Click" runat="server" Text="Register" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
