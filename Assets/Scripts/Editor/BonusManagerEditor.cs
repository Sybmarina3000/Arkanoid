using System;
using System.Collections;
using System.Collections.Generic;
using GameEntities.Bonus;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(BonusManager))]
public class BonusManagerEditor : UnityEditor.Editor
{
    private SerializedProperty ColorMass;
    private int _needCount;

    private BonusManager _component;
    private void OnEnable() {
        ColorMass = serializedObject.FindProperty("_BonusColors");
        
        _needCount = Enum.GetValues(typeof(BonusType)).Length ;
        _component = (BonusManager)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        if (ColorMass.arraySize != _needCount * _needCount)
            ChangeMass();
        
  
        EditorGUILayout.LabelField(" BONUS COLOR");
        
        for (int i = 0; i < _needCount; i++)
        {
            var yach = ColorMass.GetArrayElementAtIndex(i);
            yach.colorValue =  EditorGUILayout.ColorField( ((BonusType) i).ToString(), yach.colorValue);
        }
        
        serializedObject.ApplyModifiedProperties();
    }
    
    private void ChangeMass() {
        ColorMass.arraySize = _needCount* _needCount;      
    }
}
