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
    /// SettingsUiControl.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsUiControl : UserControl
    {
        /* 属性: Language(语言)
                 Sound(声音)

           事件: LanguageChange(当语言改变时)
                 SoundChange(当声音改变时)

                 ClickCloseButton(点击Github按钮)
                 ClickGithubButton(点击Github按钮)*/



        public SettingsUiControl()
        {
            InitializeComponent();
        }



        #region 依赖项属性：Language
        /// <summary>
        /// 依赖项属性：语言
        /// </summary>
        public static DependencyProperty LanguageProperty;

        /// <summary>
        /// 公开属性：语言
        /// </summary>
        public LanguageType Language
        {
            get { return (LanguageType)GetValue(LanguageProperty); }
            set { SetValue(LanguageProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当LanguageProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnLanguageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //如果值发生改变了
            if ((LanguageType)e.OldValue != (LanguageType)e.NewValue)
            {
                //获取控件
                SettingsUiControl _settingsUiControl = sender as SettingsUiControl;

                //判断
                switch ((LanguageType)e.NewValue)
                {
                    //如果值为[英文]
                    case LanguageType.English:
                        //打开英语面板，关闭中文面板
                        _settingsUiControl.EnStackPanel.Visibility = Visibility.Visible;
                        _settingsUiControl.CnStackPanel.Visibility = Visibility.Collapsed;
                        //修改CheckGroup
                        _settingsUiControl.EnLanguageCheckGroup.CheckedIndex = 0;
                        _settingsUiControl.CnLanguageCheckGroup.CheckedIndex = 0;
                        break;

                    //如果值为[中文]
                    case LanguageType.Chinese:
                        //打开中文面板，关闭英文面板
                        _settingsUiControl.EnStackPanel.Visibility = Visibility.Collapsed;
                        _settingsUiControl.CnStackPanel.Visibility = Visibility.Visible;
                        //修改CheckGroup
                        _settingsUiControl.EnLanguageCheckGroup.CheckedIndex = 1;
                        _settingsUiControl.CnLanguageCheckGroup.CheckedIndex = 1;
                        break;
                }

                //触发事件
                _settingsUiControl.OnLanguageChange((LanguageType)e.NewValue);
            }
        }
        #endregion

        #region 依赖项属性：Sound
        /// <summary>
        /// 依赖项属性：声音
        /// </summary>
        public static DependencyProperty SoundProperty;

        /// <summary>
        /// 公开属性：声音
        /// </summary>
        public bool Sound
        {
            get { return (bool)GetValue(SoundProperty); }
            set { SetValue(SoundProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当SoundProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnSoundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //如果值发生改变了
            if ((bool)e.OldValue != (bool)e.NewValue)
            {
                //获取控件
                SettingsUiControl _settingsUiControl = sender as SettingsUiControl;

                //判断
                switch ((bool)e.NewValue)
                {
                    //如果值为[开]
                    case true:
                        //修改CheckGroup
                        _settingsUiControl.EnSoundCheckGroup.CheckedIndex = 0;
                        _settingsUiControl.CnSoundCheckGroup.CheckedIndex = 0;
                        break;

                    //如果值为[关]
                    case false:
                        //修改CheckGroup
                        _settingsUiControl.EnSoundCheckGroup.CheckedIndex = 1;
                        _settingsUiControl.CnSoundCheckGroup.CheckedIndex = 1;
                        break;
                }

                //触发事件
                _settingsUiControl.OnSoundChange((bool)e.NewValue);
            }
        }
        #endregion



        #region 路由事件：ClickCloseButton

        /// <summary>
        /// 路由事件：ClickCloseButtonEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickCloseButtonEvent;


        /// <summary>
        /// 路由事件的属性：Click
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
            args.RoutedEvent = SettingsUiControl.ClickCloseButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }

        #endregion

        #region 路由事件：ClickGithubButton

        /// <summary>
        /// 路由事件：ClickGithubButtonEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickGithubButtonEvent;


        /// <summary>
        /// 路由事件的属性：Click
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> ClickGithubButton
        {
            //添加一条事件
            add { AddHandler(ClickGithubButtonEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickGithubButtonEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 ClickGithubButton 路由事件
        /// </summary>
        private void OnClickGithubButton()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = SettingsUiControl.ClickGithubButtonEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }

        #endregion


        #region 路由事件：LanguageChange

        /// <summary>
        /// 路由事件：LanguageChangeEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent LanguageChangeEvent;


        /// <summary>
        /// 路由事件的属性：LanguageChange
        /// </summary>
        public event RoutedPropertyChangedEventHandler<LanguageType> LanguageChange
        {
            //添加一条事件
            add { AddHandler(LanguageChangeEvent, value); }

            //移除一条事件
            remove { RemoveHandler(LanguageChangeEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 LanguageChange 路由事件
        /// </summary>
        /// <param name="_newValue">新的Language属性的值</param>
        private void OnLanguageChange(LanguageType _newValue)
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<LanguageType> args = new RoutedPropertyChangedEventArgs<LanguageType>(_newValue, _newValue);

            //设置这是哪个路由事件？
            args.RoutedEvent = SettingsUiControl.LanguageChangeEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion

        #region 路由事件：SoundChange

        /// <summary>
        /// 路由事件：SoundChangeEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent SoundChangeEvent;


        /// <summary>
        /// 路由事件的属性：SoundChange
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> SoundChange
        {
            //添加一条事件
            add { AddHandler(SoundChangeEvent, value); }

            //移除一条事件
            remove { RemoveHandler(SoundChangeEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 SoundChange 路由事件
        /// </summary>
        /// <param name="_newValue">新的Sound属性的值</param>
        private void OnSoundChange(bool _newValue)
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(_newValue, _newValue);

            //设置这是哪个路由事件？
            args.RoutedEvent = SettingsUiControl.SoundChangeEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }

        #endregion



        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static SettingsUiControl()
        {
            /*注册依赖项属性*/
            //注册LanguageProperty
            LanguageProperty = DependencyProperty.Register(
                "Language", //属性的名字
                typeof(LanguageType), //属性的类型
                typeof(SettingsUiControl), //这个属性属于哪个控件？
                new FrameworkPropertyMetadata( //属性的初始值和回调函数
                                               //初始值
                    (LanguageType)LanguageType.None,
                    //当属性的值发生改变时，调用什么方法？
                    new PropertyChangedCallback(OnLanguageChanged))
            );

            //注册SoundProperty
            SoundProperty = DependencyProperty.Register(
                "Sound", typeof(bool), typeof(SettingsUiControl),
                new FrameworkPropertyMetadata((bool)true, new PropertyChangedCallback(OnSoundChanged)));




            /*注册路由事件*/
            //注册ClickCloseButtonEvent
            ClickCloseButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickCloseButton", //事件的名字
                RoutingStrategy.Bubble, //路由事件的类型（是冒泡还是隧道？Bubble是冒泡，Tunnel是隧道）
                typeof(RoutedPropertyChangedEventHandler<bool>), //路由事件要处理的数据类型
                typeof(SettingsUiControl) //这个路由事件属于哪个控件？
            );

            //注册ClickGithubButtonEvent
            ClickGithubButtonEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "ClickGithubButton", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<bool>), typeof(SettingsUiControl));



            //注册LanguageChangeEvent
            LanguageChangeEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "LanguageChange", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<LanguageType>), typeof(SettingsUiControl));

            //注册SoundChangeEvent
            SoundChangeEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "SoundChange", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<bool>), typeof(SettingsUiControl));

        }
        #endregion



        #region [事件 - CheckGroup]
        //当[语言]的选中项改变时
        private void LanguageCheckGroup_CheckedChange(object sender, RoutedPropertyChangedEventArgs<int> e)
        {
            //获取控件
            ImageCheckGroupControl _imageCheckGroupControl = sender as ImageCheckGroupControl;

            //判断
            switch (_imageCheckGroupControl.CheckedIndex)
            {
                //如果为0
                case 0:
                    Language = LanguageType.English;
                    break;

                //如果为1
                case 1:
                    Language = LanguageType.Chinese;
                    break;
            }
        }

        //当[声音]的选中项改变时
        private void SoundCheckGroup_CheckedChange(object sender, RoutedPropertyChangedEventArgs<int> e)
        {
            //获取控件
            ImageCheckGroupControl _imageCheckGroupControl = sender as ImageCheckGroupControl;

            //判断
            switch (_imageCheckGroupControl.CheckedIndex)
            {
                //如果为0
                case 0:
                    Sound = true;
                    break;

                //如果为1
                case 1:
                    Sound = false;
                    break;
            }
        }
        #endregion

        #region [事件 - 按钮]
        //当点击[Close]按钮时
        private void CloseButtonControl_Click(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            this.OnClickCloseButton();//触发事件
        }

        //当点击[Github]按钮时
        private void GithubButtonControl_Click(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            this.OnClickGithubButton();//触发事件
        }
        #endregion

        #region [事件 - Staff面板]
        //当鼠标进入[Staff]按钮或者按钮时
        private void StaffButtonControl_MouseEnter(object sender, MouseEventArgs e)
        {
            //打开Staff面板
            this.StaffGrid.Visibility = Visibility.Visible;
            AnimationTool.PlayGridOpacityAnimation(this.StaffGrid, null, 1, 0.25f);
        }

        //当鼠标离开[Staff]按钮或者按钮时
        private void StaffButtonControl_MouseLeave(object sender, MouseEventArgs e)
        {
            //关闭Staff面板
            this.StaffGrid.Visibility = Visibility.Collapsed;
            AnimationTool.PlayGridOpacityAnimation(this.StaffGrid, null, 0, 0.25f);
        }
        #endregion
    }
}
