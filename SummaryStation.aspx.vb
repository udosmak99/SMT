Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Partial Class SummaryStation
    Inherits System.Web.UI.Page
    'Protected Sub Pages_AllStation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not (IsPostBack) Then     'DD-MM-YYYY HH24:MI:SS
    '        geturl()
    '    End If
    'End Sub
    Private Sub geturl()
        Try
            Dim type As Integer = Request.QueryString("type")
            Dim i As Integer
            Select Case type
                Case 0
                    lblGB.Text = "ข้อมูลทุกสถานี"
                    grvlastData.DataSource = ListStation0(i)
                    grvlastData.DataBind()
                    lblNum.Text = i.ToString - 1
                Case 1
                    Dim group As Integer = Request.QueryString("group")
                    lblGB.Text = "กลุ่มที่ " & group & " : "
                    lblName.Text = NulltoBlank(GetGroupName(group))
                    grvlastData.DataSource = ListStation1(group, i)
                    grvlastData.DataBind()
                    lblNum.Text = i.ToString - 1
                Case 2
                    Dim basin As Integer = Request.QueryString("basin")
                    lblGB.Text = "ลุ่มน้ำที่ " & basin & " : "
                    lblName.Text = NulltoBlank(GetBasinName(basin))
                    grvlastData.DataSource = ListStation2(basin, i)
                    grvlastData.DataBind()
                    lblNum.Text = i.ToString - 1
            End Select
        Catch ex As Exception
            Throw New Exception("getUrl Error : " & ex.Message)
        End Try
    End Sub
    Private Function GetGroupName(group As Integer) As Object
        Dim groupname As Object = DBNull.Value
        Try
            Dim cmdgetName As New SqlCommand
            Dim da As New SqlDataAdapter(cmdgetName)
            Dim ds As New DataSet
            cmdgetName.CommandType = CommandType.Text
            cmdgetName.Connection = GolbalFunc.Database.Connection
            cmdgetName.CommandText = " select group_name from tbl_group where group_id = @group_id"
            cmdgetName.Parameters.AddWithValue("group_id", group)
            da.Fill(ds, "group")
            If ds.Tables("group").Rows().Count <> 0 Then
                groupname = ds.Tables("group").Rows(0).Item("group_name")
            End If
        Catch ex As Exception
            Throw New Exception("GetGroupName error : " & ex.Message)
        End Try
        Return groupname
    End Function
    Private Function GetBasinName(basin As Integer) As Object
        Dim basinname As Object = DBNull.Value
        Try
            Dim cmdgetName As New SqlCommand
            Dim da As New SqlDataAdapter(cmdgetName)
            Dim ds As New DataSet
            cmdgetName.CommandType = CommandType.Text
            cmdgetName.Connection = GolbalFunc.Database.Connection
            cmdgetName.CommandText = " select basin_name from tbl_basin where basin_id = @basin_id"
            cmdgetName.Parameters.AddWithValue("basin_id", basin)
            da.Fill(ds, "basin")
            If ds.Tables("basin").Rows().Count <> 0 Then
                basinname = ds.Tables("basin").Rows(0).Item("basin_name")
            End If
        Catch ex As Exception
            Throw New Exception("GetBasinName error : " & ex.Message)
        End Try
        Return basinname
    End Function

    Private Function GetLastData0() As DataTable  'ByVal today7 As DateTime
        Try
            Dim cmdLastData As New SqlCommand
            Dim da As New SqlDataAdapter(cmdLastData)
            Dim ds As New DataSet
            cmdLastData.CommandType = CommandType.Text
            cmdLastData.CommandText = " select s.station_id, s.station_id_customer,s.station_name,s.critical_up,s.warning_up,s.critical_down,s.warning_down,l.rf15, " & _
            " l.wl_up,l.wl_down,l.flow,(case when l.conn_status_up = 0 then 'ปกติ' when l.conn_status_up = 1 then 'ขัดข้อง' else '-' end) as conn_status_up, " & _
            " (case when l.conn_status_down = 0 then 'ปกติ' when l.conn_status_down = 1 then 'ขัดข้อง' else '-' end) as conn_status_down,l.server_time_up " & _
            " from tbl_station_info s left join tbl_lastupdate l on s.station_id = l.station_id " & _
            " order by s.station_id,l.server_time_up "
            cmdLastData.Connection = GolbalFunc.Database.Connection
            da.Fill(ds, "LastData")
            Return ds.Tables("LastData")
        Catch ex As Exception
            Throw New Exception("GetLastData error : " & ex.Message)
        End Try
    End Function

    Private Function ListStation0(ByRef i As Integer) As Generic.IList(Of clsDataAllStation)
        Dim Allstation As New Generic.List(Of clsDataAllStation)
        Try
            Dim tblStn As System.Data.DataTable = GetLastData0()  'today7
            Dim dtrow As Data.DataRow
            i = 1
            For Each dtrow In tblStn.Rows
                Dim stn As New clsDataAllStation
                stn.server_time_up = NulltoBlankDate(dtrow.Item("server_time_up"))
                stn.station_id = GolbalFunc.Validation.NulltoBlank(dtrow.Item("station_id"))
                stn.station_id_customer = GolbalFunc.Validation.NulltoBlank(dtrow.Item("station_id_customer"))
                stn.station_name = GolbalFunc.Validation.NulltoBlank(dtrow.Item("station_name"))
                stn.rf15 = NulltoLineTwoDot(dtrow.Item("rf15"))
                stn.wl_up = NulltoLineTwoDot(dtrow.Item("wl_up"))
                stn.wl_down = NulltoLineTwoDot(dtrow.Item("wl_down"))
                stn.Flow = NulltoLineTwoDot(dtrow.Item("flow"))
                stn.conn_status_up = dtrow.Item("conn_status_up")
                stn.conn_status_down = dtrow.Item("conn_status_down")
                'stn.conn_status_down = formatConnStatus(GolbalFunc.Validation.NulltoBlank(dtrow.Item("conn_status_down")))
                stn.critical_up = NulltoLineTwoDot(dtrow.Item("critical_up"))
                stn.warning_up = NulltoLineTwoDot(dtrow.Item("warning_up"))
                stn.critical_down = NulltoLineTwoDot(dtrow.Item("critical_down"))
                stn.warning_down = NulltoLineTwoDot(dtrow.Item("warning_down"))
                stn.i = i
                Allstation.Add(stn)
                i = i + 1
            Next
        Catch ex As Exception
            Throw New Exception("Liststation Error :" & ex.Message)
        End Try
        Return Allstation
    End Function
    Private Function GetLastData1(Group As Integer) As DataTable  'ByVal today7 As DateTime
        Try
            Dim cmdLastData As New SqlCommand
            Dim da As New SqlDataAdapter(cmdLastData)
            Dim ds As New DataSet
            cmdLastData.CommandType = CommandType.Text
            cmdLastData.Connection = GolbalFunc.Database.Connection
            cmdLastData.CommandText = " select s.station_id, s.station_id_customer,s.station_name,s.critical_up,s.warning_up,s.critical_down,s.warning_down,l.rf15, " & _
            " l.wl_up,l.wl_down,l.flow,(case when l.conn_status_up = 0 then 'ปกติ' when l.conn_status_up = 1 then 'ขัดข้อง' else '-' end) as conn_status_up, " & _
            " (case when l.conn_status_down = 0 then 'ปกติ' when l.conn_status_down = 1 then 'ขัดข้อง' else '-' end) as conn_status_down,l.server_time_up " & _
            " from tbl_station_info s left join tbl_lastupdate l on s.station_id = l.station_id " & _
            " where group_id = @group_id order by s.station_id,l.server_time_up "
            cmdLastData.Parameters.AddWithValue("group_id", Group)
            da.Fill(ds, "LastData")
            Return ds.Tables("LastData")
        Catch ex As Exception
            Throw New Exception("GetLastData error : " & ex.Message)
        End Try
    End Function

    Private Function ListStation1(Group As Integer, ByRef i As Integer) As Generic.IList(Of clsDataAllStation)
        Dim Allstation As New Generic.List(Of clsDataAllStation)
        Try
            Dim tblStn As System.Data.DataTable = GetLastData1(Group)  'today7
            Dim dtrow As Data.DataRow
            i = 1
            For Each dtrow In tblStn.Rows
                Dim stn As New clsDataAllStation
                stn.server_time_up = NulltoBlankDate(dtrow.Item("server_time_up"))
                stn.station_id = GolbalFunc.Validation.NulltoBlank(dtrow.Item("station_id"))
                stn.station_id_customer = GolbalFunc.Validation.NulltoBlank(dtrow.Item("station_id_customer"))
                stn.station_name = GolbalFunc.Validation.NulltoBlank(dtrow.Item("station_name"))
                stn.rf15 = NulltoLineTwoDot(dtrow.Item("rf15"))
                stn.wl_up = NulltoLineTwoDot(dtrow.Item("wl_up"))
                stn.wl_down = NulltoLineTwoDot(dtrow.Item("wl_down"))
                stn.Flow = NulltoLineTwoDot(dtrow.Item("flow"))
                stn.conn_status_up = dtrow.Item("conn_status_up")
                stn.conn_status_down = dtrow.Item("conn_status_down")
                stn.critical_up = NulltoLineTwoDot(dtrow.Item("critical_up"))
                stn.warning_up = NulltoLineTwoDot(dtrow.Item("warning_up"))
                stn.critical_down = NulltoLineTwoDot(dtrow.Item("critical_down"))
                stn.warning_down = NulltoLineTwoDot(dtrow.Item("warning_down"))
                stn.i = i
                Allstation.Add(stn)
                i = i + 1
            Next
        Catch ex As Exception
            Throw New Exception("Liststation Error :" & ex.Message)
        End Try
        Return Allstation
    End Function
    Private Function GetLastData2(Basin As Integer) As DataTable  'ByVal today7 As DateTime
        Try
            Dim cmdLastData As New SqlCommand
            Dim da As New SqlDataAdapter(cmdLastData)
            Dim ds As New DataSet
            cmdLastData.CommandType = CommandType.Text
            cmdLastData.Connection = GolbalFunc.Database.Connection
            cmdLastData.CommandText = " select s.station_id, s.station_id_customer,s.station_name,s.critical_up,s.warning_up,s.critical_down,s.warning_down,l.rf15, " & _
            " l.wl_up,l.wl_down,l.flow,(case when l.conn_status_up = 0 then 'ปกติ' when l.conn_status_up = 1 then 'ขัดข้อง' else '-' end) as conn_status_up, " & _
            " (case when l.conn_status_down = 0 then 'ปกติ' when l.conn_status_down = 1 then 'ขัดข้อง' else '-' end) as conn_status_down,l.server_time_up " & _
            " from tbl_station_info s left join tbl_lastupdate l on s.station_id = l.station_id " & _
            " where basin_id = @basin_id order by s.station_id,l.server_time_up "
            cmdLastData.Parameters.AddWithValue("basin_id", Basin)
            da.Fill(ds, "LastData")
            Return ds.Tables("LastData")
        Catch ex As Exception
            Throw New Exception("GetLastData error : " & ex.Message)
        End Try
    End Function

    Private Function ListStation2(Basin As Integer, ByRef i As Integer) As Generic.IList(Of clsDataAllStation)
        Dim Allstation As New Generic.List(Of clsDataAllStation)
        Try
            Dim tblStn As System.Data.DataTable = GetLastData2(Basin)  'today7
            Dim dtrow As Data.DataRow
            i = 1
            For Each dtrow In tblStn.Rows
                Dim stn As New clsDataAllStation
                stn.server_time_up = NulltoBlankDate(dtrow.Item("server_time_up"))
                stn.station_id = GolbalFunc.Validation.NulltoBlank(dtrow.Item("station_id"))
                stn.station_id_customer = GolbalFunc.Validation.NulltoBlank(dtrow.Item("station_id_customer"))
                stn.station_name = GolbalFunc.Validation.NulltoBlank(dtrow.Item("station_name"))
                stn.rf15 = NulltoLineTwoDot(dtrow.Item("rf15"))
                stn.wl_up = NulltoLineTwoDot(dtrow.Item("wl_up"))
                stn.wl_down = NulltoLineTwoDot(dtrow.Item("wl_down"))
                stn.Flow = NulltoLineTwoDot(dtrow.Item("flow"))
                stn.conn_status_up = dtrow.Item("conn_status_up")
                stn.conn_status_down = dtrow.Item("conn_status_down")
                'stn.conn_status_down = formatConnStatus(GolbalFunc.Validation.NulltoBlank(dtrow.Item("conn_status_down")))
                stn.critical_up = NulltoLineTwoDot(dtrow.Item("critical_up"))
                stn.warning_up = NulltoLineTwoDot(dtrow.Item("warning_up"))
                stn.critical_down = NulltoLineTwoDot(dtrow.Item("critical_down"))
                stn.warning_down = NulltoLineTwoDot(dtrow.Item("warning_down"))
                stn.i = i
                Allstation.Add(stn)
                i = i + 1
            Next
        Catch ex As Exception
            Throw New Exception("Liststation Error :" & ex.Message)
        End Try
        Return Allstation
    End Function

    Public Shared Function NulltoLineTwoDot(ByVal msg As Object) As String
        If msg Is DBNull.Value Then
            Return "-"
        Else
            Return Format(msg, "0.00")
        End If
    End Function
    Public Shared Function NulltoBlank(ByVal msg As Object) As Object
        If msg Is DBNull.Value Then
            Return ""
        Else
            Return msg
        End If
    End Function
    Public Shared Function NulltoBlankDate(ByVal msg As Object) As Object
        If msg Is DBNull.Value Then
            Return "-"
        Else
            Return GolbalFunc.ThaiDatetime.ThaiFormat(msg, "dd/MM/yyyy HH:mm")
        End If
    End Function
    Protected Sub grvlastData_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvlastData.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then      'เช็คว่าเป็น data ของ gridview ไหม
            Dim lblStatus As Label = CType(e.Row.FindControl("lblstatus"), Label)
            Dim lbldate As Label = CType(e.Row.FindControl("lbldate"), Label)
            If lblStatus.Text = "ขัดข้อง" Then
                lblStatus.ForeColor = Color.Red
                lbldate.ForeColor = Color.Red
                'Else
                '    lblStatus.ForeColor = Color.Green
            End If

            'Dim lblwl01 As Label = CType(e.Row.FindControl("lblwl_up"), Label)
            'Dim lblwl01Max As Label = CType(e.Row.FindControl("lblwl_down"), Label)
            'Dim lblCritical As Label = CType(e.Row.FindControl("lblCritical"), Label)
            'Dim lblWarning As Label = CType(e.Row.FindControl("lblWarning"), Label)
            'Try
            '    If Not (lblCritical.Text = "-" Or lblWarning.Text = "-" Or lblwl01.Text = "-" Or lblwl01Max.Text = "-") Then
            '        If CDbl(lblwl01.Text) >= CDbl(lblCritical.Text) Then
            '            lblwl01.ForeColor = Color.Red
            '        End If
            '        If CDbl(lblwl01Max.Text) >= CDbl(lblCritical.Text) Then
            '            lblwl01Max.ForeColor = Color.Red
            '        End If
            '        If CDbl(lblwl01.Text) >= CDbl(lblWarning.Text) And CDbl(lblwl01.Text) < CDbl(lblCritical.Text) Then
            '            lblwl01.ForeColor = Color.Gold
            '        End If
            '        If CDbl(lblwl01Max.Text) >= CDbl(lblWarning.Text) And CDbl(lblwl01Max.Text) < CDbl(lblCritical.Text) Then
            '            lblwl01Max.ForeColor = Color.Gold
            '        End If
            '    End If
            'Catch ex As Exception
            '    Response.Write("Errror rowbound : " & ex.Message)
            '    ' Throw New Exception("grvlastData_RowDataBound Error :" & ex.Message)
            'End Try
        End If
    End Sub
    Protected Sub Pages_AllStation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then     'DD-MM-YYYY HH24:MI:SS
            geturl()
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
        End If
    End Sub
    'Private Sub lastdate()
    '    Try
    '        Dim cmdLastData As New SqlCommand
    '        Dim da As New SqlDataAdapter(cmdLastData)
    '        Dim ds As New DataSet
    '        cmdLastData.CommandType = CommandType.Text
    '        cmdLastData.CommandText = " select "
    '        cmdLastData.Connection = GolbalFunc.Database.Connection
    '        da.Fill(ds, "LastDate")
    '    Catch ex As Exception
    '        Throw New Exception("lastdate error : " & ex.Message)
    '    End Try
    'End Sub
    'Private Function formatConnStatus(ByVal comstatus As String) As String
    '    If comstatus = "0" Then
    '        Return "ปกติ"
    '    Else
    '        Return "ขัดข้อง"
    '    End If
    'End Function
    'Public Shared Function NulltoLineOneDot(ByVal msg As Object) As String
    '    If msg Is DBNull.Value Then
    '        Return "-"
    '    Else
    '        Return Format(msg, "0.0")
    '    End If
    'End Function

    'Private Function formatStatus(ByVal status As String) As String
    '    If status = "Y" Then
    '        Return "ปกติ"
    '    End If
    '    Return "ขัดข้อง"
    'End Function

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
