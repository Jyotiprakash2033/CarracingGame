using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
  public AudioSource audio;
   
    void Start()
    {
        
    }

   
    void Update()
    {
       float rotationSpeed = 50f; // Speed of rotation in degrees per second

    // Get the current rotation and add to the Y axis
    Vector3 currentRotation = transform.eulerAngles;
    currentRotation.y += rotationSpeed * Time.deltaTime;

    // Apply the new rotation
    transform.eulerAngles = currentRotation;
        
        
    }
    private void OnTriggerEnter(Collider other)

    {
      Debug.Log(other.gameObject);
      if(other.gameObject.tag == "Body")  
      {
        audio.Play();
        other.gameObject.GetComponent<CarController>().Coins++;
       
       Destroy(gameObject);
        
      }
    }
     
}
