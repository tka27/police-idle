using System.Collections.Generic;
using UnityEngine;

#if FLAG_FIREBASE
using Firebase;
using Firebase.Analytics;
#endif

namespace SquareDino.Scripts.MyAnalytics
{
	public class MyFirebase : MonoBehaviour
	{
#if FLAG_FIREBASE
		private FirebaseApp _app;
		
		private void Start()
		{
			FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
			  var dependencyStatus = task.Result;
			  if (dependencyStatus == Firebase.DependencyStatus.Available) {
			    // Create and hold a reference to your FirebaseApp,
			    // where app is a Firebase.FirebaseApp property of your application class.
			       _app = FirebaseApp.DefaultInstance;

			    // Set a flag here to indicate whether Firebase is ready to use by your app.

			    Firebase.Analytics.FirebaseAnalytics.SetUserId(SystemInfo.deviceUniqueIdentifier);

			  } else {
			    Debug.LogError(System.String.Format(
			      "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
			    // Firebase Unity SDK is not safe to use here.
			  }
			});

		}
#endif
		public static void LogEventAds(string type, string placement, string state)
		{
			#if FLAG_FIREBASE
				Firebase.Analytics.Parameter[] parameters = {
					new Firebase.Analytics.Parameter("Type", type),
					new Firebase.Analytics.Parameter("Placement", placement),
					new Firebase.Analytics.Parameter("State", state)
				};
				Firebase.Analytics.FirebaseAnalytics.LogEvent("Ads_Shown", parameters);
			#endif
		}

		public static void SendEvent(string eventName)
		{
			#if FLAG_FIREBASE
				Firebase.Analytics.FirebaseAnalytics.LogEvent(eventName);
			#endif
		}
		
		public static void SendEvent(string eventName, Dictionary<string,object> eventProps)
		{
			#if FLAG_FIREBASE
				Firebase.Analytics.Parameter[] parameters = new Parameter[eventProps.Count];
				int index = 0;
				foreach (var eventProp in eventProps)
				{
					parameters[index] = new Firebase.Analytics.Parameter(eventProp.Key, eventProp.Value.ToString());
					index++;
				}
				Firebase.Analytics.FirebaseAnalytics.LogEvent(eventName, parameters);
			#endif
		}
	}
}