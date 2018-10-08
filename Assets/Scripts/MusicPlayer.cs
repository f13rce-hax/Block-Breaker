using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	void Awake ()
	{
		Debug.Log ("music player awake " + GetInstanceID ());
	}

	// Use this for initialization
	void Start ()
	{

		Debug.Log ("music player start " + GetInstanceID ());

		if (instance != null) {
			Destroy (gameObject);
			Debug.Log ("Duplicate music player " + GetInstanceID() + " self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
 	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
