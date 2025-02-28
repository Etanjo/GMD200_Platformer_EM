using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour
{
    public int value;
    [SerializeField] GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.GetComponent<gameManager>().score += value;
            Destroy(gameObject);
        }
    }
}

