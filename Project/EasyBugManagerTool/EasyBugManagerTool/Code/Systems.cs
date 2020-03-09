/* By: 絮大王（xudawang@vip.163.com）
   Time：2020年2月4日04:13:48*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBugManagerTool
{
    /// <summary>
    /// 用于存放所有的系统
    /// </summary>
    public class Systems
    {
        private AudioSystem audioSystem;//[音效]的系统
        private SaveSystem saveSystem;//[存档]的系统
        private LanguageSystem languageSystem;//[语言]的系统
        private ConvertSystem convertSystem;//[转换]的系统
        private RepairSystem repairSystem;//[修复]的系统



        #region [属性]
        /// <summary>
        /// [音效]的系统
        /// </summary>
        public AudioSystem AudioSystem
        {
            get { return audioSystem; }
        }

        /// <summary>
        /// [存档]的系统
        /// </summary>
        public SaveSystem SaveSystem
        {
            get { return saveSystem; }
        }

        /// <summary>
        /// [语言]的系统
        /// </summary>
        public LanguageSystem LanguageSystem
        {
            get { return languageSystem; }
        }

        /// <summary>
        /// [转换]的系统
        /// </summary>
        public ConvertSystem ConvertSystem
        {
            get { return convertSystem; }
        }

        /// <summary>
        /// [修复]的系统
        /// </summary>
        public RepairSystem RepairSystem
        {
            get { return repairSystem; }
        }
        #endregion

        #region [构造方法]
        public Systems()
        {
            audioSystem = new AudioSystem();
            saveSystem = new SaveSystem();
            languageSystem = new LanguageSystem();
            convertSystem = new ConvertSystem();
            repairSystem = new RepairSystem();
        }
        #endregion
    }
}
