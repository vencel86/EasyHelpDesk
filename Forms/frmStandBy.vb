Public Class frmStandBy

    Private Sub frmStandBy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<EhHeader>
        Try
            '</EhHeader>
            FillCustomer("Surat")
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub FillCustomer(ByVal strCity As String)
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim strQuery As String = ""
                If strCity = String.Empty Then
                    strQuery = "Select * from tbl_Cust"
                Else
                    strQuery = "Select * from tbl_Cust where City='" + strCity + "' order by CustName"
                End If
                Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                cboCust.Items.Clear()
                If readr.HasRows Then
                    While readr.Read
                        'If PCustSelection = True Then
                        'cboCust.Items.Add(New MyList(readr.Item("Alias").ToString + " # " + readr.Item("CustName"), readr.Item("CustCode")))
                        'Else
                        cboCust.Items.Add(New MyList(readr.Item("CustName").ToString, readr.Item("CustCode")))
                        If readr.Item("Alias").ToString.Length <> 0 Then
                            cboCustCode.Items.Add(New MyList(readr.Item("Alias").ToString, readr.Item("CustCode")))
                        End If
                        ' End If

                    End While
                End If
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


End Class