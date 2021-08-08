using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class RestartButtonEnabler : MonoBehaviour
    {
        private Button _button;
        private LevelChanger _levelChanger;


        private void Awake()
        {
            _levelChanger = FindObjectOfType<LevelChanger>();
            _levelChanger.LevelFinishedEvent.AddListener(EnableButton);
        }
        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(DisableButton);
            DisableButton();
        }

        private void EnableButton()
        {
            _button.gameObject.SetActive(true);
        }

        private void DisableButton()
        {
            _button.gameObject.SetActive(false);
        }
    }
}
