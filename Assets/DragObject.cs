using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 depth;
    private Vector3 offset;

    private void OnMouseDown()
    {
        depth = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, depth.z);
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePosition);
    }


    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, depth.z);
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
    }
}
