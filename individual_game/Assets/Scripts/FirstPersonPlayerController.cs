using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonPlayerController : MonoBehaviour
{
    public Transform playerCamera; // ī�޶� Ʈ������
    public Transform gunBarrel; // �ѱ� ��ġ
    public float moveSpeed = 5.0f; // �̵� �ӵ�
    public float mouseSensitivity = 2.0f; // ���콺 ����

    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private float rotationX = 0.0f;
    private float gravity = 9.8f; // �߷� ���ӵ�
    private float verticalSpeed = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // �̵� ó��
        Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;

        // �þ� ȸ�� ó��
        Vector2 mouseDelta = lookInput * mouseSensitivity;
        rotationX -= mouseDelta.y;
        rotationX = Mathf.Clamp(rotationX, -90, 90);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseDelta.x, 0);

        // �߷� ����
        if (characterController.isGrounded)
        {
            verticalSpeed = 0; // ���� ����� �� �߷� �ʱ�ȭ
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        moveDirection += Vector3.up * verticalSpeed; // �߷� ����
        moveDirection = transform.TransformDirection(moveDirection); // ���� ��ǥ�� ���� ��ǥ�� ��ȯ
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // �߻� ó��
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void Shoot()
    {
        // �߻� ó��
        // ���⿡ �߻� ������ �߰��ϼ���.
        // ���� ���, �Ѿ� ����, �߻� ȿ�� ���� ó���� �� �ֽ��ϴ�.
    }
}