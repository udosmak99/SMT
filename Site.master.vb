Imports System.Data
Partial Class Site
    Inherits System.Web.UI.MasterPage
 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindingdata()
            bindbasin()
            bindprovince()
            'updatedatacriticalandwarning()
            If Session("LoginDesc") Is Nothing Then
                BtnLogin.ImageUrl = "~/images/BtnOfficial.png"
            Else
                BtnLogin.ImageUrl = "~/images/BtnLogOut.png"
            End If
        End If



    End Sub
    ''อัพเดทข้อมูลcritical และ Warning ของระดับน้ำ (เหนือน้ำและท้ายน้ำ)
    Sub updatedatacriticalandwarning()
        Dim tblStn As System.Data.DataTable = clsModel.GetDataInfo()
        Try
            Dim dtrow As Data.DataRow
            For Each dtrow In tblStn.Rows
                Dim critical_up, critical_down, warning_up, warning_down As Double
                Dim cmdLastData As New SqlClient.SqlCommand
                If CDbl(dtrow.Item("right_bank_wl_up")) < CDbl(dtrow.Item("left_bank_wl_up")) Then
                    critical_up = CDbl(dtrow.Item("right_bank_wl_up"))
                    warning_up = CDbl(dtrow.Item("right_bank_wl_up")) - (CDbl(dtrow.Item("right_bank_wl_up")) * 0.2)
                Else
                    critical_up = CDbl(dtrow.Item("left_bank_wl_up"))
                    warning_up = CDbl(dtrow.Item("left_bank_wl_up")) - (CDbl(dtrow.Item("left_bank_wl_up")) * 0.2)
                End If
                If CDbl(dtrow.Item("right_bank_wl_down")) < CDbl(dtrow.Item("left_bank_wl_down")) Then
                    critical_down = CDbl(dtrow.Item("right_bank_wl_down"))
                    warning_down = CDbl(dtrow.Item("right_bank_wl_down")) - (CDbl(dtrow.Item("right_bank_wl_down")) * 0.2)
                Else
                    critical_down = CDbl(dtrow.Item("left_bank_wl_down"))
                    warning_down = CDbl(dtrow.Item("left_bank_wl_down")) - (CDbl(dtrow.Item("left_bank_wl_down")) * 0.2)
                End If

                cmdLastData.CommandType = CommandType.Text
                cmdLastData.Connection = GolbalFunc.Database.Connection
                cmdLastData.Connection.Open()
                cmdLastData.CommandText = "update [dbo].[tbl_station_info]" & _
                                            "set [warning_down] = @warning_down," & _
                                         "[warning_up] = @warning_up," & _
                                         "[critical_down] = @critical_down," & _
                                         "[critical_up] = @critical_up " & _
                                            "Where station_id = @sStationID"
                cmdLastData.CommandType = CommandType.Text
                cmdLastData.Parameters.AddWithValue("@critical_up", critical_up)
                cmdLastData.Parameters.AddWithValue("@critical_down", critical_down)
                cmdLastData.Parameters.AddWithValue("@warning_up", warning_up)
                cmdLastData.Parameters.AddWithValue("@warning_down", warning_down)
                cmdLastData.Parameters.AddWithValue("@sStationID", dtrow.Item("station_id"))
                cmdLastData.ExecuteNonQuery()
                cmdLastData.Connection.Close()
            Next

        Catch ex As Exception
            Throw New Exception("Liststation Error :" & ex.Message)
        End Try
    End Sub
    Sub bindprovince()
        Dim tblStn As System.Data.DataTable = clsModel.GetLastDataProvince()
        Dim StationInfo(tblStn.Rows.Count - 1, 1) As Object
        Dim stationdata As New Generic.List(Of clsLastdata)

        Dim i As Integer
        Try
            Dim dtrow As Data.DataRow
            Dim stndata As New clsLastdata
            For Each dtrow In tblStn.Rows

                stndata.province_id = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("province_id")))
                stndata.province_name = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("province_name")))
                stationdata.Add(stndata)
                StationInfo(i, 0) = stndata.province_id
                StationInfo(i, 1) = stndata.province_name
                i = i + 1
            Next

        Catch ex As Exception
            Throw New Exception("Liststation Error :" & ex.Message)
        End Try
        Session("province") = StationInfo
    End Sub
    Sub bindbasin()
        Dim tblStn As System.Data.DataTable = clsModel.GetLastDataBasin()
        Dim StationInfo(tblStn.Rows.Count - 1, 1) As Object
        Dim stationdata As New Generic.List(Of clsLastdata)
        Dim i As Integer
        Try
            Dim dtrow As Data.DataRow
            Dim stndata As New clsLastdata
            For Each dtrow In tblStn.Rows

                stndata.basin_id = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("basin_id")))
                stndata.basin_name = CStr(GolbalFunc.Validation.NulltoString(dtrow.Item("basin_name")))
                stationdata.Add(stndata)
                StationInfo(i, 0) = stndata.basin_id
                StationInfo(i, 1) = stndata.basin_name
                i = i + 1
            Next

        Catch ex As Exception
            Throw New Exception("Liststation Error :" & ex.Message)
        End Try
        Session("basin") = StationInfo
    End Sub

    Sub bindingdata()
        'Dim StationInfo(,) As Object = { _
        '      {"1", "G101", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, " 17.116028", "100.157861", "ไซฟอน PL.0 กม. 2+175"}, _
        '      {"2", "G102", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, "17.145417", "100.222083", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"3", "G103", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, " 17.145420", "100.229160", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"4", "G104", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, "17.145667", "100.210139", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"5", "G105", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, " 17.125135", "100.255186", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"6", "G106", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, " 17.092629", "100.262759", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"7", "G107", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, " 17.101190", "100.257880", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"8", "G108", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 0, "17.138222", "100.163361", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"9", "G109", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, " 17.148472", "100.174306", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"10", "G110", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 0, "17.07689", "100.27847", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"11", "G111", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, "16.59623", "100.22684", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"12", "G112", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 0, "17.147583", "100.192722", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"13", "G113", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, " 16.827250", "100.136167", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"14", "G114", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 0, "16.875028", "100.136083", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"15", "G115", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, "16.892250", "100.131250", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"16", "G116", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, "16.907806", "100.122111", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"17", "G117", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, " 16.986667", "100.095667", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"18", "G118", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 0, " 17.027222", "100.113056", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"19", "G119", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 0, " 17.045417", "100.137889", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"20", "G120", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 0, " 16.696194", "100.194972", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"21", "G121", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, "16.644389", "100.198444", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"22", "G122", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 0, "16.78499", "100.13918", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"23", "G123", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 0, "16.78313", "100.15088", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"24", "G124", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, "16.86516", "100.13271", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"25", "G125", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, "16.96054", "100.1198", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"26", "G126", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน", "1", "11", 1, "16.97153", "100.11647", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"27", "G127", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนล่าง", "2", "11", 1, "14.78030", "100.59947", "ไซฟอน PL.0 กม. 11+673"}, _
        '      {"28", "G128", "เขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนกลาง", "3", "11", 1, "14.56138", "100.36649", "ไซฟอน PL.0 กม. 11+673"} _
        '      }
        
    End Sub
    
    Protected Sub BtnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLogin.Click
        If BtnLogin.ImageUrl = "~/images/BtnLogOut.png" Then
            BtnLogin.ImageUrl = "~/images/BtnOfficial.png"
            PnlLogin.Visible = False
            clearUser()
            'Master.Page.ClientScript.RegisterStartupScript(Me.GetType(), "'", "<script " + "type='text/javascript'> 	$('#main-menu ul').removeClass('login'); $('#symbols0, #symbols1').removeClass('login');" + "<" + "/script" + ">")
            Response.Redirect("Default.aspx")

        Else
            PnlLogin.Visible = True
            ModalPopupExtender1.Show()
        End If
       
    End Sub

    Protected Sub BtnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnConfirm.Click
        Dim Users As New Users()
        Dim U As New UserItem

        U.LOGIN_NAME = txtUsername.Text
        U.LOGIN_PASSWORD = txtpassword.Text
        Dim dtLogin As DataTable = clsUser.Login(U)
        If dtLogin Is Nothing Then
            Show("ไม่สามารถล๊อกอินได้")
        ElseIf (dtLogin.Rows.Count = 1) Then
            U.NAME = dtLogin.Rows(0).Item("user_name")
            U.LAST_NAME = dtLogin.Rows(0).Item("user_lastname")
            U.LOGIN_NAME = dtLogin.Rows(0).Item("user_login")
            U.POSITION = dtLogin.Rows(0).Item("user_position")
            U.USER_LEVEL = dtLogin.Rows(0).Item("userlevel_id")
            U.USER_LEVEL_STR = "-"
            Users.Add(U)
            Session("LoginDesc") = U
            Session("Nameuser") = U.NAME
            Session("Positionuser") = U.POSITION
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "uploadNotify", "<script " + "type='text/javascript'> 	$('#main-menu ul').addClass('login'); $('#symbols0, #symbols1').addClass('login');" + "<" + "/script" + ">")
            Response.Redirect("Show_User.aspx")
            Session("LoginDesc") = Nothing
        End If
    End Sub
    Public Sub Show(ByVal message As String)
        Dim sresult As Boolean = False
        Try
            Dim cleanMessage As String = message.Replace("'", "\'")
            Dim script As String = "<script language=javascript>alert(""" & message & """)</script>"
            Page.RegisterClientScriptBlock("OpenWindow", script)
        Catch ex As Exception
            sresult = False
        End Try

    End Sub
    Private Sub clearUser()
        Session("LoginDesc") = Nothing
    End Sub
End Class

