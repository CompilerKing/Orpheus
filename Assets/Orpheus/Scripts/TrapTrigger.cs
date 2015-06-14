using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {

	public GameObject toBeRemoved = null;

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" && toBeRemoved != null) {
			Destroy(toBeRemoved);
			toBeRemoved = null;
		}
	}
}
