Imports System.Data
Partial Class Delete_User
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
    Protected Sub grvUser_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvUser.Sorting
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
        'Try

        '    If e.Row.RowType = DataControlRowType.Pager Then
        '        Dim tb As Table = TryCast(e.Row.Cells(0).Controls(0), Table)
        '        tb.Width = 927
        '        If (tb.Rows(0).Cells.Count = 7) Then
        '            '****
        '            Dim cell0 As New TableCell()
        '            cell0.Text = "ข้อมูล " & (grvUser.DataSource).rows.count & " รายการ "
        '            cell0.Width = 927 * 0.4
        '            cell0.HorizontalAlign = HorizontalAlign.Left
        '            tb.Rows(0).Cells.AddAt(0, cell0)
        '            ' Cell1 อยู่ตรงกลาง Grid  cell1.Width = 0.2 'กว้าง 0.2 
        '            Dim cell2 As New TableCell()
        '            cell2.Text = "หน้า " & grvUser.PageIndex + 1
        '            cell2.HorizontalAlign = HorizontalAlign.Right
        '            cell2.Width = 927 * 0.4
        '            tb.Rows(0).Cells.AddAt(tb.Rows(0).Cells.Count, cell2)
        '        ElseIf (tb.Rows(0).Cells.Count < 7) Then
        '            '****
        '            Dim cell0 As New TableCell()
        '            cell0.Text = "ข้อมูล " & (grvUser.DataSource).rows.count & " รายการ "
        '            cell0.Width = 927 * 0.49
        '            cell0.HorizontalAlign = HorizontalAlign.Left
        '            tb.Rows(0).Cells.AddAt(0, cell0)
        '            ' Cell1 อยู่ตรงกลาง Grid  cell1.Width = 0.02
        '            Dim cell2 As New TableCell()
        '            cell2.Text = "หน้า " & grvUser.PageIndex + 1
        '            cell2.HorizontalAlign = HorizontalAlign.Right
        '            cell2.Width = 927 * 0.49
        '            tb.Rows(0).Cells.AddAt(tb.Rows(0).Cells.Count, cell2)
        '        End If
        '    End If
        'Catch ex As Exception
        '    Throw New Exception(ex.Message)
        'End Try
    End Sub
    Protected Sub Buttonallow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim bJump As Boolean = False

        Dim checkdelete As Boolean
      
        Try
            bJump = True
        Catch
        End Try
        If bJump Then checkdelete = clsUser.Delete(HiddenId.Value)
        If checkdelete Then BindData()
    End Sub
    Protected Sub ImgDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim user_id As String

        Dim row As GridViewRow = CType(CType(sender, ImageButton).Parent.Parent, GridViewRow)
        user_id = CType(row.FindControl("ImgDelete"), ImageButton).CommandArgument
        HiddenId.Value = user_id
        ModalPopupExtender2.Show()
    End Sub
    Protected Sub lbluser_name_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim bJump As Boolean = False
        Dim user_id As String
        Dim row As GridViewRow = CType(CType(sender, LinkButton).Parent.Parent, GridViewRow)
        user_id = CType(row.FindControl("lblid"), Label).Text
        Session("user_id") = user_id
        Try
            bJump = True
        Catch
        End Try
        If bJump Then Response.Redirect("Edit_User.aspx")
    End Sub
End Class
