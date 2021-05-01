using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionMenu : MonoBehaviour
{
    public void YesGame(){
        SceneManager.LoadScene(2);
    }

    public void NoGame(){
        SceneManager.LoadScene(2);
    }
}
