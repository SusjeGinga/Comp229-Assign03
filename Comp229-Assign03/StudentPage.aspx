﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="Comp229_Assign03.StudentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="studentIDLabel" runat="server" Text=""></asp:Label>
    <h1>Student Page</h1>
    
    <%--Display student detail--%>
    <asp:DetailsView ID="studentDetails" runat="server" AutoGenerateRows="False">
        <Fields>
            <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="FirstMidName" HeaderText="First Mid Name" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" />
        </Fields>
    </asp:DetailsView>

    <%--Delete and Update link--%>
    <asp:Button ID="Delete" runat="server" Text="Delete Student" OnClick="DeleteBtn_Click" />
    <asp:Button ID="Update" runat="server" Text="Update Student" OnClick="UpdateBtn_Click" />
    <br /><br />

    <%--Courses that student enrolled--%>
    <fieldset>
        <legend>Student's courses: </legend>
        <asp:GridView ID="coursesDetailsGrid" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:HyperLinkField DataTextField="CourseID" HeaderText="CourseID" DataNavigateUrlFields="CourseID"
                    DataNavigateUrlFormatString="CoursePage.aspx?CourseID={0}" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Credits" HeaderText="Credits" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" />
            </Columns>
        </asp:GridView>
    </fieldset>
</asp:Content>
