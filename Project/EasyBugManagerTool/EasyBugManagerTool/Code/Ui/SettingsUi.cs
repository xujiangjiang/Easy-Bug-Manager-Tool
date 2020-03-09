/* By: 絮大王（xudawang@vip.163.com）
   Time：2020年2月4日11:14:42*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyBugManagerTool
{
    /// <summary>
    /// [设置界面]的逻辑
    /// </summary>
    public class SettingsUi
    {
        #region [公开属性]
        /// <summary>
        /// [设置界面]的控件
        /// </summary>
        public SettingsUiControl UiControl
        {
            get { return AppManager.MainWindow.SettingsUiControl; }
        }
        #endregion


        #region [事件]

        #region [事件 - 值]
        /// <summary>
        /// 当[语言]改变时
        /// </summary>
        /// <param name="_currentLanguage">当前的Language属性的值</param>
        public void LanguageChange(LanguageType _currentLanguage)
        {
            //根据[语言] 重新设置 文字和图片
            AppManager.Systems.LanguageSystem.Handle(_currentLanguage);
        }

        /// <summary>
        /// 当[声音]改变时
        /// </summary>
        /// <param name="_currentSound">当前的Sound属性的值</param>
        public void SoundChange(bool _currentSound) { }
        #endregion [事件 - 值]

        #region [事件 - 按钮]

        /// <summary>
        /// 点击[关闭]按钮时
        /// </summary>
        public void ClickCloseButton()
        {
            this.OpenOrClose(false);//关闭设置界面
        }

        /// <summary>
        /// 点击[Github]按钮时
        /// </summary>
        public void ClickGithubButton()
        {
            //调用系统默认的浏览器
            System.Diagnostics.Process.Start("https://github.com/xujiangjiang/Easy-Bug-Manager");
        }
        #endregion [事件 - 按钮]

        #endregion


        #region [公开方法]

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
                    //打开前景(灰色)
                    AppManager.Uis.OpenOrCloseForeground(true);

                    //打开界面
                    this.UiControl.Visibility = Visibility.Visible;
                    break;

                //如果是关闭
                case false:
                    //关闭界面
                    this.UiControl.Visibility = Visibility.Collapsed;

                    //关闭前景(灰色)
                    AppManager.Uis.OpenOrCloseForeground(false);
                    break;
            }
        }
        #endregion [公开方法 - 打开or关闭]

        #endregion
    }
}
