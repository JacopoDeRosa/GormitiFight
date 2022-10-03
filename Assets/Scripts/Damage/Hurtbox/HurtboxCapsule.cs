using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxCapsule : MonoBehaviour
{
    [SerializeField] private float _radius, _height;

    private void OnDrawGizmosSelected()
    {
        Vector3 top = new Vector3(0, _height / 2, 0);
        Vector3 bottom = new Vector3(0, -(_height / 2), 0);
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.DrawWireSphere(top, _radius);
        Gizmos.DrawWireSphere(bottom, _radius);
        Gizmos.DrawLine(top + new Vector3(_radius, 0, 0), bottom + new Vector3(_radius, 0, 0));
        Gizmos.DrawLine(top - new Vector3(_radius, 0, 0), bottom - new Vector3(_radius, 0, 0));
        Gizmos.DrawLine(top + new Vector3(0, 0, _radius), bottom + new Vector3(0, 0, _radius));
        Gizmos.DrawLine(top - new Vector3(0, 0, _radius), bottom - new Vector3(0, 0, _radius));

        // To get the rotated position without matrix use transform.TransformPoint();
    }

    public void CheckHurtbox()
    {
        Vector3 top = new Vector3(0, _height / 2, 0);
        Vector3 bottom = new Vector3(0, -(_height / 2), 0);

        Physics.CheckCapsule(transform.TransformPoint(top), transform.TransformPoint(bottom), _radius);
    }
}
