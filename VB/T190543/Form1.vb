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

Imports DevExpress.Utils.Animation
Imports DevExpress.XtraEditors
Imports System
Imports System.Linq
Imports System.Windows.Forms

Namespace T190543
    Partial Public Class Form1
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013")
            Init()
        End Sub

        Private Sub Init()
            Me.repositoryItemLookUpEdit1.DataSource = Me.workspaceManager1.Workspaces
            Me.repositoryItemLookUpEdit1.DisplayMember = "Name"
            Me.repositoryItemLookUpEdit1.ValueMember = "Name"

            Me.repositoryItemLookUpEdit1.PopulateColumns()
            Me.repositoryItemLookUpEdit1.Columns(1).Visible = False
            Me.repositoryItemLookUpEdit1.Columns(2).Visible = False

            Me.selectWorkSpaceItem.EditValue = "Default"

            Me.workspaceManager1.CloseStreamOnWorkspaceSaving = DevExpress.Utils.DefaultBoolean.True
            Me.workspaceManager1.CloseStreamOnWorkspaceLoading = DevExpress.Utils.DefaultBoolean.True
            Me.workspaceManager1.CaptureWorkspace("Default")

            Me.repositoryItemComboBox1.Items.AddRange(System.Enum.GetValues(GetType(TransitionType)))
            AddHandler Me.repositoryItemComboBox1.EditValueChanged, AddressOf repositoryItemComboBox1_EditValueChanged

            Me.transitionItem.EditValue = TransitionType.Push
        End Sub

        #Region "Events"
        Private Sub tabbedView1_QueryControl(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs) Handles tabbedView1.QueryControl
            e.Control = New Control()
        End Sub

        Private Sub repositoryItemComboBox1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim edit As ComboBoxEdit = TryCast(sender, ComboBoxEdit)
            If edit IsNot Nothing Then
                Dim value As TransitionType = CType(edit.EditValue, TransitionType)
                Dim transition As BaseTransition = Nothing
                Select Case value
                    Case TransitionType.Clock
                        transition = New DevExpress.Utils.Animation.ClockTransition()
                    Case TransitionType.Comb
                        transition = New DevExpress.Utils.Animation.CombTransition()
                    Case TransitionType.Cover
                        transition = New DevExpress.Utils.Animation.CoverTransition()
                    Case TransitionType.Dissolve
                        transition = New DevExpress.Utils.Animation.DissolveTransition()
                    Case TransitionType.Fade
                        transition = New DevExpress.Utils.Animation.FadeTransition()
                    Case TransitionType.Push
                        transition = New DevExpress.Utils.Animation.PushTransition()
                    Case TransitionType.Shape
                        transition = New DevExpress.Utils.Animation.ShapeTransition()
                    Case TransitionType.SlideFade
                        transition = New DevExpress.Utils.Animation.SlideFadeTransition()
                End Select
                Me.workspaceManager1.TransitionType = transition
            End If
        End Sub

        Private Sub captureItem_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles captureItem.ItemClick
            If Me.workspaceNameItem.EditValue IsNot Nothing Then
                Dim workspaceName As String = Me.workspaceNameItem.EditValue.ToString()
                Dim item = Me.workspaceManager1.Workspaces.Where(Function(i) i.Name = workspaceName).FirstOrDefault()
                If (Not String.IsNullOrEmpty(workspaceName)) AndAlso item Is Nothing Then
                    Me.workspaceManager1.CaptureWorkspace(workspaceName)
                End If
            End If
        End Sub

        Private Sub applyItem_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles applyItem.ItemClick
            If Me.selectWorkSpaceItem.EditValue IsNot Nothing Then
                Dim selectWorkSpaceItem As String = Me.selectWorkSpaceItem.EditValue.ToString()
                If Not String.IsNullOrEmpty(selectWorkSpaceItem) Then
                    Me.workspaceManager1.ApplyWorkspace(selectWorkSpaceItem)
                End If
            End If
        End Sub

        Private Sub saveItem_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles saveItem.ItemClick
            Dim workspaceName As String = String.Empty
            Me.saveFileDialog1.InitialDirectory = "C:\Users\Public\Documents\"
            If XtraMessageBox.Show("Capture a new workspace or use an existing one? Click 'Yes' to capture a new workspace or 'No' to save the selected workspace.", "Create new workspace?", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                If Me.saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    workspaceName = System.IO.Path.GetFileNameWithoutExtension(Me.saveFileDialog1.FileName)
                    Me.workspaceManager1.CaptureWorkspace(workspaceName)
                    Me.workspaceManager1.SaveWorkspace(Me.workspaceManager1.Workspaces(0).Name, Me.saveFileDialog1.FileName)
                End If
            Else
                workspaceName = Me.selectWorkSpaceItem.EditValue.ToString()
            End If
            If Not String.IsNullOrEmpty(workspaceName) Then
                Me.workspaceManager1.SaveWorkspace(workspaceName, Me.saveFileDialog1.InitialDirectory & workspaceName & ".xml")
            End If
        End Sub

        Private Sub loadItem_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles loadItem.ItemClick
            Me.saveFileDialog1.InitialDirectory = "C:\Users\Public\Documents\"
            If Me.openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim workspaceName As String = System.IO.Path.GetFileNameWithoutExtension(Me.openFileDialog1.FileName)
                If Me.workspaceManager1.LoadWorkspace(System.IO.Path.GetFileNameWithoutExtension(Me.openFileDialog1.FileName), openFileDialog1.FileName) Then
                    Me.workspaceManager1.ApplyWorkspace(workspaceName)
                End If
            End If
        End Sub
        #End Region
    End Class
    Public Enum TransitionType
        Push
        Shape
        Fade
        Clock
        Dissolve
        SlideFade
        Cover
        Comb
    End Enum
End Namespace
