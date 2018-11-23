using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCubeBehaver : MonoBehaviour
{

	public float MoveSpeed;
	public GameObject Camera;
	//public Vector3 CameraPosition;
	//public Camera Camera;

	private CharacterController controller;
	private Vector3 moveDirection;
	private GameObject MainCube;
	private Vector3 MainCubePosition;
	private Renderer Renderer;

	private float zPosition;
	
	private Vector3 ScreenSize;
	private Camera Cam;
	//private Vector3 Position;

	//画面からの離れ具合
	int n = 1;

	// Use this for initialization
	void Start()
	{
		controller = GetComponent<CharacterController>();
		MainCube = GameObject.Find("MainCube");
		MainCubePosition = GameObject.Find("MainCube").transform.position;
		Renderer = GetComponent<Renderer>();
		//CameraPosition = GameObject.Find("Main Camera").transform.position;
		//Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		Cam = Camera.GetComponent<Camera>();

		Reset(true);
	}

	// Update is called once per frame
	void Update()
	{
		ScreenSize = new Vector3(Cam.orthographicSize * Screen.width / Screen.height,Cam.orthographicSize);

		//Debug.Log(Screen.width+":"+Screen.height);
		Move();
		FixZPosition();
		if(CheckOutSight()){
			Reset(true);
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
		//if (MainCube.transform.position.y - MainCube.transform.localScale.y / 2 < transform.position.y +transform.localScale.y / 2)
		{
			temp.z = 10f;
		}
		//else
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
	void Reset(bool start)
	{
		RandomColor();
		float x, y, z = -10f;
		//5画面以内に再配置
		//スタート時
		if (start)
		{
			x = Camera.transform.position.x + Random.Range(-ScreenSize.x * n, ScreenSize.x * n);
			y = Camera.transform.position.y + Random.Range(-ScreenSize.y * n, ScreenSize.y * n);
		}
		else
		{
			x = Camera.transform.position.x + ScreenSize.x * Random.Range(1, n) * (2 * Random.Range(0, 2) - 1);
			y = Camera.transform.position.y + ScreenSize.y * Random.Range(1, n) * (2 * Random.Range(0, 2) - 1);
		}
		transform.position = new Vector3(x,y,z);
	}

	//視界から遠く離れているか判定
	bool CheckOutSight() 
	{
		//下側判定
		if (transform.position.y < Camera.transform.position.y - ScreenSize.y * n * 2) //y座標 < 画面下側10倍離れている
		{
			return true;
		}
		//上側判定
		if (transform.position.y > Camera.transform.position.y + ScreenSize.y * n * 2) //y座標 > 画面上側10倍離れている
		{
			return true;
		}
		//右側判定
		if (transform.position.x > Camera.transform.position.x + ScreenSize.x * n * 2) //x座標 > 画面右側10倍離れている
		{
			return true;
		}
		//右側判定
		if (transform.position.x < Camera.transform.position.x - ScreenSize.x * n * 2) //x座標 < 画面左側10倍離れている
		{
			return true;
		}


		return false;
	}

	
}
