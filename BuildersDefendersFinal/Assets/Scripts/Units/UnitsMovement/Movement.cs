using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private UnitsScriptable _us;
    [SerializeField] private GameObject nexus;
    
    public NavMeshAgent agent;

    private UnitDetectRange _unitAttackRange;
    public PhotonView PhotonView;

    // Start is called before the first frame update
    void Start()
    {
        _unitAttackRange = GetComponentInChildren<UnitDetectRange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PhotonView.IsMine)
        {
            return;
        }
        if (_unitAttackRange.isOnDetectRange)
        {
            agent.isStopped = true;
            /*if (expr)
            {
                
            }*/
        }
        else
        {
            agent.speed = _us.movSpeed;
            agent.isStopped = false;
            agent.SetDestination(nexus.transform.position);
        }
    }
}