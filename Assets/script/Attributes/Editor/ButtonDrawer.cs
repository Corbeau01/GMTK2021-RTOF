using System.Reflection;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomPropertyDrawer (typeof (ButtonAttribute))]
public class ButtonDrawer : PropertyDrawer
{
	protected Rect currentPosition;

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		currentPosition = position;

		if (property.propertyType == SerializedPropertyType.Boolean)
		{
			string buttonLabel = string.IsNullOrEmpty (((ButtonAttribute) attribute).label) ? label.text : ((ButtonAttribute) attribute).label;
			string buttonPressedMethodName = string.IsNullOrEmpty (((ButtonAttribute) attribute).methodName) ? label.text.Replace (" ", "").Replace ("_", "") /*.Capitalized()*/ : ((ButtonAttribute) attribute).methodName;
			string buttonIndexVariableName = ((ButtonAttribute) attribute).indexVariableName;
			GUIStyle buttonStyle = ((ButtonAttribute) attribute).style;
			//currentPosition = EditorGUI.IndentedRect(currentPosition);

			//if (noFieldLabel) buttonLabel = "";

			bool pressed = GUI.Button (currentPosition, buttonLabel);

			if (pressed)
			{
				//if (!string.IsNullOrEmpty(buttonIndexVariableName))
				//	property.serializedObject.FindProperty(buttonIndexVariableName).intValue = index;

				if (!string.IsNullOrEmpty (buttonPressedMethodName))
				{
					BindingFlags AllFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy;
					MethodInfo method = property.serializedObject.targetObject.GetType ().GetMethod (buttonPressedMethodName, AllFlags);

					if (method != null)
						method.Invoke (property.serializedObject.targetObject, null);
				}

				EditorUtility.SetDirty (property.serializedObject.targetObject);
			}
			property.boolValue = pressed;
		}
		else
			EditorGUILayout.LabelField ("Button variable must be of type boolean.");

	}
}
#endif