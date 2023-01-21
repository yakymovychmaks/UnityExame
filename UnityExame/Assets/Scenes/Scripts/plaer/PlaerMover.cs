using UnityEngine;

namespace Scenes.Scripts.plaer
{
    public class PlaerMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 9f;
        [SerializeField] private float _jumpForce = 3.5f;
        [SerializeField] private Vector3 _groundCheckOffSet;
        [SerializeField] [Range(-5f, 50f)] private float _checkGroundOffSetY = -0.65f;
        [SerializeField] [Range(0, 150f)] private float _checkGroundRadius = 0.3f;
        [SerializeField] private KeyCodes _keyCodes;

        private Vector3 _moveDirection;
        private bool _feisingRite = true;
        public bool _isGrounded = false;
        private int _checkMove = 0;

        [Header("Plaer animator Settings")] [SerializeField]
        private Animator _animator;

        
        private void Update()
        {
            _animator.SetFloat("HorizontalMove", _checkMove);
            CheckGround();

            if (_isGrounded && Input.GetKeyDown(_keyCodes.PlayerKeyUp))
                Jump();

            // animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));

            // if(isGrounded == false)
            // {
            //     animator.SetBool("Jumping", true);
            // }
            // else
            // {
            //     animator.SetBool("Jumping", false); 
            // }

            SpeedControl();
        }

        private void FixedUpdate() => MovePlayer();

        private void Flip(bool direction)
        {
            _feisingRite = !_feisingRite;
            transform.GetComponent<SpriteRenderer>().flipX = direction;
        }

        private void CheckGround()
        {
            Collider2D[] colliders =
                Physics2D.OverlapCircleAll(
                    new Vector2(transform.position.x, transform.position.y + _checkGroundOffSetY),
                    _checkGroundRadius);

            if (colliders.Length > 1)
                _isGrounded = true;
            else
                _isGrounded = false;
        }

        private void Jump() => _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);

        private void MovePlayer()
        {
            if (Input.GetKey(_keyCodes.PlayerKeyLeft))
            {
                _moveDirection = -transform.right * _speed;
                Flip(true);
                _checkMove = 1;
            }
            else if (Input.GetKey(_keyCodes.PlayerKeyRight))
            {
                _moveDirection = transform.right * _speed;
                Flip(false);
                _checkMove = 1;
            }
            else
            {
                _moveDirection = Vector2.zero;
                _rb.velocity = new Vector2(0f, _rb.velocity.y);
                _checkMove = 0;
            }

            _rb.AddForce(_moveDirection.normalized * _speed, ForceMode2D.Force);
        }

        private void SpeedControl()
        {
            Vector2 flatVel = new Vector2(_rb.velocity.x, 0f);

            if (flatVel.magnitude > _speed / 2)
            {
                Vector2 limitedVel = flatVel.normalized * _speed / 2;
                _rb.velocity = new Vector2(limitedVel.x, _rb.velocity.y);
            }
        }
    }
}