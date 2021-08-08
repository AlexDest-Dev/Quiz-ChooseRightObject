using System;
using System.Collections;
using System.Collections.Generic;
using Cell;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField, Min(1)] private int _columnNumber = 3;
    [SerializeField, Range(0, 1)] private float _interсellOffset;

    private List<List<Cell.Cell>> _grid;
    private float _rowSize;
    private float _leftColumnPosition;
    private float _currentRowPosition;
    private Vector3 _cellScale;
    private int _lastRow;
    private CellCreator _cellCreator;

    public List<List<Cell.Cell>> Grid => _grid;
    private void Awake()
    {
        _grid = new List<List<Cell.Cell>>();
        
        _cellCreator = FindObjectOfType<CellCreator>();
        _cellScale = _cellCreator.CellPrefab.transform.lossyScale;
        
        int offsetColumnCount = _columnNumber - 1;
        _rowSize = _cellScale.x * _columnNumber + offsetColumnCount * _interсellOffset;
        _leftColumnPosition = transform.position.x - _rowSize / 2 + _cellScale.x / 2;
        _currentRowPosition = 0f;
        _lastRow = 0;
    }

    public void AddRow()
    {
        _grid.Add(new List<Cell.Cell>());
        
        float currentColumnPosition = _leftColumnPosition;
        
        for (int j = 0; j < _columnNumber; j++)
        {
            Cell.Cell newCell = _cellCreator.CreateNewCell(transform);
            newCell.transform.localPosition = new Vector2(currentColumnPosition, _currentRowPosition);
            
            currentColumnPosition += _cellScale.x + _interсellOffset;
            _grid[_lastRow].Add(newCell);
        }
        
        _currentRowPosition -= (_interсellOffset + _cellScale.y);
        _lastRow++;
    }

    public void ClearGrid()
    {
        foreach (var row in _grid)
        {
            foreach (var cell in row)
            {
                cell.GetComponent<ObjectClickHandler>().UnsubscribeAll();
                Destroy(cell.gameObject);
            }
            row.Clear();
        }
        _grid.Clear();
        _lastRow = 0;
        _currentRowPosition = 0f;
    }
}
