using UnityEngine;

namespace Cell
{
    public class CellCreator : MonoBehaviour
    {
        [SerializeField] private Cell _cellPrefab;
        private bool _applyStartEffect;

        public Cell CellPrefab => _cellPrefab;
        
        public Cell CreateNewCell(Transform parent)
        {
            Cell cell = Instantiate(_cellPrefab, parent);
            if (_applyStartEffect)
            {
                cell.GetComponent<CellStartEffect>().ApplyEffect();
            }

            return cell;
        }

        public void EnableStartEffect() => _applyStartEffect = true;
        public void DisableStartEffect() => _applyStartEffect = false;
    }
}