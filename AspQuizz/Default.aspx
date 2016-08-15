<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspQuizz.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Script/jquery-3.1.0.min.js"></script>
    <style>

        body{
            margin:0px;
        }

        #Site{
            height:1200px;
            width:100%;
        }
        #Banner{
            height:200px;
            width:100%;
            background:rgba(12, 76, 255,0.7);
        }
        #gununSozu{
            height:100px;
            width:500px;
            margin-left:30%;
            margin-top:3%;
           position:absolute;
           justify-content:center;
           align-items:center;
           display:flex;
           font:italic 20px ComicSans;
           color:azure;
        }
        .Menu {
            height: 50px;
            width: 150px;
            background-color: rgb(17,232, 225);
            border: 0px solid;
            border-radius: 50px;
            margin-top: 150px;
            margin-left: 300px;
            justify-content: center;
            align-items: center;
            display: flex;
            cursor: pointer;
            color: darkblue;
            transition:color.5s ease-in-out;
            float:left;
        }
        .Menu:hover{
            color:#05b690;
        }
        #Konu{
            margin-left:30px;
        }
        #Profil{
            margin-left:30px;
        }
        #İletisim{
             margin-left:30px;
        }
        #Icerik{
            width:100%;
            height:800px;
            background:darkblue;
        }
        #AltKonular{
            width:200px;
            height:300px;
            position:absolute;
            left:450px;
            background:#20CBFF;
            display: flex;
            color: darkblue;
            border-radius:30px; 
            display:none;
        }
   
    </style>
    <script>
        $(document).ready(function () {
            $("#Konu").click(function () {
                $("#AltKonular").toggle("slow");
            })
        })
      
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Site">
        <div id="Banner">
            <span id="gununSozu">
                <asp:Repeater runat="server" ID="gununSozuRepeat">
                    <ItemTemplate>Günün Sözü:<%# Eval("Soz") %></ItemTemplate>
                </asp:Repeater>
            </span>
            <div class="Menu"> Ana Sayfa</div>
            <div class="Menu" id="Konu">Konular</div>
            <div class="Menu" id="Profil">Profil</div>
            <div class="Menu" id="İletisim">İletişim</div>
        </div>
        <div id="Icerik">
            <div id="AltKonular">
                <ul>
                    <asp:Repeater runat="server" ID="repeater" OnItemCreated="repeater_ItemCreated"  OnItemDataBound="repeater_ItemDataBound" >
                        <ItemTemplate><li><%# Eval("KonuAd") %>
                            <ul style="list-style:none">
                                <asp:Repeater runat="server" ID="repeater2">
                                    <ItemTemplate><li> <%# Eval("AltKonuAd") %></li></ItemTemplate>
                                </asp:Repeater>
                               </ul>
                                      </li></ItemTemplate>
                       
                    </asp:Repeater>
                    
                </ul>
            </div>
            <div id="Icerik"></div>
        </div>
    </div>
    </form>
</body>
</html>
