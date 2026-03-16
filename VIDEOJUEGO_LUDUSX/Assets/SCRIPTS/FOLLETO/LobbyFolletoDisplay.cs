using UnityEngine;

public class LobbyFolletoDisplay : MonoBehaviour
{
    public int folletoID;

    void Start()
    {
        if (CollectionManager.instance == null)
        {
            Debug.Log("No hay CollectionManager");
            return;
        }

        if (CollectionManager.instance.collectedFolletos.Contains(folletoID))
        {
            gameObject.SetActive(true);
            Debug.Log("Mostrando folleto " + folletoID);
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("Folleto no recogido " + folletoID);
        }
    }
}