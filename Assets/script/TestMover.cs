using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMover : MonoBehaviour
{
	public Rigidbody2D Body;
	public float Speed;
	public Camera FellowCamera;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		var dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (!Mathf.Approximately(dir.magnitude, 0))
			Body.AddForce(dir.normalized * Speed * Time.deltaTime);

		if (FellowCamera)
			FellowCamera.transform.position = new Vector3(Body.position.x, Body.position.y, FellowCamera.transform.position.z);
	}
}
