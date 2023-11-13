Imports System.Data
Partial Class admin_view_station_list
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim DT As New datatable
        DT = clsMnStationInfo.getInfoList(IIf(Request.QueryString("CODE") Is Nothing, 1, CInt(Request.QueryString("CODE"))))
        If DT.Rows.Count > 0 Then
            lbl_stncode.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_id_customer"))
            lbl_stnname.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_name"))
            lbl_zone_name.Text = GolbalFunc.Validation.NulltoString(DT(0)("zone_name"))
            lbl_province_name.Text = GolbalFunc.Validation.NulltoString(DT(0)("province_name"))
            lbl_district_name.Text = GolbalFunc.Validation.NulltoString(DT(0)("district_name"))
            lbl_sub_district_name.Text = GolbalFunc.Validation.NulltoString(DT(0)("subdistrict_name"))
            lbl_station_lattitude_utm.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_lattitude_utm"))
            lbl_station_longitude_utm.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_longitude_utm"))
            lbl_station_lattitude.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_lattitude"))
            lbl_station_longitude.Text = GolbalFunc.Validation.NulltoString(DT(0)("station_longitude"))

            lblRight_bank_up.Text = GolbalFunc.Validation.NulltoString(DT(0)("right_bank_wl_up"))
            lblLeft_bank_up.Text = GolbalFunc.Validation.NulltoString(DT(0)("left_bank_wl_up"))
            lblZerogate_up.Text = GolbalFunc.Validation.NulltoString(DT(0)("zerogate_up"))
            lblWarning_up.Text = GolbalFunc.Validation.NulltoString(DT(0)("warning_up"))
            lblCritical_up.Text = GolbalFunc.Validation.NulltoString(DT(0)("critical_up"))

            lblRight_bank_down.Text = GolbalFunc.Validation.NulltoString(DT(0)("right_bank_wl_down"))
            lblLeft_bank_down.Text = GolbalFunc.Validation.NulltoString(DT(0)("left_bank_wl_down"))
            lblZerogate_down.Text = GolbalFunc.Validation.NulltoString(DT(0)("zerogate_down"))
            lblWarning_down.Text = GolbalFunc.Validation.NulltoString(DT(0)("warning_down"))
            lblCritical_down.Text = GolbalFunc.Validation.NulltoString(DT(0)("critical_down"))
        End If
    End Sub
End Class
