<%@ Page
    Title="My Book Shelf" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Home.aspx.cs" 
    Inherits="MyBookShelf.WebForms.Home"
    Async="true"
%>

<asp:Content ID="BodyContent" 
             ContentPlaceHolderID="MainContent" 
             runat="server">

    <h2>Books from MyBookShelf!</h2>
    
    <asp:Button 
        ID="buttonAddBook" 
        Text="Add new book" 
        CssClass="btn btn-primary" 
        OnClick="buttonAddBook_OnClick" 
        runat="server" />
    <br/>

    <asp:GridView 
        ID="gridViewBooks" 
        AutoGenerateColumns="False" 
        CssClass="table" 
        DataKeyNames="Id"
        OnRowCommand="gridViewBooks_OnRowCommand"
        EmptyDataText="No books yet, add the new one immediately!"
        runat="server">
        
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True"/>
            <asp:BoundField DataField="Title" HeaderText="Title"/>
            <asp:BoundField DataField="Author" HeaderText="Author"/>
            <asp:BoundField DataField="PublishYear" HeaderText="Publish Year" NullDisplayText="-"/>

            <asp:TemplateField HeaderText="Contents">
                <ItemTemplate>
                    <asp:Button 
                        ID="buttonShowContents"
                        Text="Show"
                        CommandName="ShowContents"
                        CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-sm btn-info"
                        runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Commands">
                <ItemTemplate>
                    <asp:Button 
                        ID="buttonEditBook"
                        Text="Edit"
                        CommandName="EditBook"
                        CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-sm btn-warning"
                        runat="server"/>
                    <asp:Button 
                        ID="buttonDeleteBook"
                        Text="Delete"
                        CommandName="DeleteBook"
                        CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-sm btn-danger"
                        OnClientClick="return confirm('Are you sure you want to delete this book?');"
                        runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

</asp:Content>
