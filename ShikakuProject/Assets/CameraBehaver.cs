using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaver : MonoBehaviour {
    private new Camera camera;
    private Vector3 mousePosition;
    
    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
	}

    void Update () {
        
    }

    public Vector3 GetMousePosition()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 0f;
        Vector3 p = camera.ScreenToWorldPoint(mousePosition);
        Debug.Log(p);
        return p;
    }
}
