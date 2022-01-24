#if UNITY_CLOUD_BUILD
using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class CloudBuildHelper
{
    public static void PreExport(UnityEngine.CloudBuild.BuildManifestObject manifest)
    {
        string buildNumber = manifest.GetValue<String>("buildNumber");
        Debug.LogWarning("Prebuild launched build number to " + buildNumber);
        PlayerSettings.bundleVersion = $"{PlayerSettings.bundleVersion}"; // For example 1.0 + buildNumber = 1.0.1
        PlayerSettings.Android.bundleVersionCode = int.Parse(buildNumber); // test
        PlayerSettings.SplashScreen.show = false;
    }
}
#endif

// namespace UnityEngine.CloudBuild
// {
//     public class BuildManifestObject : ScriptableObject
//     {
//         // Try to get a manifest value - returns true if key was found and could be cast to type T, otherwise returns false.
//         public bool TryGetValue<T>(string key, out T result);
//         // Retrieve a manifest value or throw an exception if the given key isn't found.
//         public T GetValue<T>(string key);
//         // Set the value for a given key.
//         public void SetValue(string key, object value);
//         // Copy values from a dictionary. ToString() will be called on dictionary values before being stored.
//         public void SetValues(Dictionary<string, object> sourceDict);
//         // Remove all key/value pairs.
//         public void ClearValues();
//         // Return a dictionary that represents the current BuildManifestObject.
//         public Dictionary<string, object> ToDictionary();
//         // Return a JSON formatted string that represents the current BuildManifestObject
//         public string ToJson();
//         // Return an INI formatted string that represents the current BuildManifestObject
//         public override string ToString();
//     }
// }