using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaculesHead : MonoBehaviour
{
	[Header("References")]
	public LineRenderer LineRenderer;
	public Transform TargetDirection;

	[Header("")]
	public int Lenght;
	public float TargetDistance;
	public float SmoothSpeed;
	public float TailSpeed;
	Vector3[] SegmentPosition;
	Vector3[] SegmentVelocity;

	public float WindSpeed;

	void Start()
	{
		LineRenderer.positionCount = Lenght;
		SegmentPosition = new Vector3[Lenght];
		SegmentVelocity = new Vector3[Lenght];
	}

	void Update()
	{
		SegmentPosition[0] = TargetDirection.position;
		for (int i = 1; i < Lenght; i++)
		{
			var target = SegmentPosition[i - 1] + TargetDirection.right * TargetDistance;
			target += TargetDirection.up * WindSpeed * Mathf.PerlinNoise(Time.time, transform.position.x + i * 0.1f);
			SegmentPosition[i] = Vector3.SmoothDamp(SegmentPosition[i], target, ref SegmentVelocity[i], SmoothSpeed + i / TailSpeed);
		}

		LineRenderer.SetPositions(SegmentPosition);
	}
}
