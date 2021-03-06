﻿using Main.Util;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using WordsLinks.UWP.View;
using WordsLinks.UWP.ViewModel;
using WordsLinks.UWP.Util;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WordsLinks.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageShell : Page
    {
        private List<NavPageItem> navList = new List<NavPageItem>
            {
                new NavPageItem()
                {
                    Label = "添加",
                    Source = "Assets/IconWrite.png",
                    PageType = typeof(WritePage)
                },
                new NavPageItem()
                {
                    Label = "记忆",
                    Source = "Assets/IconMemorize.png",
                    PageType = typeof(MemorizePage)
                },
                new NavPageItem()
                {
                    Label = "设置",
                    Source = "Assets/IconSetting.png",
                    PageType = typeof(SettingPage)
                },
            };

        public PageShell()
        {
            InitializeComponent();
            (SpecificUtils.hudPopup as HUDPopup_UWP).Init(msgBar, msgBox);
            NavMenuList.ItemsSource = navList;
            NavMenuList.PageSelected += OnPageSelected;
            frame.NavigationFailed += (o, e) => e.Exception.CopeWith("page navigation");
            Loaded += (o, e) => NavMenuList.Select(0);
        }

        private void OnPageSelected(object sender, NavPageItem item)
        {
            frame.Navigate(item.PageType, null, new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
        }

    }
}
