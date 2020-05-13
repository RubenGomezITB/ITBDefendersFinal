using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragdropTest : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private GameObject thisObject, objectToInstantiate;
    private RectTransform _rectTransform, startRectTransform;
    [SerializeField] private Canvas _canvas;
    private bool canMove = true;
    Vector2 initialTransform;
    public GameObject objectPreview, enemy;
    private Touch touch;
    private Vector3 touchPosition;
    private float distance = 10000;
    public LayerMask layer;

    private void Start()
    {
        thisObject = gameObject;
        _rectTransform = GetComponent<RectTransform>();
        initialTransform = thisObject.GetComponent<RectTransform>().anchoredPosition;
    }

    private void Update()
    {
        if (objectToInstantiate != null) {
                 
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance, layer))
            {
                
                Vector3 position = hit.point;
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                objectToInstantiate.transform.position = new Vector3(position.x, 0.5633333f, position.z);
            }            
        }
    }
 /*touch = Input.GetTouch(0);
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
         
                Debug.Log(objectToInstantiate.transform.position);
                */

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canMove = true;
        Instantiate(enemy, objectToInstantiate.transform.position, Quaternion.identity);
        Destroy(objectToInstantiate.gameObject);
        objectToInstantiate = null;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canMove)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        if (_rectTransform.anchoredPosition.y >= initialTransform.y + 20)
        {
            _rectTransform.anchoredPosition = initialTransform;
            canMove = false;
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (objectToInstantiate == null)
            {
                objectToInstantiate = Instantiate(objectPreview,
                    new Vector3(touchPosition.x, 0.5633333f, touchPosition.z), Quaternion.identity);
            }
        }
    }
}