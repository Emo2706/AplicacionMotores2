using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : Controller , IDragHandler , IEndDragHandler
{
    Vector3 _initialPosition;
    Vector3 _direction;

    [SerializeField] float _magnitude = 100f;
    public override Vector3 GetControllerDirection()
    {
        return new Vector3(_direction.x, 0, _direction.y) / _magnitude;
    }

    private void Start()
    {
        _initialPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _direction = (Vector3)eventData.position - _initialPosition;

        Vector3 joystickDirection = Vector3.ClampMagnitude(_direction, _magnitude);

        transform.position = _initialPosition + joystickDirection;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _initialPosition;

        _direction = Vector3.zero;
    }
}
