using System;
using UnityEngine;

namespace Scenes.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _health = 100f;
        public float Health => _health;

        [SerializeField] private float _damage = 20f;
        public float Damage => _damage;

        [SerializeField] private float _explosionDamage = 30f;
        public float ExplosionDamage => _explosionDamage;

        [SerializeField] private ParticleSystem _explosionEffect;

        private readonly float _explosionOffset = 7f;

        private void Start() => _explosionEffect.Stop();

        [Obsolete("Obsolete")]
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                Plaer player = col.gameObject.GetComponent<Plaer>();
                player.SetHealth(player.Health - ExplosionDamage);

                Destroy(this.gameObject, _explosionEffect.duration / Mathf.Abs(_explosionOffset));
                
                if (!_explosionEffect.isPlaying)
                    _explosionEffect.Play();
            }
        }
    }
}