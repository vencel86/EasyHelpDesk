Module modGlobal
    'Public strCurPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Easy Help Desk"
    Public strCurPath As String = Application.StartupPath & "\Data"
    Public cnMain As New OleDb.OleDbConnection("Provider = Microsoft.jet.OLEDB.4.0;Data Source =" & strCurPath & "\Data.mdb")
    'Public cnMain As New OleDb.OleDbConnection("Provider = Microsoft.jet.OLEDB.4.0;Data Source =" & Application.StartupPath & "\Data\Data.mdb")
    Dim frmSplash As SplashScreen1


    Dim frmMain As MDIMain
    Dim splashTimer As Timer

    Public Sub Main()
        '<EhHeader>
        Try
            '</EhHeader>
            splashTimer = New Timer()
            AddHandler splashTimer.Tick, AddressOf TimerTick
            splashTimer.Interval = 3000
            splashTimer.Start()
            frmSplash = New SplashScreen1
            frmSplash.ShowDialog()
            System.Windows.Forms.Application.Run(New MDIMain)
            frmMain = New MDIMain
            frmMain.Show()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub TimerTick(ByVal sender As Object, ByVal e As EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            splashTimer.Stop()
            frmSplash.Close()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Public Function ExecQuery(ByVal strQuery As String) As Boolean
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = cnMain
                cmd.CommandText = strQuery
                cmd.ExecuteNonQuery()
                cmd = Nothing
                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MessageBoxIcon.Error)
                Return False
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function
    Public Function GetTextFromCode(ByVal strMField As String, ByVal strCodeValue As String, ByVal strReturnField As String, ByVal strTable As String)
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim strQuery As String
                strQuery = "Select " & strReturnField & " from " & strTable & " where " & strMField & " = '" & strCodeValue & "'"
                Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                Dim DR As OleDb.OleDbDataReader = cmd.ExecuteReader

                Dim strVal As String = 0

                If DR.HasRows Then
                    DR.Read()
                    strVal = DR.Item(0).ToString
                    cmd = Nothing
                    DR.Close()
                    Return strVal
                Else
                    cmd = Nothing
                    DR.Close()
                    Return 0

                End If
                DR.Close()
                cmd = Nothing
            Catch ex As Exception
                Return 0
                'MsgBox(ex.Message, MessageBoxIcon.Error)
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function
    Public Function IfExistinDB(ByVal strMField As String, ByVal strFieldVal As String, ByVal strTable As String) As Boolean
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                IfExistinDB = False
                Dim strQuery As String
                strQuery = "Select " & strMField & " from " & strTable & " where " & strMField & " = '" & strFieldVal & "'"
                Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                Dim DR As OleDb.OleDbDataReader = cmd.ExecuteReader

                Dim strVal As String = 0

                If DR.HasRows Then
                    DR.Read()
                    strVal = DR.Item(0).ToString
                    cmd = Nothing
                    DR.Close()
                    Return True
                Else
                    cmd = Nothing
                    DR.Close()
                    Return False

                End If
                DR.Close()
                cmd = Nothing
            Catch ex As Exception
                Return False
                'MsgBox(ex.Message, MessageBoxIcon.Error)
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function
    Public Function TRCode(ByVal strText As String)
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim intTmp As Integer
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand(strText, cnMain)
                intTmp = cmd.ExecuteScalar
                If Len(intTmp & "") <> 0 Then
                    intTmp = intTmp + 1
                    cmd = Nothing
                    Return intTmp
                Else
                    cmd = Nothing
                    Return intTmp
                End If
            Catch ex As Exception
                Return 1
                'MsgBox(ex.Message, MessageBoxIcon.Error)
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function
    Public Function GetTotalRecords(ByVal strQueryText As String)
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim intTmp As Integer
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand(strQueryText, cnMain)
                intTmp = cmd.ExecuteScalar
                If Len(intTmp & "") <> 0 Then
                    intTmp = intTmp
                    cmd = Nothing
                    Return intTmp
                Else
                    cmd = Nothing
                    Return 0

                End If

            Catch ex As Exception

                'MsgBox(ex.Message, MessageBoxIcon.Error)
                Return 0
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function
    Public Sub BackupData(ByVal strbackupPath As String)
        '<EhHeader>
        Try
            '</EhHeader>

            Dim zipPath As String = strbackupPath & "\Backup " & Now.ToString("mm-dd-yyyy") & ".zip"
            'Open the zip file if it exists, else create a new one 

            'If IO.Directory.Exists(strCurPath & "\Backup") = False Then IO.Directory.CreateDirectory(strCurPath & "\Backup")
            Dim zip As IO.Packaging.Package = IO.Packaging.ZipPackage.Open(zipPath, _
                 IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)

            'Add as many files as you like:
            AddToArchive(zip, strCurPath & "\Data.mdb")

            zip.Close() 'Close the zip file
            MsgBox("Data backup made", MsgBoxStyle.Information, "Info")

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Public Sub AddToArchive(ByVal zip As IO.Packaging.Package, _
                         ByVal fileToAdd As String)
        '<EhHeader>
        Try
            '</EhHeader>

            'Replace spaces with an underscore (_) 
            Dim uriFileName As String = fileToAdd.Replace(" ", "_")

            'A Uri always starts with a forward slash "/" 
            Dim zipUri As String = String.Concat("/", _
                       IO.Path.GetFileName(uriFileName))

            Dim partUri As New Uri(zipUri, UriKind.Relative)
            Dim contentType As String = _
                       Net.Mime.MediaTypeNames.Application.Zip

            'The PackagePart contains the information: 
            ' Where to extract the file when it's extracted (partUri) 
            ' The type of content stream (MIME type):  (contentType) 
            ' The type of compression:  (CompressionOption.Normal)   
            Dim pkgPart As IO.Packaging.PackagePart = zip.CreatePart(partUri, _
                       contentType, IO.Packaging.CompressionOption.Normal)

            'Read all of the bytes from the file to add to the zip file 
            Dim bites As Byte() = IO.File.ReadAllBytes(fileToAdd)

            'Compress and write the bytes to the zip file 
            pkgPart.GetStream().Write(bites, 0, bites.Length)

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Public Function RestoreData(ByVal pZipFilename As String, ByVal pOutputPath As String) As Boolean
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Using pkgMain As IO.Packaging.Package = IO.Packaging.Package.Open(pZipFilename, IO.FileMode.Open, IO.FileAccess.Read)
                    For Each pkgPart As IO.Packaging.PackagePart In pkgMain.GetParts()

                        Dim strTarget As String = IO.Path.Combine(pOutputPath, CreateFilenameFromUri(pkgPart.Uri))
                        Using stmSource As IO.Stream = pkgPart.GetStream(IO.FileMode.Open, IO.FileAccess.Read)
                            Using stmDestination As IO.Stream = IO.File.OpenWrite(strTarget)
                                Dim arrBuffer(10000) As Byte
                                Dim intRead As Integer
                                intRead = stmSource.Read(arrBuffer, 0, arrBuffer.Length)
                                While intRead > 0
                                    stmDestination.Write(arrBuffer, 0, intRead)
                                    intRead = stmSource.Read(arrBuffer, 0, arrBuffer.Length)
                                End While
                            End Using
                        End Using
                    Next
                End Using
                Return True
            Catch ex As Exception
                Return False
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function
    Private Function CreateFilenameFromUri(ByVal uri As Uri) As String
        '<EhHeader>
        Try
            '</EhHeader>
            Dim invalidChars As Char() = IO.Path.GetInvalidFileNameChars()
            Dim sb As New System.Text.StringBuilder(uri.OriginalString.Length)
            For Each c As Char In uri.OriginalString
                sb.Append(If(Array.IndexOf(invalidChars, c) < 0, c, "_"c))
            Next
            Return sb.ToString()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function
    Function UppercaseFirstLetter(ByVal val As String) As String
        '<EhHeader>
        Try
            '</EhHeader>
            ' Test for nothing or empty.
            If String.IsNullOrEmpty(val) Then
                Return val
            End If

            Return val.ToUpper
            ' Convert to character array.
            Dim array() As Char = val.ToCharArray

            ' Uppercase first character.
            array(0) = Char.ToUpper(array(0))

            ' Return new string.
            Return New String(array)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function

End Module
