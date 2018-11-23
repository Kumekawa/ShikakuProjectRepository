using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaver : MonoBehaviour {
    private new Camera camera;
    private Vector3 mousePosition;
	public GameObject PlayerPosition;
	public float offset;
	private Vector3 ScreenSize;
	private Camera Cam;

	private float left;
	private float right;
	private float top;
	private float bottom;
	private float xOffset;
	private float yOffset;


	// Use this for initialization
	void Start () {
		//PlayerPosition = GameObject.Find("MainCube");
		Cam = GetComponent<Camera>();
	}

    void Update () {

		SetMax();
		FixPosition();

		//Debug.Log(PlayerPosition);
    }

	void SetMax()
	{
		ScreenSize = new Vector3(Cam.orthographicSize * Screen.width / Screen.height, Cam.orthographicSize);

		xOffset = ScreenSize.x - offset;
		yOffset = ScreenSize.y - offset;

		left = transform.position.x - xOffset;
		right = transform.position.x + xOffset;
		top = transform.position.y + yOffset;
		bottom = transform.position.y - yOffset;
	}

	void FixPosition()
	{
		Vector3 CubePosition = PlayerPosition.transform.position;
		Vector3 temp = transform.position;
		temp.z = -10f;

		if (CubePosition.x < left)
		{
			temp.x = CubePosition.x + xOffset;
		}
		if (CubePosition.x > right)
		{
			temp.x = CubePosition.x - xOffset;
		}
		if (CubePosition.y > top)
		{
			temp.y = CubePosition.y - yOffset;
		}
		if (CubePosition.y < bottom)
		{
			temp.y = CubePosition.y + yOffset;
		}

		transform.position = temp;
	}


	//public Vector3 GetMousePosition()
	//{
	//    mousePosition = Input.mousePosition;
	//    mousePosition.z = 0f;
	//    Vector3 p = camera.ScreenToWorldPoint(mousePosition);
	//    Debug.Log(p);
	//    return p;
	//}
}
