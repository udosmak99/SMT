
Partial Class admin_edit_station_list
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        gvStationList.DataSource = clsMnStationInfo.getInfoList(False)
        gvStationList.DataBind()
    End Sub

    Protected Sub gvStationList_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvStationList.PageIndexChanging
        gvStationList.PageIndex = e.NewPageIndex
        DataBind()
    End Sub
End Class
