using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyFillHealth : MonoBehaviour {

    int health = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Image image = GetComponent<Image>();

        enemyScript scriptA = GameObject.FindObjectOfType(typeof(enemyScript)) as enemyScript;

        health = scriptA.currentHealth;

        image.fillAmount = (float)(health) / 100;
	}
}
