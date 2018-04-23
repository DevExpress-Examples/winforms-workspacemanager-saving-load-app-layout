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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace T190543 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
