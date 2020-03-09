/* By: 絮大王（xudawang@vip.163.com）
   Time：2020年2月4日14:54:13*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LitJson;

namespace EasyBugManagerTool
{
    /// <summary>
    /// 修复的系统
    /// </summary>
    public class RepairSystem
    {
        /// <summary>
        /// 修复项目
        /// </summary>
        /// <param name="_projectFilePath">项目文件的路径</param>
        /// <param name="_saveFolderPath">保存文件夹的路径</param>
        /// <returns>转换后的文件夹</returns>
        public string Repair(string _projectFilePath, string _saveFolderPath)
        {
            
            try
            {
                /* 读取所有的Backup文件 */
                List<ProjectBaseData> _projectFileDatas;//项目文件的路径
                List<BugBaseData[]> _bugFileDatas;//读取到的项目数据
                List<RecordBaseData[]> _recordFileDatas;//读取到的Record数据
                LoadData(_projectFilePath, out _projectFileDatas, out _bugFileDatas, out _recordFileDatas);





                /* 修复数据 */
                //修复的数据
                ProjectBaseData _projectBaseData = null;//修复的Project
                List<BugBaseData> _bugBaseDatas = new List<BugBaseData>();//修复的Bug
                List<RecordBaseData> _recordBaseDatas = new List<RecordBaseData>();//修复的Record


                /* 修复Project数据 */
                //从最后一个开始
                for (int i = _projectFileDatas.Count - 1; i >= 0; i--)
                {
                    //进行验证
                    bool _isVerifyOk = VerifyProjectIntegrity(_projectFileDatas[i]);

                    //如果验证成功
                    if (_isVerifyOk == true)
                    {
                        _projectBaseData = _projectFileDatas[i];
                        break;
                    }
                }




                /* 修复Bug数据 */
                List<BugBaseData> _allBugBaseDatas = new List<BugBaseData>();

                //从最后一个开始
                for (int i = _bugFileDatas.Count - 1; i >= 0; i--)
                {
                    if (_bugFileDatas[i] != null)
                    {
                        //从后到前，保存所有的数据
                        for (int j = 0; j < _bugFileDatas[i].Length; j++)
                        {
                            _allBugBaseDatas.Add(_bugFileDatas[i][j]);
                        }
                    }
                }

                //遍历所有的数据
                Dictionary<long, BugBaseData> _repairBugBaseDatas = new Dictionary<long, BugBaseData>();//所有修复好的数据
                for (int i = 0; i < _allBugBaseDatas.Count; i++)
                {
                    if (_allBugBaseDatas[i] != null)
                    {
                        BugBaseData _bugBaseData = null;
                        bool _isHave = _repairBugBaseDatas.TryGetValue(_allBugBaseDatas[i].Id, out _bugBaseData);

                        //如果这个Bug还不存在
                        if (_isHave == false)
                        {
                            //验证Bug的完整性
                            if (VerifyBugIntegrity(_allBugBaseDatas[i]) == true)
                            {
                                //加入到字典中
                                _repairBugBaseDatas.Add(_allBugBaseDatas[i].Id, _allBugBaseDatas[i]);
                            }
                        }
                    }
                }

                //把修复的数据加到列表中
                foreach (BugBaseData _bugBaseData in _repairBugBaseDatas.Values)
                {
                    _bugBaseDatas.Add(_bugBaseData);
                }




                /* 修复Record数据 */
                List<RecordBaseData> _allRecordBaseDatas = new List<RecordBaseData>();

                //从最后一个开始
                for (int i = _recordFileDatas.Count - 1; i >= 0; i--)
                {
                    if (_recordFileDatas[i] != null)
                    {
                        //从后到前，保存所有的数据
                        for (int j = 0; j < _recordFileDatas[i].Length; j++)
                        {
                            _allRecordBaseDatas.Add(_recordFileDatas[i][j]);
                        }
                    }
                }

                //遍历所有的数据
                Dictionary<long, RecordBaseData> _repairRecordBaseDatas = new Dictionary<long, RecordBaseData>();//所有修复好的数据
                for (int i = 0; i < _allRecordBaseDatas.Count; i++)
                {
                    if (_allRecordBaseDatas[i] != null)
                    {
                        RecordBaseData _recordBaseData = null;
                        bool _isHave = _repairRecordBaseDatas.TryGetValue(_allRecordBaseDatas[i].Id, out _recordBaseData);

                        //如果这个Record还不存在
                        if (_isHave == false)
                        {
                            //验证Record的完整性
                            if (VerifyRecordIntegrity(_allRecordBaseDatas[i]) == true)
                            {
                                //加入到字典中
                                _repairRecordBaseDatas.Add(_allRecordBaseDatas[i].Id, _allRecordBaseDatas[i]);
                            }
                        }
                    }
                }

                //把修复的数据加到列表中
                foreach (RecordBaseData _recordBaseData in _repairRecordBaseDatas.Values)
                {
                    _recordBaseDatas.Add(_recordBaseData);
                }




                /* 创建文件夹 */
                string _newProjectFolderPath = AppManager.Systems.ConvertSystem.CreateFolders(_saveFolderPath, ToolType.Repair);
                string _oldProjectFolderPath = new FileInfo(_projectFilePath).DirectoryName;

                /* 保存数据 */
                //如果没有项目
                if (_projectBaseData == null)
                {
                    _projectBaseData = new ProjectBaseData();
                    _projectBaseData.ModeType = 1;
                    _projectBaseData.Id = DateTimeTool.DateTimeToLong(DateTime.UtcNow, TimeFormatType.YearMonthDayHourMinuteSecondMillisecond);
                    _projectBaseData.Name = " ";

                    //尝试给Project附上名字
                    FileInfo _oldProjectFileInfo = new FileInfo(_projectFilePath);
                    if (_oldProjectFileInfo.Exists == true)
                    {
                        _projectBaseData.Name = Path.GetFileNameWithoutExtension(_oldProjectFileInfo.FullName);
                    }
                }
                //保存数据
                AppManager.Systems.ConvertSystem.SaveData(_oldProjectFolderPath, _newProjectFolderPath, (ModeType)_projectBaseData.ModeType,
                    _projectBaseData, _bugBaseDatas, _recordBaseDatas);


                //返回值
                return _newProjectFolderPath;
            }
            catch (Exception e)
            {
                return "";
            }
        }




        #region [私有方法 - 数据]
        /// <summary>
        /// 读取数据（Project、Bug、Record）
        /// </summary>
        /// <param name="_projectFilePath">项目文件的路径</param>
        /// <param name="_projectFileDatas">读取到的项目数据</param>
        /// <param name="_bugFileDatas">读取到的Bug数据</param>
        /// <param name="_recordFileDatas">读取到的Record数据</param>
        private void LoadData(string _projectFilePath,
                              out List<ProjectBaseData> _projectFileDatas, out List<BugBaseData[]> _bugFileDatas, out List<RecordBaseData[]> _recordFileDatas)
        {
            /*获取Project的文件信息*/
            FileInfo _projectFileInfo = new FileInfo(_projectFilePath);






            /* 读取Project数据 */
            //所有的Project数据
            _projectFileDatas = new List<ProjectBaseData>();

            //读取Backup/Project文件
            DirectoryInfo _projectBackupDirectoryInfo = new DirectoryInfo(_projectFileInfo.DirectoryName + "/Backup/Project");

            //如果文件存在
            if (_projectBackupDirectoryInfo.Exists == true)
            {
                //取到所有的Project文件
                FileInfo[] _projectBackupFileInfos = _projectBackupDirectoryInfo.GetFiles();

                //排序
                if (_projectBackupFileInfos!=null)
                {
                    Array.Sort(_projectBackupFileInfos, (fileInfo1, fileInfo2) =>
                    {
                        /* 这个Lamba表达式的返回值为int类型，意思是fileInfo1和fileInfo2比较的大小。(大的排后面)
                   如果不能理解这段代码，可以搜索"C# List 多权重排序" */

                        int _index = 0;

                        //对[文件名]进行排序（从低到高）
                        _index += string.Compare(fileInfo1.Name, fileInfo1.Name);

                        return _index;
                    });
                }

                //解析Backup的Project数据
                for (int i = 0; i < _projectBackupFileInfos.Length; i++)
                {
                    try
                    {
                        //读取[Backup/项目名.bugs]的Json文本中的内容
                        string _projectJsonText = File.ReadAllText(_projectBackupFileInfos[i].FullName);

                        //然后把Json文本解析成ProjectBaseData对象
                        _projectFileDatas.Add(JsonMapper.ToObject<ProjectBaseData>(_projectJsonText));
                    }
                    catch (Exception e)
                    {
                    }
                }
            }

            //解析Project数据
            try
            {
                //读取[项目名.bugs]的Json文本中的内容
                string _projectJsonText = File.ReadAllText(_projectFilePath);

                //然后把Json文本解析成ProjectBaseData对象
                _projectFileDatas.Add(JsonMapper.ToObject<ProjectBaseData>(_projectJsonText));
            }
            catch (Exception e)
            {
            }







            /* 读取Bug数据 */
            _bugFileDatas = new List<BugBaseData[]>();

            //读取Backup/Bug文件
            DirectoryInfo _bugBackupDirectoryInfo = new DirectoryInfo(_projectFileInfo.DirectoryName + "/Backup/Bug");

            //如果文件存在
            if (_bugBackupDirectoryInfo.Exists == true)
            {
                //取到所有的Bug文件
                FileInfo[] _bugBackupFileInfos = _bugBackupDirectoryInfo.GetFiles();

                //排序
                if (_bugBackupFileInfos!=null)
                {
                    Array.Sort(_bugBackupFileInfos, (fileInfo1, fileInfo2) =>
                    {
                        /* 这个Lamba表达式的返回值为int类型，意思是fileInfo1和fileInfo2比较的大小。(大的排后面)
                   如果不能理解这段代码，可以搜索"C# List 多权重排序" */

                        int _index = 0;

                        //对[文件名]进行排序（从低到高）
                        _index += string.Compare(fileInfo1.Name, fileInfo1.Name);

                        return _index;
                    });
                }

                //解析Backup的Bug数据
                for (int i = 0; i < _bugBackupFileInfos.Length; i++)
                {
                    try
                    {
                        //读取[Backup/Bug/项目名.bugs]的Json文本中的内容
                        string _bugJsonText = File.ReadAllText(_bugBackupFileInfos[i].FullName);

                        //然后把Json文本解析成BugBaseData对象
                        _bugFileDatas.Add(JsonMapper.ToObject<BugBaseData[]>(_bugJsonText));
                    }
                    catch (Exception e)
                    {
                    }
                }
            }

            //如果是[默认]模式
            try
            {
                //读取[Bug]的Json文本中的内容
                string _bugsJsonText = File.ReadAllText(_projectFileInfo.DirectoryName + "/Bug/Bugs.json");

                //然后把Json文本解析成BugBaseData对象
                _bugFileDatas.Add(JsonMapper.ToObject<BugBaseData[]>(_bugsJsonText));
            }

            //如果是[协同合作]模式
            catch (Exception e)
            {
                try
                {
                    //取到Bug文件夹 的信息
                    DirectoryInfo _bugDirectoryInfo = new DirectoryInfo(_projectFileInfo.DirectoryName + "/Bug");

                    //如果文件存在
                    if (_bugDirectoryInfo.Exists == true)
                    {
                        //获取到Bug文件夹内所有的文件 的信息
                        FileInfo[] _bugFileInfos = _bugDirectoryInfo.GetFiles();

                        //
                        BugBaseData[] _bugBaseDatas = new BugBaseData[_bugFileInfos.Length];

                        //遍历所有的Bug文件
                        for (int i = 0; i < _bugFileInfos.Length; i++)
                        {
                            try
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
                                    _bugBaseDatas[i] = _bugBaseData;
                                }
                            }
                            catch (Exception exception)
                            {
                            }
                        }


                        _bugFileDatas.Add(_bugBaseDatas);
                    }
                }
                catch (Exception exception)
                {
                }
            }







            /* 读取Record数据 */
            _recordFileDatas = new List<RecordBaseData[]>();

            //读取Backup/Record文件
            DirectoryInfo _recordBackupDirectoryInfo = new DirectoryInfo(_projectFileInfo.DirectoryName + "/Backup/Record");

            //如果文件存在
            if (_recordBackupDirectoryInfo.Exists == true)
            {
                //取到所有的Record文件
                FileInfo[] _recordBackupFileInfos = _recordBackupDirectoryInfo.GetFiles();

                //排序
                if (_recordBackupFileInfos!=null)
                {
                    Array.Sort(_recordBackupFileInfos, (fileInfo1, fileInfo2) =>
                    {
                        /* 这个Lamba表达式的返回值为int类型，意思是fileInfo1和fileInfo2比较的大小。(大的排后面)
                   如果不能理解这段代码，可以搜索"C# List 多权重排序" */

                        int _index = 0;

                        //对[文件名]进行排序（从低到高）
                        _index += string.Compare(fileInfo1.Name, fileInfo1.Name);

                        return _index;
                    });
                }

                //解析Backup的Record数据
                for (int i = 0; i < _recordBackupFileInfos.Length; i++)
                {
                    try
                    {
                        //读取[Backup/Record/Record.json]的Json文本中的内容
                        string _recordJsonText = File.ReadAllText(_recordBackupFileInfos[i].FullName);

                        //然后把Json文本解析成RecordBaseData对象
                        _recordFileDatas.Add(JsonMapper.ToObject<RecordBaseData[]>(_recordJsonText));
                    }
                    catch (Exception e)
                    {
                    }
                }
            }

            //如果是[默认]模式
            try
            {
                //读取[Record]的Json文本中的内容
                string _recordsJsonText = File.ReadAllText(_projectFileInfo.DirectoryName + "/Record/Records.json");

                //然后把Json文本解析成RecordBaseData对象
                _recordFileDatas.Add(JsonMapper.ToObject<RecordBaseData[]>(_recordsJsonText));
            }

            //如果是[协同合作]模式
            catch (Exception e)
            {
                try
                {
                    //取到Record文件夹 的信息
                    DirectoryInfo _recordDirectoryInfo = new DirectoryInfo(_projectFileInfo.DirectoryName + "/Record");

                    //如果文件存在
                    if (_recordDirectoryInfo.Exists == true)
                    {
                        //获取到Record文件夹内所有的文件 的信息
                        FileInfo[] _recordFileInfos = _recordDirectoryInfo.GetFiles();

                        //
                        RecordBaseData[] _recordBaseDatas = new RecordBaseData[_recordFileInfos.Length];

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
                                try
                                {
                                    //就读取这个Record
                                    string _recordJsonText = File.ReadAllText(_recordFileInfos[i].FullName);

                                    //然后把Json文本解析成RecordBaseData对象
                                    RecordBaseData _recordBaseData = JsonMapper.ToObject<RecordBaseData>(_recordJsonText);

                                    //把RecordBaseData对象，加入到列表中
                                    _recordBaseDatas[i] = _recordBaseData;
                                }
                                catch (Exception exception)
                                {
                                }
                            }
                        }


                        _recordFileDatas.Add(_recordBaseDatas);
                    }
                }
                catch (Exception exception)
                {
                }
            }

        }
        #endregion

        #region [私有方法 - 验证]

        /// <summary>
        /// 验证Project的完整性
        /// （验证1个Project的完整性。
        /// 如果Project是完整的，代表这个Project是有效的；
        /// 如果Project是不完整的，代表Project文件还没有同步完，或者是Project文件已损坏）
        /// </summary>
        /// <param name="_projectBaseData">要验证的Project</param>
        /// <returns>Project是否是完整的</returns>
        public bool VerifyProjectIntegrity(ProjectBaseData _projectBaseData)
        {
            if (_projectBaseData == null ||
                _projectBaseData.Id < 0 ||
                _projectBaseData.Name == null||
                _projectBaseData.Name == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 验证Bug的完整性
        /// （验证1个Bug的完整性。
        /// 如果Bug是完整的，代表这个Bug是有效的；
        /// 如果Bug是不完整的，代表Bug文件还没有同步完，或者是Bug文件已损坏）
        /// </summary>
        /// <param name="_bugBaseData">要验证的Bug</param>
        /// <returns>Bug是否是完整的</returns>
        public bool VerifyBugIntegrity(BugBaseData _bugBaseData)
        {
            if (_bugBaseData == null || 
                _bugBaseData.Id < 0 ||
                _bugBaseData.Priority == 0 ||
                _bugBaseData.Progress == 0 ||
                _bugBaseData.TemperamentId < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        /// <summary>
        /// 验证完整性
        /// （验证1个Record的完整性。
        /// 如果Record是完整的，代表这个Record是有效的；
        /// 如果Record是不完整的，代表Record文件还没有同步完，或者是Record文件已损坏）
        /// </summary>
        /// <param name="_recordBaseData">要验证的Record</param>
        /// <returns>Record是否是完整的</returns>
        public bool VerifyRecordIntegrity(RecordBaseData _recordBaseData)
        {
            if (_recordBaseData ==null||
                _recordBaseData.Id < 0 || _recordBaseData.BugId < 0 || _recordBaseData.ReplyId < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

    }
}
