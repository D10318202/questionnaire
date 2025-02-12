﻿<%@ Page Title="問卷總覽" Language="C#" MasterPageFile="~/FrontDesk/FrontDesk.Master" AutoEventWireup="true" CodeBehind="Allquestionnaire.aspx.cs" Inherits="Questionnaire.Allquestionnaire" %>

<%@ Register Src="~/ShareControls/ucPage.ascx" TagPrefix="uc1" TagName="ucPage" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="../JS/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>問卷總覽</h1>
    問卷標題:
        <asp:TextBox ID="txtquestitle" runat="server" placeholder="輸入關鍵字"></asp:TextBox><br />
    開始/結束:
        <asp:TextBox ID="txtstart" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
    <asp:TextBox ID="txtend" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="搜尋" onclick="btnSearch_Click"/><br />
    <table class="table table-striped">
        <tr>
            <th>#</th>
            <th>問卷標題</th>
            <th>投票狀態</th>
            <th>開始時間</th>
            <th>結束時間</th>
            <th>觀看統計</th>
        </tr>
        <asp:Repeater ID="repQuestionnaire" runat="server">
            <ItemTemplate>
                <asp:HiddenField ID="hfquesID" runat="server" Value='<%#Eval("quesID") %>' />
                <tr>
                    <td>
                        <asp:Label ID="lblNumber" runat="server"></asp:Label>
                    </td>
                    <td>
                        <a href="#" id="QuesLink" runat="server">
                            <%#Eval("quesTitle") %></a>
                    </td>
                    <td>
                        <asp:Label ID="lblquesanswer" runat="server" Text='<%#Eval("answerType")%>'></asp:Label>
                    </td>                    
                    <td>
                        <asp:Label ID="lblquesstart" runat="server" Text='<%#Eval("quesstart") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblquesend" runat="server" Text='<%#Eval("quesend") %>'></asp:Label>
                    </td>
                    <td>
                        <a href="TotalAnswer.aspx?quesID=<%#Eval("quesID") %>">前往</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <uc1:ucPage runat="server" id="ucPage" />
<%--    <script src="js/SearchkeyWord.js"></script>--%>
</asp:Content>
