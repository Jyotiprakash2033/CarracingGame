using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController3 : MonoBehaviour
{

    
   [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
     [SerializeField] private Transform frontRightTransform;
     [SerializeField] private Transform backRightTransform;
     [SerializeField] private Transform frontLeftTransform;
     [SerializeField] private Transform backLeftTransform;
     [SerializeField] private Transform carCenterOfMassTransform;

     private Rigidbody rigidbody;
     float verticalInput;
     float horizontalInput;
    [SerializeField] private float motorForce = 100f;
    [SerializeField] private float steeringAngle = 30f;
     [SerializeField] private float brakeForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
      rigidbody.centerOfMass = carCenterOfMassTransform.localPosition;  
    } 

    // Update is called once per frame
    void  FixedUpdate()
    {
      MotorForce();
      UpdateWheels();
      GetInput(); 
       Steering();
       ApplyBrakes();
    }

    void GetInput()
    {
         verticalInput=Input.GetAxis("Vertical");
         horizontalInput = Input.GetAxis("Horizontal");
    }
    void ApplyBrakes()
    {
        if(Input.GetKey(KeyCode.Space))
        {
        frontRightWheelCollider.brakeTorque = brakeForce;
        backRightWheelCollider.brakeTorque =  brakeForce;
        frontLeftWheelCollider.brakeTorque =  brakeForce;
        backLeftWheelCollider.brakeTorque =  brakeForce;
        }
        else
        {
        frontRightWheelCollider.brakeTorque = 0f;
        backRightWheelCollider.brakeTorque = 0f;
        frontLeftWheelCollider.brakeTorque = 0f;
        backLeftWheelCollider.brakeTorque = 0f; 
        }
       

    }
    void MotorForce() 
    {
        frontRightWheelCollider.motorTorque =  motorForce*verticalInput;
        frontLeftWheelCollider.motorTorque =  motorForce*horizontalInput;  

    }

    void Steering()
    {
        frontRightWheelCollider.steerAngle = steeringAngle*horizontalInput;
        frontLeftWheelCollider.steerAngle = steeringAngle*horizontalInput;
    }
    void UpdateWheels()
    {
     RotateWheel(frontRightWheelCollider,frontRightTransform);
     RotateWheel(backRightWheelCollider,backRightTransform);
     RotateWheel(frontLeftWheelCollider,frontLeftTransform);
     RotateWheel( backLeftWheelCollider,backLeftTransform);
    }
    void RotateWheel(WheelCollider wheelCollider,Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
   
}
