using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour {

    // Use this for initialization
    public GameObject spawnEne;
    public Vector3 pos;
    public Transform csmTrans;

   // Rigidbody2D rbd;
    void Start () {
        InvokeRepeating("Enemy", 1, 0.2f);
      
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void Enemy()
    {
        Instantiate(spawnEne, new Vector3(pos.x, Random.Range(3.5f,-1.6f), transform.position.z), Quaternion.identity);
        pos.x += Random.Range(2,10 );
    }
}
