using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1Controller : MonoBehaviour
{
    public Transform gunTip;
    public GameObject bulletPrefab;
    public float shootForce = 20f;
    public float bulletDestroyTime = 2f;
    public float bounciness = 0.5f; // Factor de elasticidad de las balas

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

        // Obtener el componente Collider de la bala
        Collider bulletCollider = bullet.GetComponent<Collider>();

        // Configurar la elasticidad de la bala
        bulletCollider.material.bounciness = bounciness;

        // Aplicar fuerza a la bala para simular el disparo
        bulletRigidbody.AddForce(gunTip.forward * shootForce, ForceMode.Impulse);

        // Destruir la bala después de un cierto tiempo
        Destroy(bullet, bulletDestroyTime);
    }
}
