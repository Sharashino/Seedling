using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    private Seedling seedling;
    private float zPosition;
    private Vector3 offset;
    private bool dragging;

    [SerializeField]
    private UnityEvent OnBeginDrag;
    [SerializeField]
    private UnityEvent OnEndDrag;


    // Start is called before the first frame update
    void Start()
    {
        seedling = GetComponent<Seedling>();
        zPosition = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zPosition);
            transform.position = Camera.main.ScreenToWorldPoint(position + new Vector3(0, 0));
        }
    }

    private void OnMouseDown()
    {
        if (!dragging && seedling.isPlanted == false)
        {
            BeginDrag();
        }
    }
    public void OnMouseUp()
    {
        EndDrag();
    }
    private void BeginDrag()
    {
        OnBeginDrag.Invoke();
        dragging = true;
        offset = Camera.main.WorldToScreenPoint(transform.position) + Input.mousePosition;
    }
    private void EndDrag()
    {
        OnEndDrag.Invoke();
        dragging = false;
    }
}
