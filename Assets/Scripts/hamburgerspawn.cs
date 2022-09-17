using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamburgerspawn : MonoBehaviour
{
    public GameObject burger; // съедобный объект
    public GameObject crazyburger; // несъедобный объект

    float burgertimer = 1f; // таймер для появления бургера
    float crazyburgertimer = 0.8f; // таймер для появления бомбы
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        burgertimer -= Time.deltaTime;
        crazyburgertimer -= Time.deltaTime;

        if (burgertimer < 0)
        {
            burgertimer = 1f;
            Instantiate(burger, new Vector2(Random.Range(-25, 25), 15), new Quaternion(0, 0, 0, 0)); // клонирование префаба
        }

        if (crazyburgertimer < 0)
        {
            crazyburgertimer = 0.8f;
            Instantiate(crazyburger, new Vector2(Random.Range(-25, 25), 15), new Quaternion(0, 0, 0, 0)); // клонирование префаба
        }
    }
}
