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

    Public Partial Class Form1
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013")
            Init()
        End Sub

        Private Sub Init()
            repositoryItemLookUpEdit1.DataSource = workspaceManager1.Workspaces
            repositoryItemLookUpEdit1.DisplayMember = "Name"
            repositoryItemLookUpEdit1.ValueMember = "Name"
            repositoryItemLookUpEdit1.PopulateColumns()
            repositoryItemLookUpEdit1.Columns(1).Visible = False
            repositoryItemLookUpEdit1.Columns(2).Visible = False
            selectWorkSpaceItem.EditValue = "Default"
            workspaceManager1.CloseStreamOnWorkspaceSaving = DevExpress.Utils.DefaultBoolean.True
            workspaceManager1.CloseStreamOnWorkspaceLoading = DevExpress.Utils.DefaultBoolean.True
            workspaceManager1.CaptureWorkspace("Default")
            repositoryItemComboBox1.Items.AddRange([Enum].GetValues(GetType(TransitionType)))
            AddHandler repositoryItemComboBox1.EditValueChanged, AddressOf repositoryItemComboBox1_EditValueChanged
            transitionItem.EditValue = TransitionType.Push
        End Sub

#Region "Events"
        Private Sub tabbedView1_QueryControl(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs)
            e.Control = New Control()
        End Sub

        Private Sub repositoryItemComboBox1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim edit As ComboBoxEdit = TryCast(sender, ComboBoxEdit)
            If edit IsNot Nothing Then
                Dim value As TransitionType = CType(edit.EditValue, TransitionType)
                Dim transition As BaseTransition = Nothing
                Select Case value
                    Case TransitionType.Clock
                        transition = New ClockTransition()
                    Case TransitionType.Comb
                        transition = New CombTransition()
                    Case TransitionType.Cover
                        transition = New CoverTransition()
                    Case TransitionType.Dissolve
                        transition = New DissolveTransition()
                    Case TransitionType.Fade
                        transition = New FadeTransition()
                    Case TransitionType.Push
                        transition = New PushTransition()
                    Case TransitionType.Shape
                        transition = New ShapeTransition()
                    Case TransitionType.SlideFade
                        transition = New SlideFadeTransition()
                End Select

                workspaceManager1.TransitionType = transition
            End If
        End Sub

        Private Sub captureItem_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            If workspaceNameItem.EditValue IsNot Nothing Then
                Dim workspaceName As String = workspaceNameItem.EditValue.ToString()
                Dim item = workspaceManager1.Workspaces.Where(Function(i) Equals(i.Name, workspaceName)).FirstOrDefault()
                If Not String.IsNullOrEmpty(workspaceName) AndAlso item Is Nothing Then workspaceManager1.CaptureWorkspace(workspaceName)
            End If
        End Sub

        Private Sub applyItem_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            If selectWorkSpaceItem.EditValue IsNot Nothing Then
                Dim selectWorkSpaceItem As String = Me.selectWorkSpaceItem.EditValue.ToString()
                If Not String.IsNullOrEmpty(selectWorkSpaceItem) Then workspaceManager1.ApplyWorkspace(selectWorkSpaceItem)
            End If
        End Sub

        Private Sub saveItem_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            Dim workspaceName As String = String.Empty
            saveFileDialog1.InitialDirectory = "C:\Users\Public\Documents\"
            If XtraMessageBox.Show("Capture a new workspace or use an existing one? Click 'Yes' to capture a new workspace or 'No' to save the selected workspace.", "Create new workspace?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                    workspaceName = IO.Path.GetFileNameWithoutExtension(saveFileDialog1.FileName)
                    workspaceManager1.CaptureWorkspace(workspaceName)
                    workspaceManager1.SaveWorkspace(workspaceManager1.Workspaces(0).Name, saveFileDialog1.FileName)
                End If
            Else
                workspaceName = selectWorkSpaceItem.EditValue.ToString()
            End If

            If Not String.IsNullOrEmpty(workspaceName) Then workspaceManager1.SaveWorkspace(workspaceName, saveFileDialog1.InitialDirectory & workspaceName & ".xml")
        End Sub

        Private Sub loadItem_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            saveFileDialog1.InitialDirectory = "C:\Users\Public\Documents\"
            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim workspaceName As String = IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName)
                If workspaceManager1.LoadWorkspace(IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName), openFileDialog1.FileName) Then
                    workspaceManager1.ApplyWorkspace(workspaceName)
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
