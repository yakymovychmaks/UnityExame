using UnityEngine;

namespace Scenes.Scripts
{
    public class KeyCodes : MonoBehaviour
    {
        [Header("Player Keycodes")] [SerializeField]
        private KeyCode _playerKeyLeft = KeyCode.A;

        public KeyCode PlayerKeyLeft => _playerKeyLeft;

        [SerializeField] private KeyCode _playerKeyRight = KeyCode.D;
        public KeyCode PlayerKeyRight => _playerKeyRight;

        [SerializeField] private KeyCode _playerKeyUp = KeyCode.Space;
        public KeyCode PlayerKeyUp => _playerKeyUp;

        public void SetMoveLeft(KeyCode newKey) => _playerKeyLeft = newKey;
        public void SetMoveRight(KeyCode newKey) => _playerKeyRight = newKey;
        public void SetMoveUp(KeyCode newKey) => _playerKeyUp = newKey;

        public void DefaultKeys()
        {
            this.SetMoveLeft(KeyCode.A);
            this.SetMoveRight(KeyCode.D);
            this.SetMoveUp(KeyCode.Space);
        }
    }
}