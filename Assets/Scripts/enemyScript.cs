using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour
{
    //bullet variables
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    public GameObject AlienBullet;
    public float secondsBetweenShots = 1f;

    //speed and direction variables
    public float speed = 1f;
    public float leftAndRightEdge = -10f;
    public float directions = 0.1f;

    //health variables
    public int maxHealth;
    public int currentHealth;
    public float healthBarLength;

    //health bar images
    public Texture2D bgImage;
    public Texture2D fgImage;

    void Start()
    {
        //initiazlied variables
        maxHealth = 10000;
        currentHealth = maxHealth;
        healthBarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //update current health
        AddJustCurrentHealth(0);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        Vector3 post = transform.position;
        post.x += speed * Time.deltaTime;
        transform.position = post;

        if (post.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (post.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }

        if (post.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (post.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        else if (Random.value < directions)
        {
            speed *= -1;
        }
    }

    void OnGUI()
    {
        //create one group to contain both images
        //adjust the first two coordinates to place it somewhere else on screen
        GUI.BeginGroup(new Rect((Screen.width / 8) + 6, 0, healthBarLength, 15));

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

        healthBarLength = (Screen.width / 8) * (currentHealth / (float)maxHealth);
    }

    void FixedUpdate()
    {
        if (Random.value < directions)
        {
            speed *= -1;
        }
    }

    void OntriggerEnter2D(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            currentHealth -= 10;
        }
    }
}
