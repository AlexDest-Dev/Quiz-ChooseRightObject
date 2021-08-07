using System;
using UnityEngine;

[Serializable]
public class CellObjectData
{
    [SerializeField] private Sprite _objectSprite;
    [SerializeField] private String _objectIdentifier;
    [SerializeField] private bool _rotateSprite;

    public Sprite ObjectSprite => _objectSprite;
    public string ObjectIdentifier => _objectIdentifier;
    public bool RotateSprite => _rotateSprite;
}