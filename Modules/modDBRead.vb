Imports IntelliLock.Licensing
Imports DBUpdateNetDLL
Imports System.Data.OleDb

Module modDBRead
    Public DTFormat As String = "" '"MM/DD/YYYY"
    Public DTTFormat As String = "" '"hh:mm ampm"
    Public PCustSelection As Boolean = False
    Public PCompanyName As String = ""
    Public DeveloperName As Boolean = False

    Public Sub LoadSettings()
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                'Debug.Print(cnMain.ConnectionString.ToString)
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Settings", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader


                If readr.HasRows Then
                    While readr.Read
                        DTFormat = readr.Item("DateFormat")
                        DTTFormat = readr.Item("TimeFormat")
                        PCompanyName = readr.Item("CompName")
                        '  PCustSelection = If(readr.Item("CustomerSelection") = False, False, True)
                    End While
                Else
                    DTFormat = "MM/dd/yyyy"
                    DTTFormat = "hh:mm tt"
                    PCompanyName = "Your Company Name will be displayed here"
                End If
                readr.Close()
                Try
                    cmd.CommandText = "Select VerInfo from DataInfo"
                    readr = cmd.ExecuteReader

                    If readr.HasRows Then
                        While readr.Read

                            If isDBUpRequired(readr.Item("VerInfo").ToString) = True Then
                                readr.Close()
                                cnMain.Close()
                                cnMain.Dispose()
                                If StrctureUpdate() = True Then
                                    cnMain.ConnectionString = "Provider = Microsoft.jet.OLEDB.4.0;Data Source =" & strCurPath & "\Data.mdb"
                                    cnMain.Open()


                                    ExecQuery("Update DataInfo set VerInfo ='" & My.Application.Info.Version.ToString & "'")
                                    cnMain.Close()
                                    cnMain.Dispose()

                                    MsgBox("Data maintenance finished, you must re-start Easy Help Desk", MsgBoxStyle.Information, "Information")
                                    End

                                Else
                                    MsgBox("There are errors while updating database, Please contact the Administrator")
                                    Exit Sub
                                End If
                            End If
                        End While
                    End If

                Catch
                    'Call StrctureUpdate()
                    'MsgBox("Data maintenance finished, Please restart Easy Help Desk", MsgBoxStyle.Information, "Information")
                End Try

                cmd = Nothing

            Catch ex As Exception
                If ex.Message.ToString = "The 'Microsoft.jet.OLEDB.4.0' provider is not registered on the local machine." Then
                    MsgBox(ex.Message.ToString)
                    Exit Sub
                End If
                If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Easy Help Desk") Then
                    IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Easy Help Desk")
                    'IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Easy Help Desk")
                End If
                'If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\JBM Vision\Help Desk Pro") Then
                'IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\JBM Vision\Help Desk Pro")
                'End If
                IO.File.Copy(Application.StartupPath + "\Data\Data.mdb", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Easy Help Desk\Data.mdb")

                MsgBox("Data maintenance finished, Please restart Easy Help Desk", MsgBoxStyle.Information, "Information")
                DTFormat = "MM/DD/YYYY"
                DTTFormat = "hh:mm ampm"
            End Try


            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Public Function GR_Done() As Boolean
        '<EhHeader>
        Try
            '</EhHeader>
            'Read License information from the file
            '  Dim lock_Enabled As Boolean = EvaluationMonitor.CurrentLicense.ExpirationDays_Enabled
            'Dim days As Integer = EvaluationMonitor.CurrentLicense.ExpirationDays_Enabled
            'Dim days_current As Integer = EvaluationMonitor.CurrentLicense.ExpirationDays_Current
            'MsgBox(" is lock enabled :" & lock_Enabled)
            'MsgBox(" Total days : " & days)
            'MsgBox(" Current Day: " & days)

            'If IO.File.Exists(Application.StartupPath & "\cms.license") = True Then
            '    If EvaluationMonitor.CurrentLicense.LicenseStatus <> IntelliLock.Licensing.LicenseStatus.Licensed Then
            '        DeveloperName = False
            '        MsgBox("License file is invalid", MsgBoxStyle.Information, "Information")
            '        Return False
            '    Else

            '        If HardwareID.GetHardwareID(False, True, False, False, False, False) = EvaluationMonitor.CurrentLicense.HardwareID Then
            '            DeveloperName = True

            '        Else
            '            DeveloperName = False
            '        End If
            '        'ends here
            '        Return DeveloperName
            '    End If
            '    Return False
            'Else
            '    Return False
            'End If
            DeveloperName = True
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function

    Private Function isDBUpRequired(ByVal strDBVersion As String) As Boolean
        Return False
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                If My.Application.Info.Version.Major.ToString >= strDBVersion.Substring(0, 1) Then
                    If My.Application.Info.Version.Minor.ToString <= strDBVersion.Substring(2, 1) Then
                        If My.Application.Info.Version.Build.ToString >= strDBVersion.Substring(4, 1) Then
                            If My.Application.Info.Version.MinorRevision.ToString >= strDBVersion.Substring(6, 1) Then
                                Return False
                            Else
                                Return True
                            End If
                        Else
                            Return True
                        End If
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
                Return False
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
    Private Function StrctureUpdate() As Boolean
        '<EhHeader>
        Try
            '</EhHeader>

            Dim connDB As New ADODB.Connection
            Dim connModel As New ADODB.Connection

            Dim sLog As String = ""
            Dim sLogError As String = ""
            Dim bAnyErrors As Boolean
            Try
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor 'show hourglass while processing
                connDB.ConnectionString = "Provider = Microsoft.jet.OLEDB.4.0;Data Source =" & strCurPath & "\Data.mdb"
                'connDB.Open() ' update this database
                connModel.ConnectionString = "Provider = Microsoft.jet.OLEDB.4.0;Data Source =" & Application.StartupPath + "\Data\DataUpd.mdb"
                'connModel.Open() ' with this database

                If DoCreate(connModel, connDB, sLog, sLogError, bAnyErrors) Then 'do the update
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default  'reset mouse pointer
                    'connDB.Close()          'close databases
                    'connModel.Close()
                    connDB = Nothing        'clear references
                    connModel = Nothing
                    Return True
                Else


                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default  'reset mouse pointer
                    'connDB.Close()          'close databases
                    'connModel.Close()
                    connDB = Nothing        'clear references
                    connModel = Nothing
                    Return False

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
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
    Public Function DoCreate(ByVal connModel As ADODB.Connection,
                             ByVal connDB As ADODB.Connection,
                             ByRef sLog As String, ByRef sLogError As String,
                             ByVal bAnyErrors As Boolean) As Boolean
        '<EhHeader>
        Try
            '</EhHeader>
            Try

                Dim obj As New DBUpdateNetDLL.cUpdateNet
                With obj
                    .sAppPath = Application.StartupPath + "\Data"
                    .connModel = connModel
                    .connDB = connDB

                    If .Update() Then
                        sLog = .sFileNameLog
                        sLogError = .sFileNameErrorLog
                        bAnyErrors = .bAnyErrors
                        Try
                            obj.connDB.Close()
                            obj.connModel.Close()
                        Catch

                        End Try
                        Return True
                    Else
                        Return False
                    End If
                End With
            Catch ex As Exception
                MsgBox(ex.ToString)
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
    Public Sub FillDataGrid(ByVal sql As String, ByVal dgv As DataGridView)
        '<EhHeader>
        Try
            '</EhHeader>
            'Dim conn As  OleDbConnection  = New  OleDbConnection (CnString)
            Try
                '   conn.Open()
                Dim cmd As OleDbCommand = New OleDbCommand(sql.ToLower, cnMain)
                Dim adp As OleDbDataAdapter = New OleDbDataAdapter()
                Dim dt As DataTable = New DataTable()
                adp.SelectCommand = cmd
                adp.Fill(dt)
                dgv.DataSource = dt
                adp.Dispose()
                cmd.Dispose()
            Catch ex As Exception

            Finally
                'conn.Close()
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
End Module
