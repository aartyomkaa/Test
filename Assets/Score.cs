using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Interactable;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private GameObject _collectablesContainer;
    private IGameFactory _gameFactory;
    private int _score;

    private ICollectable[] _collectables;

    private void Awake()
    {
        _gameFactory = AllServices.Container.Single<IGameFactory>();
        _collectablesContainer = _gameFactory.Props;
        _collectables = _collectablesContainer.GetComponentsInChildren<ICollectable>();

        foreach (ICollectable collectable in _collectables)
        {
            collectable.Collected += UpdateScore;
        }
        
        UpdateScore(_score);
    }

    private void UpdateScore(int score)
    {
        _score += score;
        
        _text.text = _score.ToString();
    }
}