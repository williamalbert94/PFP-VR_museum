// Decorator: Este script permite dibujar en un pizarrón blanco en Unity utilizando un marcador. 
// El marcador deja una marca de tamaño personalizado en la textura del pizarrón cuando entra en contacto con él.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class whiteboardmarker : MonoBehaviour
{
    [SerializeField] private Transform _tip;  // Puntero del marcador
    [SerializeField] private int _penSize = 5;  // Tamaño del marcador
    private Renderer _renderer;  // Renderizador del puntero
    private Color[] _colors;  // Arreglo de colores para pintar
    private float _tipHeigth;  // Altura del puntero
    private RaycastHit _touch;  // Información del punto de contacto
    private whiteboard _whiteboard;  // Referencia al pizarrón
    private Vector2 _touchPos, _lastTouchPos;  // Posiciones del toque actual y anterior
    private bool _touchedLastFrame;  // Indica si se tocó en el frame anterior
    private Quaternion _lastTouchRot;  // Rotación del marcador en el frame anterior

    void Start()
    {
        _renderer = _tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        _tipHeigth = _tip.localScale.y;
    }

    void Update()
    {
        Draw();
    }

    private void Draw()
    {
        // Lanzar un rayo hacia abajo desde el puntero del marcador
        if (Physics.Raycast(_tip.position, transform.up, out _touch, _tipHeigth))
        {
            // Verificar si el objeto tocado es un pizarrón
            if (_touch.transform.CompareTag("whiteboard"))
            {
                // Obtener la referencia al pizarrón si aún no se ha obtenido
                if (_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<whiteboard>();
                }

                // Obtener las coordenadas en la textura del pizarrón donde se realizó el toque
                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                // Calcular las coordenadas en la textura para dibujar el marcador
                var x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_penSize / 2));

                // Verificar si las coordenadas están dentro de los límites de la textura
                if (y < 0 || y > _whiteboard.textureSize.y || x < 0 || x > _whiteboard.textureSize.x)
                {
                    return;
                }

                // Si se realizó un toque en el frame anterior, dibujar el marcador en la textura
                if (_touchedLastFrame)
                {
                    // Dibujar el marcador en la posición actual
                    _whiteboard.texture.SetPixels(x, y, _penSize, _penSize, _colors);

                    // Interpolar y dibujar el marcador en los puntos intermedios para suavizar el trazo
                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerpx = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpy = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _whiteboard.texture.SetPixels(lerpx, lerpy, _penSize, _penSize, _colors);
                    }

                    // Mantener la rotación del marcador del frame anterior
                    transform.rotation = _lastTouchRot;

                    // Aplicar los cambios a la textura del pizarrón
                    _whiteboard.texture.Apply();
                }

                // Guardar la posición y rotación del toque actual para el próximo frame
                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;

                // Indicar que se realizó un toque en el frame anterior
                _touchedLastFrame = true;
                return;
            }
        }

        // Si no se está tocando un pizarrón, reiniciar las variables
        _whiteboard = null;
        _touchedLastFrame = false;
    }
}
