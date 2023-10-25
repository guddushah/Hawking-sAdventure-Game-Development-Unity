using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    // Use this for initialization
    public GameObject prefb;
    public Vector3 pos;
   

    void Start () {
        InvokeRepeating("prefabb", 0, 1f);

    }
   
    // Update is called once per frame
    public void prefabb()
    {
        Instantiate(prefb, new Vector3(pos.x,transform.position.y,transform.position.z), Quaternion.identity);
        pos.x +=8f;
    }
  
}
