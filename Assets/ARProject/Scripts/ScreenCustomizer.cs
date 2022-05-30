using System;
using UnityEngine;

public class ScreenCustomizer : MonoBehaviour
{
    [Header("Screens Components")]
    [SerializeField] private SafeAreaUniversal _safeArea;
    [SerializeField] private ScreenOrientionChanger _orientionChanger;

    private void OnEnable()
    {
        _orientionChanger.OnChanged += _safeArea.UpdateArea;
    }

    private void Start()
    {
        _orientionChanger.Initialize();
        _safeArea.UpdateArea();
    }
    
    private void OnDisable()
    {
        _orientionChanger.OnChanged += _safeArea.UpdateArea;
    }
}
