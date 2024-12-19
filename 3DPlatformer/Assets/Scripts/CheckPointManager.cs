using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [Header("Checkpoint")]
    public Transform currentCheckpoint;
    public Transform startPoint;

    private void Start()
    {
        currentCheckpoint = startPoint;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        gameObject.transform.position = currentCheckpoint.position;
    }
}