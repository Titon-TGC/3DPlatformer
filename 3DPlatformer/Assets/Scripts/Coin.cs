using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    private bool ifAscending = false;
    public float rotSpeed;
    public float ascendSpeed;
    private GameObject UI;

    private void Start()
    {
        UI = GameObject.Find("UI");
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, rotSpeed * Time.deltaTime);

        if(ifAscending == true)
        {
            transform.position += Vector3.up * ascendSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter()
    {
        StartCoroutine(CoinThing());
        UI.GetComponent<UI>().timerOn = false;
    }

    private IEnumerator CoinThing()
    {
        gameObject.GetComponent<AudioSource>().Play();
        ifAscending = true;
        yield return new WaitForSeconds(18);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Win");
    }
}
