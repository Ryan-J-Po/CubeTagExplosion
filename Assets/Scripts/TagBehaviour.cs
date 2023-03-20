using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagBehaviour : MonoBehaviour
{
    public Transform SpawnPoint;
    public bool IsTagger;
    public int SpawnDelay = 3;
    public float ScoreMultiplier = 3;
    public float Score;
    public GameObject TagMarker;
    public GameObject Explosion;

    private void Update()
    {
        if(!IsTagger)
        {
            Score += ScoreMultiplier * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        if(IsTagger == true)
        {
            IsTagger = false;
            TagMarker.SetActive(false);
        }
        else
        {
            IsTagger = true;
            TagMarker.SetActive(true);
        }

        if(IsTagger == true)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Invoke("Respawn", SpawnDelay);
            gameObject.SetActive(false);
        }

        //IsTagger = !IsTagger;
        //TagMarker.SetActive(!IsTagger);
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        transform.position = SpawnPoint.position;
    }
}
