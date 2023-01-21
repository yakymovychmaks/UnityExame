using UnityEngine;
using TMPro;

namespace Scenes.Scripts.Dialogue
{
    public class MovementButtons : MonoBehaviour
    {
        [SerializeField] private KeyCodes _keyCodes;
        [SerializeField] private TextMeshProUGUI _keyLeft;
        [SerializeField] private TextMeshProUGUI _keyRight;
        [SerializeField] private TextMeshProUGUI _keyUp;

        private void Update() => UpdateKeys();

        private void UpdateKeys()
        {
            _keyLeft.text = _keyCodes.PlayerKeyLeft.ToString();
            _keyRight.text = _keyCodes.PlayerKeyRight.ToString();
            _keyUp.text = _keyCodes.PlayerKeyUp.ToString();
        }
    }
}