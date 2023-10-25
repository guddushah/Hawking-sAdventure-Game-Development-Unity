using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammov : MonoBehaviour {

    public Transform Target;
    public float smoothValue;
    Vector3 offset;
    public GameObject child0;
  //  public Transform enemyThresold;
  //  public GameObject child1;
   // spawnEnemy enemyy;
    

    public bool canFollow;
    playercontrol control;
  
   

    private void Start()
    {
        offset = transform.position - Target.transform.position;
        canFollow = true;

    }


    void LateUpdate()
    {
        control = FindObjectOfType<playercontrol>();
       // enemyy = FindObjectOfType<spawnEnemy>();
       
        if (control.rb2d.velocity.x <= 0)
        {
            canFollow = false;
           /* if(Target.position.x<child0.transform.position.x)
            {
                Destroy(Target.gameObject);
            }*/
          /*  if(Target.position.x>child1.transform.position.x)
            {
                enemyy.Enemy();
            }*/
            
        }
        else
        {
            canFollow = true;
        }

        if (canFollow)
        {
            Vector3 position = new Vector3(Target.transform.position.x + 6f, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, position, smoothValue * Time.deltaTime);
        }
    }
}
