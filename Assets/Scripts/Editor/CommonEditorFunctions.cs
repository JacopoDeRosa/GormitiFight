using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class CommonEditorFunctions
{
    [MenuItem("GameObject/Create Divider")]
    public static void CreateDividerFunction()
    {
        GameObject div = new GameObject();
        div.SetActive(false);
        div.name = "---------- NEW DIVIDER ----------";
        Selection.activeGameObject = div;
        EditorGUIUtility.PingObject(div);
    }
}
