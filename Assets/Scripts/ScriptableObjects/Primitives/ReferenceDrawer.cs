using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GenericReference<,>), true)]
public class ReferenceDrawer : PropertyDrawer
{
    private const float popupWidth = 20f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Draw prefix label (the field name in the inspector)
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Find sub-properties
        SerializedProperty useConstantProp = property.FindPropertyRelative("UseConstant");
        SerializedProperty constantProp = property.FindPropertyRelative("ConstantValue");
        SerializedProperty variableProp = property.FindPropertyRelative("Variable");

        // Calculate rects
        Rect fieldRect = new Rect(position.x, position.y, position.width - popupWidth, position.height);
        Rect popupRect = new Rect(position.x + position.width - popupWidth, position.y, popupWidth, position.height);

        // Draw dropdown
        int selectedIndex = useConstantProp.boolValue ? 0 : 1;
        selectedIndex = EditorGUI.Popup(popupRect, selectedIndex, new[] { "Constant", "Reference" });
        useConstantProp.boolValue = selectedIndex == 0;

        // Draw appropriate field
        if (useConstantProp.boolValue)
        {
            EditorGUI.PropertyField(fieldRect, constantProp, GUIContent.none);
        }
        else
        {
            EditorGUI.PropertyField(fieldRect, variableProp, GUIContent.none);
        }

        EditorGUI.EndProperty();
    }
}
