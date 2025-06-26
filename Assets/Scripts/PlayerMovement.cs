using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("MoveRange")]
    [SerializeField] float xClampRange = 10f;
    [SerializeField] float yClampRangeUp = 10f;
    [SerializeField] float yClampRangeDown = 10f;

    [Header("")]
    [SerializeField] float movespeed = 10f;
    Vector2 movement;

    void Update()
    {
        ProcessTranslating();
    }

    void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }

    private void ProcessTranslating()
    {
        float xOffset = movement.x * movespeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * movespeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRangeDown, yClampRangeUp);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
}
