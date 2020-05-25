using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private UnitsScriptable _us;
    [SerializeField] private GameObject HostNexus, ClientNexus, nexus;

    public NavMeshAgent agent;

    private UnitDetectRange _unitAttackRange;
    public PhotonView PhotonView;

    // Start is called before the first frame update
    void Start()
    {
        _unitAttackRange = GetComponentInChildren<UnitDetectRange>();
        if (PhotonNetwork.IsMasterClient)
        {
            nexus = HostNexus;
        }
        else nexus = ClientNexus;
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (_unitAttackRange.isOnDetectRange)
            {
                agent.isStopped = true;
            }
            else
            {
                agent.speed = _us.movSpeed;
                agent.isStopped = false;
                agent.SetDestination(nexus.transform.position);
            }
        }
    }
}