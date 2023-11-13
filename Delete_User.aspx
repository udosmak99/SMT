<%@ Page Title="" Language="VB" MasterPageFile="~/admin.master" AutoEventWireup="false" CodeFile="Delete_User.aspx.vb" Inherits="Delete_User" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DetailContent" Runat="Server">
 
    <div class="head "><img src="images/user-icon2.png" align="absmiddle"/><span>ปรับปรุง-ลบข้อมูล</span></div>
<%--<table cellpadding="5" cellspacing="1" id="edit-user" >
<tr >
<th width="30" >ลําดับ</th>
<th width="80" >ชื่อ</th>
<th width="80" >นามสกุล</th>
<th width="70" >ตําแหน่ง</th>
<th  >หมายเลข<br>โทรศัพท์</th>
<th width="120">E-mail</th>
<th >ระดับ<br>การใช้งาน</th>
<th width="50">แจ้งเตือน<br>ผ่าน<br>sms</th>
<th width="50" >แจ้งเตือน<br>ผ่าน<br>e-mail</th>
<th width="10" >ลบ</th>
</tr>
</table>--%>
 <asp:UpdatePanel ID="UpdatePanelDelete" runat="server"  >
               <ContentTemplate>           
<asp:GridView ID="grvUser" runat="server" AutoGenerateColumns="False" 
         AllowPaging="True"  BorderStyle="None" BorderColor="White"
        AllowSorting="True" Width="745px"  >
        <Columns>
            <asp:TemplateField HeaderText="ลำดับ">
             <ItemTemplate>
                        <%# Databinder.Eval(Container,"DataItemIndex") + 1 %>
                        </ItemTemplate>
                         <HeaderStyle Width="40px" />
                <ItemStyle Width="40px" />
            </asp:TemplateField>
                <asp:TemplateField HeaderText="ID" Visible="False" SortExpression="user_order">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("user_order") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%# Bind("user_order") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                   <asp:TemplateField HeaderText="ชื่อ">
            <ItemTemplate>
                <asp:LinkButton ID="lbluser_name" OnClick="lbluser_name_Click" Text='<%# bind("user_name") %>' runat="server" Width="80" >LinkButton</asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle Width="80px" />
                        </asp:TemplateField>
                    <asp:BoundField DataField="user_lastname" ShowHeader="False" 
                HeaderText="นามสกุล"  >
                    <HeaderStyle Width="80px" />
                   <ItemStyle Width="80px" />
            </asp:BoundField>
                    <asp:BoundField DataField="user_position" ShowHeader="False" 
                HeaderText="ตำแหน่ง"  >
                    <HeaderStyle Width="76px" />
                    <ItemStyle Width="76px" />
            </asp:BoundField>
                    <asp:BoundField DataField="user_phone" ShowHeader="False" 
                HeaderText="หมายเลขโทรศัพท์" >
                    <HeaderStyle Width="76px" />
                     <ItemStyle Width="76px" />
            </asp:BoundField>
                    <asp:BoundField DataField="user_email" ShowHeader="False" 
                HeaderText="E-mail"  >
                    <HeaderStyle Width="120px" />
                    <ItemStyle Width="120px" />
</asp:BoundField>
                    <asp:BoundField DataField="userlevel_name" ShowHeader="False" 
                HeaderText="ระดับการใช้งาน"  >
                     <HeaderStyle Width="83px" />
                     <ItemStyle Width="83px" />
            </asp:BoundField>
    
            <asp:TemplateField HeaderText="แจ้งเตือนผ่าน sms">
            <ItemTemplate>
                            <asp:CheckBox ID="chksms" Checked='<%# bind("user_sendsms") %>' Enabled="false"   runat="server" />
                        </ItemTemplate>
                         <HeaderStyle Width="65px" />
                        <ItemStyle Width="65px" />
            </asp:TemplateField>
    
        
            <asp:TemplateField HeaderText="แจ้งเตือนผ่าน E-mail">
            <ItemTemplate>
                            <asp:CheckBox ID="chkemail" Checked='<%# bind("user_sendemail") %>'  Enabled="false"   runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="65px" />
                        <ItemStyle Width="65px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลบ">
            <ItemTemplate>
         
                <asp:ImageButton ID="ImgDelete" runat="server"  ImageUrl="~/images/delet-icon.png" OnClick="ImgDelete_Click" CommandArgument='<%# Bind("user_id") %>' />
       
                       </ItemTemplate>
                       <HeaderStyle Width="25px" />
                        <ItemStyle Width="25px" />
                        </asp:TemplateField>
        </Columns>
            
    </asp:GridView>

                      <asp:Panel ID="pnlDel" CssClass="panelbox" Width="176px" style="display:none;" runat="server">
     ยืนยันการลบข้อมูลหรือไม่<br />
        <br />
        <div style="text-align: center">
            <asp:HiddenField ID="HiddenId" runat="server" />
        <asp:Button ID="Buttonallow" runat="server" Text="ตกลง" OnClick="Buttonallow_Click" />
            &nbsp;<asp:Button ID="ButtonCancel" runat="server" Text="ยกเลิก" /> <asp:Button ID="btnvisible" runat="server" Text="ยกเลิก" Visible="false" /></div>
    </asp:Panel>
    <ajax:ModalPopupExtender ID="ModalPopupExtender2" runat="server" 
        CancelControlID="ButtonCancel" 
        PopupControlID="pnlDel"
        TargetControlID="btnvisible" 
        BackgroundCssClass="modalBackground">
         </ajax:ModalPopupExtender>
         <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server"
     DisplayModalPopupID="ModalPopupExtender2" 
     TargetControlID="btnvisible">
    </ajax:ConfirmButtonExtender>
    
          </ContentTemplate>
          <Triggers>
          <asp:AsyncPostBackTrigger ControlID="Buttonallow" EventName="Click" />
          </Triggers>
                        </asp:UpdatePanel>
</asp:Content>

