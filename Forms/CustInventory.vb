Imports System.Windows.Forms

Public Class CustInventory
    Private _mstrTmp As String = ""
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
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strString As String = ""
            If lblMCode.Text = 0 Then
                'If cboInventory.SelectedIndex <> 0 Then
                'strString = cboInventory.Items(cboInventory.SelectedIndex).ItemData().ToString
                'Else
                '   strString = "0"
                'End If
                strString = txtMachineName.Text
                If cboServiceUnder.Text = "AMC" Then
                    strString = strString + "|" + "A"
                Else
                    strString = strString + "|" + "W"
                End If
                If dtpFrom.Checked = True Then
                    strString = strString + "|" + dtpFrom.Value.ToString(DTFormat)
                Else
                    strString = strString + "|" + "0"
                End If
                If dtpTo.Checked = True Then
                    strString = strString + "|" + dtpTo.Value.ToString(DTFormat)
                Else
                    strString = strString + "|" + "0"
                End If

                _mstrTmp = strString
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
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

    Private Sub CustInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<EhHeader>
        Try
            '</EhHeader>
            dtpFrom.CustomFormat = DTFormat
            dtpTo.CustomFormat = DTFormat

            'Call FillInventory()
            Call FillServiceUnder()

            If _mstrTmp Is Nothing Or _mstrTmp.Length <> 0 Then
                Dim strTmp() As String = MyValue.Split(New Char() {"|"c})
                If strTmp(2).Length <> 0 Then
                    dtpFrom.Value = strTmp(2)
                Else
                    dtpFrom.Checked = False
                End If
                If strTmp(3).Length <> 0 Then
                    dtpTo.Value = strTmp(3)
                Else
                    dtpTo.Checked = False
                End If
                txtMachineName.Text = strTmp(0)
                'cboInventory.Text = strTmp(0)
                cboServiceUnder.Text = strTmp(1)
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    'Private Sub FillInventory()
    'Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Inventory", cnMain)
    'Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
    '   cboInventory.Items.Clear()
    '  cboInventory.Items.Add("")
    'If readr.HasRows Then
    'While readr.Read
    '           cboInventory.Items.Add(New MyList(readr.Item("EName"), readr.Item("MCode")))
    'End While
    'End If
    '   readr.Close()
    '  cmd = Nothing
    ' cboInventory.SelectedIndex = 0

    'End Sub
    Private Sub FillServiceUnder()
        '<EhHeader>
        Try
            '</EhHeader>
            'Dim cmd As New OleDb.OleDbCommand("Select * from tbl_CType", cnMain)
            'Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
            'cboServiceUnder.Items.Clear()
            'cboServiceUnder.Items.Add("")
            'If readr.HasRows Then
            'While readr.Read
            'cboServiceUnder.Items.Add(New MyList(readr.Item("CType"), readr.Item("MCode")))
            'End While
            'End If
            'readr.Close()
            'cmd = Nothing
            cboServiceUnder.Items.Clear()
            cboServiceUnder.Items.Add("AMC")
            cboServiceUnder.Items.Add("Warranty")
            cboServiceUnder.SelectedIndex = 0

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


End Class
