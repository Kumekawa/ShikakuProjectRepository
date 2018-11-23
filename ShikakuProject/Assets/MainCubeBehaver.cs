using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCubeBehaver : MonoBehaviour {

    public float JampPower;
    public float GravityPower;
    //public float JampTime;
    private float JampTime=2f;
    public CameraBehaver cameraBehaver;
	public float MaxSpeed;

    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 mousePosition;
    

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(0f, 0f, 0f);
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

        moveDirection.y -= GravityPower * Time.deltaTime;
		moveDirection.y = Mathf.Max(moveDirection.y, -MaxSpeed);
		//Debug.Log(moveDirection.y);

        controller.Move(moveDirection * Time.deltaTime);
        if (controller.isGrounded)
        {
            moveDirection.x = 0;
            moveDirection.y = 0;
        }


        //Debug.Log(moveDirection);
    }

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		var name = hit.gameObject.name;

		Debug.Log(name);
	}
}
