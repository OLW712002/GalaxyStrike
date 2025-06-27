using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movespeed = 10f;

    [Header("MoveRange")]
    [SerializeField] float xClampRange = 10f;
    [SerializeField] float yClampRangeUp = 10f;
    [SerializeField] float yClampRangeDown = 10f;

    [Header("Rotation")]
    [SerializeField] float horizontalMove = 20f;
    [SerializeField] float verticalMove = 20f;

    Vector2 movement;

    void Update()
    {
        ProcessTranslating();
        ProcessRotating();
    }

    void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }

    void ProcessTranslating()
    {
        float xOffset = movement.x * movespeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * movespeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRangeDown, yClampRangeUp);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    void ProcessRotating()
    {
        float horizontalValue = horizontalMove * -movement.x;
        float verticalValue = verticalMove * -movement.y;
        Quaternion targetRotation = Quaternion.Euler(verticalValue, 0f, horizontalValue);
        transform.localRotation = targetRotation;
    }
}
