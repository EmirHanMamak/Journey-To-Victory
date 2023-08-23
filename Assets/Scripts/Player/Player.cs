
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool gameStarted;
    public bool isPlayerCrushed;
    public bool isOnBoundery;
    public bool gameEnded;
    public bool isJumping;
    private void Update()
    {
        gameStarted = GameConditions.gameStarted;
        isPlayerCrushed = GameConditions.isPlayerCrushed;
        isOnBoundery = GameConditions.isOnBoundery;
        isJumping = GameConditions.isJumping;
        gameEnded = GameConditions.gameEnded;
    }
}
