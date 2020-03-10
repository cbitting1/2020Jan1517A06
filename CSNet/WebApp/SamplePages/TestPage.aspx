<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="WebApp.SamplePages.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>TestPage for Menu</h1>

    <asp:LinkButton ID="LinkButton1" runat="server">
        <i class="fa fa-trash-o fa-lg"></i> Font Awesome v4.7.0
    </asp:LinkButton> <br />

    <asp:LinkButton ID="LinkButton2" runat="server">
      <i class="fa fa-flag"></i>
    </asp:LinkButton> <br />

    <asp:LinkButton ID="LinkButton3" runat="server">
        <i class="fa fa-flag-checkered fa-4x"></i>    
    </asp:LinkButton>

  
</asp:Content>
