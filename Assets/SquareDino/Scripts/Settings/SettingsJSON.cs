using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SquareDino.Scripts.Settings
{
    public class SettingsJson : MonoBehaviour
    {
        private static string _path = Path.Combine(Application.dataPath + "SquareDino.json");

        public static T Load<T>()
        {
            return File.Exists(_path) ? JsonUtility.FromJson<T>(File.ReadAllText(_path)) : default;
        }

        public static void Save(object obj)
        {
            Debug.Log("SquareDino.json updated");
            File.WriteAllText(_path, JsonUtility.ToJson(obj));
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }
    }
}