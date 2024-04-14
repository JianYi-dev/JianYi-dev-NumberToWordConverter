<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NumberToWordConverter._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Number To Words Converter</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            
        </div>
        <div class="col-md-4 text-center">
            <h2 style="text-align: left;">Number:</h2>
            <asp:TextBox ID="txtNumber" runat="server" CssClass="form-control" placeholder="Enter a number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidator" runat="server" ControlToValidate="txtNumber"
                ErrorMessage="Please enter a number" ValidationGroup="submit" CssClass="text-danger" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="regexValidator" runat="server" ControlToValidate="txtNumber"
                ValidationExpression="^\d{1,18}(?:\.\d{1,2})?$" ErrorMessage="Please enter a valid number with up to 2 decimal places and maximum value of 999999999999999999.99"
                ValidationGroup="submit" CssClass="text-danger" Display="Dynamic" />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="submit" CssClass="btn btn-primary" />
            <br />
            <h2 style="text-align: left;">Result:</h2>
            <div style="border-style: double; padding: 5px; margin-top: 10px; border-radius: 5px;">
                <asp:Label ID="lblResult" runat="server" Text="<br /><br />" CssClass="result-label"></asp:Label>
            </div>
        </div>
        <div class="col-md-4">
            
        </div>
    </div>

</asp:Content>