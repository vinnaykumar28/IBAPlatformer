using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Story : MonoBehaviour
{
    [SerializeField] private string[] dialogues;
    static private int index = 0;
    [SerializeField] private TextMeshProUGUI text;

    void Update()
    {
        text.text = dialogues[index];
    }

    static public void SetIndex(int i)
    {
        index = i;
    }
}
