using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuel : MonoBehaviour {
    private Rigidbody2D rbd;
    private float speed = -13f;
    private float fraction = 0.008f;
    void Start ()
    {
        rbd = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        rbd.velocity = new Vector3(-6.01f, transform.position.y, transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="player")
        {
           col.SendMessage("FuelUpgrade", 10.0f);
            Destroy(gameObject);
        }                  
    }
}
