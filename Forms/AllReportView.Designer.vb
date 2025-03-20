<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyReportViwer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MyReportViwer))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.lblQuery = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Nothing
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "JHD.rptClosedCalls.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(467, 310)
        Me.ReportViewer1.TabIndex = 0
        '
        'lblQuery
        '
        Me.lblQuery.AutoSize = True
        Me.lblQuery.Location = New System.Drawing.Point(0, 0)
        Me.lblQuery.Name = "lblQuery"
        Me.lblQuery.Size = New System.Drawing.Size(39, 13)
        Me.lblQuery.TabIndex = 1
        Me.lblQuery.Text = "Label1"
        Me.lblQuery.Visible = False
        '
        'MyReportViwer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 310)
        Me.Controls.Add(Me.lblQuery)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "MyReportViwer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Today's Calls"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TodaysCallBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents TblCallGenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TodaysCallBindingSource2 As System.Windows.Forms.BindingSource
    Public WithEvents Tbl_CallGenTableAdapter1 As EHD.TodaysCallTableAdapters.tbl_CallGenTableAdapter
    'Friend WithEvents tbl_CallGenTableAdapter As EHD.DataDataSetTableAdapters.tbl_CallGenTableAdapter
    Friend WithEvents tbl_CallGenTableAdapter As EHD.dsCustom.tbl_CallGenDataTable
    Public WithEvents lblQuery As System.Windows.Forms.Label
End Class
