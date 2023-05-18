using System;
using Scenes.Scripts.Enemy;
using UnityEngine;

public class Plaer : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    public float Health => _health;

    [SerializeField] private float _damage = 30f;
    public float Damage => _damage;

    public void SetHealth(float newValue) => _health = newValue;
    
}