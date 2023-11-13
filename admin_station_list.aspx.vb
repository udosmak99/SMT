
Partial Class test_admin_station_list
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        gvStationList.DataSource = clsMnStationInfo.getInfoList
        gvStationList.DataBind()
        Dim stnList As New HtmlGenericControl
        stnList = CType(Master.FindControl("stnList"), HtmlGenericControl)
        If Not stnList Is Nothing Then
            stnList.Attributes.Add("class", "active")
        End If
    End Sub

    Protected Sub gvStationList_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvStationList.PageIndexChanging
        gvStationList.PageIndex = e.NewPageIndex
        DataBind()
    End Sub
End Class
