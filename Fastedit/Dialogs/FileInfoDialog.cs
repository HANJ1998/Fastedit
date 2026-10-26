using Fastedit.Helper;
using Fastedit.Storage;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.FileProperties;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage;
using Fastedit.Core.Tab;

namespace Fastedit.Dialogs;

public class FileInfoDialog
{
    public static async Task Show(TabPageItem tab)
    {
        if (tab == null)
            return;

        StringBuilder content = new StringBuilder();

        //File extension
        string fileExtension = Path.GetExtension(tab.DatabaseItem.FilePath.Length > 0 ? tab.DatabaseItem.FilePath : tab.DatabaseItem.FileName);
        var extension = FileExtensions.FindByExtension(fileExtension);
        if (extension != null)
            content.AppendLine("扩展名：" + fileExtension + " (" + extension.ExtensionName + ")"); ;

        //only if the tab is based on a file
        if (!tab.DatabaseItem.WasNeverSaved)
        {
            //Maybe not use storage file here?
            try
            {
                StorageFile file = await StorageFile.GetFileFromPathAsync(tab.DatabaseItem.FilePath);
                BasicProperties fileProperties = await file.GetBasicPropertiesAsync();

                content.AppendLine("路径：" + tab.DatabaseItem.FilePath);
                content.AppendLine("创建时间：" + file.DateCreated.ToString("G"));
                content.AppendLine("修改时间：" + fileProperties.DateModified.ToString("G"));
                content.AppendLine("大小：" + SizeCalculationHelper.SplitSize(fileProperties.Size));
            }
            catch (FileNotFoundException) {  }
        }

        if (tab.textbox.SyntaxHighlighting != null)
            content.AppendLine("语言：" + tab.textbox.SyntaxHighlighting.Name);

        content.AppendLine("单词数：" + tab.textbox.WordCount());
        content.AppendLine("行数：" + tab.textbox.NumberOfLines);
        content.AppendLine("字符数：" + tab.textbox.CharacterCount());
        content.AppendLine("编码：" + EncodingHelper.GetEncodingName(tab.Encoding));
        content.AppendLine("行尾符：" + tab.LineEnding.ToString());

        var dialog = new ContentDialog
        {
            Background = DialogHelper.ContentDialogBackground(),
            Foreground = DialogHelper.ContentDialogForeground(),
            RequestedTheme = DialogHelper.DialogDesign,
            Title = "信息 " + tab.DatabaseItem.FileName,
            Content = new TextBlock { MaxWidth = 500, Text = content.ToString(), IsTextSelectionEnabled = true, TextWrapping=Microsoft.UI.Xaml.TextWrapping.Wrap },
            CloseButtonText = "确定",
            DefaultButton = ContentDialogButton.Close,
            XamlRoot = App.m_window.Content.XamlRoot,
            
        };
        await dialog.ShowAsync();
    }
}
