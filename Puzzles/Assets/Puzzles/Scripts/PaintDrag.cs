using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaintDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    public Image image;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        if (transform == transform.parent.GetChild(transform.parent.childCount - 1))
        {
            Debug.Log("Begin Drag");
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (transform == transform.parent.GetChild(transform.parent.childCount - 1))
        {
            Debug.Log("Draggin");
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform == transform.parent.GetChild(transform.parent.childCount - 1))
        {
            Debug.Log("End Drag");
            transform.SetParent(parentAfterDrag);
            image.raycastTarget = true;
        }
    }
}