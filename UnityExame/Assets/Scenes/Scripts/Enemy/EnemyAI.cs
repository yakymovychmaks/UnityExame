using UnityEngine;

namespace Scenes.Scripts.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private Plaer _player;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _startFollowDistance = 7f;
        [SerializeField] private float _endFollowDistance = 2f;
        [SerializeField] private KeyCodes _keyCodes;

        private Enemy _enemy;
        private float _distance;
        private float _timerForNextAttack;
        private float _cooldown = 3f;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _timerForNextAttack = _cooldown;
        }

        private void FixedUpdate()
        {
            if (!_player)
                return;
            
            // Calculate distance to player
            _distance = Vector2.Distance(transform.position, _player.transform.position);
            Vector2 direction = _player.transform.position - transform.position;
            direction.Normalize();
        
            // Movement and rotation
            if (_distance < _startFollowDistance && _distance > _endFollowDistance)
            {
                MoveTowardsTarget();
                RotateTowardsTarget();
            }
        
            // Attacking with cooldown
            if (_timerForNextAttack > 0)
                _timerForNextAttack -= Time.fixedDeltaTime;
            else if (_timerForNextAttack <= 0)
            {
                // When close enough
                if (_distance <= _endFollowDistance)
                {
                    PrepareForAttack();
                    _timerForNextAttack = _cooldown;
                }
            }
        }
        
        private void MoveTowardsTarget()
        {
            transform.position =
                Vector2.MoveTowards(transform.position, _player.transform.position,
                    _speed * Time.fixedDeltaTime);
        }
        
        private void RotateTowardsTarget()
        {
            Vector3 scale = transform.localScale;
        
            if (_player.transform.position.x > transform.position.x)
                scale.x = Mathf.Abs(scale.x);
            else
                scale.x = Mathf.Abs(scale.x) * -1;
        
            transform.localScale = scale;
        }
        
        private void PrepareForAttack()
        {
            int delay = Random.Range(0, 2);
            Invoke(nameof(Attack), delay);
        }
        
        private void Attack()
        {
            if (_player.Health > 0 && _distance <= _endFollowDistance)
            {
                _player.SetHealth(_player.Health - _enemy.Damage);
                ChangeMovementInputs();
            }
        }
        
        private void ChangeMovementInputs()
        {
            if (_player.Health <= 30)
            {
                _keyCodes.SetMoveLeft(KeyCode.J);
                _keyCodes.SetMoveRight(KeyCode.L);
                _keyCodes.SetMoveUp(KeyCode.K);
            }
            else if (_player.Health <= 60)
            {
                _keyCodes.SetMoveLeft(KeyCode.Z);
                _keyCodes.SetMoveRight(KeyCode.C);
                _keyCodes.SetMoveUp(KeyCode.X);
            }
            else if (_player.Health == 100)
            {
                _keyCodes.DefaultKeys();
            }
        }
    }
}