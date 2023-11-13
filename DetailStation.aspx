<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="DetailStation.aspx.vb" Inherits="DetailStation" %>
<%@ Register  assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
  
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>         
                <div id="contents">
                    <div>
                        <div class="details">
                            <div id="station-detail">
                                <ul id="sub-station">
                                    <li class="active" data="station-main">
                                        <div class="txt">ข้อมูลรายสถานี</div>
                                    </li>
                                    <li  data="station-photo" onclick="GotoImageStation()">
                                        <div class="txt">ภาพถ่ายสถานี</div>
                                    </li>
                                    <li data="station-graph" onclick="GotoChart()">
                                        <div class="txt">กราฟแสดงข้อมูลรายสถานี</div>
                                    </li>
                                </ul>
                            </div>
                            <div id="station-head">
                                <ul>
                                    <li>
                                        <img src="images/pin-<% Response.Write(Session("wStation")(IIf(Request.QueryString("index") Is Nothing, "1", Request.QueryString("index"))-1,15)) %>.png" vspace="5"/>
                                    </li>
                                    <li>
                                        <div class="head">
                                            <span><asp:Label ID="lblHeader_stncode" runat="server" Text="สถานี G102"></asp:Label> :</span> 
                                            <asp:Label ID="lblHeader_stnname" runat="server" Text="น้ำแม่ลาว" ForeColor="#0099CC"></asp:Label>
                                        </div>
                                        <div class="address">
                                            <asp:Label ID="lblHeader_address" runat="server" Text="บ้านต้นยาง ต.วาวี อ.แม่สรวย  จ.เชียงราย"></asp:Label>
                                        </div>
                                    </li>
                                    <li class="date-time">
                                        <div class="date">ข้อมูลล่าสุด</div>
                                        <div class="time">
                                            <asp:Label ID="lblTimeupdate" runat="server" Text="วันเสาร์ที่ 6 ตุลาคม 2556 | 10.00 น."></asp:Label>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div id="station-main" class="data" style="display:block;">
                                <div style="position:relative">
                                    <div class="station-info">
                                    <div class="station-img">
                                        <div id="Stage" runat="server">
                                            
                                        </div>
                                    </div>
                                    <div id="station-data" style=" bottom:-10px; position:absolute; z-index:9898;">
                                        <div class="info-data">
                                            <ul>
                                                <li class="top"></li>
                                                <li class="center">
                                                    <div class="head"><img src="images/info-icon.png"  align="absmiddle" hspace="10"/>ข้อมลูสถานี</div>
                                                    <div class="info">
                                                        <ul class="data">
                                                            <li>&nbsp;<div>ม.รทก</div><div>ม.รสม.</div></li>
                                                            <li>ระดับตลิ่งขวา<asp:Label ID="lblLabelRightUp" runat="server" Text="เหนือน้ำ"></asp:Label><div class="value">
                                                                <asp:Label ID="lblRight_bank_up_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                                    <asp:Label ID="lblRight_bank_up" runat="server" Text="Label"></asp:Label></div></li>
                                                            <li>ระดับตลิ่งซ้าย<asp:Label ID="lblLabelLeftUp" runat="server" Text="เหนือน้ำ"></asp:Label><div class="value">
                                                                <asp:Label ID="lblLeft_bank_up_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                                    <asp:Label ID="lblLeft_bank_up" runat="server" Text="Label"></asp:Label></div></li> 
                                                            <li>เสาระดับ<asp:Label ID="lblLabelGageUp" runat="server" Text="เหนือน้ำ"></asp:Label><div class="value">
                                                                <asp:Label ID="lblZerogate_up_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                                    <asp:Label ID="lblZerogate_up" runat="server" Text="Label"></asp:Label></div></li> 
                                                            <li>ระดับเตือนภัย<div class="value">
                                                                <asp:Label ID="lblWarning_up_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                                    <asp:Label ID="lblWarning_up" runat="server" Text="Label"></asp:Label></div></li> 
                                                            <li>ระดับน้ำวิกฤติ<div class="value">
                                                                <asp:Label ID="lblCritical_up_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                                    <asp:Label ID="lblCritical_up" runat="server" Text="Label"></asp:Label></div></li> 
                                                        </ul>
                                                    </div>
                                                    <div class="info">
                                                        <ul class="data">
                                                            <li>&nbsp;<div>ม.รทก</div><div>ม.รสม.</div></li>
                                                            <li>ระดับตลิ่งขวา<asp:Label ID="lblLabelRightDown" runat="server" Text="ท้ายน้ำ"></asp:Label><div class="value">
                                                                <asp:Label ID="lblRight_bank_down_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                                    <asp:Label ID="lblRight_bank_down" runat="server" Text="Label"></asp:Label></div></li>
                                                            <li>ระดับตลิ่งซ้าย<asp:Label ID="lblLabelLeftDown" runat="server" Text="ท้ายน้ำ"></asp:Label><div class="value">
                                                                <asp:Label ID="lblLeft_bank_down_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                                    <asp:Label ID="lblLeft_bank_down" runat="server" Text="Label"></asp:Label></div></li> 
                                                            <li>เสาระดับ<asp:Label ID="lblLabelGageDown" runat="server" Text="ท้ายน้ำ"></asp:Label><div class="value">
                                                                <asp:Label ID="lblZerogate_down_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                                    <asp:Label ID="lblZerogate_down" runat="server" Text="Label"></asp:Label></div></li> 
                                                            <li>ระดับเตือนภัย<div class="value">
                                                                <asp:Label ID="lblWarning_down_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                                    <asp:Label ID="lblWarning_down" runat="server" Text="Label"></asp:Label></div></li> 
                                                            <li>ระดับน้ำวิกฤติ<div class="value">
                                                                <asp:Label ID="lblCritical_down_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                                    <asp:Label ID="lblCritical_down" runat="server" Text="Label"></asp:Label></div></li> 
                                                        </ul>
                                                    </div>
                                                </li>
                                                <li class="bottom" style="padding-right: 68px;">&nbsp;</li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                    <div class="station-info">
                                    <div class="info-data">
                                        <ul>
                                            <li class="top"></li>
                                            <li class="center" style="min-height:650px">
                                                <div class="head"><img src="images/rain-icon.png"  align="absmiddle" hspace="10"/>ปริมาณฝน</div>
                                                <ul class="data">
                                                    <li>ฝนราย 15 นาที<div>มม.</div><div class="value">
                                                        <asp:Label ID="lblRf15" runat="server" Text="Label"></asp:Label></div></li>
                                                    <li>ฝนสะสม 7.00 – ปัจจุบัน<div>มม.</div><div class="value">
                                                        <asp:Label ID="lblRf7toNow" runat="server" Text="Label"></asp:Label></div></li>
                                                    <li>ฝนสะสม 24 ชม.<div>มม.</div><div class="value">
                                                        <asp:Label ID="lblRf7to7" runat="server" Text="Label"></asp:Label></div></li>
                                                </ul>
                                                <div class="section2"></div>
                                                <div class="head"><img src="images/water-icon.png"  align="absmiddle" hspace="10"/>ระดับน้ำ</div>
                                                <ul class="data">
                                                    <li>&nbsp;<div>ม.รทก</div><div>ม.รสม.</div></li>
                                                    <li>ระดับ<asp:Label ID="lblLabelWlUp" runat="server" Text="เหนือน้ำ"></asp:Label><div class="value">
                                                        <asp:Label ID="lblWl_up_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                            <asp:Label ID="lblWl_up" runat="server" Text="Label"></asp:Label></div></li>
                                                    <li>ระดับ<asp:Label ID="lblLabelWlDown" runat="server" Text="ท้ายน้ำ"></asp:Label><div class="value">
                                                        <asp:Label ID="lblWl_down_msl" runat="server" Text="Label"></asp:Label></div><div class="value">
                                                            <asp:Label ID="lblWl_down" runat="server" Text="Label"></asp:Label></div></li>
                                                </ul>
                                                <div class="section2"></div>

                                                <div class="head" id="DoorsHd" runat="server"><img src="images/door-icon.png"  align="absmiddle" hspace="10"/>ระยะยกบานประตู</div>
                                                <ul class="data" id="Doors" runat="server">

                                                </ul>
                                                <div class="section2" id="DoorsFt" runat="server"></div>
                                                <div class="head"><img src="images/temp-icon.png"  align="absmiddle" hspace="10"/>สถานะอุปกรณ์สนาม</div>
                                                <ul class="data">
                                                    <li>สถานะประตู<div>
                                                        <asp:Label ID="lblDoor_status" runat="server" Text="Label"></asp:Label></div> </li>
                                                    <li>สถานะแรงดันก๊าซ<asp:Label ID="lblLabelAirUp" runat="server" Text="เหนือน้ำ"></asp:Label><div>
                                                        <asp:Label ID="lblAir_tank_up" runat="server" Text="Label"></asp:Label></div></li>
                                                    <li>สถานะแรงดันก๊าซ<asp:Label ID="lblLabelAirDown" runat="server" Text="ท้ายน้ำ"></asp:Label><div>
                                                        <asp:Label ID="lblAir_tank_down" runat="server" Text="Label"></asp:Label></div></li>
                                                    <li>อุณหภูมิภายในตู้<div>
                                                        <asp:Label ID="lblTemp_alarm" runat="server" Text="Label"></asp:Label></div> </li>
                                                    <li>แบตเตอร์รี่<div>
                                                        <asp:Label ID="lblBatt_level" runat="server" Text="Label"></asp:Label></div> </li>
                                                </ul>
                                            </li>
                                            <li class="bottom">
                                            </li>
                                        </ul>
                                    </div>
                                    </div>
                                </div>
                                <div  id="admin-report">
                                    <!--<div id="all-statation-data"   style=" text-align:center;margin:0 auto;padding:0;">-->
                                    <div id="adminreportin" runat="server" style="height:500px; overflow:auto;" visible="False">
                                        <asp:GridView ID="dgvDeatail" runat="server" 
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" AutoGenerateColumns="False" Height="500px" Width="945px" >
                                            <HeaderStyle BackColor="#0099CC" Font-Bold="True" ForeColor="White"  />
                                            
                                        </asp:GridView>
                                    </div>
                                    <!--</div>-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:HiddenField ID="HiddenCodeNextPage" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="HiddenIndex" runat="server"></asp:HiddenField>
    <script src="js/config.js" type="text/javascript"></script>
    <script src="js/menu.js" type="text/javascript"></script>
    <script src="js/jquery.mCustomScrollbar.js" type="text/javascript"></script>
    <script src="js/jquery.easydropdown.js" type="text/javascript"></script>
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
   
        window.location = 'PageChart.aspx?CODE='+ document.getElementById("<%=me.HiddenCodeNextPage.ClientID %>").value + '&index='+ document.getElementById("<%=me.HiddenIndex.ClientID %>").value;
        //href = "PageChart.aspx"
    }
    function GotoImageStation() {
  
        window.location = 'StationImage.aspx?CODE='+ document.getElementById("<%=me.HiddenCodeNextPage.ClientID %>").value + '&index='+ document.getElementById("<%=me.HiddenIndex.ClientID %>").value;
    }
    $(document).ready(function (e) {
        $("#menu-1").addClass('active');

    });	
    </script>
</asp:Content>

