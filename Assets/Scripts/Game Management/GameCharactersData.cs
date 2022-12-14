using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharactersData : MonoBehaviour
{
    [SerializeField] private Transform _characterA, _characterB;

    public float Distance { get; private set; }
    public Vector3 MidPoint { get; private set; }

    private void Update()
    {
        Distance = Vector3.Distance(_characterA.position, _characterB.position);
        MidPoint = _characterA.position + (_characterB.position - _characterA.position) / 2;
    }

#if UNITY_EDITOR
    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(25, 25, 300, 300), Distance.ToString() + "m", style);
    }
    private void OnDrawGizmos()
    {
        if (MidPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(MidPoint, 0.25f);
        }
    }
#endif
}
