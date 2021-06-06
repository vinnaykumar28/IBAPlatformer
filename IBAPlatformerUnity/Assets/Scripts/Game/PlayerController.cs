using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public bool jumpCheck = false;
    private Transform trans;
    private Rigidbody2D r2D;
    private SpriteRenderer SPR;
    public GameObject fadeOrigin;
    public GameObject teleSquare;
    public GameObject MenuUI;
    public GameObject DialogueUI;
    public GameObject[] dimension;
    public GameObject dimensionTilemap;
    public AudioSource easterAudio; 
    public AudioSource zaWarudo;
    public AudioSource jumpSound;
    public AudioSource MainMusic;
    private bool checkdim = false;
    private bool rightMove = false;
    private bool leftMove = false;
    private bool restart = false;
    private Animator anime;
    private static bool setPlayerPosition = false;
    private static int SetPosLvl = 0; 

    void Start()
    {
        trans = GetComponent<Transform>();
        r2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        SPR = GetComponent<SpriteRenderer>();
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().Pause();
        restart = true;
        anime.SetBool("death", false);

        if(setPlayerPosition){
            if(SetPosLvl == 2){
                trans.position = new Vector3(44.79f, 29.7277f, 0);
                SPR.flipX = true;
            }
            else if(SetPosLvl == 3){
                trans.position = new Vector3(-35.34f, -7.346163f, 0);
                SPR.flipX = false;
            }

            

            setPlayerPosition = false;
            SetPosLvl = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        fromBlackScreen(restart);

        // if (transform.position.y < -7 && SceneManager.GetActiveScene().buildIndex == 1)
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // }

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
                dimension[i].transform.localScale = Vector3.Lerp(dimension[i].transform.localScale, new Vector3(100.0f, 100.0f, 1.0f), 0.01f);
            } 
        }
            else{
            if(dimension[i].transform.localScale.y > 0){
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
            jumpSound.Play();
            anime.SetBool("jumpTrue", true);
            r2D.velocity = new Vector2(r2D.velocity.x, jumpForce);
            jumpCheck = true;
        }
    }

    public void LeftMobile(){
        if (jumpCheck) GetComponent<AudioSource>().Pause();
        else GetComponent<AudioSource>().UnPause();
        r2D.velocity = new Vector2(-moveSpeed, r2D.velocity.y);
        anime.SetBool("runTrue", true);
        SPR.flipX = true;
        leftMove = true;
    }

    public void RightMobile(){
        if (jumpCheck) GetComponent<AudioSource>().Pause();
        else GetComponent<AudioSource>().UnPause();
        r2D.velocity = new Vector2(moveSpeed, r2D.velocity.y);
        anime.SetBool("runTrue", true);
        SPR.flipX = false;
        rightMove = true;
    }

    public void CancelLeftRight(){
        GetComponent<AudioSource>().Pause();
        anime.SetBool("runTrue", false);
        r2D.velocity = new Vector2(0, r2D.velocity.y);
        leftMove = false;
        rightMove = false;
    }

    public void DimensionMobile(){
        if(!checkdim){
            MainMusic.Pause();
            zaWarudo.Play();
            for (int i = 0; i < dimension.Length; i++)
            {
                dimension[i].SetActive(true);
            }
            dimensionTilemap.SetActive(true);
            checkdim = true;
        }
        else{
            zaWarudo.Play();
            MainMusic.Play();
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
    
    IEnumerator waitBeforeReload()
    {
        //print(Time.time);
        yield return new WaitForSeconds(2);
        //print(Time.time);
        restart = false;
        toBlackScreen(restart);
        //yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator backToReal()
    {
        yield return new WaitForSeconds(2);
    }

    public void fromBlackScreen(bool status)
    {
        //This is when the level starts or arrive at a tp
        if (status)
        {
            fadeOrigin.transform.localScale = Vector3.Lerp(fadeOrigin.transform.localScale, new Vector3(0, 0, 1.0f), 0.05f);
        }
    }

    public void toBlackScreen(bool status)
    {
        //This is when you die or collide with a tp invoker
        if (!status)
        {
            fadeOrigin.transform.localScale = Vector3.Lerp(fadeOrigin.transform.localScale, new Vector3(100.0f, 100.0f, 1.0f), 0.1f);
        }
    }

    IEnumerator labyrinthPortal()
    {
        // fadeOrigin.transform.localScale = Vector3.Lerp(fadeOrigin.transform.localScale, new Vector3(100.0f, 100.0f, 1.0f), 0.1f);
        yield return new WaitForSeconds(2);
        //GameObject positionHolder = new GameObject();
        //positionHolder.GetComponent<Transform>().position = trans.position; //Placeholder has the position of player when he was near statue.
        trans.position = teleSquare.GetComponent<Transform>().position; //Player is now moved to the teleSquare.
        //teleSquare.GetComponent<Transform>().position = positionHolder.GetComponent<Transform>().position; //teleSquare is now at the original position of the player.
        //fadeOrigin.transform.localScale = Vector3.Lerp(fadeOrigin.transform.localScale, new Vector3(0, 0, 1.0f), 0.05f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            MenuUI.SetActive(true);
            DialogueUI.SetActive(true);
        }   
        else if (other.gameObject.CompareTag("Goal")){
            SceneManager.LoadScene(Story.getIndex());
        }
        else if (other.gameObject.CompareTag("Enemy")){
            Story.SetIndex();
            SceneManager.LoadScene("Transition");
        }
        else if (other.gameObject.CompareTag("Coin")){
            easterAudio.Play();
        }
        else if (other.gameObject.CompareTag("Acid")){
            anime.SetBool("death", true);
            // restart = false;
            // toBlackScreen(restart);
            StartCoroutine(waitBeforeReload());
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (other.gameObject.CompareTag("End")){
            SceneManager.LoadScene(0);
        }
        else if (other.gameObject.CompareTag("Game1")){
            //SDebug.Log("test!");
            fadeOrigin.transform.localScale = Vector3.Lerp(fadeOrigin.transform.localScale, new Vector3(100.0f, 100.0f, 1.0f), 0.1f);
            StartCoroutine(labyrinthPortal());
            //SceneManager.LoadScene(6);            
        }
        else if (other.gameObject.CompareTag("Game2") && !checkdim){
            SceneManager.LoadScene(7);
        }  
    }

    public static void returnToLevel(int lvl){
        setPlayerPosition = true;
        SetPosLvl = lvl;
    }

}
