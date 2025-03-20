<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptViewAll
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
        Me.AllCalls = New JHD.AllCalls()
        Me.DataDataSet = New JHD.DataDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Tbl_CallGenTableAdapter1 = New JHD.AllCallsTableAdapters.tbl_CallGenTableAdapter()
        CType(Me.tbl_CallGenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllCalls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbl_CallGenBindingSource
        '
        Me.tbl_CallGenBindingSource.DataMember = "tbl_CallGen"
        Me.tbl_CallGenBindingSource.DataSource = Me.AllCalls
        '
        'AllCalls
        '
        Me.AllCalls.DataSetName = "AllCalls"
        Me.AllCalls.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataDataSet
        '
        Me.DataDataSet.DataSetName = "DataDataSet"
        Me.DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.tbl_CallGenBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "JHD.AllCalls.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(812, 430)
        Me.ReportViewer1.TabIndex = 0
        '
        'Tbl_CallGenTableAdapter1
        '
        Me.Tbl_CallGenTableAdapter1.ClearBeforeFill = True
        '
        'rptViewAll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 440)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "rptViewAll"
        Me.Text = "View All Calls"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tbl_CallGenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllCalls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataDataSet As JHD.DataDataSet
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Public WithEvents tbl_CallGenBindingSource As System.Windows.Forms.BindingSource
    Public WithEvents AllCalls As JHD.AllCalls
    Public WithEvents Tbl_CallGenTableAdapter1 As JHD.AllCallsTableAdapters.tbl_CallGenTableAdapter
End Class
