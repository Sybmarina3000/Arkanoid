using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GridCreator.GridCreator))]
    public class GridManagerEditor : UnityEditor.Editor{
        // Start is called before the first frame update
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Generate grid(in Edit Mode)"))
            {
                ((GridCreator.GridCreator) target).BuildGrid();
            }
        }
    }
}
