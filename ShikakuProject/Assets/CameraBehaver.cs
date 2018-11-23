using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaver : MonoBehaviour {
    private new Camera camera;
    private Vector3 mousePosition;
	public GameObject PlayerPosition;

    // Use this for initialization
    void Start () {
        //PlayerPosition = GameObject.Find("MainCube");
	}

    void Update () {
		Vector3 temp = PlayerPosition.transform.position;
		temp.z = -10f;
		transform.position = temp;
		Debug.Log(PlayerPosition);
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
