using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SimpleTouchController : MonoBehaviour {

	public delegate void TouchDelegate(UnityEngine.Vector2 value);
	public event TouchDelegate TouchEvent;

	public delegate void TouchStateDelegate(bool touchPresent);
	public event TouchStateDelegate TouchStateEvent;

	[SerializeField]
	private RectTransform joystickArea;
	private bool touchPresent = false;
	private UnityEngine.Vector2 movementVector;


	public UnityEngine.Vector2 GetTouchPosition
	{
		get { return movementVector;}
	}


	public void BeginDrag()
	{
		touchPresent = true;
		if(TouchStateEvent != null)
			TouchStateEvent(touchPresent);
	}

	public void EndDrag()
	{
		touchPresent = false;
        movementVector = joystickArea.anchoredPosition = UnityEngine.Vector2.zero;

		if(TouchStateEvent != null)
			TouchStateEvent(touchPresent);

	}

	public void OnValueChanged(UnityEngine.Vector2 value)
	{
		if(touchPresent)
		{
			movementVector.x = ((1 - value.x) - 0.5f) * 2f;
			movementVector.y = ((1 - value.y) - 0.5f) * 2f;

			if(TouchEvent != null)
			{
				TouchEvent(movementVector);
			}
		}

	}

}
