<%@ Page 
    Title="Book Contents"
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="BookContents.aspx.cs" 
    Inherits="MyBookShelf.WebForms.Forms.BookContents" 
    Async="true"
%>

<asp:Content
    ContentPlaceHolderID="MainContent"
    runat="server">
    
    <h2>Book Contents</h2>

    <asp:HiddenField 
        ID="hiddenBookId"
        runat="server"/>
    
    <div class="form-group">
        <label for="textContents">Contents (XML):</label>
        <asp:TextBox 
            ID="textContents"
            TextMode="MultiLine"
            Rows="13"
            Style="width:90vw; height:70vh"
            ValidateRequestMode="Disabled"
            runat="server"/>
        <asp:CustomValidator 
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