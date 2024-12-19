using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Checkpoint")]
    public Transform checkpoint;
    public GameObject level;

    private GameObject UI;

    private void Start()
    {
        UI = GameObject.Find("UI");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<CheckPointManager>().currentCheckpoint = checkpoint;
            SpawnLevel();
            UI.GetComponent<UI>().level = level;
        }
    }

    private void SpawnLevel()
    {
        level.GetComponent<Animator>().SetTrigger("Spawn");
    }
}