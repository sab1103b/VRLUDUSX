using UnityEngine;

public class PosterFragment : MonoBehaviour
{
    private bool playerInRange = false;
    private PlayerModel player;

    void OnTriggerEnter(Collider other)
    {
        PlayerModel model = other.GetComponent<PlayerModel>();

        if (model != null)
        {
            playerInRange = true;
            player = model;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerModel>() != null)
        {
            playerInRange = false;
            player = null;
        }
    }

    public void TryCollect()
    {
        if (playerInRange && player != null)
        {
            player.AddFragment();

            Debug.Log("Fragmento recogido");

            gameObject.SetActive(false);
        }
    }
}