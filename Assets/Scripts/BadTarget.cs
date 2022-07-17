using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inheritance
public class BadTarget : Target
{
    [SerializeField] private int hp = 2;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //polimorphism
    public override void OnMouseDown()
    {
        if (gameManager.isGameActive && hp == 0)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        } else
        {
            hp -= 1;
        }
    }
}
