using UnityEngine;
using System.Collections;

public class Enemy_Skeleton : MonoBehaviour {

	Transform target; //the enemy's target
	int moveSpeed = 3; //move speed
	int rotationSpeed = 3; //speed of turning
	float range = 10f;
	float range2 = 10f;
	float stop = 1;
	Transform myTransform; //current transform data of this enemy
	
	void Start()
	{
		target = GameObject.FindWithTag("Player").transform; //target the player
		myTransform = transform;
		
	}
	
	void Update () {
		//rotate to look at the player
		var distance = Vector3.Distance(myTransform.position, target.position);

		if (distance<=range2 &&  distance>=range){
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			                                        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
		}
		else if(distance<=range && distance>stop){
			//move towards the player
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			                                        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
		else if (distance<=stop) {
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			                                        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
		}
		
		
	}
}
