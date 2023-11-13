<%@ Page Title="" Language="VB" MasterPageFile="~/admin.master" AutoEventWireup="false" CodeFile="Edit_User.aspx.vb" Inherits="Edit_User" %>


<asp:Content ID="Content1" ContentPlaceHolderID="DetailContent" Runat="Server">
<asp:UpdatePanel ID="UpdatePanelEdit" runat="server">
                        <ContentTemplate>
  <div class="head "><img src="images/user-icon2.png" align="absmiddle"/><span>ปรับปรุง-ลบข้อมูล</span></div>
<form>
<table cellpadding="5" cellspacing="0"  >
<tr>
<td class="group" width="300"  align="right"><img src="images/user-icon3.png" align="absmiddle" /></td>
<td  class="group">ข้อมูลทั่วไป</td>
</tr>
<tr>
<td align="right" >ชื่อผู้ใช้งาน :</td>
<td>
    <asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td align="right">นามสกุล :</td>
<td><asp:TextBox ID="txtlastname" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td align="right">ตําแหน่ง :</td>
<td><asp:TextBox ID="txtposition" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td align="right">หมายเลขโทรศัพท์ :</td>
<td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td align="right">E-mail :</td>
<td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td  class="group" align="right" ><img src="images/lock-icon.png" align="absmiddle" /></td>
<td class="group">ข้อมูลสําหรับเข้าใช้ระบบ</td>
</tr>
<tr>
<td align="right">ชื่อสําหรับเข้าใช้งาน :</td>
<td><asp:TextBox ID="txtusername" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td align="right">เลือกระดับการใช้งาน :</td>
<td>
    <asp:DropDownList ID="ddlUserLevel" runat="server">
        <asp:ListItem Value="1">Admin</asp:ListItem>
        <asp:ListItem Value="10">User</asp:ListItem>
        <asp:ListItem Value="20">SuperAdmin</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
<tr>
<td align="right">รับข้อความแจ้งเตือน :</td>
<td ><labeL><asp:CheckBox ID="ChkEmail" runat="server" />&nbsp;&nbsp;ทาง e-mail  </labeL>&nbsp;&nbsp;&nbsp;&nbsp;<label> <asp:CheckBox ID="chkSms" runat="server" />&nbsp;&nbsp;ทาง sms </label></td>
</tr>
<tr class="submit"><td  align="right"><asp:Button ID="BtnSave" runat="server" Text="บันทึกข้อมูล" CssClass="iButton bluebtn" /> </td><td><asp:Button ID="BtnCancel" runat="server" Text="ยกเลิก" CssClass="iButton gray" /></td></tr>
</table>
<asp:Panel ID="pnlConfirm" runat="server" Visible="false" CssClass="panelbox" Width="176px">
        <%--style set position background and color--%>
        <asp:Label ID="lblalert" Text="แก้ไขข้อมูลผู้ใช้สำเร็จ" runat="server"></asp:Label><br />
        <br />
        <div style="text-align: center">
            <asp:ImageButton ID="ButtonOK" runat="server" 
                ImageUrl="images/DTS_SA_Choose_OK.png" OnClientClick="NextPage()" />
                <asp:ImageButton ID="ButtonOK1" runat="server" 
                ImageUrl="images/DTS_SA_Choose_OK.png"  />
            <asp:ImageButton ID="btnvisible" runat="server" Visible="false" />
        </div>
    </asp:Panel>
    <ajax:ModalPopupExtender ID="ModalPopupExtenderconfirm" runat="server" 
        PopupControlID="pnlConfirm"
        CancelControlID="ButtonOK" 
        TargetControlID="btnvisible"
        BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
     <ajax:ConfirmButtonExtender ID="ConfirmButtonExtenderconfirm1" runat="server" DisplayModalPopupID="ModalPopupExtenderconfirm" TargetControlID="btnvisible">
    </ajax:ConfirmButtonExtender>
     <ajax:ModalPopupExtender ID="ModalPopupExtenderconfirm1" runat="server" 
        PopupControlID="pnlConfirm"
        CancelControlID="ButtonOK1" 
        TargetControlID="btnvisible"
        BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
     <ajax:ConfirmButtonExtender ID="ConfirmButtonExtenderconfirm2" runat="server" DisplayModalPopupID="ModalPopupExtenderconfirm1" TargetControlID="btnvisible">
    </ajax:ConfirmButtonExtender>
</form>
   
  <script type="text/javascript">
      $(document).ready(function (e) {
          $("#menu-4").addClass('active');
          $('#admin-menu1 li:nth-child(2)').addClass('active');

      });
      function NextPage() {
          window.location = "Delete_User.aspx";
      }
</script>
  </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>

