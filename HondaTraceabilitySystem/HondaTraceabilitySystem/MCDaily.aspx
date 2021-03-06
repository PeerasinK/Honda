﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MCDaily.aspx.cs" Inherits="HondaTraceabilitySystem.MCDaily" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 800px;
            height: 240px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <tr>
                <td style="width: 200px; height: 45px;" valign="top" colspan="2">
                    <asp:Label ID="flblTitle" runat="server" Style="height: 23px;" CssClass="TitleLabel"
                            Width="330px">MC Daily Delivery</asp:Label>
                </td>
            </tr>
            
        </div>
        <br />
        <div>
            <%--<asp:ScriptManager runat="server"></asp:ScriptManager>--%>
            <table>
                <tr>
                    <td>**</td>
                    <td>Select Date :</td>
                    <td>
                        <asp:TextBox ID="txtSelectDate" runat="server" Width="90px"></asp:TextBox>
                        <asp:CalendarExtender ID="Calendar1" runat="server" PopupButtonID="imgPopup" TargetControlID="txtSelectDate" Format="yyyy/MM/dd" />
                    </td>
                    <td>Delivery Type :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDeliveryType" runat="server">
                            <asp:ListItem Text="--- Select Item ---" Value=""></asp:ListItem>
                            <asp:ListItem Text="CKD" Value="CKD"></asp:ListItem>
                            <asp:ListItem Text="CBU" Value="CBU"></asp:ListItem>
                            <asp:ListItem Text="KD Special" Value="KD Special"></asp:ListItem>
                            <asp:ListItem Text="Service Part" Value="Service"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>KD LotNo :
                    </td>
                    <td>
                        <asp:TextBox ID="txtKDLot" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Width="55px" Font-Bold="true" OnClick="btnSearch_Click"  />
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Font-Bold="true" Width="50px" Text="Add" OnClick="btnAdd_Click"  />
                    </td>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Font-Bold="true" Width="50px" Text="Delete" OnClick="btnDelete_Click"  />
                    </td>
                    <td>
                        <asp:Button ID="btnPrint" runat="server" Font-Bold="true" Width="50px" Text="Print" Style="height: 26px" OnClick="btnPrint_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gdvDaily" runat="server"></asp:GridView>
        </div>
        <div>
            <asp:ModalPopupExtender ID="mpe1" runat="server" PopupControlID="Panel1" TargetControlID="btnClose"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center">
                <div style="height: 60px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>Modify Daily Deliver
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>Delivery Type
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDeliveryTYP" runat="server" Width="70px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;KD LotNo
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtKDLotNo" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;Product
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtProduct" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Model
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtModel" runat="server" Width="70px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;Location (MC-P)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLocMC" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;To Location
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToLoc" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Old&nbsp;Lot No
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtLotNo1" runat="server"></asp:TextBox>
                                    </td>
                                    <td>New &nbsp;Lot No</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Select Date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSelectDateModi" runat="server" Width="90px"></asp:TextBox>
                                        <asp:CalendarExtender ID="Calendar2" runat="server" PopupButtonID="imgPopup" TargetControlID="txtSelectDateModi" Format="dd/MM/yyyy" />
                                    </td>
                                    <td>&nbsp;Sozai No
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSozaiNo" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearchModi" runat="server" Text="Search" Font-Bold="true" OnClick="btnSearchModi_Click"  />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Select Lot1</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlLot1" runat="server" Width="100%">
                                            <asp:ListItem Text="--- Select Item ---"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAddModiLot1" runat="server" Text="Add" Font-Bold="true" OnClick="btnAddModiLot1_Click" />
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td>&nbsp;Select Lot2</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlLot2" runat="server" Width="100%">
                                            <asp:ListItem Text="--- Select Item ---"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAddModiLot2" runat="server" Text="Add" Font-Bold="true" />
                                    </td>
                                </tr>--%>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <table>
                        <tr>
                            <td>
                                <br />
                                <asp:Button ID="btnClose" runat="server" Text="Close" Font-Bold="true" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>

</asp:Content>
