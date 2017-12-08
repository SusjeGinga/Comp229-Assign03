<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp229_Assign03._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Landing Page</h1>

    <asp:GridView ID="StudentsGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataTextField="StudentID" HeaderText="Student ID" DataNavigateUrlFields="StudentID" 
                DataNavigateUrlFormatString="StudentPage.aspx?StudentID={0}" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="FirstMidName" HeaderText="First Mid Name" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" DataFormatString="{0:MM-dd-yyyy}" />
        </Columns>
    </asp:GridView>
    <br /><br />

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



    <%--<div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>
</asp:Content>
