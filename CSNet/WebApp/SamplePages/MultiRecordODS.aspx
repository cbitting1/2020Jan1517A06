﻿<%@ Page Title="MultiRecord ODS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="MultiRecordODS.aspx.cs" Inherits="WebApp.SamplePages.MultiRecordODS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="page-header">
        <h1>Product MultiRecord Object DataSource</h1>
    </div>

    <div class="row col-md-12">
        <div class="alert alert-warning">
            <blockquote style="font-style: italic">
                This illustrates a display of multiple records from a query.
                The parameter can be submitted from either a drop down list
                or a textbox. This example will use a dropdownlist load via
                a ObjectDataSource. The resulting dataset is a list of Products
                whose foreign key value matches the search argument value.<br />
                The output will be displayed in a product GridView. The Gridview
                will be customized using Templates and web controls. The Gridview
                will be limited to 3 rows of display. The Gridview will demonstrate
                paging. The page will demonstrate row selection from the GridView.
            </blockquote>
        </div>
    </div>
    <div class="row">
        <asp:Literal ID="Literal1" runat="server" Text="Categories:"></asp:Literal>
        &nbsp;&nbsp;
        <asp:DropDownList ID="CategoryList" runat="server" DataSourceID="CategoryListODS" DataTextField="CategoryName" DataValueField="CategoryID" AppendDataBoundItems="true">
            <asp:ListItem Value="0">select ...</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:LinkButton ID="FetchCategoryProducts" runat="server" OnClick="FetchCategoryProducts_Click">Fetch</asp:LinkButton>
        <br />
    </div>
  
     <div class="row">
        <asp:GridView ID="ProductList" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="Horizontal" BorderStyle="None" OnSelectedIndexChanged="ProductList_SelectedIndexChanged" DataSourceID="ProductListODS" AllowPaging="True" PageSize="3">
              <Columns>
                <asp:CommandField SelectText="View" ShowSelectButton="True"></asp:CommandField>
               <%-- <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="ProductID" runat="server" 
                            Text='<%# Eval("ProductID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Product">
                    <ItemTemplate>
                        <asp:Label ID="ProductID" runat="server"  Visible="false" Text='<%# Eval("ProductID") %>'></asp:Label>
                        <asp:Label ID="ProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier">
                    <ItemTemplate>
                      <%-- <asp:Label ID="SupplierID" runat="server" 
                            Text='<%# Eval("SupplierID") %>'></asp:Label>--%>
                        <asp:DropDownList ID="SupplierListGV" runat="server" DataSourceID="SupplierListGVODS" DataTextField="CompanyName" DataValueField="SupplierID" AppendDataBoundItems="true" selectedvalue='<%# Eval("SupplierID") %>' Enabled="false">
                            <asp:ListItem value="0">select ...</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category">
                    <ItemTemplate>
                        <%-- <asp:Label ID="CategoryID" runat="server" 
                            Text='<%# Eval("CategoryID") %>'></asp:Label>--%>
                        <asp:DropDownList ID="CategoryListGV" runat="server" DataSourceID="CategoryListODS" DataTextField="CategoryName" DataValueField="CategoryID" AppendDataBoundItems="true" selectedvalue='<%# Eval("CategoryID") %>' Enabled="false">
                            <asp:ListItem value="0">select ...</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="($)">
                    <ItemTemplate>
                        <asp:Label ID="UnitPrice" runat="server" Text='<%# string.Format("{0:0.00}",Eval("UnitPrice")) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Disc.">
                    <ItemTemplate>
                        <asp:CheckBox ID="Discontinued" runat="server" Checked='<%# Eval("Discontinued") %>' Enabled="false"/>
                    </ItemTemplate>
                </asp:TemplateField>
              </Columns>
            <EmptyDataTemplate> <%--In case it doesn't find any products in that category--%>
                No Data available for select category
            </EmptyDataTemplate>
        </asp:GridView>
        <br /><br />
        <asp:Label ID="Message" runat="server" ></asp:Label>
    </div>
    <asp:ObjectDataSource ID="CategoryListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Categories_List" TypeName="NorthwindSystem.BLL.CategoryController">
    </asp:ObjectDataSource> <%--Fills the dropdown on the webpage--%>

    <asp:ObjectDataSource ID="ProductListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Products_FindByCategory" TypeName="NorthwindSystem.BLL.ProductController">
        <SelectParameters>
            <asp:ControlParameter ControlID="CategoryList" PropertyName="SelectedValue" DefaultValue="0" Name="categoryid" Type="Int32"></asp:ControlParameter>
        </SelectParameters> <%--Name of the GridView plus the ODS at the end // Gives the Products field in the Grid View its data--%>  <%--This is for the lookup of info by a foreign key--%>
    </asp:ObjectDataSource>

     <asp:ObjectDataSource ID="SupplierListGVODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Suppliers_List" TypeName="NorthwindSystem.BLL.SupplierController">
    </asp:ObjectDataSource> <%--For the Supplier List on the Grid View (it will be a Dropdown in the Grid View)--%>


</asp:Content> 