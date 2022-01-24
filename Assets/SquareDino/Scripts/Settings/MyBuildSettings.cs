using System;
using UnityEngine;

namespace SquareDino.Scripts.Settings
{
    [Serializable]
    public class OptionalPlatformSDK
    {
        public bool Faceboook;
        public bool GameAnalytics;
        public bool AppsFlyer;
        public bool Flurry;
        public bool Tenjin;
        public bool IronSource;
        public bool YandexMetrica;
        public bool AppLovin;
        public bool SuperSonic;
        public bool Appodeal;
        public bool Voodoo;
        public bool Homa;
        public bool Firebase;
        public bool Ysocorp;
        public bool Hoopsly;
        public bool Amplitude;
        public bool WannaPlay;
        public bool MagnusPlay;
    }

    [Serializable]
    public class SettingsData
    {
        public bool RemoteConfig;
        public bool DevPanel;
        public bool Policies;
        public bool RateUs;

        public bool UseSDKForIOS;
        public bool UseSDKForAndroid;

        public OptionalPlatformSDK IOS;
        public OptionalPlatformSDK Android;
    }

    [ExecuteInEditMode]
    public class MyBuildSettings : MonoBehaviour
    {
        private const string FLAG_REMOTECONFIG = "FLAG_REMOTE_CONFIG";
        private const string FLAG_DEVPANEL = "FLAG_DEV_PANEL";
        private const string FLAG_POLICIES = "FLAG_POLICIES";
        private const string FLAG_RATE_US = "FLAG_RATE_US";
        private const string FLAG_FACEBOOK = "FLAG_FA";
        private const string FLAG_GAME_ANALYTICS = "FLAG_GA";
        private const string FLAG_APPS_FLYER = "FLAG_AF";
        private const string FLAG_FLURRY = "FLAG_FlURRY";
        private const string FLAG_TENJIN = "FLAG_TENJIN";
        private const string FLAG_IRONSOURCE = "FLAG_IRONSOURCE";
        private const string FLAG_YANDEX_METRICA = "FLAG_YANDEX_METRICA";
        private const string FLAG_APPLOVIN = "FLAG_APPLOVIN";
        private const string FLAG_SUPERSONIC = "FLAG_SUPERSONIC";
        private const string FLAG_APPODEAL = "FLAG_APPODEAL";
        private const string FLAG_VOODOO = "FLAG_VOODOO";
        private const string FLAG_HOMA = "FLAG_HOMA";
        private const string FLAG_FIREBASE = "FLAG_FIREBASE";
        private const string FLAG_YSOCORP = "FLAG_YSOCORP";
        private const string FLAG_HOOPSLY = "FLAG_HOOPSLY";
        private const string FLAG_AMPLITUDE = "FLAG_AMPLITUDE";
        private const string FLAG_WANNAPLAY = "FLAG_WANNAPLAY";
        private const string FLAG_MAGNUS = "FLAG_MAGNUS";

        public static bool RemoteConfig { get; private set; }
        public static bool DevPanel { get; private set; }
        public static bool Policies { get; private set; }
        public static bool RateUs { get; private set; }

        public SettingsData Data { get; private set; }
        
        private void Awake()
        {
            Load();
            
            RemoteConfig = Data.RemoteConfig;
            DevPanel = Data.DevPanel;
            Policies = Data.Policies;
            RateUs = Data.RateUs;
            Debug.Log("Редактор запущен");
        }

        public string GenerateDefine_iOS(string value)
        {
            value = ClearOldDefines(value);
            if (value.LastIndexOf(';') != value.Length-1) value += ";";
            
            var newDefines = GenerateDefines_iOS();
            return value + newDefines;
        }
        
        public string GenerateDefine_Android(string value)
        {
            value = ClearOldDefines(value);
            if (value.LastIndexOf(';') != value.Length-1) value += ";";
            
            var newDefines = GenerateDefines_Android();
            return value + newDefines;
        }
        
        public string GenerateDefine_Standalone(string value)
        {
            value = ClearOldDefines(value);
            if (value.LastIndexOf(';') != value.Length-1) value += ";";
            
            var newDefines = GenerateDefines_Standalone();
            return value + newDefines;
        }

        private string ClearOldDefines(string value)
        {
            value = RemoveKey(value, FLAG_REMOTECONFIG);
            value = RemoveKey(value, FLAG_DEVPANEL);
            value = RemoveKey(value, FLAG_POLICIES);
            value = RemoveKey(value, FLAG_RATE_US);
            value = RemoveKey(value, FLAG_FACEBOOK);
            value = RemoveKey(value, FLAG_GAME_ANALYTICS);
            value = RemoveKey(value, FLAG_APPS_FLYER);
            value = RemoveKey(value, FLAG_FLURRY);
            value = RemoveKey(value, FLAG_TENJIN);
            value = RemoveKey(value, FLAG_IRONSOURCE);
            value = RemoveKey(value, FLAG_YANDEX_METRICA);
            value = RemoveKey(value, FLAG_APPLOVIN);
            value = RemoveKey(value, FLAG_SUPERSONIC);
            value = RemoveKey(value, FLAG_APPODEAL);
            value = RemoveKey(value, FLAG_VOODOO);
            value = RemoveKey(value, FLAG_HOMA);
            value = RemoveKey(value, FLAG_FIREBASE);
            value = RemoveKey(value, FLAG_YSOCORP);
            value = RemoveKey(value, FLAG_HOOPSLY);
            value = RemoveKey(value, FLAG_AMPLITUDE);
            value = RemoveKey(value, FLAG_WANNAPLAY);
            value = RemoveKey(value, FLAG_MAGNUS);
            return RemoveGarbage(value);
        }

        private string RemoveKey(string value, string key)
        {
            while (true)
            {
                var id = value.IndexOf(key, StringComparison.Ordinal);
                if (id <= -1) return value;

                value = value.Remove(id, key.Length);
            }
        }

        private string RemoveGarbage(string value)
        {
            var key = ";;";
            var id = value.IndexOf(key, StringComparison.Ordinal);
            if (id <= -1) return value;
            
            value = value.Remove(id, 1);
            return RemoveKey(value, key);
        }

        private string GenerateDefines_iOS()
        {
            var value = "";
            if (Data.IOS.Faceboook) value += FLAG_FACEBOOK + ";";
            if (Data.IOS.GameAnalytics) value += FLAG_GAME_ANALYTICS + ";";
            if (Data.IOS.AppsFlyer) value += FLAG_APPS_FLYER + ";";
            if (Data.IOS.Flurry) value += FLAG_FLURRY + ";";
            if (Data.IOS.Tenjin) value += FLAG_TENJIN + ";";
            if (Data.IOS.IronSource) value += FLAG_IRONSOURCE + ";";
            if (Data.IOS.YandexMetrica) value += FLAG_YANDEX_METRICA + ";";
            if (Data.IOS.AppLovin) value += FLAG_APPLOVIN + ";";
            if (Data.IOS.SuperSonic) value += FLAG_SUPERSONIC + ";";
            if (Data.IOS.Appodeal) value += FLAG_APPODEAL + ";";
            if (Data.IOS.Voodoo) value += FLAG_VOODOO + ";";
            if (Data.IOS.Homa) value += FLAG_HOMA + ";";
            if (Data.IOS.Firebase) value += FLAG_FIREBASE + ";";
            if (Data.IOS.Ysocorp) value += FLAG_YSOCORP + ";";
            if (Data.IOS.Hoopsly) value += FLAG_HOOPSLY + ";";
            if (Data.IOS.Amplitude) value += FLAG_AMPLITUDE + ";";
            if (Data.IOS.WannaPlay) value += FLAG_WANNAPLAY + ";";
            if (Data.IOS.MagnusPlay) value += FLAG_MAGNUS + ";";
                
            return value;
        }
        
        private string GenerateDefines_Android()
        {
            var value = "";
            if (Data.Android.Faceboook) value += FLAG_FACEBOOK + ";";
            if (Data.Android.GameAnalytics) value += FLAG_GAME_ANALYTICS + ";";
            if (Data.Android.AppsFlyer) value += FLAG_APPS_FLYER + ";";
            if (Data.Android.Flurry) value += FLAG_FLURRY + ";";
            if (Data.Android.Tenjin) value += FLAG_TENJIN + ";";
            if (Data.Android.IronSource) value += FLAG_IRONSOURCE + ";";
            if (Data.Android.YandexMetrica) value += FLAG_YANDEX_METRICA + ";";
            if (Data.Android.AppLovin) value += FLAG_APPLOVIN + ";";
            if (Data.Android.SuperSonic) value += FLAG_SUPERSONIC + ";";
            if (Data.Android.Appodeal) value += FLAG_APPODEAL + ";";
            if (Data.Android.Voodoo) value += FLAG_VOODOO + ";";
            if (Data.Android.Homa) value += FLAG_HOMA + ";";
            if (Data.Android.Firebase) value += FLAG_FIREBASE + ";";
            if (Data.Android.Ysocorp) value += FLAG_YSOCORP + ";";
            if (Data.Android.Hoopsly) value += FLAG_HOOPSLY + ";";
            if (Data.Android.Amplitude) value += FLAG_AMPLITUDE + ";";
            if (Data.Android.WannaPlay) value += FLAG_WANNAPLAY + ";";
            if (Data.Android.MagnusPlay) value += FLAG_MAGNUS + ";";
                
            return value;
        }
        
        private string GenerateDefines_Standalone()
        {
            var value = "";
            if (Data.RemoteConfig) value += FLAG_REMOTECONFIG + ";";
            if (Data.DevPanel) value += FLAG_DEVPANEL + ";";
            if (Data.Policies) value += FLAG_POLICIES + ";";
            if (Data.RateUs) value += FLAG_RATE_US + ";";
                
            return value;
        }
        
        private void Load()
        {
            Data = SettingsJson.Load<SettingsData>();

            // LoadPlayerPrefs();
        }

        public void Save()
        {
            SettingsJson.Save(Data);

            // SavePlayerPrefs();
        }

        #region PlayerPrefs
        /*private void SavePlayerPrefs()
        {
            PlayerPrefs.SetInt("BuildSettings: remoteConfig", remoteConfig ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: devPanel", devPanel ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: policies", policies ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: rateUs", rateUs ? 1 : 0);
            
            PlayerPrefs.SetInt("BuildSettings: iOs", iOs ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsFaceboook", iOsFaceboook ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsGameAnalytics", iOsGameAnalytics ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsAppsFlyer", iOsAppsFlyer ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsFlurry", iOsFlurry ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsTenjin", iOsTenjin ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsIronSource", iOsIronSource ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsYandexMetrica", iOsYandexMetrica ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsAppLovin", iOsAppLovin ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsSuperSonic", iOsSuperSonic ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsAppodeal", iOsAppodeal ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsVoodoo", iOsVoodoo ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsHoma", iOsHoma ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsFirebase", iOsFirebase ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsYsocorp", iOsYsocorp ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsHoopsly", iOsHoopsly ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsAmplitude", iOsAmplitude ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsWannaPlay", iOsWannaPlay ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: iOsMagnusPlay", iOsMagnusPlay ? 1 : 0);
            
            PlayerPrefs.SetInt("BuildSettings: android", android ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidFaceboook", androidFaceboook ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidGameAnalytics", androidGameAnalytics ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidAppsFlyer", androidAppsFlyer ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidFlurry", androidFlurry ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidTenjin", androidTenjin ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidIronSource", androidIronSource ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidYandexMetrica", androidYandexMetrica ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidAppLovin", androidAppLovin ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidSuperSonic", androidSuperSonic ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidAppodeal", androidAppodeal ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidVoodoo", androidVoodoo ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidHoma", androidHoma ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidFirebase", androidFirebase ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidYsocorp", androidYsocorp ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidHoopsly", androidHoopsly ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidAmplitude", androidAmplitude ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidWannaPlay", androidWannaPlay ? 1 : 0);
            PlayerPrefs.SetInt("BuildSettings: androidMagnusPlay", androidMagnusPlay ? 1 : 0);
        }

        private void LoadPlayerPrefs()
        {
            remoteConfig = PlayerPrefs.GetInt("BuildSettings: remoteConfig") == 1;
            devPanel = PlayerPrefs.GetInt("BuildSettings: devPanel") == 1;
            policies = PlayerPrefs.GetInt("BuildSettings: policies") == 1;
            rateUs = PlayerPrefs.GetInt("BuildSettings: rateUs") == 1;

            iOs = PlayerPrefs.GetInt("BuildSettings: iOs") == 1;
            iOsFaceboook = PlayerPrefs.GetInt("BuildSettings: iOsFaceboook") == 1;
            iOsGameAnalytics = PlayerPrefs.GetInt("BuildSettings: iOsGameAnalytics") == 1;
            iOsAppsFlyer = PlayerPrefs.GetInt("BuildSettings: iOsAppsFlyer") == 1;
            iOsFlurry = PlayerPrefs.GetInt("BuildSettings: iOsFlurry") == 1;
            iOsTenjin = PlayerPrefs.GetInt("BuildSettings: iOsTenjin") == 1;
            iOsIronSource = PlayerPrefs.GetInt("BuildSettings: iOsIronSource") == 1;
            iOsYandexMetrica = PlayerPrefs.GetInt("BuildSettings: iOsYandexMetrica") == 1;
            iOsAppLovin = PlayerPrefs.GetInt("BuildSettings: iOsAppLovin") == 1;
            iOsSuperSonic = PlayerPrefs.GetInt("BuildSettings: iOsSuperSonic") == 1;
            iOsAppodeal = PlayerPrefs.GetInt("BuildSettings: iOsAppodeal") == 1;
            iOsVoodoo = PlayerPrefs.GetInt("BuildSettings: iOsVoodoo") == 1;
            iOsHoma = PlayerPrefs.GetInt("BuildSettings: iOsHoma") == 1;
            iOsFirebase = PlayerPrefs.GetInt("BuildSettings: iOsFirebase") == 1;
            iOsYsocorp = PlayerPrefs.GetInt("BuildSettings: iOsYsocorp") == 1;
            iOsHoopsly = PlayerPrefs.GetInt("BuildSettings: iOsHoopsly") == 1;
            iOsAmplitude = PlayerPrefs.GetInt("BuildSettings: iOsAmplitude") == 1;
            iOsWannaPlay = PlayerPrefs.GetInt("BuildSettings: iOsWannaPlay") == 1;
            iOsMagnusPlay = PlayerPrefs.GetInt("BuildSettings: iOsMagnusPlay") == 1;
            
            android = PlayerPrefs.GetInt("BuildSettings: android") == 1;
            androidFaceboook = PlayerPrefs.GetInt("BuildSettings: androidFaceboook") == 1;
            androidGameAnalytics = PlayerPrefs.GetInt("BuildSettings: androidGameAnalytics") == 1;
            androidAppsFlyer = PlayerPrefs.GetInt("BuildSettings: androidAppsFlyer") == 1;
            androidFlurry = PlayerPrefs.GetInt("BuildSettings: androidFlurry") == 1;
            androidTenjin = PlayerPrefs.GetInt("BuildSettings: androidTenjin") == 1;
            androidIronSource = PlayerPrefs.GetInt("BuildSettings: androidIronSource") == 1;
            androidYandexMetrica = PlayerPrefs.GetInt("BuildSettings: androidYandexMetrica") == 1;
            androidAppLovin = PlayerPrefs.GetInt("BuildSettings: androidAppLovin") == 1;
            androidSuperSonic = PlayerPrefs.GetInt("BuildSettings: androidSuperSonic") == 1;
            androidAppodeal = PlayerPrefs.GetInt("BuildSettings: androidAppodeal") == 1;
            androidVoodoo = PlayerPrefs.GetInt("BuildSettings: androidVoodoo") == 1;
            androidHoma = PlayerPrefs.GetInt("BuildSettings: androidHoma") == 1;
            androidFirebase = PlayerPrefs.GetInt("BuildSettings: androidFirebase") == 1;
            androidYsocorp = PlayerPrefs.GetInt("BuildSettings: androidYsocorp") == 1;
            androidHoopsly = PlayerPrefs.GetInt("BuildSettings: androidHoopsly") == 1;
            androidAmplitude = PlayerPrefs.GetInt("BuildSettings: androidAmplitude") == 1;
            androidWannaPlay = PlayerPrefs.GetInt("BuildSettings: androidWannaPlay") == 1;
            androidMagnusPlay = PlayerPrefs.GetInt("BuildSettings: androidMagnusPlay") == 1;
        }*/
        #endregion
    }
}