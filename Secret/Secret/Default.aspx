<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Secret.Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa Talet</title>
    <link href="Styles/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultfocus="InputTextBox">
    <div id="content">

            <h1>Gissa det hemliga talet</h1>
        <div id="guessArea">
            <asp:Label ID="Label1" runat="server" Text="Gissa på ett tal mellan 1 och 100:" />
            <asp:TextBox ID="InputTextBox" runat="server"/>

            <asp:Button ID="Button1" runat="server" Text="Gissa" OnClick="Button1_Click" />
        </div>
        <div id="answerArea">
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">

                <div id="previousGuesses">
                    <asp:Label ID="guessLabel" runat="server" Text=""></asp:Label>
                </div>

                <asp:PlaceHolder ID="ResetPlaceHolder" runat="server" Visible="false">

                    <div>
                        <asp:Button ID="ResetButton" type="Button" runat="server" Text="Reset" OnClick="ResetButton_Click" />
                    </div>

                </asp:PlaceHolder>      

            </asp:PlaceHolder>
        </div>

        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Talet måste vara mellan 0 och 100" ControlToValidate="InputTextBox" MaximumValue="100" MinimumValue="0" Display="Dynamic" CssClass="Error" Type="Integer"></asp:RangeValidator>
        <asp:RequiredFieldValidator CssClass="Error" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Fyll i ett tal" ControlToValidate="InputTextBox" Display="Dynamic" Font-Underline="False"></asp:RequiredFieldValidator>
        <asp:CompareValidator CssClass="Error" ID="CompareValidator2" runat="server" ErrorMessage="Du måste fylla i ett heltal." ControlToValidate="InputTextBox" Font-Bold="False" Operator="DataTypeCheck" SetFocusOnError="False" Type="Integer" ClientIDMode="Static"></asp:CompareValidator>
            

    </div>
    </form>
    <script src="Scripts/script.js"></script>
</body>
</html>
