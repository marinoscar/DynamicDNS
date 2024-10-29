using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.DynamicDNS
{
    public static class LocalStorage
    {

        private const string _fileName = "data.txt";
        public static void Persist(IPInformation ip)
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                // Create or overwrite the file in isolated storage
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(_fileName, FileMode.Create, storage))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(ip.ToString());
                    }
                }
            }
        }

        public static IPInformation GetValue()
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (!storage.FileExists(_fileName))
                {
                    return new IPInformation(); // File does not exist
                }

                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(_fileName, FileMode.Open, storage))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return IPInformation.Create(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}
