using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Apple : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;
    public GameObject Collected;
    public int Score;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = false; // * desabilita a sprite da maçã
            circleCollider2D.enabled = false;// * desabilita o colisor dela;
            Collected.SetActive(true); // * habilita a animação do coletavel;
            GameController.instance.totalScore += Score; // * pontuação
            GameController.instance.UpdateScoreText();
            Destroy(gameObject, 0.5f); // * destroy o componente;
        }
    }
}
