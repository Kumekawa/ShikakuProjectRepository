using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCubeBehaver : MonoBehaviour
{

	public float MoveSpeed;

	private CharacterController controller;
	private Vector3 moveDirection;
	private GameObject MainCube;
	private Vector3 MainCubePosition;
	private Renderer Renderer;

	private float zPosition;

	// Use this for initialization
	void Start()
	{
		controller = GetComponent<CharacterController>();
		MainCube = GameObject.Find("MainCube");
		MainCubePosition = GameObject.Find("MainCube").transform.position;
		Renderer = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update()
	{
		Move();
		FixZPosition();
		RandomColor();
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

	void RandomColor(){
		Renderer.material.color = new Color(Random.value, Random.value, Random.value, 255f);
	}
}
