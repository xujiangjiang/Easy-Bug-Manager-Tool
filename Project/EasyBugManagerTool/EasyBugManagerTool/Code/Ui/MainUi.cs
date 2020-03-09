/* By: 絮大王（xudawang@vip.163.com）
   Time：2020年2月4日11:14:17*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace EasyBugManagerTool
{
    /// <summary>
    /// [主界面]的逻辑
    /// </summary>
    public class MainUi
    {
        #region [公开属性]
        /// <summary>
        /// [主界面]的控件
        /// </summary>
        public MainUiControl UiControl
        {
            get { return AppManager.MainWindow.MainUiControl; }
        }
        #endregion


        #region [事件]
        /// <summary>
        /// 当点击[最小化]按钮时
        /// </summary>
        public void ClickMinimizeButton() 
        {
            AppManager.MainWindow.WindowState = WindowState.Minimized; //最小化此窗口
        }

        /// <summary>
        /// 当点击[关闭]按钮时
        /// </summary>
        public void ClickCloseButton()
        {
            AppManager.MainApp.Shutdown();//关闭应用程序
        }

        /// <summary>
        /// 当点击[设置]按钮时
        /// </summary>
        public void ClickSettingButton()
        {
            AppManager.Uis.SettingsUi.OpenOrClose(true);//打开设置界面
        }

        /// <summary>
        /// 当点击[修复项目]按钮时
        /// </summary>
        public void ClickRepairButton()
        {
            //打开修复界面
            AppManager.Uis.RepairUi.UiControl.TitleString = AppManager.Systems.LanguageSystem.RepairTitle;
            AppManager.Uis.RepairUi.UiControl.LocationString = AppManager.Systems.LanguageSystem.ProjectFileString;
            AppManager.Uis.RepairUi.OpenOrClose(true);

            //打开Tip界面
            AppManager.Uis.TipUi.UiControl.TipTitle = AppManager.Systems.LanguageSystem.TipTitle;
            AppManager.Uis.TipUi.UiControl.TipContent = AppManager.Systems.LanguageSystem.RepairTipContent;
            AppManager.Uis.TipUi.OpenOrClose(true);
        }

        /// <summary>
        /// 当点击[转换项目]按钮时
        /// </summary>
        public void ClickConvertButton()
        {
            //打开转换界面
            AppManager.Uis.ConvertUi.UiControl.TitleString = AppManager.Systems.LanguageSystem.ConvertTitle;
            AppManager.Uis.ConvertUi.UiControl.LocationString = AppManager.Systems.LanguageSystem.ProjectFileString;
            AppManager.Uis.ConvertUi.UiControl.CollaborationModeString = AppManager.Systems.LanguageSystem.CollaborationModeString;
            AppManager.Uis.ConvertUi.OpenOrClose(true);

            //打开Tip界面
            AppManager.Uis.TipUi.UiControl.TipTitle = AppManager.Systems.LanguageSystem.TipTitle;
            AppManager.Uis.TipUi.UiControl.TipContent = AppManager.Systems.LanguageSystem.ConvertTipContent;
            AppManager.Uis.TipUi.OpenOrClose(true);
        }
        #endregion


        #region [公开方法 - 打开or关闭]
        /// <summary>
        /// 打开或者关闭 界面
        /// </summary>
        /// <param name="_isOpen">是否打开？</param>
        public void OpenOrClose(bool _isOpen) 
        {
            switch (_isOpen)
            {
                //如果是打开
                case true:
                    this.UiControl.Visibility = Visibility.Visible;//打开界面
                    break;

                //如果是关闭
                case false:
                    this.UiControl.Visibility = Visibility.Collapsed;//关闭界面
                    break;
            }
        }
        #endregion
    }
}
