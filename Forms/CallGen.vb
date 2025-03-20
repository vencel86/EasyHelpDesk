Imports System.Windows.Forms
Public Class CallGen
    Dim strDueDays() As String
    Public CurFocus = 0 '0 on customer , 1 assign
    Private Sub CheckTwoPreviousCalls()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Try
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand("Select format([RecDate],'" & DTFormat & "') as RD,AssignCode,CallDesc, CallSCode, tbl_Ser.SName from tbl_CallGen INNER JOIN tbl_Ser ON tbl_CallGen.CallSCode = tbl_Ser.MCode where CustCode ='" + cboCust.Tag.ToString + "' and CurrentStatus <> 'Open'", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                'lvPreviousCalls.Items.Clear()
                Dim i As Integer = 0
                If readr.HasRows Then
                    While readr.Read
                        i = i + 1
                    End While
                End If
                If i >= 2 Then
                    lblAMCStatus.Text = "This customer already have 2 pending complains! Please check them first."
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
    Private Sub FillPreviousCalls()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Try
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                strQuery = "Select format([RecDate],'" & DTFormat & "') as RD,AssignCode,CallDesc, CallSCode, " &
                    "tbl_Ser.SName, Assign.EmpName from (tbl_CallGen " &
                    "INNER JOIN tbl_Ser On tbl_CallGen.CallSCode = tbl_Ser.MCode) " &
                    "LEFT JOIN tbl_Emp as Assign on Assign.EmpCode=tbl_Callgen.AssignCode " &
                    "where CustCode ='" + cboCust.Tag.ToString + "'"

                Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                lvPreviousCalls.Items.Clear()


                If readr.HasRows Then
                    While readr.Read
                        With lvPreviousCalls.Items.Add(readr.Item("RD").ToString())
                            '.SubItems.Add(readr.Item("RefNo").ToString)
                            '.SubItems.Add(readr.Item("RecDate").ToString)
                            'strQuery = "Select * from tbl_Emp where empCode ='" & readr.Item("AssignCode") & "'"
                            Dim strEmpNm As String = ""
                            If readr.Item("AssignCode").ToString = String.Empty Then
                                .SubItems.Add("-")
                            Else
                                ' strEmpNm = strEmpNm + GetTextFromCode("EmpCode", readr.Item("AssignCode").ToString, "EmpName", "tbl_Emp")
                                strEmpNm = If(readr.IsDBNull(5), "", readr.Item("EmpName"))
                                .SubItems.Add(strEmpNm)
                            End If

                            .SubItems.Add(readr.Item("SName").ToString)
                            .SubItems.Add(readr.Item("CallDesc").ToString)
                        End With
                    End While
                End If
                If lblMCode.Text <> "0" And lvPreviousCalls.Items.Count = 1 Then lvPreviousCalls.Items.Clear()
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
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '<EhHeader>
        Try
            '</EhHeader>

            'If TabControl1.SelectedTab.Name = "TabPage2" Then
            'Me.Close()
            'Exit Sub
            'End If

            'If cboQueryFrom.SelectedIndex = 0 Then

            If cboCust.Items.Count = 0 Then
                MsgBox("You are required to add customer first, customer data not present!", MsgBoxStyle.Information, "Information")
                btnCust.Focus()
                Exit Sub
            Else

                If cboCust.SelectedIndex < 0 And cboCust.Tag = String.Empty Then
                    MsgBox("Please select customer from the list!", MsgBoxStyle.Information, "Information")
                    cboCust.Focus()
                    Exit Sub
                End If
            End If


            'If IfExistinDB("CustName", cboCust.Text, "tbl_Cust") = False Then
            'MsgBox("Customer name doesn't exist for the selected call from 'Existing Customer' category, Select customer name from the list or add new ", MsgBoxStyle.Information, "Information")
            'Exit Sub
            'End If
            'End If


            If txtRefNo.Text.Length = 0 Then
                MsgBox("Please provide call reference number", MsgBoxStyle.Information, "Information")
                txtRefNo.Focus()
                Exit Sub
            End If

            If cboPrdSer.SelectedIndex < 0 Then
                MsgBox("Please select Product/Service from the list.", MsgBoxStyle.Information, "Information")
                cboPrdSer.Focus()
                Exit Sub
            End If
            Dim custCode As String = ""
            Dim RecEmpCode As String = ""
            Dim AssignEmpCode As String = ""
            Dim strServiceCode As String = ""
            Dim strPrdSerCode As String = ""


            Dim mList As MyList

            If cboComplaint.Items.Count = 0 Then
                MsgBox("Service data doesn't exist, please add it first", MsgBoxStyle.Information, "Information")
                cboComplaint.Focus()
                Exit Sub
            End If

            If cboComplaint.Text.Length = 0 Then
                MsgBox("Please select complaint type from the list!", MsgBoxStyle.Information, "Error")
                cboComplaint.Focus()
                Exit Sub
            Else
                If cboComplaint.SelectedIndex = 0 Then
                    strServiceCode = "0"
                Else
                    mList = cboComplaint.Items(cboComplaint.SelectedIndex)
                    strServiceCode = cboComplaint.Items(cboComplaint.SelectedIndex).itemdata
                End If
            End If

            If cboPrdSer.Text <> "Other" Then
                mList = cboPrdSer.Items(cboPrdSer.SelectedIndex)
                strPrdSerCode = cboPrdSer.Items(cboPrdSer.SelectedIndex).itemdata
            Else
                strPrdSerCode = "0"
            End If
            If txtCallDesc.Text.Length = 0 Then
                MsgBox("Call Description can't be left blank, Please add call description!", MsgBoxStyle.Information, "Information")
                txtCallDesc.Focus()
                Exit Sub
            End If

            If cboRecEmp.Items.Count = 0 Then
                MsgBox("You are required to add Employee data first, Employee data not present!", MsgBoxStyle.Information, "Information")
                cboRecEmp.Focus()
                Exit Sub
            End If

            If cboRecEmp.Text.Length = 0 Then
                MsgBox("Please select Received By employee!", MsgBoxStyle.Information, "Information")
                cboRecEmp.Focus()
                Exit Sub
            End If

            'If DateDiff(DateInterval.Day, txtDueDate.Value, txtRecDate.Value) > 0 Then
            'MsgBox("Due date can't be less than call received date, Please correct it", MsgBoxStyle.Information, "Information")
            'txtDueDate.Focus()
            'Exit Sub
            'End If

            Dim strCode As String = ""
            Dim strQuery As String = ""

            'If cboQueryFrom.Text = "Existing Customer" Then
            If lblMCode.Text = "0" Then
                mList = cboCust.Items(cboCust.SelectedIndex)
                ' Get the selected item. 
                custCode = cboCust.Items(cboCust.SelectedIndex).ItemData
                '        Else
                '       custCode = " "
                '      CustNameNot = cboCust.Text
                '     End If
            Else
                custCode = cboCust.Tag
            End If
            Dim strCallUnderCode As String = ""
            ' Get the selected item. 
            strCallUnderCode = cboAMCEtc.Text


            mList = cboRecEmp.Items(cboRecEmp.SelectedIndex)
            RecEmpCode = cboRecEmp.Items(cboRecEmp.SelectedIndex).ItemData

            If cboAssignEmp.Text.Length <> 0 And cboAssignEmp.Text <> "0" Then
                mList = cboAssignEmp.Items(cboAssignEmp.SelectedIndex)
                AssignEmpCode = cboAssignEmp.Items(cboAssignEmp.SelectedIndex).ItemData
            End If

            Dim strCallPriority As String = ""

            '        mList = cboPriority.Items(cboPriority.SelectedIndex)
            '       strCallPriority = cboPriority.Items(cboPriority.SelectedIndex).ItemData

            Dim strCallFrom As String = ""
            strCallFrom = cboQueryFrom.SelectedIndex

            Dim strCallStatus As String = ""
            'mList = cboCallStatus.Items(cboCallStatus.SelectedIndex)
            'strCallStatus = cboCallStatus.Items(cboCallStatus.SelectedIndex).ItemData
            strCallStatus = cboCallStatus.Text

            'Updating AMC Detail done


            If lblMCode.Text = "0" Then

                strCode = TRCode("Select max(cint(CallCode)) from tbl_CallGen")
                'cboQueryFrom.Text 
                '            txtCallDesc.Text
                'strrating
                'txtResolution.Text

                txtDueDate.Value = Now
                strQuery = "insert into tbl_CallGen values('" & strCode & "','" & txtRefNo.Text.ToString & "','" & strCallFrom.Replace("'", "''") & "','" & custCode & "',#" _
                    & DateTime.Parse(txtRecDate.Value).ToString("MM/dd/yyyy hh:mm tt") & "#,'" & txtCallerName.Text.Replace("'", "''") & "','" & txtCallerContact.Text & "','" & strPrdSerCode & "','" & strServiceCode & "','" _
                    & strCallUnderCode & "','" & txtCallDesc.Text.Replace("'", "''") & "','" & strCallPriority & "',#" & DateTime.Parse(Now).ToString("MM/dd/yyyy hh:mm tt") & "#,'" & strCallStatus.Replace("'", "''") & "','" _
                    & RecEmpCode & "',#" & If(AssignEmpCode = String.Empty, DateTime.Parse(txtRecDate.Value).ToString("MM/dd/yyyy hh:mm tt"), DateTime.Parse(Now).ToString("MM/dd/yyyy hh:mm tt")) & "#,'" & AssignEmpCode & "','" & txtFees.Text & "','" & txtResolution.Text.Replace("'", "''") & "','" & String.Empty & "')"

                If ExecQuery(strQuery) = False Then Exit Sub
                If lvFollowUp.Items.Count <> 0 Then
                    Dim strFCode As String = ""
                    For i = 0 To lvFollowUp.Items.Count - 1
                        strFCode = TRCode("Select max(cint(FCode)) from tbl_CallGen_F")
                        strQuery = "insert into tbl_CallGen_F values('" & strFCode & "','" & strCode & "','" _
                & lvFollowUp.Items(i).Tag & "','" & lvFollowUp.Items(i).SubItems(1).Text.Replace("'", "''") & "','" & lvFollowUp.Items(i).SubItems(3).Text.Replace("'", "''") & "')"
                        Call ExecQuery(strQuery)
                    Next
                End If

                'MsgBox("New call saved successfully", MsgBoxStyle.Information, "Information")

            ElseIf lblMCode.Text <> "0" Then
                If cboCust.Text <> lblCustOld.Text Then
                    If MsgBox("Customer name is changed, are you sure you want to continue with this?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = vbNo Then Exit Sub Else
                End If
                strQuery = "Update tbl_CallGen set " &
                                "RefNo = '" + txtRefNo.Text + "', " &
                                "CallFrom = '" + strCallFrom + "', " &
                                "CustCode = '" + custCode + "', " &
                                "RecDate = #" + DateTime.Parse(txtRecDate.Value).ToString("MM/dd/yyyy hh:mm tt") + "#, " &
                                "CallerName = '" + txtCallerName.Text.Replace("'", "''") + "', " &
                                "CallerContact = '" + txtCallerContact.Text + "', " &
                                "CallPrdSerCode = '" + strPrdSerCode + "', " &
                                "CallSCode = '" + strServiceCode + "', " &
                                "CallUnder = '" + strCallUnderCode + "', " &
                                "CallDesc = '" + txtCallDesc.Text.Replace("'", "''") + "', " &
                                "CallPriority = '" + strCallPriority + "', " &
                                "DuesOn = #" + DateTime.Parse(Now).ToString("MM/dd/yyyy  hh:mm tt") + "#, " &
                                "CurrentStatus = '" + strCallStatus.Replace("'", "''") + "', " &
                                "RecEmpCode = '" + RecEmpCode + "', " &
                                "AssignTime = #" + If(AssignEmpCode = String.Empty, DateTime.Parse(txtRecDate.Value).ToString("MM/dd/yyyy hh:mm tt"), DateTime.Parse(Now).ToString("MM/dd/yyyy hh:mm tt")) + "#, " &
                                "AssignCode = '" + AssignEmpCode + "', " &
                                "FeesIfAny = '" + txtFees.Text + "', " &
                                "CallRes = '" + txtResolution.Text.Replace("'", "''") + "', " &
                                "ConfirmedBy = '" + String.Empty + "' " &
                                "where CallCode ='" + lblMCode.Text.Trim + "'"

                If ExecQuery(strQuery) = False Then Exit Sub

                strQuery = "delete from tbl_CallGen_F where FCode ='" & lblMCode.Text & "'"
                ExecQuery(strQuery)

                If lvFollowUp.Items.Count <> 0 Then
                    Dim strFCode As String = ""
                    For i = 0 To lvFollowUp.Items.Count - 1
                        strFCode = TRCode("Select max(cint(FCode)) from tbl_CallGen_F")
                        strQuery = "insert into tbl_CallGen_F values('" & strFCode & "','" & lblMCode.Text & "','" _
                & lvFollowUp.Items(i).Tag & "','" & lvFollowUp.Items(i).SubItems(1).Text & "','" & lvFollowUp.Items(i).SubItems(3).Text & "')"
                        Call ExecQuery(strQuery)
                    Next
                End If

                'MsgBox("Service call updated successfully", MsgBoxStyle.Information, "Information")
                lblMCode.Text = "0"
            End If

            'Update AMC Visit Date
            'If cboCallStatus.Text = "Solved" And cboAMCEtc.Text = "AMC" And cboAMC.Text.Length <> 0 And txtAMCVisitDate.Text.Length <> 0 Then
            'strQuery = "Update tbl_AMCDet set Done='1' where AMCDate =#" + txtAMCVisitDate.Text + "# and AMCFCode in (Select AMCCode from tbl_AMC where AMCNo='" + cboAMC.Text + "')"
            'Call ExecQuery(strQuery)
            'End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillCustomer()
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim strCity As String = String.Empty
                Dim strQuery As String = ""
                If strCity = String.Empty Then
                    strQuery = "Select * from tbl_Cust"
                Else
                    strQuery = "Select * from tbl_Cust where City='" + strCity + "' order by CustName"
                End If
                Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                cboCust.Items.Clear()
                If readr.HasRows Then
                    While readr.Read
                        'If PCustSelection = True Then
                        'cboCust.Items.Add(New MyList(readr.Item("Alias").ToString + " # " + readr.Item("CustName"), readr.Item("CustCode")))
                        'Else
                        cboCust.Items.Add(New MyList(readr.Item("CustName").ToString, readr.Item("CustCode")))
                        If readr.Item("Alias").ToString.Length <> 0 Then
                            cboCustCode.Items.Add(New MyList(readr.Item("Alias").ToString, readr.Item("CustCode")))
                        End If
                        ' End If

                    End While
                End If
                readr.Close()
                cmd.Dispose()
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


    Private Sub FillCallFrom()
        '<EhHeader>
        Try
            '</EhHeader>
            cboQueryFrom.SelectedIndex = 0
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillEmp()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strTmp As String = ""
            'Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Emp Where City='" & PCurrentCity & "'", cnMain)
            Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Emp", cnMain)
            Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
            cboRecEmp.Items.Clear()
            cboAssignEmp.Items.Clear()
            'cboLastEmp.Items.Clear()
            If readr.HasRows Then
                While readr.Read
                    cboRecEmp.Items.Add(New MyList(readr.Item("EmpName"), readr.Item("EmpCode")))
                    cboAssignEmp.Items.Add(New MyList(readr.Item("EmpName"), readr.Item("EmpCode")))
                    '       cboLastEmp.Items.Add(New MyList(readr.Item("EmpName"), readr.Item("EmpCode")))
                End While
            End If

            If lblRecEmp.Text <> "0" Then
                For i = 0 To cboRecEmp.Items.Count - 1
                    If cboRecEmp.Items.Item(i).itemdata = lblRecEmp.Text Then
                        cboRecEmp.SelectedIndex = i
                    End If
                Next
                'strTmp = GetTextFromCode("EmpCode", lblRecEmp.Text, "EmpName", "tbl_Emp")
                'cboRecEmp.Text = strTmp
            End If
            readr.Close()
            cmd.Dispose()
            'cboRecEmp.SelectedIndex = 0
            'cboAssignEmp.SelectedIndex = 0
            'cboLastEmp.SelectedIndex = 0
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub FillContractType()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim intDefVal As Integer = 0
            Dim i As Integer = 0
            cboAMCEtc.Items.Add("AMC")
            cboAMCEtc.Items.Add("Warranty")
            cboAMCEtc.SelectedIndex = 0
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillServiceName()
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Ser", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader

                cboComplaint.Items.Clear()
                cboComplaint.Items.Add("Other")
                If readr.HasRows Then
                    While readr.Read
                        cboComplaint.Items.Add(New MyList(readr.Item("SName"), readr.Item("MCode").ToString))
                    End While
                Else
                    '   MsgBox("Service data doesn't exist, please add it first", MsgBoxStyle.Information, "Information")

                    cboComplaint.SelectedIndex = 0
                End If
                readr.Close()
                'cboAMCEtc.SelectedIndex = cboAMCEtc.Items.Count.ToString - 1
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
    Private Sub FillPrdSer()
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Inventory", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader

                cboPrdSer.Items.Clear()
                cboPrdSer.Items.Add("Other")
                If readr.HasRows Then
                    While readr.Read
                        cboPrdSer.Items.Add(New MyList(readr.Item("EName"), readr.Item("MCode").ToString))
                    End While

                Else
                    '   MsgBox("Product/Service data doesn't exist, you can add it by Master Menu -> Inventory.", MsgBoxStyle.Information, "Information")
                    'Me.DialogResult = DialogResult.Cancel
                    'Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
                    'cboPrdSer.Items.Clear()

                    cboPrdSer.SelectedIndex = 0
                End If
                If cboPrdSer.Items.Count > 1 Then cboPrdSer.SelectedIndex = 1

                readr.Close()
                'cboAMCEtc.SelectedIndex = cboAMCEtc.Items.Count.ToString - 1
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
    Private Sub FillStatus()
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                cboCallStatus.Items.Add("Open")
                cboCallStatus.Items.Add("Solved")
                cboCallStatus.Items.Add("On Hold")
                cboCallStatus.Items.Add("Cancelled")
                cboCallStatus.Items.Add("Awaiting Info")
                cboCallStatus.Items.Add("Awaiting Parts")
                If cboCallStatus.Items.Count <> 0 Then cboCallStatus.SelectedIndex = 0
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
    Private Sub CallGen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<EhHeader>
        Try
            '</EhHeader>

            Call FillCustomer()
            Call FillEmp()
            Call FillContractType()
            Call FillPrdSer()
            Call FillServiceName()
            Call FillStatus()
            Call FillCallFrom()
            'txtDueDate.CustomFormat = DTFormat & " - " & IIf(DTTFormat.Length > 5, "hh:mm tt", "HH:mm")
            If DTFormat.Length = 0 Then
                txtDueDate.CustomFormat = "MM/dd/yyyy -" + "hh:mm tt"
                txtRecDate.CustomFormat = "MM/dd/yyyy -" + "hh:mm tt"
                dtpAMCTo.CustomFormat = "MM/dd/yyyy"
            Else
                txtDueDate.CustomFormat = DTFormat & " - " & IIf(DTTFormat.Length > 5, "hh:mm tt", "HH:mm")
                txtRecDate.CustomFormat = DTFormat & " - " & IIf(DTTFormat.Length > 5, "hh:mm tt", "HH:mm")
                dtpAMCTo.CustomFormat = DTFormat
            End If

            'cboQueryFrom.Items.Add("Existing Customer")
            'cboQueryFrom.Items.Add("Mail Query")
            'cboQueryFrom.Items.Add("From Website")
            'cboQueryFrom.Items.Add("Advertisement")
            'cboQueryFrom.Items.Add("Yellow Pages")
            'cboQueryFrom.Items.Add("Business Directory")
            'cboQueryFrom.Items.Add("By Reference")
            'cboQueryFrom.Items.Add("Other")
            'cboQueryFrom.SelectedIndex = 0

            'cboCallStatus.Items.Add("Open")
            'cboCallStatus.Items.Add("Solved")
            'cboCallStatus.Items.Add("On Hold")
            'cboCallStatus.Items.Add("Cancelled")
            'cboCallStatus.Items.Add("Awaiting Info")
            'cboCallStatus.Items.Add("Awaiting parts")

            'cboCallStatus.SelectedIndex = 0

            'cboPriority.Items.Add("Immediate")
            'cboPriority.Items.Add("High")
            'cboPriority.Items.Add("Medium")
            'cboPriority.Items.Add("Low")
            'cboPriority.SelectedIndex = 2

            'cboAMCEtc.Items.Add("Warranty")
            'cboAMCEtc.Items.Add("AMC")
            'cboAMCEtc.Items.Add("Other")

            '        cboAMCEtc.SelectedIndex = 2

            txtRefNo.Text = "SC - " & Format(TRCode("Select max(cint(CallCode)) from tbl_CallGen"), "0000")
            'FillCallGenView()
            cboCust.Tag = String.Empty
            If lblMCode.Text <> 0 Then btnEdit_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub ClearCust()
        '<EhHeader>
        Try
            '</EhHeader>
            cboCust.Text = ""
            txtRecDate.Value = Now
            txtRefNo.Text = ""
            cboQueryFrom.SelectedIndex = 1
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            'Call ClearCust()
            'TabControl1.SelectedTab = TabPage1
            'cboCust.Focus()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub Showonly(ByVal strShowonly As Boolean)
        '<EhHeader>
        Try
            '</EhHeader>
            Exit Sub
            If strShowonly = True Then
                Me.Height = 537

                gbCallInfo.Top = 5
                gbCustomer.Visible = False
                gbCustomer.Enabled = False

                gbAction.Top = gbCallInfo.Top + gbCallInfo.Height + 10
                OK_Button.Top = gbAction.Top + gbAction.Height + 8
                Cancel_Button.Top = OK_Button.Top
                Panel1.Height = gbAction.Top + gbAction.Height + 42
                btnFullDetail.Top = OK_Button.Top
                btnFullDetail.Visible = True
                btnFullDetail.TabStop = True
            Else
                Me.Height = 626
                gbCustomer.Enabled = True
                gbCustomer.Visible = True
                gbCallInfo.Top = 119
                gbAction.Top = 245
                OK_Button.Top = 516
                Cancel_Button.Top = OK_Button.Top
                Panel1.Height = 547
                btnFullDetail.TabStop = False
                btnFullDetail.Visible = False
            End If

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Dim strTmp As String = ""
            Try
                Call Showonly(True)
                'If lblMCode.Text = 0 Then
                'If lvCallGen.SelectedItems.Count < 1 Then Exit Sub
                'lblMCode.Text = lvCallGen.SelectedItems(0).Text
                'End If
                'strQuery = "Select * from tbl_CallGen where CallCode ='" & lblMCode.Text & "'"
                strQuery = "Select RefNo, CallFrom, tbl_callGen.CustCode, RecDate, CallerName, CallerContact, CallPrdSerCode, CallSCode, CallDesc, DuesOn, CurrentStatus, RecEMpCode, AssignCode, FeesIfAny, CallRes, " &
                "tbl_cust.CustName, tbl_cust.AMCType, tbl_Emp.EmpName as RecEmpName, Assign.EmpName, Alias from ((tbl_CallGen " &
                "INNER JOIN tbl_cust on tbl_cust.custcode=tbl_callgen.custcode) " &
                "INNER JOIN tbl_Emp on tbl_Emp.EmpCode=tbl_callgen.RecEmpCode) " &
                "LEFT JOIN tbl_Emp as Assign on Assign.EmpCode=tbl_Callgen.AssignCode " &
                "where CallCode ='" & lblMCode.Text & "'"

                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader

                If readr.HasRows Then
                    readr.Read()
                    txtRefNo.Text = readr.Item("RefNo").ToString
                    'cboQueryFrom.Text = readr.Item("CallFrom")

                    strTmp = readr.Item("CallFrom").ToString
                    If strTmp <> String.Empty Then cboQueryFrom.SelectedIndex = strTmp Else cboQueryFrom.Text = ""

                    If readr.Item("CustCode").ToString.Length <> 0 Then
                        cboCust.Text = readr.Item("CustName")
                        cboCust.Tag = readr.Item("CustCode")
                        lblCustOld.Text = cboCust.Text
                    Else
                        cboCust.Text = readr.Item("CustNameNot")
                    End If

                    txtRecDate.Value = readr.Item("RecDate").ToString
                    txtCallerName.Text = readr.Item("CallerName")
                    txtCallerContact.Text = readr.Item("CallerContact")

                    strTmp = GetTextFromCode("MCode", readr.Item("CallPrdSerCode").ToString, "EName", "tbl_Inventory")
                    If strTmp <> "0" Then cboPrdSer.Text = strTmp Else cboPrdSer.Text = ""

                    strTmp = GetTextFromCode("MCode", readr.Item("CallSCode").ToString, "SName", "tbl_Ser")
                    If strTmp <> "0" Then cboComplaint.Text = strTmp Else cboComplaint.Text = "Other"
                    'AMC and Warranty
                    strTmp = readr.Item("AMCType")
                    'GetTextFromCode("CustCode", readr.Item("CustCode").ToString, "AMCType", "tbl_Cust")

                    If strTmp.Length <> "0" Then
                        If strTmp.ToLower = "w" Then cboAMCEtc.Text = "Warranty" Else cboAMCEtc.Text = "AMC"
                        dtpAMCTo.Value = GetTextFromCode("CustCode", readr.Item("CustCode").ToString, "AMCEndDate", "tbl_Cust")

                    Else
                        cboAMCEtc.Text = "AMC"
                    End If
                    If dtpAMCTo.Value < Now Then
                        cboAMCEtc.Text = "AMC"
                    End If


                    'cboAMCEtc.Items.Clear()

                    txtCallDesc.Text = readr.Item("CallDesc").ToString
                    'cboPriority.Text = readr.Item("CallPriority")

                    'strTmp = GetTextFromCode("MCode", readr.Item("CallPriority").ToString, "CPriority", "tbl_CPriority")
                    'If strTmp <> "0" Then cboPriority.Text = strTmp Else cboPriority.Text = ""

                    txtDueDate.Value = readr.Item("DuesOn").ToString
                    cboCallStatus.Text = readr.Item("CurrentStatus").ToString
                    'strTmp = GetTextFromCode("EmpCode", readr.Item("RecEmpCode").ToString, "EmpName", "tbl_Emp")
                    strTmp = readr.Item("RecEmpName")
                    If strTmp <> "0" Then cboRecEmp.Text = strTmp Else cboRecEmp.Text = ""

                    strTmp = readr.Item("FeesIfAny").ToString
                    If strTmp.Length <> 0 Then
                        txtFees.Text = strTmp
                    Else
                        txtFees.Text = "0.00"
                    End If

                    If readr.Item("AssignCode").ToString.Length <> 0 Then
                        'cboAssignEmp.Text = GetTextFromCode("EmpCode", readr.Item("AssignCode").ToString, "EmpName", "tbl_Emp")
                        cboAssignEmp.Text = readr.Item("EmpName")
                    End If
                    txtResolution.Text = readr.Item("CallRes").ToString


                    'followup remains here
                    'strTmp = GetTextFromCode("EmpCode", readr.Item("LastEditEmpCode").ToString, "EmpName", "tbl_Emp")
                    'If strTmp <> "0" Then cboLastEmp.Text = strTmp Else cboLastEmp.Text = ""

                    'txtLastDate.Value = readr.Item("LastEditDate").ToString

                    readr.Close()

                    cmd.CommandText = "Select * from tbl_CallGen_F where FCode ='" & lblMCode.Text & "'"
                    readr = cmd.ExecuteReader
                    lvFollowUp.Items.Clear()
                    If readr.HasRows Then
                        While readr.Read
                            With lvFollowUp.Items.Add("0")
                                .SubItems.Add(readr.Item("FDate"))
                                strTmp = GetTextFromCode("EmpCode", readr.Item("EmpCode").ToString, "EmpName", "tbl_Emp")
                                If strTmp <> "0" Then .SubItems.Add(strTmp)
                                .SubItems.Add(readr.Item("ActionDone").ToString)
                                .Tag = (readr.Item("EmpCode"))
                            End With
                        End While
                    End If

                End If
                readr.Close()
                cmd = Nothing

                ' TabControl1.SelectedTab = TabPage1
                If cboCust.Text = String.Empty And cboCust.SelectedIndex < 0 Then Exit Sub
                Call FillPreviousCalls()
                'Call FillCustInfo()


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
    Private Sub lvCustView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            btnEdit_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnFAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFAdd.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Try

                Dim formFUp As New frmFollowUp
                If formFUp.ShowDialog() = DialogResult.OK Then
                    Dim strVal() As String = formFUp.MyValue.Split(New Char() {"|"c})

                    With lvFollowUp.Items.Add("0")
                        .SubItems.Add(strVal(0))

                        For i = 0 To cboAssignEmp.Items.Count
                            If cboAssignEmp.Items(i).ItemData.ToString = strVal(1) Then
                                .SubItems.Add(cboAssignEmp.Items(i).ToString)
                                Exit For
                            End If

                        Next

                        .SubItems.Add(strVal(2))
                        .Tag = strVal(1)
                    End With
                End If
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
    Private Sub btnFEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFEdit.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim CurRow As Integer = 0
            Try
                Me.DialogResult = Windows.Forms.DialogResult.None
                If lvFollowUp.Items.Count = 0 Then Exit Sub

                If lvFollowUp.SelectedItems.Count = 0 Then Exit Sub

                CurRow = lvFollowUp.SelectedItems(0).Index


                Dim formFUp As New frmFollowUp
                formFUp.MyValue = lvFollowUp.SelectedItems.Item(0).SubItems(1).Text + "|" + lvFollowUp.SelectedItems.Item(0).SubItems(2).Text + "|" + lvFollowUp.SelectedItems.Item(0).SubItems(3).Text
                If formFUp.ShowDialog() = DialogResult.OK Then

                    Dim strVal() As String = formFUp.MyValue.Split(New Char() {"|"c})

                    lvFollowUp.Items(CurRow).SubItems(0).Text = "0"
                    lvFollowUp.Items(CurRow).SubItems(1).Text = (strVal(0))

                    For i = 0 To cboAssignEmp.Items.Count
                        If cboAssignEmp.Items(i).ItemData.ToString = strVal(1) Then
                            lvFollowUp.Items(CurRow).SubItems(2).Text = cboAssignEmp.Items(i).ToString
                            Exit For
                        End If

                    Next
                    lvFollowUp.Items(CurRow).SubItems(3).Text = (strVal(2))
                    lvFollowUp.Items(CurRow).Tag = strVal(1)
                End If
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

    Private Sub btnFDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFDelete.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Me.DialogResult = DialogResult.None
            If lvFollowUp.Items.Count = 0 Then Exit Sub
            If lvFollowUp.SelectedItems.Count = 0 Then Exit Sub
            lvFollowUp.Items(lvFollowUp.SelectedItems(0).Index).Remove()
            Me.DialogResult = DialogResult.None
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboServiceName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComplaint.SelectedIndexChanged
        '<EhHeader>
        Try
            '</EhHeader>

            If cboComplaint.SelectedIndex > -1 Then
                If cboComplaint.SelectedIndex = 0 Then Exit Sub
                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Ser where MCode = '" & cboComplaint.Items(cboComplaint.SelectedIndex).itemdata & "'", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                txtCallDesc.Clear()
                txtResolution.Clear()
                If readr.HasRows Then
                    While readr.Read
                        If readr.IsDBNull(2) = False Or readr.Item("SDesc").ToString.Trim.Length <> 0 Then
                            If txtCallDesc.Text.Length = 0 Then
                                txtCallDesc.Text = readr.Item("SDesc")

                            End If
                        End If
                        If readr.IsDBNull(3) = False Or readr.Item("SRes").ToString.Trim.Length <> 0 Then
                            If txtResolution.Text.Length = 0 Then
                                txtResolution.Text = readr.Item("SRes")
                            End If
                        End If
                    End While
                End If
                readr.Close()
                cmd = Nothing
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmp.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim formEmp As New Employee
            'If formEmp.ShowDialog() = Windows.Forms.DialogResult.OK Then FillEmp()
            formEmp.ShowDialog()
            FillEmp()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub btnCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCust.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim formCustomer As New Customer
            'If formCustomer.ShowDialog() = Windows.Forms.DialogResult.OK Then FillCustomer()
            formCustomer.ShowDialog()
            FillCustomer()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub btnEmp1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmp1.Click
        '<EhHeader>
        Try
            '</EhHeader>
            btnEmp_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub btnFullDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFullDetail.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Call Showonly(False)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnService.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim formService As New ServiceForm
            'If formEmp.ShowDialog() = Windows.Forms.DialogResult.OK Then FillEmp()
            formService.ShowDialog()
            Call FillServiceName()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboQueryFrom_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboQueryFrom.Enter
        '<EhHeader>
        Try
            '</EhHeader>
            '        cboQueryFrom.DroppedDown = True
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboCust_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCust.Enter
        '<EhHeader>
        Try
            '</EhHeader>
            '       cboCust.DroppedDown = True
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboServiceName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComplaint.Enter
        '<EhHeader>
        Try
            '</EhHeader>
            '      cboServiceName.DroppedDown = True
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboAMCEtc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAMCEtc.Enter
        '<EhHeader>
        Try
            '</EhHeader>
            '     cboAMCEtc.DroppedDown = True
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboPriority_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            '    cboPriority.DroppedDown = True
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboRecEmp_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRecEmp.Enter
        '<EhHeader>
        Try
            '</EhHeader>
            '   cboRecEmp.DroppedDown = True
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnPrdSer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrdSer.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim formInvent As New Inventory
            'If formEmp.ShowDialog() = Windows.Forms.DialogResult.OK Then FillEmp()
            formInvent.ShowDialog()
            Call FillServiceName()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub AMCCheck()
        '<EhHeader>
        Try
            '</EhHeader>
            If cboCust.SelectedIndex < 0 Then Exit Sub
            Dim strProducts As String = ""
            cboCust.Tag = cboCust.Items(cboCust.SelectedIndex).ItemData.ToString
            Call CheckTwoPreviousCalls()
            Dim cmd As New OleDb.OleDbCommand("Select * from  tbl_Cust where CustCode = '" & cboCust.Items(cboCust.SelectedIndex).ItemData.ToString & "'", cnMain)
            Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
            If readr.HasRows Then
                While readr.Read
                    'If readr.IsDBNull(1) = False Or readr.Item("AMCNo").ToString.Trim.Length <> 0 Then
                    'cboAMC.Items.Add(readr.Item("AMCNo"))
                    'End If

                    If readr.IsDBNull(19) <> True Then
                        If readr.Item("AmcType").ToString.Substring(0, 1).ToLower = "w" Then
                            cboAMCEtc.SelectedIndex = 1
                            dtpAMCTo.Value = readr.Item("AMCEndDate")
                            If readr.Item("AMCEndDate") >= Now Then
                                'dtpAMCTo.Value = readr.Item("AMCEndDate")
                                cboAMCEtc.Text = "Warranty"
                                lblAMCStatus.Text = "WARRANTY"
                                lblAMCStatus.ForeColor = Color.Blue
                                lblAMCStatus.Visible = True
                            Else
                                lblAMCStatus.Text = "WARRANTY EXPIRED"
                                lblAMCStatus.ForeColor = Color.Red
                                cboAMCEtc.Text = "AMC"
                                lblAMCStatus.Visible = True
                            End If
                        Else
                            dtpAMCTo.Value = readr.Item("AMCEndDate")
                            cboAMCEtc.SelectedIndex = 0
                            dtpAMCTo.Value = Now
                            cboAMCEtc.Text = "AMC"
                            lblAMCStatus.Text = "AMC"
                            lblAMCStatus.ForeColor = Color.Red
                            lblAMCStatus.Visible = True
                        End If
                    Else
                        cboAMCEtc.SelectedIndex = 0
                        dtpAMCTo.Value = Now
                        lblAMCStatus.Text = "Call is under AMC for selected customer '" + cboCust.Text
                        lblAMCStatus.Visible = True
                    End If

                End While
            End If
            'check for previous complains

            'check for previous complains ends here
            readr.Close()
            'cmd = Nothing
            cmd.CommandText = "Select * from tbl_Cust where CustCode = '" & cboCust.Items(cboCust.SelectedIndex).ItemData.ToString & "'"
            readr = cmd.ExecuteReader
            While readr.Read
                If readr.Item("BlackList") = True Then
                    lblAMCStatus.Text = "This customer is black listed, You should not save the call for this customer"
                    lblAMCStatus.Visible = True
                    readr.Close()
                    cmd = Nothing
                    Exit Sub
                End If
            End While
            readr.Close()
            cmd = Nothing

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Private Sub cboCust_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCust.SelectedIndexChanged
        '<EhHeader>
        Try
            '</EhHeader>
            cboCust.Tag = cboCust.Items(cboCust.SelectedIndex).ItemData.ToString
            Call AMCCheck()
            Call FillPreviousCalls()
            Call FillCustInfo()
            cboComplaint.Focus()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillCustInfo()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim tmpString As String = String.Empty
            Dim mList As MyList
            mList = cboCust.Items(cboCust.SelectedIndex)

            Dim strSql As String = String.Empty
            'tmpString = cboCust.Items(cboCust.SelectedIndex).itemdata
            tmpString = cboCust.Tag
            strSql = "Select Salutation, CustName, Add1, City, Area, Alias, CustCode from tbl_Cust where CustCode = '" & tmpString & "'"

            Dim cmd As New OleDb.OleDbCommand(strSql, cnMain)
            Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
            If readr.HasRows Then
                While readr.Read
                    lblCustName.Text = "Name: " + readr.Item(0) + " " + readr.Item(1)
                    lblCustAdd.Text = "Address: " + readr(2) + Space(5) + readr.Item(4)
                    'If ActiveControl.Name = cboCust.Name Then
                    If readr.Item("Alias").ToString.Length <> 0 Then
                        cboCustCode.Text = readr.Item("Alias")
                        cboCust.Text = readr.Item("CustName")
                        cboCust.Tag = readr.Item("CustCode")
                        lblCustOld.Text = cboCust.Text
                    Else
                        'Else
                        cboCustCode.SelectedIndex = -1
                        cboCust.Text = readr.Item("CustName")
                        cboCust.Tag = readr.Item("CustCode")
                        lblCustOld.Text = cboCust.Text
                    End If
                    'End If
                End While
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Private Sub txtCallerName_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtCallerName.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtCallerName.Text = UppercaseFirstLetter(txtCallerName.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtCallDesc_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtCallDesc.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtCallDesc.Text = UppercaseFirstLetter(txtCallDesc.Text)
            OK_Button.Focus()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtResolution_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtResolution.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtResolution.Text = UppercaseFirstLetter(txtResolution.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtRefNo_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtRefNo.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtRefNo.Text = UppercaseFirstLetter(txtRefNo.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub CallGen_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        '<EhHeader>
        Try
            '</EhHeader>
            If CurFocus = 0 Then cboCust.Focus() Else cboAssignEmp.Focus()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboCust_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboCust.TextChanged
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim i As Integer = 0
                Exit Sub
                If cboCust.Text.Length < 4 Then Exit Sub
                For Each item In cboCust.Items
                    If item.ToString.Contains(cboCust.Text.ToUpper) Then
                        cboCust.SelectedIndex = i
                    End If
                    i = i + 1
                Next
            Catch ex As Exception

            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub CallGen_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        '<EhHeader>
        Try
            '</EhHeader>
            If e.Control Then
                If e.KeyCode = Keys.N Then
                    PCustSelection = False
                ElseIf e.KeyCode = Keys.O Then
                    PCustSelection = True
                End If
                Call FillCustomer()
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboCustCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboCustCode.SelectedIndexChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If cboCustCode.SelectedIndex = -1 Then Exit Sub
            If cboCustCode.Text.ToString.Length = 0 Then Exit Sub
            cboCust.Tag = cboCustCode.Items(cboCustCode.SelectedIndex).ItemData.ToString
            Dim i As Integer = 0
            If cboCustCode.Text.Length < 3 Then Exit Sub
            For i = 0 To cboCust.Items.Count - 1
                If cboCust.Items(i).ItemData.ToString = cboCust.Tag Then
                    cboCust.SelectedIndex = i
                    Exit Sub
                End If
                i = i + 1
            Next
            Threading.Thread.Sleep(300)
            Call FillCustInfo()
            Call AMCCheck()
            Call FillPreviousCalls()

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboCust_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles cboCust.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            cboComplaint.Focus()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
End Class
