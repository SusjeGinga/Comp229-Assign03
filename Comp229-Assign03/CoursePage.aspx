<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoursePage.aspx.cs" Inherits="Comp229_Assign03.CoursePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>
            <p>Student's courses: </p>

        <asp:GridView ID="CourseStudentGrid" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="FirstMidName" HeaderText="First Mid Name" />
                <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" />
                
                <asp:HyperLinkField DataTextField="Delete" DataNavigateUrlFields="Delete" 
                DataNavigateUrlFormatString="CoursePage.aspx?StudentID={0}" />

            </Columns>
        </asp:GridView>

        </fieldset>
    <fieldset>
        <legend>Add Student to course</legend>
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
            <td>Enrollment Date</td>
            <td>
                <asp:TextBox ID="enrollmentDateTxt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="enrollmentDateTxtReq" runat="server"
                    ControlToValidate="enrollmentDateTxt"
                    ErrorMessage="This field is Required" />
            </td>
        </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="addStudentBnt" OnClick="AddStudentBnt_Click" runat="server" Text="Add Student" />
                </td>
            </tr>

        </table>
    </fieldset>

</asp:Content>
