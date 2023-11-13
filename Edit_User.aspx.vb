
Partial Class Edit_User
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            Dim datauser As System.Data.DataTable = clsUser.QueryEditUser(Session("user_id"))
            txtfirstname.Text = datauser.Rows(datauser.Rows.Count - 1).Item("user_name")
            txtlastname.Text = datauser.Rows(datauser.Rows.Count - 1).Item("user_lastname")
            txtposition.Text = datauser.Rows(datauser.Rows.Count - 1).Item("user_position")
            txtEmail.Text = datauser.Rows(datauser.Rows.Count - 1).Item("user_email")
            txtPhone.Text = datauser.Rows(datauser.Rows.Count - 1).Item("user_phone")
            txtusername.Text = datauser.Rows(datauser.Rows.Count - 1).Item("user_login")
            txtusername.Enabled = False
            ddlUserLevel.SelectedValue = CInt(datauser.Rows(datauser.Rows.Count - 1).Item("userlevel_id"))
            If datauser.Rows(datauser.Rows.Count - 1).Item("user_sendsms") = 1 Then
                chkSms.Checked = True
            Else
                chkSms.Checked = False
            End If
            If datauser.Rows(datauser.Rows.Count - 1).Item("user_sendemail") = 1 Then
                ChkEmail.Checked = True
            Else
                ChkEmail.Checked = False
            End If
        End If
        
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim us_item As New UserItem
        Dim checkinsert As Boolean = True
        us_item.LOGIN_NAME = txtusername.Text
        us_item.LOGIN_PASSWORD = "1234"
        us_item.NAME = txtfirstname.Text
        us_item.LAST_NAME = txtlastname.Text
        us_item.POSITION = txtposition.Text
        us_item.USER_LEVEL = ddlUserLevel.SelectedValue
        If chkSms.Checked = True Then
            us_item.SENS_SMS = 1
            If GolbalFunc.Validation.Mobile(txtPhone.Text) Then
                us_item.PHONE = txtPhone.Text
                If ChkEmail.Checked = True Then
                    us_item.SENS_EMAIL = 1
                    If GolbalFunc.Validation.Email(txtEmail.Text) Then
                        us_item.EMAIL = txtEmail.Text
                    Else
                        lblalert.Text = "กรุณาใส่Emailให้ถูกต้อง"
                        checkinsert = False
                    End If
                Else
                    us_item.SENS_EMAIL = 0
                    If txtEmail.Text = "" Or txtEmail.Text = "-" Then
                        checkinsert = True
                    Else
                        If GolbalFunc.Validation.Email(txtEmail.Text) Then
                            us_item.EMAIL = txtEmail.Text
                            checkinsert = True
                        Else
                            lblalert.Text = "กรุณาใส่Emailให้ถูกต้อง"
                            checkinsert = False
                        End If
                    End If

                End If
            Else
                lblalert.Text = "กรุณาใส่เบอร์โทรศัพท์ให้ถูกต้อง"
                checkinsert = False
            End If
        Else
            us_item.SENS_SMS = 0
            If txtPhone.Text = "" Or txtPhone.Text = "-" Then
                us_item.PHONE = "-"


                If ChkEmail.Checked = True Then
                    us_item.SENS_EMAIL = 1
                    If GolbalFunc.Validation.Email(txtEmail.Text) Then
                        us_item.EMAIL = txtEmail.Text
                    Else
                        lblalert.Text = "กรุณาใส่Emailให้ถูกต้อง"
                        checkinsert = False
                    End If
                Else
                    us_item.SENS_EMAIL = 0
                    If txtEmail.Text = "" Or txtEmail.Text = "-" Then
                        us_item.EMAIL = "-"
                        checkinsert = True
                    Else
                        If GolbalFunc.Validation.Email(txtEmail.Text) Then
                            us_item.EMAIL = txtEmail.Text
                            checkinsert = True
                        Else
                            lblalert.Text = "กรุณาใส่Emailให้ถูกต้อง"
                            checkinsert = False
                        End If
                    End If

                End If



            Else
                If GolbalFunc.Validation.Mobile(txtPhone.Text) Then
                    us_item.PHONE = txtPhone.Text
                    If ChkEmail.Checked = True Then
                        us_item.SENS_EMAIL = 1
                        If GolbalFunc.Validation.Email(txtEmail.Text) Then
                            us_item.EMAIL = txtEmail.Text
                        Else
                            lblalert.Text = "กรุณาใส่Emailให้ถูกต้อง"
                            checkinsert = False
                        End If
                    Else
                        us_item.SENS_EMAIL = 0
                        If txtEmail.Text = "" Or txtEmail.Text = "-" Then
                            us_item.EMAIL = "-"
                            checkinsert = True
                        Else
                            If GolbalFunc.Validation.Email(txtEmail.Text) Then
                                us_item.EMAIL = txtEmail.Text
                                checkinsert = True
                            Else
                                lblalert.Text = "กรุณาใส่Emailให้ถูกต้อง"
                                checkinsert = False
                            End If
                        End If

                    End If
                Else
                    lblalert.Text = "กรุณาใส่เบอร์โทรศัพท์ให้ถูกต้อง"
                    checkinsert = False
                End If
            End If

        End If

        If checkinsert = True Then
            Dim checkEdit As Boolean = clsUser.UpdateDataUser(us_item, Session("user_id"))
            If checkEdit = True Then
                lblalert.Text = "แก้ไขข้อมูลผู้ใช้สำเร็จ"
                ButtonOK.Visible = True
                ButtonOK1.Visible = False
                pnlConfirm.Visible = True
                Me.ModalPopupExtenderconfirm.Show()

            End If
        Else
            ButtonOK.Visible = False
            ButtonOK1.Visible = True
            pnlConfirm.Visible = True
            Me.ModalPopupExtenderconfirm1.Show()
        End If

    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Response.Redirect("Delete_User.aspx")
    End Sub
End Class
