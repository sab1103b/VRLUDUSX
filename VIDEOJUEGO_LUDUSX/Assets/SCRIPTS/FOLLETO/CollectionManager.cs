using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public static CollectionManager instance;

    public List<int> collectedFolletos = new List<int>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddFolleto(int id)
    {
        if (!collectedFolletos.Contains(id))
        {
            collectedFolletos.Add(id);
            Debug.Log("Folleto agregado: " + id);
        }
    }
}