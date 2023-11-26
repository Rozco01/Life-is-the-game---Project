using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    private Transform target;
    public float homingSpeed = 10f;
    public float homingAcceleration = 20f;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calcular la dirección hacia el objetivo
            Vector3 direction = (target.position - transform.position).normalized;

            // Calcular la rotación hacia el objetivo
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Establecer la rotación directamente
            transform.rotation = rotation;

            // Acelerar la velocidad hacia adelante
            GetComponent<Rigidbody>().velocity = transform.forward * (homingSpeed + homingAcceleration * Time.fixedDeltaTime);
        }
    }
}
