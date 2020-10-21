using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    public GameObject applePrefab;
    public float treeSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("AppleDropper", 1.0f);
    }

    void AppleDropper() {
        GameObject apple = Instantiate <GameObject>(applePrefab);

        apple.transform.position = transform.position + new Vector3(0.0f, -1.5f, 0.0f);

        Invoke("AppleDropper", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(treeSpeed * Time.deltaTime, 0, 0);
       /*if (Mathf.Abs(transform.position.x) > 5.0f) {
            treeSpeed *= -1.0f;
        }*/
    }
    public void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.name == "ScreenBoundaries") {
            treeSpeed *= -1.0f;
            Debug.Log("oncollision called reversing tree");
        }
    }
}
