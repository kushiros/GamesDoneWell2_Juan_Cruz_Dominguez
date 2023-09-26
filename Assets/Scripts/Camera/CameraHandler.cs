using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] float dragSpeed = 40; // Aumenta para movimiento más rápido
    [SerializeField] float tweenDuration = 0.3f; // Reduce para un movimiento más rápido

    private Vector2 dragOrigin; // Posición de inicio del arrastre
    private bool isDragging = false;


    void Start()
    {
        // Detectar la densidad de píxeles o resolución del dispositivo y ajustar dragSpeed en consecuencia
        float scaleFactor = Screen.dpi / 800f; // Ajusta esto según tus necesidades
        dragSpeed *= scaleFactor;
    }

    void Update()
    {
        // Verifica si se toca la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Maneja el arrastre solo si estamos haciendo clic en un objeto con el tag "wall"
            if (!isDragging)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("wall"))
                    {
                        isDragging = true;
                        dragOrigin = touch.position;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 dragDelta = touch.position - dragOrigin;
                Vector3 movement = new Vector3(-dragDelta.x * dragSpeed * Time.deltaTime, 0, -dragDelta.y * dragSpeed * Time.deltaTime);

                // Usar DOTween para el movimiento suave
                transform.DOMove(transform.position + movement, tweenDuration);
                dragOrigin = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }
        }
    }
}
