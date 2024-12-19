using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlat : MonoBehaviour
{
	public float fadeSpeed; // controlls fading speed
	public float respawnTime; // controlls respawn timer


	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts) // for each collision
		{
			if (collision.gameObject.tag == "Player") // check if collision is player
			{
				StartCoroutine(Fall()); // start fall
			}
		}
	}

	IEnumerator Fall()
	{
		while (gameObject.GetComponent<Renderer>().material.color.a > 0) // while opacity is more than 0
		{
			Color objectColour = gameObject.GetComponent<Renderer>().material.color; // get objects colour property
			float fadeAmount = objectColour.a - (fadeSpeed * Time.deltaTime); // determine the fade amount
			objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount); // creates the new colour
			gameObject.GetComponent<Renderer>().material.color = objectColour; // changes the objects colour
			yield return null;
		}
	}

	private void Update()
	{
		if(gameObject.GetComponent<Renderer>().material.color.a < 0.1) // if objects opacity is lower than 0.1
		{
			gameObject.GetComponent<BoxCollider>().enabled = false; // disable platforms collider
			StartCoroutine(RespawnPlatform()); // Start respawn
		}
	}

	IEnumerator RespawnPlatform()
	{
		yield return new WaitForSeconds(respawnTime); // wait for respawn time cba to explain rest just changes it back to full opacity and enables collider
		Color objectColour = gameObject.GetComponent<Renderer>().material.color;
		objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, 1);
		gameObject.GetComponent<Renderer>().material.color = objectColour;
		gameObject.GetComponent<BoxCollider>().enabled = true;

	}
}
