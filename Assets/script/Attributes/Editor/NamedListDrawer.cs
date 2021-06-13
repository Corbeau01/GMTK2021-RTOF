#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

public abstract class NamedListDrawerBase : PropertyDrawer
{
	protected virtual NamedListAttribute Attribute { get { return (NamedListAttribute)attribute; } }

	protected abstract void CreateField(Rect position, SerializedProperty property, GUIContent label, string name);

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return EditorGUI.GetPropertyHeight(property, label, true);
	}

	public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
	{
		var errorStyle = new GUIStyle();
		errorStyle.normal.textColor = new Color(1f, 0f, 0f);

		if (Attribute.names == null || Attribute.names.Length == 0)
			EditorGUI.LabelField(rect, property.displayName, "NamedList used with an empty array or with a not array type.", errorStyle);
		else if (property.propertyPath.Contains("[") && property.propertyPath.Contains("]"))
		{
			var elements = property.propertyPath.Split('[', ']');
			var pos = int.Parse(elements[elements.Length - 2]);
			var name = "???";
			if(pos < Attribute.names.Length)
				name = Attribute.names[pos % Attribute.names.Length];
			CreateField(rect, property, label, name);
		}
		else
			EditorGUI.LabelField(rect, property.displayName, "Use NamedList with arrays.", errorStyle);
	}
}

[CustomPropertyDrawer(typeof(NamedListAttribute))]
public class NamedListDrawer : NamedListDrawerBase
{
	protected override void CreateField(Rect rect, SerializedProperty property, GUIContent label, string name)
	{
		EditorGUI.PropertyField(rect, property, new GUIContent(name, label.tooltip), true);
	}
}
#endif