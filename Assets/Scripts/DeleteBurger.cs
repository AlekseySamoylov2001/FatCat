using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBurger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "трава")
        {
            Destroy(gameObject); // если объекст упал на землю
        }
    }
    void Update()
    {
    }
}
