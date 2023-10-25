using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour {

    // Use this for initialization
    public Camera mainCam;
    private Vector2 widthThresold;
    public Transform cameraPos;
    public Rigidbody2D rb2d;
    public float runforward, jumpvelocity;
    //increase parallex speed
    mov classcheck;
    public cammov cam;

    //speed booster
    public float speedMultiplier;
    public float speedincreaseMilestone;
    private float speedmilestoneCount;

    //jump
    public LayerMask groundLayer;
    public Transform checkGround;
    float groundCheckRadius = 0.2f;
    public bool isGrounded;
    private Animator charAnim;

    //access camera rigidbody
    public GameObject accCamera;
    public Rigidbody2D rbaccCamera;

    //particle system
    public ParticleSystem system;

    GameObject particleObj;

    private barScript barscrip;
    private float up = 5.0f;

    private Animator anima;
    public bool tap;
    public bool canPlay=true;
    private bool gameover = false;
    public GameObject endPanel;

    public GameObject rod;
    public Transform rodPos;

    public Text enemiesKilled;
    private int i = 1;
    private const float upto = 10f;
    public bool fuelDegfast;

    bool longPress = false;
    public float tempVel;

    private void Awake()
    {        
        rbaccCamera = accCamera.GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<cammov>();
    }

    void Start ()
    {
        charAnim = GetComponentInChildren<Animator>();      
        anima = GetComponent<Animator>();     
        rb2d = GetComponent<Rigidbody2D>();
        barscrip = FindObjectOfType<barScript>();
        fuelDegfast = true;
        isGrounded = true;      
        //particle system
        system = transform.GetChild(2).GetComponent<ParticleSystem>();
        particleObj = transform.GetChild(2).gameObject;
        particleObj.SetActive(false);        
        speedmilestoneCount = speedincreaseMilestone;        
    }

    public void FixedUpdate()
    {

        if (isGrounded && Input.GetMouseButtonDown(0) && canPlay)
        {         
            barscrip.FuelDegrade(up);
            rb2d.velocity = new Vector2(rb2d.velocity.x, Time.timeScale * jumpvelocity);
            particleObj.SetActive(true);
            StartCoroutine(disableParticle());
        }
        else if (Input.GetMouseButton(0))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + (tempVel * Time.timeScale));
        }
        if (transform.position.x > speedmilestoneCount)
        {
            speedmilestoneCount += speedincreaseMilestone;
            speedincreaseMilestone = speedincreaseMilestone * speedMultiplier * Time.timeScale;
            runforward = runforward * speedMultiplier * Time.timeScale;
        }

        rb2d.velocity = new Vector2(runforward * Time.timeScale, rb2d.velocity.y);
        isGrounded = Physics2D.OverlapCircle(checkGround.position, groundCheckRadius, groundLayer);
        
       if (Input.GetMouseButton(0) && isGrounded && canPlay)
        {
            barscrip.FuelDegrade(up);
            rb2d.velocity = new Vector2(rb2d.velocity.x, Time.timeScale * jumpvelocity);
            particleObj.SetActive(true);
            StartCoroutine(disableParticle());
        }              
        if (Input.GetKeyDown(KeyCode.A))
        {
            throwRod();
        }
       
        
        /* Vector2 screenPos = mainCam.WorldToScreenPoint(transform.position);
        if(screenPos.x<widthThresold.x)
        {
            endGame();
            
        }*/
        
    }
    
    public void endGame()
    {
        Debug.Log("game over");
        gameover = true;
        endPanel.SetActive(true);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            endGame();
           // Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="pits")
        {
            //Destroy(gameObject);
            endGame();
        }
    }

    IEnumerator disableParticle() {
          yield return new WaitForSeconds(1.3f);
          particleObj.SetActive(false);
      }
    IEnumerator disableRot()
    {
        yield return new WaitForSeconds(0.99f);
      //  anima.enabled = !anima.enabled;
    }


    public void OnButtonClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

  
    public void throwRod()
    {
        GameObject temp = (GameObject)Instantiate(rod, rodPos.position, Quaternion.Euler(new Vector3(0,0,-90)));
        temp.GetComponent<rodScript>().Initialize(Vector2.right);
    }
    public void enemiesKill()
    {       
        enemiesKilled.text = "Enemies Killed:" + i;
        i++;       
    }
   
}
