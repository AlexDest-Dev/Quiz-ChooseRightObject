using DG.Tweening;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class TextFadeEffect : MonoBehaviour, IFadeEffect
    {
        [SerializeField] private float _endValue = 1f;
        [SerializeField] private float _fadeDuration = 1f;
        private Text _taskText;

        private void Start()
        {
            _taskText = GetComponent<Text>();
            FadeIn(_endValue, _fadeDuration);
        }

        public void FadeIn()
        {
            FadeIn(_endValue, _fadeDuration);
        }

        public void FadeOut()
        {
            FadeOut(0, _fadeDuration);
        }

        public void FadeIn(float endValue, float duration)
        {
            _taskText.DOFade(endValue, duration);
        }

        public void FadeOut(float endValue, float duration)
        {
            _taskText.DOFade(endValue, duration);
        }
    }
}
