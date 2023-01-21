using UnityEngine;
using UnityEngine.Playables;

namespace Scenes.Scripts.Teleport
{
    public class Teleport : MonoBehaviour
    {
        [Header("Plaer animator Settings")]
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayableDirector _timeline;

        private bool _animationState = true;
        private Plaer _tempPlayer;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Plaer player))
            {
                _tempPlayer = player;
                _animator.SetBool("JoFinish", _animationState);

                Invoke(nameof(DestroyPlayer), 0.2f);
            }
        }

        private void DestroyPlayer()
        {
            Destroy(_tempPlayer.gameObject);
            _timeline.Play();
        }
    }
}