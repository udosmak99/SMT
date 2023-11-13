<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="admin_report_center.aspx.vb" Inherits="admin_report_center" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/jsrender.js" type="text/javascript"></script>
<script type="text/javascript" src="js/jquery.totemticker.js"></script>
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?v=3&amp;language=th-TH&amp;sensor=false"></script>
<script type="text/javascript" src="js/infobox.js"></script>
<link href="css/admin.css" rel="stylesheet" type="text/css" />
<%--<link href="css/menu.css" rel="stylesheet" type="text/css" />--%>
<link rel="stylesheet" type="text/css" href="css/easydropdown.css"/>
<link href="css/jquery.mCustomScrollbar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div id="alpha"></div>
<article >
<div id="contents" >
<div id="m-station">
<div id="menu-station">
<ul>
<li class="top" style="padding:15px;">
<div class="input-search" >
<input type="text" placeholder="ใส่รายชื่อสถานี" id="search-station"/>
</div>
<div id="arrow-up" class="arr-button" style="margin-top:15px;"></div>
<ul id="station-menu">
</ul>
<div id="arrow-down" class="arr-button"></div>
<div id="speed">( ความเร็วในการค้นหาข้อมูล 0.7125 วินาที )</div>
</li>
<li class="bottom">
<div id="close-icon"> ปิดรายการสถานี  <img src="images/close.png" align="absmiddle"/></div>
</li>
</ul>
</div>
</div>
 
<div class="details">
<form>
<div id="all-statation-data" style="text-align:left; margin:0 auto;width:960px;"  >
<div class="col-admin" style="text-align:left;" >
<div class="head-menu-admin ">เมนูผู้ดูแลระบบ
<div id="menu-admin"></div>
</div>
</div>

<div class="col-admin" id="admin-content">
<div class="head "><img src="images/report-icon2.png" align="absmiddle"/><span>ตามศูนย์/โครงการ : ตารางและกราฟแสดงระดับน้ำ รายชั่วโมง รายวัน รายเดือน รายปี</span></div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Panel ID="Pnl" runat="server" >
<table cellpadding="5" cellspacing="0"  >
<tr>
<td  class="group" align="right" ><img src="images/search-icon.png" align="absmiddle" /></td>
<td class="group">ค้นหาข้อมูล</td>
</tr>
<tr>
<td align="right" width="180">ประเภทกลุ่ม :</td>
<td>  <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="1">ศูนย์/โครงการ</asp:ListItem>
                        <asp:ListItem Value="2">ลุ่มน้ำ</asp:ListItem>
                        <asp:ListItem Value="3">จังหวัด</asp:ListItem>
                    </asp:DropDownList>
</td>
</tr>
<tr>
         <asp:MultiView id="mtvGroup" runat="server" ActiveViewIndex="0" Visible="true">
                <asp:View id="G0" runat="server">
            <tr>
                <td align="right">                
                    <asp:Label ID="Label7" runat="server" Text="ศูนย์/โครงการ :"></asp:Label>
                </td> 
                 <td>  
                    <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>      
            </tr>
                </asp:View> 
                <asp:View id="G1" runat="server">
                <tr>
                <td align="right">                  
                    <asp:Label ID="Label9" runat="server" Text="ลุ่มน้ำ :"></asp:Label>
                </td> 
                <td>  
                    <asp:DropDownList ID="ddlBasin" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>      
            </tr>
                </asp:View> 
                <asp:View id="View3" runat="server">
            <tr>
                <td align="right">                   
                    <asp:Label ID="Label11" runat="server" Text="จังหวัด :"></asp:Label>
                </td> 
                 <td>  
                    <asp:DropDownList ID="ddlProvice" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>      
            </tr>
                </asp:View> 
            </asp:MultiView> 
</tr>
<tr>
<td align="right">สถานี :</td>
<td><asp:DropDownList ID="ddlStn" runat="server" AutoPostBack="True"></asp:DropDownList>
</td>
</tr>
<tr>
<td align="right">ประเภทรายงาน :</td>
<td><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True">
                         <asp:ListItem Value="1">ปริมาณน้ำฝน</asp:ListItem>
                         <asp:ListItem Value="2">ระดับน้ำ</asp:ListItem>
                   </asp:DropDownList> 
</td>
</tr>
<tr>
<td align="right">รายงาน :</td>
<td> <asp:DropDownList ID="ddlCondition" runat="server" AutoPostBack="True">
                          <asp:ListItem Value="1">ราย 15 นาที</asp:ListItem>
                          <asp:ListItem Value="2">รายชั่วโมง</asp:ListItem>
                          <asp:ListItem Value="3">รายวัน</asp:ListItem>
                    </asp:DropDownList>  
</td>
</tr>
<tr>
<td align="right">วันที่ :</td>
<td><asp:MultiView id="mtvMain" runat="server" ActiveViewIndex="0" Visible="true">
            <asp:View id="View0" runat="server">
                <asp:TextBox ID="txtDay" runat="server" MaxLength="10" 
                    style="text-align:center;" Width="80px"></asp:TextBox>
                <asp:MaskedEditExtender ID="TxtDtmStart_MaskedEditExtender" runat="server" 
                    AutoComplete="False" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                    Mask="99/99/9999" MaskType="Number" TargetControlID="txtDay"></asp:MaskedEditExtender>
                <asp:CalendarExtender ID="TxtDtmStart_CalendarExtender" runat="server"
                    Format="dd/MM/yyyy" PopupButtonID="BtnDay" TargetControlID="txtDay"></asp:CalendarExtender>&nbsp;
                <asp:ImageButton ID="BtnDay" runat="server" ImageUrl="~/Calendar.png" 
                    ImageAlign="AbsMiddle"/>                     
            </asp:View>
            <asp:View id="View1" runat="server">
                <asp:TextBox ID="txtMonth" runat="server" MaxLength="10" 
                    style="text-align:center;" Width="80px"></asp:TextBox>
                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                    AutoComplete="False" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                    Mask="99/9999" MaskType="Number" TargetControlID="txtMonth">
                </asp:MaskedEditExtender>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/yyyy" 
                    PopupButtonID="btnMonth" TargetControlID="txtMonth" ></asp:CalendarExtender>&nbsp;
                <asp:ImageButton ID="btnMonth" runat="server" ImageUrl="~/Calendar.png" 
                    ImageAlign="AbsMiddle"/>
            </asp:View>
            <asp:View id="View2" runat="server">
                <asp:TextBox ID="txtYear" runat="server"  MaxLength="10" 
                    style="text-align:center;" Width="80px"></asp:TextBox>
                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                    AutoComplete="False" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                    Mask="9999" MaskType="Number" TargetControlID="txtYear"></asp:MaskedEditExtender>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy" 
                    PopupButtonID="btnYear" TargetControlID="txtYear"></asp:CalendarExtender>&nbsp;
                <asp:ImageButton ID="btnYear" runat="server" ImageUrl="~/Calendar.png" 
                    ImageAlign="AbsMiddle"/>
            </asp:View>
            </asp:MultiView> 
</td>
</tr>
<%--<tr>
<td align="right">เดือน :</td>
<td><select><option>มกราคม</option></select></td>
</tr>
<tr>
<td align="right"> </td>
<td ><labeL><input checked type="radio" name="report"/>&nbsp;&nbsp;แบบตาราง </labeL>&nbsp;&nbsp;&nbsp;&nbsp;<label> <input  type="radio" name="report"/>&nbsp;&nbsp;แบบกราฟ</label>&nbsp;&nbsp;&nbsp;&nbsp;<label> <input  type="radio" name="report"/>&nbsp;&nbsp;แบบรายงาน</label></td>
</tr>--%>
<tr class="submit">
<td align="right"> </td>
<td  ><%--<button type="submit" class="iButton blue">ดูข้อมูล</button>--%> <asp:Button ID="btnShow" runat="server" Text="ดูข้อมูล" class="iButton blue"/></td> 
</tr>
</table> 

</div>
<div style ="width:500px; border-bottom-width :thin ; ">
<CR:CrystalReportViewer ID="CryReport" runat="server" AutoDataBind="false" ForeColor="Black"
        Width="500px" ToolPanelView="None" BackColor="#ffffcc"></CR:CrystalReportViewer>
</div>
</asp:Panel>
    </ContentTemplate> 
</asp:UpdatePanel>
</div>
</form> 
</div>



</div>
</article>
 
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
<script src="js/menu.js" type="text/javascript"></script>
<%--<script src="js/menuallstation.js" type="text/javascript"></script>--%>
<script src="js/jquery.easydropdown.js"></script>
<script src="js/jquery.mCustomScrollbar.js"></script>	
<script type="text/javascript">
    $(document).ready(function (e) {
        $("#menu-4").addClass('active');
        $('#admin-menu3 li:nth-child(1)').addClass('active');
    });	
</script> 
</asp:Content>

