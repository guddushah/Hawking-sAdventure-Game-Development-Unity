using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class barScript : MonoBehaviour {

    // Use this for initialization
    public Text currentFuel;
    public Image fuelBar;
    public float hitPoint = 100;
    public float maxhitPoint = 100;
    public GameObject fuell;
    public playercontrol player;
    private int i = 1;
    public Text fuelsCollected;
  

    private float recentfuel;

    void Start()
    {
        player = FindObjectOfType<playercontrol>();     
        UpdateFuelbar();
    }

    private void Update()
    {

    }

    private void UpdateFuelbar ()
    {
        

        float ratio = hitPoint / maxhitPoint;       
        fuelBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        currentFuel.text =(ratio * 100).ToString() + "%";
      
    }
  

   public void FuelDegrade(float degrade)
    {
        
        hitPoint -= degrade;
        if (hitPoint<=0)
        {
            hitPoint = 0;             
            Debug.Log("game over");
            player.canPlay = false;
        }
        
        UpdateFuelbar();
    }

  public void FuelUpgrade(float upgrade)
    {
        // Debug.Log(i);
        fuelsCollected.text = "Fuels Collected:" + i;
        i++;
        hitPoint += upgrade;
        if(hitPoint>maxhitPoint)
        {
            maxhitPoint = hitPoint;
        }
        UpdateFuelbar();
    }
}
