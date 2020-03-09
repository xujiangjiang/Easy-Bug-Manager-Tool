/*
    App：Easy Bug Manager Tool
    By：絮大王（XuDaWang）
    Email：xudawang@vip.163.com
    Steam：https://store.steampowered.com/app/1175080/Easy_Bug_Manager/
    Github：https://github.com/xujiangjiang/Easy-Bug-Manager-Tool
    Time：2020.02.04
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBugManagerTool
{
    /// <summary>
    /// App的所有属性和逻辑
    /// </summary>
    public class AppManager
    {
        private static App mainApp;//App的逻辑
        private static MainWindow mainWindow;//窗口的逻辑

        /* 子系统 */
        private static Datas datas;//所有的数据
        private static Systems systems;//所有的逻辑
        private static Uis uis;//所有的界面


        #region [属性]
        /// <summary>
        /// App的逻辑
        /// </summary>
        public static App MainApp
        {
            get { return mainApp; }
            set { mainApp = value; }
        }

        /// <summary>
        /// 窗口的逻辑
        /// </summary>
        public static MainWindow MainWindow
        {
            get { return mainApp.MainWindow as MainWindow; }
        }




        /// <summary>
        /// 所有的数据
        /// </summary>
        public static Datas Datas
        {
            get { return datas; }
        }

        /// <summary>
        /// 所有的逻辑
        /// </summary>
        public static Systems Systems
        {
            get { return systems; }
        }

        /// <summary>
        /// 所有的界面
        /// </summary>
        public static Uis Uis
        {
            get { return uis; }
        }
        #endregion

        #region [构造方法]
        static AppManager()
        {
            datas = new Datas();
            uis = new Uis();
            systems = new Systems();
        }
        #endregion

        #region [初始化]
        /// <summary>
        /// 启动程序（在Start()之前）
        /// </summary>
        public static void Awake()
        {
            systems = new Systems();
        }


        /// <summary>
        /// 初始化程序
        /// </summary>
        public static void Start()
        {
            /* 数据绑定赋值 */
            MainWindow.DataContext = Datas;//设置[数据源]

            /* 读取数据 */
            Systems.SaveSystem.Load();

            /* 进行一些操作 */


            /* 打开主界面 */
            Uis.MainUi.OpenOrClose(true);
        }


        /// <summary>
        /// 退出程序
        /// </summary>
        public static void Exit()
        {
            /* 保存数据 */
            systems.SaveSystem.Save();//保存App数据
        }
        #endregion

    }
}
