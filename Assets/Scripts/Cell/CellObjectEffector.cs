using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Cell
{
    public class CellObjectEffector : MonoBehaviour
    {

        [SerializeField] private ParticleSystem _particles;
        
        [Header("Right Answer Effect - Bounce")]
        [SerializeField] private float _rightEffectDuration = 1f;
        [SerializeField] private float _maxScale = 0.1f;

        [Header("Wrong Answer Effect - Shaking")] 
        [SerializeField] private float _wrongEffectDuration = 1f;
        [SerializeField] private float _strength = 1f;

        private Sequence _sequence;
        private Vector3 _initialScale;
        private AnswerChecker _answerChecker;
        private void Awake()
        {
            _answerChecker = FindObjectOfType<AnswerChecker>();
            _answerChecker.Subscribe(ApplyEffect);

            
        }

        private void ApplyEffect(bool isRightAnswer, CellObject cellObject)
        {
            Transform cellObjectTransform = cellObject.transform;
            _initialScale = cellObjectTransform.localScale;
            if (isRightAnswer)
                ApplyRightEffect(cellObjectTransform);
            else
                ApplyWrongEffect(cellObjectTransform);
        }

        private void ApplyRightEffect(Transform cellObjectTransform)
        {
            _particles.Play();
            _sequence = DOTween.Sequence();
            _sequence.Append(cellObjectTransform.DOScale(_maxScale, _rightEffectDuration))
                .Append(cellObjectTransform.DOScale(_initialScale, _rightEffectDuration));
        }

        private void ApplyWrongEffect(Transform cellObjectTransform)
        {
            Vector3 cellObjectWorldPosition = cellObjectTransform.position;
            _sequence = DOTween.Sequence();
            _sequence.Append(cellObjectTransform.DOShakePosition(_wrongEffectDuration, _strength, randomness: 0,fadeOut: true))
                .Append(cellObjectTransform.DOMove(cellObjectWorldPosition, 0));
        }
    }
}
