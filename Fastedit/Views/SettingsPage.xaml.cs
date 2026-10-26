using Fastedit.Helper;
using Fastedit.Models;
using Fastedit.Views.SettingsPages;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Input;

namespace Fastedit.Views;

public sealed partial class SettingsPage : Page
{
    SettingsNavigationParameter SettingsParameter = null;

    private readonly List<(string Tag, Type Page, string HeaderContent)> _pages = new List<(string Tag, Type Page, string HeaderContent)>
    {
        ("AppPage", typeof(Settings_AppPage), "应用"),
        ("TextboxPage", typeof(Settings_DocumentPage), "文本框"),
        ("TabviewPage", typeof(Settings_TabControl), "标签页"),
        ("DesignPage", typeof(Settings_DesignPage), "设计"),
        ("DataPage", typeof(Settings_Data), "数据"),
        ("AboutPage", typeof(AboutPage), "关于"),
    };

    public SettingsPage(SettingsNavigationParameter param)
    {
        this.InitializeComponent();
        SettingsParameter = param;
        NavView_Navigate(SettingsParameter.Page ?? _pages[0].Tag);
    }
    private void NavView_Navigate(string navItemTag)
    {
        Type _page = null;

        var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
        _page = item.Page;

        applySettingsButton.Visibility = ConvertHelper.BoolToVisibility(item.Page != typeof(AboutPage));

        var preNavPageType = navigationFrame.CurrentSourcePageType;
        if (!(_page is null) && !Type.Equals(preNavPageType, _page))
        {
            pageNameDisplay.Text = item.HeaderContent;
            navigationFrame.Navigate(_page, SettingsParameter);
        }
    }

    private void NavigationView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
    {
        var navItemTag = args.InvokedItemContainer.Tag.ToString();

        NavView_Navigate(navItemTag);
    }

    private void ApplySettings_Click(object sender, RoutedEventArgs e)
    {
        SettingsParameter?.MainPage.ApplySettings();

        this.ProtectedCursor = InputSystemCursor.Create(InputSystemCursorShape.Arrow);
    }

    private void Page_PointerEntered(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        this.ProtectedCursor = InputSystemCursor.Create(InputSystemCursorShape.Arrow);
    }
}
