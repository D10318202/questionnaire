﻿<%@ Page Title="後台-常用問題管理" Language="C#" MasterPageFile="~/Backadmin/Backadmin.Master" AutoEventWireup="true" CodeBehind="Oftenusequestion.aspx.cs" Inherits="Questionnaire.Backadmin.Oftenusequestion" %>

<%@ Register Src="~/ShareControls/ucPage.ascx" TagPrefix="uc1" TagName="ucPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JS/bootstrap.min.js"></script>
    <link href="../CSS/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h2>常用問題管理</h2>
        </div>
        <div class="row">
            <div class="col-lg-8">
                <table>
                    <tr>
                        <td>問卷標題</td>
                        <td>
                            <asp:TextBox ID="txtkeyword" runat="server" placeholder="請輸入搜尋文字"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="搜尋" onclick="btnSearch_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td>新增問題範例</td>
                        <td>
                            <asp:TextBox ID="txtCreate" runat="server" placeholder="請輸入範例標題"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnCreate" runat="server" Text="新增" OnClick="btnCreate_Click" BackColor="LimeGreen" />
                        </td>
                    </tr>
                </table>

                <table class="table table-striped">
                    <asp:Label ID="lblnoresult" runat="server" Color="Red" Visible="false"></asp:Label>
                    <tr>
                        <th></th>
                        <th>#</th>
                        <th>標題</th>
                        <th>建立時間</th>
                    </tr>
                    <asp:Repeater ID="rptQuestionOften" runat="server">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfID" runat="server" Value='<%#Eval("quesID") %>' />
                            <tr>
                                <td>
                                    <asp:CheckBox ID="ckbDel" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="lblNumber" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <a href="OftenQuestionDesign.aspx?quesID=<%#Eval("quesID") %>">
                                        <asp:Label ID="lblQueryName" runat="server" Text='<%#Eval("quesTitle") %>'></asp:Label></a>
                                </td>
                                <td>
                                    <asp:Label ID="lblCreateTime" runat="server" Text='<%#Eval("CreateTime") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <asp:Button ID="btnDelete" runat="server" Text="刪除" Onclick="btnDelete_Click" BackColor="Red"/>
            </div>
        </div>
    </div>
    <uc1:ucPage runat="server" ID="ucPage" />
</asp:Content>
