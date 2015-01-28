using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;

namespace OldGamingQuiz.Helper
{
    class IOHelper
    {
        public string Read(string fileName)
        {
            string r = "";
            try
            {
                IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
                if (isolatedStorage.FileExists(fileName))
                {
                    IsolatedStorageFileStream fileStream = isolatedStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read);
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        r = reader.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return r;
        }

        public void Write(string fileName, string content)
        {
            try
            {
                IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
                StreamWriter writeFile;
                if (!isolatedStorage.FileExists(fileName))
                {
                    writeFile = new StreamWriter(new IsolatedStorageFileStream(fileName, FileMode.OpenOrCreate, isolatedStorage));
                    writeFile.WriteLine(content);
                    writeFile.Close();
                }
                else
                {
                    writeFile = new StreamWriter(new IsolatedStorageFileStream(fileName, FileMode.Open, isolatedStorage));
                    writeFile.WriteLine(content);
                    writeFile.Close();
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}
