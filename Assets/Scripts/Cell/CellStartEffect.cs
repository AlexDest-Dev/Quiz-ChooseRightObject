using DG.Tweening;
using UnityEngine;

namespace Cell
{
    public class CellStartEffect : MonoBehaviour
    {
        [SerializeField] private float _maxScale = 3f;
        [SerializeField] private float _duration = 0.1f;
        private Sequence _sequence;
        private Vector3 _initialScale;
        
        public void ApplyEffect()
        {
            _initialScale = transform.localScale;
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOScale(_maxScale, _duration))
                .Append(transform.DOScale(_initialScale, _duration));
        }
    }
}