using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCubeBehaver : MonoBehaviour {

    public float JampPower;
    public float GravityPower;
    //public float JampTime;
    private float JampTime=2f;
    public CameraBehaver cameraBehaver;

    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 mousePosition;
    private float groundSpeed;
	private Vector3 t;

	// Use this for initialization
	void Start () {
		groundSpeed = 0;
		controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(0f, 0f, 0f);
    }
	
	// Update is called once per frame
	void Update () {

        mousePosition = Input.mousePosition;
        t = Camera.main.ScreenToWorldPoint(mousePosition);
        t.z = 0f;

		if (controller.isGrounded)
		{
			if (Input.GetMouseButton(0))
			{
				Jamp();
			}
			else
			{
				moveDirection.x = 0;
				moveDirection.y = groundSpeed;
			}
		}
		else
		{
			moveDirection.y -= GravityPower * Time.deltaTime;
		}

        controller.Move(moveDirection * Time.deltaTime);


        Debug.Log(moveDirection);
    }

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.tag == "FallingQube")
		{
			groundSpeed = -FallingCubeBehaver.MoveSpeed;
			//Debug.Log("Falling");
		}
		else
		{
			groundSpeed = 0;
			//Debug.Log("Gronud");
		}
	}

	void Jamp()
	{
		float A = transform.position.x;
		float B = transform.position.y - transform.localScale.y / 4;
		float a = t.x;
		float b = t.y;

		//float m = (A + a) / 2;
		float n = Mathf.Max(B, b) + 2f;

		float vy = Mathf.Sqrt((n - B) * 2 * GravityPower);
		JampTime = (vy + Mathf.Sqrt(2 * GravityPower * (n - b))) / GravityPower;
		float vx = (a - A) / JampTime;


		moveDirection.x = vx;
		moveDirection.y = vy;
	}
}

