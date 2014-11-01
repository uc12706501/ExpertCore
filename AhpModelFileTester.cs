using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExpertChooseCore
{
    class AhpModelFileTester
    {
        private string _inputFile = "D:\\SourceCode\\Projects\\ExpertCore\\input.txt";
        private string _outputFile = "D:\\SourceCode\\Projects\\ExpertCore\\output.txt";
        private int _cursor = 0;
        private IList<string> _contents; 

        public AhpModelFileTester(string inputFile, string outputFile)
        {
            _inputFile = inputFile;
            _outputFile = outputFile;
            Init();
        }

        public AhpModelFileTester()
        {
            Init();
        }

        //初始化，将input.txt的所有内容都读入contents中
        private void Init()
        {
            var contents = File.ReadLines(_inputFile);
            foreach (var content in contents)
            {
                _contents.Add(content);
            }
        }
        
        //读取游标所指向的当前行，读完之后游标指向下一行
        private string ReadNextLine()
        {
            return _contents[_cursor++];
        }

        //将输入的字符串按照空格分隔之后，转换成对应的T列表
        public IList<T> ConvertTo<T>(string content)
        {
            IEnumerable<string> values = content.Split(' ');
            IList<T> trueValues=new List<T>();
            foreach (var value in values)
            {
                trueValues.Add((T)Convert.ChangeType(value,typeof(T)));
            }
            return trueValues;
        }
    }
}
