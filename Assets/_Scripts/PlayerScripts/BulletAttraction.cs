using UnityEngine;

public class BulletAttraction : MonoBehaviour
{
    private float attractionRadius;

    public void SetAttraction(float radius)
    {
        attractionRadius = radius;
    }

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius);

        foreach (Collider col in colliders)
        {
            if (col.gameObject != gameObject) // Evitar atraerse a sí mismo
            {
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // Calcular la dirección desde la bala al objeto
                    Vector3 direction = transform.position - col.transform.position;

                    // Imprimir mensaje de depuración
                    Debug.Log("Atracción aplicada a: " + col.gameObject.name);

                    // Aplicar fuerza de atracción hacia la bala
                    rb.AddForce(direction.normalized * 5f);
                }
            }
        }
    }
}
