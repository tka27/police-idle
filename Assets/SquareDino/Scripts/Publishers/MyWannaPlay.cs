using System.Collections.Generic;
using SquareDino.Scripts.MyAnalytics;
using UnityEngine;
#if FLAG_WANNAPLAY
#endif

namespace SquareDino.Scripts.Publishers
{
	public class MyWannaPlay : MonoBehaviour
	{
		
		public static void SendEvent(string eventName)
		{
#if FLAG_YANDEX_METRICA
			AppMetrica.Instance.ReportEvent(eventName);
			AppMetrica.Instance.SendEventsBuffer();
#endif
			MyAmplitude.SendEvent(eventName);
			MyMagnus.SendEvent(eventName);
		}

		public static void SendEvent(string eventName, Dictionary<string, object> eventProps)
		{
#if FLAG_YANDEX_METRICA
			AppMetrica.Instance.ReportEvent(eventName, eventProps);
			AppMetrica.Instance.SendEventsBuffer();
#endif
			MyAmplitude.SendEvent(eventName, eventProps);
			MyMagnus.SendEvent(eventName, eventProps);
		}

		#region Tutorial

		/// <summary>
		/// Запуск туториала
		/// </summary>
		public static void TutorialStarted()
		{
			SendEvent("tutorial_started");
		}

		/// <summary>
		/// Запущен N блок туториала
		/// </summary>
		/// <param name="number">Номер блока (1,2,3...)</param>
		public static void TutorialNStarted(int number)
		{
			/*var eventProps = new Dictionary<string, object>();
			eventProps.Add("number", number);
	
			SendEvent($"tutorial_{number}_started", eventProps);*/
			SendEvent($"tutorial_{number}_started");
		}

		/// <summary>
		/// Закончен N блок туториала
		/// </summary>
		/// <param name="number">Номер блока (1,2,3...)</param>
		public static void TutorialNCompleted(int number)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("number", number);

			SendEvent($"tutorial_{number}_completed", eventProps);
		}

		/// <summary>
		/// Туториал закончен
		/// </summary>
		public static void TutorialCompleted()
		{
			SendEvent("tutorial_completed");
		}

		#endregion

		#region Level

		/// <summary>
		/// Начало уровня
		/// </summary>
		/// <param name="level_id">Номер уровня (1,2,3... N)</param>
		public static void LevelStarted(int level_id)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("level_id", level_id);

			SendEvent("level_started", eventProps);
		}

		public static void LevelStarted(int level_id, string item)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("level_id", level_id);
			eventProps.Add("item_name", item);

			SendEvent("level_started", eventProps);
		}

		/// <summary>
		/// Уровень пройден
		/// </summary>
		/// <param name="level_id">Номер уровня (1,2,3... N)</param>
		public static void LevelCompleted(int level_id)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("level_id", level_id);

			SendEvent("level_completed", eventProps);
		}

		/// <summary>
		/// Уровень проигран
		/// </summary>
		/// <param name="level_id">Номер уровня (1,2,3... N)</param>
		public static void LevelFailed(int level_id)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("level_id", level_id);

			SendEvent("level_failed", eventProps);
		}

		/// <summary>
		/// Игрок нажал на кнопку рестарта уровня
		/// </summary>
		/// <param name="level_id">Номер уровня (1,2,3... N)</param>
		public static void LevelRestart(int level_id)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("level_id", level_id);

			SendEvent("level_restart", eventProps);
		}

		/// <summary>
		/// Запущена N часть уровня
		/// </summary>
		/// <param name="number">Номер блока (1,2,3...)</param>
		public static void LevelPartNStarted(int level_id, int number)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("level_id", level_id);
			eventProps.Add("number", number);

			SendEvent($"level_part_{number}_started", eventProps);
		}

		/// <summary>
		/// Закончена N часть уровня
		/// </summary>
		/// <param name="number">Номер блока (1,2,3...)</param>
		public static void LevelPartNFinished(int level_id, int number)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("level_id", level_id);
			eventProps.Add("number", number);

			SendEvent($"level_part_{number}_finished", eventProps);
		}

		/// <summary>
		/// Игрок использовал бустер
		/// </summary>
		/// <param name="level_id">Номер уровня (1,2,3... N)</param>
		public static void UsedBooster(int level_id)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("level_id", level_id);

			SendEvent("used_booster", eventProps);
		}

		#endregion

		#region Ads

		/// <summary>
		/// Интерстишиал запущен
		/// </summary>
		/// <param name="placement">Место, где был запущен интер</param>
		public static void InterstitialStarted(string placement)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("placement", placement);

			SendEvent("interstitial_started", eventProps);
		}

		/// <summary>
		/// Интерстишиал завершился успешно
		/// </summary>
		/// <param name="placement">Место, где был запущен интер</param>
		public static void InterstitialComplete(string placement)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("placement", placement);

			SendEvent("interstitial_complete", eventProps);
		}

		/// <summary>
		/// Ревард запущен
		/// </summary>
		/// <param name="placement">Место, где был запущен реворд</param>
		public static void RewardedStarted(string placement)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("placement", placement);

			SendEvent("rewarded_started", eventProps);
		}

		/// <summary>
		/// Ревард завершился успешно
		/// </summary>
		/// <param name="placement">Место, где был запущен реворд</param>
		public static void RewardedComplete(string placement)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("placement", placement);

			SendEvent("rewarded_complete", eventProps);
		}

		/// <summary>
		/// Баннер запущен
		/// </summary>
		public static void BannerStarted()
		{
			SendEvent("banner_started");
		}

		/// <summary>
		/// Баннер завершился успешно
		/// </summary>
		public static void BannerCompleted()
		{
			SendEvent("banner_completed");
		}

		#endregion

		#region Purchase

		/// <summary>
		/// Покупка инаппа/подписки
		/// </summary>
		public static void PurchaseSuccess()
		{
			SendEvent("purchase_success");
		}

		/// <summary>
		/// Покупка инаппа
		/// </summary>
		public static void PurchaseInappSuccess()
		{
			SendEvent("purchase_inapp_success");
		}

		/// <summary>
		/// Покупка подписки
		/// </summary>
		public static void PurchaseSubscriptionSuccess()
		{
			SendEvent("purchase_subscription_success");
		}

		/// <summary>
		/// Показ экрана подписки
		/// </summary>
		public static void SubscriptionShow()
		{
			SendEvent("subscription_show");
		}

		#endregion

		#region Shop

		/// <summary>
		/// Открытие магазина
		/// </summary>
		public static void ShopEntered()
		{
			SendEvent("shop_entered");
		}

		/// <summary>
		/// Смена раздела магазина
		/// </summary>
		public static void ItemSectionEntered(string sectionName)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("section", sectionName);

			SendEvent("item_section_entered", eventProps);
		}

		/// <summary>
		/// Взятие скина из магазина
		/// </summary>
		public static void SkinTaken(string name, bool rewarded, string skin_type)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("skin_type", skin_type);
			eventProps.Add("skin_name", name);
			eventProps.Add("skin_cost", rewarded ? "rewarded" : "currency");

			SendEvent("skin_taken", eventProps);
		}

		/// <summary>
		/// Взятие айтема из магазина
		/// </summary>
		public static void ItemTaken(string name, bool rewarded)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("item_name", name);
			eventProps.Add("item_cost", rewarded ? "rewarded" : "currency");

			SendEvent("item_taken", eventProps);
		}

		#endregion

		#region LevelStages

		public static void LevelStageComplete(string stage, int level_id, string item)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("level_id", level_id);
			eventProps.Add("item_name", item);

			SendEvent("level_" + stage, eventProps);
		}

		#endregion

		public static void BoxItemSelected(string item_name, string item_type)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("item_name", item_name);
			eventProps.Add("item_type", item_type);

			SendEvent("box_item_selected", eventProps);
		}

		public static void ItemLost(string item_name)
		{
			var eventProps = new Dictionary<string, object>();
			eventProps.Add("item_name", item_name);

			SendEvent("item_lost", eventProps);
		}
	}
}