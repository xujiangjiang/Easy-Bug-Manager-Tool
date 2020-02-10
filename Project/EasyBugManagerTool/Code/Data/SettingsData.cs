/* By: 絮大王（sukiup@163.com）
   Time：2019年11月14日22:19:17*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBugManagerTool
{
    /// <summary>
    /// 设置的数据
    /// </summary>
    public class SettingsData: INotifyPropertyChanged
    {
        private LanguageType language;//语言
        private bool sound;//是否有声音？




        #region [属性 - 设置]
        /// <summary>
        /// 语言
        /// </summary>
        public LanguageType Language
        {
            get { return language; }
            set
            {
                language = value;
                PropertyChange("Language");
            }
        }

        /// <summary>
        /// 是否有声音？
        /// </summary>
        public bool Sound
        {
            get { return sound; }
            set
            {
                sound = value;
                PropertyChange("Sound");
            }
        }
        #endregion

        #region [构造方法]

        public SettingsData()
        {
            Language = LanguageType.Chinese;
            Sound = true;
        }

        #endregion






        #region 数据的双向绑定-更新方法

        /// <summary>
        /// 当属性改变的时候，就触发此方法
        /// </summary>
        /// <param name="propertyName">发生改变的属性的名字</param>
        private void PropertyChange(string propertyName)
        {
            if (PropertyChanged != null)//如果此事件被监听
            {
                //就发送通知
                //参数1：是哪个数据类的对象发生了改变？
                //参数2：发生改变的属性名
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// 系统会自动监听此事件
        /// 如果此事件触发了，系统就会去通知相应的控件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 数据的双向绑定-更新方法
    }
}
