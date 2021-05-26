using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        PlayerController.returnToLevel(0);
        Story.newGame();
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
    
}
