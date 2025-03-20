Imports System.Windows.Forms
Public Class SettingForm
    Private Sub Employee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<EhHeader>
        Try
            '</EhHeader>
            Call FillCallFrom()
            Call FillCompDateTime()
            Call FillCallPriority()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillCompDateTime()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strTmp As String = ""
            Try
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Settings", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                If readr.HasRows Then
                    While readr.Read
                        'DTFormat = readr.Item("DateFormat")
                        ' DTTFormat = readr.Item("TimeFormat")
                        If readr.IsDBNull(0) = False Or readr.Item("CompName").ToString.Length <> 0 Then
                            txtCompanyName.Text = readr.Item("CompName").ToString
                        End If
                        strTmp = readr.Item("DateFormat").ToString
                        If strTmp = "MM/dd/yyyy" Then
                            rbMMDDYYYY.Checked = True
                        ElseIf strTmp = "dd/MM/yyyy" Then
                            rbDDMMYYYY.Checked = True
                        ElseIf strTmp = "MMM/dd/yyyy" Then
                            rbMMMDDYYY.Checked = True
                        ElseIf strTmp = "dd/MMM/yyyy" Then
                            rbDDMMMYYYY.Checked = True
                        Else
                            RBCustomDate.Checked = True
                            txtDateFormat.Text = strTmp
                        End If

                        strTmp = readr.Item("TimeFormat").ToString
                        If strTmp = "hh:mm ampm" Then
                            rb12Hour.Checked = True
                        Else
                            rb24Hour.Checked = True
                        End If
                        'strTmp = readr.Item("CustomerSelection").ToString
                        'If strTmp = True Then
                        'rbCustCode.Checked = True
                        'Else
                        ' rbCustName.Checked = True
                        'End If
                    End While
                End If
                readr.Close()
                cmd = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
                'DTFormat = "MM/DD/YYYY"
                'DTTFormat = "hh:mm ampm"
            End Try


            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillCallPriority()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strTmp As String = ""
            Dim i As Integer = 1
            Try
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_CPriority order by MCode", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                If readr.HasRows Then
                    While readr.Read
                        'DTFormat = readr.Item("DateFormat")
                        ' DTTFormat = readr.Item("TimeFormat")

                        If i = 1 Then
                            If readr.IsDBNull(1) = False Then
                                txtPriority1.Text = readr.Item("CPriority")
                                txtDay1.Text = readr.Item("DayReq").ToString & ""
                            End If
                            If readr.Item("DefVal") = "1" Then
                                rbDefPrior1.Checked = True
                            End If
                        End If

                        If i = 2 Then
                            If readr.IsDBNull(1) = False Then
                                txtPriority2.Text = readr.Item("CPriority")
                                txtDay2.Text = readr.Item("DayReq")
                            End If
                            If readr.Item("DefVal") = "1" Then
                                rbDefPrior2.Checked = True
                            End If
                        End If

                        If i = 3 Then
                            If readr.IsDBNull(1) = False Then
                                txtPriority3.Text = readr.Item("CPriority")
                                txtDay3.Text = readr.Item("DayReq")
                            End If
                            If readr.Item("DefVal") = "1" Then
                                rbDefPrior3.Checked = True
                            End If
                        End If

                        If i = 4 Then
                            If readr.IsDBNull(1) = False Then
                                txtPriority4.Text = readr.Item("CPriority")
                                txtDay4.Text = readr.Item("DayReq")
                            End If
                            If readr.Item("DefVal") = "1" Then
                                rbDefPrior4.Checked = True
                            End If
                        End If

                        i = i + 1
                    End While
                End If
                readr.Close()
                cmd = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
                'DTFormat = "MM/DD/YYYY"
                'DTTFormat = "hh:mm ampm"
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillCallFrom()
        '<EhHeader>
        Try
            '</EhHeader>
            Dim i As Integer = 0
            Try
                With LVCallFrom.Items.Add("0")
                    .SubItems.Add("Existing Customer")
                End With
                With LVCallFrom.Items.Add("1")
                    .SubItems.Add("Mail Query")
                End With
                With LVCallFrom.Items.Add("2")
                    .SubItems.Add("From Website")
                End With
                With LVCallFrom.Items.Add("3")
                    .SubItems.Add("Advertisement")
                End With
                With LVCallFrom.Items.Add("4")
                    .SubItems.Add("Yellow Pages")
                End With
                With LVCallFrom.Items.Add("5")
                    .SubItems.Add("Business Directory")
                End With
                With LVCallFrom.Items.Add("6")
                    .SubItems.Add("By Reference")
                End With
                With LVCallFrom.Items.Add("7")
                    .SubItems.Add("Other")
                End With
                LVCallFrom.Items(My.Settings.CFrom).Selected = True
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

    Private Function SaveCallFrom() As Boolean
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                My.Settings.CFrom = LVCallFrom.SelectedItems(0).Index
                My.Settings.Save()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Error")
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
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                If PriorityValidateSave() = False Then Exit Sub
                If DateAndTimeSave() = False Then Exit Sub
                If SaveCallFrom() = False Then Exit Sub

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                MsgBox("Please restart Easy Help Desk in order for the changes to take effect", MsgBoxStyle.Information, "Info")
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Error")
            End Try

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


    Private Function PriorityValidateSave() As Boolean
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Dim intDefVal1 As String = 0
            Dim intDefVal2 As String = 0
            Dim intDefVal3 As String = 0
            Dim intDefVal4 As String = 0

            Try
                If txtPriority1.Text.Length = 0 Then
                    MsgBox("Call priority field can't be left blank, please correct it", MsgBoxStyle.Information, "Information")
                    txtPriority1.Focus()
                    Return False
                End If
                If txtPriority2.Text.Length = 0 Then
                    MsgBox("Call priority field can't be left blank, please correct it", MsgBoxStyle.Information, "Information")
                    txtPriority2.Focus()
                    Return False
                End If
                If txtPriority3.Text.Length = 0 Then
                    MsgBox("Call priority field can't be left blank, please correct it", MsgBoxStyle.Information, "Information")
                    txtPriority3.Focus()
                    Return False
                End If
                If txtPriority4.Text.Length = 0 Then
                    MsgBox("Call priority field can't be left blank, please correct it", MsgBoxStyle.Information, "Information")
                    txtPriority4.Focus()
                    Return False
                End If

                If rbDefPrior1.Checked = True Then intDefVal1 = 1
                If rbDefPrior2.Checked = True Then intDefVal2 = 2
                If rbDefPrior3.Checked = True Then intDefVal3 = 3
                If rbDefPrior4.Checked = True Then intDefVal4 = 4

                strQuery = "Update tbl_CPriority set CPriority = '" + txtPriority1.Text + "', DefVal = '" + intDefVal1 + "', DayReq = '" + txtDay1.Text + "' where MCode ='1'"
                If ExecQuery(strQuery) = False Then Return False

                strQuery = "Update tbl_CPriority set CPriority = '" + txtPriority2.Text + "', DefVal = '" + intDefVal2 + "', DayReq = '" + txtDay2.Text + "' where MCode ='2'"
                If ExecQuery(strQuery) = False Then Return False

                strQuery = "Update tbl_CPriority set CPriority = '" + txtPriority3.Text + "', DefVal = '" + intDefVal3 + "', DayReq = '" + txtDay3.Text + "' where MCode ='3'"
                If ExecQuery(strQuery) = False Then Return False

                strQuery = "Update tbl_CPriority set CPriority = '" + txtPriority4.Text + "', DefVal = '" + intDefVal4 + "', DayReq = '" + txtDay4.Text + "' where MCode ='4'"
                If ExecQuery(strQuery) = False Then Return False


                Return True
            Catch ex As Exception
                Return False
                MsgBox(ex.Message)
            End Try
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Function

    Private Function DateAndTimeSave() As Boolean
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Dim strTimeFormat As String = ""
            Dim strDateFormat As String = ""
            Try
                If rb12Hour.Checked = True Then
                    strTimeFormat = "hh:mm ampm"
                Else
                    strTimeFormat = "hh:mm"
                End If


                If rbMMDDYYYY.Checked = True Then
                    strDateFormat = "MM/dd/yyyy"
                ElseIf rbDDMMYYYY.Checked = True Then

                    strDateFormat = "dd/MM/yyyy"
                ElseIf rbMMMDDYYY.Checked = True Then
                    strDateFormat = "MMM/dd/yyyy"
                ElseIf rbDDMMMYYYY.Checked = True Then
                    strDateFormat = "dd/MMM/yyyy"
                ElseIf RBCustomDate.Checked = True Then
                    If txtDateFormat.Text.Length = 0 Then
                        MsgBox("Please set format of custom date", MsgBoxStyle.Information, "Information")
                        txtDateFormat.Focus()
                        Return False
                    End If
                    strDateFormat = txtDateFormat.Text
                End If

                Call ExecQuery("Delete from tbl_Settings")

                'strQuery = "insert into tbl_Settings values('" & txtCompanyName.Text & "','" & strDateFormat & "','" & strTimeFormat & "','" & If(rbCustName.Checked, 0, 1) & "')"
                strQuery = "insert into tbl_Settings values('" & txtCompanyName.Text & "','" & strDateFormat & "','" & strTimeFormat & "')"
                If ExecQuery(strQuery) = False Then Return False

                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Information")
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




    Private Sub RBCustomDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBCustomDate.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If RBCustomDate.Checked = True Then
                txtDateFormat.Enabled = True
                txtDateFormat.Focus()
            Else
                txtDateFormat.Enabled = False
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Private Sub txtDay1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDay1.KeyPress
        '<EhHeader>
        Try
            '</EhHeader>
            '97 - 122 = Ascii codes for simple letters
            '65 - 90  = Ascii codes for capital letters
            '48 - 57  = Ascii codes for numbers

            If Asc(e.KeyChar) <> 8 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtDay2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDay2.KeyPress
        '<EhHeader>
        Try
            '</EhHeader>
            If Asc(e.KeyChar) <> 8 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtDay3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDay3.KeyPress
        '<EhHeader>
        Try
            '</EhHeader>
            If Asc(e.KeyChar) <> 8 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtDay4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDay4.KeyPress
        '<EhHeader>
        Try
            '</EhHeader>
            If Asc(e.KeyChar) <> 8 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Private Sub LVCallFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVCallFrom.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                If LVCallFrom.SelectedItems.Count < 1 Then Exit Sub
                lblCallFrom.Text = LVCallFrom.SelectedItems(0).Text
                txtCallFrom.Text = LVCallFrom.SelectedItems(0).SubItems(1).Text

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

    Private Sub btnCFSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strCode As String = ""
            Dim strQuery As String = ""
            Try

                If txtCallFrom.Text.Length = 0 Then
                    MsgBox("Please provide call from text!", MsgBoxStyle.Information, "Error")
                    txtCallFrom.Focus()
                    Exit Sub
                End If

                If lblCallFrom.Text = "0" Then
                    strCode = TRCode("Select max(cint(MCode)) from tbl_CFrom")
                    strQuery = "insert into tbl_CFrom values('" & strCode & "','" & txtCallFrom.Text.Replace("'", "''") & "','" & 0 & "')"
                    If ExecQuery(strQuery) = False Then Exit Sub
                    MsgBox("New call from category added successfully", MsgBoxStyle.Information, "Status")

                ElseIf lblCallFrom.Text <> 0 Then
                    Dim intTmp As Integer = 0
                    strQuery = "Update tbl_CFrom set CFrom = '" + txtCallFrom.Text.Replace("'", "''") + "', DefVal = '" & 0 & "' " &
                    "where MCode ='" + lblCallFrom.Text + "'"
                    If ExecQuery(strQuery) = False Then Exit Sub
                    MsgBox("Call from category updated successfully", MsgBoxStyle.Information, "Status")

                End If

                lblCallFrom.Text = "0"
                txtCallFrom.Text = ""
                Call FillCallFrom()
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'Me.Close()
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



    Private Sub btnCFDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Dim i As Integer = 0
            strQuery = "Select Count(*) from tbl_CallGen where Callfrom in ( select MCode from tbl_CFrom where MCode = '" & LVCallFrom.SelectedItems(0).Text & "')"
            i = GetTotalRecords(strQuery)
            If i <> 0 Then
                MsgBox("Service call has been assigned to selected category, can't delete!", MsgBoxStyle.Information, "Error")
                Exit Sub
            Else
                Call ExecQuery("Delete from tbl_CFrom where MCode = '" & LVCallFrom.SelectedItems(0).Text & "'")
                Call FillCallFrom()
            End If
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnCFAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            lblCallFrom.Text = "0"
            txtCallFrom.Text = ""
            txtCallFrom.Focus()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvCallUnder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
End Class
