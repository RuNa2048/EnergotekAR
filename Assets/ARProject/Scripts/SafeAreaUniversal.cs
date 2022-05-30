using UnityEngine;

public class SafeAreaUniversal : MonoBehaviour
{
	private RectTransform _rect;
	
	private ScreenOrientation _lastOrientation = ScreenOrientation.AutoRotation;
	//private bool _isInitialized = false;
	
	private void Awake()
	{
		_rect = GetComponent<RectTransform>();
	}

	public void UpdateArea()
	{
		// if (_lastOrientation == Screen.orientation)
		// 	return;
		
		var safeArea = Screen.safeArea;

		var anchorMin = safeArea.position;
		var anchorMax = safeArea.position + safeArea.size;

		// if (!_isInitialized)
		// {
			anchorMin.x /= Screen.width;
			anchorMin.y /= Screen.height;
			anchorMax.x /= Screen.width;
			anchorMax.y /= Screen.height;

		// 	_isInitialized = true;
		// }
		// else
		// {
		// 	anchorMin.x /= Screen.height;
		// 	anchorMin.y /= Screen.width;
		// 	anchorMax.x /= Screen.height;
		// 	anchorMax.y /= Screen.width;
		// }
		//
		// _lastOrientation = Screen.orientation;

		_rect.anchorMin = anchorMin;
		_rect.anchorMax = anchorMax;
	}
}
