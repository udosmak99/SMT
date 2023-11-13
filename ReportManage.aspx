<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReportManage.aspx.vb" Inherits="ReportManage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:scriptmanager runat="server"></asp:scriptmanager>
        <table width = "800px"  >
            <tr>
                <td width = "200px">                
                    <asp:Label ID="Label5" runat="server" Text="ประเภทกลุ่ม :"></asp:Label>
                &nbsp;
                    </td> 
                <td width = "600px">
                    <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="1">ศูนย์/โครงการ</asp:ListItem>
                        <asp:ListItem Value="2">ลุ่มน้ำ</asp:ListItem>
                        <asp:ListItem Value="3">จังหวัด</asp:ListItem>
                    </asp:DropDownList>
                </td>               
            </tr>
            <asp:MultiView id="mtvGroup" runat="server" ActiveViewIndex="0" Visible="true">
                <asp:View id="G0" runat="server">
            <tr>
                <td>                
                    <asp:Label ID="Label7" runat="server" Text="ศูนย์/โครงการ :"></asp:Label>
                </td> 
                 <td>  
                    <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="True" Height="22px"></asp:DropDownList>
                </td>      
            </tr>
                </asp:View> 
                <asp:View id="G1" runat="server">
                <tr>
                <td>                  
                    <asp:Label ID="Label9" runat="server" Text="ลุ่มน้ำ :"></asp:Label>
                </td> 
                <td>  
                    <asp:DropDownList ID="ddlBasin" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>      
            </tr>
                </asp:View> 
                <asp:View id="View3" runat="server">
            <tr>
                <td>                  
                    <asp:Label ID="Label11" runat="server" Text="จังหวัด :"></asp:Label>
                </td> 
                 <td>  
                    <asp:DropDownList ID="ddlProvice" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>      
            </tr>
                </asp:View> 
            </asp:MultiView> 
              
            <tr>
                <td>                 
                    <asp:Label ID="Label1" runat="server" Text="เลือกสถานี :"></asp:Label>
                </td> 
                <td>
                    <asp:DropDownList ID="ddlStn" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>      
            </tr>
             <tr>
                <td>                
                    <asp:Label ID="Label3" runat="server" Text="เลือกประเภทรายงาน :"></asp:Label>
                </td> 
                <td>
                     <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True">
                         <asp:ListItem Value="1">ปริมาณน้ำฝน</asp:ListItem>
                         <asp:ListItem Value="2">ระดับน้ำ</asp:ListItem>
                         <%--<asp:ListItem Value="3">ปริมาณน้ำ</asp:ListItem>--%>
                     </asp:DropDownList>                
                </td>     
            </tr>
            <tr>
                <td>                
                    <asp:Label ID="Label2" runat="server" Text="เลือกเงื่อนไข :"></asp:Label>                
                </td>
                <td>            
                    <asp:DropDownList ID="ddlCondition" runat="server" AutoPostBack="True">
                          <asp:ListItem Value="1">ราย 15 นาที</asp:ListItem>
                          <asp:ListItem Value="2">รายชั่วโมง</asp:ListItem>
                          <asp:ListItem Value="3">รายวัน</asp:ListItem>
                    </asp:DropDownList>                                 
                </td>
            </tr>
             <tr>
                <td>                
                    <asp:Label ID="Label4" runat="server" Text="วันที่ :"></asp:Label>                    
                </td> 
                <td>
            <asp:MultiView id="mtvMain" runat="server" ActiveViewIndex="0" Visible="true">
            <asp:View id="View0" runat="server">
                <asp:TextBox ID="txtDay" runat="server" AutoPostBack="True" MaxLength="10" 
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
                <asp:TextBox ID="txtMonth" runat="server" AutoPostBack="True" MaxLength="10" 
                    style="text-align:center;" Width="80px"></asp:TextBox>
                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                    AutoComplete="False" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                    Mask="99/9999" MaskType="Number" TargetControlID="txtMonth">
                </asp:MaskedEditExtender>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/yyyy" 
                    PopupButtonID="btnMonth" TargetControlID="txtMonth"> </asp:CalendarExtender>&nbsp;
                <asp:ImageButton ID="btnMonth" runat="server" ImageUrl="~/Calendar.png" 
                    ImageAlign="AbsMiddle"/>
            </asp:View>

            <asp:View id="View2" runat="server">
                <asp:TextBox ID="txtYear" runat="server" AutoPostBack="True" MaxLength="10" 
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
                <td >                
                    
                 </td>      
            </tr>
            <tr>
                <td>            
                    
                </td> 
                <td>
                    <asp:Button ID="btnShow" runat="server" Text="แสดงรายงาน" />
                </td>      
            </tr>
        </table>
      
         <br />
              <CR:CrystalReportViewer ID="CryReport" runat="server" AutoDataBind="false" ForeColor="Black"
                        Width="800px" ToolPanelView="None" BackColor="#ffffcc"></CR:CrystalReportViewer>
                
    </div>
    </form>
</body>
</html>
