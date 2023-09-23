using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float speed = 6f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] Button UpButton;
    [SerializeField] Button DownButton;
    [SerializeField] Button LeftButton;
    [SerializeField] Button RightButton;
    float horizontal;
    float vertical;
    float turnSmoothVelocity;
    bool isAnyDirectionPressed = false;

    public void OnUpButtonClick()
    {
        isAnyDirectionPressed = true;
        vertical = 1;
    }

    public void OnDownButtonClick()
    {
        isAnyDirectionPressed = true;
        vertical = -1;
    }

    public void OnLeftButtonClick()
    {
        isAnyDirectionPressed = true;
        horizontal = -1;
    }

    public void OnRightButtonClick()
    {
        isAnyDirectionPressed = true;
        horizontal = 1;
    }

    public void OnDirectionButtonRelease()
    {
        isAnyDirectionPressed = false;
        ResetMovement();
    }

    void ResetMovement()
    {
        horizontal = 0;
        vertical = 0;
    }

    void Update()
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (isAnyDirectionPressed)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            characterController.Move(direction * speed * Time.deltaTime);
        }
    }
}
