using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Directions
    {
    up, down, right, left
    }
public class MovementArrow : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed;
    public Directions direction;

    // Start is called before the first frame update
    public void OnUpdateSelected(BaseEventData data)
        {
        if (isPressed)
            {
            SetBoolean(true);
            }
        }
    public void OnPointerDown(PointerEventData data)
        {
        isPressed = true;
        }
    public void OnPointerUp(PointerEventData data)
        {
        isPressed = false;

        SetBoolean(false);
        }

    private void SetBoolean(bool value)
        {
        switch (direction)
            {
            case Directions.up:
                ArrowBooleans.up = value;
                break;
            case Directions.down:
                ArrowBooleans.down = value;
                break;
            case Directions.right:
                ArrowBooleans.right = value;
                break;
            case Directions.left:
                ArrowBooleans.left = value;
                break;
            }
        }

    public void OnEnable()
        {
        SetBoolean(false);
        }

    private void OnDisable()
        {
        SetBoolean(false);
        }
    }

