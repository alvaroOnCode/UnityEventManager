using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

	//##################################################
	//	PRIVATE REFERENCES
	//##################################################
	private Dictionary <string, UnityEvent> eventDictionary;


	//##################################################
	//	STATIC REFERENCES
	//##################################################
	private static EventManager _instance;


	//##################################################
	//	STATIC EVENTS NAME
	//##################################################
	public static string DESTROY = "Destroy";
	public static string SPAWN = "Spawn";
	public static string JUNK = "Junk";


	//##################################################
	//	GETTERS AND SETTERS
	//##################################################
	public static EventManager Instance {
		get {
			if (!_instance) {
				_instance = FindObjectOfType (typeof (EventManager)) as EventManager;

				if (!_instance) {
					Debug.LogError ("There needs to be one active EventManager script on a GameObject in your scene.");
				} else {
					_instance.Init ();
				}
			}

			return _instance;
		}
	}


	//##################################################
	//	ALVARO FUNCTIONS
	//##################################################
	private void Init () {
		if (eventDictionary == null) {
			eventDictionary = new Dictionary<string, UnityEvent> ();
		}
	}

	public static void StartListening (string i_eventName, UnityAction i_listener) {
		UnityEvent thisEvent = null;

		if (Instance.eventDictionary.TryGetValue (i_eventName, out thisEvent)) {
			thisEvent.AddListener (i_listener);
		} else {
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (i_listener);
			Instance.eventDictionary.Add (i_eventName, thisEvent);
		}
	}

	public static void StopListening (string i_eventName, UnityAction i_listener) {
		if (Instance == null)
			return;

		UnityEvent thisEvent = null;

		if (Instance.eventDictionary.TryGetValue (i_eventName, out thisEvent)) {
			thisEvent.RemoveListener (i_listener);
		}
	}

	public static void TriggerEvent (string i_eventName) {
		UnityEvent thisEvent = null;

		if (Instance.eventDictionary.TryGetValue (i_eventName, out thisEvent)) {
			thisEvent.Invoke ();
		}
	}

}