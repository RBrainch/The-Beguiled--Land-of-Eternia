using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealParticleDespawner : MonoBehaviour
{
    private float timer;
    public float despawnTime;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.75f, player.transform.position.z);
        timer += Time.deltaTime;
        if(timer >= despawnTime)
        {
            print("Destroyed");
            Destroy(gameObject);
        }
    }
}
