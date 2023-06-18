using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFurniture : MonoBehaviour
{
    public float snapValue = 0.5f; // snapping strength

    private Vector3 offset;
    private bool isSnapEnabled;

    private void Update()
    {
        // right mouse button
        if (Input.GetMouseButton(1))
        {
            isSnapEnabled = true;
        }
        else
        {
            isSnapEnabled = false;
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = GetMouseWorldPosition() + offset;
        newPosition.y = transform.position.y;

        if (isSnapEnabled)
        {
            newPosition.x = Mathf.Round(newPosition.x / snapValue) * snapValue;
            newPosition.z = Mathf.Round(newPosition.z / snapValue) * snapValue;
        }

        transform.position = newPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.y;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
