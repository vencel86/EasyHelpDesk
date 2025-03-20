Imports System.Windows.Forms
Public Class CallSearch
    Private m_SortingColumn As ColumnHeader

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
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

    Public Sub FillCallGenView(ByVal strSCriteria As String)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Dim strQPart As String = ""
            Try
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                'tbl_emp_1.EmpName as RecieveEmp
                strQPart = "SELECT CallCode, RefNo, CustName, CurrentStatus, Format(RecDate,'" & DTFormat & "') as RD, CallDesc, tbl_emp.EmpName as AssignEmp,  ConfirmedBy From ((tbl_CallGen " &
     "LEFT JOIN tbl_Emp ON tbl_CallGen.AssignCode = tbl_Emp.EmpCode) " &
     "INNER JOIN tbl_Cust ON tbl_CallGen.CustCode = tbl_Cust.CustCode) " '&
                '"INNER JOIN tbl_Emp AS tbl_Emp_1 ON tbl_CallGen.RecEmpCode = tbl_Emp_1.EmpCode) "

                strQuery = strQPart + " where CurrentStatus='"

                If strSCriteria.Length <> 0 Then
                    strQuery = strQPart + " where " & strSCriteria 'format(RecDate, 'MM/dd/yyyy') " & strSCriteria
                    'strQuery = strQuery
                ElseIf rbOpen.Checked = True Then
                    strQuery = strQuery & "Open'"
                ElseIf rbClosed.Checked = True Then
                    strQuery = strQuery & "Solved'"
                ElseIf rbOnHold.Checked = True Then
                    strQuery = strQuery & "On Hold'"
                ElseIf rbShowAll.Checked = True Then
                    strQuery = strQPart  ' HERE changing query to show all
                ElseIf rbAInfo.Checked = True Then
                    strQuery = strQuery & "Awaiting Info'"
                ElseIf rbAParts.Checked = True Then
                    strQuery = strQuery & "Awaiting Parts'"
                ElseIf rbCancelled.Checked = True Then
                    strQuery = strQuery & "Cancelled'"
                ElseIf rbNotAssigned.Checked = True Then
                    strQuery = strQPart + " where [AssignCode] is Null or len([AssignCode])=0"
                ElseIf rbToday.Checked = True Then
                    strQuery = strQPart + " where format(RecDate,'MM/DD/YYYY') ='" & Format(Now, "MM/dd/yyyy") & "'"
                End If
                'strQuery = "SELECT Count(*) AS Expr1 FROM tbl_CallGen INNER JOIN tbl_Cust ON tbl_CallGen.CustCode = tbl_Cust.CustCode WHERE tbl_cust.City='" & PCurrentCity & "' and [AssignCode] is Null or len([AssignCode])=0;"


                If dtpFrom.Checked = True Then
                    If strQuery.Contains("where") Then
                        strQuery = strQuery + " and format(RecDate, 'MM/dd/yyyy') >= '" & dtpFrom.Value.ToString("MM/dd/yyyy") & "'"
                    Else
                        strQuery = strQuery + " where format(RecDate, 'MM/dd/yyyy') >= '" & dtpFrom.Value.ToString("MM/dd/yyyy") & "'"
                    End If
                End If

                If cboMonth.Enabled = True Then

                    If cboMonth.SelectedIndex > -1 Then
                        If strQuery.Contains("where") Then
                            strQuery = strQuery + " and format(RecDate, 'M') = '" & cboMonth.SelectedIndex + 1 & "'"
                        Else
                            strQuery = strQuery + " where format(RecDate, 'M') = '" & cboMonth.SelectedIndex + 1 & "'"
                        End If
                    End If
                End If



                If cboEmp.SelectedIndex > -1 And cboEmp.SelectedIndex <> 0 Then
                    Dim mList As MyList
                    Dim EmpCOde As String = String.Empty
                    mList = cboEmp.Items(cboEmp.SelectedIndex)
                    EmpCOde = cboEmp.Items(cboEmp.SelectedIndex).ItemData

                    If strQuery.Contains("where") Then
                        strQuery = strQuery + " and AssignCode = '" & EmpCOde & "'"
                    Else
                        strQuery = strQuery + " where AssignCode = '" & EmpCOde + 1 & "'"
                    End If
                End If

                If dtpTo.Checked = True Then
                    If strQuery.Contains("where") Then
                        strQuery = strQuery + "and RecDate <= #" & dtpTo.Value.ToString("MM/dd/yyyy") & "# "
                        'strQuery = strQuery + "and format(RecDate,'MM/dd/yyyy') <= '" & dtpTo.Value.ToString("MM/dd/yyyy") & "'"
                    Else
                        strQuery = strQuery + " where RecDate <= #" & dtpTo.Value.ToString("MM/dd/yyyy") & "# "
                        'strQuery = strQuery + " where format(RecDate,'MM/dd/yyyy') <= '" & dtpTo.Value.ToString("MM/dd/yyyy") & "'"
                    End If

                End If

                If cboCity.Text = "Surat" Then
                    strQuery = strQuery + " and tbl_Cust.City = 'Surat'"
                ElseIf cboCity.Text = "Bhavnagar" Then
                    strQuery = strQuery + " and tbl_Cust.City = 'Bhavnagar'"
                End If

                strQuery = strQuery + " order by CallCode Desc"

                FillDataGrid(strQuery, dgvCalls)
                lblTotalCalls.Text = "Total Calls: " & dgvCalls.RowCount - 1
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
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If dgvCalls.CurrentRow.Cells(0).Value <> "" Then
                If MsgBox("Are you sure you want to delete selected service call ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = vbNo Then Exit Sub
                'checking registerd calls here
                Call ExecQuery("Delete from tbl_CallGen where CallCode ='" & dgvCalls.CurrentRow.Cells("colMCode").Value.ToString.Trim & "'")
                Call ExecQuery("Delete from tbl_CallGen_F where FCode ='" & dgvCalls.CurrentRow.Cells("colMCode").Value.ToString.Trim & "'")
                'DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
                Call FillCallGenView("")
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub lvCallGen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            If e.KeyCode = Keys.Delete Then Call btnDelete_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub CallSearch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub CallSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<EhHeader>
        Try
            '</EhHeader>
            'Call FillCallGenView("")
            cboMonth.SelectedIndex = Date.Now.Month - 1
            FIllEmp()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub Cancel_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Me.Close()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub rbOnHold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOnHold.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If rbOnHold.Checked = True Then Call FillCallGenView("")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub rbClosed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbClosed.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If rbClosed.Checked = True Then Call FillCallGenView("")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub rbOpen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOpen.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If rbOpen.Checked = True Then Call FillCallGenView("")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub rbNotAssigned_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNotAssigned.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If rbNotAssigned.Checked = True Then Call FillCallGenView("")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub rbCancelled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCancelled.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If rbCancelled.Checked = True Then Call FillCallGenView("")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub rbAInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAInfo.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If rbAInfo.Checked = True Then Call FillCallGenView("")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub rbAParts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAParts.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If rbAParts.Checked = True Then Call FillCallGenView("")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub rbToday_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbToday.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If rbToday.Checked = True Then Call FillCallGenView("")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub rbShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbShowAll.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If rbShowAll.Checked = True Then Call FillCallGenView("")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim formNew As New CallGen
            'If formNew.ShowDialog() = DialogResult.OK Then FillCallGenView()
            formNew.ShowDialog()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Dim strTmp As String = ""
            Try
                If dgvCalls.CurrentRow.Cells(0).Value = 0 Then Exit Sub
                If dgvCalls.CurrentRow.Cells(0).Value Is Nothing Then Exit Sub

                Dim NewForm As New CallGen
                NewForm.lblMCode.Text = dgvCalls.CurrentRow.Cells(0).Value.ToString.Trim
                If NewForm.ShowDialog = DialogResult.OK Then FillCallGenView("")
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

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If CallSearchQuery.ShowDialog() = DialogResult.OK Then
                rbOpen.Checked = False
                rbClosed.Checked = False
                rbOnHold.Checked = False
                rbNotAssigned.Checked = False
                rbCancelled.Checked = False
                rbAInfo.Checked = False
                rbAParts.Checked = False
                rbToday.Checked = False
                rbShowAll.Checked = False
                FillCallGenView(CallSearchQuery.MyValue)
                CallSearchQuery.Dispose()
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvCallGen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
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

    Private Sub lvCallGen_KeyDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            If e.KeyCode = Keys.Delete Then Call btnDelete_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If dgvCalls.CurrentRow.Cells(0).Value = String.Empty Then Exit Sub
            If dgvCalls.CurrentRow.Cells(0).Value Is Nothing Then Exit Sub
            Dim ReportForm As New MyReportViwer
            ReportForm.lblQuery.Text = dgvCalls.CurrentRow.Cells(0).Value.ToString.Trim
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            If dgvCalls.CurrentRow.Cells(0).Value = String.Empty Then Exit Sub
            If dgvCalls.CurrentRow.Cells(0).Value Is Nothing Then Exit Sub
            Dim ReportForm As New MyReportViwer
            ReportForm.lblQuery.Text = dgvCalls.CurrentRow.Cells(0).Value.ToString.Trim
            ReportForm.strRPTName = "Follow"
            ReportForm.Show(Me)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub



    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        '<EhHeader>
        Try
            '</EhHeader>
            FillCallGenView("")
            If dtpFrom.Checked = True Then
                cboMonth.Enabled = False
            Else
                If dtpTo.Checked = False Then cboMonth.Enabled = True
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        '<EhHeader>
        Try
            '</EhHeader>
            FillCallGenView("")
            If dtpTo.Checked = True Then
                cboMonth.Enabled = False
            Else
                If dtpFrom.Checked = False Then cboMonth.Enabled = True
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCity.SelectedIndexChanged
        '<EhHeader>
        Try
            '</EhHeader>
            FillCallGenView("")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If cboMonth.Enabled = True Then FillCallGenView("")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FIllEmp()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strTmp As String = ""
            'Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Emp Where City='" & PCurrentCity & "'", cnMain)
            Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Emp", cnMain)
            Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
            cboEmp.Items.Clear()
            cboEmp.Items.Add("All")
            If readr.HasRows Then
                While readr.Read
                    cboEmp.Items.Add(New MyList(readr.Item("EmpName"), readr.Item("EmpCode")))
                End While
            End If
            readr.Close()
            cmd.Dispose()
            cboEmp.SelectedIndex = 0

        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub cboEmp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmp.SelectedIndexChanged
        FillCallGenView("")
    End Sub
End Class
