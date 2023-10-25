using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rodScript : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D rb2d;
    public float speed;
    private Vector2 direction;
   
   
    private playercontrol player;
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<playercontrol>();
	}
	
	// Update is called once per frame
	void Update ()
    {
       // direction = Vector2.right;
	}

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = direction * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            //Debug.Log("enemies kill");
            player.enemiesKill();          
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
