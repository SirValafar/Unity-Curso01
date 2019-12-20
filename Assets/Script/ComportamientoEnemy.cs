using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] // Obliga tener una variable en el inspector
public class ComportamientoEnemy : MonoBehaviour
{
    public bool valor = false;

    public Transform player;

    public Transform patronRuta;

    [HideInInspector]// solo oculta una variable en el inspector
    public List<Transform> WayPoint;

    [SerializeField]// solo muestra una variable en el inspector
    private int destino = 0;

    private NavMeshAgent _agent;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
        InicializarRuta();
        MoveToNextWayPoint();
    }

    void InicializarRuta()
    {
        foreach(Transform wp in patronRuta)
        {
            WayPoint.Add(wp);
        }
    }

    void MoveToNextWayPoint()
    {
        if(WayPoint.Count == 0)
        {
            return;
        }
        _agent.SetDestination(WayPoint[destino].position);
        //destino = (destino + 1) % WayPoint.Count;
        destino = Random.Range(0, WayPoint.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Jugador voy por ti");
            valor = true;
        }
    }

    private void Update()
    {
        if (valor == true)
        {
            _agent.SetDestination(player.position);
        }

        if (_agent.remainingDistance < 0.5f && !_agent.pathPending)
        {
            MoveToNextWayPoint();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Jugador fuera de rango");
            valor = false;

        }
    }


}
