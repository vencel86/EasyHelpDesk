Imports System.Windows.Forms

Public Class FinalOP
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
            txtName.Select()

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
                If txtName.Text = String.Empty Then
                    MsgBox("Please enter name")
                    txtName.Select()
                    Exit Sub
                End If

                MyValue = txtName.Text
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
