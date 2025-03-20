Imports System.Windows.Forms

Public Class frmFollowUp
    Private _mstrTmp As String = ""

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

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If cboEmp.Text = "" Then
                MsgBox("Please select an employee!", MsgBoxStyle.Information, "Information")
                cboEmp.Focus()
                Exit Sub
            End If
            If txtActionDone.Text.Length = 0 Then
                MsgBox("Please provide process done!", MsgBoxStyle.Information, "Information")
                txtActionDone.Focus()
                Exit Sub
            End If
            Dim strString As String = ""

            If lblMCode.Text = 0 Then

                strString = cboEmp.Items(cboEmp.SelectedIndex).ItemData

                _mstrTmp = txtFDate.Value & "|" & strString & "|" & txtActionDone.Text

            ElseIf lblMCode.Text <> 0 Then

            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
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
            Try

                FillEmp()
                'If MyValue Is Nothing Or MyValue.Length <> 0 Then
                If _mstrTmp Is Nothing Or _mstrTmp.Length <> 0 Then
                    Dim strTmp() As String = MyValue.Split(New Char() {"|"c})
                    txtFDate.Value = strTmp(0)
                    cboEmp.Text = strTmp(1)
                    txtActionDone.Text = strTmp(2)

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
    Private Sub FillEmp()
        '<EhHeader>
        Try
            '</EhHeader>
            Try


                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Emp", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                cboEmp.Items.Clear()
                If readr.HasRows Then
                    While readr.Read
                        cboEmp.Items.Add(New MyList(readr.Item("EmpName"), readr.Item("EmpCode")))
                    End While
                End If
                readr.Close()
                'cboRecEmp.SelectedIndex = 0
                'cboAssignEmp.SelectedIndex = 0
                'cboLastEmp.SelectedIndex = 0
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
