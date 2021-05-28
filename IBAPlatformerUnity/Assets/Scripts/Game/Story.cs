using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Story : MonoBehaviour
{
    [SerializeField] private string[] dialogues;
    static private int index = 1;
    [SerializeField] private TextMeshProUGUI text;

    void Update()
    {
        text.text = dialogues[index-2];
    }

    static public void SetIndex()
    {
        index++;
    }

    static public int getIndex()
    {
        return index;
    }

    static public void newGame(){
        index = 1;
    }
}
