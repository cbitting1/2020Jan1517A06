<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="WebApp.SamplePages.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>TestPage for Menu</h1>



    <%-- Link for using Icons: https://fontawesome.com/icons?d=gallery&q=plus&m=free --%>

    <asp:LinkButton ID="LinkButton1" runat="server">
        <i class="fa fa-trash-o fa-lg"></i> Font Awesome v4.7.0 <%--copied from the website--%>
    </asp:LinkButton> <br />

    <asp:LinkButton ID="LinkButton2" runat="server">
      <i class="fa fa-flag"></i>
    </asp:LinkButton> <br />

    <asp:LinkButton ID="LinkButton3" runat="server">
        <i class="fa fa-flag-checkered fa-4x"></i>    
    </asp:LinkButton>
    <%-- if some links don't work than try to remove the 's' or 'b' from the first 'fas'; 'fab'; if that doesn't work it's not for free --%>
  
</asp:Content>
