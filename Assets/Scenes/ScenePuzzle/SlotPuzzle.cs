using UnityEngine;

public class SlotPuzzle : MonoBehaviour
{
    public ButtonPuzzle currentButton;

    public SlotPuzzle up;
    public SlotPuzzle down;
    public SlotPuzzle left;
    public SlotPuzzle right;

    public bool IsEmpty()
    {
        return currentButton == null;
    }
}