using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
{
    [SerializeField] private List<HitboxArea> _areas;
    [SerializeField] private List<LimbDamageMultiplier> _limbDamageMultipliers;

    public event System.Action<float> onDamage;

    private void Awake()
    {
        foreach (var area in _areas)
        {
            area.onHit += OnAreaHit;
        }
        var damageMultipliersSet = new HashSet<LimbDamageMultiplier>(_limbDamageMultipliers);
        _limbDamageMultipliers = new List<LimbDamageMultiplier>(damageMultipliersSet);
    }
    private void OnValidate()
    {
        FindAreas();     
        if (_limbDamageMultipliers != null)
        {
            var damageMultipliersSet = new HashSet<LimbDamageMultiplier>(_limbDamageMultipliers);
            if(damageMultipliersSet.Count != _limbDamageMultipliers.Count)
            {
                Debug.LogWarning("Warning: " + gameObject.name + "'s Hitbox component contains duplicate damage multipliers," +
                    " these will be scrubbed at runtime");
            }
        }

    }

    private void FindAreas()
    {
        var areas = GetComponentsInChildren<HitboxArea>();
        _areas = new List<HitboxArea>(areas);
    }
    private void OnAreaHit(HitboxEventData data)
    {
        var damageMulti = _limbDamageMultipliers.Find(x => x.Equals(data.Bodypart));

        float multiplier = 1;

        if(damageMulti != null)
        {
            multiplier = damageMulti.Multiplier;
        }

        float damage = data.Damage * multiplier;
        onDamage?.Invoke(damage);
    }
}
