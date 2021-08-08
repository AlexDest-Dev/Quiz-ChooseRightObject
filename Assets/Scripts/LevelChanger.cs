using System;
using System.Collections;
using System.Collections.Generic;
using Cell;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class LevelChanger : MonoBehaviour
{
    [SerializeField, Min(1)] private int _levelAmount = 1;
    [SerializeField] private CellCollection[] _collections;

    private RandomCellObjectsGenerator _randomCellObjectsGenerator;
    private GridGenerator _gridGenerator;
    private AnswerChecker _answerChecker;
    private CellCreator _cellCreator;
    
    private int _currentLevel;
    
    private readonly UnityEvent _levelChangedEvent = new UnityEvent();
    private readonly UnityEvent _levelFinishedEvent = new UnityEvent();

    public UnityEvent LevelFinishedEvent => _levelFinishedEvent;
    public UnityEvent LevelChangedEvent => _levelChangedEvent;

    public void Awake()
    {
        _cellCreator = FindObjectOfType<CellCreator>();
    }

    private void Start()
    {
        _randomCellObjectsGenerator = FindObjectOfType<RandomCellObjectsGenerator>();
        _gridGenerator = FindObjectOfType<GridGenerator>();

        _answerChecker = FindObjectOfType<AnswerChecker>();
        _answerChecker.Subscribe(TryNextLevel);
        
        _currentLevel = 0;
        
        NextLevel();
    }

    private void TryNextLevel(bool isRightAnswer, CellObject cellObject)
    {
        if(isRightAnswer)
            NextLevel();
    }

    public void LoadFirstLevel()
    {
        _currentLevel = 0;
        NextLevel();
    }

    private void NextLevel()
    {
        if(_currentLevel == 0)
            _cellCreator.EnableStartEffect();
        else 
            _cellCreator.DisableStartEffect();
        
        if (_currentLevel == _levelAmount)
        {
            _levelFinishedEvent?.Invoke();
            return;
        }

        CellCollection nextCollection = _collections[Random.Range(0, _collections.Length)];
        _currentLevel++;
        _gridGenerator.AddRow();
        _randomCellObjectsGenerator.RandomizeGridCellObjects(_gridGenerator.Grid, nextCollection);
        _levelChangedEvent?.Invoke();
    }
}
