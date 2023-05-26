using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float maxtimeValue = 30;
    public PlayerMovement MovementScript;
    public Text timeText;
    private float time = 0;
    // Update is called once per frame
    
    void Start() {
        DisplayTime(time);
    }
    void Update()
    {

    }
    void FixedUpdate() {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(time < maxtimeValue) {
            time += Time.deltaTime;
        }
        else
        {
            //float szene = SceneManager.GetActiveScene().buildIndex;
            //string szenestring = szene.ToString();
            //Debug.Log(szene);
            // reset scene
            //SceneManager.LoadScene("Main Menu");
            MovementScript.SendMessage("losebytime", SendMessageOptions.DontRequireReceiver);
        }
        DisplayTime(time);
    }
    public void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay > maxtimeValue)
        {
            timeToDisplay = 0;
        }
        else if(timeToDisplay < maxtimeValue)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        //timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds); <--- fuer Millisekunden anzeige (else if aus Display time muss dann raus)
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
