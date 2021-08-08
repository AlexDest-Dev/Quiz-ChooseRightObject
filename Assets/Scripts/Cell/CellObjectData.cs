using System;
using UnityEngine;

namespace Cell
{
    [Serializable]
    public class CellObjectData
    {
        [SerializeField] private Sprite _objectSprite;
        [SerializeField] private string _objectIdentifier;
        [SerializeField] private bool _rotateSprite;

        public Sprite ObjectSprite => _objectSprite;
        public string ObjectIdentifier => _objectIdentifier;
        public bool RotateSprite => _rotateSprite;
    }
}