<%@ Page 
    Title="Update Book On Shelf"
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="UpdateBook.aspx.cs" 
    Inherits="MyBookShelf.WebForms.Forms.UpdateBook" 
    Async="true"
%>

<asp:Content 
    ID="UpdateBookContent"
    ContentPlaceHolderID="MainContent"
    runat="server" >

    <h2>Update book on shelf!</h2>
    
    <asp:ValidationSummary 
        ID="ValidationSummary" 
        CssClass="alert alert-danger"
        runat="server" />
    
    <asp:HiddenField 
        ID ="hiddenBookId"
        runat="server"/>
    
    <div class="form-group">
        <label for="textTitle">Title:</label>
        <asp:TextBox ID="textTitle" 
                     CssClass="form-control" 
                     runat="server"/>
        <asp:RequiredFieldValidator 
            ControlToValidate="textTitle"
            ErrorMessage="Enter the book title, please!"
            CssClass="text-danger"
            runat="server"/>
    </div>
    
    <div class="form-group">
        <label for="textAuthor">Author:</label>
        <asp:TextBox ID="textAuthor" 
                     CssClass="form-control" 
                     runat="server"/>
        <asp:RequiredFieldValidator 
            ControlToValidate="textAuthor"
            ErrorMessage="Enter the book author, please!"
            CssClass="text-danger"
            runat="server"/>
    </div>
    
    <div class="form-group">
        <label for="textPublishYear">Publish Year:</label>
        <asp:TextBox ID="textPublishYear" 
                     CssClass="form-control" 
                     MaxLength="4" 
                     TextMode="Number"
                     runat="server"/>
        <asp:RangeValidator
            ID="textPublishYearRangeValidator"
            ControlToValidate="textPublishYear"
            Type="Integer"
            CssClass="text-danger"
            runat="server"/>
        <asp:CompareValidator 
            ControlToValidate="textPublishYear"
            Operator="DataTypeCheck"
            Type="Integer"
            ErrorMessage="Enter integer year"
            CssClass="text-danger"
            Display="Dynamic"
            runat="server"/>
    </div>
    
    <div class="form-group">
        <label for="textContents">Contents (XML):</label>
        <asp:TextBox ID="textContents" 
                     TextMode="MultiLine"
                     Rows="7"
                     CssClass="form-control" 
                     ValidateRequestMode="Disabled"
                     runat="server"/>
        <asp:CustomValidator 
            ID="textContentsValidator"
            ControlToValidate="textContents"
            OnServerValidate="OnValidateXMLContents"
            ErrorMessage="The contents should be a valid XML or left empty!"
            Display="Dynamic"
            CssClass="text-danger"
            runat="server"/>
    </div>
    
    <asp:Button ID="buttonSave"
                Text="Save"
                CssClass="btn btn-primary"
                OnClick="buttonSave_Click"
                runat="server" />
    
    <asp:Button ID="buttonCancel"
                Text="Cancel"
                CssClass="btn btn-secondary"
                OnClick="buttonCancel_Click"
                CausesValidation="False"
                runat="server" />
    

</asp:Content>
