using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public static class JSONReader
{
    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        Debug.Log("File Not Found");
        return "";
    }

    private static string GetPath(string filename)
    {
        return Application.dataPath + "/JsonFile/" + filename;
    }

    public static List<T> ReadListFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            Debug.Log("File Is Empty");
            return new List<T>();
        }

        List<T> res = JsonHelper.FromJson<T>(content).ToList();

        return res;

    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.entries;
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] entries;
        }
    }
}
