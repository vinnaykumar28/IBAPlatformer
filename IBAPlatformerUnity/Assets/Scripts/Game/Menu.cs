using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject GameMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            MenuUI.SetActive(true);
            GameMenuUI.SetActive(true);
        }        
    }
}
