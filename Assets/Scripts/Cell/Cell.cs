using UnityEngine;

namespace Cell
{
    public class Cell : MonoBehaviour
    {
        private CellObject _cellObject;

        public CellObject CellObject => _cellObject;

        private void Awake()
        {
            _cellObject = GetComponentInChildren<CellObject>();
        }
    }
}