using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	private enum InputType
	{
		Mouse,
		Touch,
	}
	
	[Header("Type")]
	[SerializeField] private InputType _currentType = InputType.Mouse;

	public event Action<Vector2> OnTouched;
	
	private Vector2 _mouseLastPosition;

	private void Update()
	{
		CheckInput();
	}

	private void CheckInput()
	{
		switch (_currentType)
		{
			case InputType.Mouse:
				CheckMouse();
				
				break;
			case InputType.Touch:
				CheckTouch();

				break;
		}
	}

	private void CheckTouch()
	{
		if (Input.touchCount == 0 || Input.touchCount >= 2)
			return;
		
		Touch touch = Input.GetTouch(0);

		OnTouched?.Invoke(touch.deltaPosition.normalized);
	}

	private void CheckMouse()
	{
		if (Input.GetMouseButton(0))
		{
			Vector2 mouseDelta = _mouseLastPosition - (Vector2)Input.mousePosition;
			
			_mouseLastPosition = Input.mousePosition;

			OnTouched?.Invoke(mouseDelta.normalized);
		}
	}
}
