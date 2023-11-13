<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReportTableChart.aspx.vb" Inherits="ReportTableChart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="800px">
            <tr>
                <td width="200px">
                    <asp:Label ID="Label5" runat="server" Text="ประเภทกลุ่ม :"></asp:Label>
                    &nbsp;
                </td>
                <td >
                    <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">กลุ่ม</asp:ListItem>
                        <asp:ListItem Value="1">ศูนย์/โครงการ</asp:ListItem>
                        <asp:ListItem Value="2">ลุ่มน้ำ</asp:ListItem>
                        <asp:ListItem Value="3">จังหวัด</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <asp:MultiView ID="mtvGroup" runat="server" ActiveViewIndex="0" Visible="true">
                <asp:View ID="View1" runat="server">
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="กลุ่ม :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGrouper" runat="server" AutoPostBack="True" Height="22px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </asp:View>
                <asp:View ID="G0" runat="server">
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="ศูนย์/โครงการ :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="True" Height="22px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </asp:View>
                <asp:View ID="G1" runat="server">
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="ลุ่มน้ำ :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBasin" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="จังหวัด :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProvice" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
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
                    <asp:Label ID="Label3" runat="server" Text="รายงาน :" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" 
                        Visible="False">
                        <asp:ListItem Value="1">ปริมาณน้ำฝน</asp:ListItem>
                        <asp:ListItem Value="2">ระดับน้ำ</asp:ListItem>
                         <%--<asp:ListItem Value="3">ปริมาณน้ำ</asp:ListItem>--%>
                     </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="รายงาน :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCondition" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">ปี</asp:ListItem>
                        <asp:ListItem Value="1">เดือน</asp:ListItem>
                        <asp:ListItem Value="2">วัน</asp:ListItem>
                        <asp:ListItem Value="3">ชั่วโมง</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="ปีเริ่มต้น :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStart" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="สิ้นสุด :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStop" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="เดือน :"></asp:Label>
                </td>
                <td>

                    <asp:DropDownList ID="ddlMonth" runat="server" Enabled="False">
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
                <td>
                    &nbsp;</td>
                 
                <td>
                    
                    <asp:RadioButtonList ID="rdolist" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" Selected="True">แบบตาราง</asp:ListItem>
                        <asp:ListItem Value="2">แบบกราฟ</asp:ListItem>
                    </asp:RadioButtonList>
                    
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
        <div style ="width:800px; overflow :scroll ;">
         <asp:GridView ID="gdvReportYear" runat="server" AutoGenerateColumns="False" 
            Width="1000px" BorderColor="black" ForeColor="Black" Font-Names="Tahoma" 
            Font-Size="Small" >
            <HeaderStyle Font-Bold="False" />
            <RowStyle Height="24px" BackColor="#FFFFFF" BorderColor="white" BorderStyle="solid" BorderWidth="5px"/>
            <AlternatingRowStyle Height="24px" BackColor="#f4f4f4"/>
            <Columns>
                 <asp:TemplateField HeaderText="Water Year" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblYear" runat="server" Text='<%# Bind("year") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MSL." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmax" runat="server" Text='<%# Bind("wlupmax") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmax" runat="server" Text='<%# Bind("wlupDmax") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MSL." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupmin" runat="server" Text='<%# Bind("wlupmin") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwlupDmin" runat="server" Text='<%# Bind("wlupDmin") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MSL." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmax" runat="server" Text='<%# Bind("wldownmax") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmax" runat="server" Text='<%# Bind("wldownDmax") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MSL." SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownmin" runat="server" Text='<%# Bind("wldownmin") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblwldownDmin" runat="server" Text='<%# Bind("wldownDmin") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Zero Gage UP" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("ZGup") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Zero Gage Down" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("ZGdown") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         </div>

         <div style ="width:800px; overflow :scroll ;">
         <asp:GridView ID="gdvReportMonth" runat="server" AutoGenerateColumns="False" 
            Width="1000px" BorderColor="black" ForeColor="Black" Font-Names="Tahoma" 
            Font-Size="Small" >
            <HeaderStyle Font-Bold="False" />
            <RowStyle Height="24px" BackColor="#FFFFFF" BorderColor="white" BorderStyle="solid" BorderWidth="5px"/>
            <AlternatingRowStyle Height="24px" BackColor="#f4f4f4"/>
            <Columns>
                 <asp:TemplateField HeaderText="ปี" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblYear" runat="server" Text='<%# Bind("year") %>'></asp:Label>
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
                <asp:TemplateField HeaderText="ค่าเฉลี่ย" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGup" runat="server" Text='<%# Bind("25") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ค่าเฉลี่ย" SortExpression="name">
                  <ItemTemplate>
                      <asp:Label ID="lblZGdown" runat="server" Text='<%# Bind("26") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle ForeColor="black" />
                  <ItemStyle BorderStyle="Dotted" BorderColor ="#cccccc" BorderWidth="1px" width="49px"  />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         </div>

        <div style ="width:800px; overflow :scroll ;">
        <asp:GridView ID="gdvReportDay" runat="server" AutoGenerateColumns="False" 
            Width="1000px" BorderColor="black" ForeColor="Black" Font-Names="Tahoma" 
            Font-Size="Small" >
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
         </div>

         <div style ="width:800px; overflow :scroll ;">
       
        <asp:GridView ID="gdvReportHour" runat="server" AutoGenerateColumns="False" 
            Width="1000px" BorderColor="black" ForeColor="Black" Font-Names="Tahoma" 
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
         </div>

         <br />    
    </div>
    </form>
</body>
</html>
