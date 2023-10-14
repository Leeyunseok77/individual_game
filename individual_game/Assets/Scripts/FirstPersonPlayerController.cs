using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonPlayerController : MonoBehaviour
{
    public Transform playerCamera; // 카메라 트랜스폼
    public Transform gunBarrel; // 총구 위치
    public float moveSpeed = 5.0f; // 이동 속도
    public float mouseSensitivity = 2.0f; // 마우스 감도

    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private float rotationX = 0.0f;
    private float gravity = 9.8f; // 중력 가속도
    private float verticalSpeed = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 이동 처리
        Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;

        // 시야 회전 처리
        Vector2 mouseDelta = lookInput * mouseSensitivity;
        rotationX -= mouseDelta.y;
        rotationX = Mathf.Clamp(rotationX, -90, 90);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseDelta.x, 0);

        // 중력 적용
        if (characterController.isGrounded)
        {
            verticalSpeed = 0; // 땅에 닿았을 때 중력 초기화
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        moveDirection += Vector3.up * verticalSpeed; // 중력 적용
        moveDirection = transform.TransformDirection(moveDirection); // 로컬 좌표를 월드 좌표로 변환
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // 발사 처리
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
        // 발사 처리
        // 여기에 발사 로직을 추가하세요.
        // 예를 들어, 총알 생성, 발사 효과 등을 처리할 수 있습니다.
    }
}