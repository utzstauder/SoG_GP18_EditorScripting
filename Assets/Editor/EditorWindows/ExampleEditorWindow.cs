using UnityEditor;
using UnityEngine;

public class ExampleEditorWindow : EditorWindow
{
    bool hasFocus;
    int counter = 0;

    [MenuItem("Window/Custom Windows/Example Window")]
    public static void Init()
    {
        var window = GetWindow(typeof(ExampleEditorWindow)) as ExampleEditorWindow;

        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Hello world!", EditorStyles.boldLabel);
        GUILayout.Button("Press me", EditorStyles.miniButton);
        GUILayout.Label("Counter: " + counter);
    }

    private void Update()
    {
        if (hasFocus)
        {
            counter++;
        }
    }

    private void OnFocus()
    {
        Debug.Log("On Focus");
        hasFocus = true;
    }
    private void OnLostFocus()
    {
        Debug.Log("Lost Focus");
        hasFocus = false;
    }
}
