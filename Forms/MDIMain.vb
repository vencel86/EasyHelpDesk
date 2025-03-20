Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Public Class MDIMain
    Dim PopupCtrl As ListView
    Private m_SortingColumn As ColumnHeader
    Private trd As Threading.Thread
    Dim strCallsToday As String = String.Empty
    Dim strCallsOpen As String = String.Empty
    Dim strCallsNA As String = String.Empty
    Dim strCallsOnHold As String = String.Empty
    Dim strCallsAwaitInfo As String = String.Empty
    Dim strCallsAwaitParts As String = String.Empty

    Private Sub MDIMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        '<EhHeader>
        Try
            '</EhHeader>
            If e.Control Then
                If e.KeyCode = Keys.A Then
                    rbArea.Checked = True
                    cboSearch.Focus()
                End If
                If e.KeyCode = Keys.S Then
                    rbServiceType.Checked = True
                    cboSearch.Focus()
                End If
                If e.KeyCode = Keys.P Then
                    lvToday.Focus()
                    If lvToday.Items.Count <> 0 Then
                        lvToday.Items(0).Selected = True
                    End If
                End If
                If e.KeyCode = Keys.O Then
                    lvCalls.Focus()
                    If lvCalls.Items.Count <> 0 Then
                        lvCalls.Items(0).Selected = True
                    End If
                End If
                If e.KeyCode = Keys.R Then
                    btnReset_Click(sender, e)
                    lvCalls.Focus()
                    If lvCalls.Items.Count <> 0 Then
                        lvCalls.Items(0).Selected = True
                    End If
                End If
                If e.KeyCode = Keys.E Then
                    Dim frmSearch As New CallSearchQuery
                    If frmSearch.ShowDialog = DialogResult.OK Then
                        FillTodaysCall(frmSearch.MyValue)
                        frmSearch.Dispose()
                    End If
                End If
            End If

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillUsers()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Emp order by EmpName", cnMain)
            Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
            cboUser.Items.Clear()
            cboUser.Items.Add(New MyList("Admin", "0"))
            If readr.HasRows Then
                While readr.Read
                    cboUser.Items.Add(New MyList(readr.Item("EmpName"), readr.Item("EmpCode")))
                End While
                If cboUser.Items.Count <> 0 Then cboUser.SelectedIndex = 0
            Else
                cboUser.Text = "Admin"
            End If
            cboUser.SelectedIndex = 0
            readr.Close()
            cmd.Dispose()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub MDIMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<EhHeader>
        Try
            '</EhHeader>

            If GR_Done() = False Then
                DeveloperName = False
                Me.Text = My.Application.Info.Title.ToString & " V " & My.Application.Info.Version.ToString.Substring(0, 4) ' & " - Evaluation Version"
                If Today.Year > 2030 Then Me.Close()
            Else
                DeveloperName = True
            End If
            modDBRead.LoadSettings()

            Me.sbCompanyName.Text = "   Company Name: " + PCompanyName + "   "

            Call FillEmpLV()
            Call FillTodaysCall()
            Call FillCallsLV()

            Call FillTotalCalls()
            Call FilLSearch()
            Call FillUsers()
            sbUserName.Text = "  User: " + lblUserCode.Tag.ToString + "   "
            sbDate.Text = "   " + Now.ToString(DTFormat) + "   "
            sbTime.Text = "   " + Now.ToString("HH:mm tt") + "   "


            'Application.EnableVisualStyles()
            'Application.DoEvents()

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Public Sub FillTodaysCall(Optional ByVal strSCriteria As String = "")
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Dim strQPart As String = ""
            Dim strSelCode As Integer = 0
            If lvToday.Items.Count <> 0 Then
                If lvToday.SelectedItems.Count <> 0 Then
                    strSelCode = lvToday.SelectedIndices(0)
                End If
            End If
            Try
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                strQPart = "Select CallCode, RefNo, tbl_CallGen.CustCode, CallDesc, format([DuesOn],'" & DTTFormat & "') as DDate," &
                            "format([AssignTime],'" & DTFormat & "') as DT, format([AssignTime],'" & DTTFormat & "') as TT, AssignCode, " &
                            "tbl_cust.CustName as CT, AssignTime, tbl_Cust.Area, tbl_Ser.ApproxHour, tbl_ser.ApproxMinute, tbl_Ser.SName, CallUnder, format([tbl_Cust.AMCEndDate],'" & DTFormat & "') as AmcEndDate " &
                            "from tbl_CallGen, tbl_cust, tbl_Ser " &
                            "where [AssignCode] Is Not Null And len([AssignCode]) <> 0 " &
                            "And tbl_callgen.CallSCode = tbl_Ser.MCode " &
                            "And tbl_callgen.Custcode = tbl_cust.Custcode " &
                            "And CurrentStatus= 'Open' and tbl_Callgen.CustCode in ( select CustCode from tbl_Cust)"

                If strSCriteria <> String.Empty Then
                    strQuery = strQPart + " And " + strSCriteria
                Else
                    strQuery = strQPart
                End If
                '0 callcode
                '1 refno
                '2 custcode
                '3 calldesc
                '4 ddate
                '5 DT
                '6 TT
                '7 assign code
                '8 Cust Name CT
                '9 Assign Time
                '10 Area
                '11 Hour
                '12 Minute

                Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Dim strTmp As String
                lvToday.Items.Clear()
                If readr.HasRows Then
                    While readr.Read
                        With lvToday.Items.Add(readr.Item("CallCode").ToString)
                            .SubItems.Add(readr.Item("RefNo").ToString)
                            .SubItems.Add(readr.Item("CT"))

                            If readr.IsDBNull(13) <> True Then
                                .SubItems.Add(readr.Item("SName").ToString)
                            Else
                                .SubItems.Add("")
                            End If

                            If readr.IsDBNull(13) <> True Then ' Warranty
                                Dim strTmp1 As String = readr.Item("CallUnder").ToString.Substring(0, 1)
                                If strTmp1 = "A" Then
                                    '.SubItems.Add("AMC")
                                    .SubItems.Add(readr.Item("AMCEndDate").ToString)
                                ElseIf strTmp1 = "W" Then
                                    '.SubItems.Add("End " + readr.Item("AMCEndDate").ToString)
                                    .SubItems.Add(readr.Item("AMCEndDate").ToString)
                                Else
                                    '.SubItems.Add("AMC")
                                    .SubItems.Add(readr.Item("AMCEndDate").ToString)
                                End If
                            Else
                                '.SubItems.Add("AMC")
                                .SubItems.Add(readr.Item("AMCEndDate").ToString)
                            End If

                            If readr.IsDBNull(10) <> True Then
                                .SubItems.Add(readr.Item("Area").ToString)
                            Else
                                .SubItems.Add("")
                            End If

                            If readr.IsDBNull(5) <> True Then
                                strTmp = readr.Item("DT").ToString
                                .SubItems.Add(strTmp + Space(2) + readr.Item("TT"))
                                'strTmp = readr.Item("TT")
                                '.SubItems.Add(strTmp)
                            Else
                                .SubItems.Add("")
                                .SubItems.Add("")
                            End If

                            Dim dblDay As Double = DateDiff(DateInterval.Day, readr.Item("AssignTime"), Now)
                            Dim dblHour As Double = DateDiff(DateInterval.Hour, readr.Item("AssignTime"), Now)
                            Dim dblMinute As Double = DateDiff(DateInterval.Minute, readr.Item("AssignTime"), Now)
                            Dim dbltTmp As Double = 0

                            If dblHour > 24 Then
                                dbltTmp = dblHour Mod 24
                                dblHour = dbltTmp
                            End If

                            If dblMinute > 60 Then
                                dblMinute = dblMinute Mod 1440
                                dblMinute = dblMinute Mod 60
                            End If
                            Try

                                If dblHour > readr.Item("ApproxHour") Then
                                    .ForeColor = Color.Red
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                If dblMinute > readr.Item("ApproxMinute") Then
                                    .ForeColor = Color.Red
                                End If
                            Catch ex As Exception

                            End Try
                            Dim tmpStr As String = String.Empty
                            If dblDay <> 0 Then
                                tmpStr = dblDay & " Day "
                            End If
                            strTmp = tmpStr & dblHour & " Hour "
                            strTmp = strTmp & dblMinute & " Minute "
                            .SubItems.Add(strTmp)


                            If readr.IsDBNull(8) <> True Then
                                Dim strTmp1 As String = GetTextFromCode("EmpCode", readr.Item("AssignCode").ToString, "EmpName", "tbl_Emp")
                                .SubItems.Add(If(strTmp1 = "0", "-", strTmp1))
                            Else
                                .SubItems.Add("")
                            End If

                            If readr.IsDBNull(11) <> True Then ' Adding Hour to hidden column
                                .SubItems.Add(readr.Item("ApproxHour"))
                            Else
                                .SubItems.Add(0)
                            End If
                            If readr.IsDBNull(12) <> True Then ' Adding minute to hidden column
                                .SubItems.Add(readr.Item("ApproxMinute"))
                            Else
                                .SubItems.Add(0)
                            End If
                        End With
                    End While
                End If
                If lvToday.Items.Count > 0 Then
                    'If strSelCode <> 0 Then
                    lvToday.Items(strSelCode).Selected = True
                    'End If
                End If
                readr.Close()
                cmd = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Public Sub FillCallsLV(Optional ByVal strPartQuery As String = "")
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Try
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                strQuery = "Select CallCode, RefNo, tbl_CallGen.CustCode, CallDesc, CallSCode, tbl_Cust.Area, CurrentStatus, format([DuesOn],'" & DTFormat & "') as DDate, format([RecDate],'" & DTFormat & "') as DT, format([RecDate],'" & DTTFormat & "') as TT, tbl_Cust.CustName, tbl_Callgen.CallUnder, format([tbl_Cust.AMCEndDate],'" & DTFormat & "') as AmcEndDate from tbl_cust " _
                            & "INNER JOIN tbl_CallGen ON tbl_cust.CustCode = tbl_CallGen.CustCode where CurrentStatus = 'Open' and len(AssignCode)=0"
                If strPartQuery <> String.Empty Then
                    strQuery = strQuery + " and " & strPartQuery
                End If

                Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                Dim strTmp As String
                lvCalls.Items.Clear()
                If readr.HasRows Then
                    While readr.Read

                        With lvCalls.Items.Add(readr.Item("CallCode").ToString)
                            .SubItems.Add(readr.Item("RefNo").ToString)

                            If readr.IsDBNull(11) <> True Then 'Service Name / Type
                                .SubItems.Add(readr.Item("CustName"))
                            Else
                                .SubItems.Add("")
                            End If

                            If readr.IsDBNull(4) <> True Then 'Service Name / Type
                                Dim strTmp1 As String = GetTextFromCode("MCode", readr.Item("CallSCode").ToString, "SName", "tbl_Ser")
                                .SubItems.Add(If(strTmp1 = "0", "-", strTmp1))
                            Else
                                .SubItems.Add("")
                            End If

                            If readr.IsDBNull(3) <> True Then
                                .SubItems.Add(readr.Item("CallDesc").ToString)
                            Else
                                .SubItems.Add("")
                            End If

                            If readr.IsDBNull(12) <> True Then ' Warranty
                                Dim strTmp1 As String = readr.Item("CallUnder").ToString.Substring(0, 1)
                                If strTmp1 = "A" Then
                                    '   .SubItems.Add("AMC")
                                    .SubItems.Add(readr.Item("AMCEndDate").ToString)
                                ElseIf strTmp1 = "W" Then
                                    '.SubItems.Add("End " + readr.Item("AMCEndDate").ToString)
                                    .SubItems.Add(readr.Item("AMCEndDate").ToString)
                                Else
                                    '.SubItems.Add("AMC")
                                    .SubItems.Add(readr.Item("AMCEndDate").ToString)
                                End If
                            Else
                                '.SubItems.Add("AMC")
                                .SubItems.Add(readr.Item("AMCEndDate").ToString)
                            End If

                            If readr.IsDBNull(5) <> True Then
                                strTmp = readr.Item("DT").ToString
                                .SubItems.Add(strTmp)
                                strTmp = readr.Item("TT")
                                .SubItems.Add(strTmp)
                            Else
                                .SubItems.Add("")
                                .SubItems.Add("")
                            End If

                            If readr.IsDBNull(5) <> True Then
                                .SubItems.Add(readr.Item("Area"))
                            Else
                                .SubItems.Add("")
                            End If
                        End With
                    End While
                End If
                ' lvCustView.Items(0).Selected = True
                readr.Close()
                cmd = Nothing

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub HelpToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnExit.Click
        '<EhHeader>
        Try
            '</EhHeader>
            mnuExit_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub MDIMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '<EhHeader>
        Try
            '</EhHeader>
            Dim intWidth As Integer = 0
            intWidth = lvCalls.Width

            lvCalls.Columns(1).Width = intWidth * 0.08 'code
            lvCalls.Columns(2).Width = intWidth * 0.15 'customer name
            lvCalls.Columns(3).Width = intWidth * 0.12 'Service Type
            lvCalls.Columns(4).Width = intWidth * 0.15 'Call Description
            lvCalls.Columns(5).Width = intWidth * 0.12 'Warranty End
            lvCalls.Columns(6).Width = intWidth * 0.08 ' Log Date
            lvCalls.Columns(7).Width = intWidth * 0.08 ' Log Time
            lvCalls.Columns(8).Width = intWidth * 0.1 ' Area

            lvToday.Columns(1).Width = intWidth * 0.08  'code
            lvToday.Columns(2).Width = intWidth * 0.15 'customer name
            lvToday.Columns(3).Width = intWidth * 0.12 'Service Type
            lvToday.Columns(4).Width = intWidth * 0.12 'Warranty  END
            lvToday.Columns(5).Width = intWidth * 0.1 'Area
            lvToday.Columns(6).Width = intWidth * 0.13 ' Start Time
            lvToday.Columns(7).Width = intWidth * 0.13 ' Log Time
            lvToday.Columns(8).Width = intWidth * 0.12 ' Area
            'lvToday.Columns(9).Width = intWidth * 0.08


            lvEmp.Width = panEmpCust.Width / 1.6 - 10
            lvEmp.Height = lvCalls.Height
            'lvCust.Width = lvEmp.Width
            'lvCust.Left = lvEmp.Left + lvEmp.Width + 8
            'pnlCallStatus.Width = lvEmp.Width / 1.6
            'pnlCallStatus.Left = lvEmp.Left + lvEmp.Width + 6

            lvEmp.Columns(1).Width = lvEmp.Width - lvEmp.Width / 2
            'lvCust.Columns(1).Width = lvCust.Width

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub



    Public Sub FillEmpLV()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Try
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Emp", cnMain)

                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                lvEmp.Items.Clear()
                Dim i As Integer = 0
                If readr.HasRows Then
                    While readr.Read


                        With lvEmp.Items.Add(readr.Item("EmpCode").ToString)
                            .SubItems.Add(readr.Item("EmpName").ToString)


                            'strQuery = "Select Count(*) from tbl_CallGen where AssignCode ='" & readr.Item("EmpCode") & "' and format(RecDate,'MM/DD/YYYY') ='" & Format(Now, "MM/dd/yyyy") & "'"
                            'Dim TCall2 As Integer = 0
                            'TCall2 = GetTotalRecords(strQuery)
                            'If TCall2 = 0 Then Continue While

                            'open calls
                            strQuery = "Select Count(*) from tbl_CallGen where AssignCode ='" & readr.Item("EmpCode") & "' and CurrentStatus ='Open'" 'and format(RecDate,'MM/DD/YYYY') ='" & Format(Now, "MM/dd/yyyy") & "'"
                            Dim TCall As Integer = 0
                            TCall = GetTotalRecords(strQuery)

                            .SubItems.Add(If(TCall = 0, "-", TCall))
                            If (lvEmp.Items(i).SubItems(2).Text = "-") Then lvEmp.Items(i).BackColor = Color.WhiteSmoke


                            'Solved Calls
                            strQuery = "Select Count(*) from tbl_CallGen where AssignCode ='" & readr.Item("EmpCode") & "' and CurrentStatus ='Solved'" ' and format(RecDate,'MM/DD/YYYY') ='" & Format(Now, "MM/dd/yyyy") & "'"
                            Dim TCall1 As Integer = 0
                            TCall1 = GetTotalRecords(strQuery)
                            .SubItems.Add(If(TCall1 = 0, "-", TCall1))
                            i = i + 1

                        End With
                    End While
                End If
                'MsgBox(i.ToString)
                ' lvCustomers.Items(0).Selected = True
                readr.Close()
                'below commented at 30-05-2018 21:32

                cmd.CommandText = "Select * from tbl_Emp"
                cmd.Connection = cnMain
                readr = cmd.ExecuteReader
                If readr.HasRows Then
                    While readr.Read
                        For i = 0 To lvEmp.Items.Count - 1
                            If readr.Item("EmpCode").ToString = lvEmp.Items(i).Text Then Continue While
                        Next
                        With lvEmp.Items.Add(readr.Item("EmpCode").ToString)
                            .SubItems.Add(readr.Item("EmpName").ToString)
                            'open calls

                            .SubItems.Add("-")
                            'Solved Calls
                            .SubItems.Add("-")
                        End With

                    End While
                End If
                readr.Close()
                readr = Nothing
                cmd = Nothing

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If cnMain.State = ConnectionState.Open Then cnMain.Close()
            End
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuMasterCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMasterCust.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim frmCust As New Customer
            frmCust.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuServiceNewCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuServiceNewCall.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim FormCall As New CallGen
            FormCall.lblRecEmp.Text = Me.lblUserCode.Text
            If FormCall.ShowDialog() = DialogResult.OK Then
                FillCallsLV()
                FillEmpLV()
                FillTotalCalls()
                FillTodaysCall()
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Public Sub FillTotalCalls()
        '<EhHeader>
        Try
            '</EhHeader>

            Dim strQuery As String = ""
            Dim tmpStr As String = ""
            'Exit Sub
            Try

                strQuery = "Select Count(*) from tbl_CallGen, tbl_Cust where tbl_cust.CustCode=[tbl_callGen].[CustCode] and " &
                " and format(RecDate,'MM/DD/YYYY') ='" & Format(Now, "MM/dd/yyyy") & "'"
                lblTodayCall.Text = GetTotalRecords(strQuery)
                'strCallsToday = GetTotalRecords(strQuery)

                strQuery = "Select Count(*) from tbl_CallGen, tbl_Cust where tbl_callGen.CurrentStatus = 'Open' and tbl_callGen.Assigncode is Not Null and len(tbl_callGen.AssignCode) <> 0 and tbl_cust.CustCode=tbl_callGen.CustCode"
                lblOpenCalls.Text = GetTotalRecords(strQuery)
                'strCallsOpen = GetTotalRecords(strQuery)
                sbOpenCalls.Text = "   Open Call(s): " + lblOpenCalls.Text + "   "


                'strQuery = "Select Count(*) from tbl_CallGen, tbl_cust where [AssignCode] is Null or len([AssignCode])=0 and tbl_cust.CustCode=tbl_callGen.CustCode and tbl_cust.City='" & PCurrentCity & "'"
                strQuery = "SELECT Count(*) AS Expr1 FROM tbl_CallGen INNER JOIN tbl_Cust ON tbl_CallGen.CustCode = tbl_Cust.CustCode WHERE" & " [AssignCode] Is Null Or len([AssignCode])=0"

                lblCallNotAssigned.Text = GetTotalRecords(strQuery)
                'strCallsNA = GetTotalRecords(strQuery)

                strQuery = "Select Count(*) from tbl_CallGen, tbl_cust where CurrentStatus ='On Hold' and tbl_cust.CustCode=tbl_callGen.CustCode"
                lblOnHold.Text = GetTotalRecords(strQuery)
                'strCallsOpen = GetTotalRecords(strQuery)

                strQuery = "Select Count(*) from tbl_CallGen, tbl_cust where CurrentStatus ='Awaiting Info' and tbl_cust.CustCode=tbl_callGen.CustCode"
                lblAwaitingInfo.Text = GetTotalRecords(strQuery)
                'strCallsAwaitInfo = GetTotalRecords(strQuery)

                strQuery = "Select Count(*) from tbl_CallGen, tbl_Cust where CurrentStatus ='Awaiting parts' and tbl_cust.CustCode=tbl_callGen.CustCode"
                lblAwaitingParts.Text = GetTotalRecords(strQuery)
                'strCallsAwaitParts = GetTotalRecords(strQuery)



            Catch ex As Exception
                MsgBox(ex.StackTrace.ToString, , "Error")
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub tsBtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnNew.Click
        '<EhHeader>
        Try
            '</EhHeader>
            mnuServiceNewCall_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuServiceOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuServiceOpen.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim FormOpen As New CallSearch
            FormOpen.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuServiceSolved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuServiceSolved.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim FormOpen As New CallSearch
            FormOpen.rbClosed.Checked = True
            FormOpen.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuMastEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMastEmp.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim formEmp As New Employee
            If formEmp.ShowDialog() = DialogResult.OK Then
                FillEmpLV()
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub tsBtnEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnEmp.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Call mnuMastEmp_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuReportToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepToday.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim ReportForm As New MyReportViwer
            ReportForm.strRPTName = "Today"
            ReportForm.Show(Me)
            'rptTodayCalls.Show(Me)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuRepOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepOpen.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim ReportForm As New MyReportViwer
            ReportForm.strRPTName = "Open"
            ReportForm.Show(Me)
            'rptView.Show(Me)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuRepClosed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim ReportForm As New MyReportViwer
            ReportForm.strRPTName = "Solved"
            ReportForm.Show(Me)

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuRepAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            'rptViewAll.Show(Me)
            Dim ReportForm As New MyReportViwer
            ReportForm.strRPTName = "All"
            ReportForm.Show(Me)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub lvCalls_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCalls.DoubleClick
        '<EhHeader>
        Try
            '</EhHeader>
            If lvCalls.Items.Count = 0 Then Exit Sub
            If lvCalls.SelectedItems.Count = 0 Then Exit Sub

            Dim EditCall As New CallGen
            EditCall.lblMCode.Text = lvCalls.SelectedItems(0).Text
            EditCall.lblRecEmp.Text = Me.lblUserCode.Text

            EditCall.CurFocus = 1
            If EditCall.ShowDialog() = DialogResult.OK Then
                FillCallsLV()
                FillEmpLV()
                FillTotalCalls()
                'FillCallsLVBhavnagar()
                FillTodaysCall()
            End If

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub lvNotAssigned_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            'If lvCallsBhavnagar.Items.Count = 0 Then Exit Sub
            'If lvCallsBhavnagar.SelectedItems.Count = 0 Then Exit Sub

            'Dim EditCall As New CallGen
            'EditCall.lblMCode.Text = lvCallsBhavnagar.SelectedItems(0).Text
            'EditCall.lblRecEmp.Text = Me.lblUserCode.Text
            'EditCall.lblCurrentCity.Text = "Bhavnagar"
            'If EditCall.ShowDialog() = DialogResult.OK Then
            'FillCallsLV()
            'FillEmpLV()
            'FillTotalCalls()
            'FillTodaysCall()
            'FillCallsLVBhavnagar()
            'End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuServiceViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuServiceViewAll.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim FormViewAll As New CallSearch
            'FormViewAll.rbOpen.Checked = True
            FormViewAll.ShowDialog()
            FillCallsLV()
            'MDIMain.FillCallsNotAssignedLV()
            FillEmpLV()
            FillTotalCalls()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        '<EhHeader>
        Try
            '</EhHeader>
            mnuServiceViewAll_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lblBtnToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim NewForm As New CallSearch
            NewForm.rbToday.Checked = True
            NewForm.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lblBtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim NewForm As New CallSearch
            NewForm.rbOpen.Checked = True
            NewForm.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lblBtnNotAssigned_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim NewForm As New CallSearch
            NewForm.rbNotAssigned.Checked = True
            NewForm.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lblBtnOnHold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim NewForm As New CallSearch
            NewForm.rbOnHold.Checked = True
            NewForm.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lblBtnAwaitInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim NewForm As New CallSearch
            NewForm.rbAInfo.Checked = True
            NewForm.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lblBtnAwaitParts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim NewForm As New CallSearch
            NewForm.rbAParts.Checked = True
            NewForm.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuMastProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMastService.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim formService As New ServiceForm
            formService.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub tsBtnCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnCust.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Call mnuMasterCust_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub tsBtnService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnService.Click
        '<EhHeader>
        Try
            '</EhHeader>
            mnuMastProduct_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuAdminOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdminOptions.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim SettingForm As New SettingForm
            SettingForm.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
        '<EhHeader>
        Try
            '</EhHeader>
            AboutForm.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub mnuRepCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepCustom.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim CustRPTSet As New CallSearchQuery
            CustRPTSet.lblMode.Text = "1"
            If CustRPTSet.ShowDialog() = DialogResult.OK Then
                Dim ReportForm As New MyReportViwer
                ReportForm.strRPTName = "Custom"
                ReportForm.lblQuery.Text = CustRPTSet.MyValue
                CallSearchQuery.Dispose()
                ReportForm.Show(Me)
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub lvNotAssigned_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            'If e.Button = MouseButtons.Right Then
            'If lvCallsBhavnagar.Items.Count = 0 Then Exit Sub
            'If lvCallsBhavnagar.SelectedItems.Count = 0 Then Exit Sub
            'Me.ContextMenuStrip1.Show(Me.lvCallsBhavnagar, e.Location)
            'PopupCtrl = lvCallsBhavnagar
            'End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvCalls_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvCalls.MouseUp
        '<EhHeader>
        Try
            '</EhHeader>
            If e.Button = MouseButtons.Right Then
                If lvCalls.Items.Count = 0 Then Exit Sub
                If lvCalls.SelectedItems.Count = 0 Then Exit Sub
                Me.ContextMenuStrip1.Show(Me.lvCalls, e.Location)
                PopupCtrl = lvCalls
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuPopEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPopEdit.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Dim strTmp As String = ""
            Try

                Dim NewForm As New CallGen
                NewForm.lblMCode.Text = PopupCtrl.SelectedItems.Item(0).Text

                NewForm.lblRecEmp.Text = Me.lblUserCode.Text
                If NewForm.ShowDialog = DialogResult.OK Then
                    FillCallsLV()
                    FillEmpLV()
                    FillTotalCalls()
                    FillTodaysCall()
                    'FillCallsLVBhavnagar()
                    PopupCtrl = Nothing
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuPopDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPopDelete.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If MsgBox("Are you sure you want to delete selected service call ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = vbNo Then Exit Sub
            'checking registerd calls here
            Call ExecQuery("Delete from tbl_CallGen where CallCode ='" & PopupCtrl.SelectedItems(0).Text & "'")
            Call ExecQuery("Delete from tbl_CallGen_F where FCode ='" & PopupCtrl.SelectedItems(0).Text & "'")
            FillCallsLV()
            FillEmpLV()
            FillTotalCalls()
            FillTodaysCall()
            'FillCallsLVBhavnagar()
            PopupCtrl = Nothing
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuPopPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPopPrint.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim ReportForm As New MyReportViwer
            ReportForm.lblQuery.Text = PopupCtrl.SelectedItems(0).Text
            ReportForm.strRPTName = "Single"
            ReportForm.Show(Me)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuDataClosed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDataClosed.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If MsgBox("Are you sure you want to remove all closed calls? this can't be undone.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = vbNo Then Exit Sub
            Call ExecQuery("Delete from tbl_CallGen_F where FCode in (select CallCode from tbl_CallGen where CurrentStatus ='Solved')")
            Call ExecQuery("Delete from tbl_CallGen where CallCode ='Solved'")
            FillCallsLV()
            FillEmpLV()
            FillTotalCalls()
            FillTodaysCall()
            'FillCallsLVBhavnagar()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuDataAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDataAll.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If MsgBox("Are you sure you want to remove all calls? this can't be undone.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = vbNo Then Exit Sub
            Call ExecQuery("Delete from tbl_CallGen_F")
            Call ExecQuery("Delete from tbl_CallGen")
            FillCallsLV()
            FillEmpLV()
            FillTotalCalls()
            FillTodaysCall()
            'FillCallsLVBhavnagar()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuDataEverything_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDataEverything.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If MsgBox("Are you sure you want to remove all data? this can't be undone.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = vbNo Then Exit Sub
            Call ExecQuery("Delete from tbl_CallGen_F")
            Call ExecQuery("Delete from tbl_CallGen")
            Call ExecQuery("Delete from tbl_Cust")
            Call ExecQuery("Delete from tbl_Emp")
            Call ExecQuery("Delete from tbl_Ser")
            FillCallsLV()
            FillEmpLV()
            FillTotalCalls()
            FillTodaysCall()
            'FillCallsLVBhavnagar()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuDataCR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDataCR.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim jro As JRO.JetEngine
            jro = New JRO.JetEngine()
            Try
                cnMain.Close()
                cnMain.Dispose()
                Application.DoEvents()

                If IO.File.Exists(strCurPath & "\Backup.mdb") Then IO.File.Delete(strCurPath & "\Backup.mdb")
                If IO.File.Exists(strCurPath & "\Temp.mdb") Then IO.File.Delete(strCurPath & "\Temp.mdb")

                IO.File.Copy(strCurPath & "\Data.mdb", strCurPath & "\Backup.mdb")


                jro.CompactDatabase("Provider = Microsoft.jet.OLEDB.4.0;Data Source =" & strCurPath & "\Data.mdb",
                "Provider = Microsoft.jet.OLEDB.4.0;Data Source =" & strCurPath & "\Temp.mdb;Jet OLEDB:Engine Type=5")

                IO.File.Delete(strCurPath & "\Data.mdb")
                My.Computer.FileSystem.RenameFile(strCurPath & "\Temp.mdb", "Data.mdb")
                IO.File.Delete(strCurPath & "\Backup.mdb")
                jro = Nothing
                Application.DoEvents()
                'cnMain.Open()
                MsgBox("Finished, Please restart Easy Help Desk in order for the changes to take effect", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Info")
            Catch ex As Exception

                MsgBox(ex.Message)
                MsgBox("There were some problem while performing this operation, Please try again later", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Info")
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuBakup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBakup.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If cnMain.State = ConnectionState.Open Then cnMain.Close() : cnMain.Dispose()
            Application.DoEvents()
            FolderBrowserDialog1.Description = "Select folder path to take backup"
            If FolderBrowserDialog1.ShowDialog <> DialogResult.OK Then Exit Sub

            Call BackupData(FolderBrowserDialog1.SelectedPath.ToString)
            Application.DoEvents()
            cnMain.ConnectionString = "Provider = Microsoft.jet.OLEDB.4.0;Data Source =" & strCurPath & "\Data.mdb"
            cnMain.Open()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub mnuRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRestore.Click
        '<EhHeader>
        Try
            '</EhHeader>
            frmRestore.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub lvCalls_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCalls.ColumnClick
        '<EhHeader>
        Try
            '</EhHeader>
            ' Get the new sorting column. 
            Dim new_sorting_column As ColumnHeader = lvCalls.Columns(e.Column)
            ' Figure out the new sorting order. 
            Dim sort_order As System.Windows.Forms.SortOrder
            If m_SortingColumn Is Nothing Then
                ' New column. Sort ascending. 
                sort_order = SortOrder.Ascending
            Else ' See if this is the same column. 
                If new_sorting_column.Equals(m_SortingColumn) Then
                    ' Same column. Switch the sort order. 
                    If m_SortingColumn.Text.StartsWith("> ") Then
                        sort_order = SortOrder.Descending
                    Else
                        sort_order = SortOrder.Ascending
                    End If
                Else
                    ' New column. Sort ascending. 
                    sort_order = SortOrder.Ascending
                End If
                ' Remove the old sort indicator. 
                m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
            End If
            ' Display the new sort order. 
            m_SortingColumn = new_sorting_column
            If sort_order = SortOrder.Ascending Then
                m_SortingColumn.Text = "> " & m_SortingColumn.Text
            Else
                m_SortingColumn.Text = "< " & m_SortingColumn.Text
            End If
            ' Create a comparer. 
            lvCalls.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
            ' Sort. 
            lvCalls.Sort()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Private Sub lvEmp_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvEmp.ColumnClick
        '<EhHeader>
        Try
            '</EhHeader>
            ' Get the new sorting column. 
            Dim new_sorting_column As ColumnHeader = lvEmp.Columns(e.Column)
            ' Figure out the new sorting order. 
            Dim sort_order As System.Windows.Forms.SortOrder
            If m_SortingColumn Is Nothing Then
                ' New column. Sort ascending. 
                sort_order = SortOrder.Ascending
            Else ' See if this is the same column. 
                If new_sorting_column.Equals(m_SortingColumn) Then
                    ' Same column. Switch the sort order. 
                    If m_SortingColumn.Text.StartsWith("> ") Then
                        sort_order = SortOrder.Descending
                    Else
                        sort_order = SortOrder.Ascending
                    End If
                Else
                    ' New column. Sort ascending. 
                    sort_order = SortOrder.Ascending
                End If
                ' Remove the old sort indicator. 
                m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
            End If
            ' Display the new sort order. 
            m_SortingColumn = new_sorting_column
            If sort_order = SortOrder.Ascending Then
                m_SortingColumn.Text = "> " & m_SortingColumn.Text
            Else
                m_SortingColumn.Text = "< " & m_SortingColumn.Text
            End If
            ' Create a comparer. 
            lvEmp.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
            ' Sort. 
            lvEmp.Sort()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        '<EhHeader>
        Try
            '</EhHeader>
            mnuAdminOptions_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuMastInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMastInventory.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim formInvent As New Inventory
            formInvent.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub tsBtnInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnInventory.Click
        '<EhHeader>
        Try
            '</EhHeader>
            mnuMastInventory_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuRepCustAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepCustAll.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim ReportForm As New MyReportViwer
            ReportForm.strRPTName = "CustAll"
            ReportForm.Show(Me)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuRepCustOpenCalls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepCustOpenCalls.Click
        '<EhHeader>
        Try
            '</EhHeader>

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuRepInventoryList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepInventoryList.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim ReportForm As New MyReportViwer
            ReportForm.strRPTName = "InvAll"
            ReportForm.Show(Me)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Private Sub mnuRepCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepCust.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim ReportForm As New MyReportViwer
            ReportForm.strRPTName = "CustAll"
            ReportForm.Show(Me)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Private Sub mnuRepEmpAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepEmpAll.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim ReportForm As New MyReportViwer
            ReportForm.strRPTName = "EmpAll"
            ReportForm.Show(Me)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuRepEmpDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepEmpDetails.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim ReportForm As New MyReportViwer
            ReportForm.strRPTName = "EmpDetails"
            ReportForm.Show(Me)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If IO.File.Exists(Application.StartupPath & "\Readme.pdf") Then
                System.Diagnostics.Process.Start(Application.StartupPath + "\Readme.pdf")
            Else
                MsgBox("Readme file does not exist", MsgBoxStyle.OkOnly, "Error")
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuAdminLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdminLogout.Click
        '<EhHeader>
        Try
            '</EhHeader>
            cnMain.Close()

            Dim fr As New Log_in
            fr.Show()

            Me.Close()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvCalls_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCalls.KeyDown
        '<EhHeader>
        Try
            '</EhHeader>
            If e.KeyCode = Keys.Enter Then
                lvCalls_DoubleClick(sender, e)
            End If
            If e.KeyCode = Keys.A Then
                mnuPopAssign_Click(sender, e)
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Private Sub lvCallsBhavnagar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvToday_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvToday.MouseUp
        '<EhHeader>
        Try
            '</EhHeader>
            If e.Button = MouseButtons.Right Then
                If lvToday.Items.Count = 0 Then Exit Sub
                If lvToday.SelectedItems.Count = 0 Then Exit Sub
                Me.ContextMenuStrip1.Show(Me.lvToday, e.Location)
                PopupCtrl = lvToday
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvToday_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvToday.DoubleClick
        '<EhHeader>
        Try
            '</EhHeader>
            If lvToday.Items.Count = 0 Then Exit Sub
            If lvToday.SelectedItems.Count = 0 Then Exit Sub

            Dim EditCall As New CallGen
            EditCall.lblMCode.Text = lvToday.SelectedItems(0).Text
            EditCall.lblRecEmp.Text = Me.lblUserCode.Text

            If EditCall.ShowDialog() = DialogResult.OK Then
                FillCallsLV()
                FillEmpLV()
                FillTotalCalls()
                'FillCallsLVBhavnagar()
                FillTodaysCall()
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvEmp_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvEmp.DoubleClick
        '<EhHeader>
        Try
            '</EhHeader>
            If lvEmp.Items.Count = 0 Then Exit Sub
            If lvEmp.SelectedItems.Count = 0 Then Exit Sub
            Dim strQCriteria As String = " 1 = 1"
            strQCriteria = strQCriteria & " and  AssignCode in ( select EmpCode from tbl_emp where EmpCode = '" & lvEmp.SelectedItems(0).Text & "')"
            Dim EmpSearch As New CallSearch
            EmpSearch.FillCallGenView(strQCriteria)
            EmpSearch.rbOpen.Checked = False
            EmpSearch.rbClosed.Checked = False
            EmpSearch.rbOnHold.Checked = False
            EmpSearch.rbNotAssigned.Checked = False
            EmpSearch.rbCancelled.Checked = False
            EmpSearch.rbAInfo.Checked = False
            EmpSearch.rbAParts.Checked = False
            EmpSearch.rbToday.Checked = False
            EmpSearch.rbShowAll.Checked = False
            EmpSearch.cboMonth.Enabled = False
            EmpSearch.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnSearchQuery_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchQuery.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQCriteria As String = " 1 = 1"
            If cboSearch.Text.Length = 0 Then Exit Sub
            If rbArea.Checked = True Then
                strQCriteria = strQCriteria & " and tbl_Callgen.CustCode in (select CustCode from tbl_Cust where Area like '%" & cboSearch.Text & "%')"
            Else
                strQCriteria = strQCriteria & " and CallScode in (select MCode from tbl_Ser where SName like '%" & cboSearch.Text & "%')"
            End If
            FillCallsLV(strQCriteria)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReset.Click
        '<EhHeader>
        Try
            '</EhHeader>
            FillCallsLV()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        '<EhHeader>
        Try
            '</EhHeader>
            FillTodaysCall()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub




    Private Sub ChangeCity()
        '<EhHeader>
        Try
            '</EhHeader>
            Call FillEmpLV()
            Call FillTodaysCall()
            Call FillCallsLV()
            Call FillTotalCalls()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvToday_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lvToday.KeyDown
        '<EhHeader>
        Try
            '</EhHeader>
            If e.KeyCode = Keys.F Then
                If lvToday.Items.Count = 0 Then Exit Sub
                If lvToday.SelectedItems.Count = 0 Then Exit Sub
                'new code edited by V at 30-05-2018 21:13
                Dim strCode As String = lvToday.SelectedItems(0).Text.ToString.Trim
                Dim frmFinal As New FinalOP
                If frmFinal.ShowDialog() <> DialogResult.OK Then Exit Sub
                Dim strNm As String = frmFinal.MyValue

                Dim strQuery As String = "Update tbl_CallGen set CurrentStatus = 'Solved', ConfirmedBy = '" & strNm & "', DuesOn = #" + DateTime.Parse(Now).ToString("MM/dd/yyyy hh:mm tt") & "# where CallCode ='" + strCode + "' "
                If ExecQuery(strQuery) = False Then Exit Sub
                FillCallsLV()
                FillEmpLV()
                FillTotalCalls()
                FillTodaysCall()
            End If
            If e.KeyCode = Keys.Enter Then
                lvToday_DoubleClick(sender, e)
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FilLSearch()
        '<EhHeader>
        Try
            '</EhHeader>
            If rbArea.Checked = True Then
                Try
                    If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                    Dim cmd As New OleDb.OleDbCommand("Select Distinct Area from tbl_Cust order by Area", cnMain)
                    Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                    cboSearch.Items.Clear()
                    If readr.HasRows Then
                        While readr.Read
                            If readr.Item("Area").ToString.Length <> 0 Then
                                cboSearch.Items.Add(readr.Item("Area"))
                            End If
                        End While
                    End If
                    readr.Close()
                    cmd.Dispose()
                    'cnMain.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Else
                Try
                    If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                    Dim cmd As New OleDb.OleDbCommand("Select MCode, SName from tbl_Ser order by SName", cnMain)
                    Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                    cboSearch.Items.Clear()
                    If readr.HasRows Then
                        While readr.Read
                            If readr.Item("SName").ToString.Length <> 0 Then
                                cboSearch.Items.Add(New MyList(readr.Item("SName"), readr.Item("MCode")))
                            End If
                        End While
                    End If
                    readr.Close()
                    cmd.Dispose()
                    'cnMain.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub rbServiceType_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbServiceType.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            Call FilLSearch()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboUser_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboUser.SelectedIndexChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If cboUser.Text.ToLower = "admin" Then
                lblUserCode.Text = "0"
                lblUserCode.Tag = "Admin"
            Else
                Dim mList As MyList
                mList = cboUser.Items(cboUser.SelectedIndex)
                lblUserCode.Text = cboUser.Items(cboUser.SelectedIndex).ItemData
                lblUserCode.Tag = cboUser.Text
                sbUserName.Text = "  User: " + lblUserCode.Tag.ToString + "   "
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboSearch_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cboSearch.KeyDown
        '<EhHeader>
        Try
            '</EhHeader>
            If e.KeyCode = Keys.Enter Then btnSearchQuery_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub mnuPopAssign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuPopAssign.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If lvCalls.Items.Count = 0 Then Exit Sub
            If lvCalls.SelectedItems.Count = 0 Then Exit Sub
            If AssignCall.ShowDialog() = DialogResult.OK Then
                ExecQuery("Update tbl_CallGen set AssignCode = '" + AssignCall.MyValue + "', " & "AssignTime = #" + DateTime.Parse(Now).ToString("MM/dd/yyyy  hh:mm tt") + "# Where CallCode ='" + lvCalls.SelectedItems(0).Text + "'")
                Call FillTodaysCall()
                Call FillCallsLV()
                Call FillTotalCalls()
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnCToday_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCToday.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Call ShowCallSearchForm("T")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub ShowCallSearchForm(ByVal strEntity As String)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim FormOpen As New CallSearch
            FormOpen.rbClosed.Checked = True
            Select Case strEntity
                Case "T"
                    FormOpen.rbToday.Checked = True
                Case "P"
                    FormOpen.rbOpen.Checked = True
                Case "NA"
                    FormOpen.rbNotAssigned.Checked = True
                Case "H"
                    FormOpen.rbOnHold.Checked = True
                Case "AI"
                    FormOpen.rbAInfo.Checked = True
                Case "AP"
                    FormOpen.rbAParts.Checked = True
            End Select
            FormOpen.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnCP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCP.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Call ShowCallSearchForm("P")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnCNA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCNA.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Call ShowCallSearchForm("NA")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnCH_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCH.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Call ShowCallSearchForm("H")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnCAI_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCAI.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Call ShowCallSearchForm("AI")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnCAP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCAP.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Call ShowCallSearchForm("AP")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        '<EhHeader>
        Try
            '</EhHeader>
            frmStandBy.Show()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer2.Tick
        '<EhHeader>
        Try
            '</EhHeader>

            'lblTodayCall.Text = strCallsToday
            'lblOpenCalls.Text = strCallsOpen
            'lblCallNotAssigned.Text = strCallsNA
            'lblOnHold.Text = strCallsOnHold
            'lblAwaitingInfo.Text = strCallsAwaitInfo
            'lblAwaitingParts.Text = strCallsAwaitParts
            'sbOpenCalls.Text = "   Open Call(s): " + strCallsOpen + "   "
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvToday_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvToday.SelectedIndexChanged

    End Sub
End Class
