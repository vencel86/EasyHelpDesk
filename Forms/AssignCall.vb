Imports System.Windows.Forms

Public Class AssignCall
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
            End If
            FillEmp()

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

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Try

                Dim strQCriteria As String = String.Empty
                If cboEmp.SelectedIndex > -1 Then
                    strQCriteria = cboEmp.Items(cboEmp.SelectedIndex).ItemData
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

    Private Sub AssignCall_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        '<EhHeader>
        Try
            '</EhHeader>
            If e.KeyCode = Keys.Enter Then OK_Button.PerformClick()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
End Class
