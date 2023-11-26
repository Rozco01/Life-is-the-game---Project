using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimationsController : MonoBehaviour
{
    public Animator animator;
    public Button houseButton;
    public Button hiphopButton;
    public Button macarenaButton;
    public Button playButton;
    [SerializeField] private GameObject Player;
    private bool isPlayingAnimation = false;

    void Awake()
    {
        SetAndPlayAnimation("Stay");
    }

    void Start()
    {
        // Asignar funciones a los botones
        houseButton.onClick.AddListener(() => SetAndPlayAnimation("HouseDancing"));
        hiphopButton.onClick.AddListener(() => SetAndPlayAnimation("HiphopDance"));
        macarenaButton.onClick.AddListener(() => SetAndPlayAnimation("MacarenaDance"));
        playButton.onClick.AddListener(ChangeScene);
    }

    void Update()
    {
        // Verificar si hay una animación en ejecución
        if (isPlayingAnimation && !animator.GetCurrentAnimatorStateInfo(0).IsName("Stay"))
        {
            // Permitir el cambio de escena
            playButton.interactable = true;
            Debug.Log("Permitir el cambio de escena");
        }
        else
        {
            // No permitir el cambio de escena
            playButton.interactable = false;
            Debug.Log("No permitir el cambio de escena");
        }
    }

    void SetAndPlayAnimation(string animationName)
    {
        // Reproducir la nueva animación
        animator.Play(animationName);
        isPlayingAnimation = true;

        // Restablecer la rotación a cero
        Player.transform.rotation = Quaternion.identity;

        // Almacenar la animación seleccionada en PlayerPrefs
        PlayerPrefs.SetString("SelectedAnimation", animationName);
    }

    void ChangeScene()
    {
        // Cambiar de escena si hay una animación en ejecución
        if (isPlayingAnimation)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
