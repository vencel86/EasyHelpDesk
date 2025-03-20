<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptView
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.tbl_CallGenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataDataSet = New JHD.DataDataSet()
        Me.DataDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbl_CallGenTableAdapter = New JHD.DataDataSetTableAdapters.tbl_CallGenTableAdapter()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.tbl_CallGenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbl_CallGenBindingSource
        '
        Me.tbl_CallGenBindingSource.DataMember = "tbl_CallGen"
        Me.tbl_CallGenBindingSource.DataSource = Me.DataDataSet
        '
        'DataDataSet
        '
        Me.DataDataSet.DataSetName = "DataDataSet"
        Me.DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataDataSetBindingSource
        '
        Me.DataDataSetBindingSource.DataSource = Me.DataDataSet
        Me.DataDataSetBindingSource.Position = 0
        '
        'tbl_CallGenTableAdapter
        '
        Me.tbl_CallGenTableAdapter.ClearBeforeFill = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.tbl_CallGenBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "JHD.rptOpenCalls.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(477, 240)
        Me.ReportViewer1.TabIndex = 0
        '
        'rptView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 240)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "rptView"
        Me.Text = "View Open Calls"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tbl_CallGenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataDataSet As JHD.DataDataSet
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Public WithEvents tbl_CallGenBindingSource As System.Windows.Forms.BindingSource
    Public WithEvents tbl_CallGenTableAdapter As JHD.DataDataSetTableAdapters.tbl_CallGenTableAdapter
    Public WithEvents DataDataSetBindingSource As System.Windows.Forms.BindingSource
End Class
