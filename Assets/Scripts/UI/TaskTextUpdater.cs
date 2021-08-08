using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class TaskTextUpdater : MonoBehaviour
    {
        [SerializeField] private string _taskPart = "Find";
        private Text _taskText;
        private LevelChanger _levelChanger;
        private RandomCellObjectsGenerator _generator;

        private void Awake()
        {
            _taskText = GetComponent<Text>();
            _generator = FindObjectOfType<RandomCellObjectsGenerator>();
        
            _levelChanger = FindObjectOfType<LevelChanger>();
            _levelChanger.LevelChangedEvent.AddListener(UpdateText);
        }

        private void UpdateText()
        {
            _taskText.text = _taskPart + " " + _generator.CurrentRightAnswer.ObjectIdentifier;
        }
    }
}
