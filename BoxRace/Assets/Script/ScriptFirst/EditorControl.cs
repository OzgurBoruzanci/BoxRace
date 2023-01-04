using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class EditorControl : MonoBehaviour
{
    public GameObject cube;
    public GameObject cubes;

}
#if UNITY_EDITOR
[CustomEditor(typeof(EditorControl))]
[System.Serializable]
class EditorControlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorControl script = (EditorControl)target;

        if (GUILayout.Button("ProduceCube", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {

            GameObject newObject = Instantiate(script.cube);
            newObject.transform.position = new Vector3(script.transform.position.x, script.transform.position.y + 0.2f, script.transform.position.z + 1);
            newObject.name = "newCube";
            newObject.transform.parent = script.cubes.transform;


        }
    }
}
#endif
