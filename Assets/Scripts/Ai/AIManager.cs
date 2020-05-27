using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
using ScriptableObjectArchitecture;


[RequireComponent(typeof(AIStateManager))]
public class AIManager : MonoBehaviour
{

    [SerializeField] public AISettings _settings;
   

    private Dictionary<Type, BaseAIState> _initialStates;
    private AIStateManager _stateManager;
    private NavMeshAgent _agent;
    public Rigidbody2D _rb;
    public Transform _player;

    private void OnEnable()
    {
        //_player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
        SetupStates();
    }

    private void Start()
    {
        SetupStates();

        _rb = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<playerMovement>().transform;
      
    }

    private void SetupStates()
    {
        _stateManager = GetComponent<AIStateManager>();
        _initialStates = new Dictionary<Type, BaseAIState>
        {
            {typeof(WanderState), new WanderState(this)},
            {typeof(FleeState), new FleeState(this)}
        };
        _stateManager.SetStates(_initialStates);
    }

    public IEnumerator Flee()
    {
        _agent.speed = _settings._fleeSpeed;
        _agent.autoBraking = false;
        while (true)
        {
            
            yield return new WaitForSeconds(_settings._fleeMovementCycle);
            if (_agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                Vector3 dirtoplayer = transform.position - _player.transform.position;
                Debug.Log("[AIMANAGER] (" + transform.name + "): Setting new flee destination");
                _agent.SetDestination(transform.position + dirtoplayer); 
            }
        }
    }

    public IEnumerator Wander()
    {
        _agent.speed = _settings._wanderSpeed;
        _agent.autoBraking = true;
        while (true)
        {
            yield return new WaitForSeconds(_settings._wanderMovementCycle);
            if(_agent.pathStatus == NavMeshPathStatus.PathComplete && _agent.velocity.magnitude == 0)
            {
                Debug.Log("[AIMANAGER] (" + transform.name + "): Setting new wander destination");
                _agent.SetDestination(getRandomWorldPosition(_settings._wanderRadius));
            }
        }
    }

    private Vector3 getRandomWorldPosition(float radius)
    {
        Vector3 result = new Vector3(UnityEngine.Random.Range(0.0F, radius), 0.0F, 
            UnityEngine.Random.Range(0.0F, radius));
        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _settings._wanderRadius);
        
    }
}

