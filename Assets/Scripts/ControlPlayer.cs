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

    //health variables
    public int maxHealth;
    public int currentHealth;
    public float healthBarLength;

    //images for health bar
    public Texture2D bgImage;
    public Texture2D fgImage;

    void Start()
    {
        maxHealth = 1000000;
        currentHealth = 1000000;
        healthBarLength = Screen.width / 8;
    }

	void Update()
	{
        //update current health
        AddJustCurrentHealth(0);

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

    void OnGUI()
    {
        //create one group to contain both images
        //adjust the first two coordinates to place it somewhere else on screen
        GUI.BeginGroup(new Rect(0, 0, healthBarLength, 15));

        //draw background image
        GUI.Box(new Rect(0, 0, healthBarLength, 15), bgImage);

        //create second group which will be clipped 
        //want to clip the image and not scale it
        GUI.BeginGroup(new Rect(0, 0, currentHealth / maxHealth * healthBarLength, 15));

        //draw foreground image
        GUI.Box(new Rect(0, 0, healthBarLength, 15), fgImage);

        //end both groups
        GUI.EndGroup();
        GUI.EndGroup();
    }

    public void AddJustCurrentHealth(int health)
    {
        currentHealth += health;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (maxHealth < 1)
        {
            maxHealth = 1;
        }

        //change the length of the health bar
        healthBarLength = (Screen.width / 8) * (currentHealth / (float)maxHealth);
    }

    void OntriggerEnter2D(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            //lower health if hit with bullet
            currentHealth -= 10;
        }
    }
}
