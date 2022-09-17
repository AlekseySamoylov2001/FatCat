using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BurgerAnnihilation : MonoBehaviour
{
    public GameObject hamburger; // бургер
    public GameObject crazyhamburger; // не бургер
    public GameObject Score; // для изменения текста с очками
    public GameObject GameOver; // для вывода уведомления о конце игры

    public AudioClip eatSound; //звуки
    public AudioClip boomSound;

    Text sc; // текст
    Text gameover;

    public Animator animator; // для смены анимации

    bool beready = false;

    int score = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
        sc = Score.GetComponent<Text>();
        gameover = GameOver.GetComponent<Text>();
        Time.timeScale = 0; // пауза в игре
        gameover.text = "TAB SPACE";
        sc.text = "";
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject); // уничтожение объекта

        if (col.gameObject.tag == "hamburger")
        {
            score += 1;
            AudioSource.PlayClipAtPoint(eatSound, new Vector3(0, 0, 0)); // проигрываение звука
        }
        else if (col.gameObject.tag == "crazyhamburger")
        {
            score -= 3;
            AudioSource.PlayClipAtPoint(boomSound, new Vector3(0, 0, 0));
        }

        sc.text = "score: " + score.ToString(); // изменение количества очков на экране
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        beready = true; // для смены анимации разивания рта
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        beready = false;
    }

    void Update()
    {
        animator.SetBool("beready", beready);

        if (Input.GetKey("space")) // начало игры
        {
            sc.text = "score: " + score.ToString();
            Time.timeScale = 1;
            gameover.text = "";
        }
        if (Input.GetKey("escape")) // выход из игры
        {
            Application.Quit();
        }

        if (score > 20) // конец игры
        {
            gameover.text = "YOU WIN";
            Time.timeScale = 0;
        }
        else if (score < 0)
        {
            gameover.text = "YOU LOSE";
            Time.timeScale = 0;
        }
    }
}
