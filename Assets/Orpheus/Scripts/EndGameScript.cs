using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class EndGameScript : MonoBehaviour
{
	//--------------------------------
	// 1 - Designer variables
	//--------------------------------
	
	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform eurydicePrefab;
	

	
	void Start()
	{
		EndIt ();
	}
	
	void Update()
	{
	
	}
	
	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------
	
	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void EndIt()
	{
			
			// Create a new shot
			var shotTransform = Instantiate(eurydicePrefab) as Transform;
			
			// Assign position
		shotTransform.position = transform.position;

	}
	

}