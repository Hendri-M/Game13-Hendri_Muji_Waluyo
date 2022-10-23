using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Vector3 offset;

    Vector3 lasPost;

    private void Start() {
        offset = this.transform.position - player.transform.position;
    }

    void Update()
    {
        if (lasPost == player.transform.position)
            return;

        var animalPosition = new Vector3(
            player.transform.position.x,
            0,
            player.transform.position.z
        );

        transform.position = animalPosition + offset;
        lasPost = player.transform.position;
    }
}
