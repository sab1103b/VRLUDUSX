using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LoadtoLV : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Level_01");
    }
}
