using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Boundaries : MonoBehaviour
{
    public int score, highScore;

    private List<GameObject> baskets;
    public GameObject basketPrefab;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HS", 0);
        GameObject.Find("HighScore").GetComponent<Text>().text = highScore.ToString();
        baskets = new List<GameObject>();
        float bottom = transform.position.y + 0.5f;
        for (int i = 0; i < 3; i++)
        {
            GameObject basket = Instantiate<GameObject>(basketPrefab);
            Vector3 vec = basket.transform.position;
            vec.y = bottom + (i*0.5f);
            basket.transform.position = vec;
            baskets.Add(basket);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.tag == "apple") {
            int top = baskets.Count-1;
            if(top > -1) {
                Destroy(baskets[top]);
                baskets.RemoveAt(top);
            }
            GameObject[] apples = GameObject.FindGameObjectsWithTag("apple");
            foreach (GameObject apple in apples)
            {
                Destroy(apple);
            }
            if(top <= 0) {
                PlayerPrefs.SetInt("HS", highScore);
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    
    public void Score() {
        score += 10;
        if(score > highScore) {
            highScore = score;
            GameObject.Find("HighScore").GetComponent<Text>().text = score.ToString();
        }
        GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
    }
}
