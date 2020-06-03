using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragdrop : MonoBehaviourPunCallbacks, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
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
    public Camera camaraHost, camaraClient, camara;
    public RaycastHitter.spawnZones SpawnZone;
    public bool ataque;
    RaycastHit hit;
    public GameObject raycastHitter, host, client;
    public PlayManager PlayManager;
    public UnitsScriptable UnitsScriptable;

    private void Start()
    {
        thisObject = gameObject;
        _rectTransform = GetComponent<RectTransform>();
        initialTransform = thisObject.GetComponent<RectTransform>().anchoredPosition;
        if (PhotonNetwork.IsMasterClient)
        {
            camara = camaraHost;
            raycastHitter = host;
            if (ataque)
            {
                SpawnZone = RaycastHitter.spawnZones.hostAttack;
            }
            else
            {
                SpawnZone = RaycastHitter.spawnZones.hostDefense;
            }
        }
        else
        {
            raycastHitter = client;
            camara = camaraClient;
            if (ataque)
            {
                SpawnZone = RaycastHitter.spawnZones.clientAttack;
            }
            else
            {
                SpawnZone = RaycastHitter.spawnZones.clientDefense;
            }
        }
    }

    private void Update()
    {
        if (objectToInstantiate != null)
        {
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, distance, layer))
            {
                Vector3 position = hit.point;
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                objectToInstantiate.transform.position = new Vector3(position.x, 0.5633333f, position.z);
            }
        }

        Debug.Log(PhotonNetwork.IsMasterClient);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        raycastHitter.SetActive(true);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canMove = true;
        if (hit.transform.gameObject.GetComponent<RaycastHitter>().SpawnZone == SpawnZone)
        {
            PlayManager.energyTimer -= UnitsScriptable.cost;
            PhotonNetwork.Instantiate(enemy.name, objectToInstantiate.transform.position, Quaternion.identity);
        }

        Destroy(objectToInstantiate.gameObject);
        objectToInstantiate = null;
        raycastHitter.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (PlayManager.energyTimer >= UnitsScriptable.cost && PlayManager.energyTimer > 0)
        {
            if (canMove)
            {
                _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
            }

            if (_rectTransform.anchoredPosition.y >= initialTransform.y + 20)
            {
                _rectTransform.anchoredPosition = initialTransform;
                canMove = false;
                touchPosition = camara.ScreenToWorldPoint(touch.position);
                if (objectToInstantiate == null)
                {
                    objectToInstantiate = Instantiate(objectPreview,
                        new Vector3(touchPosition.x, 0.5633333f, touchPosition.z), Quaternion.identity);
                }
            }
        }
    }
}