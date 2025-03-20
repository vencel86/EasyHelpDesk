Public Class rptView

    Private Sub rptView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'DataDataSet.tbl_CallGen' table. You can move, or remove it, as needed.
            Me.tbl_CallGenTableAdapter.Connection.ConnectionString = cnMain.ConnectionString.ToString
            Me.tbl_CallGenTableAdapter.Fill(Me.DataDataSet.tbl_CallGen)

            Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ReportViewer1.Reset()
        'ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportViewer.Report2.rdlc"
        'Me.ReportViewer1.RefreshReport()
    End Sub

    
End Class