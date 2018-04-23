' Developer Express Code Central Example:
' WorkspaceManager - How to use WorkspaceManager for capturing, applying, saving and loading workspaces
' 
' This example demonstrates how to use the Workspace Manager
' (https://documentation.devexpress.com/WindowsForms/CustomDocument17674.aspx) for
' capturing, applying, saving and loading workspaces and shows different
' Transition Types in action. You can find the general information about the
' WorkspaceManager in our documentation: Workspace Manager
' (https://documentation.devexpress.com/WindowsForms/CustomDocument17674.aspx).
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=T190543

Namespace T190543
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
            Dim pushTransition2 As New DevExpress.Utils.Animation.PushTransition()
            Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
            Me.saveItem = New DevExpress.XtraBars.BarButtonItem()
            Me.loadItem = New DevExpress.XtraBars.BarButtonItem()
            Me.captureItem = New DevExpress.XtraBars.BarButtonItem()
            Me.applyItem = New DevExpress.XtraBars.BarButtonItem()
            Me.workspaceNameItem = New DevExpress.XtraBars.BarEditItem()
            Me.repositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
            Me.selectWorkSpaceItem = New DevExpress.XtraBars.BarEditItem()
            Me.repositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
            Me.transitionItem = New DevExpress.XtraBars.BarEditItem()
            Me.repositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
            Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.ribbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.repositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
            Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
            Me.documentManager1 = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
            Me.tabbedView1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
            Me.documentGroup1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(Me.components)
            Me.document1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(Me.components)
            Me.document2 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(Me.components)
            Me.document3 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(Me.components)
            Me.dockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
            Me.workspaceManager1 = New DevExpress.Utils.WorkspaceManager()
            Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
            Me.dockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
            Me.dockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
            Me.dockPanel2 = New DevExpress.XtraBars.Docking.DockPanel()
            Me.dockPanel2_Container = New DevExpress.XtraBars.Docking.ControlContainer()
            DirectCast(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.repositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.repositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.repositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.repositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.documentManager1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.tabbedView1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.documentGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.document1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.document2, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.document3, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.dockPanel1.SuspendLayout()
            Me.dockPanel2.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' ribbonControl1
            ' 
            Me.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Orange
            Me.ribbonControl1.ExpandCollapseItem.Id = 0
            Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.saveItem, Me.loadItem, Me.captureItem, Me.applyItem, Me.workspaceNameItem, Me.selectWorkSpaceItem, Me.transitionItem})
            Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
            Me.ribbonControl1.MaxItemId = 9
            Me.ribbonControl1.Name = "ribbonControl1"
            Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPage1})
            Me.ribbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemTextEdit1, Me.repositoryItemTextEdit2, Me.repositoryItemLookUpEdit1, Me.repositoryItemComboBox1})
            Me.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013
            Me.ribbonControl1.Size = New System.Drawing.Size(1202, 144)
            ' 
            ' saveItem
            ' 
            Me.saveItem.Caption = "Save Workspace"
            Me.saveItem.Glyph = (DirectCast(resources.GetObject("saveItem.Glyph"), System.Drawing.Image))
            Me.saveItem.Id = 1
            Me.saveItem.LargeGlyph = (DirectCast(resources.GetObject("saveItem.LargeGlyph"), System.Drawing.Image))
            Me.saveItem.Name = "saveItem"
            ' 
            ' loadItem
            ' 
            Me.loadItem.Caption = "Load Workspace"
            Me.loadItem.Glyph = (DirectCast(resources.GetObject("loadItem.Glyph"), System.Drawing.Image))
            Me.loadItem.Id = 2
            Me.loadItem.LargeGlyph = (DirectCast(resources.GetObject("loadItem.LargeGlyph"), System.Drawing.Image))
            Me.loadItem.Name = "loadItem"
            ' 
            ' captureItem
            ' 
            Me.captureItem.Caption = "Capture Workspace"
            Me.captureItem.Glyph = (DirectCast(resources.GetObject("captureItem.Glyph"), System.Drawing.Image))
            Me.captureItem.Id = 3
            Me.captureItem.LargeGlyph = (DirectCast(resources.GetObject("captureItem.LargeGlyph"), System.Drawing.Image))
            Me.captureItem.Name = "captureItem"
            ' 
            ' applyItem
            ' 
            Me.applyItem.Caption = "Apply Workspace"
            Me.applyItem.Glyph = (DirectCast(resources.GetObject("applyItem.Glyph"), System.Drawing.Image))
            Me.applyItem.Id = 4
            Me.applyItem.LargeGlyph = (DirectCast(resources.GetObject("applyItem.LargeGlyph"), System.Drawing.Image))
            Me.applyItem.Name = "applyItem"
            ' 
            ' workspaceNameItem
            ' 
            Me.workspaceNameItem.Caption = "Workspace Name"
            Me.workspaceNameItem.Edit = Me.repositoryItemTextEdit2
            Me.workspaceNameItem.Id = 6
            Me.workspaceNameItem.Name = "workspaceNameItem"
            Me.workspaceNameItem.Width = 100
            ' 
            ' repositoryItemTextEdit2
            ' 
            Me.repositoryItemTextEdit2.AutoHeight = False
            Me.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2"
            ' 
            ' selectWorkSpaceItem
            ' 
            Me.selectWorkSpaceItem.Caption = "Select Workspace"
            Me.selectWorkSpaceItem.Edit = Me.repositoryItemLookUpEdit1
            Me.selectWorkSpaceItem.Id = 7
            Me.selectWorkSpaceItem.Name = "selectWorkSpaceItem"
            Me.selectWorkSpaceItem.Width = 97
            ' 
            ' repositoryItemLookUpEdit1
            ' 
            Me.repositoryItemLookUpEdit1.AutoHeight = False
            Me.repositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1"
            ' 
            ' transitionItem
            ' 
            Me.transitionItem.Caption = "Transition Type"
            Me.transitionItem.Edit = Me.repositoryItemComboBox1
            Me.transitionItem.Id = 8
            Me.transitionItem.Name = "transitionItem"
            Me.transitionItem.Width = 108
            ' 
            ' repositoryItemComboBox1
            ' 
            Me.repositoryItemComboBox1.AutoHeight = False
            Me.repositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.repositoryItemComboBox1.Name = "repositoryItemComboBox1"
            ' 
            ' ribbonPage1
            ' 
            Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.ribbonPageGroup1, Me.ribbonPageGroup2})
            Me.ribbonPage1.Name = "ribbonPage1"
            Me.ribbonPage1.Text = "WorkSpace"
            ' 
            ' ribbonPageGroup1
            ' 
            Me.ribbonPageGroup1.ItemLinks.Add(Me.captureItem)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.applyItem)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.saveItem)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.loadItem)
            Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
            Me.ribbonPageGroup1.Text = "Main Group"
            ' 
            ' ribbonPageGroup2
            ' 
            Me.ribbonPageGroup2.ItemLinks.Add(Me.workspaceNameItem)
            Me.ribbonPageGroup2.ItemLinks.Add(Me.selectWorkSpaceItem)
            Me.ribbonPageGroup2.ItemLinks.Add(Me.transitionItem)
            Me.ribbonPageGroup2.Name = "ribbonPageGroup2"
            Me.ribbonPageGroup2.Text = "Workspace Settings"
            ' 
            ' repositoryItemTextEdit1
            ' 
            Me.repositoryItemTextEdit1.AutoHeight = False
            Me.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1"
            ' 
            ' documentManager1
            ' 
            Me.documentManager1.ContainerControl = Me
            Me.documentManager1.MenuManager = Me.ribbonControl1
            Me.documentManager1.View = Me.tabbedView1
            Me.documentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() { Me.tabbedView1})
            ' 
            ' tabbedView1
            ' 
            Me.tabbedView1.DocumentGroups.AddRange(New DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup() { Me.documentGroup1})
            Me.tabbedView1.Documents.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseDocument() { Me.document1, Me.document2, Me.document3})
            ' 
            ' documentGroup1
            ' 
            Me.documentGroup1.Items.AddRange(New DevExpress.XtraBars.Docking2010.Views.Tabbed.Document() { Me.document1, Me.document2, Me.document3})
            ' 
            ' document1
            ' 
            Me.document1.Caption = "Main Page"
            Me.document1.ControlName = "document1"
            ' 
            ' document2
            ' 
            Me.document2.Caption = "Page 1"
            Me.document2.ControlName = "document2"
            ' 
            ' document3
            ' 
            Me.document3.Caption = "Page 2"
            Me.document3.ControlName = "document3"
            ' 
            ' dockManager1
            ' 
            Me.dockManager1.Form = Me
            Me.dockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() { Me.dockPanel1, Me.dockPanel2})
            Me.dockManager1.TopZIndexControls.AddRange(New String() { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane"})
            ' 
            ' workspaceManager1
            ' 
            Me.workspaceManager1.TargetControl = Me
            Me.workspaceManager1.TransitionType = pushTransition2
            ' 
            ' openFileDialog1
            ' 
            Me.openFileDialog1.Filter = "XML Documents (*.xml)|*.xml"
            ' 
            ' saveFileDialog1
            ' 
            Me.saveFileDialog1.Filter = "XML Documents (*.xml)|*.xml"
            ' 
            ' dockPanel1
            ' 
            Me.dockPanel1.Controls.Add(Me.dockPanel1_Container)
            Me.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
            Me.dockPanel1.ID = New System.Guid("1f6aa3e8-067f-4a56-ab86-b3009497bdc1")
            Me.dockPanel1.Location = New System.Drawing.Point(0, 144)
            Me.dockPanel1.Name = "dockPanel1"
            Me.dockPanel1.OriginalSize = New System.Drawing.Size(200, 200)
            Me.dockPanel1.Size = New System.Drawing.Size(200, 495)
            Me.dockPanel1.Text = "dockPanel1"
            ' 
            ' dockPanel1_Container
            ' 
            Me.dockPanel1_Container.Location = New System.Drawing.Point(4, 23)
            Me.dockPanel1_Container.Name = "dockPanel1_Container"
            Me.dockPanel1_Container.Size = New System.Drawing.Size(192, 468)
            Me.dockPanel1_Container.TabIndex = 0
            ' 
            ' dockPanel2
            ' 
            Me.dockPanel2.Controls.Add(Me.dockPanel2_Container)
            Me.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right
            Me.dockPanel2.ID = New System.Guid("e458b513-b38a-4138-8e75-bc8ec80b8147")
            Me.dockPanel2.Location = New System.Drawing.Point(1002, 144)
            Me.dockPanel2.Name = "dockPanel2"
            Me.dockPanel2.OriginalSize = New System.Drawing.Size(200, 200)
            Me.dockPanel2.Size = New System.Drawing.Size(200, 495)
            Me.dockPanel2.Text = "dockPanel2"
            ' 
            ' dockPanel2_Container
            ' 
            Me.dockPanel2_Container.Location = New System.Drawing.Point(4, 23)
            Me.dockPanel2_Container.Name = "dockPanel2_Container"
            Me.dockPanel2_Container.Size = New System.Drawing.Size(192, 468)
            Me.dockPanel2_Container.TabIndex = 0
            ' 
            ' Form1
            ' 
            Me.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1202, 639)
            Me.Controls.Add(Me.dockPanel2)
            Me.Controls.Add(Me.dockPanel1)
            Me.Controls.Add(Me.ribbonControl1)
            Me.Name = "Form1"
            Me.Ribbon = Me.ribbonControl1
            Me.Text = "Form1"
            DirectCast(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.repositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.repositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.repositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.repositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.documentManager1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.tabbedView1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.documentGroup1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.document1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.document2, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.document3, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dockManager1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.dockPanel1.ResumeLayout(False)
            Me.dockPanel2.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
        Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
        Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
        Private WithEvents saveItem As DevExpress.XtraBars.BarButtonItem
        Private WithEvents loadItem As DevExpress.XtraBars.BarButtonItem
        Private WithEvents captureItem As DevExpress.XtraBars.BarButtonItem
        Private WithEvents applyItem As DevExpress.XtraBars.BarButtonItem
        Private documentManager1 As DevExpress.XtraBars.Docking2010.DocumentManager
        Private WithEvents tabbedView1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
        Private documentGroup1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup
        Private document1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.Document
        Private document2 As DevExpress.XtraBars.Docking2010.Views.Tabbed.Document
        Private document3 As DevExpress.XtraBars.Docking2010.Views.Tabbed.Document
        Private dockManager1 As DevExpress.XtraBars.Docking.DockManager
        Private workspaceManager1 As DevExpress.Utils.WorkspaceManager
        Private workspaceNameItem As DevExpress.XtraBars.BarEditItem
        Private repositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Private ribbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private repositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Private selectWorkSpaceItem As DevExpress.XtraBars.BarEditItem
        Private repositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
        Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog
        Private transitionItem As DevExpress.XtraBars.BarEditItem
        Private repositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Private dockPanel2 As DevExpress.XtraBars.Docking.DockPanel
        Private dockPanel2_Container As DevExpress.XtraBars.Docking.ControlContainer
        Private dockPanel1 As DevExpress.XtraBars.Docking.DockPanel
        Private dockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    End Class
End Namespace

