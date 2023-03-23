using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int points=0;
    public int blue=5;
    public int red=5;
    public bool paused=false;
    bool end=false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject crosshair;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] TMP_Text redDisp;
    [SerializeField] TMP_Text blueDisp;
    [SerializeField] TMP_Text pointsDisp;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !end)
        {
            SwitchPause();
        }
        
    }
    public void EndGame()
    {
        end=true;
        paused=true;
        Time.timeScale=0;
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        crosshair.SetActive(false);
        loseScreen.SetActive(true);
        
    }
    void WinGame()
    {
        end=true;
        paused=true;
        Time.timeScale=0;
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        crosshair.SetActive(false);
        winScreen.SetActive(true);
        
    }
    public void SwitchPause()
    {
        paused=!paused;
        if (paused)
        {
            Time.timeScale=0;
            Cursor.visible=true;
            Cursor.lockState=CursorLockMode.None;
            pauseMenu.SetActive(true);
            crosshair.SetActive(false);
        }
        else
        {
            Time.timeScale=1;
            Cursor.visible=false;
            Cursor.lockState=CursorLockMode.Locked;
            pauseMenu.SetActive(false);
            crosshair.SetActive(true);
        }
    }
    public void Point()
    {
        points++;
        if (points==10)
        {
            WinGame();
        }
        redDisp.text=red.ToString();
        blueDisp.text=blue.ToString();
        pointsDisp.text=points.ToString();
    }
}
