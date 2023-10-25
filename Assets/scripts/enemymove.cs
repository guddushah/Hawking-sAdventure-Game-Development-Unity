using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour {

    // Use this for initialization
    Rigidbody2D rbd;
	void Start () {
        rbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
      rbd.velocity = new Vector3(-6.01f, 0, transform.position.z);
    }
}
