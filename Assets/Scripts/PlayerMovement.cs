using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Translation")]
    [SerializeField] float translateSpeed = 10f;
    [SerializeField] float xClampRange = 10f;
    [SerializeField] float yClampRangeUp = 10f;
    [SerializeField] float yClampRangeDown = 10f;

    [Header("Rotation")]
    [SerializeField] float rollFactor = 20f;
    [SerializeField] float pitchFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;

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
        float xOffset = movement.x * translateSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * translateSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRangeDown, yClampRangeUp);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    void ProcessRotating()
    {
        float roll = rollFactor * -movement.x;
        float pitch = pitchFactor * -movement.y;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
