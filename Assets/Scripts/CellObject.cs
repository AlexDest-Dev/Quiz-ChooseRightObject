using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CellObject : MonoBehaviour
{
    [SerializeField] private Vector3 _additionalRotation = new Vector3(0, 0, -90);
    private SpriteRenderer _spriteRenderer;
    private String _identifier;

    public String Identifier => _identifier;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetCellObjectData(CellObjectData data)
    {
        _spriteRenderer.sprite = data.ObjectSprite;
        _identifier = data.ObjectIdentifier;
        if (data.RotateSprite)
        {
            transform.rotation = Quaternion.Euler(_additionalRotation);
        }
    }
}