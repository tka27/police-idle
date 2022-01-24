using System.Collections.Generic;
using UnityEngine;

namespace SquareDino.Scripts.MyAnalytics
{
    public class MyAmplitude : MonoBehaviour {
    
        [SerializeField] private string key = "key";
#if FLAG_AMPLITUDE
        private static Amplitude _amplitude;

        private void Awake()
        {
            _amplitude = Amplitude.getInstance();
            _amplitude.setServerUrl("https://api2.amplitude.com");
            _amplitude.logging = true;
            _amplitude.trackSessionEvents(true);
            _amplitude.init(key);
        }
#endif
	    public static void SendEvent(string eventName)
	    {
#if FLAG_AMPLITUDE
		    _amplitude?.logEvent(eventName);
#endif
	    }

	    public static void SendEvent(string eventName, Dictionary<string, object> eventProps)
	    {
#if FLAG_AMPLITUDE
		    _amplitude?.logEvent(eventName, eventProps);
#endif
	    }
    }
}