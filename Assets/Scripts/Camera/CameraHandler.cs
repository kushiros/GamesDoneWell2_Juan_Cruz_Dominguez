using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] float dragSpeed = 5; // Velocidad de arrastre de la c�mara
    [SerializeField] float tweenDuration = 0.15f; // Duraci�n del tween
    [SerializeField] Vector2 minXZLimit; // L�mites m�nimos en las coordenadas X y Z
    [SerializeField] Vector2 maxXZLimit; // L�mites m�ximos en las coordenadas X y Z

    private Vector2 dragOrigin; // Posici�n de inicio del arrastre


    void Start()
    {
        minXZLimit = new Vector2(-50f, -100f);
        maxXZLimit = new Vector2(50f, 100f);
        // Detectar la densidad de p�xeles o resoluci�n del dispositivo y ajustar dragSpeed en consecuencia
        float scaleFactor = Screen.dpi / 800f; // Ajusta esto seg�n tus necesidades
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

                    // Calcula la nueva posici�n despu�s del movimiento
                    Vector3 newPosition = transform.position + movement;

                    // Aplica restricciones de l�mites
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
