using System;
using UnityEngine;

[AttributeUsage (AttributeTargets.Field)]
public sealed class ButtonAttribute : PropertyAttribute
{
	public string label = "";
	public string methodName = "";
	public string indexVariableName = "";
	public GUIStyle style;

	/*public ButtonAttribute()
	{
		NoPrefixLabel = true;
	}*/

	public ButtonAttribute (string label)
	{
		this.label = label;
	}

	public ButtonAttribute (string label, string methodName) : this (label)
	{
		this.methodName = methodName;
	}

	public ButtonAttribute (string label, string methodName, string styleName) : this (label, methodName)
	{
		this.style = new GUIStyle (styleName);
	}

	public ButtonAttribute (string label, string methodName, string styleName, string indexVariableName) : this (label, methodName, styleName)
	{
		this.indexVariableName = indexVariableName;
	}
}