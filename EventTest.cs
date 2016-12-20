using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour {

	//##################################################
	//	UNITY FUNCTIONS
	//##################################################
	void OnEnable ()
	{
		EventManager.StartListening ("test", SomeFunction);
		EventManager.StartListening (EventManager.SPAWN, SomeOtherFunction);
		EventManager.StartListening (EventManager.DESTROY, SomeThirdFunction);
	}

	void OnDisable ()
	{
		EventManager.StopListening ("test", SomeFunction);
		EventManager.StopListening (EventManager.SPAWN, SomeOtherFunction);
		EventManager.StopListening (EventManager.DESTROY, SomeThirdFunction);
	}


	//##################################################
	//	ALVARO FUNCTIONS
	//##################################################
	void SomeFunction ()
	{
		Debug.Log ("SomeFunction was called!");
	}

	void SomeOtherFunction ()
	{
		Debug.Log ("SomeOtherFunction was called!");
	}

	void SomeThirdFunction ()
	{
		Debug.Log ("SomeThirdFunction was called!");
	}

}