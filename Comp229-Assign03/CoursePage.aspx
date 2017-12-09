<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoursePage.aspx.cs" Inherits="Comp229_Assign03.CoursePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Students in the courses</h1>
    <fieldset>   
        <asp:GridView ID="CourseStudentGrid" DataKeyNames="StudentID,CourseID" runat="server" AutoGenerateColumns="False" OnRowDeleting="CourseStudentGrid_RowDeleting">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="FirstMidName" HeaderText="First Mid Name" />
                <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" />
                
                <asp:CommandField ShowDeleteButton="True" />

            </Columns>
        </asp:GridView>

        </fieldset>
    <fieldset>
        <legend>Add Student to course</legend>
        
        <table>
            <tr>
                <td>Full Name</td>
                <td>
                    <asp:DropDownList ID="nameList" runat="server" DataValueField="StudentID"
                      DataTextField="FullName" ></asp:DropDownList>
                   <%-- DataTextField='<%# Eval("LastName")+" - "+Eval("FirstMidName") %>'--%>
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
                    <asp:Button ID="addStudentBnt" OnClick="AddStudentBnt_Click" runat="server" Text="Add Student" />
                </td>
            </tr>

        </table>
    </fieldset>

</asp:Content>
