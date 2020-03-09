/* By: 絮大王（sukiup@163.com）
   Time：2019年11月23日00:33:21*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBugManagerTool
{
    /// <summary>
    /// 项目的基础数据
    /// (用于保存和读取)
    /// </summary>
    public class ProjectBaseData
    {
        /* 属性：Id(编号)
                Name(项目的名字)
                ModeType(项目的模式：默认模式、协同合作模式)   */



        #region [属性]
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 项目的名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 项目的模式（默认模式、协同合作模式）
        /// </summary>
        public int ModeType { get; set; }

        #endregion


        #region [构造方法]

        public ProjectBaseData()
        {
            Id = -1;
            Name = "";
            ModeType = 1;
        }

        #endregion

    }
}
