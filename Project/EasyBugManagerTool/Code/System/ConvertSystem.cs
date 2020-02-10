/* By: 絮大王（xudawang@vip.163.com）
   Time：2020年2月4日13:16:22*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;

namespace EasyBugManagerTool
{
    /// <summary>
    /// 转换的系统
    /// </summary>
    public class ConvertSystem
    {
        /// <summary>
        /// 转换项目
        /// </summary>
        /// <param name="_projectFilePath">项目文件的路径</param>
        /// <param name="_saveFolderPath">保存文件夹的路径</param>
        /// <param name="_modeType">项目的类型</param>
        /// <returns>转换后的文件夹</returns>
        public string Convert(string _projectFilePath, string _saveFolderPath, ModeType _modeType)
        {
            /* 思路：1.读取所有的Project、Bug、Record的数据
                     2.如果是[协同合作模式]，就如何如何保存文件
                     3.如果是[普通模式]，就如何如何保存文件*/


            try
            {
                /* 读取数据（Project、Bug、Record） */
                ProjectBaseData _projectBaseData;//读取到的项目数据
                List<BugBaseData> _bugBaseDatas;//读取到的Bug数据
                List<RecordBaseData> _recordBaseDatas;//读取到的Record数据
            
                this.LoadData(_projectFilePath,out _projectBaseData,out _bugBaseDatas,out _recordBaseDatas);//读取数据



                /* 创建文件夹 */
                string _newProjectFolderPath = this.CreateFolders(_saveFolderPath);
                string _oldProjectFolderPath = new FileInfo(_projectFilePath).DirectoryName;


                /* 保存数据 */
                this.SaveData(_oldProjectFolderPath, _newProjectFolderPath,_modeType,_projectBaseData,_bugBaseDatas,_recordBaseDatas);


                //返回值
                return _newProjectFolderPath;
            }
            catch (Exception e)
            {
                return "";
            }
        }




        #region [私有方法 - 创建文件]

        /// <summary>
        /// 创建文件夹
        /// (创建：[项目文件夹]、[Bug文件夹]、[记录文件夹]、[图片文件夹]、[备份文件夹])
        /// </summary>
        /// <param name="_saveFolderPath">保存文件夹的路径</param>
        /// <param name="_toolType">工具的类型</param>
        /// <returns>项目文件夹的路径</returns>
        public string CreateFolders(string _saveFolderPath,ToolType _toolType= ToolType.Convert)
        {
            /* 判断[项目]文件夹是否存在，不存在就创建 */
            DirectoryInfo _directoryInfo = new DirectoryInfo(_saveFolderPath);//文件夹的信息
            if (_directoryInfo.Exists == false)
            {
                _directoryInfo.Create();
            }


            /* 创建文件和文件夹 */
            //创建[项目]文件夹（XXXXX/Convert - 202002041325/）
            DirectoryInfo _projectDirectoryInfo = new DirectoryInfo(_saveFolderPath + "/"+_toolType.ToString()+" - " + DateTimeTool.DateTimeToString(DateTime.Now, TimeFormatType.YearMonthDayHourMinuteSecondMillisecond));
            if (_projectDirectoryInfo.Exists == false)
            {
                _projectDirectoryInfo.Create();
            }

            //创建bug文件夹（_projectFolderPath/Bug/）
            DirectoryInfo _bugDirectoryInfo = new DirectoryInfo(_projectDirectoryInfo + "/Bug");
            if (_bugDirectoryInfo.Exists == false)
            {
                _bugDirectoryInfo.Create();
            }

            //创建[Record]文件夹（_projectFolderPath/Record/）
            DirectoryInfo _recordDirectoryInfo = new DirectoryInfo(_projectDirectoryInfo + "/Record");
            if (_recordDirectoryInfo.Exists == false)
            {
                _recordDirectoryInfo.Create();
            }

            //创建[Image]文件夹（_projectFolderPath/Image/）
            DirectoryInfo _imageDirectoryInfo = new DirectoryInfo(_projectDirectoryInfo + "/Image");
            if (_imageDirectoryInfo.Exists == false)
            {
                _imageDirectoryInfo.Create();
            }

            //创建[Backup]文件夹（_projectFolderPath/Backup/）
            DirectoryInfo _backupDirectoryInfo = new DirectoryInfo(_projectDirectoryInfo + "/Backup");
            if (_backupDirectoryInfo.Exists == false)
            {
                _backupDirectoryInfo.Create();
            }





            /*创建[Backup]文件夹（_projectFolderPath/Backup/）*/
            DirectoryInfo _projectBackupDirectoryInfo = new DirectoryInfo(_projectDirectoryInfo + "/Backup/Project");
            //如果没有文件夹，就创建文件夹
            if (_projectBackupDirectoryInfo.Exists == false)
            {
                _projectBackupDirectoryInfo.Create();
            }

            /*创建[Backup/Bug]文件夹（_projectFolderPath/Backup/Bug/）*/
            DirectoryInfo _bugBackupDirectoryInfo = new DirectoryInfo(_projectDirectoryInfo + "/Backup/Bug");
            //如果没有文件夹，就创建文件夹
            if (_bugBackupDirectoryInfo.Exists == false)
            {
                _bugBackupDirectoryInfo.Create();
            }

            /*创建[Backup/Record]文件夹（_projectFolderPath/Backup/Record/）*/
            DirectoryInfo _recordBackupDirectoryInfo = new DirectoryInfo(_projectDirectoryInfo + "/Backup/Record");
            //如果没有文件夹，就创建文件夹
            if (_recordBackupDirectoryInfo.Exists == false)
            {
                _recordBackupDirectoryInfo.Create();
            }







            return _projectDirectoryInfo.FullName;
        }

        #endregion

        #region [私有方法 - 数据]
        /// <summary>
        /// 读取数据（Project、Bug、Record）
        /// </summary>
        /// <param name="_projectFilePath">项目文件的路径</param>
        /// <param name="_projectBaseData">读取到的项目数据</param>
        /// <param name="_bugBaseDatas">读取到的Bug数据</param>
        /// <param name="_recordBaseDatas">读取到的Record数据</param>
        private void LoadData(string _projectFilePath,
                              out ProjectBaseData _projectBaseData,out List<BugBaseData> _bugBaseDatas, out List<RecordBaseData> _recordBaseDatas)
        {
            /*获取Project的文件信息*/
            FileInfo _projectFileInfo = new FileInfo(_projectFilePath);




            /* 读取Project数据 */
            //读取[项目名.bugs]的Json文本中的内容
            string _projectJsonText = File.ReadAllText(_projectFilePath);

            //然后把Json文本解析成ProjectBaseData对象
            _projectBaseData = JsonMapper.ToObject<ProjectBaseData>(_projectJsonText);




            /* 读取Bug数据 */
            _bugBaseDatas = new List<BugBaseData>();

            //如果是[默认]模式
            if ((ModeType)_projectBaseData.ModeType == ModeType.Default)
            {
                //读取[Bug]的Json文本中的内容
                string _bugsJsonText = File.ReadAllText(_projectFileInfo.DirectoryName + "/Bug/Bugs.json");

                //然后把Json文本解析成BugBaseData对象
                _bugBaseDatas = JsonMapper.ToObject<List<BugBaseData>>(_bugsJsonText);
            }

            //如果是[协同合作]模式
            else if ((ModeType)_projectBaseData.ModeType == ModeType.Collaboration)
            {
                //取到Bug文件夹 的信息
                DirectoryInfo _bugDirectoryInfo = new DirectoryInfo(_projectFileInfo.DirectoryName + "/Bug");

                //获取到Bug文件夹内所有的文件 的信息
                FileInfo[] _bugFileInfos = _bugDirectoryInfo.GetFiles();

                //遍历所有的Bug文件
                for (int i = 0; i < _bugFileInfos.Length; i++)
                {
                    //取到Bug文件的名字
                    string _bugFileName = Path.GetFileNameWithoutExtension(_bugFileInfos[i].FullName);

                    //把[Bug文件的名字]转换为[BugId]
                    _bugFileName = _bugFileName.Replace("Bug - ", "");
                    long _bugId = -1;
                    bool _isParseOk = long.TryParse(_bugFileName, out _bugId);//把string转换为long

                    //如果转换成功
                    if (_isParseOk == true)
                    {
                        //就读取这个Bug
                        string _bugJsonText = File.ReadAllText(_bugFileInfos[i].FullName);

                        //然后把Json文本解析成BugBaseData对象
                        BugBaseData _bugBaseData = JsonMapper.ToObject<BugBaseData>(_bugJsonText);

                        //把BugBaseData对象，加入到列表中
                        _bugBaseDatas.Add(_bugBaseData);
                    }
                }
            }




            /* 读取Record数据 */
            _recordBaseDatas = new List<RecordBaseData>();

            //如果是[默认]模式
            if ((ModeType)_projectBaseData.ModeType == ModeType.Default)
            {
                //读取[Record]的Json文本中的内容
                string _recordsJsonText = File.ReadAllText(_projectFileInfo.DirectoryName + "/Record/Records.json");

                //然后把Json文本解析成RecordBaseData对象
                _recordBaseDatas = JsonMapper.ToObject<List<RecordBaseData>>(_recordsJsonText);
            }

            //如果是[协同合作]模式
            else if ((ModeType)_projectBaseData.ModeType == ModeType.Collaboration)
            {
                //取到Record文件夹 的信息
                DirectoryInfo _recordDirectoryInfo = new DirectoryInfo(_projectFileInfo.DirectoryName + "/Record");

                //获取到Record文件夹内所有的文件 的信息
                FileInfo[] _recordFileInfos = _recordDirectoryInfo.GetFiles();

                //遍历所有的Record文件
                for (int i = 0; i < _recordFileInfos.Length; i++)
                {
                    //取到Record文件的名字
                    string _recordFileName = Path.GetFileNameWithoutExtension(_recordFileInfos[i].FullName);

                    //把[Record文件的名字]转换为[RecordId]
                    _recordFileName = _recordFileName.Replace("Record - ", "");
                    long _recordId = -1;
                    bool _isParseOk = long.TryParse(_recordFileName, out _recordId);//把string转换为long

                    //如果转换成功
                    if (_isParseOk == true)
                    {
                        //就读取这个Record
                        string _recordJsonText = File.ReadAllText(_recordFileInfos[i].FullName);

                        //然后把Json文本解析成RecordBaseData对象
                        RecordBaseData _recordBaseData = JsonMapper.ToObject<RecordBaseData>(_recordJsonText);

                        //把RecordBaseData对象，加入到列表中
                        _recordBaseDatas.Add(_recordBaseData);
                    }
                }
            }
        }

        /// <summary>
        /// 保存数据（Project、Bug、Record）
        /// </summary>
        /// <param name="_oldProjectFolderPath">旧的Project文件夹的路径</param>
        /// <param name="_newProjectFolderPath">新的Project文件夹的路径</param>
        /// <param name="_modeType">项目的类型</param>
        /// <param name="_projectBaseData">读取到的项目数据</param>
        /// <param name="_bugBaseDatas">读取到的Bug数据</param>
        /// <param name="_recordBaseDatas">读取到的Record数据</param>
        public void SaveData(string _oldProjectFolderPath, string _newProjectFolderPath, ModeType _modeType,
                              ProjectBaseData _projectBaseData, List<BugBaseData> _bugBaseDatas, List<RecordBaseData> _recordBaseDatas)
        {
            /* 保存Project */
            //修改项目的类型
            _projectBaseData.ModeType = (int)_modeType;

            //把ProjectBaseData转换为json
            string _projectJsonText = JsonMapper.ToJson(_projectBaseData);

            //Project文件的路径
            string _projectFilePath = _newProjectFolderPath + "/Project.bugs";

            //把json文件保存到[项目名.bugs]文件里
            File.WriteAllText(_projectFilePath, _projectJsonText, Encoding.Default);




            /* 保存Bug */
            //如果是[默认]模式
            if (_modeType == ModeType.Default)
            {
                //把BugBaseData转换为json
                string _bugsJsonText = JsonMapper.ToJson(_bugBaseDatas);

                //Bug文件的路径（文件夹+文件名+后缀）
                string _bugsFilePath = _newProjectFolderPath + "/Bug/Bugs.json";

                //把json文件保存到[Bugs.json]文件里
                File.WriteAllText(_bugsFilePath, _bugsJsonText, Encoding.Default);
            }

            //如果是[协同合作]模式
            else if (_modeType == ModeType.Collaboration)
            {
                for (int i = 0; i < _bugBaseDatas.Count; i++)
                {
                    if (_bugBaseDatas[i] != null)
                    {
                        //取到BugBaseDatas
                        BugBaseData _bugBaseData = _bugBaseDatas[i];

                        //把BugBaseData转换为json
                        string _bugJsonText = JsonMapper.ToJson(_bugBaseData);

                        //Bug文件的路径（文件夹+文件名+后缀）
                        string _bugFilePath = _newProjectFolderPath + "/Bug/Bug - " + _bugBaseData.Id + ".json";

                        //把json文件保存到[Bug - BugId.json]文件里
                        File.WriteAllText(_bugFilePath, _bugJsonText, Encoding.Default);
                    }
                }
            }




            /* 保存Record */
            //如果是[默认]模式
            if (_modeType == ModeType.Default)
            {
                //把RecordBaseData转换为json
                string _recordsJsonText = JsonMapper.ToJson(_recordBaseDatas);

                //Record文件的路径（文件夹+文件名+后缀）
                string _recordsFilePath = _newProjectFolderPath + "/Record/Records.json";

                //把json文件保存到[Records.json]文件里
                File.WriteAllText(_recordsFilePath, _recordsJsonText, Encoding.Default);
            }

            //如果是[协同合作]模式
            else if (_modeType == ModeType.Collaboration)
            {
                for (int i = 0; i < _recordBaseDatas.Count; i++)
                {
                    if (_recordBaseDatas[i] != null)
                    {
                        //取到RecordBaseDatas
                        RecordBaseData _recordBaseData = _recordBaseDatas[i];

                        //把RecordBaseData转换为json
                        string _recordJsonText = JsonMapper.ToJson(_recordBaseData);

                        //Record文件的路径（文件夹+文件名+后缀）
                        string _recordFilePath = _newProjectFolderPath + "/Record/Record - " + _recordBaseData.Id + ".json";

                        //把json文件保存到[Record - RecordId.json]文件里
                        File.WriteAllText(_recordFilePath, _recordJsonText, Encoding.Default);
                    }
                }
            }




            /* 保存图片 */
            //取到旧的项目的Image文件夹
            DirectoryInfo _imageDirectoryInfo = new DirectoryInfo(_oldProjectFolderPath+"/Image");

            if (_imageDirectoryInfo.Exists == true)
            {
                //遍历所有的Image
                FileInfo[] _imageFileInfos = _imageDirectoryInfo.GetFiles();

                //复制所有的Image
                for (int i = 0; i < _imageFileInfos.Length; i++)
                {
                    //取到Image
                    FileInfo _imageFileInfo = _imageFileInfos[i];

                    //取到二进制数据
                    byte[] _oldImage = File.ReadAllBytes(_imageFileInfo.FullName);

                    //保存二进制数据到新文件中
                    File.WriteAllBytes(_newProjectFolderPath+"/Image/"+_imageFileInfo.Name,_oldImage);
                }
            }




            /* 保存Backup文件 */
            //取到旧的项目的Backup文件夹
            DirectoryInfo _backupDirectoryInfo = new DirectoryInfo(_oldProjectFolderPath + "/Backup");

            if (_backupDirectoryInfo.Exists == true)
            {
                /* Project文件夹 */
                //Backup/Project文件夹
                DirectoryInfo _projectBackupDirectoryInfo = new DirectoryInfo(_oldProjectFolderPath + "/Backup/Project");

                //如果文件夹存在
                if (_projectBackupDirectoryInfo.Exists == true)
                {
                    //遍历所有的Backup/Project
                    FileInfo[] _projectBackupFileInfos = _projectBackupDirectoryInfo.GetFiles();

                    //复制所有的Backup
                    for (int i = 0; i < _projectBackupFileInfos.Length; i++)
                    {
                        //取到Backup
                        FileInfo _projectBackupFileInfo = _projectBackupFileInfos[i];

                        //取到二进制数据
                        string _oldProjectBackup = File.ReadAllText(_projectBackupFileInfo.FullName);

                        //保存二进制数据到新文件中
                        File.WriteAllText(_newProjectFolderPath + "/Backup/Project/" + _projectBackupFileInfo.Name, _oldProjectBackup);
                    }
                }




                /* Bug文件夹 */
                //Backup/Bug文件夹
                DirectoryInfo _bugBackupDirectoryInfo = new DirectoryInfo(_oldProjectFolderPath + "/Backup/Bug");

                //如果文件夹存在
                if (_bugBackupDirectoryInfo.Exists == true)
                {
                    //遍历所有的Backup/Bug
                    FileInfo[] _bugBackupFileInfos = _bugBackupDirectoryInfo.GetFiles();

                    //复制所有的Backup
                    for (int i = 0; i < _bugBackupFileInfos.Length; i++)
                    {
                        //取到Backup
                        FileInfo _bugBackupFileInfo = _bugBackupFileInfos[i];

                        //取到二进制数据
                        string _oldBugBackup = File.ReadAllText(_bugBackupFileInfo.FullName);

                        //保存二进制数据到新文件中
                        File.WriteAllText(_newProjectFolderPath + "/Backup/Bug/" + _bugBackupFileInfo.Name, _oldBugBackup);
                    }
                }




                /* Record文件夹 */
                //Backup/Record文件夹
                DirectoryInfo _recordBackupDirectoryInfo = new DirectoryInfo(_oldProjectFolderPath + "/Backup/Record");

                //如果文件夹存在
                if (_recordBackupDirectoryInfo.Exists == true)
                {
                    //遍历所有的Backup/Record
                    FileInfo[] _recordBackupFileInfos = _recordBackupDirectoryInfo.GetFiles();

                    //复制所有的Backup
                    for (int i = 0; i < _recordBackupFileInfos.Length; i++)
                    {
                        //取到Backup
                        FileInfo _recordBackupFileInfo = _recordBackupFileInfos[i];

                        //取到二进制数据
                        string _oldRecordBackup = File.ReadAllText(_recordBackupFileInfo.FullName);

                        //保存二进制数据到新文件中
                        File.WriteAllText(_newProjectFolderPath + "/Backup/Record/" + _recordBackupFileInfo.Name, _oldRecordBackup);
                    }
                }
            }
        }
        #endregion
    }
}
