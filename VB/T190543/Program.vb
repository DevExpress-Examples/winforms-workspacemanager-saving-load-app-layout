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

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

Namespace T190543
    Friend NotInheritable Class Program

        Private Sub New()
        End Sub

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New Form1())
        End Sub
    End Class
End Namespace
