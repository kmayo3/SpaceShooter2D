using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthFill : MonoBehaviour {

    int health = 0;
    
    void Start () {
    }

	// Update is called once per frame
	void Update () 
    {
        Image image = GetComponent<Image>();

        ControlPlayer scriptA = GameObject.FindObjectOfType(typeof(ControlPlayer)) as ControlPlayer;

        health = scriptA.currentHealth;

        image.fillAmount = (float)(health) / 100;
	}
}
