using Fastedit.Controls;
using Fastedit.Core.Tab;
using Microsoft.UI.Xaml.Controls;
using System;

namespace Fastedit.Dialogs;

public class InfoMessages
{
    public static void NoAccessToSaveFile() => new InfoBar().Show("无访问权限", "没有写入该文件的权限", InfoBarSeverity.Error);
    public static void ErrorSavingDatabaseFile(string message) => new InfoBar().Show("保存数据库时出错", message, InfoBarSeverity.Error);
    public static void ErrorSavingDBTempFile(string message) => new InfoBar().Show("保存打开的文件时出错", message, InfoBarSeverity.Error);
    public static void NoAccessToReadFile() => new InfoBar().Show("无访问权限", "没有读取该文件的权限", InfoBarSeverity.Error);
    public static void UnhandledException(string message) => new InfoBar().Show("异常", "未处理的异常：\n" + message, InfoBarSeverity.Error);
    public static void ClearRecycleBinError() => new InfoBar().Show("清空回收站", "清空回收站时发生错误", InfoBarSeverity.Error);
    public static void DeleteFromRecycleBinError() => new InfoBar().Show("从回收站删除", "从回收站删除文件时发生错误", InfoBarSeverity.Error);
    public static void RecycleBinClearSucceeded() => new InfoBar().Show("清空回收站", "已成功清空回收站", InfoBarSeverity.Success);
    public static void MoveToRecycleBinError() => new InfoBar().Show("移入回收站", "将文件移入回收站时发生错误", InfoBarSeverity.Error);
    public static void OpenFromRecycleBinError() => new InfoBar().Show("从回收站打开", "从回收站打开文件时发生错误", InfoBarSeverity.Error);
    public static void FileNameInvalidCharacters() => new InfoBar().Show("无效字符", "输入的内容包含文件名不允许的字符", InfoBarSeverity.Error);
    public static void DesignLoadError(string designName, Exception ex) => new InfoBar().Show("设计加载失败", "无法加载设计：" + designName + "\n" + ex.Message, InfoBarSeverity.Error);
    public static void DetectEncodingError(Exception ex) => new InfoBar().Show("检测编码", "无法检测编码\n" + ex.Message, InfoBarSeverity.Error);
    public static void SettingsExportSucceeded() => new InfoBar().Show("设置导出", "设置已成功导出", InfoBarSeverity.Success);
    public static void SettingsImportSucceeded() => new InfoBar().Show("设置导入", "设置已成功导入", InfoBarSeverity.Success);
    public static void SettingsExportFailed() => new InfoBar().Show("设置导出", "导出设置失败", InfoBarSeverity.Error);
    public static void SettingsImportFailed() => new InfoBar().Show("设置导入", "导入设置失败", InfoBarSeverity.Error);
    public static void ClearTemporaryFilesFailed() => new InfoBar().Show("临时文件", "清除临时文件失败", InfoBarSeverity.Error);
    public static void ClearTemporaryFilesSucceeded() => new InfoBar().Show("临时文件", "已成功清除临时文件", InfoBarSeverity.Success);
    public static void DeleteDesignError(string design = "") => new InfoBar().Show("删除设计", "无法删除设计" + (design.Length > 0 ? "\n" + design : ""), InfoBarSeverity.Error);
    public static void ImportDesignError() => new InfoBar().Show("导入设计", "无法导入设计", InfoBarSeverity.Error);
    public static void ExportDesignError() => new InfoBar().Show("导出设计", "无法导出设计", InfoBarSeverity.Error);
    public static void OneDesignMustRemain() => new InfoBar().Show("无法删除", "无法删除该设计，因为至少需要保留一个设计", InfoBarSeverity.Warning);
    public static void SaveDesignError() => new InfoBar().Show("保存设计", "无法保存设计", InfoBarSeverity.Error);
    public static void SaveDesignSucceeded() => new InfoBar().Show("保存设计", "设计已成功保存", InfoBarSeverity.Success);
    public static void CloseDesignEditor() => new InfoBar().Show("关闭设计编辑器", "请关闭所有设计编辑器窗口", InfoBarSeverity.Warning);
    public static void RenameFileAlreadyExists() => new InfoBar().Show("重命名文件", "无法重命名文件，因为已存在同名文件", InfoBarSeverity.Error);
    public static void RenameFileException(Exception ex) => new InfoBar().Show("重命名文件", "重命名文件时发生异常：\n" + ex.Message, InfoBarSeverity.Error);
    public static void FileNotFoundReopenWithEncoding() => new InfoBar().Show("找不到文件", "无法重新打开文件，因为该文件已不存在", InfoBarSeverity.Error);
    public static void InvalidDesignName() => new InfoBar().Show("无效的设计名称", "设计名称无效", InfoBarSeverity.Error);

    public static void WelcomeMessage()
    {
        var btn = new Button { Content = "设计" };
        btn.Click += delegate
        {
            TabPageHelper.mainPage.ShowSettings("DesignPage");
        };
        new InfoBar().Show("欢迎使用 Fastedit", "要自定义你的使用体验，\n请点击下方按钮", btn, InfoBarSeverity.Success, 8);
    }

    public static void NewVersionInfo(string version)
    {
        var btn = new Button { Content = "更新日志" };
        btn.Click += delegate
        {
            TabPageHelper.mainPage.ShowSettings("AboutPage");
        };

        new InfoBar().Show(
            $"欢迎使用 Fastedit {version}！",
            "• 新增自动换行及默认自动换行设置\n• 监视磁盘上的文件变化并发出通知\n• 新增日志文件与通用语法高亮\n• 更流畅的滚动、触控板手势以及触摸和手写笔支持\n• 支持 ANSI 与 UTF-32 编码\n• 速度显著提升、内存占用更低，并修复了崩溃与稳定性问题",
            btn,
            InfoBarSeverity.Success,
            25
        );
    }
}
