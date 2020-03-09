/* By: 絮大王（xudawang@vip.163.com）
   Time：2019年10月14日12:22:24*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EasyBugManagerTool
{
    /// <summary>
    /// 用于保存和读取
    /// </summary>
    public class SaveSystem
    {
        #region [公开方法]
        /// <summary>
        /// 读取
        /// </summary>
        /// <returns>是否读取成功？</returns>
        public bool Load()
        {
            AppManager.Datas.SettingsData.Language = (LanguageType)Properties.Settings.Default.Language;//语言
            AppManager.Datas.SettingsData.Sound = Properties.Settings.Default.Sound;//是否有声音？

            return true;
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>是否保存成功？</returns>
        public bool Save()
        {
            Properties.Settings.Default.Language = (int)AppManager.Datas.SettingsData.Language;//语言
            Properties.Settings.Default.Sound = AppManager.Datas.SettingsData.Sound;//是否有声音？

            //保存
            Properties.Settings.Default.Save();

            return true;
        }
        #endregion
    }
}
