using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pesawat : MonoBehaviour
{
    [SerializeField] float speed = 10;

    Player player;

    void Update() {
        if (this.transform.position.z <= player.CurrentTravel -20)
            return;

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (this.transform.position.z <= player.CurrentTravel && player.gameObject.activeInHierarchy == true)
        {
            player.transform.SetParent(this.transform);
        }
    }

    public void SetupTarget(Player targeted){
        this.player = targeted;
    }
}
