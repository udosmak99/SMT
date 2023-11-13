<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="StationImage.aspx.vb" Inherits="StationImage" %>

<%@ Register  assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/jsrender.js" type="text/javascript"></script>
<script type="text/javascript" src="js/jquery.totemticker.js"></script>
<link href="css/reset.css" rel="stylesheet" type="text/css" />
<link href="css/jquery.mCustomScrollbar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<article>
<div id="contents" >
<div >
<asp:HiddenField ID="HiddenCodeNextPage" runat="server"></asp:HiddenField>
<asp:HiddenField ID="HiddenIndex" runat="server"></asp:HiddenField>
<div class="details">
<div id="station-detail">
<ul id="sub-station"><li data="station-main" onclick="GotoDetailStation()"><div class="txt">ข้อมูลรายสถานี</div></li><li class="active"  data="station-photo"><div class="txt">ภาพถ่ายสถานี</div></li><li data="station-graph"><div class="txt" onclick="GotoChart()">กราฟแสดงข้อมูลรายสถานี</div></li></ul>
</div>



<div id="station-head">
<ul><li><img src="images/pin-<% Response.Write(Session("wStation")(Request.QueryString("index")-1,15)) %>.png" vspace="5"/></li><li><div class="head"><span><asp:Label ID="lblHeader_stncode" runat="server" Text="สถานี G102"></asp:Label> :</span> <asp:Label ID="lblHeader_stnname" runat="server" Text="น้ำแม่ลาว" ForeColor="#0099CC"></asp:Label></div><div class="address"><asp:Label ID="lblHeader_address" runat="server" Text="บ้านต้นยาง ต.วาวี อ.แม่สรวย  จ.เชียงราย"></asp:Label></div></li>
<li class="date-time"><div class="date">ข้อมูลล่าสุด</div><div class="time"><asp:Label ID="lblTimeupdate" runat="server" Text="วันเสาร์ที่ 6 ตุลาคม 2556 | 10.00 น."></asp:Label></div></li>

</ul>

</div>
<div id="station-photo" class="data">
<div class="station-info">
<div class="photo" style="background:url(images/station-image/<% Response.Write(Request.QueryString("CODE")) %>.png) 0 0 no-repeat;"></div>
<div class="head" id="head-map"><img src="images/icon-pin.png"  align="absmiddle" hspace="10"/>แผนที่ตั้งสถานี</div>
<div id="map-wrapper2"> <div id="map-canvas2"></div></div>
</div>

<div class="station-info">
<div class="info-data" style="margin-top: -917px;margin-left: 650px;">
<ul><li class="top"></li>
<li class="center">
<div class="head"><img src="images/water-icon.png"  align="absmiddle" hspace="10"/>ข้อมูลจำเพาะของสถานี</div>
<ul class="data spec" >
<li><span>ชื่อสถานี : </span><div  class="spec"><asp:Label ID="lblstnname" runat="server" Text="G10 แม่น้ำลาว"></asp:Label></div></li>
<li><span>รหัส : </span><div class="spec"><asp:Label ID="lblstncode" runat="server" Text="SMT 100"></asp:Label></div></li>
<li><span>ลุ่มน้ำย่อย :</span><div class="spec"><asp:Label ID="lblbasin" runat="server" Text="แม่น้ำลาว"></asp:Label></div></li>
<li><span>ละติจูด :</span><div class="spec"><asp:Label ID="lbllat" runat="server" Text="16.33092"></asp:Label></div></li>
<li><span>ลองจิจูด :</span><div class="spec"><asp:Label ID="lbllong" runat="server" Text="99.26475"></asp:Label></div></li>
<li><span>ละติจูด (UTM) :</span><div class="spec"><asp:Label ID="lbllatUtm" runat="server" Text="16° 19' 51.3006"></asp:Label></div></li>
<li><span>ลองจิจูด (UTM) :</span><div class="spec"><asp:Label ID="lbllongUtm" runat="server" Text="99° 15' 53.1"></asp:Label></div></li>
<li class="address"><span>ที่ตั้ง : </span><div class="spec"><asp:Label ID="lbladdress" runat="server" Text="บ้านต้นยาง ต.วาวี อ.แม่สรวย  จ.เชียงราย"></asp:Label></div ></li>
<li class="address"><span>ประเภทสถานี :</span><div class="spec"><asp:Label ID="lblstntype" runat="server" Text="วัดปริมาณน้ำฝน และ วัดระดับน้ำท่า"></asp:Label></div></li>
</ul>

</li>
<li class="bottom"></li>
</ul>
</div>
</div>

</div>
   



</div>
</div>
</div>
</article>


 <script type="text/javascript">


     $(function () {
        
         $("#station-main").show();

         $("#sub-station li").click(function () {


             $("#station-head ul li.date-time").show();


             google.maps.event.trigger(map, 'resize');
             map.setCenter(currCenter);

         });

         var latlng = new google.maps.LatLng(document.getElementById("<%=me.lbllat.ClientID %>").innerHTML, document.getElementById("<%=me.lbllong.ClientID %>").innerHTML);
         var options = {
             zoom: 12, // This number can be set to define the initial zoom level of the map
             center: latlng,
             panControl: true,
             panControlOptions: {
                 position: google.maps.ControlPosition.TOP_LEFT
             },
             zoomControl: true,
             zoomControlOptions: {
                 style: google.maps.ZoomControlStyle.SMALL,
                 position: google.maps.ControlPosition.TOP_LEFT
             },
             scaleControl: false,
             scaleControlOptions: {
                 position: google.maps.ControlPosition.RIGHT_TOP
             },
             streetViewControl: false,
             streetViewControlOptions: {
                 position: google.maps.ControlPosition.LEFT_TOP
             },
             mapTypeId: google.maps.MapTypeId.ROADMAP // This value can be set to define the map type ROADMAP/SATELLITE/HYBRID/TERRAIN
         };
         // Calling the constructor, thereby initializing the map  
         var map = new google.maps.Map(document.getElementById('map-canvas2'), options);

         // Define Marker properties
         var image = new google.maps.MarkerImage('images/pin-01.png',
         // This marker is 129 pixels wide by 42 pixels tall.
		new google.maps.Size(28, 42),
         // The origin for this image is 0,0.
		new google.maps.Point(0, 0),
         // The anchor for this image is the base of the flagpole at 18,42.
		new google.maps.Point(18, 42)
	);

         // Add Marker
         var marker1 = new google.maps.Marker({
             position: latlng,
             map: map,
             icon: image // This path is the custom pin to be shown. Remove this line and the proceeding comma to use default pin
         });

         // Add listener for a click on the pin
         google.maps.event.addListener(marker1, 'click', function () {
             infowindow1.open(map, marker1);
         });

         // Add information window

         var infowindow1 = new google.maps.InfoWindow({
             content: createInfo('สถานี ' + document.getElementById("<%=me.lblHeader_stncode.ClientID %>").innerHTML + ' : ' + document.getElementById("<%=me.lblHeader_stnname.ClientID %>").innerHTML, document.getElementById("<%=me.lblHeader_address.ClientID %>").innerHTML)
         });

         // Create information window
         function createInfo(title, content) {
             return '<div class="infowindow"><div class="head"><strong>' + title + '</strong></div><div class="desc">' + content + '</div></div>';
         }
         var currCenter = map.getCenter();
         infowindow1.open(map, marker1);
     });

    </script>
    <script src="js/config.js" type="text/javascript"></script>
<script src="js/menu.js" type="text/javascript"></script>
<script src="js/jquery.mCustomScrollbar.js"></script>
<script src="js/jquery.easydropdown.js"></script>
<script type="text/javascript">
var storeInfo = [

        <%
        Dim gate1,gate2,gate3,gate4,gate5,gate6,gate7 as String

  For row As Integer = 0 to Session("wStation").GetUpperBound(0)
   Dim code as String = CStr(Session("wStation")(row,0))
   Dim name as String = Session("wStation")(row,1)
   Dim lat as String = CStr(Session("wStation")(row,9))
   Dim lng as String = CStr(Session("wStation")(row,10))
   Dim group_name as String = CStr(Session("wStation")(row,2))
   Dim water as String = CStr(Session("wStation")(row,4))
   Dim wl_up as String = CStr(Session("wStation")(row,4))
   Dim wl_down as String = CStr(Session("wStation")(row,5))
   Dim zerogauge as String = CStr(Session("wStation")(row,16))
   Dim rf15 as String = CStr(Session("wStation")(row,6))
   Dim rf7tonow as String = CStr(Session("wStation")(row,8))
   Dim rf7to7 as String = CStr(Session("wStation")(row,7))
   Dim stnID as String = CStr(Session("wStation")(row,0))
   Dim address as String = CStr(Session("wStation")(row,14))
   Dim province_id as String = CStr(Session("wStation")(row,13))
   Dim province_name as String = CStr(Session("wStation")(row,14))
	Dim group as string = CStr(Session("wStation")(row,3))
    Dim typestn as string = CStr(Session("wStation")(row,15))
    Dim basin_id as string = CStr(Session("wStation")(row,11))
    Dim basin_name as String = CStr(Session("wStation")(row,12))
    Dim station_code as String = CStr(Session("wStation")(row,26))
    Dim gatecount as Integer = Session("wStation")(row,17)
    Dim LinkUrl as String = CStr(Session("wStation")(row,25))
    if (gatecount = 1) Then
    gate1 = CStr(Session("wStation")(row,18))
    elseif (gatecount = 2) Then
    gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    elseif (gatecount = 3) Then
    gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    gate3 = CStr(Session("wStation")(row,20))
    elseif (gatecount = 4) Then
    gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    gate3 = CStr(Session("wStation")(row,20))
    gate4 = CStr(Session("wStation")(row,21))
    elseif (gatecount = 5) Then
 gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    gate3 = CStr(Session("wStation")(row,20))
    gate4 = CStr(Session("wStation")(row,21))
    gate5 = CStr(Session("wStation")(row,22))
    elseif (gatecount = 6) Then
    gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    gate3 = CStr(Session("wStation")(row,20))
    gate4 = CStr(Session("wStation")(row,21))
    gate5 = CStr(Session("wStation")(row,22))
    gate6 = CStr(Session("wStation")(row,23))
    elseif (gatecount = 7) Then
   gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    gate3 = CStr(Session("wStation")(row,20))
    gate4 = CStr(Session("wStation")(row,21))
    gate5 = CStr(Session("wStation")(row,22))
    gate6 = CStr(Session("wStation")(row,23))
    gate7 = CStr(Session("wStation")(row,24))
    end if
%>
  {    
                   code: "<% Response.Write(code) %>",
                   code_customer:"<% Response.Write(station_code) %>",
					name: "<% Response.Write(name) %>",
					 address: "<% Response.Write(name) %>",
					group: '<% Response.Write(group) %>',
					 group_name: "<% Response.Write(group_name) %>",
                     province_id:"<% Response.Write(province_id) %>",
                     province_name:"<% Response.Write(province_name) %>",
                     basin_id:"<% Response.Write(basin_id) %>",
                     basin_name:"<% Response.Write(basin_name) %>",
//					water: '<% Response.Write(water) %>',
                    water: '<% Response.Write(typestn) %>',
					rain: '<% Response.Write(rf15) %>',
                    rain7to7: '<% Response.Write(rf7to7) %>',
                    rain7tonow: '<% Response.Write(rf7tonow) %>',
					lat: '<% Response.Write(lat) %>',
                    long: '<% Response.Write(lng) %>',
                    gatecount: '<% Response.Write(gatecount) %>',
                    linkurl:"<% Response.Write(LinkUrl) %>",
	                water_level:
					{
					    value1: '<% Response.Write(wl_up) %>',
					    value2: '<% Response.Write(wl_down) %>',
					    value3: '<% Response.Write(zerogauge) %>'
					},
                    <% if gatecount = 1 Then%>
                    door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					}
                    ]
                    <% Elseif gatecount = 2 Then%>
                     door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}
                    ]
                    <% Elseif gatecount = 3 Then%>
                    door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}, {
					    value: '<% Response.Write(gate3) %>'
					}
                    ]
                    <% Elseif gatecount = 4 Then%>
                    door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}, {
					    value: '<% Response.Write(gate3) %>'
					}, {
					    value: '<% Response.Write(gate4) %>'
					}
					 ]
                    <% Elseif gatecount = 5 Then%>
                    door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}, {
					    value: '<% Response.Write(gate3) %>'
					}, {
					    value: '<% Response.Write(gate4) %>'
					}, {
					    value: '<% Response.Write(gate5) %>'
					}
					 ]
                     <% Elseif gatecount = 6 Then%>
                     door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}, {
					    value: '<% Response.Write(gate3) %>'
					}, {
					    value: '<% Response.Write(gate4) %>'
					}, {
					    value: '<% Response.Write(gate5) %>'
					}, {
					    value: '<% Response.Write(gate6) %>'
					}
					 ]
                     <% Elseif gatecount = 7 Then%>
                     door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}, {
					    value: '<% Response.Write(gate3) %>'
					}, {
					    value: '<% Response.Write(gate4) %>'
					}, {
					    value: '<% Response.Write(gate5) %>'
					}, {
					    value: '<% Response.Write(gate6) %>'
					}, {
					    value: '<% Response.Write(gate7) %>'
					}
					 ]
                       <% End If %>
  }<% If row < Session("wStation").GetUpperBound(0) Then Response.Write(",") %>
  <%
Next
%>
];

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

    function GotoChart() {
   
        window.location = 'PageChart.aspx?CODE=' + document.getElementById("<%=me.HiddenCodeNextPage.ClientID %>").value + '&index='+ document.getElementById("<%=me.HiddenIndex.ClientID %>").value;
        //href = "PageChart.aspx"
    }
    function GotoDetailStation() {
  
        window.location = 'DetailStation.aspx?CODE=' + document.getElementById("<%=me.HiddenCodeNextPage.ClientID %>").value + '&index='+ document.getElementById("<%=me.HiddenIndex.ClientID %>").value;
    }
    $(document).ready(function (e) {
        $("#menu-1").addClass('active');

    });	
  
</script>	

</asp:Content>

