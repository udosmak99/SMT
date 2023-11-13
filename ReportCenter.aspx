<%@ Page Title="" Language="VB" MasterPageFile="~/admin.master" AutoEventWireup="false" CodeFile="ReportCenter.aspx.vb" Inherits="ReportCenter" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DetailContent" Runat="Server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <div class="head "><img src="images/report-icon2.png" align="absmiddle"/><span>แบบรายงาน</span></div>

  <table cellpadding="5" cellspacing="0" >
<tr>
<td  class="group" align="right" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;"><img src="images/search-icon.png" align="absmiddle" /></td>
<td class="group" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">ค้นหาข้อมูล</td>
</tr>
<tr>
<td align="right" width="180" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">ประเภทกลุ่ม :</td>
<td style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">  
<asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">กลุ่ม</asp:ListItem>
                        <asp:ListItem Value="1">ศูนย์/โครงการ</asp:ListItem>
                        <asp:ListItem Value="2">ลุ่มน้ำ</asp:ListItem>
                        <asp:ListItem Value="3">จังหวัด</asp:ListItem>
                    </asp:DropDownList>
</td>
</tr>
<tr>
<asp:MultiView id="mtvGroup" runat="server" ActiveViewIndex="0" Visible="true">
                <asp:View id="View5" runat="server">
           
                <td align="right" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">                
                    <asp:Label ID="Label1" runat="server" Text="กลุ่ม :"></asp:Label>
                </td> 
                 <td style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">  
                    <asp:DropDownList ID="ddlGrouper" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>      
           
                </asp:View>
                <asp:View id="G0" runat="server">
           
                <td align="right" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">                
                    <asp:Label ID="Label7" runat="server" Text="ศูนย์/โครงการ :"></asp:Label>
                </td> 
                 <td style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">  
                    <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>      
           
                </asp:View> 
                <asp:View id="G1" runat="server">
         
                <td align="right" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">                  
                    <asp:Label ID="Label9" runat="server" Text="ลุ่มน้ำ :"></asp:Label>
                </td> 
                <td style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">  
                    <asp:DropDownList ID="ddlBasin" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>      
           
                </asp:View> 
                <asp:View id="View3" runat="server">
           
                <td align="right" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">                   
                    <asp:Label ID="Label11" runat="server" Text="จังหวัด :"></asp:Label>
                </td> 
                 <td style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">  
                    <asp:DropDownList ID="ddlProvice" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>      
            
                </asp:View> 
            </asp:MultiView> 
</tr>
<tr>
<td align="right" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">สถานี :</td>
<td style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;"><asp:DropDownList ID="ddlStn" runat="server" AutoPostBack="True"></asp:DropDownList>
</td>
</tr>
<tr>
<td align="right" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">ประเภทรายงาน :</td>
<td style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;"><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True">
                         <asp:ListItem Value="1">ปริมาณน้ำฝน</asp:ListItem>
                         <asp:ListItem Value="2">ระดับน้ำ</asp:ListItem>
                   </asp:DropDownList> 
</td>
</tr>
<tr>
<td align="right" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">รายงาน :</td>
<td style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;"> <asp:DropDownList ID="ddlCondition" runat="server" AutoPostBack="True">
                          <asp:ListItem Value="1">ราย 15 นาที</asp:ListItem>
                          <asp:ListItem Value="2">รายชั่วโมง</asp:ListItem>
                          <asp:ListItem Value="3">รายวัน</asp:ListItem>
                    </asp:DropDownList>  
</td>
</tr>
<tr>
<td align="right" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;">วันที่ :</td>
<td style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;"><div id="admin-content-table"><asp:MultiView id="mtvMain" runat="server" ActiveViewIndex="0" Visible="true">
            <div style ="width:170px; height:139px;"><asp:View id="View0" runat="server">           
                <asp:TextBox ID="txtDay" runat="server" MaxLength="10" 
                    style="text-align:center;" Width="80px"></asp:TextBox>
                <asp:MaskedEditExtender ID="TxtDtmStart_MaskedEditExtender" runat="server" 
                    AutoComplete="False" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                    Mask="99/99/9999" MaskType="Number" TargetControlID="txtDay"></asp:MaskedEditExtender>
                <asp:CalendarExtender ID="TxtDtmStart_CalendarExtender" runat="server"
                    Format="dd/MM/yyyy" PopupButtonID="BtnDay" TargetControlID="txtDay" ></asp:CalendarExtender>&nbsp;
                <asp:ImageButton ID="BtnDay" runat="server" ImageUrl="~/Calendar.png" 
                    ImageAlign="AbsMiddle"/>                               
            </asp:View></div>
            <div style ="width:170px; height:139px;"><asp:View id="View1" runat="server">
                <asp:TextBox ID="txtMonth" runat="server" MaxLength="10" 
                    style="text-align:center;" Width="80px"></asp:TextBox>
                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                    AutoComplete="False" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat=""  
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                    Mask="99/9999" MaskType="Number" TargetControlID="txtMonth"></asp:MaskedEditExtender>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/yyyy" 
                    PopupButtonID="btnMonth" TargetControlID="txtMonth"></asp:CalendarExtender>&nbsp;
                <asp:ImageButton ID="btnMonth" runat="server" ImageUrl="~/Calendar.png" 
                    ImageAlign="AbsMiddle"/>
            </asp:View></div> 
            <div style ="width:170px; height:139px;"><asp:View id="View2" runat="server">
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
            </asp:View></div>
            </asp:MultiView> 
</div></td>
</tr>
<tr class="submit">
<td align="right" style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;"> </td>
<td style="border-bottom:1px dotted #ccc;padding:10px 5px; vertical-align:top;"><%--<button type="submit" class="iButton blue">ดูข้อมูล</button>--%> 
<asp:Button ID="btnShow" runat="server" Text="ดูข้อมูล" class="iButton blue"/></td> 
</tr>
</table> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FootContent" Runat="Server">
    <div style ="overflow:scroll; width:920px;">
<CR:CrystalReportViewer ID="CryReport" runat="server" AutoDataBind="false" ForeColor="Black"
        Width="500px" ToolPanelView="None" BackColor="#ffffcc"></CR:CrystalReportViewer>
</div>

</asp:Content>

