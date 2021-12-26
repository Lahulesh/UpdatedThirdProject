﻿<%@ Page Title="" Language="C#" MasterPageFile="~/First.Master" AutoEventWireup="true" CodeBehind="assetlist.aspx.cs" Inherits="Third.assetlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>&nbsp;Asset List</h1>
        <asp:TextBox ID="assetsearch" runat="server" autocomplete="off"></asp:TextBox>
        <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" /><br /><br />
        <asp:GridView ID="AssetListGrid" runat="server" DataKeyNames="AssetID" AutoGenerateColumns="False" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" OnRowDeleting="GridView1_RowDeleting" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="AssetID" HeaderText="Asset ID" />
                <asp:BoundField DataField="AssetName" HeaderText="Asset" />
                <asp:BoundField DataField="VendorName" HeaderText="Vendor" />
                <asp:BoundField DataField="Cost" HeaderText="Cost" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" HeaderText="Edit" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" HeaderText="Delete" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>

    <div class="assetlist" >
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="AssetId:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEditAssetId" runat="server" readonly='true' placeholder="Auto generate Id"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="AssetName:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEditAssetName" runat="server" autocomplete="off"></asp:TextBox>
<%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required" ControlToValidate="TextBoxEditAssetName"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="VendorName:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListEditVendorAsset" autocomplete="off" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Cost"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEditCost" runat="server" autocomplete="off" min="1" max="100000" type="number"></asp:TextBox>
<%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter Cost" ControlToValidate="TextBoxEditCost"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td id="UpBox">
                    <asp:Button ID="ButtonEditAsset" runat="server" Text="Update" OnClick="ButtonEditAsset_Click" />
                </td>
                <td id="UpBox">
                    <asp:Button ID="ButtonCancelEdit" runat="server" Text="Cancel" OnClick="ButtonCancelEdit_Click" />
                </td>
            </tr>
        </table>
    </div>
<%--    <div class="assetlist">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Label ID="Label1" runat="server" Text="AssetID"></asp:Label>
        <asp:TextBox ID="AssetID" runat="server" autocomplete="off" readonly='true' placeholder="Auto generate Id"></asp:TextBox><br /><br />

        <asp:Label ID="Label2" runat="server" Text="Asset Name"></asp:Label>
        <asp:TextBox ID="AssetName" runat="server" autocomplete="off" placeholder="Asset Name"></asp:TextBox><br /><br />

        <asp:Label ID="Label3" runat="server" Text="Vendor Name"></asp:Label>
        <asp:DropDownList ID="vendorname" runat="server"></asp:DropDownList><br /><br />

        <asp:Label ID="Label4" runat="server" Text="Cost"></asp:Label>
        <asp:TextBox ID="Cost" runat="server" autocomplete="off" placeholder="Cost"></asp:TextBox><br /><br />

        <input id="ButtonEditAsset" type="button" value="Update" OnClick="ButtonEditAsset_Click" />
    </div>--%>
</asp:Content>
