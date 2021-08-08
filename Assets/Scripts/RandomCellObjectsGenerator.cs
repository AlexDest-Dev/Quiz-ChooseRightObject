using System;
using System.Collections.Generic;
using Cell;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCellObjectsGenerator : MonoBehaviour
{
    private List<String> _lastRightAnswers;
    private int _rightAnswerRow;
    private int _rightAnswerColumn;
    private CellObjectData _currentRightAnswer;

    public CellObjectData CurrentRightAnswer => _currentRightAnswer;

    private void Awake()
    {
        _lastRightAnswers = new List<string>();
    }

    public void RandomizeGridCellObjects(List<List<Cell.Cell>> grid, CellCollection collection)
    {
        _currentRightAnswer = collection.GetRandomData();
        while (_lastRightAnswers.Contains(_currentRightAnswer.ObjectIdentifier))
        {
            _currentRightAnswer = collection.GetRandomData();
        }

        SetRightAnswer(grid, _currentRightAnswer);
        
        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid[i].Count; j++)
            {
                if(i == _rightAnswerRow && j == _rightAnswerColumn)
                    continue;

                CellObjectData data = collection.GetRandomData();
                while (string.Compare(data.ObjectIdentifier, _currentRightAnswer.ObjectIdentifier, StringComparison.Ordinal) == 0)
                {
                    data = collection.GetRandomData();
                }
                
                grid[i][j].CellObject.SetCellObjectData(data);
            }
        }

        _lastRightAnswers.Add(_currentRightAnswer.ObjectIdentifier);
    }

    private void SetRightAnswer(List<List<Cell.Cell>> grid, CellObjectData rightAnswerData)
    {
        _rightAnswerRow = Random.Range(0, grid.Count);
        _rightAnswerColumn = Random.Range(0, grid[_rightAnswerRow].Count);

        grid[_rightAnswerRow][_rightAnswerColumn].CellObject.SetCellObjectData(rightAnswerData);
    }
}
