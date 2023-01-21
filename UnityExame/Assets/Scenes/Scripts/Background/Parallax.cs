using UnityEngine;

namespace Scenes.Scripts.Background
{
    public class Parallax : MonoBehaviour
    {
        private float _startPosition, _length;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _parallaxEffect;

        private void Start()
        {
            _startPosition = transform.position.x;
            _length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void FixedUpdate()
        {
            float distanceFromStartPosition = (_camera.transform.position.x * _parallaxEffect);
            transform.position = new Vector3(_startPosition + distanceFromStartPosition, transform.position.y,
                transform.position.z);

            float temp = (_camera.transform.position.x * (1 - _parallaxEffect));
            if (temp > _startPosition + _length)
                _startPosition += _length;
            else if (temp < _startPosition - _length)
                _startPosition -= _length;
        }
    }
}