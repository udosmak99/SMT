<%@ Page Title="" Language="VB" MasterPageFile="~/admin.master" AutoEventWireup="false" CodeFile="Show_User.aspx.vb" Inherits="Show_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DetailContent" Runat="Server">
<div class="head"><img src="images/user-icon2.png" align="absmiddle"/><span>รายการผู้ใช้งาน</span></div>
<%--<table cellpadding="5" cellspacing="1"  >
<tr >
<th width="30" >ลําดับ</th>
<th width="80" >ชื่อ</th>
<th width="80" >นามสกุล</th>
<th  >ตําแหน่ง</th>
<th  >หมายเลข<br>โทรศัพท์</th>
<th width="120">E-mail</th>
<th >ระดับ<br>การใช้งาน</th>
<th width="50">แจ้งเตือน<br>ผ่าน<br>sms</th>
<th width="50" >แจ้งเตือน<br>ผ่าน<br>e-mail</th>
</tr>
</table>--%>

    <asp:GridView ID="grvUser" runat="server" AutoGenerateColumns="False" 
         AllowPaging="True"  BorderStyle="None" BorderColor="White"
        AllowSorting="True" Width="700px" >

        <Columns>
            <asp:TemplateField HeaderText="ลำดับ">
             <ItemTemplate>
                        <%# Databinder.Eval(Container,"DataItemIndex") + 1 %>
                        </ItemTemplate>
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
            <asp:BoundField DataField="user_name" HeaderText="ชื่อ"  >
                    <HeaderStyle Width="90px" />
                    <ItemStyle Width="90px" />
            </asp:BoundField>
                    <asp:BoundField DataField="user_lastname" HeaderText="นามสกุล"  >
                    <HeaderStyle Width="80px" />
                    <ItemStyle Width="80px" />
            </asp:BoundField>
                    <asp:BoundField DataField="user_position" HeaderText="ตำแหน่ง"  >
                    <HeaderStyle Width="85px" />
                    <ItemStyle Width="85px" />
            </asp:BoundField>
                    <asp:BoundField DataField="user_phone" HeaderText="หมายเลขโทรศัพท์" >
                    <HeaderStyle Width="76px" />
                     <ItemStyle Width="76px" />
            </asp:BoundField>
                    <asp:BoundField DataField="user_email" HeaderText="E-mail"  >
                    <HeaderStyle Width="120px" />
                    <ItemStyle Width="120px" />
</asp:BoundField>
                    <asp:BoundField DataField="userlevel_name" 
                HeaderText="ระดับการใช้งาน"  >
                     <HeaderStyle Width="96px" />
                     <ItemStyle Width="96px" />
            </asp:BoundField>
    
            <asp:TemplateField HeaderText="แจ้งเตือนผ่าน sms">
            <ItemTemplate>
                            <asp:CheckBox ID="chksms" Checked='<%# bind("user_sendsms") %>' Enabled="false"  runat="server" />
                        </ItemTemplate>
                         <HeaderStyle Width="65px" />
                        <ItemStyle Width="65px" />
            </asp:TemplateField>
    
        
            <asp:TemplateField HeaderText="แจ้งเตือนผ่าน E-mail">
            <ItemTemplate>
                            <asp:CheckBox ID="chkemail" Checked='<%# bind("user_sendemail") %>'  Enabled="false"  runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="65px" />
                        <ItemStyle Width="65px" />
                        </asp:TemplateField>
        </Columns>
    </asp:GridView>

  <script type="text/javascript">
      $(document).ready(function (e) {
          $("#menu-4").addClass('active');
          $('#admin-menu1 li:nth-child(1)').addClass('active');
      });	
</script> 
</asp:Content>

