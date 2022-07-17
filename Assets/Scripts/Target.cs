using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    
    public int pointValue;
    public ParticleSystem explosionParticle;
    

    public Rigidbody targetRB;
    //basic ENCAPSULATION
    [SerializeField] private float minSpeed = 12;
    [SerializeField] private float maxSpeed = 18;
    [SerializeField] private float maxTorque = 10;
    [SerializeField] private float xRange = 4;
    [SerializeField] private float ySpawnPos = -3;
    public GameManager gameManager;

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

    public Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    public float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    public Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    public virtual void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    //abstraction
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

}
