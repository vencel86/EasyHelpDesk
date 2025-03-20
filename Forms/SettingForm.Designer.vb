<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingForm))
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblCallFrom = New System.Windows.Forms.Label()
        Me.txtCallFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbDefPrior4 = New System.Windows.Forms.RadioButton()
        Me.rbDefPrior3 = New System.Windows.Forms.RadioButton()
        Me.rbDefPrior2 = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbDefPrior1 = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDay4 = New System.Windows.Forms.TextBox()
        Me.txtDay3 = New System.Windows.Forms.TextBox()
        Me.txtDay2 = New System.Windows.Forms.TextBox()
        Me.txtDay1 = New System.Windows.Forms.TextBox()
        Me.txtPriority4 = New System.Windows.Forms.TextBox()
        Me.txtPriority3 = New System.Windows.Forms.TextBox()
        Me.txtPriority2 = New System.Windows.Forms.TextBox()
        Me.txtPriority1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rb24Hour = New System.Windows.Forms.RadioButton()
        Me.rb12Hour = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBCustomDate = New System.Windows.Forms.RadioButton()
        Me.rbDDMMMYYYY = New System.Windows.Forms.RadioButton()
        Me.txtDateFormat = New System.Windows.Forms.TextBox()
        Me.rbMMMDDYYY = New System.Windows.Forms.RadioButton()
        Me.rbDDMMYYYY = New System.Windows.Forms.RadioButton()
        Me.rbMMDDYYYY = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvCallStatus = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LVCallFrom = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbCustName = New System.Windows.Forms.RadioButton()
        Me.rbCustCode = New System.Windows.Forms.RadioButton()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvCallStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.lblCallFrom)
        Me.GroupBox6.Controls.Add(Me.txtCallFrom)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Location = New System.Drawing.Point(11, 61)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(283, 265)
        Me.GroupBox6.TabIndex = 312
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Call From Category"
        '
        'lblCallFrom
        '
        Me.lblCallFrom.AutoSize = True
        Me.lblCallFrom.Location = New System.Drawing.Point(187, 16)
        Me.lblCallFrom.Name = "lblCallFrom"
        Me.lblCallFrom.Size = New System.Drawing.Size(13, 13)
        Me.lblCallFrom.TabIndex = 296
        Me.lblCallFrom.Text = "0"
        Me.lblCallFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCallFrom.Visible = False
        '
        'txtCallFrom
        '
        Me.txtCallFrom.Location = New System.Drawing.Point(54, 27)
        Me.txtCallFrom.Name = "txtCallFrom"
        Me.txtCallFrom.Size = New System.Drawing.Size(171, 20)
        Me.txtCallFrom.TabIndex = 291
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 292
        Me.Label9.Text = "Name:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 332)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(231, 13)
        Me.Label8.TabIndex = 311
        Me.Label8.Text = "Note: Selected item will be marked as a default."
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(439, 438)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(83, 23)
        Me.OK_Button.TabIndex = 11
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(530, 438)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(83, 23)
        Me.Cancel_Button.TabIndex = 12
        Me.Cancel_Button.Text = "Close"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rbDefPrior4)
        Me.GroupBox5.Controls.Add(Me.rbDefPrior3)
        Me.GroupBox5.Controls.Add(Me.rbDefPrior2)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.rbDefPrior1)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.txtDay4)
        Me.GroupBox5.Controls.Add(Me.txtDay3)
        Me.GroupBox5.Controls.Add(Me.txtDay2)
        Me.GroupBox5.Controls.Add(Me.txtDay1)
        Me.GroupBox5.Controls.Add(Me.txtPriority4)
        Me.GroupBox5.Controls.Add(Me.txtPriority3)
        Me.GroupBox5.Controls.Add(Me.txtPriority2)
        Me.GroupBox5.Controls.Add(Me.txtPriority1)
        Me.GroupBox5.Location = New System.Drawing.Point(25, 30)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(299, 192)
        Me.GroupBox5.TabIndex = 305
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Call Priority"
        '
        'rbDefPrior4
        '
        Me.rbDefPrior4.AutoSize = True
        Me.rbDefPrior4.Location = New System.Drawing.Point(43, 145)
        Me.rbDefPrior4.Name = "rbDefPrior4"
        Me.rbDefPrior4.Size = New System.Drawing.Size(14, 13)
        Me.rbDefPrior4.TabIndex = 297
        Me.rbDefPrior4.TabStop = True
        Me.rbDefPrior4.UseVisualStyleBackColor = True
        '
        'rbDefPrior3
        '
        Me.rbDefPrior3.AutoSize = True
        Me.rbDefPrior3.Location = New System.Drawing.Point(43, 117)
        Me.rbDefPrior3.Name = "rbDefPrior3"
        Me.rbDefPrior3.Size = New System.Drawing.Size(14, 13)
        Me.rbDefPrior3.TabIndex = 296
        Me.rbDefPrior3.TabStop = True
        Me.rbDefPrior3.UseVisualStyleBackColor = True
        '
        'rbDefPrior2
        '
        Me.rbDefPrior2.AutoSize = True
        Me.rbDefPrior2.Location = New System.Drawing.Point(43, 89)
        Me.rbDefPrior2.Name = "rbDefPrior2"
        Me.rbDefPrior2.Size = New System.Drawing.Size(14, 13)
        Me.rbDefPrior2.TabIndex = 295
        Me.rbDefPrior2.TabStop = True
        Me.rbDefPrior2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 294
        Me.Label6.Text = "Default"
        '
        'rbDefPrior1
        '
        Me.rbDefPrior1.AutoSize = True
        Me.rbDefPrior1.Location = New System.Drawing.Point(43, 60)
        Me.rbDefPrior1.Name = "rbDefPrior1"
        Me.rbDefPrior1.Size = New System.Drawing.Size(14, 13)
        Me.rbDefPrior1.TabIndex = 293
        Me.rbDefPrior1.TabStop = True
        Me.rbDefPrior1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoEllipsis = True
        Me.Label5.Location = New System.Drawing.Point(195, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 292
        Me.Label5.Text = "Due Days"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(113, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 291
        Me.Label4.Text = "Prirorty"
        '
        'txtDay4
        '
        Me.txtDay4.Location = New System.Drawing.Point(215, 143)
        Me.txtDay4.Name = "txtDay4"
        Me.txtDay4.Size = New System.Drawing.Size(39, 20)
        Me.txtDay4.TabIndex = 8
        Me.txtDay4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDay3
        '
        Me.txtDay3.Location = New System.Drawing.Point(215, 115)
        Me.txtDay3.Name = "txtDay3"
        Me.txtDay3.Size = New System.Drawing.Size(39, 20)
        Me.txtDay3.TabIndex = 7
        Me.txtDay3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDay2
        '
        Me.txtDay2.Location = New System.Drawing.Point(215, 87)
        Me.txtDay2.Name = "txtDay2"
        Me.txtDay2.Size = New System.Drawing.Size(39, 20)
        Me.txtDay2.TabIndex = 6
        Me.txtDay2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDay1
        '
        Me.txtDay1.Location = New System.Drawing.Point(215, 59)
        Me.txtDay1.Name = "txtDay1"
        Me.txtDay1.Size = New System.Drawing.Size(39, 20)
        Me.txtDay1.TabIndex = 5
        Me.txtDay1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPriority4
        '
        Me.txtPriority4.Location = New System.Drawing.Point(83, 143)
        Me.txtPriority4.Name = "txtPriority4"
        Me.txtPriority4.Size = New System.Drawing.Size(113, 20)
        Me.txtPriority4.TabIndex = 4
        Me.txtPriority4.Text = "Low"
        '
        'txtPriority3
        '
        Me.txtPriority3.Location = New System.Drawing.Point(83, 115)
        Me.txtPriority3.Name = "txtPriority3"
        Me.txtPriority3.Size = New System.Drawing.Size(113, 20)
        Me.txtPriority3.TabIndex = 3
        Me.txtPriority3.Text = "Medium"
        '
        'txtPriority2
        '
        Me.txtPriority2.Location = New System.Drawing.Point(83, 87)
        Me.txtPriority2.Name = "txtPriority2"
        Me.txtPriority2.Size = New System.Drawing.Size(113, 20)
        Me.txtPriority2.TabIndex = 2
        Me.txtPriority2.Text = "High"
        '
        'txtPriority1
        '
        Me.txtPriority1.Location = New System.Drawing.Point(83, 59)
        Me.txtPriority1.Name = "txtPriority1"
        Me.txtPriority1.Size = New System.Drawing.Size(113, 20)
        Me.txtPriority1.TabIndex = 1
        Me.txtPriority1.Text = "Immergency"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(500, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 301
        Me.Label3.Text = "*Report Header"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(112, 22)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(382, 20)
        Me.txtCompanyName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 290
        Me.Label2.Text = "Comapny Name:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rb24Hour)
        Me.GroupBox2.Controls.Add(Me.rb12Hour)
        Me.GroupBox2.Location = New System.Drawing.Point(394, 234)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(158, 90)
        Me.GroupBox2.TabIndex = 313
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Time Format"
        '
        'rb24Hour
        '
        Me.rb24Hour.AutoSize = True
        Me.rb24Hour.Location = New System.Drawing.Point(47, 55)
        Me.rb24Hour.Name = "rb24Hour"
        Me.rb24Hour.Size = New System.Drawing.Size(63, 17)
        Me.rb24Hour.TabIndex = 2
        Me.rb24Hour.TabStop = True
        Me.rb24Hour.Text = "24 Hour"
        Me.rb24Hour.UseVisualStyleBackColor = True
        '
        'rb12Hour
        '
        Me.rb12Hour.AutoSize = True
        Me.rb12Hour.Location = New System.Drawing.Point(47, 31)
        Me.rb12Hour.Name = "rb12Hour"
        Me.rb12Hour.Size = New System.Drawing.Size(63, 17)
        Me.rb12Hour.TabIndex = 1
        Me.rb12Hour.TabStop = True
        Me.rb12Hour.Text = "12 Hour"
        Me.rb12Hour.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(22, 227)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(326, 23)
        Me.Label7.TabIndex = 306
        Me.Label7.Text = "* If you are not sure about custom format please use default format."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBCustomDate)
        Me.GroupBox1.Controls.Add(Me.rbDDMMMYYYY)
        Me.GroupBox1.Controls.Add(Me.txtDateFormat)
        Me.GroupBox1.Controls.Add(Me.rbMMMDDYYY)
        Me.GroupBox1.Controls.Add(Me.rbDDMMYYYY)
        Me.GroupBox1.Controls.Add(Me.rbMMDDYYYY)
        Me.GroupBox1.Location = New System.Drawing.Point(394, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(158, 192)
        Me.GroupBox1.TabIndex = 299
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Format"
        '
        'RBCustomDate
        '
        Me.RBCustomDate.AutoSize = True
        Me.RBCustomDate.Location = New System.Drawing.Point(23, 127)
        Me.RBCustomDate.Name = "RBCustomDate"
        Me.RBCustomDate.Size = New System.Drawing.Size(102, 17)
        Me.RBCustomDate.TabIndex = 6
        Me.RBCustomDate.TabStop = True
        Me.RBCustomDate.Text = "* Custom Format"
        Me.RBCustomDate.UseVisualStyleBackColor = True
        '
        'rbDDMMMYYYY
        '
        Me.rbDDMMMYYYY.AutoSize = True
        Me.rbDDMMMYYYY.Location = New System.Drawing.Point(23, 103)
        Me.rbDDMMMYYYY.Name = "rbDDMMMYYYY"
        Me.rbDDMMMYYYY.Size = New System.Drawing.Size(109, 17)
        Me.rbDDMMMYYYY.TabIndex = 5
        Me.rbDDMMMYYYY.TabStop = True
        Me.rbDDMMMYYYY.Text = "DD/MMM/YYYY "
        Me.rbDDMMMYYYY.UseVisualStyleBackColor = True
        '
        'txtDateFormat
        '
        Me.txtDateFormat.Enabled = False
        Me.txtDateFormat.Location = New System.Drawing.Point(44, 151)
        Me.txtDateFormat.Name = "txtDateFormat"
        Me.txtDateFormat.Size = New System.Drawing.Size(100, 20)
        Me.txtDateFormat.TabIndex = 4
        Me.txtDateFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rbMMMDDYYY
        '
        Me.rbMMMDDYYY.AutoSize = True
        Me.rbMMMDDYYY.Location = New System.Drawing.Point(23, 79)
        Me.rbMMMDDYYY.Name = "rbMMMDDYYY"
        Me.rbMMMDDYYY.Size = New System.Drawing.Size(109, 17)
        Me.rbMMMDDYYY.TabIndex = 3
        Me.rbMMMDDYYY.TabStop = True
        Me.rbMMMDDYYY.Text = "MMM/DD/YYYY "
        Me.rbMMMDDYYY.UseVisualStyleBackColor = True
        '
        'rbDDMMYYYY
        '
        Me.rbDDMMYYYY.AutoSize = True
        Me.rbDDMMYYYY.Location = New System.Drawing.Point(23, 55)
        Me.rbDDMMYYYY.Name = "rbDDMMYYYY"
        Me.rbDDMMYYYY.Size = New System.Drawing.Size(97, 17)
        Me.rbDDMMYYYY.TabIndex = 2
        Me.rbDDMMYYYY.TabStop = True
        Me.rbDDMMYYYY.Text = "DD/MM/YYYY"
        Me.rbDDMMYYYY.UseVisualStyleBackColor = True
        '
        'rbMMDDYYYY
        '
        Me.rbMMDDYYYY.AutoSize = True
        Me.rbMMDDYYYY.Location = New System.Drawing.Point(23, 31)
        Me.rbMMDDYYYY.Name = "rbMMDDYYYY"
        Me.rbMMDDYYYY.Size = New System.Drawing.Size(100, 17)
        Me.rbMMDDYYYY.TabIndex = 1
        Me.rbMMDDYYYY.TabStop = True
        Me.rbMMDDYYYY.Text = "MM/DD/YYYY "
        Me.rbMMDDYYYY.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvCallStatus)
        Me.GroupBox3.Location = New System.Drawing.Point(697, 120)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(197, 192)
        Me.GroupBox3.TabIndex = 303
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Call Status Category"
        Me.GroupBox3.Visible = False
        '
        'dgvCallStatus
        '
        Me.dgvCallStatus.AllowUserToOrderColumns = True
        Me.dgvCallStatus.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCallStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCallStatus.ColumnHeadersVisible = False
        Me.dgvCallStatus.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvCallStatus.Location = New System.Drawing.Point(12, 27)
        Me.dgvCallStatus.Name = "dgvCallStatus"
        Me.dgvCallStatus.RowHeadersVisible = False
        Me.dgvCallStatus.Size = New System.Drawing.Size(172, 153)
        Me.dgvCallStatus.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Location = New System.Drawing.Point(8, 9)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(318, 39)
        Me.Panel2.TabIndex = 304
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 1)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(45, 38)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Change Settings"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label17.Location = New System.Drawing.Point(51, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(141, 19)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Default Settings"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 55)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(608, 377)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 305
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.LVCallFrom)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtCompanyName)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(600, 351)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Data List"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LVCallFrom
        '
        Me.LVCallFrom.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.LVCallFrom.FullRowSelect = True
        Me.LVCallFrom.GridLines = True
        Me.LVCallFrom.HideSelection = False
        Me.LVCallFrom.Location = New System.Drawing.Point(22, 120)
        Me.LVCallFrom.MultiSelect = False
        Me.LVCallFrom.Name = "LVCallFrom"
        Me.LVCallFrom.Size = New System.Drawing.Size(259, 163)
        Me.LVCallFrom.TabIndex = 1
        Me.LVCallFrom.UseCompatibleStateImageBehavior = False
        Me.LVCallFrom.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Call From"
        Me.ColumnHeader2.Width = 255
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(600, 351)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Other"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbCustCode)
        Me.GroupBox4.Controls.Add(Me.rbCustName)
        Me.GroupBox4.Location = New System.Drawing.Point(300, 61)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(283, 265)
        Me.GroupBox4.TabIndex = 313
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Customer Name Selection"
        '
        'rbCustName
        '
        Me.rbCustName.AutoSize = True
        Me.rbCustName.Checked = True
        Me.rbCustName.Location = New System.Drawing.Point(37, 28)
        Me.rbCustName.Name = "rbCustName"
        Me.rbCustName.Size = New System.Drawing.Size(146, 17)
        Me.rbCustName.TabIndex = 0
        Me.rbCustName.TabStop = True
        Me.rbCustName.Text = "Name First, Code Second"
        Me.rbCustName.UseVisualStyleBackColor = True
        '
        'rbCustCode
        '
        Me.rbCustCode.AutoSize = True
        Me.rbCustCode.Location = New System.Drawing.Point(37, 59)
        Me.rbCustCode.Name = "rbCustCode"
        Me.rbCustCode.Size = New System.Drawing.Size(146, 17)
        Me.rbCustCode.TabIndex = 1
        Me.rbCustCode.TabStop = True
        Me.rbCustCode.Text = "Code First, Name Second"
        Me.rbCustCode.UseVisualStyleBackColor = True
        '
        'SettingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(625, 467)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Default Setttings"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvCallStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDateFormat As System.Windows.Forms.TextBox
    Friend WithEvents rbMMMDDYYY As System.Windows.Forms.RadioButton
    Friend WithEvents rbDDMMYYYY As System.Windows.Forms.RadioButton
    Friend WithEvents rbMMDDYYYY As System.Windows.Forms.RadioButton
    Friend WithEvents RBCustomDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbDDMMMYYYY As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCallStatus As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPriority4 As System.Windows.Forms.TextBox
    Friend WithEvents txtPriority3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPriority2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPriority1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDay4 As System.Windows.Forms.TextBox
    Friend WithEvents txtDay3 As System.Windows.Forms.TextBox
    Friend WithEvents txtDay2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDay1 As System.Windows.Forms.TextBox
    Friend WithEvents rbDefPrior4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbDefPrior3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbDefPrior2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbDefPrior1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rb24Hour As System.Windows.Forms.RadioButton
    Friend WithEvents rb12Hour As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtCallFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LVCallFrom As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblCallFrom As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rbCustCode As RadioButton
    Friend WithEvents rbCustName As RadioButton
End Class
