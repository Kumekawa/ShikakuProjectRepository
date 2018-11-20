using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCubeBehaver : MonoBehaviour
{

	public float MoveSpeed;
	public Vector3 CameraPosition;
	public Camera Camera;

	private CharacterController controller;
	private Vector3 moveDirection;
	private GameObject MainCube;
	private Vector3 MainCubePosition;
	private Renderer Renderer;

	private float zPosition;
	
	private Vector3 ScreenSize;

	//private Vector3 Position;

	// Use this for initialization
	void Start()
	{
		controller = GetComponent<CharacterController>();
		MainCube = GameObject.Find("MainCube");
		MainCubePosition = GameObject.Find("MainCube").transform.position;
		Renderer = GetComponent<Renderer>();
		CameraPosition = GameObject.Find("Main Camera").transform.position;
		Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update()
	{
		ScreenSize = new Vector3(Camera.orthographicSize * Screen.width / Screen.height,Camera.orthographicSize);

		Debug.Log(Screen.width+":"+Screen.height);
		Move();
		FixZPosition();
		if(CheckOutSight()){
			Reset();
		}
	}

	Vector3 MoveDirection()
	{
		return new Vector3(0f, -MoveSpeed, 0f);
	}

	void Move()
	{
		controller.Move(MoveDirection() * Time.deltaTime);
	}

	void FixZPosition()
	{
		Vector3 temp = transform.position;
		if (MainCube.transform.position.y - MainCube.transform.localScale.y / 2 < transform.position.y +transform.localScale.y / 2)
		{
			temp.z = 10f;
		}
		else
		{
			temp.z = 0f;
		}
		transform.position = temp;
	}

	void RandomColor()
	{
		Renderer.material.color = new Color(Random.value, Random.value, Random.value, 255f);
	}

	//リセット処理
	void Reset()
	{
		RandomColor();
		Vector3 temp = new Vector3(transform.position.x, CameraPosition.y + ScreenSize.y,transform.position.z);
		transform.position = temp;
	}

	//視界から遠く離れているか判定
	bool CheckOutSight() 
	{
		//下側判定


		if (transform.position.y + transform.localScale.y / 2 < CameraPosition.y - ScreenSize.y) 
		{
			return true;
		}
		return false;
	}
}
