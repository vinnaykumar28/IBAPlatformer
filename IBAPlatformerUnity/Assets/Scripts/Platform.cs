using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private float startY;
    public float endY;
    private bool up;
    public float minus;

    void Start() {
        startY = transform.position.y - minus;
        Debug.Log(startY);
        Debug.Log(endY);
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(up){
            if(transform.position.y - minus < endY){
                transform.position = transform.position + new Vector3(0, 2f * Time.deltaTime, 0);
            }
            else{
                up = false;
            }
        }
        else{
            if(transform.position.y - minus > startY){
                transform.position = transform.position - new Vector3(0, 2f * Time.deltaTime, 0);
            }
            else{
                up = true;
            }
        }
    }
}
