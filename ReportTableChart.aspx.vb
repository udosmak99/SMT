Imports System.Data
Imports System.Drawing
Partial Class ReportTableChart
    Inherits System.Web.UI.Page
    Dim stn As String
    Dim tblName As String
    Protected Sub ReportTableChart_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Not (IsPostBack) Then
                SetControl()
            End If
        Catch ex As Exception
            Throw New Exception("Page_Load Error : " & ex.Message)
        End Try
    End Sub
    Protected Sub ddlGroup_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged
        SetControl()
        If ddlGroup.SelectedValue = 0 Then
            mtvGroup.ActiveViewIndex = 0
        ElseIf ddlGroup.SelectedValue = 1 Then
            mtvGroup.ActiveViewIndex = 1
        ElseIf ddlGroup.SelectedValue = 2 Then
            mtvGroup.ActiveViewIndex = 2
        ElseIf ddlGroup.SelectedValue = 3 Then
            mtvGroup.ActiveViewIndex = 3
        End If
    End Sub

    Public Sub SetControl()
        setGrouper()
        setZone()
        setBasin()
        setProvince()
        setStn()
        txtStart.Text = Now.ToString("yyyy", GolbalFunc.EN.DateTimeFormat)
        txtStop.Text = Now.ToString("yyyy", GolbalFunc.EN.DateTimeFormat)
        btnShow.Enabled = False
    End Sub
    Private Sub setGrouper()
        ddlGrouper.Items.Clear()
        Dim dt As DataTable = smtModel.getGrouper
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกกลุ่ม--"
        ddlGrouper.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("group_id")
            Item.Text = r.Item("group_name")
            ddlGrouper.Items.Add(Item)
        Next
    End Sub
    Private Sub setZone()
        ddlZone.Items.Clear()
        Dim dt As DataTable = smtModel.getZone
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกศูนย์/โครงการ--"
        ddlZone.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("zone_id")
            Item.Text = r.Item("zone_name")
            ddlZone.Items.Add(Item)
        Next
    End Sub
    Private Sub setBasin()
        ddlBasin.Items.Clear()
        Dim dt As DataTable = smtModel.getBasin
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกลุ่มน้ำ--"
        ddlBasin.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("basin_id")
            Item.Text = r.Item("basin_name")
            ddlBasin.Items.Add(Item)
        Next
    End Sub
    Private Sub setProvince()
        ddlProvice.Items.Clear()
        Dim dt As DataTable = smtModel.getProvince
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกจังหวัด--"
        ddlProvice.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("province_id")
            Item.Text = r.Item("province_name")
            ddlProvice.Items.Add(Item)
        Next
    End Sub
    Private Sub setStn()
        ddlStn.Items.Clear()
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกสถานี--"
        ddlStn.Items.Add(listP)
    End Sub
    Private Sub setStnGrouper(ByVal Group As Integer)
        ddlStn.Items.Clear()
        Dim dt As DataTable = smtModel.getStnGrouper(Group)
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกสถานี--"
        ddlStn.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("station_id")
            Item.Text = r.Item("station_name")
            ddlStn.Items.Add(Item)
        Next
    End Sub
    Private Sub setStnZone(ByVal Zone As Integer)
        ddlStn.Items.Clear()
        Dim dt As DataTable = smtModel.getStnZone(Zone)
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกสถานี--"
        ddlStn.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("station_id")
            Item.Text = r.Item("station_name")
            ddlStn.Items.Add(Item)
        Next
    End Sub
    Private Sub setStnBasin(ByVal Basin As Integer)
        ddlStn.Items.Clear()
        Dim dt As DataTable = smtModel.getStnBasin(Basin)
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกสถานี--"
        ddlStn.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("station_id")
            Item.Text = r.Item("station_name")
            ddlStn.Items.Add(Item)
        Next
    End Sub
    Private Sub setStnProvince(ByVal Province As Integer)
        ddlStn.Items.Clear()
        Dim dt As DataTable = smtModel.getStnProvince(Province)
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกสถานี--"
        ddlStn.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("station_id")
            Item.Text = r.Item("station_name")
            ddlStn.Items.Add(Item)
        Next
    End Sub
    Protected Sub ddlGrouper_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlGrouper.SelectedIndexChanged
        btnShow.Enabled = False
        If ddlGrouper.SelectedValue <> "0" Then
            setStnGrouper(ddlGrouper.SelectedValue)
        Else
            setStn()
        End If
    End Sub
    Protected Sub ddlZone_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlZone.SelectedIndexChanged
        btnShow.Enabled = False
        If ddlZone.SelectedValue <> "0" Then
            setStnZone(ddlZone.SelectedValue)
        Else
            setStn()
        End If
    End Sub
    Protected Sub ddlBasin_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlBasin.SelectedIndexChanged
        btnShow.Enabled = False
        If ddlBasin.SelectedValue <> "0" Then
            setStnBasin(ddlBasin.SelectedValue)
        Else
            setStn()
        End If
    End Sub

    Protected Sub ddlProvice_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlProvice.SelectedIndexChanged
        btnShow.Enabled = False
        If ddlProvice.SelectedValue <> "0" Then
            setStnProvince(ddlProvice.SelectedValue)
        Else
            setStn()
        End If
    End Sub
   
    Protected Sub ddlStn_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlStn.SelectedIndexChanged
        If ddlStn.SelectedValue = "0" Then
            btnShow.Enabled = False
        Else
            btnShow.Enabled = True
        End If
    End Sub

    Protected Sub ddlCondition_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCondition.SelectedIndexChanged
        If ddlCondition.SelectedValue = 0 Then
            txtStop.Enabled = True
            ddlMonth.Enabled = False
        ElseIf ddlCondition.SelectedValue = 1 Then
            txtStop.Enabled = True
            ddlMonth.Enabled = False
        ElseIf ddlCondition.SelectedValue = 2 Then
            txtStop.Enabled = False
            ddlMonth.Enabled = False
        ElseIf ddlCondition.SelectedValue = 3 Then
            txtStop.Enabled = False
            ddlMonth.Enabled = True
        End If
    End Sub

    Protected Sub btnShow_Click(sender As Object, e As System.EventArgs) Handles btnShow.Click
        CheckCondition()
    End Sub
    Public Sub CheckCondition()
        Try
            stn = ddlStn.SelectedValue
            Dim dtrow As DataRow = smtModel.getTableName(stn)
            tblName = dtrow.Item("table_name")
            Dim List As Integer = rdolist.SelectedValue
            Dim condition As Integer = ddlCondition.SelectedValue
            If List = 0 Then
                Select Case condition
                    Case 0
                        gdvReportHour.Visible = False
                        gdvReportDay.Visible = False
                        gdvReportMonth.Visible = False
                        gdvReportYear.Visible = True
                        gdvReportYear.DataSource = wlYear()
                        gdvReportYear.DataBind()
                    Case 1
                        gdvReportHour.Visible = False
                        gdvReportDay.Visible = False
                        gdvReportYear.Visible = False
                        gdvReportMonth.Visible = True
                        gdvReportMonth.DataSource = wlMonth()
                        gdvReportMonth.DataBind()
                    Case 2
                        gdvReportHour.Visible = False
                        gdvReportYear.Visible = False
                        gdvReportMonth.Visible = False
                        gdvReportDay.Visible = True
                        gdvReportDay.DataSource = wlDay()
                        gdvReportDay.DataBind()
                    Case 3
                        gdvReportYear.Visible = False
                        gdvReportDay.Visible = False
                        gdvReportMonth.Visible = False
                        gdvReportHour.Visible = True
                        gdvReportHour.DataSource = wlHour()
                        gdvReportHour.DataBind()
                End Select
            End If
        Catch ex As Exception
            Throw New Exception("CheckCondition Error : " & ex.Message)
        End Try
    End Sub
    Private Function wlYear() As DataTable
        Dim WY As New clstblwlYear
        Dim stnCode As String = stn
        Dim DateStart As String = txtStart.Text
        Dim DateStop As String = txtStop.Text
        Return WY.Table(stnCode, DateStart, DateStop, tblName)
    End Function
    Private Function wlMonth() As DataTable
        Dim WM As New clstblwlMonth
        Dim stnCode As String = stn
        Dim DateStart As String = txtStart.Text
        Dim DateStop As String = txtStop.Text
        Return WM.Table(stnCode, DateStart, DateStop, tblName)
    End Function
    Private Function wlDay() As DataTable
        Dim WD As New clstblwlDay
        Dim stnCode As String = stn
        Dim DateStart As String = txtStart.Text
        Return WD.Table(stnCode, DateStart, tblName)
    End Function
    Private Function wlHour() As DataTable
        Dim WY As New clstblwlHour
        Dim stnCode As String = stn
        Dim Month As Integer = ddlMonth.SelectedValue
        Dim DateStart As String = txtStart.Text
        Return WY.Table(stnCode, Month, DateStart, tblName)
    End Function

    
End Class
