using UnityEngine;


public class CartLap : MonoBehaviour
{
    public int lapNumber;
    public int Checkpoint;
    [SerializeField]
    private int position; 

    public int Position 
    {
        get { return position; }
    }

    public void UpdatePosition(int newPosition)
    {
        position = newPosition; // Update the position value
    }

    private void Start()
    {
        lapNumber = 1;
        Checkpoint = 0;
        position = 1; // Initialize position to 1 at the start
    }
}
