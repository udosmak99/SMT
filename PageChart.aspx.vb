Imports System.Globalization
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Data
Partial Class PageChart
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'bindData()
        ' bindDataGrid()
        If Not (IsPostBack) Then
            initial()
            Binding()
        End If
        

    End Sub
    Sub bindDataGrid()
        Dim tblDataStationGrid As System.Data.DataTable = clsModel.GetStationData(Request.QueryString("CODE"))
        Dim Station_Grid As New Generic.List(Of clsDataStation)
        Dim i As Integer
        Try
            Dim dtrow As Data.DataRow
            Dim stndata_grid As New clsDataStation
            For Each dtrow In tblDataStationGrid.Rows
                stndata_grid.server_time = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("server_time")))

            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub bindData()
        Dim dateshow As Date = Now
        Dim _cultureInfo As New Globalization.CultureInfo("th-TH")
        Dim datetimeshow As String = dateshow.ToString("วันddddที่ dd MMMM yyyy | HH:mm น.", _cultureInfo)
        Dim tblDataStation As System.Data.DataTable = clsModel.GetDataDataByStation("1", 2)
        Dim StationData(tblDataStation.Rows.Count - 1, 32) As Object
        Dim Station As New Generic.List(Of clsDataStation)
        Dim i As Integer
        Try
            Dim dtrow As Data.DataRow
            Dim stndata As New clsDataStation
            For Each dtrow In tblDataStation.Rows

                stndata.station_code = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("station_code")))
                stndata.address = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("address")))
                stndata.datetime_station = datetimeshow
                stndata.flow = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("flow")))
                stndata.rf15 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("rf15")))
                stndata.rf_7tonow = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("rf_7tonow")))
                stndata.rf_7to7 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("rf_7to7")))
                stndata.wl_up = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("wl_up")))
                stndata.wl_up_msl = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("wl_up_msl")))
                stndata.wl_down = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("wl_down")))
                stndata.wl_down_msl = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("wl_down_msl")))
                stndata.gatecount = GolbalFunc.Validation.NulltoZero(dtrow.Item("gate_sensor"))
                stndata.gate1 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_1")))
                stndata.gate2 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_2")))
                stndata.gate3 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_3")))
                stndata.gate4 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_4")))
                stndata.gate5 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_5")))
                stndata.gate6 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_6")))
                stndata.gate7 = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("gate_7")))
                stndata.door_status = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("door_status")))
                stndata.gas_status_up = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("air_tank_up")))
                stndata.gas_status_down = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("air_tank_down")))
                stndata.temperature = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("temp_alarm")))
                stndata.wl_up_warning = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("warning_up")))
                stndata.wl_up_critical = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("critical_up")))
                stndata.wl_down_warning = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("warning_down")))
                stndata.wl_down_critical = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("critical_down")))
                stndata.zerogauge_up = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("zerogate_up")))
                stndata.zerogauge_down = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("zerogate_down")))
                stndata.left_bank_wl_up = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("left_bank_wl_up")))
                stndata.right_bank_wl_up = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("right_bank_wl_up")))
                stndata.left_bank_wl_down = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("left_bank_wl_down")))
                stndata.right_bank_wl_down = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("right_bank_wl_down")))
                Station.Add(stndata)
                StationData(i, 0) = stndata.station_code
                StationData(i, 1) = stndata.address
                StationData(i, 2) = stndata.datetime_station
                StationData(i, 3) = stndata.rf15
                StationData(i, 4) = stndata.rf_7tonow
                StationData(i, 5) = stndata.rf_7to7
                StationData(i, 6) = stndata.wl_up
                StationData(i, 7) = stndata.wl_up_msl
                StationData(i, 8) = stndata.wl_down
                StationData(i, 9) = stndata.wl_down_msl
                StationData(i, 10) = stndata.gatecount
                StationData(i, 11) = stndata.gate1
                StationData(i, 12) = stndata.gate2
                StationData(i, 13) = stndata.gate3
                StationData(i, 14) = stndata.gate4
                StationData(i, 15) = stndata.gate5
                StationData(i, 16) = stndata.gate6
                StationData(i, 17) = stndata.gate7
                StationData(i, 18) = stndata.door_status
                StationData(i, 19) = stndata.gas_status_up
                StationData(i, 20) = stndata.gas_status_down
                StationData(i, 21) = stndata.temperature
                StationData(i, 22) = stndata.wl_up_warning
                StationData(i, 23) = stndata.wl_up_critical
                StationData(i, 24) = stndata.wl_down_warning
                StationData(i, 25) = stndata.wl_down_critical
                StationData(i, 26) = stndata.zerogauge_up
                StationData(i, 27) = stndata.zerogauge_down
                StationData(i, 28) = stndata.left_bank_wl_up
                StationData(i, 29) = stndata.right_bank_wl_up
                StationData(i, 30) = stndata.left_bank_wl_down
                StationData(i, 31) = stndata.right_bank_wl_down
                StationData(i, 32) = stndata.flow
                i = i + 1
            Next

        Catch ex As Exception
            Throw New Exception("Binddata Error :" & ex.Message)
        End Try
        Session("dataByStation") = StationData
    End Sub

    Public Sub initial()
        Dim typeuser As String
        Dim checkstatusup, checkstatusdown As String
        If Not Session("LoginDesc") Is Nothing Then
            Dim userdesc As UserItem
            userdesc = Session("LoginDesc")
            If userdesc.USER_LEVEL = UserLevel.SuperAdmin Then
                typeuser = "All"
            Else
                typeuser = "User"
            End If
        Else
            typeuser = "User"
        End If
        Dim tblStn As System.Data.DataTable = clsModel.GetLastData(typeuser)
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
                stndata.wl_up = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("wl_up")))
                stndata.wl_down = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("wl_down")))
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
                checkstatusup = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("conn_status_up")))
                checkstatusdown = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("conn_status_down")))
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


                    If checkstatusup = "-" Or checkstatusup = "1" Then
                        If checkstatusdown = "-" Or checkstatusdown = "1" Then
                            seticon = "00"
                        Else
                            If stndata.wl_down = "-" Then
                                seticon = "00"
                            Else

                                If CDbl(stndata.wl_down) >= CDbl(stndata.critical_down) Then
                                    seticon = "03"
                                    countcritical_new = countcritical_new + 1
                                ElseIf CDbl(stndata.wl_down) >= CDbl(stndata.warning_down) Then
                                    seticon = "02"
                                    countwarning_new = countwarning_new + 1
                                Else
                                    seticon = "01"
                                    countnormal_new = countnormal_new + 1
                                End If


                            End If
                        End If

                    Else
                        If stndata.wl_up = "-" Then
                            seticon = "00"
                        Else
                            If CDbl(stndata.wl_up) >= CDbl(stndata.critical_up) Then
                                seticon = "03"
                                countcritical_new = countcritical_new + 1
                            ElseIf CDbl(stndata.wl_up) >= CDbl(stndata.warning_up) Then
                                seticon = "02"
                                countwarning_new = countwarning_new + 1
                            Else
                                seticon = "01"
                                countnormal_new = countnormal_new + 1
                            End If
                        End If

                    End If
                    'countnormal_new = countnormal_new + 1


                    url = "href='PageChart.aspx?CODE=" & stndata.station_id & "&index=" & i + 1 & "'"
                ElseIf stndata.group_id = "4" Then
                    If checkstatusup = "-" Or checkstatusup = "1" Then
                        If checkstatusdown = "-" Or checkstatusdown = "1" Then
                            seticon = "10"
                        Else
                            If stndata.wl_down = "-" Then
                                seticon = "10"
                            Else

                                If CDbl(stndata.wl_down) >= CDbl(stndata.critical_down) Then
                                    seticon = "13"
                                    countcritical_old = countcritical_old + 1
                                ElseIf CDbl(stndata.wl_down) >= CDbl(stndata.warning_down) Then
                                    seticon = "12"
                                    countwarning_old = countwarning_old + 1
                                Else
                                    seticon = "11"
                                    countnormal_old = countnormal_old + 1
                                End If


                            End If
                        End If

                    Else
                        If stndata.wl_up = "-" Then
                            seticon = "10"
                        Else
                            If CDbl(stndata.wl_up) >= CDbl(stndata.critical_up) Then
                                seticon = "13"
                                countcritical_old = countcritical_old + 1
                            ElseIf CDbl(stndata.wl_up) >= CDbl(stndata.warning_up) Then
                                seticon = "12"
                                countwarning_old = countwarning_old + 1
                            Else
                                seticon = "11"
                                countnormal_old = countnormal_old + 1
                            End If
                        End If

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
        HiddenCodeNextPage.Value = Request.QueryString("CODE")
        HiddenIndex.Value = Request.QueryString("index")
        'bindStationCode()
        'If IsNothing(Request.QueryString("RELOAD")) Then
        '    txtHourStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "HH:mm")
        '    txtHourEnd.Text = GolbalFunc.ENFormat(Now, "HH:mm")
        '    TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
        '    TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")
        '    Dim dateStart As String = TxtDtmStart.Text
        '    Dim dateStop As String = TxtDtmEnd.Text
        '    dateStart &= " "
        '    dateStop &= " "
        '    dateStart &= txtHourStart.Text
        '    dateStop &= txtHourEnd.Text
        '    Session("dtstart") = dateStart
        '    Session("dtstop") = dateStop
        'Else
        '    Dim dtstart As String = Session("dtstart")
        '    Dim dtstop As String = Session("dtstop")
        '    Dim dt() As String
        '    dt = dtstart.Split(" ")
        '    TxtDtmStart.Text = dt(0)
        '    txtHourStart.Text = dt(1)
        '    dt = dtstop.Split(" ")
        '    TxtDtmEnd.Text = dt(0)
        '    txtHourEnd.Text = dt(1)
        'End If
        txtHourStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "HH:mm")
        txtHourEnd.Text = GolbalFunc.ENFormat(Now, "HH:mm")
        TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
        TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")


    End Sub
    Public Function checkstationForBind() As Integer

        Dim typewl As Integer
        Dim typerf As Integer
        Dim cmdLastData As New SqlCommand
        Dim dtaSession As New SqlDataAdapter(cmdLastData)
        Dim dtsSession As New DataSet
        Dim stncode As Integer = CInt(Request.QueryString("CODE"))
      

        Try
            cmdLastData.CommandType = CommandType.Text
            cmdLastData.CommandText = "select water_sensor,rain_sensor from dbo.tbl_station_info where station_id = " & stncode
            cmdLastData.Connection = GolbalFunc.Database.Connection
            dtaSession.Fill(dtsSession, "stationtype")
        Catch ex As Exception
        End Try
        typewl = NulltoBlank(dtsSession.Tables("stationtype").Rows(0).Item("water_sensor"))
        typerf = NulltoBlank(dtsSession.Tables("stationtype").Rows(0).Item("rain_sensor"))
        If GolbalFunc.Validation.BankToZero(typewl) >= 1 And GolbalFunc.Validation.BankToZero(typerf) >= 1 Then
            Return 1
        ElseIf GolbalFunc.Validation.BankToZero(typewl) >= 1 And GolbalFunc.Validation.BankToZero(typerf) = 0 Then
            Return 2
        ElseIf GolbalFunc.Validation.BankToZero(typewl) = 0 And GolbalFunc.Validation.BankToZero(typerf) >= 1 Then
            Return 3
        End If

    End Function
    'Sub bindStationCode()
    '    Dim cmdLastData As New SqlCommand
    '    Dim dtaSession As New SqlDataAdapter(cmdLastData)
    '    Dim dtsSession As New DataSet
    '    Try
    '        cmdLastData.CommandType = CommandType.Text
    '        cmdLastData.CommandText = "select stn_code,stn_name from tbl_conf_station"
    '        cmdLastData.Connection = GolbalFunc.Database.Connection
    '        dtaSession.Fill(dtsSession, "stationCode")
    '    Catch ex As Exception
    '    End Try
    '    For i As Integer = 0 To dtsSession.Tables("stationCode").Rows.Count - 1
    '        'DropDownList1.Items.Add(dtsSession.Tables("stationCode").Rows(i).Item("stn_code") & " " & dtsSession.Tables("stationCode").Rows(i).Item("stn_name"))
    '    Next
    'End Sub
    Private Sub Binding()
        Try
            ChartControl(checkstationForBind)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ChartControl(ByVal Type As Integer)
        Dim dateStart As String = TxtDtmStart.Text
        Dim dateStop As String = TxtDtmEnd.Text
        dateStart &= " "
        dateStop &= " "
        dateStart &= txtHourStart.Text
        dateStop &= txtHourEnd.Text
        Dim dtStartcon As Date = GolbalFunc.ThaiDatetime.ConvStrToDateTime(dateStart)
        Dim dtStopcon As Date = GolbalFunc.ThaiDatetime.ConvStrToDateTime(dateStop)
        Dim dtstart As New Date(GolbalFunc.EngDatetime.EngYear(dtStartcon), Month(dtStartcon), Day(dtStartcon), Hour(dtStartcon), Minute(dtStartcon), 0)
        Dim dtstop As New Date(GolbalFunc.EngDatetime.EngYear(dtStopcon), Month(dtStopcon), Day(dtStopcon), Hour(dtStopcon), Minute(dtStopcon), 0)
        Dim stn As New DataTable
        Dim stncodecheck As Integer = CInt(Request.QueryString("CODE"))

        stn = clsModel.GetLast24HrforChart(Type, dtstart, dtstop, stncodecheck)
        lblHeader_stncode.Text = stn.Rows(0).Item("station_id_customer")
        lblHeader_stnname.Text = stn.Rows(0).Item("station_name")
        lblHeader_address.Text = "ต. " & stn.Rows(0).Item("subdistrict_name") & " อ. " & stn.Rows(0).Item("district_name") & " จ. " & stn.Rows(0).Item("province_name")
        lblRainGraphDate.Text = GolbalFunc.ThaiDatetime.ThaiFormat(stn.Rows(0).Item("server_time"), "ข้อมูลวันที่ dd/MM/yy เวลา HH:mm น.") & GolbalFunc.ThaiDatetime.ThaiFormat(stn.Rows(stn.Rows.Count - 1).Item("server_time"), " ถึง dd/MM/yy เวลา HH:mm น.")
        lblWaterLevelGraphDate.Text = lblRainGraphDate.Text
        Dim setChart As New clsChart
        Dim setChart1 As New clsChart
        Dim setChart2 As New clsChart
        Dim index As Integer
        ' txtdateshow.Text = GolbalFunc.ThaiDatetime.ThaiFormat(stn.Rows(stn.Rows.Count - 1).Item("server_time"), "dd MMMM yyyy | HH:mm น.")
        ' lblStationName.Text = stn.Rows(stn.Rows.Count - 1).Item("stn_name")
        ' DropDownList1.SelectedValue = stn.Rows(stn.Rows.Count - 1).Item("stn_code") & " " & stn.Rows(stn.Rows.Count - 1).Item("stn_name")
        Select Case Type
            Case 1
                Chart1.Visible = True
                Chart2.Visible = True

               
                setChart.titleY = "มม."
                setChart.titleX = "วันที่-เวลา"
                setChart.myTable = stn
                setChart.columnY = "rf15"
                setChart.columnX = "server_time"
                index = 1
                'กำหนดชนิดกราฟ เป็นกราฟเส้น
                Chart1.Series("Rainfall").ChartType = DataVisualization.Charting.SeriesChartType.Column
                Chart1.Series("Rainfall").Font = New Font("Tahoma", 7, FontStyle.Bold)
                bindingChart(setChart)

                setChart1.titleY = "ม. (รทก.)"
                setChart1.titleX = "วันที่-เวลา"
                setChart1.myTable = stn
                setChart1.columnY = "wl_up"
                setChart1.columnY1 = "wl_down"
                setChart1.columnX = "server_time"
                index = 2
                'กำหนดชนิดกราฟ เป็นกราฟเส้น
                Chart2.Series("WaterLevel_Up").ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart2.Series("WaterLevel_Up").BorderWidth = 4
                Chart2.Series("WaterLevel_Up").Font = New Font("Tahoma", 7, FontStyle.Bold)
                Chart2.Series("WaterLevel_Down").ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart2.Series("WaterLevel_Down").BorderWidth = 4
                Chart2.Series("WaterLevel_Down").Font = New Font("Tahoma", 7, FontStyle.Bold)
                bindingChart2(setChart1)



            Case 2
                Chart1.Visible = False
                Chart2.Visible = True


                setChart1.titleY = "ม. (รทก.)"
                setChart1.titleX = "วันที่-เวลา"
                setChart1.myTable = stn
                setChart1.columnY = "wl_up"
                setChart1.columnX = "server_time"
                setChart1.columnY1 = "wl_down"
                index = 2
                'กำหนดชนิดกราฟ เป็นกราฟเส้น
                Chart2.Series("WaterLevel_Up").ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart2.Series("WaterLevel_Up").BorderWidth = 4
                Chart2.Series("WaterLevel_Up").Font = New Font("Tahoma", 7, FontStyle.Bold)
                Chart2.Series("WaterLevel_Down").ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart2.Series("WaterLevel_Down").BorderWidth = 4
                Chart2.Series("WaterLevel_Down").Font = New Font("Tahoma", 7, FontStyle.Bold)
                bindingChart2(setChart1)



            Case 3
                Chart1.Visible = True
                Chart2.Visible = False

                setChart.titleY = "มม."
                setChart.titleX = "วันที่-เวลา"
                setChart.myTable = stn
                setChart.columnY = "rf15"
                setChart.columnX = "server_time"
                index = 4
                'กำหนดชนิดกราฟ เป็นกราฟแท่ง
                Chart1.Series("Rainfall").ChartType = DataVisualization.Charting.SeriesChartType.Column
                Chart1.Series("Rainfall").Font = New Font("Tahoma", 7, FontStyle.Bold)
                bindingChart(setChart)
        End Select
        Session("RowCount") = stn.Rows.Count
        ViewState("sortDirection") = Nothing
        ViewState("SortingGridView") = stn
        ViewState("SortingOnly") = stn

    End Sub

    Public Function NulltoBlank(ByVal msg As Object) As Object
        If msg Is DBNull.Value Then
            Return "N"
        Else
            Return msg
        End If
    End Function
    Private Sub bindingChart(ByVal SetChart As clsChart)

        'กำหนดหัวตาราง
        Chart1.Titles.Add(SetChart.Title & "\n" & SetChart.SubTitle)
        Chart1.Titles(0).Font = New Font("Tahoma", 10, FontStyle.Bold)
        Chart1.Titles(0).ForeColor = Color.DeepSkyBlue
        Chart1.Titles(0).Alignment = System.Drawing.ContentAlignment.MiddleCenter

        'กำหนดแกน Y
        Chart1.ChartAreas("ChartArea1").AxisY.TitleAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Chart1.ChartAreas("ChartArea1").AxisY.Title = SetChart.titleY
        Chart1.ChartAreas("ChartArea1").AxisY.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart1.ChartAreas("ChartArea1").AxisY.TitleAlignment = StringAlignment.Center
        Chart1.ChartAreas("ChartArea1").AxisY.LabelStyle.Font = New Font("Tahoma", 7, FontStyle.Bold)

        'กำหนดแกน X
        Chart1.ChartAreas("ChartArea1").AxisX.TitleAlignment = System.Drawing.ContentAlignment.TopLeft
        Chart1.ChartAreas("ChartArea1").AxisX.Title = SetChart.titleX
        Chart1.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -45

        'กำหนดความถี่
        Chart1.ChartAreas("ChartArea1").AxisX.Interval = 1.5
        Chart1.ChartAreas("ChartArea1").AxisX.IntervalType = DateTimeIntervalType.Hours

        ''กำหนดรูปแบบแสดงปริมาณฝน
        Chart1.ChartAreas("ChartArea1").AxisY.LabelStyle.Font = New Font("Tahoma", 9, FontStyle.Regular)

        ''กำหนดรูปแบบเส้นในตาราง
        Chart1.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash

        'กำหนดรูปแบบการแสดงวันที่
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Format = "dd-MM-yyyy HH:mm"
        Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        Chart1.DataSource = SetChart.myTable
        Chart1.Series("Rainfall").YValueMembers = SetChart.columnY
        Chart1.Series("Rainfall").Color = Color.DeepSkyBlue
        Chart1.Series("Rainfall").Font = New Font("Tahoma", 8, FontStyle.Bold)
        Chart1.Series("Rainfall").XValueMember = SetChart.columnX
        Chart1.DataBind()
    End Sub
    Private Sub bindingChart2(ByVal SetChart1 As clsChart)

        'กำหนดหัวตาราง
        Chart2.Titles.Add(SetChart1.Title & "\n" & SetChart1.SubTitle)
        Chart2.Titles(0).Font = New Font("Tahoma", 10, FontStyle.Bold)
        Chart2.Titles(0).ForeColor = Color.DeepSkyBlue
        Chart2.Titles(0).Alignment = System.Drawing.ContentAlignment.MiddleCenter

        'กำหนดแกน Y
        Chart2.ChartAreas("ChartArea1").AxisY.TitleAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Chart2.ChartAreas("ChartArea1").AxisY.Title = SetChart1.titleY
        Chart2.ChartAreas("ChartArea1").AxisY.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart2.ChartAreas("ChartArea1").AxisY.TitleAlignment = StringAlignment.Center
        Chart2.ChartAreas("ChartArea1").AxisY.LabelStyle.Font = New Font("Tahoma", 7, FontStyle.Bold)

        'กำหนดแกน X
        Chart2.ChartAreas("ChartArea1").AxisX.TitleAlignment = System.Drawing.ContentAlignment.TopLeft
        Chart2.ChartAreas("ChartArea1").AxisX.Title = SetChart1.titleX
        Chart2.ChartAreas("ChartArea1").AxisX.TitleFont = New Font("Tahoma", 9, FontStyle.Bold)
        Chart2.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -45

        'กำหนดความถี่
        Chart2.ChartAreas("ChartArea1").AxisX.Interval = 1.5
        Chart2.ChartAreas("ChartArea1").AxisX.IntervalType = DateTimeIntervalType.Hours

        ''กำหนดรูปแบบระดับน้ำ
        Chart2.ChartAreas("ChartArea1").AxisY.LabelStyle.Font = New Font("Tahoma", 9, FontStyle.Regular)

        ''กำหนดรูปแบบเส้นในตาราง
        Chart2.ChartAreas("ChartArea1").AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        Chart2.ChartAreas("ChartArea1").AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash

        'กำหนดรูปแบบการแสดงวันที่
        Chart2.ChartAreas("ChartArea1").AxisX.LabelStyle.Format = "dd-MM-yyyy HH:mm"
        Chart2.ChartAreas("ChartArea1").AxisX.LabelStyle.Font = New Font("Tahoma", 8, FontStyle.Regular)

        Chart2.DataSource = SetChart1.myTable
        Chart2.Series("WaterLevel_Up").YValueMembers = SetChart1.columnY
        Chart2.Series("WaterLevel_Up").Color = Color.DeepSkyBlue
        Chart2.Series("WaterLevel_Up").Font = New Font("Tahoma", 8, FontStyle.Bold)
        Chart2.Series("WaterLevel_Up").XValueMember = SetChart1.columnX
        Chart2.Series("WaterLevel_Up").LegendText = "ระดับน้ำเหนือน้ำ"
        Chart2.Legends.Add("WaterLevel_Up")
        Chart2.Legends.Item("WaterLevel_Up").Alignment = StringAlignment.Far
        Chart2.Legends.Item("WaterLevel_Up").Docking = Docking.Top
        Chart2.Series("WaterLevel_Down").Color = Color.Chocolate
        Chart2.Series("WaterLevel_Down").Font = New Font("Tahoma", 8, FontStyle.Bold)
        Chart2.Series("WaterLevel_Down").YValueMembers = SetChart1.columnY1
        Chart2.Series("WaterLevel_Down").XValueMember = SetChart1.columnX
        Chart2.Series("WaterLevel_Down").LegendText = "ระดับน้ำท้ายน้ำ  "
        Chart2.Legends.Add("WaterLevel_Down")
        Chart2.Legends.Item("WaterLevel_Down").Alignment = StringAlignment.Far
        Chart2.Legends.Item("WaterLevel_Down").Docking = Docking.Top

        Chart2.DataBind()
    End Sub

    Protected Sub TxtDtmStart_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDtmStart.TextChanged
        Dim dtstarttext As String = TxtDtmStart.Text
        Dim dtStartcon As Date = GolbalFunc.ThaiDatetime.ConvStrToDateTime(TxtDtmStart.Text)
        Dim dtStopcon As Date = GolbalFunc.ThaiDatetime.ConvStrToDateTime(TxtDtmEnd.Text)
        Dim odtstart() As String
        Dim dtstart As Integer
        Dim yearstart As Integer
        odtstart = dtstarttext.Split("/")
        dtstart = odtstart(0)
        yearstart = odtstart(2)
        If odtstart(1) = "01" Or odtstart(1) = "03" Or odtstart(1) = "05" Or odtstart(1) = "07" Or odtstart(1) = "08" Or odtstart(0) = "10" Or odtstart(0) = "12" Then
            If dtstart > 31 Then
                lblalert.Text = "วันที่ไม่ถุกต้อง"
                TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
                TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")
            End If
        ElseIf odtstart(1) = "02" Then
            If (yearstart Mod 4) = 0 And (yearstart Mod 100) <> 0 Or (yearstart Mod 400) = 0 Then

                If dtstart > 0 And dtstart <= 29 Then
                Else
                    lblalert.Text = "วันที่ไม่ถุกต้อง"
                    TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
                    TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")
                End If
            Else
                If dtstart > 0 And dtstart <= 28 Then
                Else
                    lblalert.Text = "วันที่ไม่ถุกต้อง"
                    TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
                    TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")
                End If

            End If
        ElseIf odtstart(1) = "04" Or odtstart(1) = "06" Or odtstart(1) = "09" Or odtstart(1) = "11" Then
            If dtstart > 30 Then
                lblalert.Text = "วันที่ไม่ถุกต้อง"
                TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
                TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")
            End If
        End If
        'If dtStopcon <= dtStartcon Then
        '    TxtDtmEnd.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, +24, dtStartcon), "dd/MM/yyyy")
        'End If
    End Sub

    Protected Sub txtHourStart_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHourStart.TextChanged
        Dim ohrStart() As String
        Dim hour As Integer
        Dim minute As Integer
        ohrStart = txtHourStart.Text.Split(":")
        hour = ohrStart(0)
        minute = ohrStart(1)
        If hour > 23 Or minute > 59 Then
            lblalert.Text = "เวลาไม่ถุกต้อง"
            txtHourStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "HH:mm")
        End If
    End Sub

    Protected Sub TxtDtmEnd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDtmEnd.TextChanged
        Dim dtendtext As String = TxtDtmEnd.Text
        Dim dtStartcon As Date = GolbalFunc.ThaiDatetime.ConvStrToDateTime(TxtDtmStart.Text)
        Dim dtStopcon As Date = GolbalFunc.ThaiDatetime.ConvStrToDateTime(TxtDtmEnd.Text)
        Dim odtend() As String
        Dim dtend As Integer
        Dim yearend As Integer
        odtend = dtendtext.Split("/")
        dtend = odtend(0)
        yearend = odtend(2)
        If odtend(1) = "01" Or odtend(1) = "03" Or odtend(1) = "05" Or odtend(1) = "07" Or odtend(1) = "08" Or odtend(1) = "10" Or odtend(1) = "12" Then

            If dtend > 31 Then
                lblalert.Text = "วันที่ไม่ถุกต้อง"
                TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
                TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")
            End If
        ElseIf odtend(1) = "02" Then
            If (yearend Mod 4 = 0) And (yearend Mod 100 <> 0) Or (yearend Mod 400 = 0) Then
                If dtend > 0 And dtend <= 29 Then
                Else
                    lblalert.Text = "วันที่ไม่ถุกต้อง"
                    TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
                    TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")
                End If
            Else
                If dtend > 0 And dtend <= 28 Then
                Else
                    lblalert.Text = "วันที่ไม่ถุกต้อง"
                    TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
                    TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")
                End If
            End If
        ElseIf odtend(1) = "04" Or "06" Or "09" Or "11" Then
            If dtend > 30 Then
                lblalert.Text = "วันที่ไม่ถุกต้อง"
                TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
                TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")
            End If
        End If

    End Sub
    Protected Sub txtHourEnd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHourEnd.TextChanged
        Dim ohrEnd() As String
        Dim hour As Integer
        Dim minute As Integer
        ohrEnd = txtHourEnd.Text.Split(":")
        hour = ohrEnd(0)
        minute = ohrEnd(1)
        If hour > 23 Or minute > 59 Then
            lblalert.Text = "เวลาไม่ถุกต้อง"
            txtHourEnd.Text = GolbalFunc.ENFormat(Now, "HH:mm")
        End If

    End Sub

   

    Protected Sub BtnShowGraph_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShowGraph.Click
        Chart1.Titles.Clear()

        Dim dateStart As String = TxtDtmStart.Text
        Dim dateStop As String = TxtDtmEnd.Text
        dateStart &= " "
        dateStop &= " "
        dateStart &= txtHourStart.Text
        dateStop &= txtHourEnd.Text
        'Session("dtstart") = dateStart
        'Session("dtstop") = dateStop
        Dim odtstart() As String
        Dim odtend() As String
        Dim checkdatestart As Integer
        Dim checkdateend As Integer
        Dim checkmonthstart As Integer
        Dim checkmonthend As Integer
        Dim checkyearstart As Integer
        Dim checkyearend As Integer
        Dim station() As String
        'station = DropDownList1.Text.Split(" ")
        'HiddenCodeNextPage.Value = station(0)

        odtstart = TxtDtmStart.Text.Split("/")
        odtend = TxtDtmEnd.Text.Split("/")
        checkdatestart = odtstart(0)
        checkdateend = odtend(0)
        checkmonthstart = odtstart(1)
        checkmonthend = odtend(1)
        checkyearstart = odtstart(2)
        checkyearend = odtend(2)

        Dim dtStartcon As Date = New Date(checkyearstart, checkmonthstart, checkdatestart)
        Dim dtStopcon As Date = New Date(checkyearend, checkmonthend, checkdateend)
        If dtStopcon <= dtStartcon Then
            lblalert.Text = "วันที่เริ่มต้นกำหนดให้มีค่ามากกว่าวันที่สิ้นสุด"
            TxtDtmEnd.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, +24, dtStartcon), "dd/MM/yyyy")
        Else
            If checkmonthend - checkmonthstart > 0 Then
                If (checkdatestart + checkdateend) - checkdatestart < 5 And checkyearend - checkyearstart = 0 Then
                    lblalert.Text = ""
                Else
                    lblalert.Text = "วันที่เกินระยะเวลาที่กำหนด"
                    TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
                    TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")
                End If
            Else
                If checkdateend - checkdatestart < 5 And checkmonthend - checkmonthstart = 0 And checkyearend - checkyearstart = 0 Then
                    lblalert.Text = ""
                Else
                    lblalert.Text = "วันที่เกินระยะเวลาที่กำหนด"
                    TxtDtmStart.Text = GolbalFunc.ENFormat(DateAdd(DateInterval.Hour, -24, Now), "dd/MM/yyyy")
                    TxtDtmEnd.Text = GolbalFunc.ENFormat(Now, "dd/MM/yyyy")
                End If
            End If

        End If
        If lblalert.Text <> "" Then
            ModalPopupExtenderGraph.Show()
        End If

        Binding()

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
