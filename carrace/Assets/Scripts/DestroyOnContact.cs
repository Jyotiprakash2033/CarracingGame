using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   private void OnTriggerEnter(Collider other)
    {
       Destroy(other.transform.parent.gameObject);
    }
}
