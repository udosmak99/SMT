
Partial Class ChangePassword
    Inherits System.Web.UI.Page

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        CleartxtBox()
    End Sub
    Private Sub CleartxtBox()
        pnlConfirm.Visible = False
        txtoldpassword.Text = ""
        txtnewpassword.Text = ""
        txtconfirmpassword.Text = ""
   

    End Sub
    Private Function checktxtpassword(ByVal login As String, ByVal password As String) As String
        Try
            Dim cmdLastData As New System.Data.SqlClient.SqlCommand
            Dim dtsSession As New System.Data.DataSet
            cmdLastData.CommandType = System.Data.CommandType.Text
            cmdLastData.CommandText = "select user_password from tbl_user where user_login = '" & login & "' and user_password = '" & password & "'"
            cmdLastData.Connection = GolbalFunc.Database.Connection
            Dim dtaSession As New System.Data.SqlClient.SqlDataAdapter(cmdLastData)
            dtaSession.Fill(dtsSession, "tbl_user_login")
            If dtsSession.Tables("tbl_user_login").Rows(0).Item("user_password") Is Nothing Then
                Return ""
            Else
                If dtsSession.Tables("tbl_user_login").Rows.Count > 0 Then
                    Return dtsSession.Tables("tbl_user_login").Rows(dtsSession.Tables("tbl_user_login").Rows.Count - 1).Item("user_password")
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)

        End Try
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim sendsms, sendemail As Integer
        If txtoldpassword.Text <> "" Or txtnewpassword.Text <> "" Or txtconfirmpassword.Text <> "" Then
            If txtnewpassword.Text = txtconfirmpassword.Text And txtoldpassword.Text = checktxtpassword(txtUsername.Text, txtoldpassword.Text) Then
               
                If cUser.updatepass(txtUsername.Text, txtnewpassword.Text, sendsms, sendemail) Then
                    CleartxtBox()
                    lblalert.Text = "แก้ไขรหัสผ่านเรียบร้อย"
                    pnlConfirm.Visible = True
                    ModalPopupExtenderconfirm.Show()
                End If
            Else
                If txtoldpassword.Text <> checktxtpassword(txtUsername.Text, txtoldpassword.Text) Then
                    lblalert.Text = "กรุณาใส่รหัสเดิมให้ถูกต้อง"
                    pnlConfirm.Visible = True
                    ModalPopupExtenderconfirm.Show()
                Else
                    If txtnewpassword.Text <> txtconfirmpassword.Text Then
                        lblalert.Text = "กรุณาใส่รหัสยืนยันให้ตรงกัน"
                        pnlConfirm.Visible = True
                        ModalPopupExtenderconfirm.Show()
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim item As New UserItem
        item = Session("LoginDesc")
        txtUsername.Text = item.LOGIN_NAME
        txtUsername.Enabled = False
    End Sub
End Class
