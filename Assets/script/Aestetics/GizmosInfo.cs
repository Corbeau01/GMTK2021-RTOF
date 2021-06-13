using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosInfo : MonoBehaviour
{
	public BoxCollider2D Collider2D;
	public Color Color;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color;
		Gizmos.DrawCube(Collider2D.transform.position, new Vector3(Collider2D.size.x * transform.lossyScale.x, Collider2D.size.y * transform.lossyScale.y, 1));
	}
}
