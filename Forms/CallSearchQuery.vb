Imports System.Windows.Forms

Public Class CallSearchQuery
    Private _mstrTmp As String
    Public Property MyValue() As String
        Get
            '<EhHeader>
            Try
                '</EhHeader>
                Return _mstrTmp
                '<EhFooter>
            Catch ex As System.Exception
                Dim st As New StackTrace(True)
                st = New StackTrace(ex, True)
                AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
                WriteLog()
            End Try '</EhFooter>
        End Get
        Set(ByVal value As String)
            '<EhHeader>
            Try
                '</EhHeader>
                _mstrTmp = value
                '<EhFooter>
            Catch ex As System.Exception
                Dim st As New StackTrace(True)
                st = New StackTrace(ex, True)
                AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
                WriteLog()
            End Try '</EhFooter>
        End Set
    End Property

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

    Private Sub frmFollowUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<EhHeader>
        Try
            '</EhHeader>
            If lblMode.Text = "1" Then
                lblHeading.Text = "Customize Report"
                Me.Text = "Customize Report"
            End If
            FillEmp()
            FillCallType()
            FillServiceName()
            FillCallUnder()
            FillCustomer()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillCallUnder()
        '<EhHeader>
        Try
            '</EhHeader>
            cboCallUnder.Items.Add("AMC")
            cboCallUnder.Items.Add("WARRANTY")

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
                cboServiceName.Items.Clear()
                If readr.HasRows Then
                    While readr.Read
                        cboServiceName.Items.Add(New MyList(readr.Item("SName"), readr.Item("MCode").ToString))
                    End While
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

    Private Sub FillEmp()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Emp", cnMain)
            Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
            cboEmp.Items.Clear()
            'cboLastEmp.Items.Clear()
            If readr.HasRows Then
                While readr.Read
                    cboEmp.Items.Add(New MyList(readr.Item("EmpName"), readr.Item("EmpCode")))
                End While
            End If
            readr.Close()

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
            Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Cust", cnMain)
            Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
            cboCustomer.Items.Clear()
            If readr.HasRows Then
                While readr.Read
                    cboCustomer.Items.Add(New MyList(readr.Item("CustName"), readr.Item("CustCode")))
                End While
            End If
            readr.Close()

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillCallType()
        '<EhHeader>
        Try
            '</EhHeader>
            cboStatus.Items.Add("Open")
            cboStatus.Items.Add("Solved")
            cboStatus.Items.Add("On Hold")
            cboStatus.Items.Add("Cancelled")
            cboStatus.Items.Add("Awaiting Info")
            cboStatus.Items.Add("Awaiting Parts")

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
            Try

                Dim strQCriteria As String = " 1 = 1"
                'Dim cond As String = " 1 = 1"
                If dtpFrom.Checked Then
                    strQCriteria = strQCriteria & " and format(RecDate, 'MM/dd/yyyy') >= '" & dtpFrom.Value.ToString("MM/dd/yyyy") & "'"
                End If

                If dtpTo.Checked Then
                    strQCriteria = strQCriteria & " and format(RecDate,'MM/dd/yyyy') <= '" & dtpTo.Value.ToString("MM/dd/yyyy") & "'"
                    'strQCriteria &= " and  RecDate <=  '" & dtpTo.Text & "'"
                End If

                If cboStatus.SelectedIndex > -1 Then
                    strQCriteria = strQCriteria & "and CurrentStatus = '" & cboStatus.Text & "'"
                End If

                If cboEmp.SelectedIndex > -1 Then
                    strQCriteria = strQCriteria & " and  AssignCode in ( select EmpCode from tbl_emp where EmpCode = '" & cboEmp.Items(cboEmp.SelectedIndex).ItemData & "')"
                End If

                If cboCallUnder.SelectedIndex > -1 Then
                    strQCriteria = strQCriteria & " and  CallUnder in ( select MCode from tbl_CType where MCode = '" & cboCallUnder.Items(cboCallUnder.SelectedIndex).ItemData & "')"
                End If

                If cboServiceName.SelectedIndex > -1 Then
                    strQCriteria = strQCriteria & " and  CallSCode in ( select MCode from tbl_Ser where MCode = '" & cboServiceName.Items(cboServiceName.SelectedIndex).ItemData & "')"
                End If


                If cboCustomer.SelectedIndex > -1 Then
                    'strQCriteria = strQCriteria & " and tbl_Callgen.CustCode in ( select tbl_Cust.CustCode from tbl_Cust where tbl_Cust.CustCode = '" & cboCustomer.Items(cboCustomer.SelectedIndex).ItemData.ToString & "')"
                    strQCriteria = strQCriteria & " and tbl_Callgen.CustCode = '" & cboCustomer.Items(cboCustomer.SelectedIndex).ItemData.ToString & "'"
                End If

                If txtWordSearch.Text.Length <> 0 Then
                    'strQCriteria = strQCriteria & " and (RefNo Like '%" & txtWordSearch.Text & "%' or CustNameNot Like '%" & txtWordSearch.Text & "%' or CallerName like '%" & txtWordSearch.Text & "%' or CallerContact Like '%" & txtWordSearch.Text & "%' or CallDesc like '%" & txtWordSearch.Text & "%' or CallRes like '%" & txtWordSearch.Text & "%')"
                    strQCriteria = strQCriteria & " and (RefNo Like '%" & txtWordSearch.Text & "%' or CustNameNot Like '%" & txtWordSearch.Text & "%' or CallerName like '%" & txtWordSearch.Text & "%' or CallerContact Like '%" & txtWordSearch.Text & "%' or CallDesc like '%" & txtWordSearch.Text & "%' or CallRes like '%" & txtWordSearch.Text & "%' or CustCode in (select CustCode from tbl_Cust where CustName like '%" & txtWordSearch.Text & "%'))"

                End If
                _mstrTmp = strQCriteria
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
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
End Class
