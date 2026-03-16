using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightTriggerShooter : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform muzzleTransform;
    public float bulletSpeed = 20f;
    public float fireRate = 0.15f;
    public float spawnOffset = 0.1f;

    [Header("Cooldown")]
    public int maxShots = 30;
    public float cooldownTime = 8f;

    private InputAction triggerAction;
    private float nextFireTime = 0f;
    private int shotsFired = 0;
    private bool isCoolingDown = false;

    private void Awake()
    {
        triggerAction = new InputAction(
            name: "RightTrigger",
            type: InputActionType.Value,
            binding: "<XRController>{RightHand}/trigger"
        );
    }

    private void OnEnable()
    {
        triggerAction.Enable();
    }

    private void OnDisable()
    {
        triggerAction.Disable();
    }

    private void Update()
    {
        if (isCoolingDown) return;

        float triggerValue = triggerAction.ReadValue<float>();

        if (triggerValue > 0.1f && Time.time >= nextFireTime)
        {
            if (shotsFired < maxShots)
            {
                Shoot();
                shotsFired++;
                nextFireTime = Time.time + fireRate;

                if (shotsFired >= maxShots)
                {
                    StartCoroutine(CooldownRoutine());
                }
            }
        }
    }

    private void Shoot()
    {
        if (bulletPrefab == null || muzzleTransform == null)
        {
            Debug.LogWarning("Falta bulletPrefab o muzzleTransform");
            return;
        }

        Vector3 spawnPos = muzzleTransform.position + muzzleTransform.forward * spawnOffset;
        Quaternion spawnRot = muzzleTransform.rotation;

        GameObject bullet = Instantiate(bulletPrefab, spawnPos, spawnRot);

        if (bullet.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.linearVelocity = muzzleTransform.forward * bulletSpeed;
        }
    }

    private IEnumerator CooldownRoutine()
    {
        if (isCoolingDown) yield break;

        isCoolingDown = true;
        Debug.Log("Cooldown iniciado");

        yield return new WaitForSeconds(cooldownTime);

        shotsFired = 0;
        nextFireTime = 0f;
        isCoolingDown = false;

        Debug.Log("Cooldown terminado");
    }
}