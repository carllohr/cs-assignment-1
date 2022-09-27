using Assignment01.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01.Services
{
    internal interface IFileMethods
    {
        public void Save(List<Contact> list);
        public void Read(ref List<Contact> list);
    }
    internal class FileMethods : IFileMethods
    {
        private string _filePath;
        public FileMethods(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(List<Contact> list)
        {
            try
            {
                using var sw = new StreamWriter(_filePath);
                sw.WriteLine(JsonConvert.SerializeObject(list, Formatting.Indented));
            }
            catch
            {

            }
        }

        public void Read (ref List<Contact> list)
        {
            
            try
            {
                using var sr = new StreamReader(_filePath);
                list = JsonConvert.DeserializeObject<List<Contact>>(sr.ReadToEnd());
            }
            catch
            {

            }
            
        }
    }
}
