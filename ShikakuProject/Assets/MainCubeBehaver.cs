using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCubeBehaver : MonoBehaviour {

    public float JampPower;
    public float GravityPower;

    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 mousePosition;
    private Camera camera;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        camera = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        mousePosition = Input.mousePosition;
        //if (controller.isGrounded)
        {
            //if (Input.GetMouseButton(0))
            //{
            //    moveDirection.y = JampPower;
            //}
            if (Input.GetMouseButton(0))
            {
                transform.position = camera.ScreenToWorldPoint(mousePosition);
            }
        }

        //moveDirection.y -= GravityPower * Time.deltaTime;
        //controller.Move(moveDirection * Time.deltaTime);
	}
}
