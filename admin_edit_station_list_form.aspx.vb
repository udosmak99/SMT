Imports System.Data
Partial Class admin_edit_station_list_form
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            setDDl()
            Dim DT As New DataTable
            DT = clsMnStationInfo.getInfoList(IIf(Request.QueryString("CODE") Is Nothing, 1, CInt(Request.QueryString("CODE"))))
            If DT.Rows.Count > 0 Then
                station_id.Value = GolbalFunc.Validation.NulltoString(DT(0)("station_id"))
                txt_station_id_customer.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_id_customer"))
                txt_station_name.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_name"))
                ddl_zone_id.SelectedValue = GolbalFunc.Validation.NulltoZero(DT(0)("zone_id"))
                ddl_province_id.SelectedValue = GolbalFunc.Validation.NulltoZero(DT(0)("province_id"))
                ddl_district_id.DataSource = clsMnStationInfo.getDistrict(ddl_province_id.SelectedValue)
                ddl_district_id.DataTextField = "district_name"
                ddl_district_id.DataValueField = "district_id"
                If ddl_district_id.DataSource.rows.count > 0 Then
                    ddl_district_id.DataBind()
                End If
                ddl_district_id.SelectedValue = GolbalFunc.Validation.NulltoZero(DT(0)("district_id"))
                ddl_subdistrict_id.DataSource = clsMnStationInfo.getSubdistrict(ddl_district_id.SelectedValue)
                ddl_subdistrict_id.DataTextField = "subdistrict_name"
                ddl_subdistrict_id.DataValueField = "subdistrict_id"
                If ddl_subdistrict_id.DataSource.rows.count > 0 Then
                    ddl_subdistrict_id.DataBind()
                End If
                ddl_subdistrict_id.SelectedValue = GolbalFunc.Validation.NulltoZero(DT(0)("subdistrict_id"))
                
                txt_station_lattitude_utm.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_lattitude_utm"))
                txt_station_longitude_utm.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_longitude_utm"))
                txt_station_lattitude.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_lattitude"))
                txt_station_longitude.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_longitude"))

                txt_right_bank_wl_up.Text = GolbalFunc.Validation.NulltoString(DT(0)("right_bank_wl_up"))
                txt_left_bank_wl_up.Text = GolbalFunc.Validation.NulltoString(DT(0)("left_bank_wl_up"))
                txt_zerogate_up.Text = GolbalFunc.Validation.NulltoString(DT(0)("zerogate_up"))
                txt_warning_up.Text = GolbalFunc.Validation.NulltoString(DT(0)("warning_up"))
                txt_critical_up.Text = GolbalFunc.Validation.NulltoString(DT(0)("critical_up"))

                txt_right_bank_wl_down.Text = GolbalFunc.Validation.NulltoString(DT(0)("right_bank_wl_down"))
                txt_left_bank_wl_down.Text = GolbalFunc.Validation.NulltoString(DT(0)("left_bank_wl_down"))
                txt_zerogate_down.Text = GolbalFunc.Validation.NulltoString(DT(0)("zerogate_down"))
                txt_warning_down.Text = GolbalFunc.Validation.NulltoString(DT(0)("warning_down"))
                txt_critical_down.Text = GolbalFunc.Validation.NulltoString(DT(0)("critical_down"))

            End If
        End If
    End Sub

    Protected Sub ddl_province_id_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddl_province_id.SelectedIndexChanged
        ddl_district_id.DataSource = clsMnStationInfo.getDistrict(ddl_province_id.SelectedValue)
        ddl_district_id.DataTextField = "district_name"
        ddl_district_id.DataValueField = "district_id"
        If ddl_district_id.DataSource.rows.count > 0 Then
            ddl_district_id.DataBind()
        End If

    End Sub

    Protected Sub ddl_district_id_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddl_district_id.SelectedIndexChanged
        ddl_subdistrict_id.DataSource = clsMnStationInfo.getSubdistrict(ddl_district_id.SelectedValue)
        ddl_subdistrict_id.DataTextField = "subdistrict_name"
        ddl_subdistrict_id.DataValueField = "subdistrict_id"
        If ddl_subdistrict_id.DataSource.rows.count > 0 Then
            ddl_subdistrict_id.DataBind()
        End If

    End Sub
    Private Sub setDDl()
        ddl_zone_id.DataSource = clsMnStationInfo.getZone
        ddl_zone_id.DataTextField = "zone_name"
        ddl_zone_id.DataValueField = "zone_id"
        ddl_zone_id.DataBind()

        ddl_province_id.DataSource = clsMnStationInfo.getProvince
        ddl_province_id.DataTextField = "province_name"
        ddl_province_id.DataValueField = "province_id"
        ddl_province_id.DataBind()

        ddl_district_id.DataSource = clsMnStationInfo.getDistrict()
        ddl_district_id.DataTextField = "district_name"
        ddl_district_id.DataValueField = "district_id"
        ddl_district_id.DataBind()

        ddl_subdistrict_id.DataSource = clsMnStationInfo.getSubdistrict()
        ddl_subdistrict_id.DataTextField = "subdistrict_name"
        ddl_subdistrict_id.DataValueField = "subdistrict_id"
        ddl_subdistrict_id.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        Dim prop As New clsMnStationInfo.propertys
        prop.station_id = station_id.Value
        prop.station_id_customer = txt_station_id_customer.Text.Trim
        prop.station_name = txt_station_name.Text.Trim
        prop.zone_id = GolbalFunc.Validation.BankToZero(ddl_zone_id.SelectedValue)
        prop.province_id = GolbalFunc.Validation.BankToZero(ddl_province_id.SelectedValue)
        prop.district_id = GolbalFunc.Validation.BankToZero(ddl_district_id.SelectedValue)
        prop.subdistrict_id = GolbalFunc.Validation.BankToZero(ddl_subdistrict_id.SelectedValue)
        prop.station_lattitude_utm = txt_station_lattitude_utm.Text.Trim
        prop.station_longitude_utm = txt_station_longitude_utm.Text.Trim
        prop.station_lattitude = txt_station_lattitude.Text.Trim
        prop.station_longitude = txt_station_longitude.Text.Trim

        prop.right_bank_wl_up = strToZero(txt_right_bank_wl_up.Text.Trim)
        prop.left_bank_wl_up = strToZero(txt_left_bank_wl_up.Text.Trim)
        prop.zerogate_up = strToZero(txt_zerogate_up.Text.Trim)
        prop.warning_up = strToZero(txt_warning_up.Text.Trim)
        prop.critical_up = strToZero(txt_critical_up.Text.Trim)

        prop.right_bank_wl_down = strToZero(txt_right_bank_wl_down.Text.Trim)
        prop.left_bank_wl_down = strToZero(txt_left_bank_wl_down.Text.Trim)
        prop.zerogate_down = strToZero(txt_zerogate_down.Text.Trim)
        prop.warning_down = strToZero(txt_warning_down.Text.Trim)
        prop.critical_down = strToZero(txt_critical_down.Text.Trim)
        If clsMnStationInfo.UpdateInfo(prop) Then
            MessageBox("บันทึกสำเร็จ")
        Else
            MessageBox("บันทึกไม่สำเร็จ", "ข้อผิดพลาด")
        End If
    End Sub
    Private Function strToZero(ByVal obj As Object) As Object
        If obj = "-" Then
            Return 0
        Else
            Return obj
        End If
    End Function
    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("admin_edit_station_list.aspx")
    End Sub

    Protected Sub txt_right_bank_wl_up_TextChanged(sender As Object, e As System.EventArgs) Handles txt_right_bank_wl_up.TextChanged
        SetCRI_WAR(txt_right_bank_wl_up, txt_left_bank_wl_up, "UP")
    End Sub

    Protected Sub txt_left_bank_wl_up_TextChanged(sender As Object, e As System.EventArgs) Handles txt_left_bank_wl_up.TextChanged
        SetCRI_WAR(txt_right_bank_wl_up, txt_left_bank_wl_up, "UP")
    End Sub

    Protected Sub txt_right_bank_wl_down_TextChanged(sender As Object, e As System.EventArgs) Handles txt_right_bank_wl_down.TextChanged
        SetCRI_WAR(txt_right_bank_wl_down, txt_left_bank_wl_down, "DOWN")
    End Sub

    Protected Sub txt_left_bank_wl_down_TextChanged(sender As Object, e As System.EventArgs) Handles txt_left_bank_wl_down.TextChanged
        SetCRI_WAR(txt_right_bank_wl_down, txt_left_bank_wl_down, "DOWN")
    End Sub
    Private Sub MessageBox(ByVal message As String, Optional ByVal Title As String = "Title")
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Title, String.Format("alert('{0}');", message), True)
    End Sub
    Private Sub SetCRI_WAR(ByVal right As TextBox, ByVal left As TextBox, ByVal type As String)
        Try
            If CDbl(right.Text) > CDbl(left.Text) Then
                If type = "UP" Then
                    txt_critical_up.Text = left.Text
                    txt_warning_up.Text = (CDbl(left.Text) - (CDbl(left.Text) * 0.2)).ToString("F2")
                ElseIf type = "DOWN" Then
                    txt_critical_down.Text = left.Text
                    txt_warning_down.Text = (CDbl(left.Text) - (CDbl(left.Text) * 0.2)).ToString("F2")
                End If
            ElseIf CDbl(right.Text) < CDbl(left.Text) Then
                If type = "UP" Then
                    txt_critical_up.Text = right.Text
                    txt_warning_up.Text = (CDbl(right.Text) - (CDbl(right.Text) * 0.2)).ToString("F2")
                ElseIf type = "DOWN" Then
                    txt_critical_down.Text = right.Text
                    txt_warning_down.Text = (CDbl(right.Text) - (CDbl(right.Text) * 0.2)).ToString("F2")
                End If
            End If
        Catch ex As Exception
            MessageBox("กรุณากรอกตัวเลขระดับตลิ่งให้ถูกต้อง", "เกิดข้อผิดพลาด")
        End Try

    End Sub
End Class
