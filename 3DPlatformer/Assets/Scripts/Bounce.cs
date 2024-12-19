using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    public float force; //change for applied in inspector
    private GameObject player; //player

    private void OnCollisionEnter(Collision col)
    {
        gameObject.GetComponent<AudioSource>().Play();
        player = col.gameObject; // player is the collided object
        Vector3 down = transform.up; // find direction
        player.GetComponent<Rigidbody>().velocity = down * force; // apply force to player
    }
}