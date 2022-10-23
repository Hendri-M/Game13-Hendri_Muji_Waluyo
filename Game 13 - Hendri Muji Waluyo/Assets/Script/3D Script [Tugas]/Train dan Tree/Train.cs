using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] float speed;

    int extend;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (this.transform.position.x < -(extend+3.5f) || this.transform.position.x > extend+3.5f)
            Destroy(this.gameObject);
    }

    public void Setup(int extend){
        this.extend = extend;
    }
}
