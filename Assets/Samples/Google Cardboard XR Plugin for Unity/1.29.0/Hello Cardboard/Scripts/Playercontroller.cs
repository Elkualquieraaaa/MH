using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    PlayerInput input;
    [SerializeField] Transform bulletpoint, gun;
    [SerializeField] float sensibility;
    CharacterController characterController;
    [SerializeField] float velocity;
    [SerializeField] GameObject panel;
    Transform player;
    float mousey;
    float Yrotation;
    Vector3 iny;

    bulletpool bulletpool;

    float movX, movY;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        input = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();  
        bulletpool = FindAnyObjectByType<bulletpool>();
        player = GetComponent<Transform>();
    }
    private void Update()
    {
        //Movercamera();
        iny.y = -9.8f;   

        movX = input.actions["Move"].ReadValue<Vector2>().x * velocity;
        movY = input.actions["Move"].ReadValue<Vector2>().y * velocity;


        characterController.Move(transform.forward * movY * Time.deltaTime + iny + transform.right * movX * Time.deltaTime);

        if (input.actions["Fire"].WasPressedThisFrame())
        {
            GameObject bulletTouse = bulletpool.Bullettouse();
            bulletTouse.SetActive(true);
            bulletTouse.transform.position = bulletpoint.position;
            bulletTouse.transform.rotation = bulletpoint.rotation;
        }
    }

    public void Movercamera()
    {
        mousey = input.actions["Look"].ReadValue<Vector2>().x * sensibility * Time.deltaTime;


        Yrotation += mousey;
        player.localRotation = Quaternion.Euler(0, Yrotation, 0);
    }

    public void Die()
    {
        panel.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
