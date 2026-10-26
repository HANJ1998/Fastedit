using Fastedit.Views;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace Fastedit.Dialogs;

public class AskSaveDesignDialog
{
    public static async Task<ContentDialogResult> Show(DesignEditor editor)
    {
        var SaveDialog = new ContentDialog
        {
            XamlRoot = editor.XamlRoot,
            Background = DialogHelper.ContentDialogBackground(),
            Foreground = DialogHelper.ContentDialogForeground(),
            RequestedTheme = DialogHelper.DialogDesign,
            Title = "保存设计？",
            Content = "是否保存对以下项目的更改：" + Path.GetFileNameWithoutExtension(editor.CurrentDesignName) + "?",
            PrimaryButtonText = "保存",
            SecondaryButtonText = "不保存",
            CloseButtonText = "取消",
            DefaultButton = ContentDialogButton.Primary,
        };
        return await SaveDialog.ShowAsync();
    }
}
