/* By: 絮大王（xudawang@vip.163.com）
   Time：2020年2月4日11:18:39*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Forms;

namespace EasyBugManagerTool
{
    /// <summary>
    /// [浏览界面]的逻辑
    /// </summary>
    public class BrowseUi
    {
        #region [公开属性]
        /// <summary>
        /// [转换项目界面]的控件
        /// </summary>
        public BrowseUiControl UiControl
        {
            get { return AppManager.MainWindow.BrowseUiControl; }
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
                UiControl.TipString = AppManager.Systems.LanguageSystem.NoChooseSaveFolderTip;
            }

            else
            {
                //提示
                UiControl.TipString = "";

                //打开前景(灰色)
                AppManager.Uis.OpenOrCloseForeground(true);

                //如果是转换
                if (AppManager.Uis.ConvertUi.UiControl.Visibility == Visibility.Visible)
                {
                    //取到ModeType
                    ModeType _modeType = ModeType.Default;
                    if (AppManager.Uis.ConvertUi.UiControl.IsCollaborationMode == true)
                    {
                        _modeType = ModeType.Collaboration;
                    }

                    //进行转换
                    string _convertFolderPath = AppManager.Systems.ConvertSystem.Convert(AppManager.Uis.ConvertUi.UiControl.PathString, UiControl.PathString ,_modeType);

                    //关闭当前页面
                    this.OpenOrClose(false);

                    //如果转换失败
                    if (_convertFolderPath == null || _convertFolderPath == "")
                    {
                        AppManager.Uis.TipUi.UiControl.TipTitle = AppManager.Systems.LanguageSystem.ErrorTitle;
                        AppManager.Uis.TipUi.UiControl.TipContent = AppManager.Systems.LanguageSystem.ErrorContent;
                        AppManager.Uis.TipUi.OpenOrClose(true);
                    }
                    //如果转换成功
                    else
                    {
                        AppManager.Uis.TipUi.UiControl.TipTitle = AppManager.Systems.LanguageSystem.DoneTitle;
                        AppManager.Uis.TipUi.UiControl.TipContent = _convertFolderPath;
                        AppManager.Uis.TipUi.OpenOrClose(true);
                    }
                }

                //如果是修复
                else if (AppManager.Uis.RepairUi.UiControl.Visibility == Visibility.Visible)
                {
                    //进行修复
                    string _repairFolderPath = AppManager.Systems.RepairSystem.Repair(AppManager.Uis.RepairUi.UiControl.PathString, UiControl.PathString);

                    //关闭当前页面
                    this.OpenOrClose(false);

                    //如果转换失败
                    if (_repairFolderPath == null || _repairFolderPath == "")
                    {
                        AppManager.Uis.TipUi.UiControl.TipTitle = AppManager.Systems.LanguageSystem.ErrorTitle;
                        AppManager.Uis.TipUi.UiControl.TipContent = AppManager.Systems.LanguageSystem.ErrorContent;
                        AppManager.Uis.TipUi.OpenOrClose(true);
                    }
                    //如果转换成功
                    else
                    {
                        AppManager.Uis.TipUi.UiControl.TipTitle = AppManager.Systems.LanguageSystem.DoneTitle;
                        AppManager.Uis.TipUi.UiControl.TipContent = _repairFolderPath;
                        AppManager.Uis.TipUi.OpenOrClose(true);
                    }
                }

                //如果是其他
                else
                {
                    AppManager.Uis.TipUi.UiControl.TipTitle = AppManager.Systems.LanguageSystem.ErrorTitle;
                    AppManager.Uis.TipUi.UiControl.TipContent = AppManager.Systems.LanguageSystem.ErrorContent;
                    AppManager.Uis.TipUi.OpenOrClose(true);
                }
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
            /* FolderBrowserDialog类，用于打开文件夹对话框 */
            FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();

            /* 调用OpenFileDialog.ShowDialog()方法，显示[打开文件对话框]
               这个方法有一个bool?类型的返回值
               返回值为Ok，代表用户选择了文件；否则就代表用户没有选择文件 */
            DialogResult _dialogResult = _folderBrowserDialog.ShowDialog();

            /* 获取用户打开的文件 的路径 */
            if (_dialogResult == DialogResult.OK)
            {
                //把用户选择的文件夹，赋值给PathString属性
                UiControl.PathString = _folderBrowserDialog.SelectedPath;
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
