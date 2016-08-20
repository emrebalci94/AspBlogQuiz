<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AltKategori.ascx.cs" Inherits="AspQuizz.AltKategori" %>
<style>
    body{ 
        color:white;
    }
</style>
<div >
    <asp:Repeater runat="server" ID="repeat">
        <ItemTemplate><p><%# Eval("AltKonuAd") %></p></ItemTemplate>
    </asp:Repeater>
    <br />
</div>
<div runat="server" id="div">

</div>