Imports System.Web
Imports System.Web.UI
Imports Microsoft.VisualBasic
Imports System.Globalization

Partial Class Add_User
    Inherits System.Web.UI.Page

   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            CleartxtBox()
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim us_item As New UserItem
        Dim checkinsert As Boolean = True
        If clsUser.CheckUserName(txtusername.Text) Then
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
           

        Else
            lblalert.Text = "Username ที่ใช้ login ซ้ำ"
            checkinsert = False
        End If


        If checkinsert = True Then
            If cUser.Save(us_item) Then

                CleartxtBox()
                lblalert.Text = "เพิ่มข้อมูลผู้ใช้สำเร็จ"
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

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        CleartxtBox()
        Response.Redirect("Show_User.aspx")
    End Sub
    Private Sub CleartxtBox()
        txtfirstname.Text = ""
        txtlastname.Text = ""
        txtposition.Text = ""
        txtPhone.Text = ""
        txtEmail.Text = ""
        txtusername.Text = ""
        ChkEmail.Checked = False
        chkSms.Checked = False
        ddlUserLevel.SelectedValue = 1
    End Sub
End Class
