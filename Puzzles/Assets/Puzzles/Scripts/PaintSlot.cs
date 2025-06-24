using UnityEngine;
using UnityEngine.EventSystems;

public class PaintSlot : MonoBehaviour, IDropHandler
{
    public ItemDrag droppedItem = null;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount < 4)
        {
            GameObject dropped = eventData.pointerDrag;
            ItemDrag ItemDrag = dropped.GetComponent<ItemDrag>();
            ItemDrag.parentAfterDrag = transform;
            droppedItem = ItemDrag;
        }
    }
}
