using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TentaculesGroup : MonoBehaviour
{
	public GameObject Prefab;
	public int Amount;
	public float Spacing;
	public Vector2Int HeadsLenghts;
	public Vector2 HeadsDistances;

	private bool doUpdate;
	private void OnValidate()
	{
		if (!Application.isPlaying)
			doUpdate = true;
	}

	private void Update()
	{
		if (!doUpdate)
			return;

		doUpdate = false;

		if (Amount <= 0)
			Amount = 1;

		for (int i = transform.childCount; i < Amount; i++)
		{
			var kid = Instantiate(Prefab);
			kid.transform.parent = transform;
		}

		for (int i = transform.childCount - 1; i >= Amount; i--)
		{
			DestroyImmediate(transform.GetChild(i).gameObject);
		}

		for (int x = 0; x < Amount; x++)
		{
			var trans = transform.GetChild(x);
			trans.transform.localPosition = new Vector3(Spacing * x, 0, 0);
			var head = trans.GetComponent<TentaculesHead>();
			head.Lenght = Random.Range(HeadsLenghts.x, HeadsLenghts.y + 1);
			head.TargetDistance = Random.Range(HeadsDistances.x, HeadsDistances.y);
		}
	}
}
