using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostWalker : MonoBehaviour
{
    public bool check = false;
    private Animator anime;
    [SerializeField] private Rigidbody2D r2D;
    [SerializeField] private SpriteRenderer SPR;
    [SerializeField] private BoxCollider2D B2D;


    // Start is called before the first frame update
    void Start()
    {
        r2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        SPR = GetComponent<SpriteRenderer>();
        B2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Stop ghost once it has reached destination and enable collider
        if (transform.position.x >= 12)
        {
            r2D.velocity = new Vector2(0, r2D.velocity.y);
            anime.SetBool("ghostRunner", false);
            SPR.flipX = false;
            B2D.enabled = true;
        }
    }

    public void movement()
    {
        if (!check)
        {
            r2D.velocity = new Vector2(7f, r2D.velocity.y);
            anime.SetBool("ghostRunner", true);
            B2D.enabled = false;
            check = true;
        }
    }
}
