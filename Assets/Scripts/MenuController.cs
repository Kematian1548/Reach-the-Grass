using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string FirstScene;
    public string TestEnvironment;
    public void StartGame() {
        SceneManager.LoadScene(FirstScene);
    }
    public void TestScene() {
        SceneManager.LoadScene(TestEnvironment);
    }
    public void Leave() {
        Application.Quit();
    }
}
