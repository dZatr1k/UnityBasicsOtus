using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Scripts;
using TMPro;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Character _owner;
    [SerializeField] private TextMeshProUGUI _text;

    private Health _health;


    private void OnEnable()
    {
        _health = _owner.Health;
        _health.OnChanged += OnHealthChanged;

        OnHealthChanged(_health.Current, _health.Max);
    }

    private void OnDisable()
    {
        _health.OnChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int current, int max)
    {
        _text.text = string.Format($"{current}/{max}");
    }
}
