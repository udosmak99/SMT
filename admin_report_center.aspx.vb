Imports System.Data

Partial Class admin_report_center
    Inherits System.Web.UI.Page
    Dim stn As String
    Dim tblName As String
    'Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    '    Try
    '        If Not (IsPostBack) Then
    '            Session("success") = "false"
    '            SetControl()
    '            If Not (Session("reports") Is Nothing) Then
    '                CryReport.ReportSource = Session("reports")
    '            End If
    '        Else
    '            If Session("success") = "true" Then
    '                CryReport.ReportSource = Session("reports")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw New Exception("Page_Load Error : " & ex.Message)
    '    End Try
    'End Sub
    Public Sub SetControl()
        setZone()
        setBasin()
        setProvince()
        setStn()
        txtDay.Text = Now.ToString("dd/MM/yyyy", GolbalFunc.EN.DateTimeFormat)
        txtMonth.Text = Now.ToString("MM/yyyy", GolbalFunc.EN.DateTimeFormat)
        txtYear.Text = Now.ToString("yyyy", GolbalFunc.EN.DateTimeFormat)
        btnShow.Enabled = False
    End Sub
    Protected Sub ddlGroup_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged
        SetControl()
        If ddlGroup.SelectedValue = 1 Then
            mtvGroup.ActiveViewIndex = 0
        ElseIf ddlGroup.SelectedValue = 2 Then
            mtvGroup.ActiveViewIndex = 1
        ElseIf ddlGroup.SelectedValue = 3 Then
            mtvGroup.ActiveViewIndex = 2
        End If
    End Sub
    Private Sub setStn()
        ddlStn.Items.Clear()
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกสถานี--"
        ddlStn.Items.Add(listP)
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
    Protected Sub btnShow_Click(sender As Object, e As System.EventArgs) Handles btnShow.Click
        Session("success") = "true"
        CheckCondition()
        If Session("success") = "true" Then
            CryReport.ReportSource = Session("reports")
        End If
    End Sub

    Public Sub CheckCondition()
        Try
            stn = ddlStn.SelectedValue
            Dim dtrow As DataRow = smtModel.getTableName(stn)
            tblName = dtrow.Item("table_name")
            'Dim water_sensor As Integer = dtrow.Item("water_sensor")
            Dim type As Integer = ddlType.SelectedValue
            Dim condition As Integer = ddlCondition.SelectedValue
            If type = 1 Then
                Select Case condition
                    Case 1
                        Session("reports") = RainDay()
                    Case 2
                        Session("reports") = RainMonth()
                    Case 3
                        Session("reports") = RainYear()
                End Select
            ElseIf type = 2 Then
                Select Case condition
                    Case 1
                        Session("reports") = WaterlevelTran()
                    Case 2
                        Session("reports") = WaterlevelHour()
                    Case 3
                        Session("reports") = WaterlevelDay2()
                End Select
            End If
            If Not (Session("reports") Is Nothing) Then
                CryReport.ReportSource = Session("reports")
            End If
        Catch ex As Exception
            Throw New Exception("CheckCondition Error : " & ex.Message)
        End Try
    End Sub
    Private Function RainYear() As clsRPT
        Dim RY As New clsRainYearControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtYear.Text.Split("/")                '05/11/2013
        Dim Year As Integer = txtYear.Text  'CInt(dtm(2))
        Return RY.Report(stnCode, Year, tblName)
    End Function

    Private Function RainMonth() As clsRPT
        Dim RM As New clsRainMonthControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtMonth.Text.Split("/")                '05/11/2013
        Dim month As Integer = CInt(dtm(0))
        Dim year As Integer = CInt(dtm(1))
        Return RM.Report(stnCode, month, year, tblName)
    End Function

    Private Function RainDay() As clsRPT
        Dim RD As New clsRainDayControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtDay.Text.Split("/")
        Dim day As Integer = CInt(dtm(0))
        Dim month As Integer = CInt(dtm(1))
        Dim year As Integer = CInt(dtm(2))
        Return RD.Report(stnCode, day, month, year, tblName)
    End Function
    Private Function WaterlevelTran() As clsRPT
        Dim WT As New clsWLTranControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtDay.Text.Split("/")
        Dim day As Integer = CInt(dtm(0))
        Dim month As Integer = CInt(dtm(1))
        Dim year As Integer = CInt(dtm(2))
        Return WT.Report(stnCode, day, month, year, tblName)
    End Function
    Private Function WaterlevelHour() As clsRPT
        Dim WH As New clsWLHourControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtDay.Text.Split("/")
        Dim day As Integer = CInt(dtm(0))
        Dim month As Integer = CInt(dtm(1))
        Dim year As Integer = CInt(dtm(2))
        Return WH.Report(stnCode, day, month, year, tblName)
    End Function
    Private Function WaterlevelDay2() As clsRPT
        Dim WD2 As New clsWLDayControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtMonth.Text.Split("/")
        Dim month As Integer = CInt(dtm(0))
        Dim year As Integer = CInt(dtm(1))
        Return WD2.Report(stnCode, month, year, tblName)
    End Function

    Protected Sub ddlCondition_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCondition.SelectedIndexChanged
        If ddlType.SelectedValue = 1 Then
            If ddlCondition.SelectedValue = 1 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 2 Then
                mtvMain.ActiveViewIndex = 1
            ElseIf ddlCondition.SelectedValue = 3 Then
                mtvMain.ActiveViewIndex = 2
            End If
        ElseIf ddlType.SelectedValue = 2 Then
            If ddlCondition.SelectedValue = 1 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 2 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 3 Then
                mtvMain.ActiveViewIndex = 1
            End If
        End If
    End Sub

    Protected Sub ddlStn_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlStn.SelectedIndexChanged
        If ddlStn.SelectedValue = "0" Then
            btnShow.Enabled = False
        Else
            btnShow.Enabled = True
        End If
    End Sub

    Protected Sub ddlType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlType.SelectedIndexChanged
        If ddlType.SelectedValue = 1 Then
            If ddlCondition.SelectedValue = 1 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 2 Then
                mtvMain.ActiveViewIndex = 1
            ElseIf ddlCondition.SelectedValue = 3 Then
                mtvMain.ActiveViewIndex = 2
            End If
        ElseIf ddlType.SelectedValue = 2 Then
            If ddlCondition.SelectedValue = 1 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 2 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 3 Then
                mtvMain.ActiveViewIndex = 1
            End If
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then     'DD-MM-YYYY HH24:MI:SS
            Session("success") = "false"
            SetControl()
            If Not (Session("reports") Is Nothing) Then
                CryReport.ReportSource = Session("reports")
            End If
            Dim tblStn As System.Data.DataTable = clsModel.GetLastData()
            Dim StationInfo(tblStn.Rows.Count - 1, 26) As Object
            Dim CountStation(0, 5) As Object
            Dim stationdata As New Generic.List(Of clsLastdata)
            Dim url As String
            Dim i As Integer
            Dim countcritical_new, countcritical_old, countwarning_new, countwarning_old, countnormal_new, countnormal_old As Integer
            countnormal_new = 0
            countcritical_new = 0
            countcritical_old = 0
            countwarning_new = 0
            countwarning_old = 0
            countnormal_old = 0
            Try
                Dim dtrow As Data.DataRow
                Dim stndata As New clsLastdata
                For Each dtrow In tblStn.Rows

                    stndata.station_id = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("station_id")))
                    stndata.station_name = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("station_name")))
                    stndata.group_name = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("group_name")))
                    stndata.group_id = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("group_id")))
                    stndata.wl_up = CStr(GolbalFunc.Validation.NulltoZero(dtrow.Item("wl_up")))
                    stndata.wl_down = CStr(GolbalFunc.Validation.NulltoZero(dtrow.Item("wl_down")))
                    stndata.zeroguage = "15"
                    stndata.rf15 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("rf15")))
                    stndata.rf_7to7 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("rf_7to7")))
                    stndata.rf_7tonow = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("rf_7tonow")))
                    stndata.lat = CDbl(NulltoLat(dtrow.Item("station_lattitude")))
                    stndata.longtitude = CDbl(NulltoLong(dtrow.Item("station_longitude")))
                    stndata.basin_id = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("basin_id")))
                    stndata.basin_name = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("basin_name")))
                    stndata.province_id = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("province_id")))
                    stndata.province_name = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("province_name")))
                    stndata.gatecount = GolbalFunc.Validation.NulltoZero(dtrow.Item("gate_sensor"))
                    stndata.gate1 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_1")))
                    stndata.gate2 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_2")))
                    stndata.gate3 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_3")))
                    stndata.gate4 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_4")))
                    stndata.gate5 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_5")))
                    stndata.gate6 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_6")))
                    stndata.gate7 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_7")))
                    stndata.station_code = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("station_id_customer")))
                    stndata.warning_up = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("warning_up")))
                    stndata.warning_down = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("warning_down")))
                    stndata.critical_up = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("critical_up")))
                    stndata.critical_down = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("critical_down")))
                    stationdata.Add(stndata)
                    StationInfo(i, 0) = stndata.station_id
                    StationInfo(i, 1) = stndata.station_name
                    StationInfo(i, 2) = stndata.group_name
                    StationInfo(i, 3) = stndata.group_id
                    StationInfo(i, 4) = stndata.wl_up
                    StationInfo(i, 5) = stndata.wl_down
                    StationInfo(i, 6) = stndata.rf15
                    StationInfo(i, 7) = stndata.rf_7to7
                    StationInfo(i, 8) = stndata.rf_7tonow
                    StationInfo(i, 9) = stndata.lat
                    StationInfo(i, 10) = stndata.longtitude
                    StationInfo(i, 11) = stndata.basin_id
                    StationInfo(i, 12) = stndata.basin_name
                    StationInfo(i, 13) = stndata.province_id
                    StationInfo(i, 14) = stndata.province_name
                    Dim seticon As String
                    If stndata.group_id = "1" Or stndata.group_id = "2" Or stndata.group_id = "3" Then
                        If CDbl(stndata.wl_up) >= CDbl(stndata.critical_up) Or CDbl(stndata.wl_down) >= CDbl(stndata.critical_down) Then
                            seticon = "03"
                            countcritical_new = countcritical_new + 1
                        ElseIf CDbl(stndata.wl_up) >= CDbl(stndata.warning_up) Or CDbl(stndata.wl_down) >= CDbl(stndata.warning_down) Then
                            seticon = "02"
                            countwarning_new = countwarning_new + 1
                        Else
                            seticon = "01"
                            countnormal_new = countnormal_new + 1
                        End If


                        url = "href='DetailStation.aspx?CODE=" & stndata.station_id & "'"
                    ElseIf stndata.group_id = "4" Then

                        If CDbl(stndata.wl_up) >= CDbl(stndata.critical_up) Or CDbl(stndata.wl_down) >= CDbl(stndata.critical_down) Then
                            seticon = "13"
                            countcritical_old = countcritical_old + 1
                        ElseIf CDbl(stndata.wl_up) >= CDbl(stndata.warning_up) Or CDbl(stndata.wl_down) >= CDbl(stndata.warning_down) Then
                            seticon = "12"
                            countwarning_old = countwarning_old + 1
                        Else
                            seticon = "11"
                            countnormal_old = countnormal_old + 1
                        End If

                        url = "href='http://122.155.12.58/' onclick='javascript:openNewWindow(this.href);return false;'"
                    End If
                    StationInfo(i, 15) = seticon
                    StationInfo(i, 16) = stndata.zeroguage
                    StationInfo(i, 17) = stndata.gatecount
                    StationInfo(i, 18) = stndata.gate1
                    StationInfo(i, 19) = stndata.gate2
                    StationInfo(i, 20) = stndata.gate3
                    StationInfo(i, 21) = stndata.gate4
                    StationInfo(i, 22) = stndata.gate5
                    StationInfo(i, 23) = stndata.gate6
                    StationInfo(i, 24) = stndata.gate7
                    StationInfo(i, 25) = url
                    StationInfo(i, 26) = stndata.station_code
                    i = i + 1
                Next
                CountStation(0, 0) = countnormal_new
                CountStation(0, 1) = countnormal_old
                CountStation(0, 2) = countwarning_new
                CountStation(0, 3) = countwarning_old
                CountStation(0, 4) = countcritical_new
                CountStation(0, 5) = countcritical_old
            Catch ex As Exception
                Throw New Exception("Liststation Error :" & ex.Message)
            End Try
            Session("wStation") = StationInfo
            Session("Icon") = CountStation
        Else
            If Session("success") = "true" Then
                CryReport.ReportSource = Session("reports")
            End If
        End If
    End Sub
    Public Function NulltoLat(ByVal msg As Object) As Object
        If msg Is DBNull.Value Then
            Return "14.050905707724784"
        Else
            Return msg
        End If
    End Function
    Public Function NulltoLong(ByVal msg As Object) As Object
        If msg Is DBNull.Value Then
            Return "100.61279296875"
        Else
            Return msg
        End If
    End Function
End Class
