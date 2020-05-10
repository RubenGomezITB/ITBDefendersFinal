using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUnitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sandWorm, snowman, sandWormPreview;
    private Vector3 touchPosition;
    private bool isTouching = false;
    private Touch touch;
    private GameObject objetoInstanciado;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        }

        if (touch.phase == TouchPhase.Ended)
        {
            touchEnded();
        }
    }

    private void touchEnded()
    {
        
        Instantiate(sandWorm, new Vector3(touchPosition.x, 0.57f, touchPosition.z), Quaternion.identity);
    }

    public void onSpawnUnitButtonClicked(string unit)
    {
        switch (unit)
        {
            case "sandworm":
                onSandWormSpawnClicked();
                break;
            case "snowman":
                onSnowmanSpawnClicked();
                break;
        }
    }

    private void onSnowmanSpawnClicked()
    {
    }

    private void onSandWormSpawnClicked()
    {
        if (sandWormPreview == null)
        {
            objetoInstanciado = Instantiate(sandWormPreview, touchPosition, Quaternion.identity);
        }
    }
        
}