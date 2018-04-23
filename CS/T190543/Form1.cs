// Developer Express Code Central Example:
// WorkspaceManager - How to use WorkspaceManager for capturing, applying, saving and loading workspaces
// 
// This example demonstrates how to use the Workspace Manager
// (https://documentation.devexpress.com/WindowsForms/CustomDocument17674.aspx) for
// capturing, applying, saving and loading workspaces and shows different
// Transition Types in action. You can find the general information about the
// WorkspaceManager in our documentation: Workspace Manager
// (https://documentation.devexpress.com/WindowsForms/CustomDocument17674.aspx).
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=T190543

using DevExpress.Utils.Animation;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace T190543 {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013");
            Init();
        }

        private void Init() {
            this.repositoryItemLookUpEdit1.DataSource = this.workspaceManager1.Workspaces;
            this.repositoryItemLookUpEdit1.DisplayMember = "Name";
            this.repositoryItemLookUpEdit1.ValueMember = "Name";

            this.repositoryItemLookUpEdit1.PopulateColumns();
            this.repositoryItemLookUpEdit1.Columns[1].Visible = false;
            this.repositoryItemLookUpEdit1.Columns[2].Visible = false;

            this.selectWorkSpaceItem.EditValue = "Default";

            this.workspaceManager1.CloseStreamOnWorkspaceSaving = DevExpress.Utils.DefaultBoolean.True;
            this.workspaceManager1.CloseStreamOnWorkspaceLoading = DevExpress.Utils.DefaultBoolean.True;
            this.workspaceManager1.CaptureWorkspace("Default");

            this.repositoryItemComboBox1.Items.AddRange(Enum.GetValues(typeof(TransitionType)));
            this.repositoryItemComboBox1.EditValueChanged += repositoryItemComboBox1_EditValueChanged;

            this.transitionItem.EditValue = TransitionType.Push;
        }

        #region Events
        private void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e) {
            e.Control = new Control();
        }

        void repositoryItemComboBox1_EditValueChanged(object sender, EventArgs e) {
            ComboBoxEdit edit = sender as ComboBoxEdit;
            if (edit != null) {
                TransitionType value = (TransitionType)edit.EditValue;
                BaseTransition transition = null;
                switch (value) {
                    case TransitionType.Clock:
                        transition = new DevExpress.Utils.Animation.ClockTransition();
                        break;
                    case TransitionType.Comb:
                        transition = new DevExpress.Utils.Animation.CombTransition();
                        break;
                    case TransitionType.Cover:
                        transition = new DevExpress.Utils.Animation.CoverTransition();
                        break;
                    case TransitionType.Dissolve:
                        transition = new DevExpress.Utils.Animation.DissolveTransition();
                        break;
                    case TransitionType.Fade:
                        transition = new DevExpress.Utils.Animation.FadeTransition();
                        break;
                    case TransitionType.Push:
                        transition = new DevExpress.Utils.Animation.PushTransition();
                        break;
                    case TransitionType.Shape:
                        transition = new DevExpress.Utils.Animation.ShapeTransition();
                        break;
                    case TransitionType.SlideFade:
                        transition = new DevExpress.Utils.Animation.SlideFadeTransition();
                        break;
                }
                this.workspaceManager1.TransitionType = transition;
            }
        }

        private void captureItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (this.workspaceNameItem.EditValue != null) {
                string workspaceName = this.workspaceNameItem.EditValue.ToString();
                var item = this.workspaceManager1.Workspaces.Where(i => i.Name == workspaceName).FirstOrDefault();
                if (!string.IsNullOrEmpty(workspaceName) && item == null)
                    this.workspaceManager1.CaptureWorkspace(workspaceName);
            }
        }

        private void applyItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (this.selectWorkSpaceItem.EditValue != null) {
                string selectWorkSpaceItem = this.selectWorkSpaceItem.EditValue.ToString();
                if (!string.IsNullOrEmpty(selectWorkSpaceItem))
                    this.workspaceManager1.ApplyWorkspace(selectWorkSpaceItem);
            }
        }

        private void saveItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            string workspaceName = string.Empty;
            this.saveFileDialog1.InitialDirectory = @"C:\Users\Public\Documents\";
            if (XtraMessageBox.Show("Capture a new workspace or use an existing one? Click 'Yes' to capture a new workspace or 'No' to save the selected workspace.", "Create new workspace?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    workspaceName = System.IO.Path.GetFileNameWithoutExtension(this.saveFileDialog1.FileName);
                    this.workspaceManager1.CaptureWorkspace(workspaceName);
                    this.workspaceManager1.SaveWorkspace(this.workspaceManager1.Workspaces[0].Name, this.saveFileDialog1.FileName);
                }
            }
            else {
                workspaceName = this.selectWorkSpaceItem.EditValue.ToString();
            }
            if (!string.IsNullOrEmpty(workspaceName))
                this.workspaceManager1.SaveWorkspace(workspaceName, this.saveFileDialog1.InitialDirectory + workspaceName + ".xml");
        }

        private void loadItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.saveFileDialog1.InitialDirectory = @"C:\Users\Public\Documents\";
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string workspaceName = System.IO.Path.GetFileNameWithoutExtension(this.openFileDialog1.FileName);
                if (this.workspaceManager1.LoadWorkspace(System.IO.Path.GetFileNameWithoutExtension(this.openFileDialog1.FileName), openFileDialog1.FileName)) {
                    this.workspaceManager1.ApplyWorkspace(workspaceName);
                }
            }
        }
        #endregion
    }
    public enum TransitionType {
        Push,
        Shape,
        Fade,
        Clock,
        Dissolve,
        SlideFade,
        Cover,
        Comb
    }
}
