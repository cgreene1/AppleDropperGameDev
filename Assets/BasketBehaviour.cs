using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 convMouse = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 pos = transform.position;
        pos.x = convMouse.x;
        transform.position = pos;
    }
}
