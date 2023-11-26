using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteraction : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float raycastDistance = 5f;

    public GameObject weaponOne;
    public GameObject weaponTwo;
    public GameObject weaponThree;
    public TMPro.TextMeshProUGUI text;


    private void Start() {
        weaponOne.SetActive(true);
        weaponTwo.SetActive(false);
        weaponThree.SetActive(false);
    }
    private void Update()
    {
        // Disparar el rayo desde la posición de la cámara hacia adelante
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Realizar el raycast
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Verificar la capa del objeto impactado y mostrar un mensaje
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("WeaponOne"))
            {
                text.text = "Pulsa E para coger el arma parabolica";
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Pulsando la tecla E.");
                    weaponOne.SetActive(true);
                    weaponTwo.SetActive(false);
                    weaponThree.SetActive(false);     

                }
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("WeaponTwo"))
            {
                text.text = "Pulsa E para coger el arma de atraccion";
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Pulsando la tecla E.");
                    weaponOne.SetActive(false);
                    weaponTwo.SetActive(true);
                    weaponThree.SetActive(false);     

                }
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("WeaponThree"))
            {
                text.text = "Pulsa E para coger el arma de Autoguia";
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Pulsando la tecla E.");
                    weaponOne.SetActive(false);
                    weaponTwo.SetActive(false);
                    weaponThree.SetActive(true);     

                }
            }else
            {
                text.text = "";
            }
        }
    }
}
