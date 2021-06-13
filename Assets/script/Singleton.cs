using UnityEngine;

public class Singleton<TSelf> : MonoBehaviour where TSelf : Singleton<TSelf>
{
	static TSelf instance;

	public static TSelf Instance
	{
		get
		{
			if (instance == null) instance = FindObjectOfType<TSelf>();
			if (instance == null)
			{
				var prefab = Resources.Load<TSelf>($"Managers/{typeof(TSelf).Name}");
				instance = GameObject.Instantiate(prefab);
				var parent = GameObject.Find("Managers");
				if (parent != null)
					instance.transform.parent = parent.transform;
			}
			return instance;
		}
	}

	protected virtual void Awake()
	{
		if (instance != null)
			Destroy(gameObject);
		instance = this as TSelf;
	}
}