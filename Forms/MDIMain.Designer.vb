<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MDIMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIMain))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuSerice = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuServiceNewCall = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuServiceOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuServiceSolved = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuServiceViewAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasters = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMasterCust = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMastEmp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMastService = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMastInventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepToday = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRepCustom = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRepCust = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepEmp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepEmpAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepEmpDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRepInventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepInventoryList = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAdminOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDataCR = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBakup = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDataClosed = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDataAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDataEverything = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAdminLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepCustAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRepCustOpenCalls = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsBtnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtnCust = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnEmp = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnInventory = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnService = New System.Windows.Forms.ToolStripButton()
        Me.btnSettings = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.sbCompanyName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbUserName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbSep1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbOpenCalls = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbSep2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnSearchQuery = New System.Windows.Forms.Button()
        Me.cboSearch = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbServiceType = New System.Windows.Forms.RadioButton()
        Me.rbArea = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lvCalls = New System.Windows.Forms.ListView()
        Me.clCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clRefNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clCustName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clServiceType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clCallDesc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clWarrantyDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clLogDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clCallTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clArea = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvEmp = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvToday = New System.Windows.Forms.ListView()
        Me.clACode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clARefNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clCustomerName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPService = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPWarranty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clAArea = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clStartTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clTimeElapsed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clAssignedTo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.panEmpCust = New System.Windows.Forms.Panel()
        Me.pnlCallStatus = New System.Windows.Forms.Panel()
        Me.btnCAP = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.lblAwaitingInfo = New System.Windows.Forms.Label()
        Me.btnCAI = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnCH = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnCNA = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblCallNotAssigned = New System.Windows.Forms.Label()
        Me.lblTodayCall = New System.Windows.Forms.Label()
        Me.btnCP = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblOnHold = New System.Windows.Forms.Label()
        Me.btnCToday = New System.Windows.Forms.Label()
        Me.lblAwaitingParts = New System.Windows.Forms.Label()
        Me.lblOpenCalls = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuPopEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPopDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPopPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPopAssign = New System.Windows.Forms.ToolStripMenuItem()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblUserCode = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.panEmpCust.SuspendLayout()
        Me.pnlCallStatus.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSerice, Me.mnuMasters, Me.ViewMenu, Me.mnuAdmin, Me.HelpMenu, Me.mnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1008, 25)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'mnuSerice
        '
        Me.mnuSerice.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuServiceNewCall, Me.mnuServiceOpen, Me.mnuServiceSolved, Me.mnuServiceViewAll})
        Me.mnuSerice.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.mnuSerice.Name = "mnuSerice"
        Me.mnuSerice.Size = New System.Drawing.Size(61, 21)
        Me.mnuSerice.Text = "&Service"
        '
        'mnuServiceNewCall
        '
        Me.mnuServiceNewCall.Image = CType(resources.GetObject("mnuServiceNewCall.Image"), System.Drawing.Image)
        Me.mnuServiceNewCall.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuServiceNewCall.Name = "mnuServiceNewCall"
        Me.mnuServiceNewCall.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mnuServiceNewCall.Size = New System.Drawing.Size(148, 22)
        Me.mnuServiceNewCall.Text = "&New Call"
        '
        'mnuServiceOpen
        '
        Me.mnuServiceOpen.Image = CType(resources.GetObject("mnuServiceOpen.Image"), System.Drawing.Image)
        Me.mnuServiceOpen.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuServiceOpen.Name = "mnuServiceOpen"
        Me.mnuServiceOpen.Size = New System.Drawing.Size(148, 22)
        Me.mnuServiceOpen.Text = "&in Process"
        '
        'mnuServiceSolved
        '
        Me.mnuServiceSolved.Image = CType(resources.GetObject("mnuServiceSolved.Image"), System.Drawing.Image)
        Me.mnuServiceSolved.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuServiceSolved.Name = "mnuServiceSolved"
        Me.mnuServiceSolved.Size = New System.Drawing.Size(148, 22)
        Me.mnuServiceSolved.Text = "&Solved"
        '
        'mnuServiceViewAll
        '
        Me.mnuServiceViewAll.Image = CType(resources.GetObject("mnuServiceViewAll.Image"), System.Drawing.Image)
        Me.mnuServiceViewAll.Name = "mnuServiceViewAll"
        Me.mnuServiceViewAll.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mnuServiceViewAll.Size = New System.Drawing.Size(148, 22)
        Me.mnuServiceViewAll.Text = "View All"
        '
        'mnuMasters
        '
        Me.mnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMasterCust, Me.mnuMastEmp, Me.mnuMastService, Me.mnuMastInventory})
        Me.mnuMasters.Name = "mnuMasters"
        Me.mnuMasters.Size = New System.Drawing.Size(67, 21)
        Me.mnuMasters.Text = "&Masters"
        '
        'mnuMasterCust
        '
        Me.mnuMasterCust.Image = CType(resources.GetObject("mnuMasterCust.Image"), System.Drawing.Image)
        Me.mnuMasterCust.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuMasterCust.Name = "mnuMasterCust"
        Me.mnuMasterCust.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mnuMasterCust.Size = New System.Drawing.Size(169, 22)
        Me.mnuMasterCust.Text = "&Customer"
        '
        'mnuMastEmp
        '
        Me.mnuMastEmp.Image = CType(resources.GetObject("mnuMastEmp.Image"), System.Drawing.Image)
        Me.mnuMastEmp.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuMastEmp.Name = "mnuMastEmp"
        Me.mnuMastEmp.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.mnuMastEmp.Size = New System.Drawing.Size(169, 22)
        Me.mnuMastEmp.Text = "&Employee"
        '
        'mnuMastService
        '
        Me.mnuMastService.Image = CType(resources.GetObject("mnuMastService.Image"), System.Drawing.Image)
        Me.mnuMastService.Name = "mnuMastService"
        Me.mnuMastService.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.mnuMastService.Size = New System.Drawing.Size(169, 22)
        Me.mnuMastService.Text = "Service Type"
        '
        'mnuMastInventory
        '
        Me.mnuMastInventory.Image = CType(resources.GetObject("mnuMastInventory.Image"), System.Drawing.Image)
        Me.mnuMastInventory.Name = "mnuMastInventory"
        Me.mnuMastInventory.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuMastInventory.Size = New System.Drawing.Size(169, 22)
        Me.mnuMastInventory.Text = "Inventory"
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRepToday, Me.mnuRepOpen, Me.ToolStripMenuItem1, Me.mnuRepCustom, Me.ToolStripSeparator2, Me.mnuRepCust, Me.mnuRepEmp, Me.ToolStripMenuItem3, Me.mnuRepInventory})
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(60, 21)
        Me.ViewMenu.Text = "&Report"
        '
        'mnuRepToday
        '
        Me.mnuRepToday.Image = CType(resources.GetObject("mnuRepToday.Image"), System.Drawing.Image)
        Me.mnuRepToday.Name = "mnuRepToday"
        Me.mnuRepToday.Size = New System.Drawing.Size(164, 22)
        Me.mnuRepToday.Text = "Today's Calls"
        '
        'mnuRepOpen
        '
        Me.mnuRepOpen.Image = CType(resources.GetObject("mnuRepOpen.Image"), System.Drawing.Image)
        Me.mnuRepOpen.Name = "mnuRepOpen"
        Me.mnuRepOpen.Size = New System.Drawing.Size(164, 22)
        Me.mnuRepOpen.Text = "Open Calls"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(161, 6)
        '
        'mnuRepCustom
        '
        Me.mnuRepCustom.Image = CType(resources.GetObject("mnuRepCustom.Image"), System.Drawing.Image)
        Me.mnuRepCustom.Name = "mnuRepCustom"
        Me.mnuRepCustom.Size = New System.Drawing.Size(164, 22)
        Me.mnuRepCustom.Text = "Custom Report"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(161, 6)
        '
        'mnuRepCust
        '
        Me.mnuRepCust.Name = "mnuRepCust"
        Me.mnuRepCust.Size = New System.Drawing.Size(164, 22)
        Me.mnuRepCust.Text = "Customer List"
        '
        'mnuRepEmp
        '
        Me.mnuRepEmp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRepEmpAll, Me.mnuRepEmpDetails})
        Me.mnuRepEmp.Name = "mnuRepEmp"
        Me.mnuRepEmp.Size = New System.Drawing.Size(164, 22)
        Me.mnuRepEmp.Text = "Employee"
        '
        'mnuRepEmpAll
        '
        Me.mnuRepEmpAll.Name = "mnuRepEmpAll"
        Me.mnuRepEmpAll.Size = New System.Drawing.Size(140, 22)
        Me.mnuRepEmpAll.Text = "List"
        '
        'mnuRepEmpDetails
        '
        Me.mnuRepEmpDetails.Name = "mnuRepEmpDetails"
        Me.mnuRepEmpDetails.Size = New System.Drawing.Size(140, 22)
        Me.mnuRepEmpDetails.Text = "Call Details"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(161, 6)
        '
        'mnuRepInventory
        '
        Me.mnuRepInventory.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRepInventoryList})
        Me.mnuRepInventory.Name = "mnuRepInventory"
        Me.mnuRepInventory.Size = New System.Drawing.Size(164, 22)
        Me.mnuRepInventory.Text = "Inventory"
        '
        'mnuRepInventoryList
        '
        Me.mnuRepInventoryList.Name = "mnuRepInventoryList"
        Me.mnuRepInventoryList.Size = New System.Drawing.Size(152, 22)
        Me.mnuRepInventoryList.Text = "Inventory List"
        '
        'mnuAdmin
        '
        Me.mnuAdmin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAdminOptions, Me.ToolStripSeparator5, Me.DatabaseToolStripMenuItem, Me.mnuData, Me.ToolStripMenuItem4, Me.mnuAdminLogout})
        Me.mnuAdmin.Name = "mnuAdmin"
        Me.mnuAdmin.Size = New System.Drawing.Size(104, 21)
        Me.mnuAdmin.Text = "&Administration"
        '
        'mnuAdminOptions
        '
        Me.mnuAdminOptions.Image = CType(resources.GetObject("mnuAdminOptions.Image"), System.Drawing.Image)
        Me.mnuAdminOptions.Name = "mnuAdminOptions"
        Me.mnuAdminOptions.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.mnuAdminOptions.Size = New System.Drawing.Size(184, 22)
        Me.mnuAdminOptions.Text = "&Settings"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(181, 6)
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDataCR, Me.mnuBakup, Me.mnuRestore})
        Me.DatabaseToolStripMenuItem.Image = CType(resources.GetObject("DatabaseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.DatabaseToolStripMenuItem.Text = "Data Management"
        '
        'mnuDataCR
        '
        Me.mnuDataCR.Name = "mnuDataCR"
        Me.mnuDataCR.Size = New System.Drawing.Size(190, 22)
        Me.mnuDataCR.Text = "Scan && Repair Data"
        '
        'mnuBakup
        '
        Me.mnuBakup.Name = "mnuBakup"
        Me.mnuBakup.Size = New System.Drawing.Size(190, 22)
        Me.mnuBakup.Text = "&Backup"
        '
        'mnuRestore
        '
        Me.mnuRestore.Name = "mnuRestore"
        Me.mnuRestore.Size = New System.Drawing.Size(190, 22)
        Me.mnuRestore.Text = "&Restore"
        '
        'mnuData
        '
        Me.mnuData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDataClosed, Me.mnuDataAll, Me.mnuDataEverything})
        Me.mnuData.Name = "mnuData"
        Me.mnuData.Size = New System.Drawing.Size(184, 22)
        Me.mnuData.Text = "Remove"
        '
        'mnuDataClosed
        '
        Me.mnuDataClosed.Name = "mnuDataClosed"
        Me.mnuDataClosed.Size = New System.Drawing.Size(198, 22)
        Me.mnuDataClosed.Text = "Remove Closed Calls"
        '
        'mnuDataAll
        '
        Me.mnuDataAll.Name = "mnuDataAll"
        Me.mnuDataAll.Size = New System.Drawing.Size(198, 22)
        Me.mnuDataAll.Text = "Remove All Calls"
        '
        'mnuDataEverything
        '
        Me.mnuDataEverything.Name = "mnuDataEverything"
        Me.mnuDataEverything.Size = New System.Drawing.Size(198, 22)
        Me.mnuDataEverything.Text = "Remove Everything"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(181, 6)
        '
        'mnuAdminLogout
        '
        Me.mnuAdminLogout.Name = "mnuAdminLogout"
        Me.mnuAdminLogout.Size = New System.Drawing.Size(184, 22)
        Me.mnuAdminLogout.Text = "&Log Out"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.mnuHelpAbout})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(47, 21)
        Me.HelpMenu.Text = "&Help"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Image = CType(resources.GetObject("ContentsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(177, 22)
        Me.mnuHelpAbout.Text = "&About ..."
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.mnuExit.Size = New System.Drawing.Size(40, 21)
        Me.mnuExit.Text = "E&xit"
        '
        'mnuRepCustAll
        '
        Me.mnuRepCustAll.Name = "mnuRepCustAll"
        Me.mnuRepCustAll.Size = New System.Drawing.Size(165, 22)
        Me.mnuRepCustAll.Text = "All"
        '
        'mnuRepCustOpenCalls
        '
        Me.mnuRepCustOpenCalls.Name = "mnuRepCustOpenCalls"
        Me.mnuRepCustOpenCalls.Size = New System.Drawing.Size(165, 22)
        Me.mnuRepCustOpenCalls.Text = "With Open Calls"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsBtnNew, Me.btnSearch, Me.ToolStripSeparator3, Me.tsBtnCust, Me.tsBtnEmp, Me.tsBtnInventory, Me.tsBtnService, Me.btnSettings, Me.ToolStripSeparator1, Me.tsBtnExit, Me.ToolStripButton1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1008, 31)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'tsBtnNew
        '
        Me.tsBtnNew.Image = CType(resources.GetObject("tsBtnNew.Image"), System.Drawing.Image)
        Me.tsBtnNew.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsBtnNew.Margin = New System.Windows.Forms.Padding(2, 1, 5, 2)
        Me.tsBtnNew.Name = "tsBtnNew"
        Me.tsBtnNew.Size = New System.Drawing.Size(87, 28)
        Me.tsBtnNew.Text = "New Call"
        Me.tsBtnNew.ToolTipText = "Add new service call"
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(94, 28)
        Me.btnSearch.Text = "View Calls"
        Me.btnSearch.ToolTipText = "View call list"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'tsBtnCust
        '
        Me.tsBtnCust.Image = CType(resources.GetObject("tsBtnCust.Image"), System.Drawing.Image)
        Me.tsBtnCust.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsBtnCust.Margin = New System.Windows.Forms.Padding(2, 1, 5, 2)
        Me.tsBtnCust.Name = "tsBtnCust"
        Me.tsBtnCust.Size = New System.Drawing.Size(92, 28)
        Me.tsBtnCust.Text = "Customer"
        Me.tsBtnCust.ToolTipText = "Customer management"
        '
        'tsBtnEmp
        '
        Me.tsBtnEmp.BackColor = System.Drawing.Color.Transparent
        Me.tsBtnEmp.Image = CType(resources.GetObject("tsBtnEmp.Image"), System.Drawing.Image)
        Me.tsBtnEmp.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsBtnEmp.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.tsBtnEmp.Name = "tsBtnEmp"
        Me.tsBtnEmp.Size = New System.Drawing.Size(93, 28)
        Me.tsBtnEmp.Text = "Employee"
        Me.tsBtnEmp.ToolTipText = "Employee management"
        '
        'tsBtnInventory
        '
        Me.tsBtnInventory.Image = CType(resources.GetObject("tsBtnInventory.Image"), System.Drawing.Image)
        Me.tsBtnInventory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnInventory.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.tsBtnInventory.Name = "tsBtnInventory"
        Me.tsBtnInventory.Size = New System.Drawing.Size(89, 28)
        Me.tsBtnInventory.Text = "Inventory"
        '
        'tsBtnService
        '
        Me.tsBtnService.Image = CType(resources.GetObject("tsBtnService.Image"), System.Drawing.Image)
        Me.tsBtnService.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsBtnService.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.tsBtnService.Name = "tsBtnService"
        Me.tsBtnService.Size = New System.Drawing.Size(108, 28)
        Me.tsBtnService.Text = "Service Type"
        Me.tsBtnService.ToolTipText = "Complaint management"
        '
        'btnSettings
        '
        Me.btnSettings.Image = CType(resources.GetObject("btnSettings.Image"), System.Drawing.Image)
        Me.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(82, 28)
        Me.btnSettings.Text = "Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'tsBtnExit
        '
        Me.tsBtnExit.BackColor = System.Drawing.Color.Transparent
        Me.tsBtnExit.Image = CType(resources.GetObject("tsBtnExit.Image"), System.Drawing.Image)
        Me.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsBtnExit.Margin = New System.Windows.Forms.Padding(2, 1, 0, 2)
        Me.tsBtnExit.Name = "tsBtnExit"
        Me.tsBtnExit.Size = New System.Drawing.Size(56, 28)
        Me.tsBtnExit.Text = "Exit"
        Me.tsBtnExit.ToolTipText = "Exit and close the program"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.Visible = False
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbCompanyName, Me.ToolStripStatusLabel2, Me.sbUserName, Me.sbSep1, Me.sbOpenCalls, Me.ToolStripStatusLabel1, Me.sbDate, Me.sbSep2, Me.sbTime})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 678)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1008, 24)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'sbCompanyName
        '
        Me.sbCompanyName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.sbCompanyName.Name = "sbCompanyName"
        Me.sbCompanyName.Size = New System.Drawing.Size(108, 19)
        Me.sbCompanyName.Text = "Company Name"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(4, 19)
        '
        'sbUserName
        '
        Me.sbUserName.Name = "sbUserName"
        Me.sbUserName.Size = New System.Drawing.Size(42, 19)
        Me.sbUserName.Text = "User :"
        '
        'sbSep1
        '
        Me.sbSep1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sbSep1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.sbSep1.Name = "sbSep1"
        Me.sbSep1.Size = New System.Drawing.Size(4, 19)
        '
        'sbOpenCalls
        '
        Me.sbOpenCalls.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.sbOpenCalls.Name = "sbOpenCalls"
        Me.sbOpenCalls.Size = New System.Drawing.Size(75, 19)
        Me.sbOpenCalls.Text = "Open Calls"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(4, 19)
        '
        'sbDate
        '
        Me.sbDate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.sbDate.Name = "sbDate"
        Me.sbDate.Size = New System.Drawing.Size(38, 19)
        Me.sbDate.Text = "Date"
        '
        'sbSep2
        '
        Me.sbSep2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sbSep2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.sbSep2.Name = "sbSep2"
        Me.sbSep2.Size = New System.Drawing.Size(4, 19)
        '
        'sbTime
        '
        Me.sbTime.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.sbTime.Name = "sbTime"
        Me.sbTime.Size = New System.Drawing.Size(38, 19)
        Me.sbTime.Text = "Time"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lvEmp, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 55)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1008, 345)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cboUser)
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Controls.Add(Me.btnSearchQuery)
        Me.Panel2.Controls.Add(Me.cboSearch)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.rbServiceType)
        Me.Panel2.Controls.Add(Me.rbArea)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.lvCalls)
        Me.Panel2.Location = New System.Drawing.Point(204, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(801, 339)
        Me.Panel2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(40, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 292
        Me.Label2.Text = "Current User:"
        '
        'cboUser
        '
        Me.cboUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUser.FormattingEnabled = True
        Me.cboUser.Location = New System.Drawing.Point(115, 4)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(169, 21)
        Me.cboUser.TabIndex = 291
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(742, 4)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(50, 23)
        Me.btnReset.TabIndex = 290
        Me.btnReset.Text = "Reset"
        '
        'btnSearchQuery
        '
        Me.btnSearchQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchQuery.Location = New System.Drawing.Point(690, 4)
        Me.btnSearchQuery.Name = "btnSearchQuery"
        Me.btnSearchQuery.Size = New System.Drawing.Size(50, 23)
        Me.btnSearchQuery.TabIndex = 289
        Me.btnSearchQuery.Text = "Search"
        '
        'cboSearch
        '
        Me.cboSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearch.FormattingEnabled = True
        Me.cboSearch.Location = New System.Drawing.Point(514, 4)
        Me.cboSearch.Name = "cboSearch"
        Me.cboSearch.Size = New System.Drawing.Size(169, 21)
        Me.cboSearch.TabIndex = 288
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(293, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 287
        Me.Label4.Text = "Search:"
        '
        'rbServiceType
        '
        Me.rbServiceType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbServiceType.AutoSize = True
        Me.rbServiceType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbServiceType.Location = New System.Drawing.Point(418, 5)
        Me.rbServiceType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbServiceType.Name = "rbServiceType"
        Me.rbServiceType.Size = New System.Drawing.Size(88, 17)
        Me.rbServiceType.TabIndex = 38
        Me.rbServiceType.Text = "Service Type"
        Me.rbServiceType.UseVisualStyleBackColor = True
        '
        'rbArea
        '
        Me.rbArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbArea.AutoSize = True
        Me.rbArea.Checked = True
        Me.rbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbArea.Location = New System.Drawing.Point(346, 5)
        Me.rbArea.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rbArea.Name = "rbArea"
        Me.rbArea.Size = New System.Drawing.Size(47, 17)
        Me.rbArea.TabIndex = 37
        Me.rbArea.TabStop = True
        Me.rbArea.Text = "Area"
        Me.rbArea.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(2, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(197, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Open Calls (Not Assigned) - Surat"
        '
        'lvCalls
        '
        Me.lvCalls.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCalls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvCalls.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clCode, Me.clRefNo, Me.clCustName, Me.clServiceType, Me.clCallDesc, Me.clWarrantyDate, Me.clLogDate, Me.clCallTime, Me.clArea})
        Me.lvCalls.FullRowSelect = True
        Me.lvCalls.GridLines = True
        Me.lvCalls.HideSelection = False
        Me.lvCalls.Location = New System.Drawing.Point(0, 33)
        Me.lvCalls.MultiSelect = False
        Me.lvCalls.Name = "lvCalls"
        Me.lvCalls.Size = New System.Drawing.Size(801, 306)
        Me.lvCalls.TabIndex = 2
        Me.lvCalls.UseCompatibleStateImageBehavior = False
        Me.lvCalls.View = System.Windows.Forms.View.Details
        '
        'clCode
        '
        Me.clCode.Text = "Code"
        Me.clCode.Width = 0
        '
        'clRefNo
        '
        Me.clRefNo.Text = "Ref. No"
        Me.clRefNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.clRefNo.Width = 80
        '
        'clCustName
        '
        Me.clCustName.Text = "Customer Name"
        Me.clCustName.Width = 150
        '
        'clServiceType
        '
        Me.clServiceType.Text = "Service Type"
        Me.clServiceType.Width = 150
        '
        'clCallDesc
        '
        Me.clCallDesc.Text = "Call Description"
        Me.clCallDesc.Width = 100
        '
        'clWarrantyDate
        '
        Me.clWarrantyDate.Text = "Warranty/AMC"
        Me.clWarrantyDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.clWarrantyDate.Width = 100
        '
        'clLogDate
        '
        Me.clLogDate.Text = "Log Date"
        Me.clLogDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.clLogDate.Width = 110
        '
        'clCallTime
        '
        Me.clCallTime.Text = "Log Time"
        Me.clCallTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.clCallTime.Width = 110
        '
        'clArea
        '
        Me.clArea.Text = "Area"
        Me.clArea.Width = 100
        '
        'lvEmp
        '
        Me.lvEmp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvEmp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader11, Me.ColumnHeader16})
        Me.lvEmp.FullRowSelect = True
        Me.lvEmp.GridLines = True
        Me.lvEmp.HideSelection = False
        Me.lvEmp.Location = New System.Drawing.Point(3, 3)
        Me.lvEmp.Name = "lvEmp"
        Me.lvEmp.Size = New System.Drawing.Size(195, 339)
        Me.lvEmp.TabIndex = 0
        Me.lvEmp.UseCompatibleStateImageBehavior = False
        Me.lvEmp.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Code"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Employee"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Assigned "
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader11.Width = 70
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Solved"
        Me.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader16.Width = 70
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.panEmpCust, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 403)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1008, 274)
        Me.TableLayoutPanel2.TabIndex = 11
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.lvToday)
        Me.Panel4.Location = New System.Drawing.Point(204, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(801, 268)
        Me.Panel4.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Call in Process"
        '
        'lvToday
        '
        Me.lvToday.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvToday.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clACode, Me.clARefNo, Me.clCustomerName, Me.colPService, Me.colPWarranty, Me.clAArea, Me.clStartTime, Me.clTimeElapsed, Me.clAssignedTo})
        Me.lvToday.FullRowSelect = True
        Me.lvToday.GridLines = True
        Me.lvToday.HideSelection = False
        Me.lvToday.Location = New System.Drawing.Point(5, 16)
        Me.lvToday.Name = "lvToday"
        Me.lvToday.Size = New System.Drawing.Size(793, 249)
        Me.lvToday.TabIndex = 1
        Me.lvToday.UseCompatibleStateImageBehavior = False
        Me.lvToday.View = System.Windows.Forms.View.Details
        '
        'clACode
        '
        Me.clACode.Text = "Code"
        Me.clACode.Width = 0
        '
        'clARefNo
        '
        Me.clARefNo.Text = "Ref No."
        Me.clARefNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.clARefNo.Width = 80
        '
        'clCustomerName
        '
        Me.clCustomerName.Text = "Customer Name"
        Me.clCustomerName.Width = 150
        '
        'colPService
        '
        Me.colPService.Text = "Service Type"
        Me.colPService.Width = 100
        '
        'colPWarranty
        '
        Me.colPWarranty.Text = "Warranty/AMC"
        Me.colPWarranty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colPWarranty.Width = 100
        '
        'clAArea
        '
        Me.clAArea.Text = "Area"
        Me.clAArea.Width = 100
        '
        'clStartTime
        '
        Me.clStartTime.Text = "Start Time"
        Me.clStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.clStartTime.Width = 140
        '
        'clTimeElapsed
        '
        Me.clTimeElapsed.Text = "Time Elapsed"
        Me.clTimeElapsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.clTimeElapsed.Width = 130
        '
        'clAssignedTo
        '
        Me.clAssignedTo.Text = "Assinged To"
        Me.clAssignedTo.Width = 120
        '
        'panEmpCust
        '
        Me.panEmpCust.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panEmpCust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panEmpCust.Controls.Add(Me.pnlCallStatus)
        Me.panEmpCust.Location = New System.Drawing.Point(3, 3)
        Me.panEmpCust.Name = "panEmpCust"
        Me.panEmpCust.Size = New System.Drawing.Size(195, 268)
        Me.panEmpCust.TabIndex = 12
        '
        'pnlCallStatus
        '
        Me.pnlCallStatus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlCallStatus.Controls.Add(Me.btnCAP)
        Me.pnlCallStatus.Controls.Add(Me.Label35)
        Me.pnlCallStatus.Controls.Add(Me.lblAwaitingInfo)
        Me.pnlCallStatus.Controls.Add(Me.btnCAI)
        Me.pnlCallStatus.Controls.Add(Me.Label28)
        Me.pnlCallStatus.Controls.Add(Me.btnCH)
        Me.pnlCallStatus.Controls.Add(Me.Label26)
        Me.pnlCallStatus.Controls.Add(Me.Label29)
        Me.pnlCallStatus.Controls.Add(Me.btnCNA)
        Me.pnlCallStatus.Controls.Add(Me.Label25)
        Me.pnlCallStatus.Controls.Add(Me.lblCallNotAssigned)
        Me.pnlCallStatus.Controls.Add(Me.lblTodayCall)
        Me.pnlCallStatus.Controls.Add(Me.btnCP)
        Me.pnlCallStatus.Controls.Add(Me.Label24)
        Me.pnlCallStatus.Controls.Add(Me.Label33)
        Me.pnlCallStatus.Controls.Add(Me.lblOnHold)
        Me.pnlCallStatus.Controls.Add(Me.btnCToday)
        Me.pnlCallStatus.Controls.Add(Me.lblAwaitingParts)
        Me.pnlCallStatus.Controls.Add(Me.lblOpenCalls)
        Me.pnlCallStatus.Location = New System.Drawing.Point(-1, 8)
        Me.pnlCallStatus.Name = "pnlCallStatus"
        Me.pnlCallStatus.Size = New System.Drawing.Size(195, 261)
        Me.pnlCallStatus.TabIndex = 24
        '
        'btnCAP
        '
        Me.btnCAP.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCAP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnCAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCAP.Location = New System.Drawing.Point(171, 213)
        Me.btnCAP.Name = "btnCAP"
        Me.btnCAP.Size = New System.Drawing.Size(21, 17)
        Me.btnCAP.TabIndex = 23
        Me.btnCAP.Text = "..."
        '
        'Label35
        '
        Me.Label35.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(69, 7)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(80, 13)
        Me.Label35.TabIndex = 9
        Me.Label35.Text = "Call(s) status"
        '
        'lblAwaitingInfo
        '
        Me.lblAwaitingInfo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAwaitingInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblAwaitingInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAwaitingInfo.Location = New System.Drawing.Point(110, 177)
        Me.lblAwaitingInfo.Name = "lblAwaitingInfo"
        Me.lblAwaitingInfo.Size = New System.Drawing.Size(54, 17)
        Me.lblAwaitingInfo.TabIndex = 15
        Me.lblAwaitingInfo.Text = "2"
        Me.lblAwaitingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCAI
        '
        Me.btnCAI.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCAI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnCAI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCAI.Location = New System.Drawing.Point(171, 177)
        Me.btnCAI.Name = "btnCAI"
        Me.btnCAI.Size = New System.Drawing.Size(21, 17)
        Me.btnCAI.TabIndex = 22
        Me.btnCAI.Text = "..."
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(3, 106)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(101, 13)
        Me.Label28.TabIndex = 3
        Me.Label28.Text = "Call(s) not assigned:"
        '
        'btnCH
        '
        Me.btnCH.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnCH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCH.Location = New System.Drawing.Point(171, 141)
        Me.btnCH.Name = "btnCH"
        Me.btnCH.Size = New System.Drawing.Size(21, 17)
        Me.btnCH.TabIndex = 21
        Me.btnCH.Text = "..."
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 70)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(92, 13)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "Call(s) in progress:"
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(3, 178)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(100, 13)
        Me.Label29.TabIndex = 14
        Me.Label29.Text = "Call(s) awaiting info:"
        '
        'btnCNA
        '
        Me.btnCNA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCNA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnCNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCNA.Location = New System.Drawing.Point(171, 105)
        Me.btnCNA.Name = "btnCNA"
        Me.btnCNA.Size = New System.Drawing.Size(21, 17)
        Me.btnCNA.TabIndex = 20
        Me.btnCNA.Text = "..."
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 214)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(106, 13)
        Me.Label25.TabIndex = 16
        Me.Label25.Text = "Call(s) awaiting parts:"
        '
        'lblCallNotAssigned
        '
        Me.lblCallNotAssigned.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCallNotAssigned.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCallNotAssigned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCallNotAssigned.Location = New System.Drawing.Point(110, 105)
        Me.lblCallNotAssigned.Name = "lblCallNotAssigned"
        Me.lblCallNotAssigned.Size = New System.Drawing.Size(54, 17)
        Me.lblCallNotAssigned.TabIndex = 6
        Me.lblCallNotAssigned.Text = "2"
        Me.lblCallNotAssigned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTodayCall
        '
        Me.lblTodayCall.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTodayCall.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTodayCall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTodayCall.Location = New System.Drawing.Point(110, 33)
        Me.lblTodayCall.Name = "lblTodayCall"
        Me.lblTodayCall.Size = New System.Drawing.Size(54, 17)
        Me.lblTodayCall.TabIndex = 4
        Me.lblTodayCall.Text = "10"
        Me.lblTodayCall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCP
        '
        Me.btnCP.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCP.Location = New System.Drawing.Point(171, 69)
        Me.btnCP.Name = "btnCP"
        Me.btnCP.Size = New System.Drawing.Size(21, 17)
        Me.btnCP.TabIndex = 19
        Me.btnCP.Text = "..."
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 34)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(79, 13)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Call(s) of today:"
        '
        'Label33
        '
        Me.Label33.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(3, 142)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(76, 13)
        Me.Label33.TabIndex = 12
        Me.Label33.Text = "Call(s) on hold:"
        '
        'lblOnHold
        '
        Me.lblOnHold.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOnHold.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblOnHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOnHold.Location = New System.Drawing.Point(110, 141)
        Me.lblOnHold.Name = "lblOnHold"
        Me.lblOnHold.Size = New System.Drawing.Size(54, 17)
        Me.lblOnHold.TabIndex = 13
        Me.lblOnHold.Text = "2"
        Me.lblOnHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCToday
        '
        Me.btnCToday.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnCToday.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCToday.Location = New System.Drawing.Point(171, 33)
        Me.btnCToday.Name = "btnCToday"
        Me.btnCToday.Size = New System.Drawing.Size(21, 17)
        Me.btnCToday.TabIndex = 18
        Me.btnCToday.Text = "..."
        '
        'lblAwaitingParts
        '
        Me.lblAwaitingParts.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAwaitingParts.BackColor = System.Drawing.Color.Gray
        Me.lblAwaitingParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAwaitingParts.Location = New System.Drawing.Point(110, 213)
        Me.lblAwaitingParts.Name = "lblAwaitingParts"
        Me.lblAwaitingParts.Size = New System.Drawing.Size(54, 17)
        Me.lblAwaitingParts.TabIndex = 17
        Me.lblAwaitingParts.Text = "2"
        Me.lblAwaitingParts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOpenCalls
        '
        Me.lblOpenCalls.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOpenCalls.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOpenCalls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpenCalls.Location = New System.Drawing.Point(110, 69)
        Me.lblOpenCalls.Name = "lblOpenCalls"
        Me.lblOpenCalls.Size = New System.Drawing.Size(54, 17)
        Me.lblOpenCalls.TabIndex = 5
        Me.lblOpenCalls.Text = "45"
        Me.lblOpenCalls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPopEdit, Me.mnuPopDelete, Me.ToolStripMenuItem2, Me.mnuPopPrint, Me.mnuPopAssign})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(140, 98)
        '
        'mnuPopEdit
        '
        Me.mnuPopEdit.Image = CType(resources.GetObject("mnuPopEdit.Image"), System.Drawing.Image)
        Me.mnuPopEdit.Name = "mnuPopEdit"
        Me.mnuPopEdit.Size = New System.Drawing.Size(139, 22)
        Me.mnuPopEdit.Text = "Edit"
        '
        'mnuPopDelete
        '
        Me.mnuPopDelete.Image = CType(resources.GetObject("mnuPopDelete.Image"), System.Drawing.Image)
        Me.mnuPopDelete.Name = "mnuPopDelete"
        Me.mnuPopDelete.Size = New System.Drawing.Size(139, 22)
        Me.mnuPopDelete.Text = "Delete"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(136, 6)
        '
        'mnuPopPrint
        '
        Me.mnuPopPrint.Image = CType(resources.GetObject("mnuPopPrint.Image"), System.Drawing.Image)
        Me.mnuPopPrint.Name = "mnuPopPrint"
        Me.mnuPopPrint.Size = New System.Drawing.Size(139, 22)
        Me.mnuPopPrint.Text = "Print"
        '
        'mnuPopAssign
        '
        Me.mnuPopAssign.Name = "mnuPopAssign"
        Me.mnuPopAssign.Size = New System.Drawing.Size(139, 22)
        Me.mnuPopAssign.Text = "Assign Call"
        '
        'lblUserCode
        '
        Me.lblUserCode.AutoSize = True
        Me.lblUserCode.Location = New System.Drawing.Point(891, 33)
        Me.lblUserCode.Name = "lblUserCode"
        Me.lblUserCode.Size = New System.Drawing.Size(13, 13)
        Me.lblUserCode.TabIndex = 12
        Me.lblUserCode.Text = "0"
        Me.lblUserCode.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50000
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 10000
        '
        'MDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1008, 702)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.lblUserCode)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MDIMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Service Call Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.panEmpCust.ResumeLayout(False)
        Me.pnlCallStatus.ResumeLayout(False)
        Me.pnlCallStatus.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdminOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsBtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents sbCompanyName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents tsBtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsBtnCust As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnEmp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuServiceNewCall As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSerice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuServiceOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuServiceSolved As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuMasters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMasterCust As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMastEmp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepToday As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdmin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lvEmp As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDataCR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBakup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCalls As System.Windows.Forms.ListView
    Friend WithEvents clCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents clRefNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents clCustName As System.Windows.Forms.ColumnHeader
    Friend WithEvents clLogDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents clCallTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuServiceViewAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuMastService As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsBtnService As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRepCustom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sbSep1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sbDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sbSep2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sbTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sbOpenCalls As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuPopEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPopDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPopPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mnuData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDataClosed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDataAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDataEverything As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRestore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuMastInventory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsBtnInventory As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRepCust As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepCustAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepCustOpenCalls As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepCustSolvedCalls As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepEmp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepEmpAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepEmpDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRepInventory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRepInventoryList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblUserCode As System.Windows.Forms.Label
    Friend WithEvents sbUserName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAdminLogout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvToday As System.Windows.Forms.ListView
    Friend WithEvents clACode As System.Windows.Forms.ColumnHeader
    Friend WithEvents clARefNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents clCustomerName As System.Windows.Forms.ColumnHeader
    Friend WithEvents clStartTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents clTimeElapsed As System.Windows.Forms.ColumnHeader
    Friend WithEvents clAssignedTo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents clServiceType As ColumnHeader
    Friend WithEvents clCallDesc As ColumnHeader
    Friend WithEvents clArea As ColumnHeader
    Friend WithEvents clWarrantyDate As ColumnHeader
    Friend WithEvents rbServiceType As RadioButton
    Friend WithEvents rbArea As RadioButton
    Friend WithEvents cboSearch As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents btnSearchQuery As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents clAArea As ColumnHeader
    Friend WithEvents Label2 As Label
    Friend WithEvents cboUser As ComboBox
    Friend WithEvents panEmpCust As Panel
    Friend WithEvents pnlCallStatus As Panel
    Friend WithEvents btnCAP As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents lblAwaitingInfo As Label
    Friend WithEvents btnCAI As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents btnCH As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents btnCNA As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents lblCallNotAssigned As Label
    Friend WithEvents lblTodayCall As Label
    Friend WithEvents btnCP As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents lblOnHold As Label
    Friend WithEvents btnCToday As Label
    Friend WithEvents lblAwaitingParts As Label
    Friend WithEvents lblOpenCalls As Label
    Friend WithEvents colPService As ColumnHeader
    Friend WithEvents colPWarranty As ColumnHeader
    Friend WithEvents mnuPopAssign As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer2 As Timer
End Class
