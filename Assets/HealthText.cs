using UnityEngine;
using System.Collections;

public class HealthText : MonoBehaviour {

    void Start ()
    {
    }
	// Update is called once per frame
	void Update () {

        GUIText guiText = GetComponent<GUIText>();

        ControlPlayer scriptA = GameObject.FindObjectOfType(typeof(ControlPlayer)) as ControlPlayer;

        guiText.text = ("Health: " + scriptA.currentHealth.ToString());

	}
}
