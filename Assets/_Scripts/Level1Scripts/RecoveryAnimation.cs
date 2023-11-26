using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryAnimation : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // Obtener la animación seleccionada de PlayerPrefs
        string savedAnimation = PlayerPrefs.GetString("SelectedAnimation", "Stay");
        Debug.Log("Animación seleccionada: " + savedAnimation);

        // Utilizar la información recuperada (por ejemplo, configurar la animación en un Animator)
        if (animator != null)
        {
            animator.Play(savedAnimation);
        }
    }
}
