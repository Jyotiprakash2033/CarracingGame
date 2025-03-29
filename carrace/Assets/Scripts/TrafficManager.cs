using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    [SerializeField] Transform[] lane;
    [SerializeField] GameObject[] trafficVehicle;
    [SerializeField] CarController1 carController;
   [SerializeField] float minSpawnTimer = 30f;
   [SerializeField] float maxSpawnTimer = 60f;
    private float dynamicTimer = 2f;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(TrafficSpawner());
    }

    IEnumerator TrafficSpawner()
    {
      yield return new WaitForSeconds(2f);
      while(true)
      {
         
        
        if(carController.CarSpeed()>1f)
        {
          dynamicTimer = Random.Range(minSpawnTimer,maxSpawnTimer)/carController.CarSpeed();
        SpwanTrafficVehicle();
        }
         yield return new WaitForSeconds(dynamicTimer);
      }
    }
    void SpwanTrafficVehicle()
    {
        int randomLaneIndex = Random.Range(0,lane.Length);
        int randomTrafficVehicleIndex = Random.Range(0,trafficVehicle.Length);
        Instantiate(trafficVehicle[randomTrafficVehicleIndex],lane[randomLaneIndex].position,Quaternion.identity);
    }
   
   
}
