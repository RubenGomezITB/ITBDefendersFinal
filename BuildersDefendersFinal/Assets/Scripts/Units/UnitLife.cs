using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class UnitLife : MonoBehaviour, IPunObservable
{
    public float life;
    public PhotonView PhotonView;
    public Slider Slider;

    [SerializeField] private UnitsScriptable _us;

    private void Start()
    {
        life = _us.Life;
        Slider.maxValue = life;
    }

    private void Update()
    {
        Slider.value = life;
    }

    public void recibeDamage(float damage)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            life -= damage;
        }

        if (life <= 0 && GetComponent<PhotonView>().IsMine)
        {
            destroyThisObject();
        }
    }

    private void destroyThisObject()
    {
        PhotonNetwork.Destroy(gameObject);
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
            life = (float) stream.ReceiveNext();
        }
    }
}