using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuplicateQuestionMenu : MonoBehaviour
{
    public void YesGame(){
        SceneManager.LoadScene(3);
    }

    public void NoGame(){
        SceneManager.LoadScene(3);
    }
}
