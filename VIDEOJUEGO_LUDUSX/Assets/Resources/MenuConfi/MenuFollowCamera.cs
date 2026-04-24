using UnityEngine;

public class MenuFollowCamera : MonoBehaviour
{
    [Header("Referencia a la cámara XR")]
    public Transform xrCamera;

    [Header("Panel del menú")]
    public GameObject panel;

    [Header("Distancia del menú")]
    public float distancia = 1.5f;

    void LateUpdate()
    {
        // Solo mover si el menú está activo
        if (panel != null && panel.activeSelf && xrCamera != null)
        {
            // Dirección hacia adelante de la cámara (sin inclinación)
            Vector3 forward = xrCamera.forward;
            forward.y = 0;
            forward.Normalize();

            // Posición frente al jugador
            transform.position = xrCamera.position + forward * distancia;

            // Rotación mirando al jugador (solo eje Y)
            transform.LookAt(xrCamera);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}