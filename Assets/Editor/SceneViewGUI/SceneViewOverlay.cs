using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class SceneViewOverlay : Editor
{
    static SceneViewOverlay()
    {
        Debug.Log("SceneViewOverlay constructor called!");

        SceneView.duringSceneGui += SceneView_duringSceneGui;
    }

    private static void SceneView_duringSceneGui(SceneView sceneView)
    {
        //Debug.Log("duringSceneGui");

        DrawToolbar(sceneView);
    }

    private static void DrawToolbar(SceneView sceneView)
    {
        Handles.BeginGUI();
        {
            Rect rect = new Rect(sceneView.position);
            rect.x = 0;
            rect.y = sceneView.position.height - 36;
            GUILayout.BeginArea(rect, EditorStyles.toolbar);
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Button(EditorGUIUtility.IconContent("editicon.sml"), EditorStyles.toolbarButton);
                    if (GUILayout.Button(EditorGUIUtility.IconContent("BodyPartPicker"), EditorStyles.toolbarButton))
                    {
                        SetCameraPosition(sceneView, Vector3.zero);
                    }
                    GUILayout.Button("Tool B", EditorStyles.toolbarButton);
                    GUILayout.Button("Tool C", EditorStyles.toolbarButton);
                    GUILayout.Button("Tool D", EditorStyles.toolbarButton);
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndArea();
        }
        Handles.EndGUI();
    }

    static void SetCameraPosition(SceneView sceneView, Vector3 position)
    {
        sceneView.pivot = position;   
    }
}
