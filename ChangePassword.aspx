<%@ Page Title="" Language="VB" MasterPageFile="~/admin.master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="ChangePassword" %>


<asp:Content ID="Content1" ContentPlaceHolderID="DetailContent" Runat="Server">
<asp:UpdatePanel ID="UpdatePanelChangePassword" runat="server">
                        <ContentTemplate>
    <div class="head "><img src="images/user-icon2.png" align="absmiddle"/><span>เปลี่ยนรหัสผ่าน</span></div>
<form>
<table cellpadding="5" cellspacing="0"  >
 <tr>
<td  class="group" align="right" ><img src="images/lock-icon.png" align="absmiddle" /></td>
<td class="group">ข้อมูลสําหรับเข้าใช้ระบบ</td>
</tr>
<tr>
<td align="right">ชื่อสําหรับเข้าใช้งาน :</td>
<td>
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td align="right">รหัสในการใช้งานเดิม :</td>
<td><asp:TextBox ID="txtoldpassword" runat="server" TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<td align="right">รหัสการใช้งานใหม่ :</td>
<td><asp:TextBox ID="txtnewpassword" runat="server" TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<td align="right">ยืนยันรหัสการใช้งานใหม่ :</td>
<td><asp:TextBox ID="txtconfirmpassword" runat="server" TextMode="Password"></asp:TextBox></td>
</tr>

<tr class="submit"><td  align="right"><asp:Button ID="btnSave" runat="server" Text="บันทึกข้อมูล" CssClass="iButton bluebtn" /> </td><td><asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="iButton gray" /></td></tr>
</table>
</form>
 <asp:Panel ID="pnlConfirm" runat="server" Visible="false" CssClass="panelbox" Width="176px">
        <%--style set position background and color--%>
        <asp:Label ID="lblalert" Text="แก้ไขรหัสผ่านเรียบร้อย" runat="server"></asp:Label><br />
        <br />
        <div style="text-align: center">
            <asp:ImageButton ID="ButtonOK" runat="server" 
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
     <ajax:ConfirmButtonExtender ID="ConfirmButtonExtenderconfirm" runat="server" DisplayModalPopupID="ModalPopupExtenderconfirm" TargetControlID="btnvisible">
    </ajax:ConfirmButtonExtender>
 </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>

