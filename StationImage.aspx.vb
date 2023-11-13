
Partial Class StationImage
    Inherits System.Web.UI.Page

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
        Dim StationInfo(tblStn.Rows.Count - 1, 33) As Object
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
                stndata.address = "ต. " & CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("subdistrict_name")))
                stndata.address = stndata.address & " อ. " & CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("district_name")))
                stndata.address = stndata.address & " จ. " & CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("province_name")))
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


                    url = "href='StationImage.aspx?CODE=" & stndata.station_id & "&index=" & i + 1 & "'"
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
                StationInfo(i, 27) = GolbalFunc.Validation.NulltoString(dtrow.Item("station_lattitude_utm"))
                StationInfo(i, 28) = GolbalFunc.Validation.NulltoString(dtrow.Item("station_longitude_utm"))
                StationInfo(i, 29) = GolbalFunc.Validation.NulltoZero(dtrow.Item("water_sensor"))
                StationInfo(i, 30) = GolbalFunc.Validation.NulltoZero(dtrow.Item("rain_sensor"))
                StationInfo(i, 31) = dtrow.Item("server_time_up")
                StationInfo(i, 32) = dtrow.Item("server_time_down")
                StationInfo(i, 33) = stndata.address
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
        lblHeader_stncode.Text = StationInfo(HiddenIndex.Value - 1, 26)
        lblHeader_stnname.Text = StationInfo(HiddenIndex.Value - 1, 1)
        lblHeader_address.Text = StationInfo(HiddenIndex.Value - 1, 33)
        lblstnname.Text = StationInfo(HiddenIndex.Value - 1, 1)
        lblstncode.Text = StationInfo(HiddenIndex.Value - 1, 26)
        lblbasin.Text = StationInfo(HiddenIndex.Value - 1, 12)
        lbllat.Text = StationInfo(HiddenIndex.Value - 1, 9)
        lbllong.Text = StationInfo(HiddenIndex.Value - 1, 10)
        lbllatUtm.Text = StationInfo(HiddenIndex.Value - 1, 9)
        lbllongUtm.Text = StationInfo(HiddenIndex.Value - 1, 10)
        lbladdress.Text = StationInfo(HiddenIndex.Value - 1, 33)

        lbllatUtm.Text = StationInfo(HiddenIndex.Value - 1, 27)
        lbllongUtm.Text = StationInfo(HiddenIndex.Value - 1, 28)
        If StationInfo(HiddenIndex.Value - 1, 29) >= 1 And StationInfo(HiddenIndex.Value - 1, 30) >= 1 Then
            lblstntype.Text = "วัดปริมาณน้ำฝน และ วัดระดับน้ำท่า"
        ElseIf StationInfo(HiddenIndex.Value - 1, 29) >= 1 And StationInfo(HiddenIndex.Value - 1, 30) >= 0 Then
            lblstntype.Text = "วัดระดับน้ำท่า"
        Else
            lblstntype.Text = "วัดปริมาณน้ำฝน"
        End If
        If StationInfo(HiddenIndex.Value - 1, 31) Is DBNull.Value Then
            lblTimeupdate.Text = GolbalFunc.Validation.NulltoString(StationInfo(HiddenIndex.Value - 1, 31))
        Else
            lblTimeupdate.Text = GolbalFunc.ThaiDatetime.ThaiFormat(StationInfo(HiddenIndex.Value - 1, 31), "วันddddที่ dd MMMM yyyy | HH:mm น.")
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
