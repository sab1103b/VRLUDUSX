using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Lifetime")]
    [SerializeField] private float lifeTime = 4f;

    private bool hasHit = false;
    private Rigidbody rb;
    private Collider[] allColliders;
    private Renderer[] allRenderers;
    private TrailRenderer[] allTrails;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        allColliders = GetComponentsInChildren<Collider>(true);
        allRenderers = GetComponentsInChildren<Renderer>(true);
        allTrails = GetComponentsInChildren<TrailRenderer>(true);

        if (rb != null)
        {
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
        }
    }

    private void Start()
    {
        // Se destruye sola si no golpea nada
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return;
        hasHit = true;

        Debug.Log("La bala chocó con: " + collision.gameObject.name);

        // Frenarla en seco
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.detectCollisions = false;
            rb.isKinematic = true;
        }

        // Apagar colisiones ya mismo
        foreach (Collider c in allColliders)
        {
            if (c != null) c.enabled = false;
        }

        // Borrar trail para que no quede “fantasma”
        foreach (TrailRenderer t in allTrails)
        {
            if (t != null)
            {
                t.Clear();
                t.emitting = false;
                t.enabled = false;
            }
        }

        // Ocultar mesh/render en este mismo frame
        foreach (Renderer r in allRenderers)
        {
            if (r != null) r.enabled = false;
        }

        // Destruir sin delay extra
        Destroy(gameObject);
    }
}