namespace StudentsManagementSystem_Kolyo_Kolev_F113002;

public static class MessageDialog
{
    // Shows a MessageBox using the provided parameters.
    public static DialogResult Show(IWin32Window owner, string text, 
        string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        => MessageBox.Show(owner, text, caption, buttons, icon);
}
