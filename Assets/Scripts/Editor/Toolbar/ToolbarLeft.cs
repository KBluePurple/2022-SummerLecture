using System.Linq;
using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;
using UnityToolbarExtender;
using System.IO;

[InitializeOnLoad]
public static class ToolbarLeft
{
    static ToolbarLeft()
    {
        ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
    }

    static void OnToolbarGUI()
    {
        GUIContent content = new (EditorSceneManager.GetActiveScene().name);
        
        Rect dropdownRect = new Rect(5, 0, 150, 20);
        if (EditorGUI.DropdownButton(dropdownRect, content, FocusType.Keyboard, EditorStyles.toolbarDropDown))
        {
            GenericMenu menu = new GenericMenu();
            var scenes = EditorBuildSettings.scenes;
            foreach (var scene in scenes)
            {
                if (scene.enabled)
                {
                    menu.AddItem(new GUIContent(Path.GetFileNameWithoutExtension(scene.path)), false, () =>
                    {
                        EditorSceneManager.OpenScene(scene.path);
                    });
                }
            }
            menu.DropDown(dropdownRect);
        }
    }
}
