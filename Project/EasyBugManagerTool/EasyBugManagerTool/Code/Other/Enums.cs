/* By: 絮大王（xudawang@vip.163.com）
   Time：2019年10月12日07:40:11*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBugManagerTool
{
    /*所有的枚举类型*/


    /// <summary>
    /// 语言类型
    /// </summary>
    public enum LanguageType : byte
    {
        None,
        English,//英语
        Chinese//中文
    }

    /// <summary>
    /// 模式类型
    /// </summary>
    public enum ModeType : byte
    {
        None,
        Default,//[默认]模式
        Collaboration,//[协同合作]模式（Teamwork）
    }

    /// <summary>
    /// 时间格式类型
    /// </summary>
    public enum TimeFormatType:byte
    {
        None,
        YearMonthDay,//年.月.日
        YearMonthDayHourMinute,//年.月.日 时:分
        YearMonthDayHourMinuteSecond,//年.月.日 时:分:秒
        YearMonthDayHourMinuteSecondMillisecond,//年 月 日 时 分 秒 毫秒
        HourMinuteSecond,//时:分:秒
    }

    /// <summary>
    /// 工具类型
    /// </summary>
    public enum ToolType : byte
    {
        None,
        Convert,//[转换]工具
        Repair,//[修复]工具
    }






    /// <summary>
    /// 枚举类（和枚举相关的属性和方法）
    /// </summary>
    public static class Enums
    {
        #region [公开方法 - 对比]

        /// <summary>
        /// 对比2个枚举值的大小
        /// </summary>
        /// <param name="_value1">第1个枚举值</param>
        /// <param name="_value2">第2个枚举值</param>
        /// <returns>1代表第1个比第2个Bug大(大的排后面)；0代表第1个比第2个Bug相等，-1代表第1个比第2个Bug小</returns>
        public static int EnumValueCompare(int _value1, int _value2)
        {
            if (_value1 > _value2)
            {
                return 1;
            }
            else if (_value1 < _value2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        #endregion
    } 
}
