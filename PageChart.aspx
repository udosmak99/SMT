<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PageChart.aspx.vb" Inherits="PageChart" %>
<%@ Register  assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


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

<div class="details">
<div id="station-detail">
<ul id="sub-station"><li data="station-main" onclick="GotoDetailStation()"><div class="txt">ข้อมูลรายสถานี</div></li><li   data="station-photo" onclick="GotoImageStation()"><div class="txt">ภาพถ่ายสถานี</div></li><li class="active" data="station-graph"><div class="txt">กราฟแสดงข้อมูลรายสถานี</div></li></ul>
</div>
<asp:HiddenField ID="HiddenCodeNextPage" runat="server"></asp:HiddenField>
<asp:HiddenField ID="HiddenIndex" runat="server"></asp:HiddenField>
<div id="station-head">
<ul><li><img src="images/pin-<% Response.Write(Session("wStation")(Request.QueryString("index")-1,15)) %>.png" vspace="5"/></li><li><div class="head"><span><asp:Label ID="lblHeader_stncode" runat="server" Text="สถานี G102"></asp:Label> :</span> <asp:Label ID="lblHeader_stnname" runat="server" Text="น้ำแม่ลาว" ForeColor="#0099CC"></asp:Label></div><div class="address"><asp:Label ID="lblHeader_address" runat="server" Text="บ้านต้นยาง ต.วาวี อ.แม่สรวย  จ.เชียงราย"></asp:Label></div></li>
<li class="select-time"><div><asp:Button ID="BtnShowGraph" runat="server" style="margin-left:9px;" CssClass="iButton blue" Text="แสดงข้อมูล" /></div></li><li class="select-time">

  <div style=" margin-top:-10px;">  
  
                 <asp:UpdatePanel ID="UpdatePanelCalendar1" runat="server">
   <ContentTemplate>
                 เริ่มวันที่           
    <asp:TextBox ID="TxtDtmStart" runat="server" MaxLength="10" 
                                                                    style="text-align:center;" Width="80px"></asp:TextBox>
                                                                <ajax:MaskedEditExtender ID="TxtDtmStart_MaskedEditExtender" runat="server" 
                                                                    AutoComplete="False" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                                                    Mask="99/99/9999" MaskType="Number" TargetControlID="TxtDtmStart">
                </ajax:MaskedEditExtender>
                                                                <ajax:CalendarExtender ID="TxtDtmStart_CalendarExtender" runat="server" 
                                                                    Format="dd/MM/yyyy" PopupButtonID="BtnDtmStart" TargetControlID="TxtDtmStart">
                </ajax:CalendarExtender>
                                                                &nbsp;
                                                            
                                                                <asp:ImageButton ID="BtnDtmStart" runat="server" align="absmiddle" 
                                                                    alt="ปฏิทินเริ่มวันที่" ImageUrl="~/images/calendar_icon.gif" 
                                                                    title="เลือกเริ่มวันที่" />
                                                            
                                                            
                                                                <asp:TextBox ID="txtHourEnd" runat="server" MaxLength="5" 
                                                                    style="margin-left: 5px" Width="80px"></asp:TextBox>
                                                                <ajax:MaskedEditExtender ID="txtHourEnd__MaskedEditExtender" runat="server" 
                                                                    AutoComplete="False" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                                                    Mask="99:99" MaskType="Number" TargetControlID="txtHourEnd">
                </ajax:MaskedEditExtender>
          </ContentTemplate>
            <Triggers>
        <asp:AsyncPostBackTrigger ControlID="BtnDtmStart" EventName="Click" />
     
            </Triggers>
</asp:UpdatePanel>

                                                           </div>
  <div style=" margin-top:0px;">  <asp:UpdatePanel ID="UpdatePanelCalendar2" runat="server" >
   <ContentTemplate>
 ถึงวันที่  
              
                                                                <asp:TextBox ID="TxtDtmEnd" runat="server" MaxLength="10" 
                                                                    style="text-align:center;" Width="80px"></asp:TextBox>
                                                                <ajax:MaskedEditExtender ID="TxtDtmEnd_MaskedEditExtender" runat="server" 
                                                                    AutoComplete="False" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                                                    Mask="99/99/9999" MaskType="Number" TargetControlID="TxtDtmEnd">
                </ajax:MaskedEditExtender>
                                                                <ajax:CalendarExtender ID="TxtDtmEnd_CalendarExtender" runat="server" 
                                                                    Format="dd/MM/yyyy" PopupButtonID="BtnDtmEnd" TargetControlID="TxtDtmEnd">
                </ajax:CalendarExtender>
                                                            
                                                            &nbsp;
                                                                <asp:ImageButton ID="BtnDtmEnd" runat="server" align="absmiddle" 
                                                                    alt="ปฏิทินถึงวันที่" ImageUrl="~/images/calendar_icon.gif" 
                                                                    title="เลือกถึงวันที่" />
                                                            
                                                           
                                                                <asp:TextBox ID="txtHourStart" runat="server" MaxLength="5" 
                                                                    style="margin-left: 5px" Width="80px"></asp:TextBox>
                                                                <ajax:MaskedEditExtender ID="txtHourStart_MaskedEditExtender" runat="server" 
                                                                    AutoComplete="False" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                                                    Mask="99:99" MaskType="Number" TargetControlID="txtHourStart">
                </ajax:MaskedEditExtender> 
          </ContentTemplate>
               <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnDtmEnd" EventName="Click"/>
            
            </Triggers>
</asp:UpdatePanel>
                                                            </div>
                                                            
</li>
</ul>

</div>

<div id="station-graph" class="data">
<asp:UpdatePanel ID="UpdatePanelpnlConfirm" runat="server" UpdateMode="Conditional">
   <ContentTemplate>
<div class="graph-head"><img src="images/rain-icon.png"  align="absmiddle" hspace="10"/>กราฟแสดงข้อมูลปริมาณฝนย้อนหลัง</div>
<div class="date"><asp:Label ID="lblRainGraphDate" runat="server" Text="ข้อมูลวันที่ 19/10/2556 เวลา 7.00 น. ถึง 20/10/2556 เวลา 7.00 น."></asp:Label></div>
<asp:Chart ID="Chart1" runat="server" Height="390px" Width="920px">
                    <Series>
                        <asp:Series Name="Rainfall">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderDashStyle="Dash">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                    <br />
                    <br />
                    <div align="center" >
                    <div class="graph-head"><img src="images/water-icon.png"  align="absmiddle" hspace="10"/>กราฟแสดงข้อมูลระดับน้ำย้อนหลัง</div>
                    <div class="date"><asp:Label ID="lblWaterLevelGraphDate" runat="server" Text="ข้อมูลวันที่ 19/10/2556 เวลา 7.00 น. ถึง 20/10/2556 เวลา 7.00 น."></asp:Label></div>
                    <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="ChkWlScale" runat="server" 
                            Text="กำหนดค่าสูงสุดต่ำสุดระดับน้ำ" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="ค่าต่ำสุด"></asp:Label>
&nbsp;<asp:TextBox ID="txtMinWl" runat="server" Width="53px" style=" text-align:right;">0.0</asp:TextBox>
                    &nbsp;ม.รทก.&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="ค่าสูงสุด"></asp:Label>
&nbsp;<asp:TextBox ID="txtMaxWl" runat="server" Width="53px" style=" text-align:right;" >0.0</asp:TextBox>
                        &nbsp;ม.รทก.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; </div>
                    <br />
                <asp:Chart ID="Chart2" runat="server" Height="450px" Width="920px">
                    <Series>
                        <asp:Series Name="WaterLevel_Up" Legend="WaterLevel_Up">
                        </asp:Series>
                        <asp:Series Name="WaterLevel_Down" Legend="WaterLevel_Down">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderDashStyle="Dash">
                        </asp:ChartArea>
                    </ChartAreas>
                 
                </asp:Chart>
                    <br />
                    <br />
                    <br />
                    
                  <asp:Panel ID="pnlConfirm" runat="server" CssClass="panelbox" 
        style="display:none;" Width="176px">
      
        <asp:Label ID="lblalert" runat="server"></asp:Label><br />
        <br />
        <div style="text-align: center">
            <asp:ImageButton ID="ButtonOK" runat="server" 
                ImageUrl="images/DTS_SA_Choose_OK.png" />
            <asp:ImageButton ID="btnvisible" runat="server" Visible="false" />
        </div>
    </asp:Panel>
    <ajax:ModalPopupExtender ID="ModalPopupExtenderGraph" runat="server" 
        PopupControlID="pnlConfirm" 
        CancelControlID="ButtonOK" 
        TargetControlID="btnvisible"
        BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
     <ajax:ConfirmButtonExtender ID="ConfirmButtonExtenderGraph" runat="server" DisplayModalPopupID="ModalPopupExtenderGraph" TargetControlID="btnvisible">
    </ajax:ConfirmButtonExtender>
    </ContentTemplate>
             <Triggers>
 <asp:AsyncPostBackTrigger ControlID="BtnShowGraph" EventName="Click" />
 </Triggers>
</asp:UpdatePanel>

</div>
          
</div>

</div>

</div>
</article>


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


    function GotoDetailStation() {
   
        window.location = 'DetailStation.aspx?CODE=' + document.getElementById("<%=me.HiddenCodeNextPage.ClientID %>").value + '&index='+ document.getElementById("<%=me.HiddenIndex.ClientID %>").value;
    }
    function GotoImageStation() {
    
        window.location = 'StationImage.aspx?CODE=' + document.getElementById("<%=me.HiddenCodeNextPage.ClientID %>").value + '&index='+ document.getElementById("<%=me.HiddenIndex.ClientID %>").value;
    }
         
    $(document).ready(function (e) {
        $("#menu-1").addClass('active');

    });	
</script>	

</asp:Content>

