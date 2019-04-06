using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    PlayerController controller;
    GameObject groundMesh;
    Camera viewCamera;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
        groundMesh = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(groundMesh.transform.up, Vector3.zero);
        float rayDistance;
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 intersectionPoint = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, intersectionPoint, Color.cyan);
            controller.LookAt(intersectionPoint);
        }
    }
}
