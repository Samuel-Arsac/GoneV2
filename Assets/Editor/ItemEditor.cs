using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        
    }
}
