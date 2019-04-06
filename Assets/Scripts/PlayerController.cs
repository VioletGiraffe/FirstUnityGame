using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody myRigidBody;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 newVelocity)
    {
        velocity = newVelocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void FixedUpdate()
    {
        myRigidBody.MovePosition(myRigidBody.position + velocity * Time.fixedDeltaTime);
    }
}
