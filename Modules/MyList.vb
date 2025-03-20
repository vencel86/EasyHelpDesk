Public Class MyList
    Private sName As String
    ' You can also declare this as String,bitmap or almost anything. 
    ' If you change this delcaration you will also need to change the Sub New 
    ' to reflect any change. Also the ItemData Property will need to be updated. 
    Private iID As String

    ' Default empty constructor. 
    Public Sub New()
        '<EhHeader>
        Try
            '</EhHeader>
            sName = ""
            ' This would need to be changed if you modified the declaration above. 
            iID = 0
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Public Sub New(ByVal Name As String, ByVal ID As Integer)
        '<EhHeader>
        Try
            '</EhHeader>
            sName = Name
            iID = ID
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Public Property Name() As String
        Get
            '<EhHeader>
            Try
                '</EhHeader>
                Return sName
                '<EhFooter>
            Catch ex As System.Exception
                Dim st As New StackTrace(True)
                st = New StackTrace(ex, True)
                AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
                WriteLog()
            End Try '</EhFooter>
        End Get
        Set(ByVal sValue As String)
            '<EhHeader>
            Try
                '</EhHeader>
                sName = sValue
                '<EhFooter>
            Catch ex As System.Exception
                Dim st As New StackTrace(True)
                st = New StackTrace(ex, True)
                AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
                WriteLog()
            End Try '</EhFooter>
        End Set
    End Property

    ' This is the property that holds the extra data. 
    Public Property ItemData() As Int32
        Get
            '<EhHeader>
            Try
                '</EhHeader>
                Return iID
                '<EhFooter>
            Catch ex As System.Exception
                Dim st As New StackTrace(True)
                st = New StackTrace(ex, True)
                AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
                WriteLog()
            End Try '</EhFooter>
        End Get
        Set(ByVal iValue As Int32)
            '<EhHeader>
            Try
                '</EhHeader>
                iID = iValue
                '<EhFooter>
            Catch ex As System.Exception
                Dim st As New StackTrace(True)
                st = New StackTrace(ex, True)
                AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
                WriteLog()
            End Try '</EhFooter>
        End Set
    End Property

    ' This is neccessary because the ListBox and ComboBox rely 
    ' on this method when determining the text to display. 
    Public Overrides Function ToString() As String
        '<EhHeader>
        Try
            '</EhHeader>
            Return sName
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function
End Class
