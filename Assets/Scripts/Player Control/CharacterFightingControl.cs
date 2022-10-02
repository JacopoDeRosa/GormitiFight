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
        _activeInputs = new List<CharacterInput>();
    }

    private void Start()
    {
        _input = FindObjectOfType<PlayerInput>();

        if (_input)
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
        SetTrigger("Heavy Attack");
    }

    private void OnLightAttackStart(InputAction.CallbackContext context)
    {
        SetTrigger("Light Attack");
    }

    private void OnParryStart(InputAction.CallbackContext context)
    {
        SetTrigger("Parry");
    }

    private void OnJumpStart(InputAction.CallbackContext context)
    {
        SetTrigger("Jump");
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        UpdateActiveInputs();
        SmoothInput();
        SendMoveInput();

    }

    private void SmoothInput()
    {
        _actualHardness = Mathf.Clamp01(_inputHardness * Time.deltaTime);
        _smoothMoveInput = Vector2.Lerp(_smoothMoveInput, _moveInput, _actualHardness);
    }

    private void SendMoveInput()
    {
        _animator.SetFloat("Horizontal Speed", _smoothMoveInput.x);
        _animator.SetFloat("Vertical Speed", _smoothMoveInput.y);
    }

    private void UpdateActiveInputs()
    {
        List<CharacterInput> toRemove = new List<CharacterInput>();
        foreach (CharacterInput input in _activeInputs)
        {
            if (input.ShouldDie())
            {
                toRemove.Add(input);
            }
        }

        foreach (CharacterInput input in toRemove)
        {
            _activeInputs.Remove(input);
            _animator.ResetTrigger(input.Name);
        }

    }

    private bool GetActiveInput(string name, out CharacterInput input)
    {
        input = _activeInputs.Find(input => input.Name.Equals(name));
        if (input == null)
        {
            return false;
        }
        return true;
    }

    private void SetTrigger(string name)
    {
        _animator.SetTrigger(name);
        if (GetActiveInput(name, out CharacterInput input))
        {
            input.ResetTimer();
        }
        else
        {
            _activeInputs.Add(new CharacterInput(name));
        }
    }
}
