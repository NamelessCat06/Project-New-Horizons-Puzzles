using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;
public class PaintSlot : MonoBehaviour, IDropHandler
{
    public PaintDrag droppedItem = null;
    public List<string> itemTags = new List<string>();
    
    private bool allGood = false;
    PaintPuzzleManager manager;

    // TODO: dynamically initialize the itemTags list correctly - don't manually store in scene!

    public bool IsGood()
    {
        return allGood;
    }
    public bool IsEmpty()
    {
        return itemTags.Count == 0;
    }
    void OnDestroy()
    {
        manager.UnRegisterSlot(this);
    }

    void Start()
    {
        manager = FindAnyObjectByType<PaintPuzzleManager>();
        if (manager == null)
        {
            Debug.Log("WARNING: no manager found!");
        }
        else
        {
            manager.RegisterSlot(this);
        }
    }

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
            PaintDrag.parentBeforeDrag.GetComponent<PaintSlot>().RemoveLast();
            if (itemTags.Count == 4)
            {
                CheckWin();
            }
            else
            {
                allGood = false; 
            }
        }
    }

    public void RemoveLast()
    {
        if (itemTags.Count > 0) itemTags.RemoveAt(itemTags.Count - 1);
    }

    public void CheckWin()
    {
        allGood = false;
        if (itemTags.Count < 4) return;

        Debug.Log("Checking win on pile " + gameObject.name);

        allGood = true;
        string itemTagName = itemTags[0];

        for (int i = 1; i < itemTags.Count; i++)
        {
            if (itemTags[i] != itemTagName) // also false if null
            {
                allGood = false;
                return;
            }
        }
        if (allGood)
        {
            Debug.Log("All Good on pile " + gameObject.name);
            manager.CheckGameWin();
        }
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
