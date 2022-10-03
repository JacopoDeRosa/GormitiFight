using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxController : MonoBehaviour
{
    [SerializeField] private Hurtbox[] _hurtboxes;
    [SerializeField] private LayerMask _checkMask;

    public void CheckHurtbox(int index)
    {
        _hurtboxes[index].CheckPieces(_checkMask);
    }
}
