using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxSphere : HurtboxPiece
{
    [SerializeField] private float _radius;

    private void OnDrawGizmosSelected()
    {
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Vector3.zero, _radius);
    }

    public override Collider[] CheckHurtbox(LayerMask mask)
    { 
        return Physics.OverlapSphere(transform.localPosition, _radius, mask);
    }
}
