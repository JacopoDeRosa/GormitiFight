using UnityEngine;


public class CharacterInput
{
    private const float inputLifetime = 0.25f;

    private string _inputName;
    private float _deathTime;

    public string InputName { get => _inputName; }

    public CharacterInput(string name)
    {
        _inputName = name;
        _deathTime = Time.time + inputLifetime;
    }

    public bool ShouldDie()
    {
        return Time.deltaTime > _deathTime;
    }
}

