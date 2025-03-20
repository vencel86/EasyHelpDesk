Public Class rptViewClosed

    Private Sub rptView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ClosedCalls.tbl_CallGen' table. You can move, or remove it, as needed.
        'Me.Tbl_CallGenTableAdapter1.Fill(Me.ClosedCalls.tbl_CallGen)
        'TODO: This line of code loads data into the 'ClosedCalls.tbl_CallGen' table. You can move, or remove it, as needed.
        'Me.Tbl_CallGenTableAdapter1.Fill(Me.ClosedCalls.tbl_CallGen)
        Try
            'TODO: This line of code loads data into the 'DataDataSet.tbl_CallGen' table. You can move, or remove it, as needed.
            Me.Tbl_CallGenTableAdapter1.Connection.ConnectionString = cnMain.ConnectionString.ToString
            Me.Tbl_CallGenTableAdapter1.Fill(Me.ClosedCalls.tbl_CallGen)
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