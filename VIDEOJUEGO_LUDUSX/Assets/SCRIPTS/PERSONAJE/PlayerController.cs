using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel model;

    bool canTakeDamage = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // El enemigo SIEMPRE muere
            EnemyLife enemy = other.GetComponent<EnemyLife>();
            if (enemy != null)
            {
                enemy.Die();
            }

            // El jugador solo recibe daño si puede
            if (canTakeDamage)
            {
                canTakeDamage = false;

                Debug.Log("El jugador fue golpeado");

                model.TakeDamage(1);

                Invoke("ResetDamage", 3f);
            }
        }
    }

    void ResetDamage()
    {
        canTakeDamage = true;
    }
}