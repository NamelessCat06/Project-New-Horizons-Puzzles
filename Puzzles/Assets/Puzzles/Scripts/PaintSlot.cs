using UnityEngine;
using UnityEngine.EventSystems;

public class PaintSlot : MonoBehaviour, IDropHandler
{
    public PaintDrag droppedItem = null;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount < 4)
        {
            GameObject dropped = eventData.pointerDrag;
            PaintDrag PaintDrag = dropped.GetComponent<PaintDrag>();
            PaintDrag.parentAfterDrag = transform;
            droppedItem = PaintDrag;
        }
    }
}
