<%@ Page Title="CD Library" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CDLibraryTest.aspx.cs" Inherits="WebApp.SamplePages.CDLibrary_Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1>CD Library</h1>


    <asp:RequiredFieldValidator ID="RequiredTitle" runat="server" ErrorMessage="Title is required." Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="CDTitle"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredYear" runat="server" ErrorMessage="Year is required." Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="ReleaseYear"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredNumberOfTracks" runat="server" ErrorMessage="Number of Tracks is required." Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="Tracks"></asp:RequiredFieldValidator>

    <asp:CompareValidator ID="CompareCheckAnswer" runat="server" ErrorMessage="Year is not a number" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="ReleaseYear" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
    <asp:RangeValidator ID="RangeReleaseYear" runat="server" ErrorMessage="Year must be between 1900 and greater" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="ReleaseYear" MinimumValue="1900" MaximumValue="3000" Type="Integer"></asp:RangeValidator>
    <asp:CompareValidator ID="CompareNumberOfTracks" runat="server" ErrorMessage="Tracks value must be greater than 0" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="Tracks" Operator="GreaterThanEqual" ValueToCompare="1" Type="Integer"></asp:CompareValidator>   





<div class="row">
  <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-info" HeaderText="Data entry errors. Examine your data to resolve the following concerns."/>
</div> 


<div class="row">
        <div class="col-md-6">
            <fieldset class="form-horizontal">

                <legend>Fill out the form below to add a CD to your personal library</legend>

                <asp:Label ID="Label1" runat="server" Text="ISBN (Barcode)" AssociatedControlID="CDISBN"></asp:Label>
                <asp:TextBox ID="CDISBN" runat="server"></asp:TextBox>

                <asp:Label ID="Label5" runat="server" Text="" AssociatedControlID="Search"></asp:Label>

                <asp:Label ID="Label2" runat="server" Text="Title" AssociatedControlID="CDTitle"></asp:Label>
                <asp:TextBox ID="CDTitle" runat="server"></asp:TextBox>


                <asp:Label ID="Label3" runat="server" Text="Artist(s)" AssociatedControlID="CDArtists"></asp:Label>
                <asp:TextBox ID="CDArtists" runat="server" Height="100px"></asp:TextBox>


                <asp:Label ID="Label4" runat="server" Text="Year" AssociatedControlID="ReleaseYear"></asp:Label>
                <asp:TextBox ID="ReleaseYear" runat="server" Width="150px"></asp:TextBox>              


                <asp:Label ID="Label6" runat="server" Text="Number of Tracks" AssociatedControlID="Tracks"></asp:Label>
                <asp:TextBox ID="Tracks" runat="server" Width="150px"></asp:TextBox>
               
            </fieldset>
        </div>

        <div class="col-md-10">
               <asp:Button ID="Submit" runat="server" Text="Add to Library" CssClass="btn btn-success" OnClick="Submit_Click"/>
               <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
        </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</div>
</asp:Content>
