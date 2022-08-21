using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utilities;

public class TouchController : Singleton<TouchController>, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    private Image pivotImage;
    private Vector2 direction;
    public Vector2 Direction => direction;
    private Vector2 touchPosition;

    public void OnDrag(PointerEventData eventData)
    {
        var delta = eventData.position-touchPosition;
        direction = delta.normalized;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        touchPosition = eventData.position;
        pivotImage.enabled = true;
        pivotImage.transform.position = touchPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector3.zero;
        pivotImage.enabled = false;
    }
}
