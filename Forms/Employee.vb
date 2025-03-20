Imports System.Windows.Forms

Public Class Employee
    Private m_SortingColumn As ColumnHeader
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '<EhHeader>
        Try
            '</EhHeader>
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

    Private Sub Employee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<EhHeader>
        Try
            '</EhHeader>
            cboDept.Items.Add("Help Desk")
            cboDept.Items.Add("Customer Service")
            cboDept.Items.Add("Sales")
            cboDept.Items.Add("Finance")
            cboDept.Items.Add("Human Resource")
            cboDept.Items.Add("Other")
            FillEmpLV()
            TabControl1.SelectedTab = TabPage2
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub ClearTexts()
        '<EhHeader>
        Try
            '</EhHeader>
            txtEmpName.Clear()
            txtAdd1.Clear()
            txtAdd2.Clear()
            txtPhoneO.Clear()
            txtPhoneR.Clear()
            txtCellphone1.Clear()
            txtCellphone2.Clear()
            txtEmail.Clear()
            cboCity.Text = "Surat"
            lblMCode.Text = "0"
            txtEmpName.Focus()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub lvEmp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEmp.DoubleClick
        '<EhHeader>
        Try
            '</EhHeader>
            btnEdit_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillEmpLV()
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Emp", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                lvEmp.Items.Clear()

                If readr.HasRows Then
                    While readr.Read
                        With lvEmp.Items.Add(readr.Item("EmpCode").ToString)
                            .SubItems.Add(readr.Item("EmpName").ToString)
                            .SubItems.Add(readr.Item("TelR").ToString)
                            .SubItems.Add(readr.Item("Cellphone1").ToString)
                            .SubItems.Add(readr.Item("Cellphone2").ToString)
                        End With
                    End While
                End If
                If lvEmp.Items.Count <> 0 Then lvEmp.Items(0).Selected = True
                lvEmp.Focus()
                readr.Close()
                cmd = Nothing
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

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Call ClearTexts()
            TabControl1.SelectedTab = TabPage1
            txtEmpName.Focus()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvEmp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEmp.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Try

                If lvEmp.SelectedItems.Count < 1 Then Exit Sub
                lblMCode.Text = lvEmp.SelectedItems(0).Text
                strQuery = "Select * from tbl_Emp where EmpCode ='" & lblMCode.Text & "'"

                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader

                If readr.HasRows Then
                    While readr.Read
                        txtEmpName.Text = readr.Item("EmpName") & ""
                        txtAdd1.Text = readr.Item("Add1") & ""
                        txtAdd2.Text = readr.Item("Add2") & ""
                        txtPhoneO.Text = readr.Item("TelO") & ""
                        txtPhoneR.Text = readr.Item("TelR") & ""
                        txtCellphone1.Text = readr.Item("Cellphone1") & ""
                        txtCellphone2.Text = readr.Item("Cellphone2") & ""
                        txtEmail.Text = readr.Item("EmailAdd") & ""
                    End While
                End If
                readr.Close()

                cmd.CommandText = "Select * from tbl_HUser where UCode ='" & lblMCode.Text & "'"
                readr = cmd.ExecuteReader
                If readr.HasRows Then
                    While readr.Read
                        txtUserName.Text = readr.Item("UName")
                        txtPassword.Text = readr.Item("UPassword")
                    End While
                End If

                readr.Close()
                cmd = Nothing

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


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strCode As String = ""
            Dim strQuery As String = ""
            Try

                If txtEmpName.Text.Length = 0 Then
                    MsgBox("Please enter employee name!", MsgBoxStyle.Information, "Error")
                    txtEmpName.Focus()
                    Me.DialogResult = Windows.Forms.DialogResult.None
                    Exit Sub
                End If
                'user name pasword validation
                If txtUserName.Text.Length <> 0 Then
                    If txtUserName.Text.Contains(" ") = True Then
                        MsgBox("Username can't contain blank space!", MsgBoxStyle.Information, "Error")
                        txtUserName.Focus()
                        Me.DialogResult = Windows.Forms.DialogResult.None
                        Exit Sub
                    End If
                    If txtPassword.Text.Length = 0 Then
                        MsgBox("Password can't be left blank!", MsgBoxStyle.Information, "Error")
                        txtPassword.Focus()
                        Me.DialogResult = Windows.Forms.DialogResult.None
                        Exit Sub
                    End If
                    If txtPassword.Text.Contains(" ") = True Then
                        MsgBox("Password can't contain blank space!", MsgBoxStyle.Information, "Error")
                        txtPassword.Focus()
                        Me.DialogResult = Windows.Forms.DialogResult.None
                        Exit Sub
                    End If
                End If


                If lblMCode.Text = "0" Then

                    strCode = TRCode("Select max(cint(EmpCode)) from tbl_Emp")

                    strQuery = "insert into tbl_Emp values('" & strCode & "','" & txtEmpName.Text.Replace("'", "''") & "','" & cboDept.Text.Replace("'", "''") & "','" _
                        & txtJobTitle.Text.Replace("'", "''") & "','" & txtAdd1.Text.Replace("'", "''") & "','" & txtAdd2.Text.Replace("'", "''") & "','" & cboCity.Text.Replace("'", "''") & "','" & txtPhoneO.Text.Replace("'", "''") & "','" _
                        & txtPhoneR.Text.Replace("'", "''") & "','" & txtCellphone1.Text & "','" & txtCellphone2.Text & "','" & txtEmail.Text & "')"


                    If ExecQuery(strQuery) = False Then Exit Sub
                    'to enter user details
                    If txtUserName.Text.Length <> 0 And txtPassword.Text.Length <> 0 Then
                        strQuery = "insert into tbl_HUser values('" & strCode & "','" & txtUserName.Text.Replace("'", "''") & "','" & txtPassword.Text.Replace("'", "''") & "')"
                        If ExecQuery(strQuery) = False Then Exit Sub
                    End If
                    MsgBox("New employee added successfully", MsgBoxStyle.Information, "Status")

                ElseIf lblMCode.Text <> 0 Then
                    strQuery = "Update tbl_Emp set " &
                                "EmpName = '" + txtEmpName.Text.Replace("'", "''") + "', " &
                                "DeptCode = '" + cboDept.Text.Replace("'", "''") + "', " &
                                "JobTitle = '" + txtJobTitle.Text.Replace("'", "''") + "', " &
                                "Add1 = '" + txtAdd1.Text.Replace("'", "''") + "', " &
                                "Add2 = '" + txtAdd2.Text.Replace("'", "''") + "', " &
                                "City = '" + cboCity.Text.Replace("'", "''") + "', " &
                                "TelO = '" + txtPhoneO.Text.Replace("'", "''") + "', " &
                                "TelR = '" + txtPhoneR.Text.Replace("'", "''") + "', " &
                                "CellPhone1 = '" + txtCellphone1.Text + "', " &
                                "CellPhone2 = '" + txtCellphone2.Text + "', " &
                                "EmailAdd = '" + txtEmail.Text + "' " &
                    "where EmpCode ='" + lblMCode.Text.Trim + "'"

                    If ExecQuery(strQuery) = False Then
                        Me.DialogResult = DialogResult.None
                        Exit Sub
                    End If

                    'update User Name Password
                    Call ExecQuery("Delete from tbl_HUser where UCode ='" & lblMCode.Text & "'")

                    strQuery = "insert into tbl_HUser values('" & lblMCode.Text & "','" & txtUserName.Text.Replace("'", "''") & "','" & txtPassword.Text.Replace("'", "''") & "')"

                    If ExecQuery(strQuery) = False Then
                        Me.DialogResult = DialogResult.None
                        Exit Sub
                    End If
                    MsgBox("Employee record updated successfully", MsgBoxStyle.Information, "Status")
                End If

                Call ClearTexts()
                Call FillEmpLV()
                lblMCode.Text = "0"
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


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Dim i As Integer = 0
            If lvEmp.Items.Count = 0 Then Exit Sub
            If lvEmp.SelectedItems.Count = 0 Then Exit Sub
            If MsgBox("Are you sure you want to delete selected employee?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = vbNo Then Exit Sub
            'checking registerd calls here

            strQuery = "Select Count(*) from tbl_CallGen where (ReceivedByEmpCode ='" & lvEmp.SelectedItems(0).Text & "' or AssignedEmpCode ='" & lvEmp.SelectedItems(0).Text & "') and CurrentStatus = 'Open' "
            i = GetTotalRecords(strQuery)
            If i <> 0 Then
                MsgBox("Service call has been assigned to selected employee, unable to delete!", MsgBoxStyle.Information, "Error")
                Exit Sub
            End If
            i = 0
            strQuery = "Select Count(*) from tbl_CallGen_F where EmpCode ='" & lvEmp.SelectedItems(0).Text & "'"
            i = GetTotalRecords(strQuery)
            If i <> 0 Then
                MsgBox("Service call has been assigned to selected employee, unable to delete!", MsgBoxStyle.Information, "Error")
                Exit Sub
            End If

            Call ExecQuery("Delete from tbl_HUser where UCode ='" & lblMCode.Text & "'")
            Call ExecQuery("Delete from tbl_Emp where EmpCode ='" & lvEmp.SelectedItems(0).Text & "'")
            Call FillEmpLV()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub lvEmp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            '        Call lvEmp_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Try
                If lvEmp.SelectedItems.Count < 1 Then Exit Sub
                lblMCode.Text = lvEmp.SelectedItems(0).Text
                strQuery = "Select * from tbl_Emp where EmpCode ='" & lblMCode.Text & "'"

                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader

                If readr.HasRows Then
                    While readr.Read
                        txtEmpName.Text = readr.Item("EmpName") & ""
                        If readr.Item("DeptCode") & "" = "" Then
                            cboDept.SelectedIndex = -1
                        Else
                            cboDept.Text = readr.Item("DeptCode") & ""
                        End If

                        txtJobTitle.Text = readr.Item("JobTitle") & ""
                        txtAdd1.Text = readr.Item("Add1") & ""
                        txtAdd2.Text = readr.Item("Add2") & ""
                        cboCity.Text = readr.Item("City") & ""
                        txtPhoneO.Text = readr.Item("TelO") & ""
                        txtPhoneR.Text = readr.Item("TelR") & ""
                        txtCellphone1.Text = readr.Item("CellPhone1") & ""
                        txtCellphone2.Text = readr.Item("CellPhone2") & ""
                        txtEmail.Text = readr.Item("EmailAdd") & ""

                    End While
                End If
                readr.Close()

                cmd.CommandText = "Select * from tbl_HUser where UCode ='" & lblMCode.Text & "'"
                readr = cmd.ExecuteReader
                If readr.HasRows Then
                    While readr.Read
                        txtUserName.Text = readr.Item("UName")
                        txtPassword.Text = readr.Item("UPassword")
                    End While
                End If

                readr.Close()

                cmd = Nothing

                TabControl1.SelectedTab = TabPage1
                txtEmpName.Focus()
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

    Private Sub lvEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvEmp.KeyDown
        '<EhHeader>
        Try
            '</EhHeader>
            If e.KeyCode = Keys.Delete Then Call btnDelete_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        '<EhHeader>
        Try
            '</EhHeader>
            If TabControl1.SelectedIndex = 0 Then btnSave.Visible = True Else btnSave.Visible = False
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvEmp_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvEmp.ColumnClick
        '<EhHeader>
        Try
            '</EhHeader>
            ' Get the new sorting column. 
            Dim new_sorting_column As ColumnHeader = lvEmp.Columns(e.Column)
            ' Figure out the new sorting order. 
            Dim sort_order As System.Windows.Forms.SortOrder
            If m_SortingColumn Is Nothing Then
                ' New column. Sort ascending. 
                sort_order = SortOrder.Ascending
            Else ' See if this is the same column. 
                If new_sorting_column.Equals(m_SortingColumn) Then
                    ' Same column. Switch the sort order. 
                    If m_SortingColumn.Text.StartsWith("> ") Then
                        sort_order = SortOrder.Descending
                    Else
                        sort_order = SortOrder.Ascending
                    End If
                Else
                    ' New column. Sort ascending. 
                    sort_order = SortOrder.Ascending
                End If
                ' Remove the old sort indicator. 
                m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
            End If
            ' Display the new sort order. 
            m_SortingColumn = new_sorting_column
            If sort_order = SortOrder.Ascending Then
                m_SortingColumn.Text = "> " & m_SortingColumn.Text
            Else
                m_SortingColumn.Text = "< " & m_SortingColumn.Text
            End If
            ' Create a comparer. 
            lvEmp.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
            ' Sort. 
            lvEmp.Sort()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtEmpName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpName.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtEmpName.Text = UppercaseFirstLetter(txtEmpName.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtJobTitle_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobTitle.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtJobTitle.Text = UppercaseFirstLetter(txtJobTitle.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtAdd1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdd1.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtAdd1.Text = UppercaseFirstLetter(txtAdd1.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtAdd2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdd2.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtAdd2.Text = UppercaseFirstLetter(txtAdd2.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
End Class
