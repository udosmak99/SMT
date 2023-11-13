Imports System.Data
Imports System.Drawing
Imports System.Web.UI.DataVisualization.Charting
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class ReportTblChart
    Inherits System.Web.UI.Page
    Dim stn As String
    Dim tblName As String
    Dim stnName As String
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
        txtStart.Text = Now.ToString("yyyy", GolbalFunc.EN.DateTimeFormat) - 1
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
            stnName = dtrow.Item("station_name")
            Dim List As Integer = rdolist.SelectedValue
            Dim condition As Integer = ddlCondition.SelectedValue
            If List = 0 Then
                Chart1.Visible = False
                lbtDownload.Visible = True
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
            ElseIf List = 1 Then
                gdvReportHour.Visible = False
                gdvReportDay.Visible = False
                gdvReportMonth.Visible = False
                gdvReportYear.Visible = False
                lbtDownload.Visible = False
                Chart1.Visible = True
                Select Case condition
                    Case 0
                        BindWlYear(stn, txtStart.Text, txtStop.Text, tblName)
                    Case 1
                        BindWlMonth(stn, txtStart.Text, tblName)
                    Case 2
                        BindWlDay(stn, txtStart.Text, tblName)
                    Case 3
                        BindWlHour(stn, txtStart.Text, ddlMonth.SelectedValue, tblName, stnName)
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
    Private Function EXYear(ByVal Stn As String, ByVal StartYear As Integer, ByVal StopYear As Integer, ByVal tblName As String) As clsRPT
        Dim EY As New clstblwlYear
        Dim stnCode As String = Stn
        Dim DateStart As String = txtStart.Text
        Dim DateStop As String = txtStop.Text
        Return EY.Report(stnCode, DateStart, DateStop, tblName)
    End Function
    Private Function EXMonth(ByVal Stn As String, ByVal StartYear As Integer, ByVal StopYear As Integer, ByVal tblName As String) As clsRPT
        Dim EM As New clstblwlMonth
        Dim stnCode As String = Stn
        Dim DateStart As String = txtStart.Text
        Dim DateStop As String = txtStop.Text
        Return EM.Report(stnCode, DateStart, DateStop, tblName)
    End Function
    Private Function EXDay(ByVal Stn As String, ByVal StartYear As Integer, ByVal tblName As String) As clsRPT
        Dim ED As New clstblwlDay
        Dim stnCode As String = Stn
        Dim DateStart As String = txtStart.Text
        Return ED.Report(stnCode, DateStart, tblName)
    End Function
    Private Function EXHour(ByVal Stn As String, ByVal StartYear As Integer, ByVal Month As Integer, ByVal tblName As String) As clsRPT
        Dim EH As New clstblwlHour
        Dim stnCode As String = Stn
        Dim DateStart As String = txtStart.Text
        Return EH.Report(stnCode, DateStart, Month, tblName)
    End Function
    Protected Sub lbtDownload_Click(sender As Object, e As System.EventArgs) Handles lbtDownload.Click
        Try
            stn = ddlStn.SelectedValue
            Dim dtrow As DataRow = smtModel.getTableName(stn)
            tblName = dtrow.Item("table_name")
            stnName = dtrow.Item("station_name")
            stnName = dtrow.Item("station_id_customer")
            Dim List As Integer = rdolist.SelectedValue
            Dim condition As Integer = ddlCondition.SelectedValue
            Dim cryRpt As New ReportDocument
            If List = 0 Then
                Select Case condition
                    Case 0
                        cryRpt = EXYear(stn, txtStart.Text, txtStop.Text, tblName)
                    Case 1
                        cryRpt = EXMonth(stn, txtStart.Text, txtStop.Text, tblName)
                    Case 2
                        cryRpt = EXDay(stn, txtStart.Text, tblName)
                    Case 3
                        cryRpt = EXHour(stn, txtStart.Text, ddlMonth.SelectedValue, tblName)
                End Select
            End If
            If Not (cryRpt Is Nothing) Then
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
                Dim CrFormatTypeOptions As New ExcelFormatOptions

                'stnName = "fileExport"
                CrDiskFileDestinationOptions.DiskFileName = Server.MapPath("~\SaveFile\" & stnName & ".xls")
                CrExportOptions = cryRpt.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = ExportFormatType.Excel
                    .DestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions
                End With
                cryRpt.Export()
                'Dim url As String = Server.MapPath("~\SaveFile\" & stnName & ".xls")
                ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(String), "MyJSFunction", "window.open ('./savefile/" & stnName & ".xls','mywindow','width=500,height=100,left=100,top=100,resizable=false');", True)
                'CryExRpt.ReportSource = Session("reports")
            End If
        Catch ex As Exception
            Throw New Exception("CheckCondition Error : " & ex.Message)
        End Try
    End Sub

    Private Function GetTblavg(ByVal station_id As String, ByVal DateStart As DateTime, ByVal DateStop As DateTime, ByVal tblName As String) As DataTable
        Try
            Dim Cmd As New SqlCommand
            Dim da As New SqlDataAdapter(Cmd)
            Dim ds As New DataSet
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "select avg(wl_up)as avg_wl ,avg(wl_down) as avg_wl_down from " & tblName & " where station_id = @station_id " & _
                " and server_time between @DateStart and @DateStop and wl_up is not null "
            Cmd.Parameters.AddWithValue("station_id", station_id.Trim)
            Cmd.Parameters.AddWithValue("DateStart", DateStart)
            Cmd.Parameters.AddWithValue("DateStop", DateStop)
            Cmd.Connection = GolbalFunc.Database.Connection
            da.Fill(ds, "tblavg")
            If ds.Tables("tblavg").Rows.Count <> 0 Then
                Return ds.Tables("tblavg")
            End If
        Catch ex As Exception
            Throw New Exception("GetTblavg" & ex.Message)
        End Try
    End Function
    Private Sub BindWlYear(ByVal stn As String, ByVal Dstart As Integer, ByVal Dstop As Integer, ByVal tblName As String)
        Dim StartYear As Integer = Dstart
        Dim StopYear As Integer = Dstop
        Dim DateStart As DateTime
        Dim DateStop As DateTime
        Dim tbl As New DataTable
        Dim tblAvg As New DataTable
        Dim dr As DataRow
        Dim years As Integer = StopYear - StartYear
        tbl.Columns.Add("server_time")
        tbl.Columns.Add("avg_wl")
        tbl.Columns.Add("avg_wl_down")
        DateStart = New DateTime(StartYear, 4, 1, 0, 15, 0)
        DateStop = New DateTime(StartYear + 1, 4, 1, 0, 0, 0)
        For i = 0 To years
            dr = tbl.NewRow
            dr.Item("server_time") = Dstart + 543
            tblAvg = GetTblavg(stn, DateStart, DateStop, tblName)
            dr.Item("avg_wl") = tblAvg.Rows(0).Item("avg_wl")
            dr.Item("avg_wl_down") = tblAvg.Rows(0).Item("avg_wl_down")
            tbl.Rows.Add(dr)
            Dstart = Dstart + 1
            DateStart = DateAdd(DateInterval.Year, 1, DateStart)
            DateStop = DateAdd(DateInterval.Year, 1, DateStop)
        Next
        Dim tblChart As New DataTable
        tblChart = tbl
        Dim setChart As New clsChart
        Dim index As Integer
        setChart.Title = "กราฟแสดงระดับน้ำรายปี"
        setChart.titleY = "ระดับน้ำ - เมตร(รทก.)"
        setChart.titleX = "ปี"
        setChart.myTable = tblChart
        setChart.columnY = "avg_wl"
        setChart.columnY1 = "avg_wl_down"
        setChart.columnX = "server_time"
        index = 2
        'กำหนดชนิดกราฟ เป็นกราฟเส้น
        Chart1.Series("WaterLevel_Up").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart1.Series("WaterLevel_Up").BorderWidth = 5
        Chart1.Series("WaterLevel_Up").Font = New Font("Tahoma", 7, FontStyle.Bold)
        Chart1.Series("WaterLevel_Down").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart1.Series("WaterLevel_Down").BorderWidth = 5
        Chart1.Series("WaterLevel_Down").Font = New Font("Tahoma", 7, FontStyle.Bold)
        bindingChart4(setChart)

    End Sub
    Private Sub BindWlMonth(ByVal stn As String, ByVal Dstart As Integer, ByVal tblName As String)
        Dim Years As Integer = Dstart
        Dim NextYear As Integer = Years + 1
        Dim StartDate = New DateTime(Years, 4, 1, 0, 15, 0)
        Dim StopDate = New DateTime(NextYear, 4, 1, 0, 0, 0)
        Dim tblChart As New DataTable
        tblChart = clsReportChart.GetGraphWlMonth(stn, StartDate, StopDate, tblName)
        Dim setChart As New clsChart
        Dim index As Integer
        setChart.Title = "กราฟแสดงระดับน้ำรายเดือน"
        setChart.titleY = "ระดับน้ำ - เมตร(รทก.)"
        setChart.titleX = "เดือน"
        setChart.myTable = tblChart
        setChart.columnY = "avg_wl"
        setChart.columnY1 = "avg_wl_down"
        setChart.columnX = "server_time"
        index = 2
        'กำหนดชนิดกราฟ เป็นกราฟเส้น
        Chart1.Series("WaterLevel_Up").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart1.Series("WaterLevel_Up").BorderWidth = 2
        Chart1.Series("WaterLevel_Up").Font = New Font("Tahoma", 7, FontStyle.Bold)
        Chart1.Series("WaterLevel_Down").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart1.Series("WaterLevel_Down").BorderWidth = 2
        Chart1.Series("WaterLevel_Down").Font = New Font("Tahoma", 7, FontStyle.Bold)
        bindingChart3(setChart)

    End Sub
    Private Sub BindWlDay(ByVal stn As String, ByVal Dstart As Integer, ByVal tblName As String)
        Dim Years As Integer = Dstart
        Dim NextYear As Integer = Years + 1
        Dim StartDate = New DateTime(Years, 4, 1, 0, 15, 0)
        Dim StopDate = New DateTime(NextYear, 4, 1, 0, 0, 0)
        Dim tblChart As New DataTable
        tblChart = clsReportChart.GetGraphWlDay(stn, StartDate, StopDate, tblName)
        Dim setChart As New clsChart
        Dim index As Integer
        setChart.Title = "กราฟแสดงระดับน้ำรายวัน ปีน้ำ " & Years + 543
        setChart.titleY = "ระดับน้ำ - เมตร(รทก.)"
        setChart.titleX = "เดือน"
        setChart.myTable = tblChart
        setChart.columnY = "avg_wl"
        setChart.columnY1 = "avg_wl_down"
        setChart.columnX = "server_time"
        index = 2
        'กำหนดชนิดกราฟ เป็นกราฟเส้น
        Chart1.Series("WaterLevel_Up").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series("WaterLevel_Up").BorderWidth = 2
        Chart1.Series("WaterLevel_Up").Font = New Font("Tahoma", 7, FontStyle.Bold)
        Chart1.Series("WaterLevel_Down").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series("WaterLevel_Down").BorderWidth = 2
        Chart1.Series("WaterLevel_Down").Font = New Font("Tahoma", 7, FontStyle.Bold)
        bindingChart(setChart)

    End Sub
    Private Sub BindWlHour(ByVal stn As String, ByVal Dstart As Integer, ByVal Month As Integer, ByVal tblName As String, ByVal stnName As String)
        Dim Years As Integer = Dstart
        Dim StartDate = New DateTime(Years, Month, 1, 0, 15, 0)
        Dim StopDate = DateAdd(DateInterval.Month, 1, StartDate)
        StopDate = DateAdd(DateInterval.Minute, -15, StopDate)
        Dim tblChart As New DataTable
        tblChart = clsReportChart.GetGraphWlHour(stn, StartDate, StopDate, tblName)
        Dim setChart As New clsChart
        Dim index As Integer
        setChart.Title = "กราฟแสดงระดับน้ำรายชั่วโมง สถานี " & stnName & " เดือน" & Format(StartDate, "MMMM") & " " & Years + 543
        setChart.titleY = "ระดับน้ำ - เมตร(รทก.)"
        setChart.titleX = "เดือน" & Format(StartDate, "MMMM") & " " & Years + 543
        setChart.myTable = tblChart
        setChart.columnY = "avg_wl"
        setChart.columnY1 = "avg_wl_down"
        setChart.columnX = "server_time"
        index = 2
        'กำหนดชนิดกราฟ เป็นกราฟเส้น
        Chart1.Series("WaterLevel_Up").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series("WaterLevel_Up").BorderWidth = 2
        Chart1.Series("WaterLevel_Up").Font = New Font("Tahoma", 7, FontStyle.Bold)
        Chart1.Series("WaterLevel_Down").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series("WaterLevel_Down").BorderWidth = 2
        Chart1.Series("WaterLevel_Down").Font = New Font("Tahoma", 7, FontStyle.Bold)
        bindingChart2(setChart)
    End Sub
    Private Sub bindingChart(ByVal SetChart As clsChart)

        'กำหนดหัวตาราง
        Chart1.Titles.Add(SetChart.Title & "\n" & SetChart.SubTitle)
        Chart1.Titles(0).Font = New Font("Tahoma", 10, FontStyle.Bold)
        Chart1.Titles(0).ForeColor = Color.Black
        Chart1.Titles(0).Alignment = System.Drawing.ContentAlignment.MiddleCenter

        'กำหนดแกน Y
        Chart1.ChartAreas("ChartArea1").AxisY.TitleAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Chart1.ChartAreas("ChartArea1").AxisY.Title = SetChart.titleY
        Chart1.ChartAreas("ChartArea1").AxisY.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart1.ChartAreas("ChartArea1").AxisY.TitleAlignment = StringAlignment.Center
        Chart1.ChartAreas("ChartArea1").AxisY.LabelStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)

        'กำหนดแกน X
        Chart1.ChartAreas("ChartArea1").AxisX.TitleAlignment = System.Drawing.ContentAlignment.TopLeft
        Chart1.ChartAreas("ChartArea1").AxisX.Title = SetChart.titleX
        Chart1.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -45

        'กำหนดความถี่
        Chart1.ChartAreas("ChartArea1").AxisX.Interval = 1
        Chart1.ChartAreas("ChartArea1").AxisX.IntervalType = DateTimeIntervalType.Months

        'กำหนดรูปแบบเส้นในตาราง
        Chart1.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash

        'กำหนดรูปแบบการแสดงวันที่
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Format = "d-MMM"
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        Chart1.DataSource = SetChart.myTable
        Chart1.Series("WaterLevel_Up").YValueMembers = SetChart.columnY
        Chart1.Series("WaterLevel_Up").Color = Color.Blue
        Chart1.Series("WaterLevel_Up").Font = New Font("Tahoma", 8, FontStyle.Bold)
        Chart1.Series("WaterLevel_Up").XValueMember = SetChart.columnX
        Chart1.Series("WaterLevel_Up").LegendText = "ระดับน้ำเหนือน้ำ"
        Chart1.Legends.Add("WaterLevel_Up")
        Chart1.Legends.Item("WaterLevel_Up").Alignment = StringAlignment.Far
        Chart1.Legends.Item("WaterLevel_Up").Docking = Docking.Bottom
        Chart1.Legends.Item("WaterLevel_Up").Font = New Font("Tahoma", 8, FontStyle.Regular)
        Chart1.Series("WaterLevel_Down").Color = Color.Orange
        Chart1.Series("WaterLevel_Down").Font = New Font("Tahoma", 8, FontStyle.Bold)
        Chart1.Series("WaterLevel_Down").YValueMembers = SetChart.columnY1
        Chart1.Series("WaterLevel_Down").XValueMember = SetChart.columnX
        Chart1.Series("WaterLevel_Down").LegendText = "ระดับน้ำท้ายน้ำ"
        Chart1.Legends.Add("WaterLevel_Down")
        Chart1.Legends.Item("WaterLevel_Down").Alignment = StringAlignment.Far
        Chart1.Legends.Item("WaterLevel_Down").Docking = Docking.Bottom
        Chart1.Legends.Item("WaterLevel_Down").Font = New Font("Tahoma", 8, FontStyle.Regular)
        Chart1.DataBind()
    End Sub
    Private Sub bindingChart2(ByVal SetChart As clsChart)

        'กำหนดหัวตาราง
        Chart1.Titles.Add(SetChart.Title & "\n" & SetChart.SubTitle)
        Chart1.Titles(0).Font = New Font("Tahoma", 10, FontStyle.Bold)
        Chart1.Titles(0).ForeColor = Color.Black
        Chart1.Titles(0).Alignment = System.Drawing.ContentAlignment.MiddleCenter

        'กำหนดแกน Y
        Chart1.ChartAreas("ChartArea1").AxisY.TitleAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Chart1.ChartAreas("ChartArea1").AxisY.Title = SetChart.titleY
        Chart1.ChartAreas("ChartArea1").AxisY.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart1.ChartAreas("ChartArea1").AxisY.TitleAlignment = StringAlignment.Center
        Chart1.ChartAreas("ChartArea1").AxisY.LabelStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)

        'กำหนดแกน X
        Chart1.ChartAreas("ChartArea1").AxisX.TitleAlignment = System.Drawing.ContentAlignment.TopLeft
        Chart1.ChartAreas("ChartArea1").AxisX.Title = SetChart.titleX
        Chart1.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -45

        'กำหนดความถี่
        Chart1.ChartAreas("ChartArea1").AxisX.Interval = 3
        Chart1.ChartAreas("ChartArea1").AxisX.IntervalType = DateTimeIntervalType.Days

        'กำหนดรูปแบบเส้นในตาราง
        Chart1.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash

        'กำหนดรูปแบบการแสดงวันที่
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Format = "d-MMM"
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        Chart1.DataSource = SetChart.myTable
        Chart1.Series("WaterLevel_Up").YValueMembers = SetChart.columnY
        Chart1.Series("WaterLevel_Up").Color = Color.Blue
        Chart1.Series("WaterLevel_Up").Font = New Font("Tahoma", 8, FontStyle.Bold)
        Chart1.Series("WaterLevel_Up").XValueMember = SetChart.columnX
        Chart1.Series("WaterLevel_Up").LegendText = "ระดับน้ำเหนือน้ำ"
        Chart1.Legends.Add("WaterLevel_Up")
        Chart1.Legends.Item("WaterLevel_Up").Alignment = StringAlignment.Far
        Chart1.Legends.Item("WaterLevel_Up").Docking = Docking.Bottom
        Chart1.Legends.Item("WaterLevel_Up").Font = New Font("Tahoma", 8, FontStyle.Regular)
        Chart1.Series("WaterLevel_Down").Color = Color.Orange
        Chart1.Series("WaterLevel_Down").Font = New Font("Tahoma", 8, FontStyle.Bold)
        Chart1.Series("WaterLevel_Down").YValueMembers = SetChart.columnY1
        Chart1.Series("WaterLevel_Down").XValueMember = SetChart.columnX
        Chart1.Series("WaterLevel_Down").LegendText = "ระดับน้ำท้ายน้ำ"
        Chart1.Legends.Add("WaterLevel_Down")
        Chart1.Legends.Item("WaterLevel_Down").Alignment = StringAlignment.Far
        Chart1.Legends.Item("WaterLevel_Down").Docking = Docking.Bottom
        Chart1.Legends.Item("WaterLevel_Down").Font = New Font("Tahoma", 8, FontStyle.Regular)
        Chart1.DataBind()
    End Sub
    Private Sub bindingChart3(ByVal SetChart As clsChart)

        'กำหนดหัวตาราง
        Chart1.Titles.Add(SetChart.Title & "\n" & SetChart.SubTitle)
        Chart1.Titles(0).Font = New Font("Tahoma", 10, FontStyle.Bold)
        Chart1.Titles(0).ForeColor = Color.Black
        Chart1.Titles(0).Alignment = System.Drawing.ContentAlignment.MiddleCenter

        'กำหนดแกน Y
        Chart1.ChartAreas("ChartArea1").AxisY.TitleAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Chart1.ChartAreas("ChartArea1").AxisY.Title = SetChart.titleY
        Chart1.ChartAreas("ChartArea1").AxisY.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart1.ChartAreas("ChartArea1").AxisY.TitleAlignment = StringAlignment.Center
        Chart1.ChartAreas("ChartArea1").AxisY.LabelStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)

        'กำหนดแกน X
        Chart1.ChartAreas("ChartArea1").AxisX.TitleAlignment = System.Drawing.ContentAlignment.TopLeft
        Chart1.ChartAreas("ChartArea1").AxisX.Title = SetChart.titleX
        Chart1.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -45

        'กำหนดความถี่
        Chart1.ChartAreas("ChartArea1").AxisX.Interval = 1
        Chart1.ChartAreas("ChartArea1").AxisX.IntervalType = DateTimeIntervalType.Months

        'กำหนดรูปแบบเส้นในตาราง
        Chart1.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash

        'กำหนดรูปแบบการแสดงวันที่
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Format = "d-MMM"
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        Chart1.DataSource = SetChart.myTable
        Chart1.Series("WaterLevel_Up").YValueMembers = SetChart.columnY
        Chart1.Series("WaterLevel_Up").Color = Color.Blue
        Chart1.Series("WaterLevel_Up").Font = New Font("Tahoma", 8, FontStyle.Bold)
        Chart1.Series("WaterLevel_Up").XValueMember = SetChart.columnX
        Chart1.Series("WaterLevel_Up").LegendText = "ระดับน้ำเหนือน้ำ"
        Chart1.Legends.Add("WaterLevel_Up")
        Chart1.Legends.Item("WaterLevel_Up").Alignment = StringAlignment.Far
        Chart1.Legends.Item("WaterLevel_Up").Docking = Docking.Bottom
        Chart1.Legends.Item("WaterLevel_Up").Font = New Font("Tahoma", 8, FontStyle.Regular)
        Chart1.Series("WaterLevel_Down").Color = Color.Orange
        Chart1.Series("WaterLevel_Down").Font = New Font("Tahoma", 8, FontStyle.Bold)
        Chart1.Series("WaterLevel_Down").YValueMembers = SetChart.columnY1
        Chart1.Series("WaterLevel_Down").XValueMember = SetChart.columnX
        Chart1.Series("WaterLevel_Down").LegendText = "ระดับน้ำท้ายน้ำ"
        Chart1.Legends.Add("WaterLevel_Down")
        Chart1.Legends.Item("WaterLevel_Down").Alignment = StringAlignment.Far
        Chart1.Legends.Item("WaterLevel_Down").Docking = Docking.Bottom
        Chart1.Legends.Item("WaterLevel_Down").Font = New Font("Tahoma", 8, FontStyle.Regular)
        Chart1.DataBind()
    End Sub
    Private Sub bindingChart4(ByVal SetChart As clsChart)

        'กำหนดหัวตาราง
        Chart1.Titles.Add(SetChart.Title & "\n" & SetChart.SubTitle)
        Chart1.Titles(0).Font = New Font("Tahoma", 10, FontStyle.Bold)
        Chart1.Titles(0).ForeColor = Color.Black
        Chart1.Titles(0).Alignment = System.Drawing.ContentAlignment.MiddleCenter

        'กำหนดแกน Y
        Chart1.ChartAreas("ChartArea1").AxisY.TitleAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Chart1.ChartAreas("ChartArea1").AxisY.Title = SetChart.titleY
        Chart1.ChartAreas("ChartArea1").AxisY.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart1.ChartAreas("ChartArea1").AxisY.TitleAlignment = StringAlignment.Center
        Chart1.ChartAreas("ChartArea1").AxisY.LabelStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)

        'กำหนดแกน X
        Chart1.ChartAreas("ChartArea1").AxisX.TitleAlignment = System.Drawing.ContentAlignment.TopLeft
        Chart1.ChartAreas("ChartArea1").AxisX.Title = SetChart.titleX
        Chart1.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -45

        'กำหนดความถี่
        'Chart1.ChartAreas("ChartArea1").AxisX.Interval = 1
        'Chart1.ChartAreas("ChartArea1").AxisX.IntervalType = DateTimeIntervalType.Years

        'กำหนดรูปแบบเส้นในตาราง
        Chart1.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash

        'กำหนดรูปแบบการแสดงวันที่
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Format = "YYYY"
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        Chart1.DataSource = SetChart.myTable
        Chart1.Series("WaterLevel_Up").YValueMembers = SetChart.columnY
        Chart1.Series("WaterLevel_Up").Color = Color.Blue
        Chart1.Series("WaterLevel_Up").Font = New Font("Tahoma", 8, FontStyle.Bold)
        Chart1.Series("WaterLevel_Up").XValueMember = SetChart.columnX
        Chart1.Series("WaterLevel_Up").LegendText = "ระดับน้ำเหนือน้ำ"
        Chart1.Legends.Add("WaterLevel_Up")
        Chart1.Legends.Item("WaterLevel_Up").Alignment = StringAlignment.Far
        Chart1.Legends.Item("WaterLevel_Up").Docking = Docking.Bottom
        Chart1.Legends.Item("WaterLevel_Up").Font = New Font("Tahoma", 8, FontStyle.Regular)
        Chart1.Series("WaterLevel_Down").Color = Color.Orange
        Chart1.Series("WaterLevel_Down").Font = New Font("Tahoma", 8, FontStyle.Bold)
        Chart1.Series("WaterLevel_Down").YValueMembers = SetChart.columnY1
        Chart1.Series("WaterLevel_Down").XValueMember = SetChart.columnX
        Chart1.Series("WaterLevel_Down").LegendText = "ระดับน้ำท้ายน้ำ"
        Chart1.Legends.Add("WaterLevel_Down")
        Chart1.Legends.Item("WaterLevel_Down").Alignment = StringAlignment.Far
        Chart1.Legends.Item("WaterLevel_Down").Docking = Docking.Bottom
        Chart1.Legends.Item("WaterLevel_Down").Font = New Font("Tahoma", 8, FontStyle.Regular)
        Chart1.DataBind()
    End Sub
    Protected Sub gdvReportYear_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvReportYear.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            ' TableCell for Header 1 
            Dim headerCell1 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell2 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell3 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell4 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell5 As TableHeaderCell = New TableHeaderCell()
            ' The TableCell's definition 
            headerCell1.ColumnSpan = 1
            headerCell1.RowSpan = 3
            headerCell1.Text = "Water Year"
            'headerCell1.BackColor = Drawing.Color.CornflowerBlue
            headerCell1.HorizontalAlign = HorizontalAlign.Center
            headerCell2.ColumnSpan = 4
            headerCell2.Text = "จุดที่ 1"
            'headerCell2.BackColor = Drawing.Color.CornflowerBlue
            headerCell2.HorizontalAlign = HorizontalAlign.Center
            headerCell3.ColumnSpan = 4
            headerCell3.Text = "จุดที่ 2"
            'headerCell3.BackColor = Drawing.Color.CornflowerBlue
            headerCell3.HorizontalAlign = HorizontalAlign.Center
            headerCell4.ColumnSpan = 1
            headerCell4.Text = "จุดที่ 1"
            'headerCell4.BackColor = Drawing.Color.CornflowerBlue
            headerCell4.HorizontalAlign = HorizontalAlign.Center
            headerCell5.ColumnSpan = 1
            headerCell5.Text = "จุดที่ 2"
            'headerCell5.BackColor = Drawing.Color.CornflowerBlue
            headerCell5.HorizontalAlign = HorizontalAlign.Center
            ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData) 
            Dim rowHeader1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader1.Cells.Add(headerCell1)
            rowHeader1.Cells.Add(headerCell2)
            rowHeader1.Cells.Add(headerCell3)
            rowHeader1.Cells.Add(headerCell4)
            rowHeader1.Cells.Add(headerCell5)
            rowHeader1.ForeColor = Drawing.Color.White
            rowHeader1.Font.Bold = True
            rowHeader1.Visible = True
            gdvReportYear.Controls(0).Controls.AddAt(0, rowHeader1)

            ' TableCell for Header 2 
            Dim fields2 As TableCellCollection = e.Row.Cells
            Dim headerCell11 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell12 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell13 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell14 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell15 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell16 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell17 As TableHeaderCell = New TableHeaderCell()
            headerCell11.ColumnSpan = 2
            headerCell11.Text = "Max. Gage Height - m"
            'headerCell11.BackColor = Drawing.Color.CornflowerBlue
            headerCell12.ColumnSpan = 2
            headerCell12.Text = "Min. Gage Height - m"
            'headerCell12.BackColor = Drawing.Color.CornflowerBlue
            headerCell13.ColumnSpan = 2
            headerCell13.Text = "Max. Gage Height - m"
            'headerCell13.BackColor = Drawing.Color.CornflowerBlue
            headerCell14.ColumnSpan = 2
            headerCell14.Text = "Min. Gage Height - m"
            'headerCell14.BackColor = Drawing.Color.CornflowerBlue
            headerCell15.ColumnSpan = 1
            headerCell15.RowSpan = 2
            headerCell15.Text = "Zero Gage"
            ' headerCell15.BackColor = Drawing.Color.CornflowerBlue
            headerCell16.ColumnSpan = 1
            headerCell16.RowSpan = 2
            headerCell16.Text = "Zero Gage"
            ' headerCell16.BackColor = Drawing.Color.CornflowerBlue
        

            ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData) 
            Dim rowHeader2 As GridViewRow = New GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader2.Cells.Add(headerCell11)
            rowHeader2.Cells.Add(headerCell12)
            rowHeader2.Cells.Add(headerCell13)
            rowHeader2.Cells.Add(headerCell14)
            rowHeader2.Cells.Add(headerCell15)
            rowHeader2.Cells.Add(headerCell16)
            rowHeader2.ForeColor = Drawing.Color.White
            rowHeader2.HorizontalAlign = HorizontalAlign.Center
            rowHeader2.Visible = True
            rowHeader2.Font.Bold = True
            gdvReportYear.Controls(0).Controls.AddAt(1, rowHeader2)

            ' TableCell for Header 3 
            Dim fields3 As TableCellCollection = e.Row.Cells
            Dim headerC1 As TableHeaderCell = New TableHeaderCell()
            Dim headerC2 As TableHeaderCell = New TableHeaderCell()
            Dim headerC3 As TableHeaderCell = New TableHeaderCell()
            Dim headerC4 As TableHeaderCell = New TableHeaderCell()
            Dim headerC5 As TableHeaderCell = New TableHeaderCell()
            Dim headerC6 As TableHeaderCell = New TableHeaderCell()
            Dim headerC7 As TableHeaderCell = New TableHeaderCell()
            Dim headerC8 As TableHeaderCell = New TableHeaderCell()
            'Dim h As  = New TableHeaderCell

            headerC1.ColumnSpan = 1

            headerC1.Text = "MSL."
            'headerC1.BackColor = Drawing.Color.CornflowerBlue
            headerC2.ColumnSpan = 1
            headerC2.Text = "Date"
            'headerC2.BackColor = Drawing.Color.CornflowerBlue
            headerC3.ColumnSpan = 1
            headerC3.Text = "MSL."
            'headerC3.BackColor = Drawing.Color.CornflowerBlue
            headerC4.ColumnSpan = 1
            headerC4.Text = "Date"
            'headerC4.BackColor = Drawing.Color.CornflowerBlue
            headerC5.ColumnSpan = 1
            headerC5.Text = "MSL."
            'headerC5.BackColor = Drawing.Color.CornflowerBlue
            headerC6.ColumnSpan = 1
            headerC6.Text = "Date"
            'headerC6.BackColor = Drawing.Color.CornflowerBlue
            headerC7.ColumnSpan = 1
            headerC7.Text = "MSL."
            'headerC7.BackColor = Drawing.Color.CornflowerBlue
            headerC8.ColumnSpan = 1
            headerC8.Text = "Date"
            'headerC8.BackColor = Drawing.Color.CornflowerBlue
         
            ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData) 
            Dim rowHeader3 As GridViewRow = New GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader3.Cells.Add(headerC1)
            rowHeader3.Cells.Add(headerC2)
            rowHeader3.Cells.Add(headerC3)
            rowHeader3.Cells.Add(headerC4)
            rowHeader3.Cells.Add(headerC5)
            rowHeader3.Cells.Add(headerC6)
            rowHeader3.Cells.Add(headerC7)
            rowHeader3.Cells.Add(headerC8)
            rowHeader3.ForeColor = Drawing.Color.White
            rowHeader3.HorizontalAlign = HorizontalAlign.Center
            rowHeader3.Visible = True
            rowHeader3.Font.Bold = True
            gdvReportYear.Controls(0).Controls.AddAt(2, rowHeader3)
        End If
    End Sub
    Protected Sub gdvReportMonth_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvReportMonth.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            ' TableCell for Header 1 
            Dim headerCell1 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell2 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell3 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell4 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell5 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell6 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell7 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell8 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell9 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell10 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell11 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell12 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell13 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell14 As TableHeaderCell = New TableHeaderCell()
            ' The TableCell's definition 
            headerCell1.ColumnSpan = 1
            headerCell1.RowSpan = 2
            headerCell1.Text = "ปี"
            headerCell1.HorizontalAlign = HorizontalAlign.Center
            headerCell2.ColumnSpan = 2
            headerCell2.Text = "เม.ย."
            headerCell2.HorizontalAlign = HorizontalAlign.Center
            headerCell3.ColumnSpan = 2
            headerCell3.Text = "พ.ค."
            headerCell3.HorizontalAlign = HorizontalAlign.Center
            headerCell4.ColumnSpan = 2
            headerCell4.Text = "มิ.ย."
            headerCell4.HorizontalAlign = HorizontalAlign.Center
            headerCell5.ColumnSpan = 2
            headerCell5.Text = "ก.ค."
            headerCell5.HorizontalAlign = HorizontalAlign.Center
            headerCell6.ColumnSpan = 2
            headerCell6.Text = "ส.ค."
            headerCell6.HorizontalAlign = HorizontalAlign.Center
            headerCell7.ColumnSpan = 2
            headerCell7.Text = "ก.ย."
            headerCell7.HorizontalAlign = HorizontalAlign.Center
            headerCell8.ColumnSpan = 2
            headerCell8.Text = "ต.ค."
            headerCell8.HorizontalAlign = HorizontalAlign.Center
            headerCell9.ColumnSpan = 2
            headerCell9.Text = "พ.ย."
            headerCell9.HorizontalAlign = HorizontalAlign.Center
            headerCell10.ColumnSpan = 2
            headerCell10.Text = "ธ.ค."
            headerCell10.HorizontalAlign = HorizontalAlign.Center
            headerCell11.ColumnSpan = 2
            headerCell11.Text = "ม.ค."
            headerCell11.HorizontalAlign = HorizontalAlign.Center
            headerCell12.ColumnSpan = 2
            headerCell12.Text = "ก.พ."
            headerCell12.HorizontalAlign = HorizontalAlign.Center
            headerCell13.ColumnSpan = 2
            headerCell13.Text = "มี.ค."
            headerCell13.HorizontalAlign = HorizontalAlign.Center
            headerCell14.ColumnSpan = 2
            headerCell14.Text = "ค่าเฉลี่ย"
            headerCell14.HorizontalAlign = HorizontalAlign.Center
            ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData) 
            Dim rowHeader1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader1.Cells.Add(headerCell1)
            rowHeader1.Cells.Add(headerCell2)
            rowHeader1.Cells.Add(headerCell3)
            rowHeader1.Cells.Add(headerCell4)
            rowHeader1.Cells.Add(headerCell5)
            rowHeader1.Cells.Add(headerCell6)
            rowHeader1.Cells.Add(headerCell7)
            rowHeader1.Cells.Add(headerCell8)
            rowHeader1.Cells.Add(headerCell9)
            rowHeader1.Cells.Add(headerCell10)
            rowHeader1.Cells.Add(headerCell11)
            rowHeader1.Cells.Add(headerCell12)
            rowHeader1.Cells.Add(headerCell13)
            rowHeader1.Cells.Add(headerCell14)
            rowHeader1.ForeColor = Drawing.Color.White
            rowHeader1.Font.Bold = True
            rowHeader1.Visible = True
            gdvReportMonth.Controls(0).Controls.AddAt(0, rowHeader1)

            ' TableCell for Header 2 
            Dim fields2 As TableCellCollection = e.Row.Cells
            Dim headerC1 As TableHeaderCell = New TableHeaderCell()
            Dim headerC2 As TableHeaderCell = New TableHeaderCell()
            Dim headerC3 As TableHeaderCell = New TableHeaderCell()
            Dim headerC4 As TableHeaderCell = New TableHeaderCell()
            Dim headerC5 As TableHeaderCell = New TableHeaderCell()
            Dim headerC6 As TableHeaderCell = New TableHeaderCell()
            Dim headerC7 As TableHeaderCell = New TableHeaderCell()
            Dim headerC8 As TableHeaderCell = New TableHeaderCell()
            Dim headerC9 As TableHeaderCell = New TableHeaderCell()
            Dim headerC10 As TableHeaderCell = New TableHeaderCell()
            Dim headerC11 As TableHeaderCell = New TableHeaderCell()
            Dim headerC12 As TableHeaderCell = New TableHeaderCell()
            Dim headerC13 As TableHeaderCell = New TableHeaderCell()
            Dim headerC14 As TableHeaderCell = New TableHeaderCell()
            Dim headerC15 As TableHeaderCell = New TableHeaderCell()
            Dim headerC16 As TableHeaderCell = New TableHeaderCell()
            Dim headerC17 As TableHeaderCell = New TableHeaderCell()
            Dim headerC18 As TableHeaderCell = New TableHeaderCell()
            Dim headerC19 As TableHeaderCell = New TableHeaderCell()
            Dim headerC20 As TableHeaderCell = New TableHeaderCell()
            Dim headerC21 As TableHeaderCell = New TableHeaderCell()
            Dim headerC22 As TableHeaderCell = New TableHeaderCell()
            Dim headerC23 As TableHeaderCell = New TableHeaderCell()
            Dim headerC24 As TableHeaderCell = New TableHeaderCell()
            Dim headerC25 As TableHeaderCell = New TableHeaderCell()
            Dim headerC26 As TableHeaderCell = New TableHeaderCell()
            headerC1.ColumnSpan = 1
            headerC1.Text = "จุดที่ 1"
            headerC2.ColumnSpan = 1
            headerC2.Text = "จุดที่ 2"
            headerC3.ColumnSpan = 1
            headerC3.Text = "จุดที่ 1"
            headerC4.ColumnSpan = 1
            headerC4.Text = "จุดที่ 2"
            headerC5.ColumnSpan = 1
            headerC5.Text = "จุดที่ 1"
            headerC6.ColumnSpan = 1
            headerC6.Text = "จุดที่ 2"
            headerC7.ColumnSpan = 1
            headerC7.Text = "จุดที่ 1"
            headerC8.ColumnSpan = 1
            headerC8.Text = "จุดที่ 2"
            headerC9.ColumnSpan = 1
            headerC9.Text = "จุดที่ 1"
            headerC10.ColumnSpan = 1
            headerC10.Text = "จุดที่ 2"
            headerC11.ColumnSpan = 1
            headerC11.Text = "จุดที่ 1"
            headerC12.ColumnSpan = 1
            headerC12.Text = "จุดที่ 2"
            headerC13.ColumnSpan = 1
            headerC13.Text = "จุดที่ 1"
            headerC14.ColumnSpan = 1
            headerC14.Text = "จุดที่ 2"
            headerC5.ColumnSpan = 1
            headerC15.Text = "จุดที่ 1"
            headerC16.ColumnSpan = 1
            headerC16.Text = "จุดที่ 2"
            headerC17.ColumnSpan = 1
            headerC17.Text = "จุดที่ 1"
            headerC18.ColumnSpan = 1
            headerC18.Text = "จุดที่ 2"
            headerC19.ColumnSpan = 1
            headerC19.Text = "จุดที่ 1"
            headerC20.ColumnSpan = 1
            headerC20.Text = "จุดที่ 2"
            headerC21.ColumnSpan = 1
            headerC21.Text = "จุดที่ 1"
            headerC22.ColumnSpan = 1
            headerC22.Text = "จุดที่ 2"
            headerC23.ColumnSpan = 1
            headerC23.Text = "จุดที่ 1"
            headerC24.ColumnSpan = 1
            headerC24.Text = "จุดที่ 2"
            headerC25.ColumnSpan = 1
            headerC25.Text = "จุดที่ 1"
            headerC26.ColumnSpan = 1
            headerC26.Text = "จุดที่ 2"

            ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData) 
            Dim rowHeader2 As GridViewRow = New GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader2.Cells.Add(headerC1)
            rowHeader2.Cells.Add(headerC2)
            rowHeader2.Cells.Add(headerC3)
            rowHeader2.Cells.Add(headerC4)
            rowHeader2.Cells.Add(headerC5)
            rowHeader2.Cells.Add(headerC6)
            rowHeader2.Cells.Add(headerC7)
            rowHeader2.Cells.Add(headerC8)
            rowHeader2.Cells.Add(headerC9)
            rowHeader2.Cells.Add(headerC10)
            rowHeader2.Cells.Add(headerC11)
            rowHeader2.Cells.Add(headerC12)
            rowHeader2.Cells.Add(headerC13)
            rowHeader2.Cells.Add(headerC14)
            rowHeader2.Cells.Add(headerC15)
            rowHeader2.Cells.Add(headerC16)
            rowHeader2.Cells.Add(headerC17)
            rowHeader2.Cells.Add(headerC18)
            rowHeader2.Cells.Add(headerC19)
            rowHeader2.Cells.Add(headerC20)
            rowHeader2.Cells.Add(headerC21)
            rowHeader2.Cells.Add(headerC22)
            rowHeader2.Cells.Add(headerC23)
            rowHeader2.Cells.Add(headerC24)
            rowHeader2.Cells.Add(headerC25)
            rowHeader2.Cells.Add(headerC26)
            rowHeader2.ForeColor = Drawing.Color.White
            rowHeader2.HorizontalAlign = HorizontalAlign.Center
            rowHeader2.Visible = True
            rowHeader2.Font.Bold = True
            gdvReportMonth.Controls(0).Controls.AddAt(1, rowHeader2)
        End If
    End Sub
    Protected Sub gdvReportDay_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvReportDay.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            ' TableCell for Header 1 
            Dim headerCell1 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell2 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell3 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell4 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell5 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell6 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell7 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell8 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell9 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell10 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell11 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell12 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell13 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell14 As TableHeaderCell = New TableHeaderCell()
            ' The TableCell's definition 
            headerCell1.ColumnSpan = 1
            headerCell1.RowSpan = 2
            headerCell1.Text = "Date"
            headerCell1.HorizontalAlign = HorizontalAlign.Center
            headerCell2.ColumnSpan = 2
            headerCell2.Text = "เม.ย."
            headerCell2.HorizontalAlign = HorizontalAlign.Center
            headerCell3.ColumnSpan = 2
            headerCell3.Text = "พ.ค."
            headerCell3.HorizontalAlign = HorizontalAlign.Center
            headerCell4.ColumnSpan = 2
            headerCell4.Text = "มิ.ย."
            headerCell4.HorizontalAlign = HorizontalAlign.Center
            headerCell5.ColumnSpan = 2
            headerCell5.Text = "ก.ค."
            headerCell5.HorizontalAlign = HorizontalAlign.Center
            headerCell6.ColumnSpan = 2
            headerCell6.Text = "ส.ค."
            headerCell6.HorizontalAlign = HorizontalAlign.Center
            headerCell7.ColumnSpan = 2
            headerCell7.Text = "ก.ย."
            headerCell7.HorizontalAlign = HorizontalAlign.Center
            headerCell8.ColumnSpan = 2
            headerCell8.Text = "ต.ค."
            headerCell8.HorizontalAlign = HorizontalAlign.Center
            headerCell9.ColumnSpan = 2
            headerCell9.Text = "พ.ย."
            headerCell9.HorizontalAlign = HorizontalAlign.Center
            headerCell10.ColumnSpan = 2
            headerCell10.Text = "ธ.ค."
            headerCell10.HorizontalAlign = HorizontalAlign.Center
            headerCell11.ColumnSpan = 2
            headerCell11.Text = "ม.ค."
            headerCell11.HorizontalAlign = HorizontalAlign.Center
            headerCell12.ColumnSpan = 2
            headerCell12.Text = "ก.พ."
            headerCell12.HorizontalAlign = HorizontalAlign.Center
            headerCell13.ColumnSpan = 2
            headerCell13.Text = "มี.ค."
            headerCell13.HorizontalAlign = HorizontalAlign.Center
            headerCell14.ColumnSpan = 2
            headerCell14.Text = "Annual"
            headerCell14.HorizontalAlign = HorizontalAlign.Center
            ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData) 
            Dim rowHeader1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader1.Cells.Add(headerCell1)
            rowHeader1.Cells.Add(headerCell2)
            rowHeader1.Cells.Add(headerCell3)
            rowHeader1.Cells.Add(headerCell4)
            rowHeader1.Cells.Add(headerCell5)
            rowHeader1.Cells.Add(headerCell6)
            rowHeader1.Cells.Add(headerCell7)
            rowHeader1.Cells.Add(headerCell8)
            rowHeader1.Cells.Add(headerCell9)
            rowHeader1.Cells.Add(headerCell10)
            rowHeader1.Cells.Add(headerCell11)
            rowHeader1.Cells.Add(headerCell12)
            rowHeader1.Cells.Add(headerCell13)
            rowHeader1.Cells.Add(headerCell14)
            rowHeader1.ForeColor = Drawing.Color.White
            rowHeader1.Font.Bold = True
            rowHeader1.Visible = True
            gdvReportDay.Controls(0).Controls.AddAt(0, rowHeader1)

            ' TableCell for Header 2 
            Dim fields2 As TableCellCollection = e.Row.Cells
            Dim headerC1 As TableHeaderCell = New TableHeaderCell()
            Dim headerC2 As TableHeaderCell = New TableHeaderCell()
            Dim headerC3 As TableHeaderCell = New TableHeaderCell()
            Dim headerC4 As TableHeaderCell = New TableHeaderCell()
            Dim headerC5 As TableHeaderCell = New TableHeaderCell()
            Dim headerC6 As TableHeaderCell = New TableHeaderCell()
            Dim headerC7 As TableHeaderCell = New TableHeaderCell()
            Dim headerC8 As TableHeaderCell = New TableHeaderCell()
            Dim headerC9 As TableHeaderCell = New TableHeaderCell()
            Dim headerC10 As TableHeaderCell = New TableHeaderCell()
            Dim headerC11 As TableHeaderCell = New TableHeaderCell()
            Dim headerC12 As TableHeaderCell = New TableHeaderCell()
            Dim headerC13 As TableHeaderCell = New TableHeaderCell()
            Dim headerC14 As TableHeaderCell = New TableHeaderCell()
            Dim headerC15 As TableHeaderCell = New TableHeaderCell()
            Dim headerC16 As TableHeaderCell = New TableHeaderCell()
            Dim headerC17 As TableHeaderCell = New TableHeaderCell()
            Dim headerC18 As TableHeaderCell = New TableHeaderCell()
            Dim headerC19 As TableHeaderCell = New TableHeaderCell()
            Dim headerC20 As TableHeaderCell = New TableHeaderCell()
            Dim headerC21 As TableHeaderCell = New TableHeaderCell()
            Dim headerC22 As TableHeaderCell = New TableHeaderCell()
            Dim headerC23 As TableHeaderCell = New TableHeaderCell()
            Dim headerC24 As TableHeaderCell = New TableHeaderCell()
            Dim headerC25 As TableHeaderCell = New TableHeaderCell()
            Dim headerC26 As TableHeaderCell = New TableHeaderCell()
            headerC1.ColumnSpan = 1
            headerC1.Text = "จุดที่ 1"
            headerC2.ColumnSpan = 1
            headerC2.Text = "จุดที่ 2"
            headerC3.ColumnSpan = 1
            headerC3.Text = "จุดที่ 1"
            headerC4.ColumnSpan = 1
            headerC4.Text = "จุดที่ 2"
            headerC5.ColumnSpan = 1
            headerC5.Text = "จุดที่ 1"
            headerC6.ColumnSpan = 1
            headerC6.Text = "จุดที่ 2"
            headerC7.ColumnSpan = 1
            headerC7.Text = "จุดที่ 1"
            headerC8.ColumnSpan = 1
            headerC8.Text = "จุดที่ 2"
            headerC9.ColumnSpan = 1
            headerC9.Text = "จุดที่ 1"
            headerC10.ColumnSpan = 1
            headerC10.Text = "จุดที่ 2"
            headerC11.ColumnSpan = 1
            headerC11.Text = "จุดที่ 1"
            headerC12.ColumnSpan = 1
            headerC12.Text = "จุดที่ 2"
            headerC13.ColumnSpan = 1
            headerC13.Text = "จุดที่ 1"
            headerC14.ColumnSpan = 1
            headerC14.Text = "จุดที่ 2"
            headerC15.ColumnSpan = 1
            headerC15.Text = "จุดที่ 1"
            headerC16.ColumnSpan = 1
            headerC16.Text = "จุดที่ 2"
            headerC17.ColumnSpan = 1
            headerC17.Text = "จุดที่ 1"
            headerC18.ColumnSpan = 1
            headerC18.Text = "จุดที่ 2"
            headerC19.ColumnSpan = 1
            headerC19.Text = "จุดที่ 1"
            headerC20.ColumnSpan = 1
            headerC20.Text = "จุดที่ 2"
            headerC21.ColumnSpan = 1
            headerC21.Text = "จุดที่ 1"
            headerC22.ColumnSpan = 1
            headerC22.Text = "จุดที่ 2"
            headerC23.ColumnSpan = 1
            headerC23.Text = "จุดที่ 1"
            headerC24.ColumnSpan = 1
            headerC24.Text = "จุดที่ 2"
            headerC25.ColumnSpan = 1
            headerC25.Text = "จุดที่ 1"
            headerC26.ColumnSpan = 1
            headerC26.Text = "จุดที่ 2"

            ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData) 
            Dim rowHeader2 As GridViewRow = New GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader2.Cells.Add(headerC1)
            rowHeader2.Cells.Add(headerC2)
            rowHeader2.Cells.Add(headerC3)
            rowHeader2.Cells.Add(headerC4)
            rowHeader2.Cells.Add(headerC5)
            rowHeader2.Cells.Add(headerC6)
            rowHeader2.Cells.Add(headerC7)
            rowHeader2.Cells.Add(headerC8)
            rowHeader2.Cells.Add(headerC9)
            rowHeader2.Cells.Add(headerC10)
            rowHeader2.Cells.Add(headerC11)
            rowHeader2.Cells.Add(headerC12)
            rowHeader2.Cells.Add(headerC13)
            rowHeader2.Cells.Add(headerC14)
            rowHeader2.Cells.Add(headerC15)
            rowHeader2.Cells.Add(headerC16)
            rowHeader2.Cells.Add(headerC17)
            rowHeader2.Cells.Add(headerC18)
            rowHeader2.Cells.Add(headerC19)
            rowHeader2.Cells.Add(headerC20)
            rowHeader2.Cells.Add(headerC21)
            rowHeader2.Cells.Add(headerC22)
            rowHeader2.Cells.Add(headerC23)
            rowHeader2.Cells.Add(headerC24)
            rowHeader2.Cells.Add(headerC25)
            rowHeader2.Cells.Add(headerC26)
            rowHeader2.ForeColor = Drawing.Color.White
            rowHeader2.HorizontalAlign = HorizontalAlign.Center
            rowHeader2.Visible = True
            rowHeader2.Font.Bold = True
            gdvReportDay.Controls(0).Controls.AddAt(1, rowHeader2)
        End If
    End Sub
    Protected Sub gdvReportHour_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvReportHour.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim header1 As TableHeaderCell = New TableHeaderCell()
            Dim header2 As TableHeaderCell = New TableHeaderCell()
            ' The TableCell's definition 
            header1.ColumnSpan = 49
            header1.Text = "Time and Gage Height in Meter(A.D.)"
            header1.HorizontalAlign = HorizontalAlign.Center
            header2.ColumnSpan = 10
            header2.Text = "Gage Height in Meter(MSL.)"
            header2.HorizontalAlign = HorizontalAlign.Center
            Dim rowHeader1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader1.Cells.Add(header1)
            rowHeader1.Cells.Add(header2)
            rowHeader1.ForeColor = Drawing.Color.White
            rowHeader1.Font.Bold = True
            rowHeader1.Visible = True
            gdvReportHour.Controls(0).Controls.AddAt(0, rowHeader1)

            ' TableCell for Header 2 
            Dim headerCell0 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell1 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell2 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell3 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell4 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell5 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell6 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell7 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell8 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell9 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell10 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell11 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell12 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell13 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell14 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell15 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell16 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell17 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell18 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell19 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell20 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell21 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell22 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell23 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell24 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell25 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell26 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell27 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell28 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell29 As TableHeaderCell = New TableHeaderCell()
            Dim headerCell30 As TableHeaderCell = New TableHeaderCell()
            ' The TableCell's definition 
            headerCell0.ColumnSpan = 1
            headerCell0.RowSpan = 2
            headerCell0.Text = "Date"
            headerCell1.HorizontalAlign = HorizontalAlign.Center
            headerCell1.ColumnSpan = 2
            headerCell1.Text = "00:00"
            headerCell1.HorizontalAlign = HorizontalAlign.Center
            headerCell2.ColumnSpan = 2
            headerCell2.Text = "01:00"
            headerCell2.HorizontalAlign = HorizontalAlign.Center
            headerCell3.ColumnSpan = 2
            headerCell3.Text = "02:00"
            headerCell3.HorizontalAlign = HorizontalAlign.Center
            headerCell4.ColumnSpan = 2
            headerCell4.Text = "03:00"
            headerCell4.HorizontalAlign = HorizontalAlign.Center
            headerCell5.ColumnSpan = 2
            headerCell5.Text = "04:00"
            headerCell5.HorizontalAlign = HorizontalAlign.Center
            headerCell6.ColumnSpan = 2
            headerCell6.Text = "05:00"
            headerCell6.HorizontalAlign = HorizontalAlign.Center
            headerCell7.ColumnSpan = 2
            headerCell7.Text = "06:00"
            headerCell7.HorizontalAlign = HorizontalAlign.Center
            headerCell8.ColumnSpan = 2
            headerCell8.Text = "07:00"
            headerCell8.HorizontalAlign = HorizontalAlign.Center
            headerCell9.ColumnSpan = 2
            headerCell9.Text = "08:00"
            headerCell9.HorizontalAlign = HorizontalAlign.Center
            headerCell10.ColumnSpan = 2
            headerCell10.Text = "09:00"
            headerCell10.HorizontalAlign = HorizontalAlign.Center
            headerCell11.ColumnSpan = 2
            headerCell11.Text = "10:00"
            headerCell11.HorizontalAlign = HorizontalAlign.Center
            headerCell12.ColumnSpan = 2
            headerCell12.Text = "11:00"
            headerCell12.HorizontalAlign = HorizontalAlign.Center
            headerCell13.ColumnSpan = 2
            headerCell13.Text = "12:00"
            headerCell13.HorizontalAlign = HorizontalAlign.Center
            headerCell14.ColumnSpan = 2
            headerCell14.Text = "13:00"
            headerCell14.HorizontalAlign = HorizontalAlign.Center
            headerCell15.ColumnSpan = 2
            headerCell15.Text = "14:00"
            headerCell15.HorizontalAlign = HorizontalAlign.Center
            headerCell16.ColumnSpan = 2
            headerCell16.Text = "15:00"
            headerCell16.HorizontalAlign = HorizontalAlign.Center
            headerCell17.ColumnSpan = 2
            headerCell17.Text = "16:00"
            headerCell17.HorizontalAlign = HorizontalAlign.Center
            headerCell18.ColumnSpan = 2
            headerCell18.Text = "17:00"
            headerCell18.HorizontalAlign = HorizontalAlign.Center
            headerCell19.ColumnSpan = 2
            headerCell19.Text = "18:00"
            headerCell19.HorizontalAlign = HorizontalAlign.Center
            headerCell20.ColumnSpan = 2
            headerCell20.Text = "19:00"
            headerCell20.HorizontalAlign = HorizontalAlign.Center
            headerCell21.ColumnSpan = 2
            headerCell21.Text = "20:00"
            headerCell21.HorizontalAlign = HorizontalAlign.Center
            headerCell22.ColumnSpan = 2
            headerCell22.Text = "21:00"
            headerCell22.HorizontalAlign = HorizontalAlign.Center
            headerCell23.ColumnSpan = 2
            headerCell23.Text = "22:00"
            headerCell23.HorizontalAlign = HorizontalAlign.Center
            headerCell24.ColumnSpan = 2
            headerCell24.Text = "23:00"
            headerCell24.HorizontalAlign = HorizontalAlign.Center
            headerCell25.ColumnSpan = 2
            headerCell25.Text = "Mean"
            headerCell25.HorizontalAlign = HorizontalAlign.Center
            headerCell26.ColumnSpan = 2
            headerCell26.Text = "Max"
            headerCell26.HorizontalAlign = HorizontalAlign.Center
            headerCell27.ColumnSpan = 2
            headerCell27.Text = "Time"
            headerCell27.HorizontalAlign = HorizontalAlign.Center
            headerCell28.ColumnSpan = 2
            headerCell28.Text = "Min"
            headerCell28.HorizontalAlign = HorizontalAlign.Center
            headerCell29.ColumnSpan = 2
            headerCell29.Text = "Time"
            headerCell29.HorizontalAlign = HorizontalAlign.Center
            ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData) 
            Dim rowHeader2 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader2.Cells.Add(headerCell0)
            rowHeader2.Cells.Add(headerCell1)
            rowHeader2.Cells.Add(headerCell2)
            rowHeader2.Cells.Add(headerCell3)
            rowHeader2.Cells.Add(headerCell4)
            rowHeader2.Cells.Add(headerCell5)
            rowHeader2.Cells.Add(headerCell6)
            rowHeader2.Cells.Add(headerCell7)
            rowHeader2.Cells.Add(headerCell8)
            rowHeader2.Cells.Add(headerCell9)
            rowHeader2.Cells.Add(headerCell10)
            rowHeader2.Cells.Add(headerCell11)
            rowHeader2.Cells.Add(headerCell12)
            rowHeader2.Cells.Add(headerCell13)
            rowHeader2.Cells.Add(headerCell14)
            rowHeader2.Cells.Add(headerCell15)
            rowHeader2.Cells.Add(headerCell16)
            rowHeader2.Cells.Add(headerCell17)
            rowHeader2.Cells.Add(headerCell18)
            rowHeader2.Cells.Add(headerCell19)
            rowHeader2.Cells.Add(headerCell20)
            rowHeader2.Cells.Add(headerCell21)
            rowHeader2.Cells.Add(headerCell22)
            rowHeader2.Cells.Add(headerCell23)
            rowHeader2.Cells.Add(headerCell24)
            rowHeader2.Cells.Add(headerCell25)
            rowHeader2.Cells.Add(headerCell26)
            rowHeader2.Cells.Add(headerCell27)
            rowHeader2.Cells.Add(headerCell28)
            rowHeader2.Cells.Add(headerCell29)
            rowHeader2.ForeColor = Drawing.Color.White
            rowHeader2.Font.Bold = True
            rowHeader2.Visible = True
            gdvReportHour.Controls(0).Controls.AddAt(1, rowHeader2)

            ' TableCell for Header 2 
            Dim headerC1 As TableHeaderCell = New TableHeaderCell()
            Dim headerC2 As TableHeaderCell = New TableHeaderCell()
            Dim headerC3 As TableHeaderCell = New TableHeaderCell()
            Dim headerC4 As TableHeaderCell = New TableHeaderCell()
            Dim headerC5 As TableHeaderCell = New TableHeaderCell()
            Dim headerC6 As TableHeaderCell = New TableHeaderCell()
            Dim headerC7 As TableHeaderCell = New TableHeaderCell()
            Dim headerC8 As TableHeaderCell = New TableHeaderCell()
            Dim headerC9 As TableHeaderCell = New TableHeaderCell()
            Dim headerC10 As TableHeaderCell = New TableHeaderCell()
            Dim headerC11 As TableHeaderCell = New TableHeaderCell()
            Dim headerC12 As TableHeaderCell = New TableHeaderCell()
            Dim headerC13 As TableHeaderCell = New TableHeaderCell()
            Dim headerC14 As TableHeaderCell = New TableHeaderCell()
            Dim headerC15 As TableHeaderCell = New TableHeaderCell()
            Dim headerC16 As TableHeaderCell = New TableHeaderCell()
            Dim headerC17 As TableHeaderCell = New TableHeaderCell()
            Dim headerC18 As TableHeaderCell = New TableHeaderCell()
            Dim headerC19 As TableHeaderCell = New TableHeaderCell()
            Dim headerC20 As TableHeaderCell = New TableHeaderCell()
            Dim headerC21 As TableHeaderCell = New TableHeaderCell()
            Dim headerC22 As TableHeaderCell = New TableHeaderCell()
            Dim headerC23 As TableHeaderCell = New TableHeaderCell()
            Dim headerC24 As TableHeaderCell = New TableHeaderCell()
            Dim headerC25 As TableHeaderCell = New TableHeaderCell()
            Dim headerC26 As TableHeaderCell = New TableHeaderCell()
            Dim headerC27 As TableHeaderCell = New TableHeaderCell()
            Dim headerC28 As TableHeaderCell = New TableHeaderCell()
            Dim headerC29 As TableHeaderCell = New TableHeaderCell()
            Dim headerC30 As TableHeaderCell = New TableHeaderCell()
            Dim headerC31 As TableHeaderCell = New TableHeaderCell()
            Dim headerC32 As TableHeaderCell = New TableHeaderCell()
            Dim headerC33 As TableHeaderCell = New TableHeaderCell()
            Dim headerC34 As TableHeaderCell = New TableHeaderCell()
            Dim headerC35 As TableHeaderCell = New TableHeaderCell()
            Dim headerC36 As TableHeaderCell = New TableHeaderCell()
            Dim headerC37 As TableHeaderCell = New TableHeaderCell()
            Dim headerC38 As TableHeaderCell = New TableHeaderCell()
            Dim headerC39 As TableHeaderCell = New TableHeaderCell()
            Dim headerC40 As TableHeaderCell = New TableHeaderCell()
            Dim headerC41 As TableHeaderCell = New TableHeaderCell()
            Dim headerC42 As TableHeaderCell = New TableHeaderCell()
            Dim headerC43 As TableHeaderCell = New TableHeaderCell()
            Dim headerC44 As TableHeaderCell = New TableHeaderCell()
            Dim headerC45 As TableHeaderCell = New TableHeaderCell()
            Dim headerC46 As TableHeaderCell = New TableHeaderCell()
            Dim headerC47 As TableHeaderCell = New TableHeaderCell()
            Dim headerC48 As TableHeaderCell = New TableHeaderCell()
            Dim headerC49 As TableHeaderCell = New TableHeaderCell()
            Dim headerC50 As TableHeaderCell = New TableHeaderCell()
            Dim headerC51 As TableHeaderCell = New TableHeaderCell()
            Dim headerC52 As TableHeaderCell = New TableHeaderCell()
            Dim headerC53 As TableHeaderCell = New TableHeaderCell()
            Dim headerC54 As TableHeaderCell = New TableHeaderCell()
            Dim headerC55 As TableHeaderCell = New TableHeaderCell()
            Dim headerC56 As TableHeaderCell = New TableHeaderCell()
            Dim headerC57 As TableHeaderCell = New TableHeaderCell()
            Dim headerC58 As TableHeaderCell = New TableHeaderCell()
            ' The TableCell's definition 
            headerC1.ColumnSpan = 1
            headerC1.Text = "จุดที่ 1"
            headerC2.ColumnSpan = 1
            headerC2.Text = "จุดที่ 2"
            headerC3.ColumnSpan = 1
            headerC3.Text = "จุดที่ 1"
            headerC4.ColumnSpan = 1
            headerC4.Text = "จุดที่ 2"
            headerC5.ColumnSpan = 1
            headerC5.Text = "จุดที่ 1"
            headerC6.ColumnSpan = 1
            headerC6.Text = "จุดที่ 2"
            headerC7.ColumnSpan = 1
            headerC7.Text = "จุดที่ 1"
            headerC8.ColumnSpan = 1
            headerC8.Text = "จุดที่ 2"
            headerC9.ColumnSpan = 1
            headerC9.Text = "จุดที่ 1"
            headerC10.ColumnSpan = 1
            headerC10.Text = "จุดที่ 2"
            headerC11.ColumnSpan = 1
            headerC11.Text = "จุดที่ 1"
            headerC12.ColumnSpan = 1
            headerC12.Text = "จุดที่ 2"
            headerC13.ColumnSpan = 1
            headerC13.Text = "จุดที่ 1"
            headerC14.ColumnSpan = 1
            headerC14.Text = "จุดที่ 2"
            headerC15.ColumnSpan = 1
            headerC15.Text = "จุดที่ 1"
            headerC16.ColumnSpan = 1
            headerC16.Text = "จุดที่ 2"
            headerC17.ColumnSpan = 1
            headerC17.Text = "จุดที่ 1"
            headerC18.ColumnSpan = 1
            headerC18.Text = "จุดที่ 2"
            headerC19.ColumnSpan = 1
            headerC19.Text = "จุดที่ 1"
            headerC20.ColumnSpan = 1
            headerC20.Text = "จุดที่ 2"
            headerC21.ColumnSpan = 1
            headerC21.Text = "จุดที่ 1"
            headerC22.ColumnSpan = 1
            headerC22.Text = "จุดที่ 2"
            headerC23.ColumnSpan = 1
            headerC23.Text = "จุดที่ 1"
            headerC24.ColumnSpan = 1
            headerC24.Text = "จุดที่ 2"
            headerC25.ColumnSpan = 1
            headerC25.Text = "จุดที่ 1"
            headerC26.ColumnSpan = 1
            headerC26.Text = "จุดที่ 2"
            headerC27.ColumnSpan = 1
            headerC27.Text = "จุดที่ 1"
            headerC28.ColumnSpan = 1
            headerC28.Text = "จุดที่ 2"
            headerC29.ColumnSpan = 1
            headerC29.Text = "จุดที่ 1"
            headerC30.ColumnSpan = 1
            headerC30.Text = "จุดที่ 2"
            headerC31.ColumnSpan = 1
            headerC31.Text = "จุดที่ 1"
            headerC32.ColumnSpan = 1
            headerC32.Text = "จุดที่ 2"
            headerC33.ColumnSpan = 1
            headerC33.Text = "จุดที่ 1"
            headerC34.ColumnSpan = 1
            headerC34.Text = "จุดที่ 2"
            headerC35.ColumnSpan = 1
            headerC35.Text = "จุดที่ 1"
            headerC36.ColumnSpan = 1
            headerC36.Text = "จุดที่ 2"
            headerC37.ColumnSpan = 1
            headerC37.Text = "จุดที่ 1"
            headerC38.ColumnSpan = 1
            headerC38.Text = "จุดที่ 2"
            headerC39.ColumnSpan = 1
            headerC39.Text = "จุดที่ 1"
            headerC40.ColumnSpan = 1
            headerC40.Text = "จุดที่ 2"
            headerC41.ColumnSpan = 1
            headerC41.Text = "จุดที่ 1"
            headerC42.ColumnSpan = 1
            headerC42.Text = "จุดที่ 2"
            headerC43.ColumnSpan = 1
            headerC43.Text = "จุดที่ 1"
            headerC44.ColumnSpan = 1
            headerC44.Text = "จุดที่ 2"
            headerC45.ColumnSpan = 1
            headerC45.Text = "จุดที่ 1"
            headerC46.ColumnSpan = 1
            headerC46.Text = "จุดที่ 2"
            headerC47.ColumnSpan = 1
            headerC47.Text = "จุดที่ 1"
            headerC48.ColumnSpan = 1
            headerC48.Text = "จุดที่ 2"
            headerC49.ColumnSpan = 1
            headerC49.Text = "จุดที่ 1"
            headerC50.ColumnSpan = 1
            headerC50.Text = "จุดที่ 2"
            headerC51.ColumnSpan = 1
            headerC51.Text = "จุดที่ 1"
            headerC52.ColumnSpan = 1
            headerC52.Text = "จุดที่ 2"
            headerC53.ColumnSpan = 1
            headerC53.Text = "จุดที่ 1"
            headerC54.ColumnSpan = 1
            headerC54.Text = "จุดที่ 2"
            headerC55.ColumnSpan = 1
            headerC55.Text = "จุดที่ 1"
            headerC56.ColumnSpan = 1
            headerC56.Text = "จุดที่ 2"
            headerC57.ColumnSpan = 1
            headerC57.Text = "จุดที่ 1"
            headerC58.ColumnSpan = 1
            headerC58.Text = "จุดที่ 2"
            ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData) 
            Dim rowHeader3 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
            rowHeader3.Cells.Add(headerC1)
            rowHeader3.Cells.Add(headerC2)
            rowHeader3.Cells.Add(headerC3)
            rowHeader3.Cells.Add(headerC4)
            rowHeader3.Cells.Add(headerC5)
            rowHeader3.Cells.Add(headerC6)
            rowHeader3.Cells.Add(headerC7)
            rowHeader3.Cells.Add(headerC8)
            rowHeader3.Cells.Add(headerC9)
            rowHeader3.Cells.Add(headerC10)
            rowHeader3.Cells.Add(headerC11)
            rowHeader3.Cells.Add(headerC12)
            rowHeader3.Cells.Add(headerC13)
            rowHeader3.Cells.Add(headerC14)
            rowHeader3.Cells.Add(headerC15)
            rowHeader3.Cells.Add(headerC16)
            rowHeader3.Cells.Add(headerC17)
            rowHeader3.Cells.Add(headerC18)
            rowHeader3.Cells.Add(headerC19)
            rowHeader3.Cells.Add(headerC20)
            rowHeader3.Cells.Add(headerC21)
            rowHeader3.Cells.Add(headerC22)
            rowHeader3.Cells.Add(headerC23)
            rowHeader3.Cells.Add(headerC24)
            rowHeader3.Cells.Add(headerC25)
            rowHeader3.Cells.Add(headerC26)
            rowHeader3.Cells.Add(headerC27)
            rowHeader3.Cells.Add(headerC28)
            rowHeader3.Cells.Add(headerC29)
            rowHeader3.Cells.Add(headerC30)
            rowHeader3.Cells.Add(headerC31)
            rowHeader3.Cells.Add(headerC32)
            rowHeader3.Cells.Add(headerC33)
            rowHeader3.Cells.Add(headerC34)
            rowHeader3.Cells.Add(headerC35)
            rowHeader3.Cells.Add(headerC36)
            rowHeader3.Cells.Add(headerC37)
            rowHeader3.Cells.Add(headerC38)
            rowHeader3.Cells.Add(headerC39)
            rowHeader3.Cells.Add(headerC40)
            rowHeader3.Cells.Add(headerC41)
            rowHeader3.Cells.Add(headerC42)
            rowHeader3.Cells.Add(headerC43)
            rowHeader3.Cells.Add(headerC44)
            rowHeader3.Cells.Add(headerC45)
            rowHeader3.Cells.Add(headerC46)
            rowHeader3.Cells.Add(headerC47)
            rowHeader3.Cells.Add(headerC48)
            rowHeader3.Cells.Add(headerC49)
            rowHeader3.Cells.Add(headerC50)
            rowHeader3.Cells.Add(headerC51)
            rowHeader3.Cells.Add(headerC52)
            rowHeader3.Cells.Add(headerC53)
            rowHeader3.Cells.Add(headerC54)
            rowHeader3.Cells.Add(headerC55)
            rowHeader3.Cells.Add(headerC56)
            rowHeader3.Cells.Add(headerC57)
            rowHeader3.Cells.Add(headerC58)
            rowHeader3.ForeColor = Drawing.Color.White
            rowHeader3.Font.Bold = True
            rowHeader3.Visible = True
            gdvReportHour.Controls(0).Controls.AddAt(2, rowHeader3)
        End If
    End Sub


End Class
