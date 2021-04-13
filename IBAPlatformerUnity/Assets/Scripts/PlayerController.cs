using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public bool jumpCheck = false;

    private Transform trans;
    private Rigidbody2D r2D;
    private SpriteRenderer SPR;
    public GameObject MenuUI;
    public GameObject DialogueUI;
    public GameObject QuestionUI;
    public GameObject dimension;
    public GameObject dimensionTilemap;
    public bool checkdim = false;
    //private Animator anime;

    void Start()
    {
        Debug.Log("HASSAN IS A LEGEND!");
        trans = GetComponent<Transform>();
        r2D = GetComponent<Rigidbody2D>();
        //anime = GetComponent<Animator>();
        SPR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jumpCheck)
        {
            r2D.velocity = new Vector2(r2D.velocity.x, jumpForce);
            jumpCheck = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            r2D.velocity = new Vector2(moveSpeed, r2D.velocity.y);
            //anime.SetBool("Run", true);
            SPR.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            r2D.velocity = new Vector2(-moveSpeed, r2D.velocity.y);
            //anime.SetBool("Run", true);
            SPR.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if(!checkdim){
                dimension.SetActive(true);
                dimensionTilemap.SetActive(true);
                checkdim = true;
            }
            else{
                dimension.SetActive(false);
                dimensionTilemap.SetActive(false);
                checkdim = false;
            }
        }

        if(checkdim){
            if(dimension.transform.localScale.y < 650){
                dimension.transform.localScale += new Vector3(50f * Time.deltaTime,50f * Time.deltaTime, 0);
            } 
        }
        else{
            if(dimension.transform.localScale.y > 0){
                dimension.transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GameController"))
        {
            jumpCheck = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(0);
        } 
        else if (other.gameObject.CompareTag("Player"))
        {
            MenuUI.SetActive(true);
            DialogueUI.SetActive(true);
        }   
        else if (other.gameObject.CompareTag("Enemy"))
        {
            MenuUI.SetActive(true);
            QuestionUI.SetActive(true); 
        }

        else if (other.gameObject.CompareTag("Acid"))
        {
            SceneManager.LoadScene(2);
        }


    }
}
