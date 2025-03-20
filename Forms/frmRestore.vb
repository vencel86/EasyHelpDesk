Imports System.Windows.Forms

Public Class frmRestore

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '<EhHeader>
        Try
            '</EhHeader>
            If txtBackupFile.Text = "" Then
                MessageBox.Show("Please select a backup file.", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            cnMain.Close()
            Application.DoEvents()
            If RestoreData(txtBackupFile.Text.ToString, strCurPath) = True Then
                IO.File.Delete(strCurPath & "\Data.mdb")
                My.Computer.FileSystem.RenameFile(strCurPath & "\_Data.mdb", "Data.mdb")
                MsgBox("Restore finished, Please restart Easy Help Desk in order for the changes to take effect", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Info")
            Else
                MsgBox("There is some error, please try again later", MsgBoxStyle.Information, "Info")
                cnMain.Open()
                Application.DoEvents()
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

    Private Sub cmdOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenFile.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim fileD As New OpenFileDialog
            fileD.Filter = "Zip Files | *.zip"
            If fileD.ShowDialog() = DialogResult.OK Then
                txtBackupFile.Text = fileD.FileName

            Else
                txtBackupFile.Text = ""
                Exit Sub
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
End Class
