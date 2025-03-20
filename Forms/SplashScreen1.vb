Public NotInheritable Class SplashScreen1

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '<EhHeader>
        Try
            '</EhHeader>
            'Set up the dialog text at runtime according to the application's assembly information.  

            'TODO: Customize the application's assembly information in the "Application" pane of the project 
            '  properties dialog (under the "Project" menu).

            'Application title
            If My.Application.Info.Title <> "" Then
                ApplicationTitle.Text = My.Application.Info.Title
            Else
                'If the application title is missing, use the application name, without the extension
                ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If

            'Format the version information using the text set into the Version control at design time as the
            '  formatting string.  This allows for effective localization if desired.
            '  Build and revision information could be included by using the following code and changing the 
            '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
            '  String.Format() in Help for more information.
            '
            '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

            Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

            'Copyright info
            lblCopyRight.Text = My.Application.Info.Copyright

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Private Sub SplashScreen1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        '<EhHeader>
        Try
            '</EhHeader>
            'Dim fr As New MDIMain
            'fr.Show()


            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '   Timer1.Enabled = False
    '  DialogResult = DialogResult.OK
    ' Me.Close()
    'End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        '<EhHeader>
        Try
            '</EhHeader>

            Cursor = Cursors.WaitCursor
            ProgBar.Value += 10
            If ProgBar.Value >= 100 Then
                'ProgBar.Value = 0
                'splashClosed = True
                Timer2.Enabled = False
                DialogResult = DialogResult.None
                LoadSettings()
                'Dim Mainform1 As New MDIMain
                'Mainform1.lblUserCode.Text = "0"
                'Mainform1.lblUserCode.Tag = "Admin"
                'Mainform1.Show()
                Dim fr As New Log_in
                fr.ShowDialog()
                fr.Dispose()
                Me.Close()
            Else
                'splashClosed = False
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
