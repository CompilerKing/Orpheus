using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	
	private static Music instance = null;

	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(this);
		} else if (instance != this) {
			Destroy(this);
		}
	}
}
