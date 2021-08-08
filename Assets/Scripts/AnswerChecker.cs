using System;
using System.Collections.Generic;
using Cell;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class AnswerChecker : MonoBehaviour, ISubscription<UnityAction<bool, CellObject>>
{
    private List<List<Cell.Cell>> _grid;
    private LevelChanger _levelChanger;
    private UnityEvent<bool, CellObject> _answerEvent = new UnityEvent<bool, CellObject>();
    private CellObjectData _rightAnswerData;
    private RandomCellObjectsGenerator _generator;

    private void Awake()
    {
        _grid = FindObjectOfType<GridGenerator>().Grid;
        _generator = FindObjectOfType<RandomCellObjectsGenerator>();
        
        _levelChanger = FindObjectOfType<LevelChanger>();
        _levelChanger.LevelChangedEvent.AddListener(UpdateClickHandlerSubscribes);
        _levelChanger.LevelChangedEvent.AddListener(UpdateRightAnswer);
    }

    private void UpdateClickHandlerSubscribes()
    {
        foreach (var row in _grid)
        {
            foreach (var cell in row)
            {
                cell.GetComponent<ObjectClickHandler>().Subscribe(CheckAnswer);
            }
        }
    }

    private void UpdateRightAnswer()
    {
        _rightAnswerData = _generator.CurrentRightAnswer;
    }

    private void CheckAnswer(CellObject currentAnswer)
    {
        bool isRightAnswer = string.Compare(currentAnswer.Identifier, _rightAnswerData.ObjectIdentifier,
                                 StringComparison.Ordinal) == 0;
        _answerEvent?.Invoke(isRightAnswer, currentAnswer);
    }

    public void Subscribe(UnityAction<bool, CellObject> listenerMethod)
    {
        _answerEvent ??= new UnityEvent<bool, CellObject>();
        _answerEvent.AddListener(listenerMethod);
    }

    public void Unsubscribe(UnityAction<bool, CellObject> listenerMethod)
    {
        _answerEvent.RemoveListener(listenerMethod);
    }

    public void UnsubscribeAll()
    {
        _answerEvent.RemoveAllListeners();
    }
}
