<%@ Page Title="" Language="VB" MasterPageFile="~/admin.master" AutoEventWireup="false" CodeFile="admin_edit_station_list.aspx.vb" Inherits="admin_edit_station_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DetailContent" Runat="Server">
    <div class="head "><img src="images/station-icon2.png" align="absmiddle"/><span>แก้ไขข้อมูลสถานีสนาม</span></div>
    <asp:GridView ID="gvStationList" runat="server" AutoGenerateColumns="False" 
        BorderColor="White" AllowPaging="True">                          
        <Columns>
            <asp:BoundField DataField="rowID" HeaderText="ลําดับ" HeaderStyle-HorizontalAlign="Right">
            <HeaderStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="station_id" 
                DataNavigateUrlFormatString="admin_edit_station_list_form.aspx?CODE={0}" 
                DataTextField="station_id_customer" HeaderText="รหัสสถานี" />
            <asp:HyperLinkField DataNavigateUrlFields="station_id" 
                DataNavigateUrlFormatString="admin_edit_station_list_form.aspx?CODE={0}" 
                DataTextField="station_name" HeaderText="ชื่อสถานี" />
            <asp:BoundField DataField="zone_name" HeaderText="ศูนย์อุทกวิทยา" />
            <asp:BoundField DataField="subdistrict_name" HeaderText="ตําบล" />
            <asp:BoundField DataField="district_name" HeaderText="อําเภอ" />
            <asp:BoundField DataField="province_name" HeaderText="จังหวัด" />
        </Columns>                    
    </asp:GridView>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $("#menu-4").addClass('active');
            $('#admin-menu2 li:nth-child(2)').addClass('active');

        });	
</script> 
</asp:Content>

