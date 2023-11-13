<%@ Page Title="" Language="VB" MasterPageFile="~/admin.master" AutoEventWireup="false" CodeFile="ReportTblChart.aspx.vb" Inherits="ReportTblChart" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DetailContent" Runat="Server">
    <link href="css/reportTC.css" rel="stylesheet" type="text/css" />
<div class="head "><img src="images/report-icon2.png" align="absmiddle"/><span>ตารางและกราฟแสดงระดับน้ำ รายชั่วโมง รายวัน รายเดือน รายปี</span></div>

<table cellpadding="5" cellspacing="0" >
<tr>
<td class="group" align="right"><img src="images/search-icon.png" align="absmiddle"></td>
<td class="group">ค้นหาข้อมูล</td>
</tr>
<tr>
<td align="right" width="180">ประเภทกลุ่ม :</td>
<td><asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">กลุ่ม</asp:ListItem>
                        <asp:ListItem Value="1">ศูนย์/โครงการ</asp:ListItem>
                        <asp:ListItem Value="2">ลุ่มน้ำ</asp:ListItem>
                        <asp:ListItem Value="3">จังหวัด</asp:ListItem>
                    </asp:DropDownList></td>
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
                    <asp:DropDownList ID="ddlProvice" runat="server" AutoPostBack="True" 
                         ForeColor="White"></asp:DropDownList>
                </td>      
            
                </asp:View> 
            </asp:MultiView> 
</tr>
<tr>
<td align="right">สถานี :</td>
<td><asp:DropDownList ID="ddlStn" runat="server" AutoPostBack="True"></asp:DropDownList></td>
</tr>
<tr>
<td align="right">รายงาน :</td>
<td><asp:DropDownList ID="ddlCondition" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">ปี</asp:ListItem>
                        <asp:ListItem Value="1">เดือน</asp:ListItem>
                        <asp:ListItem Value="2">วัน</asp:ListItem>
                        <asp:ListItem Value="3">ชั่วโมง</asp:ListItem>
                    </asp:DropDownList>
</td>
</tr>
<tr>
<td align="right">ปีเริ่มต้น :</td>
<td>
<asp:TextBox ID="txtStart" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label2" runat="server" Text="สิ้นสุด"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtStop" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right">เดือน :</td>
<td><asp:DropDownList ID="ddlMonth" runat="server" Enabled="False">
                        <asp:ListItem Value="1">มกราคม</asp:ListItem>
                        <asp:ListItem Value="2">กุมภาพันธ์</asp:ListItem>
                        <asp:ListItem Value="3">มีนาคม</asp:ListItem>
                        <asp:ListItem Value="4">เมษายน</asp:ListItem>
                        <asp:ListItem Value="5">พฤษภาคม</asp:ListItem>
                        <asp:ListItem Value="6">มิถุนายน</asp:ListItem>
                        <asp:ListItem Value="7">กรกฎาคม</asp:ListItem>
                        <asp:ListItem Value="8">สิงหาคม</asp:ListItem>
                        <asp:ListItem Value="9">กันยายน</asp:ListItem>
                        <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
                        <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
                        <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
                    </asp:DropDownList>
</td>
</tr>
<tr>

<td align="right"></td>
<td><div id="admin-content-tbl" ><asp:RadioButtonList ID="rdolist" runat="server" 
                        RepeatDirection="Horizontal"  >                        
                        <asp:ListItem Value="0" Selected="True">แบบตาราง</asp:ListItem>
                        <asp:ListItem Value="1">แบบกราฟ</asp:ListItem>
</asp:RadioButtonList></div>
</td>
</tr>
<tr class="submit"><td align="right"> </td><td><%--<button type="submit" >ดูข้อมูล</button>--%> <asp:Button ID="btnShow" runat="server" Class="iButton blue" Text="ดูข้อมูล" /></td> </tr>
</table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FootContent" Runat="Server">
    <br />
        <div id="admin-content-table" style ="overflow:scroll; width:960px;" align ="center">
         <asp:GridView ID="gdvReportYear" runat="server" AutoGenerateColumns="False" 
            BorderColor="white" width="960px" ShowHeader="false" >
            <HeaderStyle Font-Bold="False"/>
            <RowStyle Height="2px" BackColor="#FFFFFF" BorderColor="#ffffff" BorderStyle="solid" BorderWidth="5px"/>
            <AlternatingRowStyle Height="24px" BackColor="#f4f4f4"/>
            <Columns>
                 <asp:TemplateField HeaderText="Water Year" SortExpression="name" >
                  <ItemTemplate>
                      <asp:Label ID="lblYear" runat="server" Text='<%# Bind("year") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="100px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MSL." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmax" runat="server" Text='<%# Bind("wlupmax") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="100px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmax" runat="server" Text='<%# Bind("wlupDmax") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="100px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MSL." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmin" runat="server" Text='<%# Bind("wlupmin") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="100px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmin" runat="server" Text='<%# Bind("wlupDmin") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="100px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MSL." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmax" runat="server" Text='<%# Bind("wldownmax") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="100px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmax" runat="server" Text='<%# Bind("wldownDmax") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="100px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MSL." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("wldownmin") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="100px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmin" runat="server" Text='<%# Bind("wldownDmin") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="100px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Zero Gage UP" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("ZGup") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="100px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Zero Gage Down" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("ZGdown") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="100px"  />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <asp:GridView ID="gdvReportMonth" runat="server" AutoGenerateColumns="False" 
            BorderColor="white" Visible="False" Width = "1400px" ShowHeader="False">
            <HeaderStyle Font-Bold="False"  />
            <RowStyle Height="24px" BackColor="#FFFFFF" BorderColor="white" BorderStyle="solid" BorderWidth="5px"/>
            <AlternatingRowStyle Height="24px" BackColor="#f4f4f4"/>
            <Columns>
                 <asp:TemplateField HeaderText="ปี" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblYear" runat="server" Text='<%# Bind("year") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="เม.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmax" runat="server" Text='<%# Bind("01") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="เม.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmax" runat="server" Text='<%# Bind("02") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="พ.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmin" runat="server" Text='<%# Bind("03") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="พ.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmin" runat="server" Text='<%# Bind("04") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="มิ.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmax" runat="server" Text='<%# Bind("05") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="มิ.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmax" runat="server" Text='<%# Bind("06") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ก.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("07") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ก.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmin" runat="server" Text='<%# Bind("08") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ส.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("09") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ส.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("10") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ก.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("11") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ก.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("12") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ต.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("13") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ต.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("14") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="พ.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("15") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="พ.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("16") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ธ.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("17") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ธ.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("18") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ม.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("19") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ม.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("20") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ก.พ." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("21") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ก.พ." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("22") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="มี.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("23") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="มี.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("24") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ค่าเฉลี่ย" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("25") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ค่าเฉลี่ย" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("26") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" Width="55px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <asp:GridView ID="gdvReportDay" runat="server" AutoGenerateColumns="False" 
            BorderColor="white" ShowHeader="False" Width = "1500px" >
            <HeaderStyle Font-Bold="False" />
            <RowStyle Height="24px" BackColor="#FFFFFF" BorderColor="white" BorderStyle="solid" BorderWidth="5px"/>
            <AlternatingRowStyle Height="24px" BackColor="#f4f4f4"/>
            <Columns>
                 <asp:TemplateField HeaderText="Date" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblYear" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="เม.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmax" runat="server" Text='<%# Bind("01") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="เม.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmax" runat="server" Text='<%# Bind("02") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="พ.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmin" runat="server" Text='<%# Bind("03") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="พ.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmin" runat="server" Text='<%# Bind("04") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="มิ.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmax" runat="server" Text='<%# Bind("05") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="มิ.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmax" runat="server" Text='<%# Bind("06") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ก.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("07") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ก.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmin" runat="server" Text='<%# Bind("08") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ส.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("09") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ส.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("10") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ก.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("11") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ก.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("12") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ต.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("13") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ต.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("14") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="พ.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("15") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="พ.ย." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("16") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ธ.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("17") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ธ.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("18") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ม.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("19") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ม.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("20") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ก.พ." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("21") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ก.พ." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("22") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="มี.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("23") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="มี.ค." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("24") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Annual" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("25") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Annual" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("26") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <asp:GridView ID="gdvReportHour" runat="server" AutoGenerateColumns="False" 
            BorderColor="black" ForeColor="Black" Font-Names="Tahoma" ShowHeader="False"  Width = "2700px"
            Font-Size="Small">
            <HeaderStyle Font-Bold="False" />
            <RowStyle Height="24px" BackColor="#FFFFFF" BorderColor="white" BorderStyle="solid" BorderWidth="5px"/>
            <AlternatingRowStyle Height="24px" BackColor="#f4f4f4"/>
            <Columns>
                 <asp:TemplateField HeaderText="Water Year" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblYear" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="00:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmax" runat="server" Text='<%# Bind("00") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="00:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmax" runat="server" Text='<%# Bind("01") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="01:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmax" runat="server" Text='<%# Bind("02") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="01:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmin" runat="server" Text='<%# Bind("03") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="02:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmin" runat="server" Text='<%# Bind("04") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="02:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmax" runat="server" Text='<%# Bind("05") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="03:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmax" runat="server" Text='<%# Bind("06") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="03:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("07") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="04:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmin" runat="server" Text='<%# Bind("08") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="04:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("09") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="05:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("10") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="05:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmax" runat="server" Text='<%# Bind("11") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="06:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmax" runat="server" Text='<%# Bind("12") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="06:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmin" runat="server" Text='<%# Bind("13") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="07:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmin" runat="server" Text='<%# Bind("14") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="07:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmax" runat="server" Text='<%# Bind("15") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="08:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmax" runat="server" Text='<%# Bind("16") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="08:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("17") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="09:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmin" runat="server" Text='<%# Bind("18") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="09:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("19") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="10:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("20") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="10:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmax" runat="server" Text='<%# Bind("21") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="11:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmax" runat="server" Text='<%# Bind("22") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="11:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmin" runat="server" Text='<%# Bind("23") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="12:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmin" runat="server" Text='<%# Bind("24") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="12:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmin" runat="server" Text='<%# Bind("25") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="13:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmax" runat="server" Text='<%# Bind("26") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="13:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("27") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="14:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmin" runat="server" Text='<%# Bind("28") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="14:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("29") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="15:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("30") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="15:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmax" runat="server" Text='<%# Bind("31") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="16:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmax" runat="server" Text='<%# Bind("32") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="16:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmin" runat="server" Text='<%# Bind("33") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="17:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmin" runat="server" Text='<%# Bind("34") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="17:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmax" runat="server" Text='<%# Bind("35") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="18:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmax" runat="server" Text='<%# Bind("36") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="18:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("37") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="19:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmin" runat="server" Text='<%# Bind("38") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="19:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("39") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="20:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("40") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="20:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmax" runat="server" Text='<%# Bind("41") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="21:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmax" runat="server" Text='<%# Bind("42") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="21:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmin" runat="server" Text='<%# Bind("43") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="22:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmin" runat="server" Text='<%# Bind("44") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="22:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmax" runat="server" Text='<%# Bind("45") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="23:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmax" runat="server" Text='<%# Bind("46") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="23:00" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("47") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mean" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("48") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Mean" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("49") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Max" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("50") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Max" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("51") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Time" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("52") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Time" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("53") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Min" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("54") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Min" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("55") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Time" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("56") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Time" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("57") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <%--</div>
         <div style ="overflow:scroll; width:920px;" align ="center">   --%>
        <asp:Chart ID="Chart1" runat="server" Height="450px" Width="800px" Visible="False">
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
         </div>
    <asp:LinkButton ID="lbtDownload" runat="server" Visible="False" >Download ข้อมูลรายงาน</asp:LinkButton>
    <br />
<CR:CrystalReportViewer ID="CryExRpt" runat="server" AutoDataBind="true" />
</asp:Content>

