<%@ Page Title="Blur Faces" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Faces.aspx.cs" Inherits="BlureFaces.Engine.Faces" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="contentBody" runat="server">

    <h2 class="edit">Here you can upload your images and see how them will change </h2>
    
    <div class="content">
        <asp:Panel ID="CP1" runat="server">
            <hr />
            <asp:Label ID="label1" runat="server" Text="Strength:"></asp:Label>
            <asp:TextBox ID="TextBoxStrenght" Text="30" TextMode="Number" runat="server" min="0" max="99" step="1" width="60" />

            <div class="Paddding"></div>

            <asp:FileUpload ID="FileUpload1" runat="server" Width ="300" />
            <div class="Paddding"></div>
            <asp:Button ID="btnUpload" runat="server" Text="Upload and Processed" OnClick="Upload" />
            <div class="Paddding"></div>


            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowHeader="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Text" />
                    <asp:ImageField ControlStyle-Height="490" ControlStyle-Width="650" DataImageUrlField="Value">
                        <ControlStyle Height="490" Width="650" />
                    </asp:ImageField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </asp:Panel>

    </div>
    <div class="clear"></div>
</asp:Content>


