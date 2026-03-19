using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 4f;
    public float destroyAfterHit = 0.5f;

    private bool hasHit = false;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
        }
    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return;
        hasHit = true;

        Debug.Log("La bala chocó con: " + collision.gameObject.name);

        Destroy(gameObject, destroyAfterHit);
    }
}