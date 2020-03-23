<%@ Page Title="User Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration(Test).aspx.cs" Inherits="WebApp.SamplePages.UserRegistration_Test_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--Please fill in the form below and click submit. After submittingthe form,
                       you will receive an email with a lin to confirm your registration. By clicking
                       on that link, you will complete the registration process.--%>
    <h1>User Registration</h1>


    <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server" ErrorMessage="First Name is required." Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="FName"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredLastName" runat="server" ErrorMessage="Last Name is required." Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="LName"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredUserName" runat="server" ErrorMessage="User Name is required." Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="User"></asp:RequiredFieldValidator>

    <asp:CompareValidator ID="CompareCheckAnswer" runat="server" ErrorMessage="Email Adressess do not match" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="Email" Operator="Equal" ControlToCompare="ConfirmedEmail"></asp:CompareValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="EnteredPassword" Operator="Equal" ControlToCompare="ConfrimedPassword"></asp:CompareValidator>



<div class="row">
  <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-info" HeaderText="Data entry errors. Examine your data to resolve the following concerns."/>
</div> 

    <div class="row">
        <div class="col-md-6">
            <fieldset class="form-horizontal">
               <legend>Please fill in the form below and click submit. After submittingthe form,
                       you will receive an email with a lin to confirm your registration. By clicking
                       on that link, you will complete the registration process.</legend>

                <asp:Label ID="Label1" runat="server" Text="First Name" AssociatedControlID="FName"></asp:Label>
                <asp:TextBox ID="FName" runat="server"></asp:TextBox>



                <asp:Label ID="Label2" runat="server" Text="Last Name" AssociatedControlID="LName"></asp:Label>
                <asp:TextBox ID="LName" runat="server"></asp:TextBox>




                <asp:Label ID="Label3" runat="server" Text="User Name" AssociatedControlID="User"></asp:Label>
                <asp:TextBox ID="User" runat="server"></asp:TextBox>




                <asp:Label ID="Label4" runat="server" Text="Email Address" AssociatedControlID="Email"></asp:Label>
                <asp:TextBox ID="Email" runat="server"></asp:TextBox>




                <asp:Label ID="Label5" runat="server" Text="Confirm Email" AssociatedControlID="ConfirmedEmail"></asp:Label>
                <asp:TextBox ID="ConfirmedEmail" runat="server"></asp:TextBox>
          


                <asp:Label ID="Label6" runat="server" Text="Password" AssociatedControlID="EnteredPassword"></asp:Label>
                <asp:TextBox ID="EnteredPassword" runat="server" MaxLength="8" MinLength="4"></asp:TextBox>



                <asp:Label ID="Label7" runat="server" Text="Confirm Password" AssociatedControlID="ConfrimedPassword"></asp:Label>
                <asp:TextBox ID="ConfrimedPassword" runat="server"></asp:TextBox>


                <asp:CheckBox ID="Terms" runat="server" Text="I agree to the terms of this site"/>

            </fieldset>
            <br />
               <asp:Button ID="Submit" runat="server" Text="Submit Registration" CssClass="btn btn-success" OnClick="Submit_Click" />
               <asp:Label ID="OutputMessage" runat="server" Text=""></asp:Label>

        </div>
            <script src="../Scripts/bootwrap-freecode.js"></script>
    </div>
</asp:Content>
