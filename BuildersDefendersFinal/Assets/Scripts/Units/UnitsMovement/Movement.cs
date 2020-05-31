using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour, IPunObservable
{
    [SerializeField] private UnitsScriptable _us;
    [SerializeField] private GameObject HostNexus, ClientNexus, nexus;

    public NavMeshAgent agent;

    private UnitDetectRange _unitAttackRange;
    public PhotonView photonView;

    private void Awake()
    {
        _unitAttackRange = GetComponentInChildren<UnitDetectRange>();
        if (PhotonNetwork.IsMasterClient && photonView.IsMine)
        {
            nexus = ClientNexus;
        }
        else nexus = HostNexus;
    }

    // Start is called before the first frame update
    void Start()
    { 
        photonView.TransferOwnership(PhotonNetwork.MasterClient);
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
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            // Network player, receive data
            transform.position = (Vector3) stream.ReceiveNext();
            transform.rotation = (Quaternion) stream.ReceiveNext();
        }
    }
}