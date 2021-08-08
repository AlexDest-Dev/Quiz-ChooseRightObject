using DG.Tweening;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class LoadScreenFadeEffect : MonoBehaviour, IFadeEffect
    {
        [SerializeField] private float _duration = 1f;

        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
        }

        public void FadeIn()
        {
            FadeIn(1, _duration);
        }

        public void FadeOut()
        {
            FadeOut(0, _duration);
        }

        public void FadeIn(float endValue, float duration)
        {
            _image.DOFade(endValue, duration);
        }

        public void FadeOut(float endValue, float duration)
        {
            _image.DOFade(endValue, duration);
        }
    }
}
