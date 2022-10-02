using UnityEngine;
using System;

public class CharacterInput: IEquatable<CharacterInput>
{
    private const float inputLifetime = 0.25f;

    private string _inputName;
    private float _deathTime;

    public string Name { get => _inputName; }

    public CharacterInput(string name)
    {
        _inputName = name;
        _deathTime = Time.time + inputLifetime;
    }

    public bool ShouldDie()
    {
        return Time.time > _deathTime;
    }

    public void ResetTimer()
    {
        _deathTime = Time.time + inputLifetime;
    }

    public bool Equals(CharacterInput other)
    {
        if (other == null) return false;
        return _inputName.Equals(other.Name);
    }

    public override bool Equals(object obj)
    {
        CharacterInput other = obj as CharacterInput;
        if (other == null) return false;
        return _inputName.Equals(other.Name);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

