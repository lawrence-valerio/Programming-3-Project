<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDrop.aspx.cs" Inherits="BITCollegeSite.ViewDrop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:DetailsView ID="dvCourse" runat="server" AutoGenerateRows="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="50px" Width="300px" AllowPaging="True" OnPageIndexChanging="dvCourse_PageIndexChanging">
            <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="RegistrationId" HeaderText="Registration" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Student.FullName" HeaderText="Student" >
                <ControlStyle BorderWidth="1px" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Course.Title" HeaderText="Course" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="RegistrationDate" DataFormatString="{0:d}" HeaderText="Date" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Grade" DataFormatString="{0:p}" HeaderText="Grade" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Fields>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
        </asp:DetailsView>
    </p>
    <p>
        <asp:LinkButton ID="btnDropCourse" runat="server" Width="115px" Height="16px" OnClick="btnDropCourse_Click">Drop Course</asp:LinkButton>
        <asp:LinkButton ID="btnReturn" runat="server" Height="16px" Width="200px" OnClick="btnReturn_Click">Return to Registration Listing</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False" ForeColor="#CC0000"></asp:Label>
    </p>
</asp:Content>
