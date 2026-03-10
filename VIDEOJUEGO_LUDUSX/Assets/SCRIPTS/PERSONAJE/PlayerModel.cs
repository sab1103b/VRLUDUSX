using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;

    void Awake()
    {
        currentLives = maxLives;
    }

    public void TakeDamage(int amount)
    {
        currentLives -= amount;

        if (currentLives < 0)
            currentLives = 0;

        Debug.Log("Vidas restantes: " + currentLives);
    }
}