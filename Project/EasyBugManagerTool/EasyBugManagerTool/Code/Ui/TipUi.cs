/* By: 絮大王（xudawang@vip.163.com）
   Time：2020年2月4日11:14:52*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyBugManagerTool
{
    /// <summary>
    /// [提示界面]的逻辑
    /// </summary>
    public class TipUi
    {
        #region [公开属性]
        /// <summary>
        /// [提示界面]的控件
        /// </summary>
        public TipUiControl UiControl
        {
            get { return AppManager.MainWindow.TipUiControl; }
        }
        #endregion


        #region [事件]

        /// <summary>
        /// 当点击[确认]按钮时
        /// </summary>
        public void ClickYesButton()
        {
            this.OpenOrClose(false);//关闭提示
        }

        /// <summary>
        /// 当点击[取消]按钮时
        /// </summary>
        public void ClickNoButton()
        {
            this.OpenOrClose(false);//关闭提示
        }
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
                    //打开界面
                    this.UiControl.Visibility = Visibility.Visible;

                    //打开前景(灰色)
                    AppManager.Uis.OpenOrCloseForeground(true);
                    break;

                //如果是关闭
                case false:
                    this.UiControl.Visibility = Visibility.Collapsed;//关闭界面
                    AppManager.Uis.OpenOrCloseForeground(false);//关闭前景(灰色)
                    break;
            }


            //清空Ui
            switch (_isOpen)
            {
                //如果是关闭
                case false:
                    UiControl.TipTitle = "";
                    UiControl.TipContent = "";
                    break;
            }
        }
        #endregion [公开方法 - 打开or关闭]

        #endregion
    }
}
