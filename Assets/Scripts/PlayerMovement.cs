using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public EndGame endgamescript;
    public Timer timecontroller;
    string timegettertext;
    public float runSpeed = 40f;
    public float jumpdelay;
    public float horizontalMove;
    bool jump = false;
    bool isjumping = false;
    bool youwin;
    string maxtimeValue;
    public bool movementactive = true;

    private void OnTriggerEnter2D(Collider2D collision) {
        endgamescript.SendMessage("GameEnd");
    }
    private void losebytime() {
        //Debug.Log("Time over");
        youwin = false;
        Text timegetter = timecontroller.GetComponent<Timer>().timeText;;
        timegettertext = timegetter.ToString();
        endgamescript.SendMessage("GameEnd");
    }
    void Start() {
        float maxtime = timecontroller.GetComponent<Timer>().maxtimeValue;;
        maxtimeValue = maxtime.ToString();
        movementactive = true;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            toMenu();
        }

        if (Input.GetButtonDown("Jump") && !isjumping)
        {
            jump = true;
            activatejump();
        }
        //check for pressed button
        MovementControl();
        //Move Charakter
        controller.Move(horizontalMove * Time.fixedDeltaTime * runSpeed, false, jump);
    }
    public void Restart() {
        float currentscene = SceneManager.GetActiveScene().buildIndex - 1;
        string currentscenestring = "Map" + currentscene.ToString();
        SceneManager.LoadScene(currentscenestring);
        movementactive = true;
    }
    public void toMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    void StartGame() {
        float szene = SceneManager.GetActiveScene().buildIndex;
        string szenestring = szene.ToString();
        SceneManager.LoadScene(szenestring);
    }
    public void activatejump() {
        jump = true;
        isjumping = true;
        Invoke("resetJump", jumpdelay);
    } 
    void resetJump() {
        jump = false;
        isjumping = false;
    }
    void MovementControl() {
        if(movementactive) {
            if(Input.GetKeyDown(KeyCode.A)) {
                horizontalMove = -1;
            }
            if(Input.GetKeyUp(KeyCode.A)) {
                horizontalMove = 0;
            }

            if(Input.GetKeyDown(KeyCode.D)) {
                horizontalMove = 1;
            }
            if(Input.GetKeyUp(KeyCode.D)) {
                horizontalMove = 0;
            }
        }
        
    }
    void deactivateMovement() {
        horizontalMove = 0;
        movementactive = false;
    }
    void activateMovement() {
        movementactive = true;
    }
}
