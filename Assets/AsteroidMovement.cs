using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    
    public float speed = 3f;
    public GameObject explosionPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {
            Debug.Log("Laser hit asteroid");
            
            Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
