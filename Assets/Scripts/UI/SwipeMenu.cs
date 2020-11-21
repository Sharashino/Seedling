using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    [SerializeField]
    GameObject scrollbar;
    float scrollPos;
    float[] position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = new float[transform.childCount];
        float distance = 1f / (position.Length - 1f);
        for (int i = 0; i < position.Length; i++)
        {
            position[i] = distance * i;
        }
        if(Input.GetMouseButton(0))
        {
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < position.Length; i++)
            {
                if(scrollPos <position[i] +(distance/2) && scrollPos > position[i] - (distance /2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, position[i], 0.1f);
                }
            }
        }
    }
}
