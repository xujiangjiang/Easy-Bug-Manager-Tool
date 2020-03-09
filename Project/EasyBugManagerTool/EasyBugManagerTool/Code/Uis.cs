/* By: 絮大王（xudawang@vip.163.com）
   Time：2020年2月4日04:13:35*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyBugManagerTool
{
    /// <summary>
    /// 用于存放所有的界面
    /// </summary>
    public class Uis
    {
        private MainUi mainUi;//[主]界面
        private SettingsUi settingsUi;//[设置]界面
        private TipUi tipUi;//[提示]界面
        private BrowseUi browseUi;//[浏览]界面
        private RepairUi repairUi;//[修复]界面
        private ConvertUi convertUi;//[转换]界面


        #region 属性
        /// <summary>
        /// [主]界面
        /// </summary>
        public MainUi MainUi
        {
            get { return mainUi; }
        }

        /// <summary>
        /// [设置]界面
        /// </summary>
        public SettingsUi SettingsUi
        {
            get { return settingsUi; }
        }

        /// <summary>
        /// [提示]界面
        /// </summary>
        public TipUi TipUi
        {
            get { return tipUi; }
        }


        /// <summary>
        /// [浏览]界面
        /// </summary>
        public BrowseUi BrowseUi
        {
            get { return browseUi; }
        }

        /// <summary>
        /// [修复]界面
        /// </summary>
        public RepairUi RepairUi
        {
            get { return repairUi; }
        }

        /// <summary>
        /// [转换]界面
        /// </summary>
        public ConvertUi ConvertUi
        {
            get { return convertUi; }
        }
        #endregion


        #region 构造方法
        public Uis()
        {
            mainUi = new MainUi();
            settingsUi = new SettingsUi();
            tipUi = new TipUi();
            browseUi = new BrowseUi();
            repairUi = new RepairUi();
            convertUi = new ConvertUi();
        }
        #endregion


        #region [公开方法]
        /// <summary>
        /// 打开/关闭 前景
        /// (灰色的前景用于遮挡按钮)
        /// </summary>
        /// <param name="_isOpen">是否打开？</param>
        public void OpenOrCloseForeground(bool _isOpen)
        {
            switch (_isOpen)
            {
                //如果是打开
                case true:

                    /* 打开前景(灰色) */

                    //如果[浏览界面]是打开的
                    if (BrowseUi.UiControl.Visibility == Visibility.Visible)
                    {
                        BrowseUi.UiControl.ForegroundCanvas.Visibility = Visibility.Visible;
                    }

                    //如果[修复界面]是打开的
                    else if (RepairUi.UiControl.Visibility == Visibility.Visible)
                    {
                        RepairUi.UiControl.ForegroundCanvas.Visibility = Visibility.Visible;
                    }

                    //如果[转换界面]是打开的
                    else if (ConvertUi.UiControl.Visibility == Visibility.Visible)
                    {
                        ConvertUi.UiControl.ForegroundCanvas.Visibility = Visibility.Visible;
                    }

                    //如果[主界面]是打开的
                    else if (MainUi.UiControl.Visibility == Visibility.Visible)
                    {
                        MainUi.UiControl.ForegroundCanvas.Visibility = Visibility.Visible;
                    }
                    break;



                //如果是关闭
                case false:
                    /* 关闭前景(灰色) */

                    //如果[浏览界面]是打开的
                    if (BrowseUi.UiControl.Visibility == Visibility.Visible)
                    {
                        BrowseUi.UiControl.ForegroundCanvas.Visibility = Visibility.Collapsed;
                    }

                    //如果[修复界面]是打开的
                    else if (RepairUi.UiControl.Visibility == Visibility.Visible)
                    {
                        RepairUi.UiControl.ForegroundCanvas.Visibility = Visibility.Collapsed;
                    }

                    //如果[转换界面]是打开的
                    else if (ConvertUi.UiControl.Visibility == Visibility.Visible)
                    {
                        ConvertUi.UiControl.ForegroundCanvas.Visibility = Visibility.Collapsed;
                    }

                    //如果[主界面]是打开的
                    else if (MainUi.UiControl.Visibility == Visibility.Visible)
                    {
                        MainUi.UiControl.ForegroundCanvas.Visibility = Visibility.Collapsed;
                    }
                    break;
            }
        }
        #endregion
    }
}
