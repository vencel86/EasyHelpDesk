Imports System.Data.OleDb
Public Class Log_in


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
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

    Private Sub Log_in_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                LoadSettings()

                If cnMain.State.Open Then cnMain.Close()
                cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_HUser order by UName", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                cboUserName.Items.Clear()
                If readr.HasRows Then
                    While readr.Read
                        cboUserName.Items.Add(New MyList(readr.Item("UName"), readr.Item("UCode")))
                    End While
                    If cboUserName.Items.Count <> 0 Then cboUserName.SelectedIndex = 0
                Else
                    cboUserName.Text = "admin"
                    txtPassword.Text = "admin"

                End If
                'cboUserName.Focus()
                txtPassword.Focus()
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

    Public Sub RetrieveUserPass()
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim cmd As New OleDb.OleDbCommand("SELECT * FROM [tbl_HUser] Where UName = '" & Trim(cboUserName.Text) & "' And [UPassword] = '" & Trim(txtPassword.Text) & "'", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader


                If Not readr.HasRows Then
                    If cboUserName.Text.ToLower = "admin" And txtPassword.Text = "admin" Then
                        Dim Mainform1 As New MDIMain
                        Mainform1.lblUserCode.Text = "0"
                        Mainform1.lblUserCode.Tag = "Admin"

                        Mainform1.Show()
                    Else
                        MsgBox("Invalid Username And Password", MsgBoxStyle.OkOnly, "Propmt")
                        txtPassword.Focus()
                        Me.DialogResult = DialogResult.None
                    End If
                Else
                    If cboUserName.Text.ToLower = "admin" And txtPassword.Text = "admin" Then

                    End If

                    Dim Mainform As New MDIMain
                    While readr.Read
                        Mainform.lblUserCode.Text = readr.Item("UCode")
                        Mainform.lblUserCode.Tag = cboUserName.Text
                    End While
                    'Mainform.lblUserCode.Text = cboUserName.Items(cboUserName.SelectedIndex).itemdata
                    Mainform.Show()
                    'Find.Show()
                    '  Main.lbluser.Text = txtUserName.Text
                    Me.Hide()
                End If

                readr.Close()
                cmd.Dispose()

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        '<EhHeader>
        Try
            '</EhHeader>
            RetrieveUserPass()
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
            '   Timer1.Enabled = False
            '  Button1_Click(sender, e)

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
End Class