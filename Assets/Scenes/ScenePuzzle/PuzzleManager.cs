using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public ButtonPuzzle targetButton;
    public SlotPuzzle targetSlot;

    void Update()
    {
        if (targetButton.currentSlot == targetSlot)
        {
            Debug.Log("Puzzle réussi 🎉");
        }
    }
}