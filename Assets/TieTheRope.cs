using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieTheRope : MonoBehaviour
{
	//trace une ligne entre ma position et la position de ce a quoi je suis lie

	Vector3 MyPosition;
	Vector3 NextPosition;
	private void Start()
	{
		this.GetComponent<LineRenderer>().startWidth = 0.1f;
		this.GetComponent<LineRenderer>().endWidth = 0.1f;
	}
	private void Update()
	{
		MyPosition = this.transform.position;
		NextPosition = this.GetComponent<SpringJoint2D>().connectedBody.gameObject.transform.position;
		this.GetComponent<LineRenderer>().SetPosition(0, MyPosition);
		this.GetComponent<LineRenderer>().SetPosition(1, NextPosition);
		if (Input.GetKey(KeyCode.F1))
		{
			this.GetComponent<LineRenderer>().startWidth = 0.05f;
			this.GetComponent<LineRenderer>().endWidth = 0.05f;
		}
	}

}
