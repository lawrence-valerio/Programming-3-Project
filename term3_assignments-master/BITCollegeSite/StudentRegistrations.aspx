<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentRegistrations.aspx.cs" Inherits="BITCollegeSite.SudentRegistrations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="lblStudentName" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvCourses_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Course.CourseNumber" HeaderText="Course">
                <HeaderStyle Width="100px" Wrap="False" />
                <ItemStyle Width="100px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Course.Title" HeaderText="Title" >
                <HeaderStyle Width="175px" Wrap="False" />
                <ItemStyle Width="175px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Course.CourseType" HeaderText="Course Type" >
                <HeaderStyle Width="100px" />
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Course.TuitionAmount" DataFormatString="{0:c}" HeaderText="Tuition">
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Right" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Grade" DataFormatString="{0:p}" HeaderText="Grade">
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Right" Width="100px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="lblInfo" runat="server" Text="Click the Select Beside a registration (above) to View or Drop the course"></asp:Label>
    </p>
    <p>
        <asp:LinkButton ID="btnRegister" runat="server" OnClick="btnRegister_Click">Click Here to Register for a Course</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblStudentError" runat="server" Text="Label" Visible="False" ForeColor="#CC0000"></asp:Label>
    </p>
</asp:Content>
