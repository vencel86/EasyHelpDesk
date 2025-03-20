Imports System.IO
Imports System.Text
Imports Microsoft.Win32
Imports System.Globalization
Imports System
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Diagnostics


'Imports IntelliLock.Licensing

Module modErr
    '*************************************************************
    'NAME:          WriteToErrorLog
    'PURPOSE:       Open or create an error log and submit error message
    'PARAMETERS:    msg - message to be written to error file
    '               stkTrace - stack trace from error message
    '               title - title of the error file entry
    'RETURNS:       Nothing
    '*************************************************************

    Private strCurPath As String = Application.StartupPath & "\Logs"
    'Public DeveloperName As Boolean = False ' for Registration
    'hasp
    Dim Rtn As Integer = 0
    Friend IndentLevel As Integer
    Friend m_Log As String 'Logs


    Public Enum LogType As Integer
        StartApplication = 1
        EndApplication = 2
        EnterSub = 3
        LeaveSub = 4
        Message = 5
        ErrorMessage = 6
    End Enum
    Public Sub AppDirCheck()
        '<EhHeader>
        Try
            '</EhHeader>
            If IO.Directory.Exists(strCurPath) = False Then
                IO.Directory.CreateDirectory(strCurPath)
            End If


            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Public Sub WriteToErrorLog(ByVal msg As String, ByVal stkTrace As String, ByVal title As String)
        '<EhHeader>
        Try
            '</EhHeader>

            'check and make the directory if necessary; this is set to look in the application
            'folder, you may wish to place the error log in another location depending upon the
            'the user's role and write access to different areas of the file system
            'If Not System.IO.Directory.Exists(strCurPath & "\Errors\") Then
            'System.IO.Directory.CreateDirectory(strCurPath & "\Errors\")
            'End If

            ' check File size and delete if BIG

            'check the file
            Dim fs As FileStream = New FileStream(strCurPath & "\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim s As StreamWriter = New StreamWriter(fs)
            s.Close()
            fs.Close()

            'log it
            Dim fs1 As FileStream = New FileStream(strCurPath & "\errlog.txt", FileMode.Append, FileAccess.Write)
            Dim s1 As StreamWriter = New StreamWriter(fs1)
            s1.Write("Title: " & title & vbCrLf)
            s1.Write("Message: " & msg & vbCrLf)
            s1.Write("StackTrace: " & stkTrace & vbCrLf)
            s1.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
            s1.Write("===========================================================================================" & vbCrLf)
            s1.Close()
            fs1.Close()

            Dim MyFile As New FileInfo(strCurPath & "\errlog.txt")
            Dim FileSize As Long = MyFile.Length
            If FileSize > 1048576 Then File.Delete(strCurPath & "\errlog.txt")
            MyFile = Nothing


            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Public Sub WriteToEventsLog(ByVal msg As String)
        '<EhHeader>
        Try
            '</EhHeader>



            'check and make the directory if necessary; this is set to look in the application
            'folder, you may wish to place the error log in another location depending upon the
            'the user's role and write access to different areas of the file system
            'If Not System.IO.Directory.Exists(strCurPath & "\Errors\") Then
            'System.IO.Directory.CreateDirectory(strCurPath & "\Errors\")
            'End If

            ' check File size and delete if BIG

            'check the file
            Dim fs As FileStream = New FileStream(strCurPath & "\eventlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim s As StreamWriter = New StreamWriter(fs)
            s.Close()
            fs.Close()

            'log it
            Dim fs1 As FileStream = New FileStream(strCurPath & "\eventlog.txt", FileMode.Append, FileAccess.Write)
            Dim s1 As StreamWriter = New StreamWriter(fs1)
            s1.Write(msg & vbCrLf)
            s1.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
            s1.Write("===========================================================================================" & vbCrLf)
            s1.Close()
            fs1.Close()

            Dim MyFile As New FileInfo(strCurPath & "\eventlog.txt")
            Dim FileSize As Long = MyFile.Length
            If FileSize > 1048576 Then File.Delete(strCurPath & "\eventlog.txt")
            MyFile = Nothing



            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Public Sub AddStartUpLog(ByVal LogMessage As String)
        '<EhHeader>
        Try
            '</EhHeader>




            'Check if logging needs to be done
            'If UserSettingManagement.Instance.isLogOn = False Then Exit Sub

            Dim iIndent As Integer = 0

            If (LogMessage Is Nothing) Or (LogMessage.Length < 1) Then
                Exit Sub
            End If

            Dim iPad As Integer = 23 + IndentLevel + iIndent

            m_Log = m_Log & LogMessage & vbCrLf


            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Public Sub AddLog(ByVal LogMessage As String, Optional ByVal Type As LogType = LogType.Message)
        '<EhHeader>
        Try
            '</EhHeader>



            'Check if logging needs to be done
            ' If UserSettingManagement.Instance.isLogOn = False Then Exit Sub

            Dim iIndent As Integer = 0

            If (LogMessage Is Nothing) Or (LogMessage.Length < 1) Then
                Exit Sub
            End If

            Select Case Type
                Case LogType.EndApplication
                    IndentLevel -= 2
                    LogMessage = LogMessage & vbCrLf 'additional break

                Case LogType.EnterSub
                    LogMessage = "> Entering " & LogMessage

                Case LogType.LeaveSub
                    LogMessage = "< Leaving " & LogMessage
                    IndentLevel -= 2

                Case LogType.Message
                    'iIndent = 2

                Case LogType.ErrorMessage
                    'Modify the message to include error tags
                    LogMessage = "ERROR! " & vbCrLf &
                                "=".PadRight(80, CChar("=")) & vbCrLf &
                                LogMessage & vbCrLf &
                                "=".PadRight(80, CChar("=")) & vbCrLf
            End Select

            Dim iPad As Integer = 23 + IndentLevel + iIndent

            m_Log = m_Log & GetTimeStampForLogs().PadRight(iPad) & LogMessage & vbCrLf

            If Type = LogType.StartApplication Or Type = LogType.EnterSub Then
                IndentLevel += 2
            End If



            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Friend Function GetTimeStampForLogs() As String
        '<EhHeader>
        Try
            '</EhHeader>


            Return Now.ToString("dd/MMM/yyyy hh:mm:ss") 'with hour, minutes and seconds


            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function
    Public Sub WriteLog()
        '<EhHeader>
        Try
            '</EhHeader>


            Dim sPath As String = Path.Combine(Application.StartupPath, "logs\SystemLog_" & GetTimeStamp() & ".log")

            Try
                File.AppendAllText(sPath, m_Log)
                'Flush the logs
                m_Log = vbNullString
            Catch ex As Exception
                'SetStatusLabel("Failed to write log file")
            End Try



            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Friend Function GetTimeStamp() As String
        '<EhHeader>
        Try
            '</EhHeader>


            '---------------Examples of formats --------------
            '  "ddd, dd MMM yyyy"  --> Fri, 15 Dec 2006
            '  "dd_MMM_yyyy"       --> 15_Dec_2006
            '  "ddMMMyyyy"         --> 15Dec2006
            '-------------------------------------------------

            Return Now.ToString("ddMMMyyyy")



            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function






End Module
