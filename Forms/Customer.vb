Imports System.Windows.Forms

Public Class Customer
    Private m_SortingColumn As ColumnHeader

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Try

                If txtName.Text.Length = 0 Then
                    MsgBox("Please input customer name!", MsgBoxStyle.Information, "Error")
                    txtName.Focus()
                    Exit Sub
                End If
                If cboSaluatation.Text = String.Empty Then
                    MsgBox("Please select salutation!", MsgBoxStyle.Information, "Error")
                    cboSaluatation.Focus()
                    Exit Sub
                End If
                Dim strCode As String = ""
                Dim strQuery As String = ""
                Dim strFromD As String = ""
                Dim strTOD As String = ""

                If lblMCode.Text = "0" Then

                    strCode = TRCode("Select max(cint(CustCode)) from tbl_Cust")

                    strQuery = "insert into tbl_cust values('" & strCode & "','" & cboSaluatation.Text & "','" & txtName.Text.Replace("'", "''") & "','" & txtAlias.Text.Replace("'", "''") & "','" _
                        & txtAdd1.Text.Replace("'", "''") & "','" & txtAdd2.Text.Replace("'", "''") & "','" & txtLandmark.Text.Replace("'", "''") & "','" & txtArea.Text.Replace("'", "''") & "','" & cboCity.Text.Replace("'", "''") & "','" _
                        & cboState.Text.Replace("'", "''") & "','" & txtPostalCode.Text & "','" & cboCountry.Text.Replace("'", "''") & "','" & txtPhoneO.Text & "','" _
                        & txtPhoneR.Text & "','" & txtFax.Text & "','" & txtCellphone.Text & "','" & txtEmail.Text & "'," _
                        & IIf(chkBlackList.Checked = True, 1, 0) & ",'" & IIf(rbAMC.Checked = True, "A", "W") & "','" & dtpAMCFrom.Value & "','" & dtpAMCFrom.Value.AddYears(1) & "')"
                    If ExecQuery(strQuery) = False Then Exit Sub
                    If lvInventory.Items.Count <> 0 Then
                        Dim strFCode As String = ""
                        For i = 0 To lvInventory.Items.Count - 1
                            strFCode = TRCode("Select max(cint(MCode)) from tbl_CustInventory")
                            strFromD = lvInventory.Items(i).SubItems(3).Text
                            strTOD = lvInventory.Items(i).SubItems(4).Text
                            If strFromD.Length = 0 Then
                                strFromD = "10/10/1910"
                            End If
                            If strTOD.Length = 0 Then
                                strTOD = "10/10/1910"
                            End If

                            strQuery = "insert into tbl_CustInventory values('" & strFCode & "','" & strCode & "','" _
                    & lvInventory.Items(i).SubItems(1).Text & "','" & lvInventory.Items(i).SubItems(2).Text & "',#" & DateTime.Parse(strFromD).ToString("MM/dd/yyyy") & "#,#" & DateTime.Parse(strTOD).ToString("MM/dd/yyyy") & "#)"
                            Call ExecQuery(strQuery)
                        Next
                    End If


                    MsgBox("New customer added successfully", MsgBoxStyle.Information, "Status")
                    'call clearForm

                ElseIf lblMCode.Text <> 0 Then
                    strQuery = "Update tbl_Cust set " &
                                "Salutation = '" + cboSaluatation.Text + "', " &
                                "CustName = '" + txtName.Text.Replace("'", "''") + "', " &
                                "Alias = '" + txtAlias.Text.Replace("'", "''") + "', " &
                                "Add1 = '" + txtAdd1.Text.Replace("'", "''") + "', " &
                                "Add2 = '" + txtAdd2.Text.Replace("'", "''") + "', " &
                                "Landmark = '" + txtLandmark.Text.Replace("'", "''") + "', " &
                                "Area = '" + txtArea.Text.Replace("'", "''") + "', " &
                                "City = '" + cboCity.Text.Replace("'", "''") + "', " &
                                "State = '" + cboState.Text.Replace("'", "''") + "', " &
                                "PostalCode = '" + txtPostalCode.Text.Replace("'", "''") + "', " &
                                "Country = '" + cboCountry.Text.Replace("'", "''") + "', " &
                                "TelO = '" + txtPhoneO.Text + "', " &
                                "TelR = '" + txtPhoneR.Text + "', " &
                                "Fax = '" + txtFax.Text + "', " &
                                "Cellphone = '" + txtCellphone.Text + "', " &
                                "Email = '" + txtEmail.Text + "', " &
                                "BlackList = '" + IIf(chkBlackList.Checked = True, 1, 0).ToString + "', " &
                                "AMCType = '" + IIf(rbAMC.Checked = True, "A", "W") + "', " &
                                "AMCFromDate = '" + dtpAMCFrom.Value + "', " &
                                "AMCEndDate = '" + dtpAMCFrom.Value.AddYears(1) + "' " &
                                "where CustCode ='" + lblMCode.Text.Trim + "'"

                    If ExecQuery(strQuery) = False Then Exit Sub

                    If lvInventory.Items.Count <> 0 Then
                        Dim strFCode As String = ""
                        strQuery = "Delete from tbl_CustINventory where FCode ='" + lblMCode.Text.Trim & "'"
                        Call ExecQuery(strQuery)

                        For i = 0 To lvInventory.Items.Count - 1
                            strFromD = lvInventory.Items(i).SubItems(3).Text
                            strTOD = lvInventory.Items(i).SubItems(4).Text

                            If strFromD.Length = 0 Then
                                strFromD = "10/10/1910"
                            End If
                            If strTOD.Length = 0 Then
                                strTOD = "10/10/1910"
                            End If


                            strFCode = TRCode("Select max(CInt(MCode)) from tbl_CustInventory")
                            strQuery = "insert into tbl_CustInventory values('" & strFCode & "','" & lblMCode.Text & "','" _
                            & lvInventory.Items(i).SubItems(1).Text & "','" & lvInventory.Items(i).SubItems(2).Text & "',#" & DateTime.Parse(strFromD).ToString("MM/dd/yyyy") & "#,#" & DateTime.Parse(strTOD).ToString("MM/dd/yyyy") & "#)"
                            Call ExecQuery(strQuery)

                        Next
                    End If

                    MsgBox("Customer updated successfully", MsgBoxStyle.Information, "Status")

                End If
                FillCustView()
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'Me.Close()

                Call ClearCust()
                lblMCode.Text = "0"
                cboSaluatation.Focus()
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


    Private Sub FillCustView()
        '<EhHeader>
        Try
            '</EhHeader>
            Try


                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Cust order by CustName", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                lvCustView.Items.Clear()

                If readr.HasRows Then
                    While readr.Read
                        With lvCustView.Items.Add(readr.Item("CustCode").ToString)
                            .SubItems.Add(readr.Item("CustName").ToString)
                            .SubItems.Add(readr.Item("TelR").ToString)
                            .SubItems.Add(readr.Item("TelO").ToString)
                            .SubItems.Add(readr.Item("Cellphone").ToString)
                        End With
                    End While
                End If
                If lvCustView.Items.Count <> 0 Then lvCustView.Items(0).Selected = True

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


    Private Sub Customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<EhHeader>
        Try
            '</EhHeader>
            dtpAMCFrom.CustomFormat = DTFormat
            dtpAMCTo.CustomFormat = DTFormat
            Call FillCustView()
            'cboSaluatation.Focus()
            'Call FillCountries()

            TabControl1.SelectedTab = TabPage2
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillCountries()
        '<EhHeader>
        Try
            '</EhHeader>
            Try

                Dim ds As New DataSet()
                Dim adapter As New OleDb.OleDbDataAdapter()
                Dim command As OleDb.OleDbCommand


                'If cboCountry.Text.Length = 0 Then Exit Sub
                'If cboCountry.SelectedValue.ToString.Length = 0 Then Exit Sub

                Dim strSQL As String = "Select * from tbl_CC order by CountryName"

                command = New OleDb.OleDbCommand(strSQL, cnMain)
                adapter.SelectCommand = command
                adapter.Fill(ds)

                cboCountry.DataSource = ds.Tables(0)
                cboCountry.ValueMember = "CountryCode"
                cboCountry.DisplayMember = "CountryName"

                cboCountry.SelectedIndex = -1
                adapter.Dispose()
                command.Dispose()

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
    Private Sub ClearCust()
        '<EhHeader>
        Try
            '</EhHeader>
            cboSaluatation.Text = "Mr."
            txtName.Clear()
            txtAdd1.Clear()
            txtAdd2.Clear()
            txtLandmark.Clear()
            txtArea.Clear()
            cboCity.SelectedIndex = -1
            txtPostalCode.Clear()
            cboState.SelectedIndex = -1
            cboCountry.SelectedIndex = -1
            txtPhoneO.Clear()
            txtPhoneR.Clear()
            txtFax.Clear()
            txtCellphone.Clear()
            txtEmail.Clear()
            lvInventory.Items.Clear()
            rbAMC.Checked = False
            rbWarranty.Checked = False
            txtName.Focus()
            chkBlackList.Checked = False
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
            Call ClearCust()
            TabControl1.SelectedTab = TabPage1
            txtName.Focus()
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
            '   Try
            If lvCustView.SelectedItems.Count < 1 Then Exit Sub
            lblMCode.Text = lvCustView.SelectedItems(0).Text
            strQuery = "Select * from tbl_Cust where CustCode ='" & lblMCode.Text & "'"

            If cnMain.State = ConnectionState.Closed Then cnMain.Open()
            Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
            Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader

            If readr.HasRows Then
                While readr.Read
                    cboSaluatation.Text = readr.Item("Salutation") & ""
                    txtName.Text = readr.Item("CustName")
                    txtAlias.Text = readr.Item("Alias")
                    txtAdd1.Text = readr.Item("Add1") & ""
                    txtAdd2.Text = readr.Item("Add2") & ""
                    txtLandmark.Text = readr.Item("Landmark") & ""
                    txtArea.Text = readr.Item("Area") & ""
                    cboCity.Text = readr.Item("City") & ""
                    txtPostalCode.Text = readr.Item("PostalCode") & ""
                    cboState.Text = readr.Item("State") & ""
                    cboCountry.Text = readr.Item("Country") & ""
                    txtPhoneO.Text = readr.Item("TelO") & ""
                    txtPhoneR.Text = readr.Item("TelR") & ""
                    txtFax.Text = readr.Item("Fax") & ""
                    txtCellphone.Text = readr.Item("Cellphone") & ""
                    txtEmail.Text = readr.Item("Email") & ""
                    chkBlackList.Checked = readr.Item("Blacklist") & ""
                    If readr.Item("AMCType").ToString = "A" Then
                        rbAMC.Checked = True
                        dtpAMCFrom.Enabled = True
                        dtpAMCFrom.Value = readr.Item("AMCFromDate") & ""
                        dtpAMCTo.Value = readr.Item("AMCEndDate") & ""
                    ElseIf readr.Item("AMCType").ToString = "W" Then
                        rbWarranty.Checked = True
                        dtpAMCFrom.Enabled = True
                        dtpAMCFrom.Value = readr.Item("AMCFromDate") & ""
                        dtpAMCTo.Value = readr.Item("AMCEndDate") & ""
                    Else
                        rbAMC.Checked = False
                        rbWarranty.Checked = False
                        dtpAMCFrom.Enabled = False
                    End If

                End While
            End If
            readr.Close()

            Dim strTMp As String = ""
            cmd.CommandText = "Select * from tbl_CustInventory where FCode ='" & lblMCode.Text & "'"
            readr = cmd.ExecuteReader
            lvInventory.Items.Clear()
            If readr.HasRows Then
                While readr.Read
                    With lvInventory.Items.Add("0")
                        'strTMp = GetTextFromCode("MCode", readr.Item("CodeInvent").ToString, "EName", "tbl_Inventory")
                        'If strTMp <> "0" Then
                        '.SubItems.Add(strTMp).Tag = readr.Item("CodeInvent").ToString
                        'Else
                        .SubItems.Add(readr.Item("CodeInvent").ToString)
                        'End If

                        'strTMp = GetTextFromCode("MCode", readr.Item("CodeCType").ToString, "CType", "tbl_CType")
                        'If strTMp <> "0" Then
                        '.SubItems.Add(strTMp).Tag = readr.Item("CodeCType").ToString
                        'Else
                        .SubItems.Add(readr.Item("CodeCType").ToString)
                        ' End If
                        strTMp = Convert.ToDateTime(readr.Item("CFrom").ToString).ToString(DTFormat)
                        If strTMp <> "10/10/1910" Then
                            .SubItems.Add(strTMp)
                        Else
                            .SubItems.Add("")
                        End If

                        strTMp = Convert.ToDateTime(readr.Item("CTo").ToString).ToString(DTFormat)
                        If strTMp <> "10/10/1910" Then
                            .SubItems.Add(strTMp)
                        Else
                            .SubItems.Add("")
                        End If
                    End With
                End While
            End If
            readr.Close()
            cmd = Nothing

            TabControl1.SelectedTab = TabPage1
            txtName.Focus()
            ' Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            'End Try

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvCustView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCustView.DoubleClick
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

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim i As Integer = 0

            If MsgBox("Are you sure you want to delete selected customer?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = vbNo Then Exit Sub
            'checking customer with call in progress
            i = GetTotalRecords("Select * from tbl_CallGen where CustCode = '" + lvCustView.SelectedItems(0).Text + "'and CurrentStatus = 'Open'")
            If i <> 0 Then
                MsgBox("Selected customer have open call in progress, unable to delete!", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                Call ExecQuery("Delete from tbl_CallGen where CustCode ='" & lvCustView.SelectedItems(0).Text & "'")
            End If
            i = 0
            'check AMC/Warrenty present
            i = GetTotalRecords("Select * from tbl_AMC where CustCode = '" + lvCustView.SelectedItems(0).Text + "' and AMCTo >#" + Now + "#")
            If i <> 0 Then
                MsgBox("Selected customer have assigned AMC, unable to delete!", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                Call ExecQuery("Delete from tbl_AMCDet where AMCFCode in (select AMCCode from tbl_AMC where CustCode='" + lvCustView.SelectedItems(0).Text + "')")
                Call ExecQuery("Delete from tbl_AMC where CustCode ='" & lvCustView.SelectedItems(0).Text & "'")
            End If


            'checking registerd calls here
            Call ExecQuery("Delete from tbl_cust where CustCode ='" & lvCustView.SelectedItems(0).Text & "'")
            Call FillCustView()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvCustView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCustView.KeyDown
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
            If TabControl1.SelectedIndex = 0 Then OK_Button.Visible = True Else OK_Button.Visible = False
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvCustView_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCustView.ColumnClick
        '<EhHeader>
        Try
            '</EhHeader>
            ' Get the new sorting column. 
            Dim new_sorting_column As ColumnHeader = lvCustView.Columns(e.Column)
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
            lvCustView.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
            ' Sort. 
            lvCustView.Sort()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub btnIAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIAdd.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Try

                Dim formFUp As New CustInventory
                If formFUp.ShowDialog() = DialogResult.OK Then
                    Dim strVal() As String = formFUp.MyValue.Split(New Char() {"|"c})
                    Dim strTMp As String = ""
                    'MsgBox(strVal(0))
                    'Exit Sub
                    'strTmp = GetTextFromCode("CustCode", readr.Item("CustCode").ToString, "CustName", "tbl_Cust")
                    With lvInventory.Items.Add("0")


                        .SubItems.Add(strVal(0))

                        If strVal(1) = "A" Then
                            .SubItems.Add("AMC")
                        Else
                            .SubItems.Add("Warranty")
                        End If
                        If strVal(2) <> "0" Then
                            .SubItems.Add(strVal(2))

                        Else
                            .SubItems.Add("")
                        End If
                        If strVal(3) <> "0" Then
                            .SubItems.Add(strVal(3))
                        Else
                            .SubItems.Add("")
                        End If
                        .Tag = strVal(1)
                    End With
                End If
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

    Private Sub btnIEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIEdit.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim CurRow As Integer = 0
            If lvInventory.Items.Count = 0 Then Exit Sub
            If lvInventory.SelectedItems.Count = 0 Then Exit Sub
            CurRow = lvInventory.SelectedItems(0).Index

            Dim formFUp As New CustInventory
            formFUp.MyValue = lvInventory.SelectedItems.Item(0).SubItems(1).Text + "|" + lvInventory.SelectedItems.Item(0).SubItems(2).Text + "|" + lvInventory.SelectedItems.Item(0).SubItems(3).Text + "|" + lvInventory.SelectedItems.Item(0).SubItems(4).Text
            If formFUp.ShowDialog() = DialogResult.OK Then


                Dim strVal() As String = formFUp.MyValue.Split(New Char() {"|"c})
                Dim strTmp As String = ""

                lvInventory.Items(CurRow).SubItems(0).Text = "0"

                '  lvInventory.Items(CurRow).SubItems(1).Text = (strVal(0))



                If strVal(0) <> "0" Then
                    strTmp = GetTextFromCode("MCode", strVal(0), "EName", "tbl_Inventory")
                    lvInventory.Items(CurRow).SubItems(1).Text = strTmp
                    lvInventory.Items(CurRow).SubItems(1).Tag = strVal(0)
                Else
                    lvInventory.Items(CurRow).SubItems(1).Text = ""
                End If
                'Exit Sub
                If strVal(1) <> "0" Then
                    strTmp = GetTextFromCode("MCode", strVal(1), "CType", "tbl_CType")
                    lvInventory.Items(CurRow).SubItems(2).Text = strTmp
                    lvInventory.Items(CurRow).SubItems(2).Tag = strVal(1)
                Else
                    lvInventory.Items(CurRow).SubItems(2).Text = ""
                End If
                If strVal(2) <> "0" Then
                    lvInventory.Items(CurRow).SubItems(3).Text = strVal(2)

                Else
                    lvInventory.Items(CurRow).SubItems(3).Text = ""
                End If
                If strVal(3) <> "0" Then
                    lvInventory.Items(CurRow).SubItems(4).Text = strVal(3)
                Else
                    lvInventory.Items(CurRow).SubItems(4).Text = ""
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

    Private Sub txtName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtName.Text = UppercaseFirstLetter(txtName.Text)
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

    Private Sub txtLandmark_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLandmark.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtLandmark.Text = UppercaseFirstLetter(txtLandmark.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtArea_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArea.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtArea.Text = UppercaseFirstLetter(txtArea.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtCity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCity.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            cboCity.Text = UppercaseFirstLetter(cboCity.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtState_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboState.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            cboState.Text = UppercaseFirstLetter(cboState.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtCountry_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCountry.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            cboCountry.Text = UppercaseFirstLetter(cboCountry.Text)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub



    Private Sub cboCountry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCountry.SelectedIndexChanged
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim ds As New DataSet()
                Dim adapter As New OleDb.OleDbDataAdapter()
                Dim command As OleDb.OleDbCommand

                If cboCountry.Text.Length = 0 Then cboState.SelectedIndex = -1
                If cboCountry.Text.Length = 0 Then Exit Sub


                If cboCountry.SelectedValue.ToString.Length > 2 Or cboCountry.SelectedValue.ToString.Length = 0 Then Exit Sub

                Dim strSQL As String = "Select * from tbl_CS where SUCountry= '" + cboCountry.SelectedValue.ToString + "'"


                command = New OleDb.OleDbCommand(strSQL, cnMain)
                adapter.SelectCommand = command
                adapter.Fill(ds)

                cboState.DataSource = ds.Tables(0)

                cboState.ValueMember = "SUCode"
                cboState.DisplayMember = "SUName"
                adapter.Dispose()
                command.Dispose()



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

    Private Sub cboState_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboState.SelectedIndexChanged
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim ds As New DataSet()
                Dim adapter As New OleDb.OleDbDataAdapter()
                Dim command As OleDb.OleDbCommand

                If cboState.Text.Length = 0 Then cboCity.SelectedIndex = -1
                If cboState.Text.Length = 0 Then Exit Sub


                'If cboState.SelectedValue.ToString.Length > 2 Or cboState.SelectedValue.ToString.Length = 0 Then Exit Sub

                Dim strSQL As String = "Select * from tbl_CCD where SubDivision='" + cboState.SelectedValue.ToString + "' and Country = '" + cboCountry.SelectedValue.ToString + "'"


                command = New OleDb.OleDbCommand(strSQL, cnMain)
                adapter.SelectCommand = command
                adapter.Fill(ds)

                cboCity.DataSource = ds.Tables(0)

                cboCity.ValueMember = "CCD"
                cboCity.DisplayMember = "Name"
                adapter.Dispose()
                command.Dispose()


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

    Private Sub rbAMC_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbAMC.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            dtpAMCFrom.Enabled = True
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub rbWarranty_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbWarranty.CheckedChanged
        '<EhHeader>
        Try
            '</EhHeader>
            dtpAMCFrom.Enabled = True
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub dtpAMCFrom_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dtpAMCFrom.ValueChanged
        '<EhHeader>
        Try
            '</EhHeader>
            dtpAMCTo.Value = dtpAMCFrom.Value.AddYears(1)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
End Class
