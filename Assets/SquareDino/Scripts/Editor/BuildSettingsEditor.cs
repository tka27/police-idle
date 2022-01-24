using System;
using SquareDino.Scripts.Settings;
using UnityEditor;
using UnityEngine;

namespace SquareDino.Scripts.Editor
{
    [CustomEditor(typeof(MyBuildSettings))]
    public class BuildSettingsEditor : UnityEditor.Editor
    {

        private void OnPreSceneGUI()
        {
            // UpdateState(target as MyBuildSettings);
        }

        public override void OnInspectorGUI()
        {
            UpdateState(target as MyBuildSettings);
        }

        private void UpdateState(MyBuildSettings settings)
        {
            if (settings == null) return;
            
            var changed = false;
            var data = settings.Data;
            var dataiOS = data.IOS;
            var dataAndroid = data.Android;

            changed |= Toggle("Remote Config", ref data.RemoteConfig);
            changed |= Toggle("Dev Panel", ref data.DevPanel);
            changed |= Toggle("Policies", ref data.Policies);
            changed |= Toggle("Rate Us", ref data.RateUs);

            if (changed)
            {
                RefreshDefine(BuildTargetGroup.Standalone, settings.GenerateDefine_Standalone);
            }
            GUILayout.Space(10);

            changed = false;
            data.UseSDKForIOS = EditorGUILayout.BeginToggleGroup("AppStore SDKs", data.UseSDKForIOS);
            if (data.UseSDKForIOS)
            {
                CheckToggleChange(SDKNames.Facebook, ref dataiOS.Faceboook, ref changed);
                CheckToggleChange(SDKNames.GameAnalytics, ref dataiOS.GameAnalytics, ref changed);
                CheckToggleChange(SDKNames.AppsFlyer, ref dataiOS.AppsFlyer, ref changed);
                CheckToggleChange(SDKNames.Flurry, ref dataiOS.Flurry, ref changed);
                CheckToggleChange(SDKNames.Tenjin, ref dataiOS.Tenjin, ref changed);
                CheckToggleChange(SDKNames.IronSource, ref dataiOS.IronSource, ref changed);
                CheckToggleChange(SDKNames.YandexMetrica, ref dataiOS.YandexMetrica, ref changed);
                CheckToggleChange(SDKNames.AppLovin, ref dataiOS.AppLovin, ref changed);
                CheckToggleChange(SDKNames.SuperSonic, ref dataiOS.SuperSonic, ref changed);
                CheckToggleChange(SDKNames.Appodeal, ref dataiOS.Appodeal, ref changed);
                CheckToggleChange(SDKNames.Voodoo, ref dataiOS.Voodoo, ref changed);
                CheckToggleChange(SDKNames.Homa, ref dataiOS.Homa, ref changed);
                CheckToggleChange(SDKNames.Firebase, ref dataiOS.Firebase, ref changed);
                CheckToggleChange(SDKNames.Ysocorp, ref dataiOS.Ysocorp, ref changed);
                CheckToggleChange(SDKNames.Hoopsly, ref dataiOS.Hoopsly, ref changed);
                CheckToggleChange(SDKNames.Amplitude, ref dataiOS.Amplitude, ref changed);
                CheckToggleChange(SDKNames.WannaPlay, ref dataiOS.WannaPlay, ref changed);
                CheckToggleChange(SDKNames.Magnus, ref dataiOS.MagnusPlay, ref changed);
            }
            EditorGUILayout.EndToggleGroup();
            if (changed)
                RefreshDefine(BuildTargetGroup.iOS, settings.GenerateDefine_iOS);
            
            changed = false;
            data.UseSDKForAndroid = EditorGUILayout.BeginToggleGroup("GooglePlay SDKs", data.UseSDKForAndroid);
            if (data.UseSDKForAndroid)
            {
                CheckToggleChange(SDKNames.Facebook, ref dataAndroid.Faceboook, ref changed);
                CheckToggleChange(SDKNames.GameAnalytics, ref dataAndroid.GameAnalytics, ref changed);
                CheckToggleChange(SDKNames.AppsFlyer, ref dataAndroid.AppsFlyer, ref changed);
                CheckToggleChange(SDKNames.Flurry, ref dataAndroid.Flurry, ref changed);
                CheckToggleChange(SDKNames.Tenjin, ref dataAndroid.Tenjin, ref changed);
                CheckToggleChange(SDKNames.IronSource, ref dataAndroid.IronSource, ref changed);
                CheckToggleChange(SDKNames.YandexMetrica, ref dataAndroid.YandexMetrica, ref changed);
                CheckToggleChange(SDKNames.AppLovin, ref dataAndroid.AppLovin, ref changed);
                CheckToggleChange(SDKNames.SuperSonic, ref dataAndroid.SuperSonic, ref changed);
                CheckToggleChange(SDKNames.Appodeal, ref dataAndroid.Appodeal, ref changed);
                CheckToggleChange(SDKNames.Voodoo, ref dataAndroid.Voodoo, ref changed);
                CheckToggleChange(SDKNames.Homa, ref dataAndroid.Homa, ref changed);
                CheckToggleChange(SDKNames.Firebase, ref dataAndroid.Firebase, ref changed);
                CheckToggleChange(SDKNames.Ysocorp, ref dataAndroid.Ysocorp, ref changed);
                CheckToggleChange(SDKNames.Hoopsly, ref dataAndroid.Hoopsly, ref changed);
                CheckToggleChange(SDKNames.Amplitude, ref dataAndroid.Amplitude, ref changed);
                CheckToggleChange(SDKNames.WannaPlay, ref dataAndroid.WannaPlay, ref changed);
                CheckToggleChange(SDKNames.Magnus, ref dataAndroid.MagnusPlay, ref changed);
            }
            EditorGUILayout.EndToggleGroup();

            if (changed)
                RefreshDefine(BuildTargetGroup.Android, settings.GenerateDefine_Android);

            if (!GUI.changed) return;
            EditorUtility.SetDirty(target);
            settings.Save();
        }

        private void RefreshDefine(BuildTargetGroup buildTargetGroup, Func<string, string> defineGenerator)
        {
            var oldDefine = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
            var define = defineGenerator(oldDefine);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, define);
        }
        
        private void CheckToggleChange(string stringName, ref bool settings, ref bool changer)
        {
            EditorGUILayout.BeginHorizontal("Box", GUILayout.Width(290));
            changer |= Toggle(stringName, ref settings);
            EditorGUILayout.EndHorizontal();
        }
        
        private bool Toggle(string text, ref bool value)
        {
            var originalValue = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 100;   
            
            var prevValue = value;
            value = EditorGUILayout.Toggle(text, value);
            
            EditorGUIUtility.labelWidth = originalValue;
            
            return prevValue != value;
        }
    }
}