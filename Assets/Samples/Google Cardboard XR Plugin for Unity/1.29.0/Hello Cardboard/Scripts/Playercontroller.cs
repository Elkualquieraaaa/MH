using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontroller : MonoBehaviour
{
    PlayerInput input;
    [SerializeField] Transform bulletpoint, gun;
    CharacterController characterController;
    [SerializeField] float velocity;

    bulletpool bulletpool;

    float movX, movY;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();  
        bulletpool = FindAnyObjectByType<bulletpool>();
    }
    private void Update()
    {
        movX = input.actions["Move"].ReadValue<Vector2>().x * velocity;
        movY = input.actions["Move"].ReadValue<Vector2>().y * velocity;

        characterController.Move(new Vector3(movX * Time.deltaTime,0, movY * Time.deltaTime));

        if (input.actions["Fire"].WasPressedThisFrame())
        {
            GameObject bulletTouse = bulletpool.Bullettouse();
            bulletTouse.SetActive(true);
            bulletTouse.transform.position = bulletpoint.position;
            bulletTouse.transform.rotation = bulletpoint.rotation;
        }
    }
}
