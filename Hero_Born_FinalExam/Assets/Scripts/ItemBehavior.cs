using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior GameManager;
    void Start()
    {
        GameManager = GameObject.Find("Game_Manager").GetComponent<GameBehavior>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.LogWarning("Item collected!");
            GameManager.Bullets += 20;
        }
    }
}