using UnityEngine;

public class WeaponEquipRight : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform rightController;
    [SerializeField] private Transform rightWeaponSocket;
    [SerializeField] private GameObject rightControllerVisual;

    [Header("Opcional")]
    [SerializeField] private KeyCode equipKey = KeyCode.G;
    [SerializeField] private float pickupRange = 1.2f;

    private Rigidbody rb;
    private Collider[] allColliders;

    private bool playerIsNear = false;
    private bool isEquipped = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        allColliders = GetComponentsInChildren<Collider>(true);
    }

    private void Update()
    {
        if (rightController == null || rightWeaponSocket == null) return;

        float distance = Vector3.Distance(transform.position, rightController.position);
        playerIsNear = distance <= pickupRange;

        if (Input.GetKeyDown(equipKey))
        {
            if (!isEquipped && playerIsNear)
            {
                Equip();
            }
            else if (isEquipped)
            {
                Unequip();
            }
        }
    }

    private void Equip()
    {
        isEquipped = true;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
            rb.isKinematic = true;
            rb.detectCollisions = false;
        }

        foreach (Collider col in allColliders)
        {
            if (col != null)
                col.enabled = false;
        }

        transform.SetParent(rightWeaponSocket, false);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        if (rightControllerVisual != null)
            rightControllerVisual.SetActive(false);
    }

    private void Unequip()
    {
        isEquipped = false;

        transform.SetParent(null, true);

        foreach (Collider col in allColliders)
        {
            if (col != null)
                col.enabled = true;
        }

        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.detectCollisions = true;
        }

        if (rightControllerVisual != null)
            rightControllerVisual.SetActive(true);
    }
}