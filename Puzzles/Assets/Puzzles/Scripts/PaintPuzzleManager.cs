using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintPuzzleManager : MonoBehaviour
{
    List<PaintSlot> slots = new List<PaintSlot>();
    public AudioSource correctAnswer;
    public string SceneName;

    public void RegisterSlot(PaintSlot slot)
    {
        slots.Add(slot);
        Debug.Log(slot.name + " registers to game manager");
    }
    public void UnRegisterSlot(PaintSlot slot)
    {
        if (slots.Contains(slot))
        {
            slots.Remove(slot);
            Debug.Log(slot.name + " unregisters from game manager");
        }
        else
        {
            Debug.Log("Something went wrong");
        }
    }
    public void CheckGameWin()
    {
        Debug.Log("Checking if all piles good...");
        bool win = AllPilesGood();
        // TODO: play anim? load next scene?
        if (win)
        {
            Debug.Log("Player has won!");
            correctAnswer.Play();
            SceneManager.LoadScene(SceneName);
        }
    }

    bool AllPilesGood()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (! (slots[i].IsGood() || slots[i].IsEmpty()))
            {
                Debug.Log($"Pile {slots[i].name} is still bad");
                return false;
            }
        }
        return true;
    }
}
