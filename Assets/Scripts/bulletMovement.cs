using UnityEngine;
using System.Collections;

public class bulletMovement : MonoBehaviour
{
	public float speed;

	void Start()
	{
		//this mean that when bullet is created it will move forward
		rigidbody2D.velocity = transform.forward * speed;
	}
	
	void OnBecameInvisible()
	{
		//destroy bullet
		Destroy (gameObject);
	}
}