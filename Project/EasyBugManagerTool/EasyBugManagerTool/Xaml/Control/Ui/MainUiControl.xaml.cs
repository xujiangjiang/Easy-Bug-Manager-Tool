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
    /// MainUiControl.xaml 的交互逻辑
    /// </summary>
    public partial class MainUiControl : UserControl
    {
        /*  事件： ClickMinimizeButton（当点击[最小化]按钮时）
                   ClickCloseButton（当点击[关闭]按钮时）
                   ClickSettingButton（当点击[设置]按钮时）
                   ClickRepairButton（当点击[修复项目]按钮时）
                   ClickConvertButton（当点击[转换项目]按钮时）*/


        public MainUiControl()
        {
            InitializeComponent();
        }



        #region 路由事件：ClickMinimizeButton
        /// <summary>
        /// 路由事件：ClickMinimizeButtonEvent
        /// （当点击[最小化]按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickMinimizeButtonEvent;


        /// <summary>
        /// 路由事件的属性：ClickMinimizeButton
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> ClickMinimizeButton
        {
            //添加一条事件
            add { AddHandler(ClickMinimizeButtonEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickMinimizeButtonEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 ClickMinimizeButton 路由事件
        /// </summary>
        private void OnClickMinimizeButton()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = MainUiControl.ClickMinimizeButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion

        #region 路由事件：ClickCloseButton
        /// <summary>
        /// 路由事件：ClickCloseButtonEvent
        /// （当点击[最小化]按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickCloseButtonEvent;


        /// <summary>
        /// 路由事件的属性：ClickCloseButton
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> ClickCloseButton
        {
            //添加一条事件
            add { AddHandler(ClickCloseButtonEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickCloseButtonEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 ClickCloseButton 路由事件
        /// </summary>
        private void OnClickCloseButton()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = MainUiControl.ClickCloseButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion

        #region 路由事件：ClickSettingButton
        /// <summary>
        /// 路由事件：ClickSettingButtonEvent
        /// （当点击[设置]按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickSettingButtonEvent;


        /// <summary>
        /// 路由事件的属性：ClickSettingButton
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> ClickSettingButton
        {
            //添加一条事件
            add { AddHandler(ClickSettingButtonEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickSettingButtonEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 ClickSettingButton 路由事件
        /// </summary>
        private void OnClickSettingButton()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = MainUiControl.ClickSettingButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion

        #region 路由事件：ClickRepairButton
        /// <summary>
        /// 路由事件：ClickRepairButtonEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickRepairButtonEvent;


        /// <summary>
        /// 路由事件的属性：ClickRepairButton
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> ClickRepairButton
        {
            //添加一条事件
            add { AddHandler(ClickRepairButtonEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickRepairButtonEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 ClickRepairButton 路由事件
        /// </summary>
        private void OnClickRepairButton()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = MainUiControl.ClickRepairButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion

        #region 路由事件：ClickConvertButton
        /// <summary>
        /// 路由事件：ClickConvertButtonEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickConvertButtonEvent;


        /// <summary>
        /// 路由事件的属性：ClickConvertButton
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> ClickConvertButton
        {
            //添加一条事件
            add { AddHandler(ClickConvertButtonEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickConvertButtonEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 ClickConvertButton 路由事件
        /// </summary>
        private void OnClickConvertButton()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = MainUiControl.ClickConvertButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion



        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static MainUiControl()
        {
            /*注册路由事件*/
            //注册ClickMinimizeButtonEvent
            ClickMinimizeButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickMinimizeButton", //事件的名字
                RoutingStrategy.Bubble, //路由事件的类型（是冒泡还是隧道？Bubble是冒泡，Tunnel是隧道）
                typeof(RoutedPropertyChangedEventHandler<bool>), //路由事件要处理的数据类型
                typeof(MainUiControl) //这个路由事件属于哪个控件？
            );

            //注册ClickCloseButtonEvent
            ClickCloseButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickCloseButton", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<bool>), typeof(MainUiControl));

            //注册ClickSettingButtonEvent
            ClickSettingButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickSettingButton", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<bool>), typeof(MainUiControl));

            //注册ClickRepairButtonEvent
            ClickRepairButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickRepairButton", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<bool>), typeof(MainUiControl));

            //注册ClickConvertButtonEvent
            ClickConvertButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickConvertButton", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<bool>), typeof(MainUiControl));
        }
        #endregion






        #region [事件]
        /// <summary>
        /// 当点击[最小化]按钮时
        /// </summary>
        private void MinimizeButtonControl_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            this.OnClickMinimizeButton();//触发[点击最小化按钮]的事件
        }

        /// <summary>
        /// 当点击[关闭]按钮时
        /// </summary>
        private void CloseButtonControl_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            this.OnClickCloseButton();//触发[点击关闭按钮]的事件
        }

        /// <summary>
        /// 当点击[设置]按钮时
        /// </summary>
        private void SettingButtonControl_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            this.OnClickSettingButton();//触发[点击设置按钮]的事件
        }

        /// <summary>
        /// 当点击[修复项目]按钮时
        /// </summary>
        private void RepairButtonControl_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            this.OnClickRepairButton();//触发[点击修复项目按钮]的事件
        }

        /// <summary>
        /// 当点击[转换项目]按钮时
        /// </summary>
        private void ConvertButtonControl_OnClick(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            this.OnClickConvertButton();//触发[点击转换项目按钮]的事件
        }
        #endregion

        #region [拖动窗口]
        /// <summary>
        /// 当在窗口顶部的矩形中，按下鼠标左键的时候：拖动窗口的时候
        /// </summary>
        private void WindowTitleBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            /* 当点击拖拽区域的时候，让窗口跟着移动 */
            AppManager.MainWindow.DragMove();
        }
        #endregion
    }
}
