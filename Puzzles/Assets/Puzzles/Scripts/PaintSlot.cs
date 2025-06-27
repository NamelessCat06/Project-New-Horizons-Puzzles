using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class PaintSlot : MonoBehaviour, IDropHandler
{
    public PaintDrag droppedItem = null;
    public List<string> itemTags = new List<string>();
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount >= 4) return;
  
        GameObject dropped = eventData.pointerDrag;
        PaintDrag PaintDrag = dropped.GetComponent<PaintDrag>();
        if (itemTags.Count == 0 || PaintDrag.CompareTag(itemTags[itemTags.Count - 1]))
        {
            PaintDrag.parentAfterDrag = transform;
            droppedItem = PaintDrag;
            itemTags.Add(PaintDrag.tag);
        }

        PaintDrag.parentBeforeDrag.GetComponent<PaintSlot>().RemoveLast();
    }

    public void RemoveLast()
    {
        if (itemTags.Count > 0) itemTags.RemoveAt(itemTags.Count - 1);
    }
    
    /*
public void OnDrop(PointerEventData eventData)
    {
        //string firstTag = transform.GetChild(transform.childCount - 1).tag;
        if (transform.childCount >= 4) return;
     //   {
            // if (itemTags.Count == 0)
            // {
            //     GameObject dropped = eventData.pointerDrag;
            //     PaintDrag PaintDrag = dropped.GetComponent<PaintDrag>();
            //     PaintDrag.parentAfterDrag = transform;
            //     droppedItem = PaintDrag;
            //     itemTags.Add(PaintDrag.tag);
            //     PaintDrag.parentBeforeDrag.GetComponent<PaintSlot>().RemoveLast();
            // }
            // else
            // {
            GameObject dropped = eventData.pointerDrag;
            PaintDrag PaintDrag = dropped.GetComponent<PaintDrag>();
            if (itemTags.Count == 0 || PaintDrag.CompareTag(itemTags[itemTags.Count - 1]))
            {
                PaintDrag.parentAfterDrag = transform;
                droppedItem = PaintDrag;
                itemTags.Add(PaintDrag.tag);
            }

            PaintDrag.parentBeforeDrag.GetComponent<PaintSlot>().RemoveLast();
 //           }


     //   }
        //if (transform.childCount > 0)
        //{
        //    foreach (Transform child in transform)
        //    {
        //        if (child.tag != firstTag)
        //        {
        //            allMatch = false;
        //        }
        //    }
        //    if (allMatch)
        //    {
        //        Debug.Log("That's the right position for " + firstTag);
        //    }
        //}
    }
    */
}
