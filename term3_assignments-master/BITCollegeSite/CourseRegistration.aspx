<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseRegistration.aspx.cs" Inherits="BITCollegeSite.CourseRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="lblStudentName" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblCourseSelector" runat="server" Text="Course Selector:" Width="150px"></asp:Label>
        <asp:DropDownList ID="ddlCourseSelector" runat="server" Width="150px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblRegistrationNotes" runat="server" Text="Registration Notes:" Width="150px"></asp:Label>
        <asp:TextBox ID="txtRegistrationNotes" runat="server" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNotes" runat="server" ControlToValidate="txtRegistrationNotes" Enabled="False" ErrorMessage="Required: Field cannot be empty." ForeColor="#CC0000"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:LinkButton ID="btnRegister" runat="server" OnClick="btnRegister_Click" Width="100px">Register</asp:LinkButton>
        <asp:LinkButton ID="btnReturn" runat="server" OnClick="btnReturn_Click" Width="200px">Return to Registration Listing</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" Text="Label" ForeColor="#CC0000" Visible="False"></asp:Label>
    </p>
</asp:Content>
