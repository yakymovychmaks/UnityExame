using System.Collections;
using UnityEngine;
using TMPro;

namespace Scenes.Scripts.Dialogue
{
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textComponent;
        [SerializeField] private string[] _lines;
        [SerializeField] private float _textSpeed = 0.1f;

        private int _index;

        private void Start()
        {
            _textComponent.text = string.Empty;

            StartDialogue();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_textComponent.text == _lines[_index])
                    NextLine();
                else
                {
                    StopAllCoroutines();
                    _textComponent.text = _lines[_index];
                }
            }
        }

        private void StartDialogue()
        {
            _index = 0;
            StartCoroutine(TypeLine());
        }

        IEnumerator TypeLine()
        {
            foreach (char item in _lines[_index].ToCharArray())
            {
                _textComponent.text += item;
                yield return new WaitForSeconds(_textSpeed);
            }
        }

        private void NextLine()
        {
            if (_index < _lines.Length - 1)
            {
                _index++;
                _textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
                gameObject.SetActive(false);
        }
    }
}