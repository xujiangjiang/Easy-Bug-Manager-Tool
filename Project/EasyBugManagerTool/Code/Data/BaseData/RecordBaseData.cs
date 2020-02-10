/* By: 絮大王（sukiup@163.com）
   Time：2019年11月14日22:30:29*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBugManagerTool
{
    /// <summary>
    /// 记录的基础数据
    /// (用于保存和读取)
    /// </summary>
    public class RecordBaseData
    {
        /* 属性：Id(编号)
                 BugId(Bug的编号)（这个Record属于哪个Bug？）
                 ReplyId(回复的编号)（用Bug中的TemperamentId和ReplyId，可以获取到Bug回复的内容）

                 Content(内容)
                 Time(时间)
                 Images(图片)(路径)
                 IsDelete(是否删除？)（true代表已删除，false代表未删除）*/


        #region [属性]
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Bug的编号（这个Record属于哪个Bug？）
        /// </summary>
        public long BugId { get; set; }

        /// <summary>
        /// 回复的编号（用Bug中的TemperamentId和ReplyId，可以获取到Bug回复的内容）
        /// </summary>
        public int ReplyId { get; set; }



        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public List<int> Time { get; set; }

        /// <summary>
        /// 图片（路径）
        /// </summary>
        public List<string> Images { get; set; }

        /// <summary>
        /// 是否删除？（true代表已删除，false代表未删除）
        /// </summary>
        public bool IsDelete { get; set; }
        #endregion


        #region [构造方法]

        public RecordBaseData()
        {
            Id = -1;
            BugId = -1;
            ReplyId = -1;

            Content = "";
            Time = new List<int>();
            Images = new List<string>();
            IsDelete = false;
        }

        #endregion

    }
}
