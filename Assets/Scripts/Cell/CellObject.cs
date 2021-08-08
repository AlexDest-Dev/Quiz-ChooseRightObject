using UnityEngine;

namespace Cell
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CellObject : MonoBehaviour
    {
        [SerializeField] private Vector3 _additionalRotation = new Vector3(0, 0, -90);
        private SpriteRenderer _spriteRenderer;
        private string _identifier;

        public string Identifier => _identifier;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetCellObjectData(CellObjectData data)
        {
            _spriteRenderer.sprite = data.ObjectSprite;
            _identifier = data.ObjectIdentifier;
            if (data.RotateSprite)
                transform.localRotation = Quaternion.Euler(_additionalRotation);
            else
                transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }
}