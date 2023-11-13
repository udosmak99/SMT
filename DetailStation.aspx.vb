Imports System.Data
Partial Class DetailStation
    Inherits System.Web.UI.Page
    Dim station_id As String
    Dim model As clsDetailStation.Model
    Dim gateCount As Integer
    Dim user As UserItem
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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


                    url = "href='DetailStation.aspx?CODE=" & stndata.station_id & "&index=" & i + 1 & "'"
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
    Protected Sub Page_PreLoad(sender As Object, e As System.EventArgs) Handles Me.PreLoad
        station_id = IIf(Request.QueryString("CODE") Is Nothing, "1", Request.QueryString("CODE"))
        user = Session("LoginDesc")
        model = clsDetailStation.fncGetDetailStation(station_id)
        gateCount = clsDetailStation.fncGetGateCount(station_id)

        SetDetail()
        If gateCount < 1 Then
            'DoorsHd.Visible = False
            'Doors.Visible = False
            'DoorsFt.Visible = False
            lblLabelRightUp.Text = "จุดวัดที่ 1"
            lblLabelLeftUp.Text = "จุดวัดที่ 1"
            lblLabelGageUp.Text = "จุดวัดที่ 1"
            lblLabelGageUp.Text = "จุดวัดที่ 1"
            lblLabelRightDown.Text = "จุดวัดที่ 2"
            lblLabelLeftDown.Text = "จุดวัดที่ 2"
            lblLabelGageDown.Text = "จุดวัดที่ 2"
            lblLabelGageDown.Text = "จุดวัดที่ 2"
            lblLabelWlUp.Text = "จุดวัดที่ 1"
            lblLabelWlDown.Text = "จุดวัดที่ 2"
            lblLabelAirUp.Text = "จุดวัดที่ 1"
            lblLabelAirDown.Text = "จุดวัดที่ 2"
        End If
        If user IsNot Nothing AndAlso (user.USER_LEVEL = UserLevel.Admin Or user.USER_LEVEL = UserLevel.User) Then
            Dim mdl As DataTable = clsDetailStation.fncGetDetailStation24hr(station_id)
            bindGridview()
            dgvDeatail.DataSource = mdl
            dgvDeatail.DataBind()
            adminreportin.Visible = True
        End If

    End Sub
    Private Sub bindGridview()
        Dim bf As New BoundField
        bf.HeaderText = "วันเวลา"
        bf.DataField = "server_time"
        bf.DataFormatString = "{0:dd/MM/yyyy HH:mm}"

        dgvDeatail.Columns.Add(bf)
        bf = New BoundField

        bf.HeaderText = "สถานะการเชื่อมต่อ"
        bf.DataField = "conn_status_up"
        dgvDeatail.Columns.Add(bf)
        bf = New BoundField

        bf.HeaderText = "ฝนสะสม 15 นาที (มม.)"
        bf.DataField = "rf15"
        dgvDeatail.Columns.Add(bf)
        bf = New BoundField
        If gateCount < 1 Then
            bf.HeaderText = "ระดับน้ำจุดวัดที่ 1(ม.รทก)"
            bf.DataField = "wl_up_msl"
            dgvDeatail.Columns.Add(bf)
            bf = New BoundField

            bf.HeaderText = "ระดับน้ำจุดวัดที่ 2(ม.รทก)"
            bf.DataField = "wl_down_msl"
            dgvDeatail.Columns.Add(bf)
            bf = New BoundField
        Else
            bf.HeaderText = "ระดับน้ำเหนือน้ำ(ม.รทก)"
            bf.DataField = "wl_up_msl"
            dgvDeatail.Columns.Add(bf)
            bf = New BoundField

            bf.HeaderText = "ระดับน้ำท้ายน้ำ(ม.รทก)"
            bf.DataField = "wl_down_msl"
            dgvDeatail.Columns.Add(bf)
            bf = New BoundField
        End If


        If gateCount > 0 Then
            bf.HeaderText = "ระยะยกบาน 1 (ม.)"
            bf.DataField = "gate_1"
            dgvDeatail.Columns.Add(bf)
            bf = New BoundField
        End If
        If gateCount > 1 Then
            bf.HeaderText = "ระยะยกบาน 2 (ม.)"
            bf.DataField = "gate_2"
            dgvDeatail.Columns.Add(bf)
            bf = New BoundField
        End If
        If gateCount > 2 Then
            bf.HeaderText = "ระยะยกบาน 3 (ม.)"
            bf.DataField = "gate_3"
            dgvDeatail.Columns.Add(bf)
            bf = New BoundField
        End If
        If gateCount > 3 Then
            bf.HeaderText = "ระยะยกบาน 4 (ม.)"
            bf.DataField = "gate_4"
            dgvDeatail.Columns.Add(bf)
            bf = New BoundField
        End If
        If gateCount > 4 Then
            bf.HeaderText = "ระยะยกบาน 5 (ม.)"
            bf.DataField = "gate_5"
            dgvDeatail.Columns.Add(bf)
            bf = New BoundField
        End If
        If gateCount > 5 Then
            bf.HeaderText = "ระยะยกบาน 6 (ม.)"
            bf.DataField = "gate_6"
            dgvDeatail.Columns.Add(bf)
            bf = New BoundField
        End If
        If gateCount > 6 Then
            bf.HeaderText = "ระยะยกบาน 7 (ม.)"
            bf.DataField = "gate_7"
            dgvDeatail.Columns.Add(bf)
            bf = New BoundField
        End If

        bf.HeaderText = "สถานะประตู"
        bf.DataField = "door_status"
        dgvDeatail.Columns.Add(bf)
        bf = New BoundField

        bf.HeaderText = "แรงดันก๊าซเหนือน้ำ"
        bf.DataField = "air_tank_up"
        dgvDeatail.Columns.Add(bf)
        bf = New BoundField

        bf.HeaderText = "แรงดันก๊าซท้ายน้ำ"
        bf.DataField = "air_tank_down"
        dgvDeatail.Columns.Add(bf)
        bf = New BoundField

        bf.HeaderText = "อุณหภูมิภายในตู้"
        bf.DataField = "temp_alarm"
        dgvDeatail.Columns.Add(bf)
        bf = New BoundField

        bf.HeaderText = "แบตเตอร์รี่"
        bf.DataField = "batt_level"
        dgvDeatail.Columns.Add(bf)
        bf = New BoundField
    End Sub
    Private Sub SetDetail()
        lblHeader_stncode.Text = model.station_id_customer
        lblHeader_stnname.Text = model.station_name
        lblHeader_address.Text = "ต." & model.sub_district_name & " อ." & model.district_name & " จ." & model.province_name
        If model.server_time_up <> "-" Then
            lblTimeupdate.Text = GolbalFunc.ThaiDatetime.ThaiFormat(model.server_time_up, "วันddddที่ dd MMMM yyyy | HH:mm น.")
        Else
            lblTimeupdate.Text = model.server_time_up
        End If


        SetSGV()

        lblRight_bank_up_msl.Text = model.right_bank_wl_up + model.zerogate_up
        lblRight_bank_up.Text = model.right_bank_wl_up
        lblLeft_bank_up_msl.Text = model.left_bank_wl_up + model.zerogate_up
        lblLeft_bank_up.Text = model.left_bank_wl_up
        lblZerogate_up_msl.Text = model.zerogate_up
        lblZerogate_up.Text = "0"
        lblWarning_up_msl.Text = model.warning_up + model.zerogate_up
        lblWarning_up.Text = model.warning_up
        lblCritical_up_msl.Text = model.critical_up + model.zerogate_up
        lblCritical_up.Text = model.critical_up

        lblRight_bank_down_msl.Text = model.right_bank_wl_down + model.zerogate_down
        lblRight_bank_down.Text = model.right_bank_wl_down
        lblLeft_bank_down_msl.Text = model.left_bank_wl_down + model.zerogate_down
        lblLeft_bank_down.Text = model.left_bank_wl_down
        lblZerogate_down_msl.Text = model.zerogate_down
        lblZerogate_down.Text = "0"
        lblWarning_down_msl.Text = model.warning_down + model.zerogate_down
        lblWarning_down.Text = model.warning_down
        lblCritical_down_msl.Text = model.critical_down + model.zerogate_down
        lblCritical_down.Text = model.critical_down

        lblRf15.Text = model.rf15
        lblRf7toNow.Text = model.rf_7tonow
        lblRf7to7.Text = model.rf_7to7

        lblWl_up_msl.Text = model.wl_up_msl
        lblWl_up.Text = model.wl_up
        lblWl_down_msl.Text = model.wl_down_msl
        lblWl_down.Text = model.wl_down

        SetDoor()
        If model.door_status = "False" Then
            lblDoor_status.Text = "ปิด"
        ElseIf model.door_status = "True" Then
            lblDoor_status.Text = "เปิด"
        Else
            lblDoor_status.Text = "-"
        End If
        If model.air_tank_up = "True" Then
            lblAir_tank_up.Text = "น้อยกว่า 2 bar"
        ElseIf model.air_tank_up = "False" Then
            lblAir_tank_up.Text = "ปกติ"
        Else
            lblAir_tank_up.Text = "-"
        End If
        If model.air_tank_down = "True" Then
            lblAir_tank_down.Text = "น้อยกว่า 2 bar"
        ElseIf model.air_tank_down = "False" Then
            lblAir_tank_down.Text = "ปกติ"
        Else
            lblAir_tank_down.Text = "-"
        End If
        If model.temp_alarm = "True" Then
            lblTemp_alarm.Text = "มากว่า 50 องศาเซลเซียส"
        ElseIf model.temp_alarm = "False" Then
            lblTemp_alarm.Text = "ปกติ"
        Else
            lblTemp_alarm.Text = "-"
        End If
        lblBatt_level.Text = model.batt_level
    End Sub
    Private Sub SetSGV()
        Select Case gateCount
            Case 1
                Dim door1 As Double = 2 - (model.gate_1 * 2)
                Stage.InnerHtml &= "<svg  width=""645"" height=""430"">"
                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,0,0)"" >"
                Stage.InnerHtml &= "<image width=""645"" height=""430"" preserveAspectRatio=""none"" xlink:href=""images/door1.png"" transform=""translate(0,0)""></image>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,222,227)"" >"
                Stage.InnerHtml &= "<image width=""100"" height=""96"" xlink:href=""images/door-item.png"" transform=""translate(0," & door1.ToString & ") scale(2.55,1.1)""></image>"
                Stage.InnerHtml &= "<image width=""48"" height=""116"" xlink:href=""images/door1_floor.png"" transform=""translate(33,-4)""></image>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,20,205)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) "" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">เหนือน้ำ " & model.wl_up_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,500,360)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) ""  ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)"" ></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">ท้ายน้ำ " & model.wl_down_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "<g transform=""translate(342,125) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">1</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_1 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</svg>"
            Case 2
                Dim door1 As Double = 2 - (model.gate_1 * 2)
                Dim door2 As Double = 2 - (model.gate_2 * 2)
                Stage.InnerHtml &= "<svg  width=""645"" height=""430"">"
                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,0,0)"" >"
                Stage.InnerHtml &= "<image width=""645"" height=""430"" preserveAspectRatio=""none"" xlink:href=""images/door2.png"" transform=""translate(0,0)""></image>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,171,240)"" >"
                Stage.InnerHtml &= "<image width=""100"" height=""96"" xlink:href=""images/door-item.png"" transform=""translate(0," & door1 & ") scale(2.2,1)""></image>"
                Stage.InnerHtml &= "<image width=""100"" height=""96"" xlink:href=""images/door-item.png"" transform=""translate(165," & door2 & ") scale(1.9,0.9)""></image>"
                Stage.InnerHtml &= "<image width=""46"" height=""100"" xlink:href=""images/door2_floor.png"" transform=""translate(13,12)""></image>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,20,205)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) "" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">เหนือน้ำ " & model.wl_up_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,500,360)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) ""  ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)"" ></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">ท้ายน้ำ " & model.wl_down_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "<g transform=""translate(272,115) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">1</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_1 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "<g transform=""translate(420,130) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">2</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_2 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</svg>"
            Case 3
                Dim door1 As Double = 8 - (model.gate_1 * 2)
                Dim door2 As Double = 4 - (model.gate_2 * 2)
                Dim door3 As Double = 2 - (model.gate_3 * 2)
                Stage.InnerHtml &= "<svg  width=""645"" height=""430"">"
                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,0,0)"" >"
                Stage.InnerHtml &= "<image width=""645"" height=""430"" preserveAspectRatio=""none"" xlink:href=""images/door3.png"" transform=""translate(0,0)""></image>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,178,230)"" >"
                Stage.InnerHtml &= "<image width=""100"" height=""96"" xlink:href=""images/door-item.png"" transform=""translate(31," & door1 & ") scale(1.4,1)""></image>"
                Stage.InnerHtml &= "<image width=""100"" height=""96"" xlink:href=""images/door-item.png"" transform=""translate(150," & door2 & ") scale(1.15,0.9)""></image>"
                Stage.InnerHtml &= "<image width=""100"" height=""96"" xlink:href=""images/door-item.png"" transform=""translate(248," & door3 & ") scale(1,0.8)""></image>"
                Stage.InnerHtml &= "<image width=""249"" height=""101"" xlink:href=""images/door3_floor.png"" transform=""translate(44,20)""></image>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,25,180)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) "" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">เหนือน้ำ " & model.wl_up_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,500,360)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) ""  ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)"" ></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">ท้ายน้ำ " & model.wl_down_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(262,115) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">1</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_1 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(363,125) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">2</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_2 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(465,135) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">3</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_3 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "</svg>"
            Case 4
                Dim door1 As Double = 10 - (model.gate_1 * 2)
                Dim door2 As Double = 6 - (model.gate_2 * 2)
                Dim door3 As Double = 2 - (model.gate_3 * 2)
                Dim door4 As Double = -2 - (model.gate_4 * 2)
                Stage.InnerHtml &= "<svg  width=""645"" height=""430"">"
                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,0,0)"" >"
                Stage.InnerHtml &= "<image width=""645"" height=""430"" preserveAspectRatio=""none"" xlink:href=""images/door4.png"" transform=""translate(0,0)""></image>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,178,250)"" >"
                Stage.InnerHtml &= "<image width=""60"" height=""101"" xlink:href=""images/door-item.png"" transform=""translate(38," & door1 & ")""></image>"
                Stage.InnerHtml &= "<image width=""52"" height=""101"" xlink:href=""images/door-item.png"" transform=""translate(121," & door2 & ")""></image>"
                Stage.InnerHtml &= "<image width=""50"" height=""99"" xlink:href=""images/door-item.png"" transform=""translate(194," & door3 & ")""></image>"
                Stage.InnerHtml &= "<image width=""45"" height=""99"" xlink:href=""images/door-item.png"" transform=""translate(264," & door4 & ")""></image>"
                Stage.InnerHtml &= "<image width=""239"" height=""102"" xlink:href=""images/door5_floor.png"" transform=""translate(-190,8)""></image>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,13,200)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) "" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">เหนือน้ำ " & model.wl_up_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,500,360)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) ""  ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)"" ></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">ท้ายน้ำ " & model.wl_down_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(232,115) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">1</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_1 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(313,125) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">2</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_2 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(385,135) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">3</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_3 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(456,145) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">4</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_4 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "</svg>"
            Case 5
                Dim door1 As Double = 10 - (model.gate_1 * 2)
                Dim door2 As Double = 6 - (model.gate_2 * 2)
                Dim door3 As Double = 2 - (model.gate_3 * 2)
                Dim door4 As Double = -2 - (model.gate_4 * 2)
                Dim door5 As Double = -6 - (model.gate_5 * 2)
                Stage.InnerHtml &= "<svg  width=""645"" height=""430"">"
                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,0,0)"" >"
                Stage.InnerHtml &= "<image width=""645"" height=""430"" preserveAspectRatio=""none"" xlink:href=""images/door5.png"" transform=""translate(0,0)""></image>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,178,233)"" >"
                Stage.InnerHtml &= "<image width=""58"" height=""101"" xlink:href=""images/door-item.png"" transform=""translate(40," & door1 & ")""></image>"
                Stage.InnerHtml &= "<image width=""52"" height=""101"" xlink:href=""images/door-item.png"" transform=""translate(121," & door2 & ")""></image>"
                Stage.InnerHtml &= "<image width=""50"" height=""99"" xlink:href=""images/door-item.png"" transform=""translate(194," & door3 & ")""></image>"
                Stage.InnerHtml &= "<image width=""45"" height=""99"" xlink:href=""images/door-item.png"" transform=""translate(264," & door4 & ")""></image>"
                Stage.InnerHtml &= "<image width=""42"" height=""99"" xlink:href=""images/door-item.png"" transform=""translate(331," & door5 & ")""></image>"
                Stage.InnerHtml &= "<image width=""239"" height=""102"" xlink:href=""images/door5_floor.png"" transform=""translate(-178,8)""></image>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,13,200)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) "" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">เหนือน้ำ " & model.wl_up_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,500,360)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) ""  ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)"" ></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">ท้ายน้ำ " & model.wl_down_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(232,105) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">1</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_1 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(313,115) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">2</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_2 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(385,125) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">3</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_3 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(456,135) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">4</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_4 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(530,140) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">5</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_5 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "</svg>"
            Case 6
                Dim door1 As Double = 4 - (model.gate_1 * 2)
                Dim door2 As Double = 8 - (model.gate_2 * 2)
                Dim door3 As Double = 4 - (model.gate_3 * 2)
                Dim door4 As Double = 0 - (model.gate_4 * 2)
                Dim door5 As Double = -3 - (model.gate_5 * 2)
                Dim door6 As Double = -5 - (model.gate_6 * 2)
                Stage.InnerHtml &= "<svg  width=""645"" height=""430"">"
                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,0,0)"" >"
                Stage.InnerHtml &= "<image width=""645"" height=""430"" preserveAspectRatio=""none"" xlink:href=""images/door6.png"" transform=""translate(0,0)""></image>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,178,243)"" >"
                Stage.InnerHtml &= "<image width=""52"" height=""132"" xlink:href=""images/door-item.png"" transform=""translate(13," & door1 & ")""></image>"
                Stage.InnerHtml &= "<image width=""48"" height=""112"" xlink:href=""images/door-item.png"" transform=""translate(83," & door2 & ")""></image>"
                Stage.InnerHtml &= "<image width=""47"" height=""110"" xlink:href=""images/door-item.png"" transform=""translate(146," & door3 & ")""></image>"
                Stage.InnerHtml &= "<image width=""45"" height=""110"" xlink:href=""images/door-item.png"" transform=""translate(206," & door4 & ")""></image>"
                Stage.InnerHtml &= "<image width=""42"" height=""108"" xlink:href=""images/door-item.png"" transform=""translate(264," & door5 & ")""></image>"
                Stage.InnerHtml &= "<image width=""39"" height=""105"" xlink:href=""images/door-item.png"" transform=""translate(318," & door6 & ")""></image> "
                Stage.InnerHtml &= "<image width=""105"" height=""105"" xlink:href=""images/door6_floor.png"" transform=""translate(-70,6)""></image>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,13,200)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) "" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">เหนือน้ำ " & model.wl_up_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,500,360)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) ""  ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)"" ></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">ท้ายน้ำ " & model.wl_down_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(202,140) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">1</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_1 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(263,145) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">2</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_2 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(325,155) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">3</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_3 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(386,165) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">4</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_4 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(448,170) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">5</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_5 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(510,175) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">6</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_6 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "</svg>"
            Case 7 '7 door
                Dim door1 As Double = 0 - (model.gate_1 * 2)
                Dim door2 As Double = 0 - (model.gate_2 * 2)
                Dim door3 As Double = -1 - (model.gate_3 * 2)
                Dim door4 As Double = -4 - (model.gate_4 * 2)
                Dim door5 As Double = -6 - (model.gate_5 * 2)
                Dim door6 As Double = -8 - (model.gate_6 * 2)
                Dim door7 As Double = -10 - (model.gate_7 * 2)
                Stage.InnerHtml &= "<svg  width=""645"" height=""430"">"
                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,0,0)"" >"
                Stage.InnerHtml &= "<image width=""645"" height=""430"" preserveAspectRatio=""none"" xlink:href=""images/door7.png"" transform=""translate(0,0)""></image>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,178,245)"" >"
                Stage.InnerHtml &= "<image width=""56"" height=""120"" xlink:href=""images/door-item.png"" transform=""translate(0," & door1 & ")""></image>"
                Stage.InnerHtml &= "<image width=""52"" height=""112"" xlink:href=""images/door-item.png"" transform=""translate(74," & door2 & ")""></image>"
                Stage.InnerHtml &= "<image width=""49"" height=""112"" xlink:href=""images/door-item.png"" transform=""translate(140," & door3 & ")""></image>"
                Stage.InnerHtml &= "<image width=""47"" height=""112"" xlink:href=""images/door-item.png"" transform=""translate(203," & door4 & ")""></image>"
                Stage.InnerHtml &= "<image width=""44"" height=""110"" xlink:href=""images/door-item.png"" transform=""translate(264," & door5 & ")""></image>"
                Stage.InnerHtml &= "<image width=""42"" height=""108"" xlink:href=""images/door-item.png"" transform=""translate(320," & door6 & ")""></image>"
                Stage.InnerHtml &= "<image width=""39"" height=""108"" xlink:href=""images/door-item.png"" transform=""translate(374," & door7 & ")""></image>"
                Stage.InnerHtml &= "<image width=""30"" height=""200"" xlink:href=""images/door7_floor.png"" transform=""translate(-12,-62)""></image>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,13,200)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) "" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">เหนือน้ำ " & model.wl_up_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,500,360)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) ""  ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)"" ></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""16"">ท้ายน้ำ " & model.wl_down_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(198,150) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">1</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_1 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(260,155) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">2</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_2 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(322,160) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">3</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_3 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(384,165) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">4</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_4 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(445,170) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">5</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_5 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(505,175) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">6</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_6 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "<g transform=""translate(565,180) "">"
                Stage.InnerHtml &= "<g transform=""translate(-210,-385) ""><path fill=""none"" stroke=""#930"" d=""M 223 325 L 223 398""  stroke-width=""1"" ></path></g>"
                Stage.InnerHtml &= "<path fill=""#C60"" stroke=""#930""  d=""M 12.5 0 C 19 0 25 5 25 12.5 C 25 19 19 25 12.5 25 C 5 25 0 19 0 12.5 C 0 5 5 0 12.5 0 Z"" stroke-width=""1"" ></path>"
                Stage.InnerHtml &= "<text fill=""#fff"" font-family=""Arial"" font-size=""12px"" font-weight=""bold""  x=""10"" y=""18"">7</text>"
                Stage.InnerHtml &= "<g transform=""translate(12,-70) "">"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""#ccc"" stroke-width=""1"" d=""M 0 0 L 47 0 C 54 0 60 5.8 60 13 C 60 20  54 26 47 26 L 0 26 Z""></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""12"" y=""18"">" & model.gate_7 & " ม.</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</g>"

                Stage.InnerHtml &= "</svg>"
            Case Else
                Stage.InnerHtml &= "<svg  width=""645"" height=""430"">"
                Stage.InnerHtml &= "<g transform=""matrix(1,0,0,1,0,0)"" >"
                Stage.InnerHtml &= "<image width=""645"" height=""430"" preserveAspectRatio=""none"" xlink:href=""images/no_door.jpg"" transform=""translate(0,0)""></image>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,39,280)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) ""  ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)"" ></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""5"" y=""16"">จุดวัดที่ 1 " & model.wl_up_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "<g transform=""translate(0,0) matrix(1,0,0,1,331,160)"" >"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(2,2) scale(0.8,1) "" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#000"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(57,15)"" opacity=""0.2"" ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 140 0 Q 150 0 150 10 L 150 15 Q 150 25 140 25 L 10 25 Q 0 25 0 15 L 0 10 Q 0 0 10 0 Z"" transform=""translate(0,0) scale(0.8,1) ""  ></path>"
                Stage.InnerHtml &= "<path fill=""#FFFFFF"" stroke=""none"" d=""M 10 0 L 20 10 L 10 20 L 0 10 L 10 0 Z"" transform=""translate(55,13)"" ></path>"
                Stage.InnerHtml &= "<text fill=""#444"" font-family=""Arial"" font-size=""12px""  x=""5"" y=""16""  >จุดวัดที่ 2 " & model.wl_down_msl & " ม.รทก</text>"
                Stage.InnerHtml &= "</g>"
                Stage.InnerHtml &= "</svg>"
        End Select
    End Sub
    Private Sub SetDoor()
        Dim param(8) As Integer
        param(1) = model.gate_1
        param(2) = model.gate_2
        param(3) = model.gate_3
        param(4) = model.gate_4
        param(5) = model.gate_5
        param(6) = model.gate_6
        param(7) = model.gate_7

        For i = 1 To gateCount
            Doors.InnerHtml &= "<li>ประตูบานที่ " & i & "<div>ม.</div><div class=""value"">" & param(i) & "</div></li>"
        Next
        If gateCount = 0 Then
            Doors.InnerHtml &= "<li>ไม่มีประตู</li>"
        End If
    End Sub

    Protected Sub dgvDeatail_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgvDeatail.RowDataBound
        Dim cellCount = e.Row.Cells.Count
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    e.Row.Cells(0).Text = "'"
        '    e.Row.Cells(0).ForeColor = Drawing.Color.Red
        'End If
        Dim cellDefalt As Integer = 10
        Dim door As Integer = 5
        Dim airUp As Integer = 6
        Dim airDown As Integer = 7
        Dim temp As Integer = 8
        Dim batt As Integer = 9
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.HorizontalAlign = HorizontalAlign.Center
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(1).Text = "True" Then
                e.Row.Cells(1).Text = "ปกติ"
            ElseIf e.Row.Cells(1).Text = "False" Then
                e.Row.Cells(1).Text = "ผิดปกติ"
            Else
                e.Row.Cells(1).Text = "-"
            End If
            'If cellCount = 11 Then
            '    door += 1
            '    airUp += 1
            '    airDown += 1
            '    temp += 1
            '    batt += 1
            'ElseIf cellCount = 12 Then
            '    door += 2
            '    airUp += 2
            '    airDown += 2
            '    temp += 2
            '    batt += 2
            'ElseIf cellCount = 13 Then
            '    door += 3
            '    airUp += 3
            '    airDown += 3
            '    temp += 3
            '    batt += 3
            'ElseIf cellCount = 14 Then
            '    door += 4
            '    airUp += 4
            '    airDown += 4
            '    temp += 4
            '    batt += 4
            'ElseIf cellCount = 15 Then
            '    door += 5
            '    airUp += 5
            '    airDown += 5
            '    temp += 5
            '    batt += 5
            'ElseIf cellCount = 16 Then
            '    door += 6
            '    airUp += 6
            '    airDown += 6
            '    temp += 6
            '    batt += 6
            'ElseIf cellCount = 17 Then
            '    door += 7
            '    airUp += 7
            '    airDown += 7
            '    temp += 7
            '    batt += 7
            'End If
            While cellDefalt < cellCount
                door += 1
                airUp += 1
                airDown += 1
                temp += 1
                batt += 1
                cellDefalt += 1
            End While
            If e.Row.Cells(door).Text = "True" Then
                e.Row.Cells(door).Text = "เปิด"
            ElseIf e.Row.Cells(door).Text = "False" Then
                e.Row.Cells(door).Text = "ปิด"
            Else
                e.Row.Cells(door).Text = "-"
            End If
            If e.Row.Cells(airUp).Text = "False" Then
                e.Row.Cells(airUp).Text = "ปกติ"
            ElseIf e.Row.Cells(airUp).Text = "True" Then
                e.Row.Cells(airUp).Text = "ผิดปกติ"
            Else
                e.Row.Cells(airUp).Text = "-"
            End If
            If e.Row.Cells(airDown).Text = "False" Then
                e.Row.Cells(airDown).Text = "ปกติ"
            ElseIf e.Row.Cells(airDown).Text = "True" Then
                e.Row.Cells(airDown).Text = "ผิดปกติ"
            Else
                e.Row.Cells(airDown).Text = "-"
            End If
            If e.Row.Cells(temp).Text = "False" Then
                e.Row.Cells(temp).Text = "ปกติ"
            ElseIf e.Row.Cells(temp).Text = "True" Then
                e.Row.Cells(temp).Text = "สูง"
            Else
                e.Row.Cells(temp).Text = "-"
            End If
        End If
    End Sub
End Class
