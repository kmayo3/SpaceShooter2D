using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	//boundary for x and y axis
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;
}

public class ControlPlayer : MonoBehaviour
{
	//speed variable
	public float speed;

	//bounds of game
	public Boundary bounds;

	//takes care of the shots in the game
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;


	void Update()
	{
		if (Input.GetButton ("Submit") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate()
	{
		//gets input from user for the horizontal/vertical
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed;
		float moveVertical = Input.GetAxis ("Vertical") * speed;

		//movement for object
		Vector2 movementAmount = new Vector2 (moveHorizontal, moveVertical);

		//velocity of object
		rigidbody2D.velocity = movementAmount * speed;

		//clamps player within bounds
		rigidbody2D.position = new Vector2
			(
				Mathf.Clamp(rigidbody2D.position.x, bounds.xMin, bounds.xMax),
				Mathf.Clamp(rigidbody2D.position.y, bounds.yMin, bounds.yMax)
			);
	}
	
}
