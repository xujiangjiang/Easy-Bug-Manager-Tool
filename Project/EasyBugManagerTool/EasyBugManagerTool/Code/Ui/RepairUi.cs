/* By: 絮大王（xudawang@vip.163.com）
   Time：2020年2月4日11:19:34*/

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
    /// [修复项目界面]的逻辑
    /// </summary>
    public class RepairUi
    {
        #region [公开属性]
        /// <summary>
        /// [修复项目界面]的控件
        /// </summary>
        public BrowseUiControl UiControl
        {
            get { return AppManager.MainWindow.RepairUiControl; }
        }
        #endregion


        #region [事件]
        /// <summary>
        /// 当点击[确认]按钮时
        /// </summary>
        public void ClickYesButton()
        {
            //如果没有选择文件
            if (UiControl.PathString == null || UiControl.PathString == "")
            {
                //提示
                UiControl.TipString = AppManager.Systems.LanguageSystem.NoChooseProjectFileTip;
            }

            else
            {
                //提示
                UiControl.TipString = "";


                //打开保存界面
                AppManager.Uis.BrowseUi.UiControl.TitleString = AppManager.Systems.LanguageSystem.BrowseTitle;
                AppManager.Uis.BrowseUi.UiControl.LocationString = AppManager.Systems.LanguageSystem.ProjectFoldertring;
                AppManager.Uis.BrowseUi.OpenOrClose(true);
            }
        }

        /// <summary>
        /// 当点击[取消]按钮时
        /// </summary>
        public void ClickNoButton()
        {
            this.OpenOrClose(false);//关闭界面
        }

        /// <summary>
        /// 当点击[浏览]按钮时
        /// </summary>
        public void ClickBrowseButton()
        {
            /* OpenFileDialog类，用于打开文件对话框 */
            OpenFileDialog _openFileDialog = new OpenFileDialog();

            /* 设置文件过滤 */
            _openFileDialog.Filter = "项目文件|*.bugs";

            /* 调用OpenFileDialog.ShowDialog()方法，显示[打开文件对话框]
               这个方法有一个bool?类型的返回值
               返回值为true，代表用户选择了文件；否则就代表用户没有选择文件 */
            bool? _isChooseFile = _openFileDialog.ShowDialog();

            /* 获取用户打开的文件 的路径 */
            if (_isChooseFile == true)
            {
                UiControl.PathString = _openFileDialog.FileName;
            }
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
                    UiControl.ForegroundCanvas.Visibility = Visibility.Collapsed;
                    AppManager.Uis.OpenOrCloseForeground(false);
                    break;
            }


            //清空Ui
            switch (_isOpen)
            {
                //如果是关闭
                case false:
                    UiControl.LocationString = "";
                    UiControl.TipString = "";
                    UiControl.PathString = "";
                    UiControl.TitleString = "";
                    break;
            }
        }
        #endregion
    }
}
