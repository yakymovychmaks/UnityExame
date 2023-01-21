using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Scripts.Menu
{
    public class MeinMenu : MonoBehaviour
    {
        public void PlayGame() => SceneManager.LoadScene("SampleScene");
        
        public void ExitGame() => Application.Quit();
    }
}
