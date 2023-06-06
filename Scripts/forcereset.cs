// Este script se encarga de restablecer objetos grabbables en Unity.
// Permite guardar el estado original de los objetos grabbables y restablecerlos cuando sea necesario.
// También proporciona la capacidad de restablecer los objetos al colisionar con un objeto específico.
// Además, puede eliminar las bolas que no están siendo sostenidas.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using UnityEngine;

public class forcereset : MonoBehaviour
{
    // Clase para almacenar el estado de restablecimiento de un objeto grabbable
    class ResetState
    {
        public HVRGrabbable Grabbable;
        public HVRGrabbable Clone;
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale { get; set; }
        public Transform Parent;
    }

    public List<Transform> Parents = new List<Transform>();
    public List<HVRGrabbable> Grabbables = new List<HVRGrabbable>();

    [Header("Debug")]
    public bool ForceReset;

    private readonly List<ResetState> _grabbableState = new List<ResetState>();

    void Start()
    {
        // Se agregan los objetos grabbables de los padres especificados a la lista de restablecimiento
        foreach (var parent in Parents)
        {
            if (parent)
                AddResetGrabbable(parent);
        }

        // Se guardan los objetos grabbables especificados en la lista de restablecimiento
        foreach (var grabbable in Grabbables)
        {
            SaveResetGrabbable(grabbable.transform.parent, grabbable);
        }
    }

    private void AddResetGrabbable(Transform parent)
    {
        // Se agregan los objetos grabbables hijos del padre especificado a la lista de restablecimiento
        foreach (var grabbable in parent.GetComponentsInChildren<HVRGrabbable>().Where(e => e.transform.parent == parent))
        {
            SaveResetGrabbable(parent, grabbable);
        }
    }

    private void SaveResetGrabbable(Transform parent, HVRGrabbable grabbable)
    {
        // Se guarda el estado de restablecimiento de un objeto grabbable
        var clone = Instantiate(grabbable);
        clone.gameObject.SetActive(false);
        clone.gameObject.hideFlags = HideFlags.HideInHierarchy;
        var state = new ResetState()
        {
            Grabbable = grabbable,
            Clone = clone,
            Position = grabbable.transform.position,
            Rotation = grabbable.transform.rotation,
            Scale = grabbable.transform.localScale,
            Parent = parent
        };

        _grabbableState.Add(state);
    }

    void Update()
    {
        // Si ForceReset es verdadero, se restablecen los objetos grabbables
        if (ForceReset)
        {
            ResetGrabbables();
            ForceReset = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si se colisiona con un objeto llamado "coliider_solo", se restablecen los objetos grabbables
        if (other.gameObject.name == "coliider_solo")
        {
            ResetGrabbables();
            ForceReset = false;
        }
    }

    private List<HVRGrabbable> _balls = new List<HVRGrabbable>();

    public void BallSpawned(HVRSocket socket, GameObject ball)
    {
        // Cuando se spawnea una bola, se agrega a la lista de bolas
        var grabbable = ball.GetComponent<HVRGrabbable>();
        _balls.Add(grabbable);
    }

    public void ResetGrabbables()
    {
        // Restablece los objetos grabbables a su estado original
        foreach (var state in _grabbableState)
        {
            if (!state.Grabbable)
            {
                // Si el objeto grabbable ya no existe, se reemplaza por su clon y se activa
                state.Grabbable = state.Clone;
                state.Grabbable.gameObject.SetActive(true);
                state.Clone = Instantiate(state.Clone);
                state.Clone.gameObject.SetActive(false);
                state.Clone.gameObject.hideFlags = HideFlags.HideInHierarchy;
                state.Grabbable.transform.parent = state.Parent;
            }

            if (!state.Grabbable.IsBeingHeld)
            {
                // Si el objeto grabbable no está siendo sostenido, se restablece su posición, rotación y escala
                state.Grabbable.transform.parent = state.Parent;
                state.Grabbable.transform.position = state.Position;
                state.Grabbable.transform.rotation = state.Rotation;
                state.Grabbable.transform.localScale = state.Scale;
                state.Grabbable.Rigidbody.velocity = Vector3.zero;
                state.Grabbable.Rigidbody.angularVelocity = Vector3.zero;
            }
        }

        var remove = new List<HVRGrabbable>();
        foreach (var ball in _balls)
        {
            // Si una bola no está siendo sostenida, se destruye y se remueve de la lista
            if (ball.IsBeingHeld)
                continue;
            Destroy(ball.gameObject);
            remove.Add(ball);
        }

        remove.ForEach(grabbable => _balls.Remove(grabbable));
    }
}