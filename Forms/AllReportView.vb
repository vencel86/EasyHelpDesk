Imports Microsoft.Reporting.WinForms
Imports System
Public Class MyReportViwer
    Public Property strRPTName

    Private Sub MyReportViwer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        '<EhHeader>
        Try
            '</EhHeader>
            If e.KeyCode = Keys.Escape Then Me.Close()
            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub


    Private Sub rptView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<EhHeader>
        Try
            '</EhHeader>

            'TODO: This line of code loads data into the 'DataDataSet.tbl_CallGen' table. You can move, or remove it, as needed.
            'Me.tbl_CallGenTableAdapter.Fill(Me.DataDataSet.tbl_CallGen)
            'TODO: This line of code loads data into the 'DataDataSet.tbl_CallGen' table. You can move, or remove it, as needed.
            'Me.tbl_CallGenTableAdapter.Fill(Me.DataDataSet.tbl_CallGen)
            Dim rptDataSource As New ReportDataSource

            'Me.Tbl_CallGenTableAdapter1.Fill(Me.TodaysCall.tbl_CallGen)


            Try
                'TODO: This line of code loads data into the 'DataDataSet.tbl_CallGen' table. You can move, or remove it, as needed.

                Select Case strRPTName
                    Case "EmpAll"
                        Dim ds As New EHD.dsEmpAll
                        Dim da As New EHD.dsEmpAllTableAdapters.tbl_CallGenTableAdapter

                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "EHD.EmpAll.rdlc"
                        Me.ReportViewer1.LocalReport.DataSources.Clear()
                        da.Connection.ConnectionString = cnMain.ConnectionString.ToString
                        da.Connection.Open()
                        da.Fill(ds.tbl_CallGen)
                        rptDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("Dataset1", ds.Tables("tbl_CallGen"))
                        Me.Text = "Employee List"
                    Case "EmpDetails"
                        Dim strQuery As String = ""
                        strQuery = "SELECT tbl_Emp.EmpName, tbl_Emp.DeptCode, tbl_Emp.JobTitle," & _
                                 "(SELECT COUNT(*) FROM(tbl_CallGen)" & _
                                   "WHERE tbl_Emp.EmpCode = tbl_CallGen.AssignCode AND tbl_CallGen.CurrentStatus = 'Open')," & _
                                 "(SELECT COUNT(*) FROM(tbl_CallGen)" & _
                                   "WHERE tbl_Emp.EmpCode = tbl_CallGen.AssignCode AND tbl_CallGen.CurrentStatus = 'On Hold')," & _
                                 "(SELECT COUNT(*) FROM(tbl_CallGen)" & _
                                   "WHERE tbl_Emp.EmpCode = tbl_CallGen.AssignCode AND tbl_CallGen.CurrentStatus = 'Awaiting Info')," & _
                                 "(SELECT COUNT(*) FROM(tbl_CallGen)" & _
                                   "WHERE tbl_Emp.EmpCode = tbl_CallGen.AssignCode AND tbl_CallGen.CurrentStatus = 'Awaiting Parts')," & _
                                 "(SELECT COUNT(*) FROM(tbl_CallGen)" & _
                                   "WHERE tbl_Emp.EmpCode = tbl_CallGen.AssignCode AND tbl_CallGen.CurrentStatus = 'Solved')" & _
                                    "FROM tbl_Emp"

                        'Debug.Print(lblQuery.Text)

                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "EHD.EmpDetails.rdlc"
                        Me.ReportViewer1.LocalReport.DataSources.Clear()

                        Dim myCommand As New System.Data.OleDb.OleDbCommand
                        Dim myAdapter As New Data.OleDb.OleDbDataAdapter
                        Dim dt As New DataTable


                        myCommand.Connection = cnMain
                        myCommand.CommandText = strQuery
                        myCommand.ExecuteNonQuery()
                        myAdapter.SelectCommand = myCommand

                        'Fill dataset with select query
                        myAdapter.Fill(dt)

                        rptDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("Dataset1", dt)

                        Me.Text = "Employee Details"
                    Case "InvAll"
                        Dim strQuery As String = ""
                        strQuery = "SELECT tbl_Inventory.EName, tbl_Inventory.EDesc," & _
                                 "(SELECT COUNT(*) FROM(tbl_CallGen) WHERE tbl_Inventory.MCode = tbl_CallGen.CallSCode AND tbl_CallGen.CurrentStatus = 'Open')," & _
                                 "(SELECT COUNT(*) FROM(tbl_CallGen) WHERE tbl_Inventory.MCode = tbl_CallGen.CallSCode AND tbl_CallGen.CurrentStatus = 'Awaiting Info')," & _
                                 "(SELECT COUNT(*) FROM(tbl_CallGen) WHERE tbl_Inventory.MCode = tbl_CallGen.CallSCode AND tbl_CallGen.CurrentStatus = 'Awaiting Parts')" & _
                                 "FROM tbl_Inventory"

                        'Debug.Print(lblQuery.Text)

                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "EHD.InventoryAll.rdlc"
                        Me.ReportViewer1.LocalReport.DataSources.Clear()

                        Dim myCommand As New System.Data.OleDb.OleDbCommand
                        Dim myAdapter As New Data.OleDb.OleDbDataAdapter
                        Dim dt As New DataTable


                        myCommand.Connection = cnMain
                        myCommand.CommandText = strQuery
                        myCommand.ExecuteNonQuery()
                        myAdapter.SelectCommand = myCommand

                        'Fill dataset with select query
                        myAdapter.Fill(dt)

                        rptDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("Dataset1", dt)
                        Me.Text = "Inventory List"
                    Case "CustAll"
                        Dim ds As New EHD.CustAll
                        Dim da As New EHD.CustAllTableAdapters.tbl_CallGenTableAdapter

                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "EHD.CustAll.rdlc"
                        Me.ReportViewer1.LocalReport.DataSources.Clear()
                        da.Connection.ConnectionString = cnMain.ConnectionString.ToString
                        da.Connection.Open()
                        da.Fill(ds.tbl_CallGen)



                        rptDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("Dataset1", ds.Tables("tbl_CallGen"))
                        Me.Text = "Customer List"
                    Case "Today"
                        Dim ds As New EHD.TodaysCall
                        Dim da As New EHD.TodaysCallTableAdapters.tbl_CallGenTableAdapter

                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "EHD.CallsToday.rdlc"
                        Me.ReportViewer1.LocalReport.DataSources.Clear()
                        da.Connection.ConnectionString = cnMain.ConnectionString.ToString
                        da.Connection.Open()
                        da.Fill(ds.tbl_CallGen)

                        rptDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("Dataset1", ds.Tables("tbl_CallGen"))

                        Me.Text = "Today's Call"
                    Case "Solved"
                        Dim ds As New EHD.ClosedCalls
                        Dim da As New EHD.ClosedCallsTableAdapters.tbl_CallGenTableAdapter


                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "EHD.CallsClosed.rdlc"
                        Me.ReportViewer1.LocalReport.DataSources.Clear()

                        da.Connection.ConnectionString = cnMain.ConnectionString.ToString
                        'da.Connection.Open()
                        da.Fill(ds.tbl_CallGen)


                        rptDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("ClosedCalls", ds.Tables("tbl_CallGen"))

                    Case "All"
                        Dim ds As New EHD.AllCalls
                        Dim da As New EHD.AllCallsTableAdapters.tbl_CallGenTableAdapter


                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "EHD.CallsAll.rdlc"
                        Me.ReportViewer1.LocalReport.DataSources.Clear()

                        da.Connection.ConnectionString = cnMain.ConnectionString.ToString
                        da.Connection.Open()
                        da.Fill(ds.tbl_CallGen)

                        rptDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("AllCalls", ds.Tables("tbl_CallGen"))
                        Me.Text = "All Calls"
                    Case ("Follow")
                        Dim ds As New EHD.AllCalls
                        Dim da As New EHD.AllCallsTableAdapters.tbl_CallGenTableAdapter


                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "EHD.rptFollowUp.rdlc"
                        Me.ReportViewer1.LocalReport.DataSources.Clear()

                        da.Connection.ConnectionString = cnMain.ConnectionString.ToString
                        da.Connection.Open()
                        da.Fill(ds.tbl_CallGen)

                        rptDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("ds_SingleCall", ds.Tables("tbl_CallGen"))

                        Me.Text = "Follow Up"
                    Case "Open"
                        Dim ds As New EHD.OpenCalls
                        Dim da As New EHD.OpenCallsTableAdapters.tbl_CallGenTableAdapter

                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "EHD.CallsOpen.rdlc"
                        Me.ReportViewer1.LocalReport.DataSources.Clear()

                        da.Connection.ConnectionString = cnMain.ConnectionString.ToString
                        da.Connection.Open()
                        da.Fill(ds.tbl_CallGen)

                        rptDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("DataDataSet", ds.Tables("tbl_CallGen"))

                        Me.Text = "Open Calls"
                    Case "Custom"
                        Dim strQuery As String = ""
                        'strQuery = "SELECT CallCode, RefNo, CustCode, CurrentStatus, Format(RecDate,'" & DTFormat & "') as RD, CallPriority, format(DuesOn,'" & DTFormat & "') as DD, AssignCode From tbl_CallGen where " & lblQuery.Text.ToString


                        '                    strQuery = " SELECT tbl_CallGen.CustCode, tbl_CallGen.RefNo, tbl_CallGen.CallDesc, tbl_CallGen.CallPriority, tbl_CallGen.RecDate, tbl_CallGen.RecEmpCode, tbl_CallGen.AssignCode, " & _
                        '   "tbl_CallGen.CurrentStatus, tbl_Cust.CustName, tbl_Emp.EmpName, tbl_CallGen.CallUnder, tbl_CType.CType, Format(tbl_CallGen.DuesOn, 'mm/dd/yyyy') AS Expr1, " & _
                        '"tbl_CallGen.CallCode, tbl_Ser.SName " & _
                        '"FROM ((((tbl_CallGen INNER JOIN " & _
                        ' "tbl_Cust ON tbl_CallGen.CustCode = tbl_Cust.CustCode) INNER JOIN " & _
                        '"tbl_Emp ON tbl_CallGen.RecEmpCode = tbl_Emp.EmpCode) INNER JOIN " & _
                        '"tbl_CType ON tbl_CallGen.CallUnder = tbl_CType.MCode) INNER JOIN " & _
                        '"tbl_Ser ON tbl_CallGen.CallSCode = tbl_Ser.MCode) " & _
                        '" Where " & lblQuery.Text.ToString & _
                        '" ORDER BY tbl_CallGen.RecDate, tbl_CallGen.RefNo"



                        strQuery = " SELECT tbl_CallGen.CustCode, tbl_CallGen.RefNo, tbl_CallGen.CallDesc, tbl_CallGen.CallPriority, tbl_CallGen.RecDate, tbl_CallGen.RecEmpCode, tbl_CallGen.AssignCode, " &
                            "tbl_CallGen.CurrentStatus, tbl_Cust.CustName, tbl_Emp.EmpName, tbl_CallGen.CallUnder, tbl_CallGen.CallUnder, Format(tbl_CallGen.DuesOn, 'mm/dd/yyyy') AS Expr1, " &
                      "tbl_CallGen.CallCode, tbl_Ser.SName " &
                     "FROM (((tbl_CallGen INNER JOIN " &
                         "tbl_Cust ON tbl_CallGen.CustCode = tbl_Cust.CustCode) Left JOIN " &
                        "tbl_Emp ON tbl_CallGen.RecEmpCode = tbl_Emp.EmpCode) Left JOIN " &
                        "tbl_Ser ON tbl_CallGen.CallSCode = tbl_Ser.MCode) " &
                      "Where " & lblQuery.Text.ToString &
                     " ORDER BY tbl_CallGen.RecDate, tbl_CallGen.RefNo"

                        'Debug.Print(lblQuery.Text)

                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "EHD.CallsCustom.rdlc"
                        Me.ReportViewer1.LocalReport.DataSources.Clear()

                        Dim myCommand As New System.Data.OleDb.OleDbCommand
                        Dim myAdapter As New Data.OleDb.OleDbDataAdapter
                        Dim dt As New DataTable


                        myCommand.Connection = cnMain
                        myCommand.CommandText = strQuery
                        myCommand.ExecuteNonQuery()
                        myAdapter.SelectCommand = myCommand

                        'Fill dataset with select query
                        myAdapter.Fill(dt)

                        rptDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("dsCustom", dt)

                        Me.Text = "Custom Report"
                    Case "Single"

                        Dim strQuery As String = ""

                        strQuery = "SELECT tbl_CallGen.RefNo From tbl_CallGen where tbl_CallGen.CallCode = '" & lblQuery.Text.ToString & "'"

                        Dim cmd As New OleDb.OleDbCommand("Select AssignCode from tbl_CallGen where CallCode = '" & lblQuery.Text & "'", cnMain)
                        'Dim cmd As New OleDb.OleDbCommand(strQuery, cnMain)
                        Dim readr As OleDb.OleDbDataReader = cmd.ExecuteReader

                        While readr.Read
                            If readr.IsDBNull(0) = False Or readr.Item(0).ToString.Trim.Length <> 0 Then
                                strQuery = "SELECT tbl_CallGen.CallCode, tbl_CallGen.RefNo, tbl_CallGen.CallFrom, tbl_CallGen.CustCode, tbl_CallGen.RecDate, tbl_CallGen.CallerName, tbl_CallGen.CallerContact, " & _
                            "tbl_CallGen.CallSCode, tbl_CallGen.CallUnder, tbl_CallGen.CallDesc, tbl_CallGen.CallPriority, tbl_CallGen.DuesOn, tbl_CallGen.CurrentStatus, " & _
                            "tbl_CallGen.RecEmpCode, tbl_CallGen.AssignCode, tbl_CallGen.CallRes, tbl_Cust.CustName, tbl_CFrom.CFrom, tbl_CType.CType, tbl_Ser.SName, R.EmpName as RecEmp " & _
                            "FROM (((((tbl_CallGen INNER JOIN " & _
                                 "tbl_Cust ON tbl_CallGen.CustCode = tbl_Cust.CustCode) INNER JOIN " & _
                                 "tbl_CFrom ON tbl_CallGen.CallFrom = tbl_CFrom.MCode) INNER JOIN " & _
                                 "tbl_CType ON tbl_CallGen.CallUnder = tbl_CType.MCode) INNER JOIN " & _
                                 "tbl_Ser ON tbl_CallGen.CallSCode = tbl_Ser.MCode) INNER JOIN " & _
                                  "tbl_Emp R ON tbl_CallGen.RecEmpCode = R.EmpCode)" & _
                             "where tbl_callGen.CallCode = '" & lblQuery.Text.ToString & "'"
                            Else
                                strQuery = "SELECT tbl_CallGen.CallCode, tbl_CallGen.RefNo, tbl_CallGen.CallFrom, tbl_CallGen.CustCode, tbl_CallGen.RecDate, tbl_CallGen.CallerName, tbl_CallGen.CallerContact, " & _
                        "tbl_CallGen.CallSCode, tbl_CallGen.CallUnder, tbl_CallGen.CallDesc, tbl_CallGen.CallPriority, tbl_CallGen.DuesOn, tbl_CallGen.CurrentStatus, " & _
                        "tbl_CallGen.RecEmpCode, tbl_CallGen.AssignCode, tbl_CallGen.CallRes, tbl_Cust.CustName, tbl_CFrom.CFrom, tbl_CType.CType, tbl_Ser.SName, R.EmpName as RecEmp, A.EmpName as AssignEmp " & _
                        "FROM ((((((tbl_CallGen INNER JOIN " & _
                             "tbl_Cust ON tbl_CallGen.CustCode = tbl_Cust.CustCode) INNER JOIN " & _
                             "tbl_CFrom ON tbl_CallGen.CallFrom = tbl_CFrom.MCode) INNER JOIN " & _
                             "tbl_CType ON tbl_CallGen.CallUnder = tbl_CType.MCode) INNER JOIN " & _
                             "tbl_Ser ON tbl_CallGen.CallSCode = tbl_Ser.MCode) INNER JOIN " & _
                             "tbl_Emp A ON tbl_CallGen.AssignCode = A.EmpCode) INNER JOIN " & _
                             "tbl_Emp R ON tbl_CallGen.RecEmpCode = R.EmpCode)" & _
                         "where tbl_callGen.CallCode = '" & lblQuery.Text.ToString & "'"
                            End If
                        End While

                        readr.Close()
                        readr = Nothing
                        cmd = Nothing

                        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "EHD.CallSWhole.rdlc"
                        Me.ReportViewer1.LocalReport.DataSources.Clear()

                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

                        Dim myCommand As New System.Data.OleDb.OleDbCommand
                        Dim myAdapter As New Data.OleDb.OleDbDataAdapter
                        Dim dt As New DataTable

                        myCommand.Connection = cnMain
                        myCommand.CommandText = strQuery
                        myCommand.ExecuteNonQuery()
                        myAdapter.SelectCommand = myCommand

                        'Fill dataset with select query
                        myAdapter.Fill(dt)

                        rptDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("ds_SingleCall", dt)

                        'Dim rptDataSource2 As New ReportDataSource
                        'rptDataSource2 = New Microsoft.Reporting.WinForms.ReportDataSource("ds_SingleCall", dt2)

                        Me.Text = "Single Report"


                End Select



                Me.ReportViewer1.LocalReport.DataSources.Add(rptDataSource)

                '//////////// FOR PARAMETER Company Name ///////////////////
                'Create a report parameter for the sales order number 
                PCompanyName = "SRT"
                Dim rp As New ReportParameter("RepParamCompName", PCompanyName)
                'Set the report parameters for the report
                Me.ReportViewer1.LocalReport.SetParameters(rp)
                '//////////// Ends Here ///////////////////


                'Me.ReportViewer1.LocalReport.Refresh()

                Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Me.Tbl_CallGenTableAdapter1.Connection.ConnectionString = cnMain.ConnectionString.ToString
                'Me.Tbl_CallGenTableAdapter1.Connection.Open()
                'Me.Tbl_CallGenTableAdapter1.Fill(Me.TodaysCall.tbl_CallGen)
                'Me.ReportViewer1.RefreshReport()
            End Try

            '<EhFooter>
        Catch ex As System.Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            AddLog("Error" + "-" + ex.Message + " Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "-" + ex.StackTrace.ToString, LogType.ErrorMessage)
            WriteLog()
        End Try '</EhFooter>
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        '<EhHeader>
        Try
            '</EhHeader>
            Try
                Dim strQuery2 As String = ""
                Dim myCommand2 As New System.Data.OleDb.OleDbCommand
                Dim myAdapter2 As New Data.OleDb.OleDbDataAdapter
                Dim dt2 As New DataTable

                'strQuery2 = "Select FDate,ActionDone,FCode from tbl_CallGen_F where FCode = '" & lblQuery.Text & "'"
                strQuery2 = "SELECT tbl_Emp.EmpName, tbl_CallGen_F.FDate, tbl_CallGen_F.ActionDone " & _
                            "FROM (tbl_Emp INNER JOIN " & _
                             "tbl_CallGen_F ON tbl_Emp.EmpCode = tbl_CallGen_F.EmpCode) " & _
                             "where tbl_CallGen_F.FCode= '" & lblQuery.Text & "'"

                myCommand2.Connection = cnMain
                myCommand2.CommandText = strQuery2
                myCommand2.ExecuteNonQuery()
                myAdapter2.SelectCommand = myCommand2
                myAdapter2.Fill(dt2)

                e.DataSources.Add(New ReportDataSource("ds_SingleCall", dt2))

            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
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