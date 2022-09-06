using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FootballScoreBoard.Tests.Utilities
{
        public static class MockFilesHelper
        {
            public static T DeserializeFromMockFile<T>(string path)
            {
                T result = default(T);

                try
                {
                    if (File.Exists(path))
                    {
                        Stream fileStream = File.OpenRead(path);

                        using (Stream stream = fileStream)
                        {
                            using (StreamReader sr = new StreamReader(stream))
                            {
                                string text = sr.ReadToEnd();

                                result = JsonConvert.DeserializeObject<T>(text, new JsonSerializerSettings());
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    string error = e.ToString();
                }

                return result;
            }
        }
    }
