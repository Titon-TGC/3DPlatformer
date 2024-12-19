using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UI : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject pauseMenu;

    public Text levelText;
    public Text timer;

    public GameObject level;
    public string levelString;
    public Slider soundSlider;
    public AudioMixer masterMixer;

    private float time;
    public bool timerOn;

    private void Start()
    {
        timerOn = true;
    }

    public void SetVolume (float volume)
    {
        masterMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }

    private void Update()
    {
        if(timerOn)
            time += Time.deltaTime;
        timer.text = time.ToString("#.00");
        LevelText();
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(!pauseMenu.activeInHierarchy)
                OpenUI();
            else
                CloseUI();
        }
    }

    private void OpenUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        mainUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void CloseUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        mainUI.SetActive(true);
        Time.timeScale = 1;
    }

    private void LevelText()
    {
        if(level == GameObject.Find("Level1"))
            levelString = "1";
        if(level == GameObject.Find("Level2"))
            levelString = "2";
        if(level == GameObject.Find("Level3"))
            levelString = "3";
        if(level == GameObject.Find("Level4"))
            levelString = "4";
        if(level == GameObject.Find("Level5"))
            levelString = "5";
        if(level == GameObject.Find("Level6"))
            levelString = "6";
        if(level == GameObject.Find("Level7"))
            levelString = "7";
        if(level == GameObject.Find("Level8"))
            levelString = "8";
        
        levelText.text = levelString;
        
    }
}
