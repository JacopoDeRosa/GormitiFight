using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hurtbox
{
#if UNITY_EDITOR
    [SerializeField] private string _name;

    /// <summary>
    /// Editor Only Function
    /// </summary>
    /// <param name="name"></param>
    public void SetName(string name)
    {
        _name = name;
    }
#endif

    [SerializeField] private HurtboxPiece[] _pieces;

    public void CheckPieces(LayerMask mask)
    {
        foreach (HurtboxPiece piece in _pieces)
        {
          Debug.Log(piece.CheckHurtbox(mask).Length);
        }
    }
}
