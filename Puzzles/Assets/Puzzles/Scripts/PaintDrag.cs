using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaintDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Transform parentBeforeDrag;
    public Image image;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        if (transform == transform.parent.GetChild(transform.parent.childCount - 1))
        {
            Debug.Log("Begin Drag");
            Debug.Log("HERE:" + transform.parent.GetComponent<PaintSlot>());
            parentBeforeDrag = transform.parent;

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