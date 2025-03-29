using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarController : MonoBehaviour
{  
    
    public int Coins;
    public WheelCollider[] wheel_col; 
    public Transform[] wheels; 
    float torque = 150;  
     float angle = 45;
 public Text CoinText;
    public float maxSpeed = 500f;  
    public float acceleration = 1000f; 
    public float brakingTorque = 2000f;  
private float currentSpeed = 0f;  
    private float targetSpeed = 0f;
    void Start()
    {
     Coins=0;
    }
    
    
    void Update()
    {
        Debug.Log(Coins);
       CoinText.text =("Coins = "+ Coins.ToString());
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        
        targetSpeed = verticalInput * maxSpeed;

       
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);


        for (int i = 0; i < wheel_col.Length; i++)
        {
            
            wheel_col[i].motorTorque = Input.GetAxis("Vertical") * torque;
            if( i==2||i==3)
            {
               wheel_col[i].steerAngle=Input.GetAxis("Horizontal")*angle; 
            }
            var pos = transform.position;
            var rot = transform.rotation;
            wheel_col[i].GetWorldPose(out pos, out rot);
            wheels[i].position=pos;
            wheels[i].rotation=rot;

            
        }
    if(Input.anyKeyDown)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                foreach( var i in wheel_col)
                {
                    i.brakeTorque=2000;
                }
            }
            else
             {
                foreach( var i in wheel_col)
                {
                    i.brakeTorque=0;
                }
            }
            
        }
    }
}