using System;
using DG.Tweening;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RestartGameHandler : MonoBehaviour
{
    [SerializeField] private Text _taskText;
    [SerializeField] private Image _loadImage;
    [SerializeField] private Button _restartButton;

    private LoadScreenFadeEffect _loadScreenEffect;
    private LevelChanger _levelChanger;
    private GridGenerator _generator;

    private void Awake()
    {
        _levelChanger = FindObjectOfType<LevelChanger>();
        _levelChanger.LevelFinishedEvent.AddListener(ShowLoadImage);

        _restartButton.onClick.AddListener(RestartGame);
    }

    private void Start()
    {
        _generator = FindObjectOfType<GridGenerator>();

        _loadScreenEffect = _loadImage.GetComponent<LoadScreenFadeEffect>();
    }

    private void ShowLoadImage()
    {
        _loadImage.raycastTarget = true;
        _loadScreenEffect.FadeIn();
    }

    private void RestartGame()
    {
        TextFadeEffect textFadeEffect = _taskText.GetComponent<TextFadeEffect>();
        textFadeEffect.FadeOut();
        
        _generator.ClearGrid();
        
        _loadScreenEffect.FadeOut();
        _loadImage.raycastTarget = false;
        
        textFadeEffect.FadeIn();
        
        _levelChanger.LoadFirstLevel();
    }
}