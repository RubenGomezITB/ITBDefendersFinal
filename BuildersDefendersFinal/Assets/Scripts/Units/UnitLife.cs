using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class UnitLife : MonoBehaviour, IPunObservable
{
    public float life;
    public PhotonView PhotonView;

    [SerializeField] private UnitsScriptable _us;

    private void Start()
    {
        life = _us.Life;
    }

    public void recibeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            destroyThisObject();
        }
    }

    private void destroyThisObject()
    {
        if (PhotonNetwork.IsMasterClient)
        {
             PhotonNetwork.Destroy(gameObject);
        }
       
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(life);
        }
        else
        {
            // Network player, receive data
            life = (int)stream.ReceiveNext();
        }
    }
}