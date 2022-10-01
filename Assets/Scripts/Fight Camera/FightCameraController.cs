using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCameraController : MonoBehaviour
{
    [SerializeField] private GameCharactersData _charactersData;
    [SerializeField] private float _verticalOffset = 1;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _minOffset, _maxOffset;

    private Vector3 _positionOffset;
    private void Awake()
    {
        _positionOffset = new Vector3(0, _verticalOffset, 0);
    }

    private void Update()
    {

        float  offsetValue = Mathf.Clamp01(_charactersData.Distance / _maxDistance);


        _positionOffset.z = Mathf.Lerp(_minOffset, _maxOffset, offsetValue);
        transform.position = _charactersData.MidPoint + _positionOffset;
    }

}
