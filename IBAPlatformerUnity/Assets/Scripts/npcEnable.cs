using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcEnable : MonoBehaviour
{
    public GameObject statue;
    public GameObject MenuUI;
    public GameObject DialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainChar"))
        {
            MenuUI.SetActive(true);
            DialogueUI.SetActive(true);
            
            statue.GetComponent<Collider2D>().enabled = true;
        } 
    }
}
