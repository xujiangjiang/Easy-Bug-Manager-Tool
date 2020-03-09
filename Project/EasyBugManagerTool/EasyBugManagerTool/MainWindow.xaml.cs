using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyBugManagerTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        #region [初始化]
        //当窗口初始化时，触发此方法
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //初始化
            AppManager.Start();
        }
        #endregion


        #region [事件 - 主界面]
        /// <summary>
        /// 当点击[最小化]按钮时
        /// </summary>
        private void MainUiControl_ClickMinimizeButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.MainUi.ClickMinimizeButton();//调用逻辑
        }

        /// <summary>
        /// 当点击[关闭]按钮时
        /// </summary>
        private void MainUiControl_ClickCloseButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.MainUi.ClickCloseButton();//调用逻辑
        }

        /// <summary>
        /// 当点击[设置]按钮时
        /// </summary>
        private void MainUiControl_ClickSettingButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.MainUi.ClickSettingButton();//调用逻辑
        }

        /// <summary>
        /// 当点击[修复项目]按钮时
        /// </summary>
        private void MainUiControl_ClickRepairButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.MainUi.ClickRepairButton();//调用逻辑
        }

        /// <summary>
        /// 当点击[转换项目]按钮时
        /// </summary>
        private void MainUiControl_ClickConvertButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.MainUi.ClickConvertButton();//调用逻辑
        }
        #endregion

        #region [事件 - 设置界面]
        /// <summary>
        /// 当点击[关闭]按钮时
        /// </summary>
        private void SettingsUiControl_OnClickCloseButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.SettingsUi.ClickCloseButton();//调用逻辑
        }

        /// <summary>
        /// 当点击[Github]按钮时
        /// </summary>
        private void SettingsUiControl_OnClickGithubButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.SettingsUi.ClickGithubButton();//调用逻辑
        }

        /// <summary>
        /// 当[语言]改变时
        /// </summary>
        private void SettingsUiControl_OnLanguageChange(object sender, RoutedPropertyChangedEventArgs<LanguageType> e)
        {
            AppManager.Uis.SettingsUi.LanguageChange(e.NewValue);//触发事件
        }

        /// <summary>
        /// 当[声音]改变时
        /// </summary>
        private void SettingsUiControl_OnSoundChange(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.SettingsUi.SoundChange(e.NewValue);//触发事件
        }
        #endregion

        #region [事件 - 转换界面]
        /// <summary>
        /// 当点击[浏览]按钮时
        /// </summary>
        private void ConvertUiControl_OnClickBrowseButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.ConvertUi.ClickBrowseButton();//触发事件
        }

        /// <summary>
        /// 当点击[确认]按钮时
        /// </summary>
        private void ConvertUiControl_OnClickYesButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.ConvertUi.ClickYesButton();//触发事件
        }

        /// <summary>
        /// 当点击[取消]按钮时
        /// </summary>
        private void ConvertUiControl_OnClickNoButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.ConvertUi.ClickNoButton();//触发事件
        }
        #endregion

        #region [事件 - 修复界面]
        /// <summary>
        /// 当点击[浏览]按钮时
        /// </summary>
        private void RepairUiControl_OnClickBrowseButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.RepairUi.ClickBrowseButton();//触发事件
        }

        /// <summary>
        /// 当点击[确认]按钮时
        /// </summary>
        private void RepairUiControl_OnClickYesButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.RepairUi.ClickYesButton();//触发事件
        }

        /// <summary>
        /// 当点击[取消]按钮时
        /// </summary>
        private void RepairUiControl_OnClickNoButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.RepairUi.ClickNoButton();//触发事件
        }
        #endregion

        #region [事件 - 浏览界面]
        /// <summary>
        /// 当点击[浏览]按钮时
        /// </summary>
        private void BrowseUiControl_OnClickBrowseButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.BrowseUi.ClickBrowseButton();//触发事件
        }

        /// <summary>
        /// 当点击[确认]按钮时
        /// </summary>
        private void BrowseUiControl_OnClickYesButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.BrowseUi.ClickYesButton();//触发事件
        }

        /// <summary>
        /// 当点击[取消]按钮时
        /// </summary>
        private void BrowseUiControl_OnClickNoButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.BrowseUi.ClickNoButton();//触发事件
        }
        #endregion

        #region [事件 - Tip界面]
        /// <summary>
        /// 当点击[确认]按钮时
        /// </summary>
        private void TipUiControl_OnClickYesButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.TipUi.ClickYesButton();//触发事件
        }

        /// <summary>
        /// 当点击[取消]按钮时
        /// </summary>
        private void TipUiControl_OnClickNoButton(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            AppManager.Uis.TipUi.ClickNoButton();//触发事件
        }
        #endregion
    }
}
