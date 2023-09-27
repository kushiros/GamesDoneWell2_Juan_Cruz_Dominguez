using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] float dragSpeed = 5; // Velocidad de arrastre de la cámara
    [SerializeField] float tweenDuration = 0.15f; // Duración del tween
    [SerializeField] Vector2 minXZLimit; // Límites mínimos en las coordenadas X y Z
    [SerializeField] Vector2 maxXZLimit; // Límites máximos en las coordenadas X y Z

    private Vector2 dragOrigin; // Posición de inicio del arrastre


    void Start()
    {
        minXZLimit = new Vector2(-50f, -100f);
        maxXZLimit = new Vector2(50f, 100f);
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

            // Maneja el arrastre
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    dragOrigin = touch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 dragDelta = touch.position - dragOrigin;
                    Vector3 movement = new Vector3(-dragDelta.x * dragSpeed * Time.deltaTime, 0, -dragDelta.y * dragSpeed * Time.deltaTime);

                    // Calcula la nueva posición después del movimiento
                    Vector3 newPosition = transform.position + movement;

                    // Aplica restricciones de límites
                    newPosition.x = Mathf.Clamp(newPosition.x, minXZLimit.x, maxXZLimit.x);
                    newPosition.z = Mathf.Clamp(newPosition.z, minXZLimit.y, maxXZLimit.y);

                    // Usar DOTween para el movimiento suave
                    transform.DOMove(newPosition, tweenDuration);
                    dragOrigin = touch.position;
                    break;
            }
        }
    }
}
