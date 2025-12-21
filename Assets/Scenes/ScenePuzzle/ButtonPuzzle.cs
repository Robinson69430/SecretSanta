using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    public SlotPuzzle currentSlot;

    void OnMouseDown()
    {
        TryMove();
    }

    void TryMove()
    {
        SlotPuzzle emptySlot = GetAdjacentEmptySlot();

        if (emptySlot == null)
            return;

        // Libère l'ancien slot
        currentSlot.currentButton = null;

        // Prend le nouveau
        currentSlot = emptySlot;
        emptySlot.currentButton = this;

        transform.position = emptySlot.transform.position;
    }

    SlotPuzzle GetAdjacentEmptySlot()
    {
        if (currentSlot.up != null && currentSlot.up.IsEmpty()) return currentSlot.up;
        if (currentSlot.down != null && currentSlot.down.IsEmpty()) return currentSlot.down;
        if (currentSlot.left != null && currentSlot.left.IsEmpty()) return currentSlot.left;
        if (currentSlot.right != null && currentSlot.right.IsEmpty()) return currentSlot.right;

        return null;
    }
}