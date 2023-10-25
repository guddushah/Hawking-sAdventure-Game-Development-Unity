using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spineGeneration : MonoBehaviour {

    // Use this for initialization
    public GameObject spawnSpine;
    private Vector3 pos;
    void Start () {
        InvokeRepeating("Spine", 1, 5);
    }
	
	// Update is called once per frame
	private void Spine () {
        Instantiate(spawnSpine, new Vector3(pos.x, transform.position.y, transform.position.z), Quaternion.identity);
        pos.x += Random.Range(10, 25);
    }
}
