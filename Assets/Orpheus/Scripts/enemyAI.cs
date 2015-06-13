using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	
	private Transform myTransform;
	
	// Use this for initialization
	void Awake() {
		myTransform = transform;
	}
	
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		target = go.transform;
	}
	
	// Update is called once per frame
	void Update () {    
		Vector3 dir = target.position - myTransform.position;
		if (dir != Vector3.zero) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, 
			                                         Quaternion.FromToRotation(Vector3.right, dir), rotationSpeed * Time.deltaTime);
		}
		
		//Move Towards Target
		myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;
	}
}
