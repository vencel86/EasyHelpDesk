Imports System.Windows.Forms

Public Class Inventory
    Private m_SortingColumn As ColumnHeader

    Private Sub Inventory_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '<EhHeader>
        Try
            '</EhHeader>
            txtServiceName.Focus()
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
            Try
                FillServiceLV()

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
    Private Sub ClearTexts()
        '<EhHeader>
        Try
            '</EhHeader>
            'txtSerRes.Clear()
            txtServiceName.Clear()
            txtSerDesc.Clear()
            lblMCode.Text = "0"

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Private Sub FillServiceLV()
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand("Select * from tbl_Inventory", cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader
                lvService.Items.Clear()

                If readr.HasRows Then
                    While readr.Read
                        With lvService.Items.Add(readr.Item("MCode").ToString)
                            .SubItems.Add(readr.Item("EName").ToString)
                            .SubItems.Add(readr.Item("EDesc").ToString)
                            '.SubItems.Add(readr.Item("SDesc").ToString)
                            '.SubItems.Add(readr.Item("SRes").ToString)
                        End With
                    End While
                End If
                'If lvService.Items.Count <> 0 Then lvService.Items(lvService.Items.Count - 1).Selected = True
                readr.Close()
                cmd = Nothing
                If lvService.Items.Count <> 0 Then lvService.Items(0).Selected = True
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



    Private Sub lvEmp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvService.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Dim strQuery As String = ""
            Try

                If lvService.SelectedItems.Count < 1 Then Exit Sub
                lblMCode.Text = lvService.SelectedItems(0).Text
                strQuery = "Select * from tbl_Inventory where MCode ='" & lblMCode.Text & "'"

                If cnMain.State = ConnectionState.Closed Then cnMain.Open()
                Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader

                If readr.HasRows Then
                    While readr.Read
                        txtServiceName.Text = readr.Item("EName") & ""
                        txtSerDesc.Text = readr.Item("EDesc") & ""
                        'txtSerRes.Text = readr.Item("SRes") & ""
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

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
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


    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        '<EhHeader>
        Try
            '</EhHeader>
            Call ClearTexts()
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

                If txtServiceName.Text.Length = 0 Then
                    MsgBox("Please Provide Product/Service name!", MsgBoxStyle.Information, "Error")
                    txtServiceName.Focus()
                    Exit Sub
                End If

                If lblMCode.Text = "0" Then

                    strCode = TRCode("Select max(cint(MCode)) from tbl_Inventory")

                    strQuery = "insert into tbl_Inventory values('" & strCode & "','" & txtServiceName.Text.Replace("'", "''") & "','" & txtSerDesc.Text.Replace("'", "''") & "')"


                    If ExecQuery(strQuery) = False Then Exit Sub

                    MsgBox("New inventory added successfully", MsgBoxStyle.Information, "Status")

                ElseIf lblMCode.Text <> 0 Then
                    strQuery = "Update tbl_Inventory set " & _
                    "EName = '" + txtServiceName.Text.Replace("'", "''") + "', " & _
                                "EDesc = '" + txtSerDesc.Text.Replace("'", "''") + "' " & _
                                         "where MCode ='" + lblMCode.Text.Trim + "'"

                    If ExecQuery(strQuery) = False Then Exit Sub

                    MsgBox("Inventory updated successfully", MsgBoxStyle.Information, "Status")

                End If
                Call ClearTexts()
                Call FillServiceLV()
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

            If lvService.Items.Count = 0 Then Exit Sub
            If lvService.SelectedItems.Count = 0 Then Exit Sub
            If MsgBox("Are you sure you want to delete selected service?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = vbNo Then Exit Sub
            'checking registerd calls here

            strQuery = "Select Count(*) from tbl_CallGen where CallSCode ='" & lvService.SelectedItems(0).Text.Trim & "' "
            i = GetTotalRecords(strQuery)
            If i <> 0 Then
                MsgBox("Service call has been assigned to selected service, unable to delete!", MsgBoxStyle.Information, "Error")
                Exit Sub
            End If
            i = 0

            Call ExecQuery("Delete from tbl_Inventory where MCode ='" & lvService.SelectedItems(0).Text & "'")
            txtSerDesc.Clear()
            txtServiceName.Clear()
            lblMCode.Text = "0"

            Call FillServiceLV()
            lvService.Select()

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvService_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvService.ColumnClick
        '<EhHeader>
        Try
            '</EhHeader>
            ' Get the new sorting column. 
            Dim new_sorting_column As ColumnHeader = lvService.Columns(e.Column)
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
            lvService.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
            ' Sort. 
            lvService.Sort()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub lvService_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvService.SelectedIndexChanged
        '<EhHeader>
        Try
            '</EhHeader>
            lvEmp_Click(sender, e)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub

    Private Sub txtServiceName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceName.Leave
        '<EhHeader>
        Try
            '</EhHeader>
            txtServiceName.Text = StrConv(txtServiceName.Text, vbProperCase)
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
End Class
