using UnityEngine;

public class Gun2Controller : MonoBehaviour
{
    public Transform gunTip;
    public GameObject bulletPrefab;
    public float shootForce = 20f;
    public float bulletDestroyTime = 2f;
    public float attractionRadius = 5f; // Radio de atracción para objetos cercanos

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
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);

        // Obtener el componente Rigidbody de la bala
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Configurar la atracción de objetos cercanos
        BulletAttraction bulletAttraction = bullet.GetComponent<BulletAttraction>();
        if (bulletAttraction != null)
        {
            bulletAttraction.SetAttraction(attractionRadius);
        }

        // Aplicar fuerza a la bala para simular el disparo
        bulletRigidbody.AddForce(gunTip.forward * shootForce, ForceMode.Impulse);

        // Destruir la bala después de un cierto tiempo
        Destroy(bullet, bulletDestroyTime);
    }
}
