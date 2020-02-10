/* By: 絮大王（sukiup@163.com）
   Time：2019年10月31日13:25:54*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace EasyBugManagerTool
{
    /// <summary>
    /// 动画工具
    /// </summary>
    public static class AnimationTool
    {
        /// <summary>
        /// 播放按钮动画
        /// (让按钮的尺寸(Scale) 变小/变大)
        /// </summary>
        /// <param name="_isPress">是否是按下？（true:按下的动画；false:抬起的动画）</param>
        /// <param name="_pressAnimationSize">按下的时候，缩放的大小</param>
        /// <param name="_buttonScaleTransform">要缩放的Button组件的ScaleTransform</param>
        public static void PlayButtonAnimation(bool _isPress, Point _pressAnimationSize, ScaleTransform _buttonScaleTransform)
        {
            /* 音效 */
            if (_isPress == true) 
            {
                AppManager.Systems.AudioSystem.PlayAudio(AudioType.ButtonDown);//播放音效
            }





            /* 动画 */
            DoubleAnimation _animationX = new DoubleAnimation();//X轴的动画
            DoubleAnimation _animationY = new DoubleAnimation();//Y轴的动画


            switch (_isPress)
            {
                //如果是"按钮按下的动画"
                case true:
                    _animationX.From = 1;
                    _animationX.To = _pressAnimationSize.X;
                    _animationX.Duration = TimeSpan.FromSeconds(0.1f);

                    _animationY.From = 1;
                    _animationY.To = _pressAnimationSize.Y;
                    _animationY.Duration = TimeSpan.FromSeconds(0.1f);
                    break;

                //如果是"按钮抬起的动画"
                case false:
                    _animationX.From = _pressAnimationSize.X;
                    _animationX.To = 1;
                    _animationX.Duration = TimeSpan.FromSeconds(0.1f);

                    _animationY.From = _pressAnimationSize.Y;
                    _animationY.To = 1;
                    _animationY.Duration = TimeSpan.FromSeconds(0.1f);
                    break;
            }


            //播放动画 (让按钮的尺寸(Scale) 变小/变大)
            _buttonScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, _animationX, HandoffBehavior.SnapshotAndReplace);
            _buttonScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, _animationY, HandoffBehavior.SnapshotAndReplace);

        }



        /// <summary>
        /// 播放[Grid控件]的[Opacity属性]的动画
        /// </summary>
        /// <param name="_grid">要执行动画的网格</param>
        /// <param name="_from">开始值（如果为null，就表示从当前值开始）</param>
        /// <param name="_to">结束值</param>
        /// <param name="_durationSeconds">间隔市场(单位：秒)</param>
        /// <param name="_completed">完成时，要触发的事件</param>
        public static void PlayGridOpacityAnimation(Grid _grid, double? _from, double? _to, float _durationSeconds, EventHandler _completed = null)
        {
            /* 动画 */
            DoubleAnimation _animation = new DoubleAnimation();

            //设置动画的属性
            _animation.From = _from;
            _animation.To = _to;
            _animation.Duration = TimeSpan.FromSeconds(_durationSeconds);
            if (_completed != null)
            {
                _animation.Completed += _completed;
            }




            //播放动画
            _grid.BeginAnimation(Grid.OpacityProperty, _animation, HandoffBehavior.SnapshotAndReplace);
        }
    }
}
