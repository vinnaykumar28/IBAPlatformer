using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public int index;
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public bool jumpCheck = false;
    private Transform trans;
    private Rigidbody2D r2D;
    private SpriteRenderer SPR;
    public GameObject MenuUI;
    public GameObject DialogueUI;
    //public GameObject QuestionUI;
    public GameObject[] dimension;
    public GameObject dimensionTilemap;
    // public Button ButtonLeft;
    // public Button ButtonRight;
    // public Button ButtonDimension;
    // public Button ButtonJump;    
    public bool checkdim = false;
    private bool rightMove = false;
    private bool leftMove = false;
    private Animator anime;

    void Start()
    {
        // GetComponent<AudioSource>().Pause();
        Debug.Log("HASSAN was A LEGEND!");
        trans = GetComponent<Transform>();
        r2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        SPR = GetComponent<SpriteRenderer>();
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space) && !jumpCheck)
        {
            anime.SetBool("jumpTrue", true);
            r2D.velocity = new Vector2(r2D.velocity.x, jumpForce);
            jumpCheck = true;
            //anime.SetBool("jumpTrue", false);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //GetComponent<AudioSource>().Play();
            if (jumpCheck) GetComponent<AudioSource>().Pause();
            else GetComponent<AudioSource>().UnPause();
            r2D.velocity = new Vector2(moveSpeed, r2D.velocity.y);
            anime.SetBool("runTrue", true);
            //GetComponent<AudioSource>().UnPause();
            SPR.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //GetComponent<AudioSource>().Play();
            if (jumpCheck) GetComponent<AudioSource>().Pause();
            else GetComponent<AudioSource>().UnPause();
            r2D.velocity = new Vector2(-moveSpeed, r2D.velocity.y);
            anime.SetBool("runTrue", true);
            // GetComponent<AudioSource>().UnPause();
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
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            GetComponent<AudioSource>().Pause();
            anime.SetBool("runTrue", false);
            jumpCheck = false;
            r2D.velocity = new Vector2(0, r2D.velocity.y);
        }

        */

/*
        if (Input.GetKeyDown(KeyCode.Space) && !jumpCheck)
        {
            anime.SetBool("jumpTrue", true);
            r2D.velocity = new Vector2(r2D.velocity.x, jumpForce);
            jumpCheck = true;
            //anime.SetBool("jumpTrue", false);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //GetComponent<AudioSource>().Play();
            if (jumpCheck) GetComponent<AudioSource>().Pause();
            else GetComponent<AudioSource>().UnPause();
            r2D.velocity = new Vector2(moveSpeed, r2D.velocity.y);
            anime.SetBool("runTrue", true);
            //GetComponent<AudioSource>().UnPause();
            SPR.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //GetComponent<AudioSource>().Play();
            if (jumpCheck) GetComponent<AudioSource>().Pause();
            else GetComponent<AudioSource>().UnPause();
            r2D.velocity = new Vector2(-moveSpeed, r2D.velocity.y);
            anime.SetBool("runTrue", true);
            // GetComponent<AudioSource>().UnPause();
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
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            GetComponent<AudioSource>().Pause();
            anime.SetBool("runTrue", false);
            jumpCheck = false;
            r2D.velocity = new Vector2(0, r2D.velocity.y);
        }
        */

        if (transform.position.y < -7 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(leftMove){
            LeftMobile();
        }
        else if(rightMove){
            RightMobile();
        }

        for (int i = 0; i < dimension.Length; i++)
        {
            if(checkdim){
            if(dimension[i].transform.localScale.y < 100){
                //dimension.transform.localScale += new Vector3(50f * Time.deltaTime,50f * Time.deltaTime, 0);
                dimension[i].transform.localScale = Vector3.Lerp(dimension[i].transform.localScale, new Vector3(100.0f, 100.0f, 1.0f), 0.01f);
            } 
        }
            else{
            if(dimension[i].transform.localScale.y > 0){
                //dimension.transform.localScale = new Vector3(0, 0, 0);
                 dimension[i].transform.localScale = Vector3.Lerp(dimension[i].transform.localScale, new Vector3(0, 0, 1.0f), 0.02f);
                 if (dimension[i].transform.localScale.y <= 2.0f)
                 {
                    dimension[i].SetActive(false);
                    dimensionTilemap.SetActive(false);
                 }
            }
        }
        }
    }

    public void JumpMobile(){
        if(!jumpCheck){
            anime.SetBool("jumpTrue", true);
            r2D.velocity = new Vector2(r2D.velocity.x, jumpForce);
            jumpCheck = true;
            //anime.SetBool("jumpTrue", false);
        }
    }

    public void LeftMobile(){
        //GetComponent<AudioSource>().Play();
        //Debug.Log("On your left");
        if (jumpCheck) GetComponent<AudioSource>().Pause();
        else GetComponent<AudioSource>().UnPause();
        r2D.velocity = new Vector2(-moveSpeed, r2D.velocity.y);
        anime.SetBool("runTrue", true);
        // GetComponent<AudioSource>().UnPause();
        SPR.flipX = true;
        leftMove = true;
    }

    public void RightMobile(){
        //GetComponent<AudioSource>().Play();
        //Debug.Log("On your left");
        if (jumpCheck) GetComponent<AudioSource>().Pause();
        else GetComponent<AudioSource>().UnPause();
        r2D.velocity = new Vector2(moveSpeed, r2D.velocity.y);
        anime.SetBool("runTrue", true);
        //GetComponent<AudioSource>().UnPause();
        SPR.flipX = false;
        rightMove = true;
    }

    public void CancelLeftRight(){
        GetComponent<AudioSource>().Pause();
        anime.SetBool("runTrue", false);
        jumpCheck = false;
        r2D.velocity = new Vector2(0, r2D.velocity.y);
        leftMove = false;
        rightMove = false;
    }

    public void DimensionMobile(){
        if(!checkdim){
            for (int i = 0; i < dimension.Length; i++)
            {
                dimension[i].SetActive(true);
            }
            dimensionTilemap.SetActive(true);
            checkdim = true;
        }
        else{
            // dimension.SetActive(false);
            // dimensionTilemap.SetActive(false);
            checkdim = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GameController"))
        {
            jumpCheck = false;
            anime.SetBool("jumpTrue", false);
        }

        else if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("In platform collision");
            r2D.gravityScale = 0;
            r2D.mass = 0;

            if (jumpCheck)
            {
                jumpCheck = false;
                anime.SetBool("jumpTrue", false);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            r2D.gravityScale = 1;
            r2D.mass = 1;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.CompareTag("Finish"))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // } 
        if (other.gameObject.CompareTag("Player"))
        {
            MenuUI.SetActive(true);
            DialogueUI.SetActive(true);
            //anime.SetBool("ghostWalk", true);
        }   
        else if (other.gameObject.CompareTag("Goal"))
        {
            // MenuUI.SetActive(true);
            // QuestionUI.SetActive(true); 
            // Story.SetIndex();
            // SceneManager.LoadScene("Transition");
            //Story.SetIndex();
            SceneManager.LoadScene(Story.getIndex());
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            // MenuUI.SetActive(true);
            // QuestionUI.SetActive(true); 
            Story.SetIndex();
            SceneManager.LoadScene("Transition");
            //Story.SetIndex();
        }

        else if (other.gameObject.CompareTag("Acid"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (other.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene(0);
        }

    }

}
