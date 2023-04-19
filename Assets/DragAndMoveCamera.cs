using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragAndMoveCamera : MonoBehaviour
{
    public Vector2 dragSpeed = new Vector2(1, 1);
    public float zoomSpeed = 10f;
    public float rotationSpeed = 10f;

    private Vector3 dragOrigin;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector2 move = new Vector2(pos.x, pos.y) * dragSpeed;
            transform.Translate(move.x, move.y, 0, Space.World);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            transform.Translate(0, 0, zoom, Space.Self);
        }

        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pivotPoint = hit.point;
                float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
                float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed;
                transform.RotateAround(pivotPoint, Vector3.up, rotationX);
                transform.RotateAround(pivotPoint, transform.right, -rotationY);
            }
        }
    }
}
