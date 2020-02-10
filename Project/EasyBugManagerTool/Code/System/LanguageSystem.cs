/* By: 絮大王（xudawang@vip.163.com）
   Time：2020年2月4日04:37:23*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EasyBugManagerTool
{
    /// <summary>
    /// 语言的系统（用于更换语言）
    /// </summary>
    public class LanguageSystem
    {

        #region [字段]
        /*提示界面*/
        private string tipTitle = "提示";//[提示]的标题
        private string errorTitle = "错误";//[错误]的标题
        private string errorContent = "未知的错误";//[错误]的内容
        private string doneTitle = "操作成功！";//[操作成功]的标题

        /*修复界面*/
        private string repairTitle = "修复项目";//[修复]的标题
        private string projectFileString = "项目文件";//[项目文件]的标题
        private string repairTipContent = "如果你的项目文件发生了损坏，或遗失了数据。\n可以尝试用这个工具修复项目文件。\n（不一定能修复成功）\n（无法修复图片）";//[修复]的提示内容

        /*浏览界面*/
        private string noChooseProjectFileTip = "( 请选择项目的文件呀~ )";//[没有选择项目文件]的提示
        private string noChooseSaveFolderTip = "( 请选择保存的文件夹呀~ )";//[没有选择保存的文件夹]的提示
        private string browseTitle = "保存到哪里？";//[浏览]的标题
        private string projectFoldertring = "保存路径";//[保存路径]的标题

        /*转换界面*/
        private string convertTitle = "转换项目";//[转换]的标题
        private string collaborationModeString = "协同合作模式";//[协同合作模式]的标题
        private string convertTipContent = "这个工具可以把[协同合作模式]的项目，转换为[普通]的项目。\n或者把[普通]的项目，转换为[协同合作模式]的项目";//[转换]的提示内容

        /*浏览界面*/
        
        #endregion


        #region [公开属性 - Tip界面]
        /// <summary>
        /// [提示]的标题
        /// </summary>
        public string TipTitle
        {
            get { return tipTitle; }
            set { tipTitle = value; }
        }


        /// <summary>
        /// [错误]的标题
        /// </summary>
        public string ErrorTitle
        {
            get { return errorTitle; }
            set { errorTitle = value; }
        }


        /// <summary>
        /// [错误]的内容
        /// </summary>
        public string ErrorContent
        {
            get { return errorContent; }
            set { errorContent = value; }
        }




        /// <summary>
        /// [操作完成]的内容
        /// </summary>
        public string DoneTitle
        {
            get { return doneTitle; }
            set { doneTitle = value; }
        }
        #endregion

        #region [公开属性 - 修复界面]
        /// <summary>
        /// [修复的标题]的标题
        /// </summary>
        public string RepairTitle
        {
            get { return repairTitle; }
            set { repairTitle = value; }
        }


        /// <summary>
        /// [项目文件]的标题
        /// </summary>
        public string ProjectFileString
        {
            get { return projectFileString; }
            set { projectFileString = value; }
        }


        /// <summary>
        /// [修复]的提示内容
        /// </summary>
        public string RepairTipContent
        {
            get { return repairTipContent; }
            set { repairTipContent = value; }
        }
        #endregion

        #region [公开属性 - 转换界面]
        /// <summary>
        /// [修复的标题]的标题
        /// </summary>
        public string ConvertTitle
        {
            get { return convertTitle; }
            set { convertTitle = value; }
        }


        /// <summary>
        /// [协同合作模式]的标题
        /// </summary>
        public string CollaborationModeString
        {
            get { return collaborationModeString; }
            set { collaborationModeString = value; }
        }


        /// <summary>
        /// [转换]的提示内容
        /// </summary>
        public string ConvertTipContent
        {
            get { return convertTipContent; }
            set { convertTipContent = value; }
        }
        #endregion

        #region [公开属性 - 浏览界面]
        /// <summary>
        /// [浏览]的标题
        /// </summary>
        public string BrowseTitle
        {
            get { return browseTitle; }
            set { browseTitle = value; }
        }


        /// <summary>
        /// [保存路径]的标题
        /// </summary>
        public string ProjectFoldertring
        {
            get { return projectFoldertring; }
            set { projectFoldertring = value; }
        }


        /// <summary>
        /// [没有选择项目文件]的提示
        /// </summary>
        public string NoChooseProjectFileTip
        {
            get { return noChooseProjectFileTip; }
            set { noChooseProjectFileTip = value; }
        }


        /// <summary>
        /// [没有选择保存的文件夹]的提示
        /// </summary>
        public string NoChooseSaveFolderTip
        {
            get { return noChooseSaveFolderTip; }
            set { noChooseSaveFolderTip = value; }
        }

        #endregion




        #region [公开方法]
        /// <summary>
        /// 按照[语言]进行一些处理 (设置图片和文字等)
        /// </summary>
        /// <param name="_language">语言</param>
        public void Handle(LanguageType _language)
        {
            this.SetImage(_language);//设置图片
            this.SetText(_language);//设置文字
            this.SetOther(_language);//设置其他
        }
        #endregion

        #region [私有方法]
        /// <summary>
        /// 按照语言设置图片
        /// </summary>
        /// <param name="_language">语言</param>
        private void SetImage(LanguageType _language)
        {
            //字典文件的路径
            string _dictionaryFilePath = "";

            //获得资源字典的路径
            switch (_language)
            {
                case LanguageType.Chinese:
                    _dictionaryFilePath = "/EasyBugManagerTool;component/Xaml/Dictionary/ChineseTextDictionary.xaml";
                    break;

                case LanguageType.English:
                    _dictionaryFilePath = "/EasyBugManagerTool;component/Xaml/Dictionary/EnglishTextDictionary.xaml";
                    break;
            }

            //创建1个新的资源字典
            ResourceDictionary _resourceDictionary = new ResourceDictionary();

            //设置资源字典的资源
            _resourceDictionary.Source = new Uri(_dictionaryFilePath, UriKind.Relative);

            //替换资源字典（替换App.xaml中的TextDictionary）
            AppManager.MainApp.Resources.MergedDictionaries[2] = _resourceDictionary;
        }

        /// <summary>
        /// 按照语言设置文字
        /// </summary>
        /// <param name="_language">语言</param>
        private void SetText(LanguageType _language)
        {
            switch (_language)
            {
                /*中文*/
                case LanguageType.Chinese:
                    repairTitle = "修复项目";
                    projectFileString = "项目文件";
                    repairTipContent = "如果你的项目文件发生了损坏，或遗失了数据。\n可以尝试用这个工具修复项目文件。\n（不一定能修复成功）\n（无法修复图片）";

                    convertTitle = "转换项目";
                    collaborationModeString = "协同合作模式";
                    convertTipContent = "这个工具可以把[协同合作模式]的项目，转换为[普通]的项目。\n或者把[普通]的项目，转换为[协同合作模式]的项目";

                    tipTitle = "提示";
                    errorTitle = "错误";

                    noChooseProjectFileTip = "( 请选择项目的文件呀~ )";
                    noChooseSaveFolderTip = "( 请选择保存的文件夹呀~ )";

                    browseTitle = "保存到哪里？";
                    projectFoldertring = "保存路径";

                    errorContent = "未知的错误";
                    doneTitle = "操作成功！";
                    break;

                /*英文*/
                case LanguageType.English:
                    repairTitle = "Repair Project";
                    projectFileString = "Project File";
                    repairTipContent = "If your project file is damaged or data is missing.\nYou can try to repair the project file with this tool.\n(Not necessarily successful)\n(Cannot fix picture)";

                    convertTitle = "Convert Project";
                    collaborationModeString = "Collaboration Mode";
                    convertTipContent = "This tool can convert [Collaboration Mode] projects into [default] projects.\nOr convert [default] projects to [Collaboration mode] projects";

                    tipTitle = "Tip";
                    errorTitle = "Error";

                    noChooseProjectFileTip = "( Please select the project file ~ )";
                    noChooseSaveFolderTip = "( Please choose a folder to save it ~ )";

                    browseTitle = "Where do save the files?";
                    projectFoldertring = "Save Folder";

                    errorContent = "Unknown error.";
                    doneTitle = "Done!";
                    break;
            }
        }

        /// <summary>
        /// 按照语言设置其他
        /// </summary>
        /// <param name="_language">语言</param>
        private void SetOther(LanguageType _language)
        {
        }
        #endregion

    }
}
