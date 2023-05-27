using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    //Referenzen
    public PlayerMovement Movementscript;
    public Timer timecontroller;
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject GameEndScreen;
    public Text TimeDisplay;

    //Parameter
    bool youwin;
    string maxtimeValue;

    void Start()
    {
        float maxtime = timecontroller.GetComponent<Timer>().maxtimeValue;;
        maxtimeValue = maxtime.ToString();
    }

    void GameEnd() {

        Text timegetter = timecontroller.GetComponent<Timer>().timeText;;
        string timegettertext = timegetter.ToString();

        if(timegettertext == maxtimeValue) {
            youwin = false;
        }
        else {
            youwin = true;   	
        }


        GameEndScreen.SetActive(true);
        TimeDisplay.text = string.Empty;
        TimeDisplay.text = "your time is: " + timegettertext;

        //SceneManager.LoadScene("Main Menu");

        if(youwin) {
            WinText.SetActive(true);
        } 
        else {
            LoseText.SetActive(true);
        }

        Movementscript.SendMessage("deactivateMovement");
    }
}
