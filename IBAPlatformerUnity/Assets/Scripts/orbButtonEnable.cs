using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orbButtonEnable : MonoBehaviour
{

    public Button dimensionButton;
    [SerializeField] static private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainChar"))
        {
            dimensionButton.interactable = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("MainChar")) && (!flag))
        {
            dimensionButton.interactable = false;
            //Debug.Log("Debog log lel");
        } 
    }

    public void disableButton()
    {
        if (flag)
        {
            dimensionButton.interactable = false;
            flag = false;
        }
        else
        {
            flag = true;
        }
    }
}
