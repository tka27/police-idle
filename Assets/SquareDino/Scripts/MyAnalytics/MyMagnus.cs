using System;
using System.Collections;
using System.Collections.Generic;
#if FLAG_AF 
using AppsFlyerSDK;
#endif
#if FLAG_MAGNUS
using MagnusSdk.Core;
using MagnusSdk.EvTruck;
using MagnusSdk.Mutator;
#endif
using UnityEngine;

namespace SquareDino.Scripts.MyAnalytics
{
    public struct MagnusEvent
    {
        public string Name;
        public Dictionary<string, object> Props;

        public MagnusEvent(string eventName, Dictionary<string, object> eventProps)
        {
            Name = eventName;
            Props = eventProps;
        }
    }

    public class MyMagnus : MonoBehaviour
    {
        [SerializeField] private string _androidKey = "key";
        [SerializeField] private string _iosKey = "key";

        private static bool _refreshibalBox;
        public static bool RefreshibalBox => _refreshibalBox;

        private static List<MagnusEvent> _savedEvents = new List<MagnusEvent>();
        private WaitForSeconds _waitTime = new WaitForSeconds(1);
    
#if FLAG_MAGNUS
        private async void Awake()
        {
#if FLAG_AF 
            Magnus.SetAppsFlyerIdGetter(AppsFlyer.getAppsFlyerId); // Oprional step: set AppsFlyer id getter
#endif
#if UNITY_IOS
        await Magnus.Initialize(_iosKey);
#elif UNITY_ANDROID
            await Magnus.Initialize(_androidKey);
#endif

            EvTruck.Initialize();
        
            try
            {
                Mutator.Initialize();
                await Mutator.FetchConfig();
                MutatorConfig сonfig = await Mutator.Activate();
                _refreshibalBox = сonfig.GetValue("is_box_refreshibal").BoolValue;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            StartCoroutine(WaitMagnusInitialization());
        }
#endif

        public static void SendEvent(string eventName)
        {
#if FLAG_MAGNUS
            if(Magnus.IsInitialized)
                EvTruck.TrackEvent(eventName);
            else
                _savedEvents.Add(new MagnusEvent(eventName, null));
#endif
        }
    
        public static void SendEvent(string eventName, Dictionary<string, object> eventProps)
        {
#if FLAG_MAGNUS
            if(Magnus.IsInitialized)
                EvTruck.TrackEvent(eventName, eventProps);
            else 
                _savedEvents.Add(new MagnusEvent(eventName, eventProps));
#endif
        }
    
#if FLAG_MAGNUS
        private IEnumerator WaitMagnusInitialization()
        {

            while (!Magnus.IsInitialized)
            {
                yield return _waitTime;
            }
            SendSavedEvents();
        }
    
        private void SendSavedEvents()
        {
            foreach (var savedEvent in _savedEvents)
            {
                EvTruck.TrackEvent(savedEvent.Name, savedEvent.Props);
            }
            _savedEvents.Clear();
        }
#endif
    }
}