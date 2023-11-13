Imports System.Data
Partial Class Show_User
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            BindData()

        End If
        
    End Sub
    Private Sub BindData()
        Dim tbl As DataTable = clsUser.QueryUserData
        Session("RowCount") = tbl.Rows.Count
        ViewState("SortingOnly") = tbl
        grvUser.DataSource = tbl
        grvUser.DataBind()
    End Sub
    Protected Sub grvUser_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvUser.PageIndexChanging
        grvUser.PageIndex = e.NewPageIndex
        Dim s As New GridViewSortEventArgs(ViewState("SortExpression"), ViewState("sortDirection"))
        If ViewState("sortDirection") Is Nothing Then
            ViewState("sortDirection") = SortDirection.Ascending

        Else
            If ViewState("sortDirection") = SortDirection.Ascending Then
                ViewState("sortDirection") = SortDirection.Descending
            Else
                ViewState("sortDirection") = SortDirection.Ascending
            End If
        End If
        Dim oGrdModel As New GolbalFunc.GridViewModel(grvUser)
        oGrdModel.GridViewSort(s, ViewState("sortDirection"), ViewState("SortingOnly"))
    End Sub
    Protected Sub grdUser_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvUser.RowCreated
        If e.Row.RowType = DataControlRowType.Pager Then
            Dim oGrdModel As New GolbalFunc.GridViewModel(grvUser)
            oGrdModel.Gridview_RowCreated(e, Session("RowCount"))
        End If
    End Sub
    Protected Sub grdUser_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvUser.Sorting
        Dim oGrdModel As New GolbalFunc.GridViewModel(grvUser)
        If ViewState("sortDirection") Is Nothing AndAlso e.SortExpression = "user_order" Then
            ViewState("sortDirection") = SortDirection.Descending
            ViewState("SortExpression") = e.SortExpression
        ElseIf ViewState("SortExpression") <> e.SortExpression Then
            ViewState("sortDirection") = SortDirection.Ascending
            ViewState("SortExpression") = e.SortExpression
        End If
        oGrdModel.GridViewSort(e, ViewState("sortDirection"), ViewState("SortingOnly"))
    End Sub
    Protected Sub grvUser_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvUser.RowDataBound
        
    End Sub
End Class
