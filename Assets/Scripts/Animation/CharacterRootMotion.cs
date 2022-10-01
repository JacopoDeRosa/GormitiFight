using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRootMotion : MonoBehaviour
{
    [SerializeField]
    private bool _allowDepthMovement;
    [SerializeField]
    private bool _allowRootRotation;

    private Animator _animator;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorMove()
    {
        if (_allowDepthMovement)
        {
            transform.position = _animator.rootPosition;
        }
        else
        {
            Vector3 rootPosChanged = _animator.rootPosition;
            rootPosChanged.z = 0;
            transform.position = rootPosChanged;
        }

        if(_allowRootRotation)
        {
            transform.rotation = _animator.rootRotation;
        }
    }

}