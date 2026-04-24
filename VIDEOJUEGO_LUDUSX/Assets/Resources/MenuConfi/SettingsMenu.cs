using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject panel;
    public GameObject lobbyButtons;
    public GameObject gameButtons;

    [Header("Input VR")]
    public InputActionProperty openMenuButton;

    private bool isOpen = false;

    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if (openMenuButton.action.WasPressedThisFrame())
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        isOpen = !isOpen;
        panel.SetActive(isOpen);

        if (isOpen)
        {
            bool isLobby = SceneManager.GetActiveScene().name == "Lobby";

            lobbyButtons.SetActive(isLobby);
            gameButtons.SetActive(!isLobby);
        }
    }

    // BOTONES

    public void VolverJuego()
    {
        panel.SetActive(false);
        isOpen = false;
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void VolverLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void VolverNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Mantener frente al jugador
    void LateUpdate()
    {
        if (panel.activeSelf)
        {
            Transform cam = Camera.main.transform;

            transform.position = cam.position + cam.forward * 1.5f;
            transform.LookAt(cam);
            transform.Rotate(0, 180, 0);
        }
    }
}
