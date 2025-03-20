<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStandBy
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
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboCustCode = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRecDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCust = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboPrdSer = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCallDesc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboAssignEmp = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 91)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(82, 13)
        Me.Label19.TabIndex = 257
        Me.Label19.Text = "Customer Code:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCustCode
        '
        Me.cboCustCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustCode.FormattingEnabled = True
        Me.cboCustCode.Location = New System.Drawing.Point(119, 89)
        Me.cboCustCode.Name = "cboCustCode"
        Me.cboCustCode.Size = New System.Drawing.Size(98, 21)
        Me.cboCustCode.TabIndex = 256
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(170, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 255
        Me.Label6.Text = "Received Date:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecDate
        '
        Me.txtRecDate.CalendarMonthBackground = System.Drawing.Color.White
        Me.txtRecDate.CustomFormat = "MM/dd/yyyy - hh:mm tt"
        Me.txtRecDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtRecDate.Location = New System.Drawing.Point(258, 12)
        Me.txtRecDate.Name = "txtRecDate"
        Me.txtRecDate.Size = New System.Drawing.Size(159, 20)
        Me.txtRecDate.TabIndex = 252
        Me.txtRecDate.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 254
        Me.Label1.Text = "Customer Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCust
        '
        Me.cboCust.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCust.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCust.FormattingEnabled = True
        Me.cboCust.Location = New System.Drawing.Point(119, 62)
        Me.cboCust.Name = "cboCust"
        Me.cboCust.Size = New System.Drawing.Size(282, 21)
        Me.cboCust.TabIndex = 253
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(22, 121)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 13)
        Me.Label20.TabIndex = 288
        Me.Label20.Text = "Product/Item:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPrdSer
        '
        Me.cboPrdSer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPrdSer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPrdSer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboPrdSer.FormattingEnabled = True
        Me.cboPrdSer.Location = New System.Drawing.Point(119, 121)
        Me.cboPrdSer.Name = "cboPrdSer"
        Me.cboPrdSer.Size = New System.Drawing.Size(282, 21)
        Me.cboPrdSer.TabIndex = 285
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 287
        Me.Label3.Text = "Description:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCallDesc
        '
        Me.txtCallDesc.Location = New System.Drawing.Point(119, 157)
        Me.txtCallDesc.Multiline = True
        Me.txtCallDesc.Name = "txtCallDesc"
        Me.txtCallDesc.Size = New System.Drawing.Size(282, 59)
        Me.txtCallDesc.TabIndex = 286
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 290
        Me.Label8.Text = "Enggineer To:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboAssignEmp
        '
        Me.cboAssignEmp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssignEmp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssignEmp.FormattingEnabled = True
        Me.cboAssignEmp.Location = New System.Drawing.Point(119, 236)
        Me.cboAssignEmp.Name = "cboAssignEmp"
        Me.cboAssignEmp.Size = New System.Drawing.Size(282, 21)
        Me.cboAssignEmp.TabIndex = 289
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 277)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 292
        Me.Label2.Text = "Status :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(119, 274)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(98, 21)
        Me.ComboBox1.TabIndex = 291
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(239, 415)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(85, 23)
        Me.OK_Button.TabIndex = 293
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(332, 415)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(85, 23)
        Me.Cancel_Button.TabIndex = 294
        Me.Cancel_Button.Text = "Close"
        '
        'frmStandBy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 450)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboAssignEmp)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cboPrdSer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCallDesc)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cboCustCode)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRecDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCust)
        Me.Name = "frmStandBy"
        Me.Text = "Stand By"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboCustCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRecDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboPrdSer As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCallDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboAssignEmp As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
End Class
