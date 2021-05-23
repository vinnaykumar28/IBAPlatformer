using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPlatformMove : MonoBehaviour
{
    public GameObject platform;
    public bool enableWithDimension = false;
    private static bool checkdim = false;
    public bool isDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        checkdim = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DimensionMobile(){
        if(!checkdim){
            checkdim = true;
        }
        else{
            checkdim = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((enableWithDimension && checkdim) || (!enableWithDimension))
        if (collision.gameObject.CompareTag("MainChar"))
        {
            if(isDoor){
                platform.SetActive(false);
            }
            else{            
                platform.GetComponent<Platform>().startMoving();
            }
        }
    }
}
