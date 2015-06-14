using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class HartSkelly : MonoBehaviour {

	public float moveForce = 50;

	private GameObject player;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 dir = new Vector2(player.transform.position.x - this.transform.position.x, 0).normalized;
		body.AddForce(dir * moveForce);

		if (body.velocity.x > 0) {
			transform.rotation = new Quaternion(0, 180, 0, 0);
		} else {
			transform.rotation = new Quaternion(0, 0, 0, 0);
		}
	}
}
