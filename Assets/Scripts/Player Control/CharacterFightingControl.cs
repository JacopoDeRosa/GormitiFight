using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterFightingControl : MonoBehaviour
{
    [SerializeField] private float _inputHardness = 1;

    private Animator _animator;

    private PlayerInput _input;
    private Vector2 _moveInput;
    private Vector2 _smoothMoveInput;
    private float _actualHardness;

    private List<CharacterInput> _activeInputs;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _input = FindObjectOfType<PlayerInput>();

        if(_input)
        {
            _input.actions["Heavy Attack"].started += OnHeavyAttackStart;
            _input.actions["Light Attack"].started += OnLightAttackStart;
            _input.actions["Parry"].started += OnParryStart;
            _input.actions["Jump"].started += OnJumpStart;
            _input.actions["Move"].performed += OnMove;
        }
    }

    private void OnHeavyAttackStart(InputAction.CallbackContext context)
    {
        Debug.Log("Heavy Attack");
    }

    private void OnLightAttackStart(InputAction.CallbackContext context)
    {
        Debug.Log("Light Attack");
        _animator.SetTrigger("Light Attack");
    }

    private void OnParryStart(InputAction.CallbackContext context)
    {
        Debug.Log("Parry");
    }

    private void OnJumpStart(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        _animator.SetTrigger("Jump");
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        _actualHardness = Mathf.Clamp01(_inputHardness * Time.deltaTime);
        _smoothMoveInput = Vector2.Lerp(_smoothMoveInput, _moveInput, _actualHardness);
        _animator.SetFloat("Horizontal Speed", _smoothMoveInput.x);
        _animator.SetFloat("Vertical Speed", _smoothMoveInput.y);
    }
}
