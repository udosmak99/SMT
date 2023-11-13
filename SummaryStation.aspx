<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="SummaryStation.aspx.vb" Inherits="SummaryStation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="js/jquery.js" type="text/javascript"></script>
<script src="js/jsrender.js" type="text/javascript"></script>
<script type="text/javascript" src="js/jquery.totemticker.js"></script>
<%--<link href="css/reset.css" rel="stylesheet" type="text/css" />--%>
<link href="css/all_station.css" rel="stylesheet" type="text/css" />
<link href="css/jquery.mCustomScrollbar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 
 <article>
 <div id="contents" >
<div>
 <div class="details">
 
<div class="top-all"></div>
<div id="all-statation-data" class="center-all">
<div class="section bg-section" style ="margin-left: 20px;">      <%--พื่นที่ชื่อกลุ่ม--%>
<div class="under-head">
<span class="group"><asp:Label ID="lblGB" runat="server"></asp:Label>
</span><span class="name"><asp:Label ID="lblName" runat="server"></asp:Label>
</span>
<div>ข้อมูลทั้งหมด <asp:Label ID="lblNum" runat="server"></asp:Label> รายการ</div>
</div><div>
<ul class="head"><li>
<div class="name" style="height:60px; width:40px;padding-bottom: 0px;">ลำดับ</div>
<div style="height:60px; width:68px;padding-bottom: 0px;">รหัสสถานี</div>
<div style="height:60px; width:212px;padding-bottom: 0px;">ชื่อสถานี</div>
<div style="height:60px; width:64px;padding-bottom: 0px;">ปริมาณฝน (มม.)</div>
<div style="height:60px; width:98px;padding-bottom: 0px;">ระดับน้ำ     เหนือน้ำ ม.(รทก.)</div>
<div style="height:60px; width:89px;padding-bottom: 0px;">ระดับน้ำ ท้ายน้ำ    ม.(รทก.)</div>
<div style="height:60px; width:80px;padding-bottom: 0px;">สถานะเชื่อมต่อ</div>
<div style="height:60px; width:143px;padding-bottom: 0px;">ข้อมูลล่าสุด ณ เวลา</div>
</li>
</ul></div>
</div>
<div style ="width :920; margin-left: 20px;overflow:scroll;height:400px;"> <%--
<div style ="width :920; margin-left: 20px; overflow-scroll: touch; height:400px;"> --%>
<%--<asp:Panel id="pan1" runat="server" width="940px" style="margin-left :20px;" Height ="400px" ScrollBars="Auto">--%>

<asp:GridView ID="grvlastData" runat="server" AutoGenerateColumns="False" 
                       ShowHeader="False" Width="920px" BorderColor="White" 
        BorderStyle="solid" BorderWidth="2px"  Height="400px">                                                     
                        <HeaderStyle Font-Bold="False" />
                        <RowStyle Height="48px" BackColor="#FFFFFF" BorderColor="white" BorderStyle="solid" BorderWidth="5px"/>
                        <AlternatingRowStyle Height="48px" BackColor="#f4f4f4"/>
                        <Columns>
                            <asp:TemplateField HeaderText="ลำดับ" SortExpression="name">
                                <HeaderTemplate>
                                    <table border= 0 cellspacing=0px>
                                        <tr height=42 >
                                            <td bgcolor="#10b9f0" width="49px" valign=top style="padding-top:7px">ลำดับ</td>
                                        </tr>
                                     </table>                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNum" runat="server" Text='<%# Bind("i") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle ForeColor="White" />
                                <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="รหัสสถานี" SortExpression="name">
                                <HeaderTemplate>
                                    <table border= 0 cellspacing=0px>
                                        <tr height=42 >
                                            <td bgcolor="#10b9f0" width="80px" valign=top style="padding-top:7px">รหัสสถานี</td>
                                        </tr>
                                     </table>                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblcode" runat="server" Text='<%# Bind("station_id_customer") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle ForeColor="White"  />
                                <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อสถานี" SortExpression="name">
                                <HeaderTemplate>
                                    <table border= 0  cellspacing=0>
                                        <tr height=42 >
                                            <td  bgcolor="#10b9f0" width="230px" valign=top style="padding-top:7px">ชื่อสถานี</td>
                                        </tr>
                                     </table>                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblname" runat="server" Text='<%# Bind("station_name") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle ForeColor="White" BorderColor="White" BorderStyle="Solid"/>
                                <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" HorizontalAlign="Left" width="230px" />                        
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ปริมาณฝน           (มม.)" SortExpression="name">
                                <HeaderTemplate>
                                    <table border= 0  cellspacing=0>
                                        <tr height=42 >
                                           <td bgcolor="#10b9f0" width="78px" valign=top style="padding-top:7px">ปริมาณฝน<br/>(มม.)</td>
                                        </tr>
                                     </table>                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblrf" runat="server" Text='<%# Bind("rf15") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle ForeColor="White" BorderColor="White" BorderStyle="Solid"/>
                                <ItemStyle  BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" HorizontalAlign="right" width="78px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ระดับน้ำ เหนือน้ำ ม.(รทก.)" 
                                SortExpression="name">
                                <HeaderTemplate>
                                    <table border= 0  cellspacing=0>
                                        <tr height=42 >
                                           <td bgcolor="#10b9f0" width="113px" valign=top style="padding-top:7px">  ระดับน้ำ เหนือน้ำ <br/>ม.(รทก.)</td>
                                        </tr>
                                     </table>                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblwl_up" runat="server" Text='<%# Bind("wl_up") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle ForeColor="White" BorderColor="White" BorderStyle="Solid"/>
                                <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" HorizontalAlign="right" width="113px"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ระดับน้ำ ท้ายน้ำ      ม.(รทก.)" SortExpression="name">
                                <HeaderTemplate>
                                <table border= 0  cellspacing=0>
                                        <tr height=42 >
                                           <td  bgcolor="10b9f0" width="103px" valign=top style="padding-top:7px">ระดับน้ำ ท้ายน้ำ <br/>ม.(รทก.)</td>
                                        </tr>
                                     </table>                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblwl_down" runat="server" Text='<%# Bind("wl_down") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle ForeColor="White" BorderColor="White" BorderStyle="Solid"/>
                                <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" HorizontalAlign="right" 
                                    width="103px" />   
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สถานะการเชื่อมต่อ" SortExpression="name">                                
                                <HeaderTemplate>
                                <table border= 0  cellspacing=0>
                                        <tr height="42" >
                                           <td bgcolor="#10b9f0" width="93px" valign=top style="padding-top:6px">สถานะการเชื่อมต่อ<br/></td>
                                        </tr>
                                     </table>                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("conn_status_up") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle ForeColor="White" BorderColor="White" BorderStyle="Solid"/>
                                <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" HorizontalAlign="center" 
                                    width="93px"  />   
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ข้อมูลล่าสุด">
                                <HeaderTemplate>
                                <table border= 0  cellspacing=0>
                                        <tr height=42 >
                                           <td bgcolor="#10b9f0" width="158px" valign=top style="padding-top:7px">
                                              ข้อมูลล่าสุด </td>
                                        </tr>
                                     </table>                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbldate" runat="server" Text='<%# Bind("server_time_up") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle ForeColor="White" BorderColor="White" BorderStyle="Solid"/>
                                <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" HorizontalAlign="center" 
                                    width="158px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
<%-- </asp:Panel> --%>
</div>
</div>
<div class="bottom-all"></div>
 

</div>
</div>
</article >
<script type="text/javascript">

    var storeInfo = [

        <% Dim gate1,gate2,gate3,gate4,gate5,gate6,gate7 as String

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

    </script>
<script src="js/config.js" type="text/javascript"></script>
<script src="js/menuallstation.js" type="text/javascript"></script>
<script src="js/jquery.easydropdown.js"></script>
<script src="js/jquery.mCustomScrollbar.js"></script>	
<script type="text/javascript">
    $(document).ready(function (e) {
        $("#menu-2").addClass('active');

    });	
</script> 

</div>

</div>

</asp:Content>

