using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public static float speed = 2f;
    bool increaseSpeed = false;

    Rigidbody2D rb;
    int rotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch()
    {
        rotation = Random.Range(0, 361);
        GameManager.rot = rotation;
        transform.Rotate(transform.forward, rotation);
        StartCoroutine(WaitToStart());
    }

    void FixedUpdate()
    {
        if (GameManager.score % GameManager.points[GameManager.levelNo] == 0 && increaseSpeed)
        {
            speed += 1.0f;
            increaseSpeed = false;
            Reset();
        }
    }

    public void Reset()
    {
        GameManager.levelNo += 1;
        rb.velocity = Vector2.zero;
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
        Launch();
    }

    private IEnumerator WaitToStart()
    {
        GameManager.time = 4;
        GameManager.levelTextShow = true;

        for(int i=3; i>0; i--)
        {
            GameManager.countAudio = 1;
            GameManager.time -= 1;
            yield return new WaitForSeconds(1f);
        }

        GameManager.countAudio = 2;
        yield return new WaitForSeconds(0.5f);
        rb.velocity = transform.up * speed;
        GameManager.levelTextShow = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.score += 1;
            GameManager.paddleAudio = true;
            increaseSpeed = true;
        }
        if (collision.gameObject.CompareTag("RestartArea"))
        {
            speed = 2f;
            SceneManager.LoadScene("Game");
        }
    }
}
