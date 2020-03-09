<%@ Page Title="Movies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="WebApp.SamplePages.Movies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <h1>Movie Library</h1>


<div class="row">
        <div class="col-md-6">
            <fieldset class="form-horizontal">

                <legend>Fill out the form below to add information on the movie for your movie library</legend>

                <asp:Label ID="Label1" runat="server" Text="Title" AssociatedControlID="MovieTitle"></asp:Label>
                <asp:TextBox ID="MovieTitle" runat="server"></asp:TextBox>


                <asp:Label ID="Label2" runat="server" Text="Year" AssociatedControlID="YearMovie"></asp:Label>
                <asp:TextBox ID="YearMovie" runat="server"></asp:TextBox>


                <asp:Label ID="Label3" runat="server" Text="Media" AssociatedControlID="MediaSelection"></asp:Label>
                <asp:RadioButtonList ID="MediaSelection" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">&nbsp;DVD&nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem Value="2">&nbsp;VHS&nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem Value="3">&nbsp;File</asp:ListItem>
                </asp:RadioButtonList>




                <asp:Label ID="Label4" runat="server" Text="Rating" AssociatedControlID="MovieRatings"></asp:Label>
                <asp:CheckBoxList ID="MovieRatings" runat="server">
                    <asp:ListItem>General (G)</asp:ListItem>
                    <asp:ListItem>Parental Guidance (PG)</asp:ListItem>
                    <asp:ListItem>14A</asp:ListItem>
                    <asp:ListItem>18A</asp:ListItem>
                    <asp:ListItem>Restricted (R)</asp:ListItem>
                </asp:CheckBoxList>

              
                <asp:Label ID="Label5" runat="server" Text="Rating" AssociatedControlID="MovieRatings"></asp:Label>
                <asp:DropDownList ID="StarList" runat="server" CssClass="form-control" ></asp:DropDownList>


                <asp:Label ID="Label6" runat="server" Text="ISBN" AssociatedControlID="MovieISBN"></asp:Label>
                <asp:TextBox ID="MovieISBN" runat="server"></asp:TextBox>
               
            </fieldset>
        </div>
                <div class="col-md-10">
                         <asp:Button ID="Submit" runat="server" Text="Add to Library" CssClass="btn btn-success" OnClick="Submit_Click"/>
                         <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
                </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</div>
</asp:Content>