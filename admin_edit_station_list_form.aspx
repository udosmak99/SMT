<%@ Page Title="" Language="VB" MasterPageFile="~/admin.master" AutoEventWireup="false" CodeFile="admin_edit_station_list_form.aspx.vb" Inherits="admin_edit_station_list_form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DetailContent" Runat="Server">
<div class="head "><img src="images/station-icon2.png" align="absmiddle"/><span>แก้ไขข้อมูลสถานีสนาม</span></div>
<table cellpadding="5" cellspacing="0"  >
<asp:HiddenField ID="station_id" runat="server" />
<tr>
<td align="right" >รหัสสถานี :</td>
<td><asp:TextBox ID="txt_station_id_customer" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td align="right">ชื่อสถานี :</td>
<td><asp:TextBox ID="txt_station_name" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td align="right">ชื่อศูนย์อุทกวิทยา :</td>
<td><asp:DropDownList ID="ddl_zone_id" runat="server"></asp:DropDownList>
</td>
</tr>
<tr>
<td align="right">จังหวัด :</td>
<td><asp:DropDownList ID="ddl_province_id" runat="server" AutoPostBack="True"></asp:DropDownList></td>
</tr>
<tr>
<td align="right">อําเภอ :</td>
<td><asp:DropDownList ID="ddl_district_id" 
        runat="server" AutoPostBack="True"></asp:DropDownList></td>
</tr>
<tr>
<td align="right">ตําบล :</td>
<td><asp:DropDownList ID="ddl_subdistrict_id" runat="server"></asp:DropDownList></td>
</tr>
<tr>
<td align="right">ค่าละติจูดที่ตั้งของสถานี(UTM) :</td>
<td><asp:TextBox ID="txt_station_lattitude_utm" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td align="right">ค่าลองจิจูดที่ตั้งของสถานี(UTM) :</td>
<td><asp:TextBox ID="txt_station_longitude_utm" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td align="right">ค่าละติจูดที่ตั้งของสถานี :</td>
<td><asp:TextBox ID="txt_station_lattitude" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td align="right">ค่าลองจิจูดที่ตั้งของสถานี :</td>
<td><asp:TextBox ID="txt_station_longitude" runat="server"></asp:TextBox></td>
</tr>
  
</table>
<table cellpadding="5" cellspacing="0"  >
<tr >
<td align="center" colspan ="4" class="group">ข้อมูลเหนือน้ํา</td>
</tr>
<tr>
<td align="right" width="250">ระดับตลิ่งขวา :</td>
<td  width="120"><asp:TextBox ID="txt_right_bank_wl_up" runat="server" Width="50" 
        AutoPostBack="True" onKeyPress="txt_right_bank_wl_up_TextChanged"></asp:TextBox> ม.รสม</td>
<td align="right" width="120">ระดับตลิ่งซ้าย :</td>
<td  ><asp:TextBox ID="txt_left_bank_wl_up" runat="server" Width="50" 
        AutoPostBack="True" onKeyPress="txt_left_bank_wl_up_TextChanged"></asp:TextBox> ม.รสม</td>
</tr>
<tr>
<td align="right">ศูนย์เสาระดับ :</td>
<td><asp:TextBox ID="txt_zerogate_up" runat="server" Width="50"></asp:TextBox> ม.รทก</td>
<td align="right">ระดับแจ้งเตือนภัย :</td>
<td><asp:TextBox ID="txt_warning_up" runat="server" Width="50" ReadOnly="True"></asp:TextBox> ม.รสม</td>
</tr>
<tr>
<td align="right">ระดับวิกฤต :</td>
<td><asp:TextBox ID="txt_critical_up" runat="server" Width="50" ReadOnly="True"></asp:TextBox> ม.รสม</td>
<td align="right"> </td>
<td> </td>
</tr>
<tr>
<td align="center" colspan ="4" class="group">ข้อมูลท้ายน้ํา</td>
</tr>
<tr>
<td align="right" >ระดับตลิ่งขวา :</td>
<td><asp:TextBox ID="txt_right_bank_wl_down" runat="server" Width="50" 
        AutoPostBack="True" onKeyPress="txt_right_bank_wl_down_TextChanged"></asp:TextBox> ม.รสม</td>
 
<td align="right">ระดับตลิ่งซ้าย :</td>
<td><asp:TextBox ID="txt_left_bank_wl_down" runat="server" Width="50" 
        AutoPostBack="True" onKeyPress="txt_left_bank_wl_down_TextChanged"></asp:TextBox> ม.รสม</td>
</tr>
<tr>
<td align="right">ศูนย์เสาระดับ :</td>
<td><asp:TextBox ID="txt_zerogate_down" runat="server" Width="50"></asp:TextBox> ม.รทก</td>
<td align="right">ระดับแจ้งเตือนภัย :</td>
<td><asp:TextBox ID="txt_warning_down" runat="server" Width="50" ReadOnly="True"></asp:TextBox> ม.รสม</td>
</tr>
<tr>
<td align="right">ระดับวิกฤต :</td>
<td><asp:TextBox ID="txt_critical_down" runat="server" Width="50" ReadOnly="True"></asp:TextBox> ม.รสม</td>
<td align="right"> </td>
<td> </td>
</tr>
</table>
<table cellpadding="5" cellspacing="0"  >
<tr class="submit"><td  align="right">
   <asp:Button ID="btnSave" runat="server" Text="บันทึกข้อมูล" CssClass="iButton blue" /></td><td>
       <asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="iButton gray" /></td></tr>
</table>
<script type="text/javascript">
        $(document).ready(function (e) {
            $("#menu-4").addClass('active');
            $('#admin-menu2 li:nth-child(2)').addClass('active');

        });	
</script> 
</asp:Content>

