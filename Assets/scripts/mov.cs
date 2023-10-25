using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{

    // Use this for initialization
    public float parallaxSpeed;
    public float backgroundSize;
    public const float speed = 0.05f;
    private Transform cameraTransform;
    private Transform[] layers;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;
    public const float delta = 0.008f;
    public bool canScroll;

   
    void Start()
    {       
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    void Update()
    {
        transformdis();

    
    }

    public void transformdis()
    {
        transform.position += Vector3.right * (delta * parallaxSpeed);

        lastCameraX = cameraTransform.position.x;

         if (cameraTransform.position.x < (layers[leftIndex].transform.position.x))
          {
              scrollLeft();
          }
        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x))
        {
            scrollRight();
        }
    }


    private void scrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex<0)
        {
            rightIndex=layers.Length - 1;
        }
    }
   private void scrollRight()
    {
      
            int lastLeft = leftIndex;
            layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
            rightIndex = leftIndex;
            leftIndex++;
            if (leftIndex == layers.Length)
            {
            leftIndex = 0;
            }
        }
}