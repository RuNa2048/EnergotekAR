using System;
using System.Collections;
using UnityEngine;
 
public class ScreenOrientionChanger : MonoBehaviour
{
	[Header("Screen Settings")]
	[SerializeField] private bool _isAutoRotation = true;

	public event Action OnChanged;

	private Rect _currentSafeArea;
	private ScreenOrientation _currentOrientation = ScreenOrientation.AutoRotation;

	public void Initialize()
	{
		Screen.orientation = _isAutoRotation
			? ScreenOrientation.AutoRotation
			: ScreenOrientation.Portrait;
	}
	
	private void Update()
	{
		if (_currentOrientation != Screen.orientation || _currentSafeArea != Screen.safeArea)
		{
			Changed();
		}
	}

	private void Changed()
	{
		OnChanged?.Invoke();

		_currentSafeArea = Screen.safeArea;
		_currentOrientation = Screen.orientation;
	}
}
