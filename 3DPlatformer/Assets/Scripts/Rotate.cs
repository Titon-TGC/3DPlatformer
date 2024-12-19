using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Rigidbody rb; // Rigidbody of the rotating thingy in inspector
    public float rotX; //variables so you can switch what rotation is being used, did this cuz the prefab in the pack only rotates 1 direction. (Make sure to lock other rotations in inspector)
    public float rotZ;
    public float rotY;

    void FixedUpdate()
    {
        rb.AddTorque(rotX, rotY, rotZ, ForceMode.Impulse); // Add force to the rotating thing
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
            gameObject.GetComponent<AudioSource>().Play();
    }
}
