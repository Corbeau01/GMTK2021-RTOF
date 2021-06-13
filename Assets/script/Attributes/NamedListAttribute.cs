using System;
using UnityEngine;

public class NamedListAttribute : PropertyAttribute
{
	public readonly string[] names;
	public NamedListAttribute(string[] names) { this.names = names; }

	public NamedListAttribute(Type enumerable)
	{
		if (enumerable.BaseType == typeof(Enum))
			names = Enum.GetNames(enumerable);
		else
			Debug.LogError("NamedList used with a not enum type.");
	}
}
