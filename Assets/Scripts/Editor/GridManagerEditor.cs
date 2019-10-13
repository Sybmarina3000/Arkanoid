using System.Collections;
using System.Collections.Generic;
using GridCreator;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridCreator.GridCreator))]
public class GridManagerEditor : Editor{
    // Start is called before the first frame update

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate map (in Edit Mode)"))
        {
            ((GridCreator.GridCreator) target).BuildGrid();
        }
    }
}
