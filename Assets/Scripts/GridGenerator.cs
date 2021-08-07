using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField, Min(1)] private int _columnNumber = 3;
    [SerializeField, Range(0, 1)] private float _interсellOffset;
    [SerializeField] private Cell _cellPrefab;

    private List<List<Cell>> _grid;
    private float _rowSize;
    private float _leftColumnPosition;
    private float _currentRowPosition;
    private Vector3 _cellScale;
    private int _lastRow;

    public List<List<Cell>> Grid => _grid;
    private void Awake()
    {
        _grid = new List<List<Cell>>();
        _cellScale = _cellPrefab.transform.lossyScale;
        int offsetColumnCount = _columnNumber - 1;
        _rowSize = _cellScale.x * _columnNumber + offsetColumnCount * _interсellOffset;
        _leftColumnPosition = transform.position.x - _rowSize / 2 + _cellScale.x / 2;
        _currentRowPosition = 0f;
        _lastRow = 0;
    }

    public void AddRow()
    {
        _grid.Add(new List<Cell>());
        float currentColumnPosition = _leftColumnPosition;
        for (int j = 0; j < _columnNumber; j++)
        {
            Cell newCell = Instantiate(_cellPrefab, transform);
            newCell.transform.localPosition = new Vector2(currentColumnPosition, _currentRowPosition);
            currentColumnPosition += _cellScale.x + _interсellOffset;
            _grid[_lastRow].Add(newCell);
        }
        _currentRowPosition -= (_interсellOffset + _cellScale.y);
        _lastRow++;
    }

    public void ClearGrid()
    {
        _grid.Clear();
    }
}
