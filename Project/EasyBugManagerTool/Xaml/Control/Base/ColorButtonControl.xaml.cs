﻿using System;
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
    /// ColorButtonControl.xaml 的交互逻辑
    /// </summary>
    public partial class ColorButtonControl : UserControl
    {
        /* 属性: BorderThickness(线段的宽度)
                 CornerRadius(圆角的角度)
                 PressAnimationSize(按下按钮时 动画缩小的尺寸)
                 MouseEnterBackground(鼠标进入时的背景颜色) 
                 MouseLeaveBackground(鼠标移出时的背景颜色)
                 MouseEnterBorderBrush(鼠标进入时的线段颜色) 
                 MouseLeaveBorderBrush(鼠标移出时的线段颜色)

           事件: OnClick(当点击按钮的时候)*/



        public ColorButtonControl()
        {
            InitializeComponent();
        }



        #region 依赖项属性：BorderThickness

        /// <summary>
        /// 依赖项属性：线段的宽度
        /// </summary>
        public static DependencyProperty BorderThicknessProperty;

        /// <summary>
        /// 公开属性：线段的宽度
        /// </summary>
        public Thickness BorderThickness
        {
            get { return (Thickness)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当BorderThicknessProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnBorderThicknessChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion

        #region 依赖项属性：CornerRadius
        /// <summary>
        /// 依赖项属性：圆角的角度
        /// </summary>
        public static DependencyProperty CornerRadiusProperty;

        /// <summary>
        /// 公开属性：圆角的角度
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当CornerRadiusProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnCornerRadiusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion

        #region 依赖项属性：PressAnimationSize
        /// <summary>
        /// 依赖项属性：按下按钮时 动画缩小的尺寸
        /// </summary>
        public static DependencyProperty PressAnimationSizeProperty;

        /// <summary>
        /// 公开属性：按下按钮时 动画缩小的尺寸
        /// </summary>
        public Point PressAnimationSize
        {
            get { return (Point)GetValue(PressAnimationSizeProperty); }
            set { SetValue(PressAnimationSizeProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当PressAnimationSizeProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnPressAnimationSizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion

        #region 依赖项属性：MouseEnterBackground

        /// <summary>
        /// 依赖项属性：鼠标进入时的背景颜色
        /// </summary>
        public static DependencyProperty MouseEnterBackgroundProperty;

        /// <summary>
        /// 公开属性：鼠标进入时的背景颜色
        /// </summary>
        public SolidColorBrush MouseEnterBackground
        {
            get { return (SolidColorBrush)GetValue(MouseEnterBackgroundProperty); }
            set { SetValue(MouseEnterBackgroundProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当MouseEnterBackgroundProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnMouseEnterBackgroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion

        #region 依赖项属性：MouseLeaveBackground

        /// <summary>
        /// 依赖项属性：鼠标移出时的背景颜色
        /// </summary>
        public static DependencyProperty MouseLeaveBackgroundProperty;

        /// <summary>
        /// 公开属性：鼠标移出时的背景颜色
        /// </summary>
        public SolidColorBrush MouseLeaveBackground
        {
            get { return (SolidColorBrush)GetValue(MouseLeaveBackgroundProperty); }
            set { SetValue(MouseLeaveBackgroundProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当MouseLeaveBackgroundProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnMouseLeaveBackgroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion

        #region 依赖项属性：MouseEnterBorderBrush

        /// <summary>
        /// 依赖项属性：鼠标进入时的线段颜色
        /// </summary>
        public static DependencyProperty MouseEnterBorderBrushProperty;

        /// <summary>
        /// 公开属性：鼠标进入时的线段颜色
        /// </summary>
        public SolidColorBrush MouseEnterBorderBrush
        {
            get { return (SolidColorBrush)GetValue(MouseEnterBorderBrushProperty); }
            set { SetValue(MouseEnterBorderBrushProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当MouseEnterBorderBrushProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnMouseEnterBorderBrushChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion

        #region 依赖项属性：MouseLeaveBackground

        /// <summary>
        /// 依赖项属性：鼠标移出时的线段颜色
        /// </summary>
        public static DependencyProperty MouseLeaveBorderBrushProperty;

        /// <summary>
        /// 公开属性：鼠标移出时的线段颜色
        /// </summary>
        public SolidColorBrush MouseLeaveBorderBrush
        {
            get { return (SolidColorBrush)GetValue(MouseLeaveBorderBrushProperty); }
            set { SetValue(MouseLeaveBorderBrushProperty, value); }
        }

        /// <summary>
        /// 依赖项属性发生改变时，触发的事件：
        /// 当MouseLeaveBorderBrushProperty依赖项属性，的属性值发生改变的时候，调用这个方法
        /// </summary>
        /// <param name="sender">依赖项对象</param>
        /// <param name="e">依赖项属性改变事件 的参数（里面有这个属性的新的值，和旧的值）</param>
        private static void OnMouseLeaveBorderBrushChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion





        #region 路由事件：Click
        /// <summary>
        /// 路由事件：ClickEvent
        /// （当点击按钮时，触发此事件）
        /// </summary>
        public static readonly RoutedEvent ClickEvent;


        /// <summary>
        /// 路由事件的属性：Click
        /// </summary>
        public event RoutedPropertyChangedEventHandler<bool> Click
        {
            //添加一条事件
            add { AddHandler(ClickEvent, value); }

            //移除一条事件
            remove { RemoveHandler(ClickEvent, value); }
        }


        /// <summary>
        /// 这个方法，用于触发 Click 路由事件
        /// </summary>
        private void OnClick()
        {
            //创建路由事件参数
            RoutedPropertyChangedEventArgs<bool> args = new RoutedPropertyChangedEventArgs<bool>(true, true);

            //设置这是哪个路由事件？
            args.RoutedEvent = ColorButtonControl.ClickEvent;

            //引发这个路由事件
            RaiseEvent(args);
        }
        #endregion




        #region 静态构造方法：注册依赖项属性 和 路由事件
        /// <summary>
        /// 静态构造方法：在里面注册依赖项属性 和 路由事件
        /// </summary>
        static ColorButtonControl()
        {
            /*注册依赖项属性*/
            //注册BorderThicknessProperty
            BorderThicknessProperty = DependencyProperty.Register(
                "BorderThickness", //属性的名字
                typeof(Thickness), //属性的类型
                typeof(ColorButtonControl), //这个属性属于哪个控件？
                new FrameworkPropertyMetadata( //属性的初始值和回调函数
                                               //初始值
                    (Thickness)new Thickness(0),
                    //当属性的值发生改变时，调用什么方法？
                    new PropertyChangedCallback(OnBorderThicknessChanged))
            );

            //注册CornerRadiusProperty
            CornerRadiusProperty = DependencyProperty.Register(
                "CornerRadius", typeof(CornerRadius), typeof(ColorButtonControl),
                new FrameworkPropertyMetadata((CornerRadius)new CornerRadius(0),
                    new PropertyChangedCallback(OnCornerRadiusChanged)));

            //注册PressAnimationSizeProperty
            PressAnimationSizeProperty = DependencyProperty.Register(
                "PressAnimationSize", typeof(Point), typeof(ColorButtonControl),
                new FrameworkPropertyMetadata((Point)new Point(0.75f, 0.75f), new PropertyChangedCallback(OnPressAnimationSizeChanged)));

            //注册MouseEnterBackgroundProperty
            MouseEnterBackgroundProperty = DependencyProperty.Register(
                "MouseEnterBackground", typeof(SolidColorBrush), typeof(ColorButtonControl),
                new FrameworkPropertyMetadata((SolidColorBrush)null, new PropertyChangedCallback(OnMouseEnterBackgroundChanged)));

            //注册MouseLeaveBackgroundProperty
            MouseLeaveBackgroundProperty = DependencyProperty.Register(
                "MouseLeaveBackground", typeof(SolidColorBrush), typeof(ColorButtonControl),
                new FrameworkPropertyMetadata((SolidColorBrush)null, new PropertyChangedCallback(OnMouseLeaveBackgroundChanged)));

            //注册MouseEnterBorderBrushProperty
            MouseEnterBorderBrushProperty = DependencyProperty.Register(
                "MouseEnterBorderBrush", typeof(SolidColorBrush), typeof(ColorButtonControl),
                new FrameworkPropertyMetadata((SolidColorBrush)null, new PropertyChangedCallback(OnMouseEnterBorderBrushChanged)));

            //注册MouseLeaveBorderBrushProperty
            MouseLeaveBorderBrushProperty = DependencyProperty.Register(
                "MouseLeaveBorderBrush", typeof(SolidColorBrush), typeof(ColorButtonControl),
                new FrameworkPropertyMetadata((SolidColorBrush)null, new PropertyChangedCallback(OnMouseLeaveBorderBrushChanged)));







            /*注册路由事件*/
            //注册ClickEvent
            ClickEvent = System.Windows.EventManager.RegisterRoutedEvent(
                "Click", //事件的名字
                RoutingStrategy.Bubble, //路由事件的类型（是冒泡还是隧道？Bubble是冒泡，Tunnel是隧道）
                typeof(RoutedPropertyChangedEventHandler<bool>), //路由事件要处理的数据类型
                typeof(ColorButtonControl) //这个路由事件属于哪个控件？
            );

        }
        #endregion



        #region 事件 -[点击按钮动画]
        //当鼠标进入[按钮]的时候，触发此方法
        private void BaseButton_OnMouseEnter(object sender, MouseEventArgs e)
        {
            /* 更改按钮的背景 */
            this.ButtonImageBorder.Background = MouseEnterBackground;
            this.ButtonImageBorder.BorderBrush = MouseEnterBorderBrush;
        }

        //当鼠标离开[按钮]的时候，触发此方法
        private void BaseButton_OnMouseLeave(object sender, MouseEventArgs e)
        {
            /* 更改按钮的背景 */
            this.ButtonImageBorder.Background = MouseLeaveBackground;
            this.ButtonImageBorder.BorderBrush = MouseLeaveBorderBrush;
        }


        //当鼠标在[按钮]上点击的时候，触发此方法
        private void Button_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            /* 获取"按下动画"，并播放动画 */
            AnimationTool.PlayButtonAnimation(true, this.PressAnimationSize, this.BaseButtonScaleTransform);
        }


        //当鼠标在[按钮]上抬起的时候，触发此方法
        private void Button_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            /* 获取"抬起动画"，并播放动画 */
            AnimationTool.PlayButtonAnimation(false, this.PressAnimationSize, this.BaseButtonScaleTransform);
        }


        //当鼠标在[按钮]上按下的时候，触发此方法
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            //触发点击事件
            OnClick();
        }
        #endregion
    }
}
