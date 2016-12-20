using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour {

	//##################################################
	//	UNITY FUNCTIONS
	//##################################################
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("t")) {
			EventManager.TriggerEvent ("test");
		}

		if (Input.GetKeyDown ("s")) {
			EventManager.TriggerEvent (EventManager.SPAWN);
		}

		if (Input.GetKeyDown ("d")) {
			EventManager.TriggerEvent (EventManager.DESTROY);
		}
	}

}