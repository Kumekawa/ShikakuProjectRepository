using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCubeBehaver : MonoBehaviour {

    public float JampPower;
    public float GravityPower;
    public cameraBehaver cameraBehaver;

    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 mousePosition;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {

        mousePosition = Input.mousePosition;
        Vector3 t = Camera.main.ScreenToWorldPoint(mousePosition);
        t.z = 0f;

        if (Input.GetMouseButton(0))
        {
            
            if (controller.isGrounded)
            {
                float A = transform.position.x;
                float B = transform.position.y;
                float a = t.x;
                float b = t.y;

                float vx = (a - A) / 2;
                float vy = (b + (2 * GravityPower) - B) / 2;

                moveDirection.x = vx;
                moveDirection.y = vy;
            }
            else
            {
                moveDirection.x = 0f;
            }
        }

        //Debug.Log(cameraBehaver.GetMousePosition());
        //transform.position = cameraBehaver.GetMousePosition();
        moveDirection.y -= GravityPower * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        //transform.position = t;
    }
}
