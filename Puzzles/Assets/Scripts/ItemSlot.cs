using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            ItemDrag ItemDrag = dropped.GetComponent<ItemDrag>();
            ItemDrag.parentAfterDrag = transform;
        }
    }
}
