using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector2 hiz;
    public float yumusakZamanY;
    public float yumusakZamanX;
    public GameObject player;

    [SerializeField]
    private float minX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float maxY;

    void Start()
    {
        
    }

    
    void Update()
    {
        float posX,posY;
        posX = Mathf.SmoothDamp(transform.position.x,player.transform.position.x,ref hiz.x,yumusakZamanX);
        posY = Mathf.SmoothDamp(transform.position.y,player.transform.position.y,ref hiz.y,yumusakZamanY);
        transform.position = new Vector3(Mathf.Clamp(posX,minX,maxX), Mathf.Clamp(posY,minY,maxY),transform.position.z);

    }
}
