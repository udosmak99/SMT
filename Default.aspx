<%@ Page Title="" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/jsrender.js" type="text/javascript"></script>
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?v=3&amp;language=th-TH&amp;sensor=false"></script>
<script type="text/javascript" src="js/infobox.js"></script>
<script type="text/javascript" src="js/jquery.totemticker.js"></script>
<link href="css/reset.css" rel="stylesheet" type="text/css" />
<link href="css/jquery.mCustomScrollbar.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="css/easydropdown.css"/>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<div id="contents" >
<div id="map-wrapper" >

<!--div id="left-wrap"></div>
<div id="right-wrap"></div-->
<div id="bottom-wrap">
<div  id="symbol">
<div class="symbols" id="symbols0">
<div class="icon-head">
<div class="iButton blue black-shadow box-level" id="water-level">การเชื่อมโยง</div>
</div><div class="symbols_inside"><ul id="icon0"></ul>
</div>
</div>
<div class="symbols" id="symbols1">
<div class="icon-head">
<div class="iButton blue black-shadow box-level" id="water-level">ระดับน้ำ</div>
</div><div class="symbols_inside"><ul id="icon1"></ul>
</div>
</div>
<!--div class="symbols" id="symbols2">
<div class="icon-head">
<div class="iButton blue black-shadow box-level" id="rain-level">เธเธฃเธดเธกเธฒเธ“เธเธ</div>
</div>
<div class="symbols_inside"><ul id="icon2"></ul>
</div>
</div-->
</div>
</div>
<div id="map_canvas"></div>
</div>
</div>
 <script type="text/javascript">

    

var basin_group = [

        <%
  For row As Integer = 0 to Session("basin").GetUpperBound(0)
   
   Dim name as String = CStr(Session("basin")(row,1))
%>
     
				"<% Response.Write(name) %>"
  <% If row < Session("basin").GetUpperBound(0) Then Response.Write(",") %>
  <%
Next
%>
];
var province_group = [

        <%
  For row As Integer = 0 to Session("province").GetUpperBound(0)
   
   Dim name as String = CStr(Session("province")(row,1))
%>
     
				"<% Response.Write(name) %>"
  <% If row < Session("province").GetUpperBound(0) Then Response.Write(",") %>
  <%
Next
%>
];

<%
    Dim nor_new as Integer = Session("Icon")(0,0)
    Dim nor_old as Integer = Session("Icon")(0,1)
    Dim warn_new as Integer = Session("Icon")(0,2)
    Dim warn_old as Integer = Session("Icon")(0,3)
    Dim cri_new as Integer = Session("Icon")(0,4)
    Dim cri_old as Integer = Session("Icon")(0,5)
%>
var icons1 = [
		{
		    icon: "pin-01.png",
		    icon2: "pin-11.png",
		    unit1: "<% Response.Write(nor_new) %>",
		    unit2: "<% Response.Write(nor_old) %>",
		    title: "ปกติ",
		    title_e: "Normal"
		},
		{
		    icon: "pin-02.png",
		    icon2: "pin-12.png",
		   unit1: "<% Response.Write(warn_new) %>",
		    unit2: "<% Response.Write(warn_old) %>",
		    title: "เตือนภัย",
		    title_e: "Warning"
		},
		{
		    icon: "pin-03.png",
		    icon2: "pin-13.png",
		  unit1: "<% Response.Write(cri_new) %>",
		    unit2: "<% Response.Write(cri_old) %>",
		    title: "วิกฤติ",
		    title_e: "Urgent"
		}

	];

    </script>
 <script src="js/config.js" type="text/javascript"></script>
<script src="js/gmap.js" type="text/javascript"></script>
<script src="js/menu.js" type="text/javascript"></script>
<script src="js/jquery.mCustomScrollbar.js"></script>	
<script src="js/jquery.easydropdown.js"></script>

<script type="text/javascript">
    
    $(document).ready(function (e) {
        $("#menu-0").addClass('active');
        
    });
    
</script>

</asp:Content>