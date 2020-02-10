/* By: 絮大王（xudawang@vip.163.com）
   Time：2019年11月23日03:02:43*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBugManagerTool
{
    /// <summary>
    /// Bug的基础数据
    /// (用于保存和读取)
    /// </summary>
    public class BugBaseData
    {
        #region [属性]
        /// <summary>
        /// 编号（如果Id为-1，就代表这个Bug不存在）
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 完成度
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 创建时间（年、月、日、时、分、秒）
        /// </summary>
        public List<int> CreateTime { get; set; }

        /// <summary>
        /// 完成时间（年、月、日、时、分、秒）
        /// </summary>
        public List<int> SolveTime { get; set; }

        /// <summary>
        /// 更新时间（年、月、日、时、分、秒）
        /// </summary>
        public List<int> UpdateTime { get; set; }

        /// <summary>
        /// 更新次数
        /// </summary>
        public int UpdateNumber { get; set; }



        /// <summary>
        /// 性格的编号（虫子的性格）
        /// </summary>
        public int TemperamentId { get; set; }

        /// <summary>
        /// 是否删除？（true代表已删除，false代表未删除）
        /// </summary>
        public bool IsDelete { get; set; }
        #endregion


        #region [构造方法]

        public BugBaseData()
        {
            Id = -1;
            Name = "";
            Progress = 0;
            Priority = 0;
            CreateTime = new List<int>();
            SolveTime = new List<int>();
            UpdateTime = new List<int>();
            UpdateNumber = 0;
            TemperamentId = -1;
            IsDelete = false;
        }

        #endregion
    }
}
