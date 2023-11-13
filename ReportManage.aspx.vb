Imports System.Data
Partial Class ReportManage
    Inherits System.Web.UI.Page
    Dim stn As String
    Dim tblName As String
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Not (IsPostBack) Then
                Session("success") = "false"
                SetControl()
                If Not (Session("reports") Is Nothing) Then
                    CryReport.ReportSource = Session("reports")
                End If
            Else
                If Session("success") = "true" Then
                    CryReport.ReportSource = Session("reports")
                End If
            End If
        Catch ex As Exception
            Throw New Exception("Page_Load Error : " & ex.Message)
        End Try
    End Sub
    Public Sub SetControl()
        setZone()
        setBasin()
        setProvince()
        setStn()
        txtDay.Text = Now.ToString("dd/MM/yyyy", GolbalFunc.EN.DateTimeFormat)
        txtMonth.Text = Now.ToString("MM/yyyy", GolbalFunc.EN.DateTimeFormat)
        txtYear.Text = Now.ToString("yyyy", GolbalFunc.EN.DateTimeFormat)
        btnShow.Enabled = False
    End Sub
    Protected Sub ddlGroup_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged
        SetControl()
        If ddlGroup.SelectedValue = 1 Then
            mtvGroup.ActiveViewIndex = 0
        ElseIf ddlGroup.SelectedValue = 2 Then
            mtvGroup.ActiveViewIndex = 1
        ElseIf ddlGroup.SelectedValue = 3 Then
            mtvGroup.ActiveViewIndex = 2
        End If
    End Sub
    Private Sub setStn()
        ddlStn.Items.Clear()
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกสถานี--"
        ddlStn.Items.Add(listP)
    End Sub
    Private Sub setZone()
        ddlZone.Items.Clear()
        Dim dt As DataTable = smtModel.getZone
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกศูนย์/โครงการ--"
        ddlZone.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("zone_id")
            Item.Text = r.Item("zone_name")
            ddlZone.Items.Add(Item)
        Next
    End Sub
    Private Sub setBasin()
        ddlBasin.Items.Clear()
        Dim dt As DataTable = smtModel.getBasin
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกลุ่มน้ำ--"
        ddlBasin.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("basin_id")
            Item.Text = r.Item("basin_name")
            ddlBasin.Items.Add(Item)
        Next
    End Sub
    Private Sub setProvince()
        ddlProvice.Items.Clear()
        Dim dt As DataTable = smtModel.getProvince
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกจังหวัด--"
        ddlProvice.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("province_id")
            Item.Text = r.Item("province_name")
            ddlProvice.Items.Add(Item)
        Next
    End Sub
    Private Sub setStnZone(ByVal Zone As Integer)
        ddlStn.Items.Clear()
        Dim dt As DataTable = smtModel.getStnZone(Zone)
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกสถานี--"
        ddlStn.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("station_id")
            Item.Text = r.Item("station_name")
            ddlStn.Items.Add(Item)
        Next
    End Sub
    Private Sub setStnBasin(ByVal Basin As Integer)
        ddlStn.Items.Clear()
        Dim dt As DataTable = smtModel.getStnBasin(Basin)
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกสถานี--"
        ddlStn.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("station_id")
            Item.Text = r.Item("station_name")
            ddlStn.Items.Add(Item)
        Next
    End Sub
    Private Sub setStnProvince(ByVal Province As Integer)
        ddlStn.Items.Clear()
        Dim dt As DataTable = smtModel.getStnProvince(Province)
        Dim listP As New ListItem
        listP.Value = "0"
        listP.Text = "--กรุณาเลือกสถานี--"
        ddlStn.Items.Add(listP)
        For Each r As DataRow In dt.Rows
            Dim Item As New ListItem
            Item.Value = r.Item("station_id")
            Item.Text = r.Item("station_name")
            ddlStn.Items.Add(Item)
        Next
    End Sub
    Protected Sub ddlZone_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlZone.SelectedIndexChanged
        btnShow.Enabled = False
        If ddlZone.SelectedValue <> "0" Then
            setStnZone(ddlZone.SelectedValue)
        Else
            setStn()
        End If
    End Sub
    Protected Sub ddlBasin_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlBasin.SelectedIndexChanged
        btnShow.Enabled = False
        If ddlBasin.SelectedValue <> "0" Then
            setStnBasin(ddlBasin.SelectedValue)
        Else
            setStn()
        End If
    End Sub

    Protected Sub ddlProvice_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlProvice.SelectedIndexChanged
        btnShow.Enabled = False
        If ddlProvice.SelectedValue <> "0" Then
            setStnProvince(ddlProvice.SelectedValue)
        Else
            setStn()
        End If
    End Sub
    Protected Sub btnShow_Click(sender As Object, e As System.EventArgs) Handles btnShow.Click
        Session("success") = "true"
        CheckCondition()
    End Sub
    
    Public Sub CheckCondition()
        Try
            stn = ddlStn.SelectedValue
            Dim dtrow As DataRow = smtModel.getTableName(stn)
            tblName = dtrow.Item("table_name")
            'Dim water_sensor As Integer = dtrow.Item("water_sensor")
            Dim type As Integer = ddlType.SelectedValue
            Dim condition As Integer = ddlCondition.SelectedValue
            If type = 1 Then
                Select Case condition
                    Case 1
                        Session("reports") = RainDay()
                    Case 2
                        Session("reports") = RainMonth()
                    Case 3
                        Session("reports") = RainYear()
                End Select
            ElseIf type = 2 Then
                 Select condition
                    Case 1
                        Session("reports") = WaterlevelTran()
                    Case 2
                        Session("reports") = WaterlevelHour()
                    Case 3
                        Session("reports") = WaterlevelDay2()
                End Select
            End If
            If Not (Session("reports") Is Nothing) Then
                CryReport.ReportSource = Session("reports")
            End If
        Catch ex As Exception
            Throw New Exception("CheckCondition Error : " & ex.Message)
        End Try
    End Sub
    Private Function RainYear() As clsRPT
        Dim RY As New clsRainYearControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtYear.Text.Split("/")                '05/11/2013
        Dim Year As Integer = txtYear.Text  'CInt(dtm(2))
        Return RY.Report(stnCode, Year, tblName)
    End Function

    Private Function RainMonth() As clsRPT
        Dim RM As New clsRainMonthControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtMonth.Text.Split("/")                '05/11/2013
        Dim month As Integer = CInt(dtm(0))
        Dim year As Integer = CInt(dtm(1))
        Return RM.Report(stnCode, month, year, tblName)
    End Function

    Private Function RainDay() As clsRPT
        Dim RD As New clsRainDayControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtDay.Text.Split("/")
        Dim day As Integer = CInt(dtm(0))
        Dim month As Integer = CInt(dtm(1))
        Dim year As Integer = CInt(dtm(2))
        Return RD.Report(stnCode, day, month, year, tblName)
    End Function
    Private Function WaterlevelTran() As clsRPT
        Dim WT As New clsWLTranControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtDay.Text.Split("/")
        Dim day As Integer = CInt(dtm(0))
        Dim month As Integer = CInt(dtm(1))
        Dim year As Integer = CInt(dtm(2))
        Return WT.Report(stnCode, day, month, year, tblName)
    End Function
    Private Function WaterlevelHour() As clsRPT
        Dim WH As New clsWLHourControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtDay.Text.Split("/")
        Dim day As Integer = CInt(dtm(0))
        Dim month As Integer = CInt(dtm(1))
        Dim year As Integer = CInt(dtm(2))
        Return WH.Report(stnCode, day, month, year, tblName)
    End Function
    Private Function WaterlevelDay2() As clsRPT
        Dim WD2 As New clsWLDayControl
        Dim stnCode As String = stn
        Dim dtm() As String = txtMonth.Text.Split("/")
        Dim month As Integer = CInt(dtm(0))
        Dim year As Integer = CInt(dtm(1))
        Return WD2.Report(stnCode, month, year, tblName)
    End Function
   
    Protected Sub ddlCondition_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCondition.SelectedIndexChanged
        If ddlType.SelectedValue = 1 Then
            If ddlCondition.SelectedValue = 1 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 2 Then
                mtvMain.ActiveViewIndex = 1
            ElseIf ddlCondition.SelectedValue = 3 Then
                mtvMain.ActiveViewIndex = 2
            End If
        ElseIf ddlType.SelectedValue = 2 Then
            If ddlCondition.SelectedValue = 1 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 2 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 3 Then
                mtvMain.ActiveViewIndex = 1
            End If
        End If
    End Sub

    Protected Sub ddlStn_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlStn.SelectedIndexChanged
        If ddlStn.SelectedValue = "0" Then
            btnShow.Enabled = False
        Else
            btnShow.Enabled = True
        End If
    End Sub

    Protected Sub ddlType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlType.SelectedIndexChanged
        If ddlType.SelectedValue = 1 Then
            If ddlCondition.SelectedValue = 1 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 2 Then
                mtvMain.ActiveViewIndex = 1
            ElseIf ddlCondition.SelectedValue = 3 Then
                mtvMain.ActiveViewIndex = 2
            End If
        ElseIf ddlType.SelectedValue = 2 Then
            If ddlCondition.SelectedValue = 1 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 2 Then
                mtvMain.ActiveViewIndex = 0
            ElseIf ddlCondition.SelectedValue = 3 Then
                mtvMain.ActiveViewIndex = 1
            End If
        End If
    End Sub

  
End Class
