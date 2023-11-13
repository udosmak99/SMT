<%@ Page Title="" Language="VB" MasterPageFile="~/admin.master" AutoEventWireup="false" CodeFile="admin_view_station_list.aspx.vb" Inherits="admin_view_station_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DetailContent" Runat="Server">
<div class="head "><img src="images/station-icon2.png" align="absmiddle"/><span>รายการสถานีสนาม</span></div>
<table cellpadding="5" cellspacing="0" >
    <tr>
    <td align="right" width="350" >รหัสสถานี :</td>
    <td><asp:Label ID="lbl_stncode" runat="server" Text="Label"></asp:Label></td>
    </tr>
    <tr>
    <td align="right">ชื่อสถานี :</td>
    <td><asp:Label ID="lbl_stnname" runat="server" Text="Label"></asp:Label></td>
    </tr>
    <tr>
    <td align="right">ชื่อศูนย์อุทกวิทยา :</td>
    <td><asp:Label ID="lbl_zone_name" runat="server" Text="Label"></asp:Label></td>
    </tr>
    <tr>
    <td align="right">จังหวัด :</td>
    <td><asp:Label ID="lbl_province_name" runat="server" Text="Label"></asp:Label></td>
    </tr>
    <tr>
    <td align="right">อําเภอ :</td>
    <td><asp:Label ID="lbl_district_name" runat="server" Text="Label"></asp:Label></td>
    </tr>
    <tr>
    <td align="right">ตําบล :</td>
    <td><asp:Label ID="lbl_sub_district_name" runat="server" Text="Label"></asp:Label></td>
    </tr>
    <tr>
    <td align="right">ค่าละติจูดที่ตั้งของสถานี(UTM) :</td>
    <td><asp:Label ID="lbl_station_lattitude_utm" runat="server" Text="Label"></asp:Label></td>
    </tr>
    <tr>
    <td align="right">ค่าลองจิจูดที่ตั้งของสถานี(UTM) :</td>
    <td><asp:Label ID="lbl_station_longitude_utm" runat="server" Text="Label"></asp:Label></td>
    </tr>
    <tr>
    <td align="right">ค่าละติจูดที่ตั้งของสถานี :</td>
    <td><asp:Label ID="lbl_station_lattitude" runat="server" Text="Label"></asp:Label></td>
    </tr>
    <tr>
    <td align="right">ค่าลองจิจูดที่ตั้งของสถานี :</td>
    <td><asp:Label ID="lbl_station_longitude" runat="server" Text="Label"></asp:Label></td>
    </tr>
  
    </table>
    <table cellpadding="5" cellspacing="0"  >
    <tr >
    <td align="center" colspan ="4" class="group">ข้อมูลเหนือน้ํา</td>
    </tr>
    <tr>
    <td align="right" width="250">ระดับตลิ่งขวา :</td>
    <td  width="120"> <asp:Label ID="lblRight_bank_up" runat="server" Text="Label"></asp:Label> ม.รสม</td>
    <td align="right" width="120">ระดับตลิ่งซ้าย :</td>
    <td> <asp:Label ID="lblLeft_bank_up" runat="server" Text="Label"></asp:Label> ม.รสม</td>
    </tr>
    <tr>
    <td align="right">ศูนย์เสาระดับ :</td>
    <td> <asp:Label ID="lblZerogate_up" runat="server" Text="Label"></asp:Label> ม.รทก</td>
    <td align="right">ระดับแจ้งเตือนภัย :</td>
    <td> <asp:Label ID="lblWarning_up" runat="server" Text="Label"></asp:Label> ม.รสม</td>
    </tr>
    <tr>
    <td align="right">ระดับวิกฤต :</td>
    <td> <asp:Label ID="lblCritical_up" runat="server" Text="Label"></asp:Label> ม.รสม</td>
    <td align="right"> </td>
    <td> </td>
    </tr>
    <tr>
    <td align="center" colspan ="4" class="group">ข้อมูลท้ายน้ํา</td>
    </tr>
    <tr>
    <td align="right" >ระดับตลิ่งขวา :</td>
    <td> <asp:Label ID="lblRight_bank_down" runat="server" Text="Label"></asp:Label> ม.รสม</td>
 
    <td align="right">ระดับตลิ่งซ้าย :</td>
    <td> <asp:Label ID="lblLeft_bank_down" runat="server" Text="Label"></asp:Label> ม.รสม</td>
    </tr>
    <tr>
    <td align="right">ศูนย์เสาระดับ :</td>
    <td> <asp:Label ID="lblZerogate_down" runat="server" Text="Label"></asp:Label> ม.รทก</td>
    <td align="right">ระดับแจ้งเตือนภัย :</td>
    <td> <asp:Label ID="lblWarning_down" runat="server" Text="Label"></asp:Label> ม.รสม</td>
    </tr>
    <tr>
    <td align="right">ระดับวิกฤต :</td>
    <td> <asp:Label ID="lblCritical_down" runat="server" Text="Label"></asp:Label> ม.รสม</td>
    <td align="right"> </td>
    <td> </td>
    </tr>
</table>
</asp:Content>

