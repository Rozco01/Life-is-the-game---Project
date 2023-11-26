using UnityEngine;

public class Gun3Controller : MonoBehaviour
{
    public Transform gunTip;
    public GameObject bulletPrefab;
    public float initialShootForce = 10f;
    public float bulletDestroyTime = 5f;
    public string targetTag = "Target";

    private GameObject bulletGameObject; // Variable de clase para almacenar la bala instanciada

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar una nueva bala en la posición del punto de origen del disparo
        bulletGameObject = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);

        // Obtener el componente HomingBullet de la bala
        HomingBullet homingBullet = bulletGameObject.GetComponent<HomingBullet>();

        // Si no hay componente HomingBullet, agregamos uno
        if (homingBullet == null)
        {
            homingBullet = bulletGameObject.AddComponent<HomingBullet>();
        }

        // Aplicar fuerza inicial a la bala para simular el disparo
        Rigidbody bulletRigidbody = bulletGameObject.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(gunTip.forward * initialShootForce, ForceMode.Impulse);

        // Establecer el objetivo para la bala después de 2 segundos
        Invoke("FindTarget", 2f);

        // Destruir la bala después de un cierto tiempo
        Destroy(bulletGameObject, bulletDestroyTime);
    }

    void FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        if (targets.Length > 0)
        {
            Transform closestTarget = GetClosestTarget(targets);

            // Obtener el componente HomingBullet directamente del objeto de la bala INSTANCIADO
            HomingBullet homingBullet = bulletGameObject.GetComponent<HomingBullet>();

            if (homingBullet != null)
            {
                // Establecer el objetivo para la bala
                homingBullet.SetTarget(closestTarget);
            }
            else
            {
                Debug.LogError("El objeto de la bala no tiene el componente HomingBullet.");
            }
        }
    }

    Transform GetClosestTarget(GameObject[] targets)
    {
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(gunTip.position, target.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target.transform;
            }
        }

        return closestTarget;
    }
}
