<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CallSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CallSearch))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvCalls = New System.Windows.Forms.DataGridView()
        Me.colCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCust = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAssignedTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConfirmed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rbCancelled = New System.Windows.Forms.RadioButton()
        Me.rbToday = New System.Windows.Forms.RadioButton()
        Me.rbAParts = New System.Windows.Forms.RadioButton()
        Me.rbAInfo = New System.Windows.Forms.RadioButton()
        Me.rbNotAssigned = New System.Windows.Forms.RadioButton()
        Me.rbShowAll = New System.Windows.Forms.RadioButton()
        Me.rbOnHold = New System.Windows.Forms.RadioButton()
        Me.rbClosed = New System.Windows.Forms.RadioButton()
        Me.rbOpen = New System.Windows.Forms.RadioButton()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCity = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboEmp = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalCalls = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCalls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnPrint)
        Me.Panel1.Controls.Add(Me.Cancel_Button)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Location = New System.Drawing.Point(6, 50)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(996, 649)
        Me.Panel1.TabIndex = 37
        '
        'dtpTo
        '
        Me.dtpTo.Checked = False
        Me.dtpTo.CustomFormat = "dd-MMM-yy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(246, 614)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.ShowCheckBox = True
        Me.dtpTo.Size = New System.Drawing.Size(113, 21)
        Me.dtpTo.TabIndex = 281
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(197, 617)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 283
        Me.Label2.Text = "To Date:"
        '
        'dtpFrom
        '
        Me.dtpFrom.Checked = False
        Me.dtpFrom.CustomFormat = "dd-MMM-yy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(70, 614)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.ShowCheckBox = True
        Me.dtpFrom.Size = New System.Drawing.Size(113, 21)
        Me.dtpFrom.TabIndex = 280
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 617)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 282
        Me.Label1.Text = "From Date:"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(703, 612)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(90, 28)
        Me.btnPrint.TabIndex = 47
        Me.btnPrint.Text = "&Print"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(897, 612)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(90, 28)
        Me.Cancel_Button.TabIndex = 5
        Me.Cancel_Button.Text = "&Close"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(800, 612)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 28)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "&Search..."
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblTotalCalls)
        Me.GroupBox1.Controls.Add(Me.dgvCalls)
        Me.GroupBox1.Controls.Add(Me.rbCancelled)
        Me.GroupBox1.Controls.Add(Me.rbToday)
        Me.GroupBox1.Controls.Add(Me.rbAParts)
        Me.GroupBox1.Controls.Add(Me.rbAInfo)
        Me.GroupBox1.Controls.Add(Me.rbNotAssigned)
        Me.GroupBox1.Controls.Add(Me.rbShowAll)
        Me.GroupBox1.Controls.Add(Me.rbOnHold)
        Me.GroupBox1.Controls.Add(Me.rbClosed)
        Me.GroupBox1.Controls.Add(Me.rbOpen)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(985, 603)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        '
        'dgvCalls
        '
        Me.dgvCalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCalls.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCode, Me.colRefNo, Me.colCust, Me.colStatus, Me.colRecDate, Me.colDesc, Me.colAssignedTo, Me.colConfirmed})
        Me.dgvCalls.Location = New System.Drawing.Point(10, 45)
        Me.dgvCalls.Name = "dgvCalls"
        Me.dgvCalls.RowHeadersVisible = False
        Me.dgvCalls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCalls.Size = New System.Drawing.Size(966, 531)
        Me.dgvCalls.TabIndex = 46
        '
        'colCode
        '
        Me.colCode.DataPropertyName = "CallCode"
        Me.colCode.HeaderText = "Code"
        Me.colCode.Name = "colCode"
        Me.colCode.Visible = False
        '
        'colRefNo
        '
        Me.colRefNo.DataPropertyName = "RefNo"
        Me.colRefNo.HeaderText = "Ref No"
        Me.colRefNo.Name = "colRefNo"
        Me.colRefNo.Width = 70
        '
        'colCust
        '
        Me.colCust.DataPropertyName = "CustName"
        Me.colCust.HeaderText = "Customer Name"
        Me.colCust.Name = "colCust"
        Me.colCust.Width = 200
        '
        'colStatus
        '
        Me.colStatus.DataPropertyName = "CurrentStatus"
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.Width = 80
        '
        'colRecDate
        '
        Me.colRecDate.DataPropertyName = "RD"
        Me.colRecDate.HeaderText = "Rec Date"
        Me.colRecDate.Name = "colRecDate"
        '
        'colDesc
        '
        Me.colDesc.DataPropertyName = "CallDesc"
        Me.colDesc.HeaderText = "Description"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.Width = 200
        '
        'colAssignedTo
        '
        Me.colAssignedTo.DataPropertyName = "AssignEmp"
        Me.colAssignedTo.HeaderText = "Assigned To"
        Me.colAssignedTo.Name = "colAssignedTo"
        Me.colAssignedTo.Width = 120
        '
        'colConfirmed
        '
        Me.colConfirmed.DataPropertyName = "ConfirmedBy"
        Me.colConfirmed.HeaderText = "Confirmed By"
        Me.colConfirmed.Name = "colConfirmed"
        Me.colConfirmed.Width = 120
        '
        'rbCancelled
        '
        Me.rbCancelled.AutoSize = True
        Me.rbCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCancelled.Location = New System.Drawing.Point(391, 22)
        Me.rbCancelled.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbCancelled.Name = "rbCancelled"
        Me.rbCancelled.Size = New System.Drawing.Size(72, 17)
        Me.rbCancelled.TabIndex = 45
        Me.rbCancelled.Text = "Cancelled"
        Me.rbCancelled.UseVisualStyleBackColor = True
        '
        'rbToday
        '
        Me.rbToday.AutoSize = True
        Me.rbToday.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbToday.Location = New System.Drawing.Point(747, 22)
        Me.rbToday.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbToday.Name = "rbToday"
        Me.rbToday.Size = New System.Drawing.Size(82, 17)
        Me.rbToday.TabIndex = 42
        Me.rbToday.Text = "Today's Call"
        Me.rbToday.UseVisualStyleBackColor = True
        '
        'rbAParts
        '
        Me.rbAParts.AutoSize = True
        Me.rbAParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAParts.Location = New System.Drawing.Point(618, 22)
        Me.rbAParts.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbAParts.Name = "rbAParts"
        Me.rbAParts.Size = New System.Drawing.Size(92, 17)
        Me.rbAParts.TabIndex = 41
        Me.rbAParts.Text = "Awaiting Parts"
        Me.rbAParts.UseVisualStyleBackColor = True
        '
        'rbAInfo
        '
        Me.rbAInfo.AutoSize = True
        Me.rbAInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAInfo.Location = New System.Drawing.Point(495, 22)
        Me.rbAInfo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbAInfo.Name = "rbAInfo"
        Me.rbAInfo.Size = New System.Drawing.Size(86, 17)
        Me.rbAInfo.TabIndex = 40
        Me.rbAInfo.Text = "Awaiting Info"
        Me.rbAInfo.UseVisualStyleBackColor = True
        '
        'rbNotAssigned
        '
        Me.rbNotAssigned.AutoSize = True
        Me.rbNotAssigned.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNotAssigned.Location = New System.Drawing.Point(269, 22)
        Me.rbNotAssigned.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbNotAssigned.Name = "rbNotAssigned"
        Me.rbNotAssigned.Size = New System.Drawing.Size(88, 17)
        Me.rbNotAssigned.TabIndex = 39
        Me.rbNotAssigned.Text = "Not Assigned"
        Me.rbNotAssigned.UseVisualStyleBackColor = True
        '
        'rbShowAll
        '
        Me.rbShowAll.AutoSize = True
        Me.rbShowAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbShowAll.Location = New System.Drawing.Point(865, 22)
        Me.rbShowAll.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbShowAll.Name = "rbShowAll"
        Me.rbShowAll.Size = New System.Drawing.Size(66, 17)
        Me.rbShowAll.TabIndex = 38
        Me.rbShowAll.Text = "Show All"
        Me.rbShowAll.UseVisualStyleBackColor = True
        '
        'rbOnHold
        '
        Me.rbOnHold.AutoSize = True
        Me.rbOnHold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOnHold.Location = New System.Drawing.Point(176, 22)
        Me.rbOnHold.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbOnHold.Name = "rbOnHold"
        Me.rbOnHold.Size = New System.Drawing.Size(64, 17)
        Me.rbOnHold.TabIndex = 37
        Me.rbOnHold.Text = "On Hold"
        Me.rbOnHold.UseVisualStyleBackColor = True
        '
        'rbClosed
        '
        Me.rbClosed.AutoSize = True
        Me.rbClosed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbClosed.Location = New System.Drawing.Point(89, 22)
        Me.rbClosed.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbClosed.Name = "rbClosed"
        Me.rbClosed.Size = New System.Drawing.Size(58, 17)
        Me.rbClosed.TabIndex = 36
        Me.rbClosed.Text = "Solved"
        Me.rbClosed.UseVisualStyleBackColor = True
        '
        'rbOpen
        '
        Me.rbOpen.AutoSize = True
        Me.rbOpen.Checked = True
        Me.rbOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOpen.Location = New System.Drawing.Point(11, 22)
        Me.rbOpen.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbOpen.Name = "rbOpen"
        Me.rbOpen.Size = New System.Drawing.Size(51, 17)
        Me.rbOpen.TabIndex = 35
        Me.rbOpen.TabStop = True
        Me.rbOpen.Text = "Open"
        Me.rbOpen.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(606, 612)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 28)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "D&elete"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Location = New System.Drawing.Point(509, 612)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(90, 28)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "&Edit"
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Location = New System.Drawing.Point(412, 612)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(90, 28)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "&New"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Location = New System.Drawing.Point(6, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(318, 39)
        Me.Panel2.TabIndex = 282
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(53, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(165, 15)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Manage, Print Serivce Call(s)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label17.Location = New System.Drawing.Point(51, 2)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(138, 19)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Service Call List"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(823, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 283
        Me.Label3.Text = "City:"
        '
        'cboCity
        '
        Me.cboCity.FormattingEnabled = True
        Me.cboCity.Items.AddRange(New Object() {"<All>", "Surat", "Bhavnagar"})
        Me.cboCity.Location = New System.Drawing.Point(854, 14)
        Me.cboCity.Name = "cboCity"
        Me.cboCity.Size = New System.Drawing.Size(148, 23)
        Me.cboCity.TabIndex = 284
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(400, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 285
        Me.Label4.Text = "Month:"
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "NOVEMBER", "DECEMBER"})
        Me.cboMonth.Location = New System.Drawing.Point(445, 14)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(105, 23)
        Me.cboMonth.TabIndex = 286
        '
        'cboEmp
        '
        Me.cboEmp.FormattingEnabled = True
        Me.cboEmp.Items.AddRange(New Object() {"<All>"})
        Me.cboEmp.Location = New System.Drawing.Point(629, 14)
        Me.cboEmp.Name = "cboEmp"
        Me.cboEmp.Size = New System.Drawing.Size(188, 23)
        Me.cboEmp.TabIndex = 288
        Me.cboEmp.Text = "All"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(571, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 287
        Me.Label5.Text = "Engineer:"
        '
        'lblTotalCalls
        '
        Me.lblTotalCalls.AutoSize = True
        Me.lblTotalCalls.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCalls.ForeColor = System.Drawing.Color.Green
        Me.lblTotalCalls.Location = New System.Drawing.Point(8, 582)
        Me.lblTotalCalls.Name = "lblTotalCalls"
        Me.lblTotalCalls.Size = New System.Drawing.Size(71, 13)
        Me.lblTotalCalls.TabIndex = 286
        Me.lblTotalCalls.Text = "Total Calls:"
        '
        'CallSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(1008, 711)
        Me.Controls.Add(Me.cboEmp)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboCity)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CallSearch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Service Call List"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCalls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbToday As System.Windows.Forms.RadioButton
    Friend WithEvents rbAParts As System.Windows.Forms.RadioButton
    Friend WithEvents rbAInfo As System.Windows.Forms.RadioButton
    Friend WithEvents rbNotAssigned As System.Windows.Forms.RadioButton
    Friend WithEvents rbShowAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbOnHold As System.Windows.Forms.RadioButton
    Friend WithEvents rbClosed As System.Windows.Forms.RadioButton
    Friend WithEvents rbOpen As System.Windows.Forms.RadioButton
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents rbCancelled As System.Windows.Forms.RadioButton
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCity As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents dgvCalls As System.Windows.Forms.DataGridView
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCust As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAssignedTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConfirmed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboEmp As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTotalCalls As Label
End Class
