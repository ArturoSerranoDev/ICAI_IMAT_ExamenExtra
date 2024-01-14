using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform turretEndPoint;
    [SerializeField] private float cooldownTime = 0.25f;

    private bool isOnCooldown = false;
    
    private void Start()
    {
        // Makes so the game runs at 60 frames per second
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetKeyDown(KeyCode.Space) returns true if the user presses the space key down during the current frame
        if (Input.GetKeyDown(KeyCode.Space) && !isOnCooldown)
        {
            Shoot();
            StartCoroutine(CooldownCoroutine());
        }

        MoveTurret();
    }
    
    // Example of Coroutine and timer
    private IEnumerator CooldownCoroutine()
    {
        isOnCooldown = true;
        float timer = 0f;
        while (timer <= cooldownTime)
        {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isOnCooldown = false;
    }
    
    private void MoveTurret()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate the turret to the left
            transform.Translate(Vector3.right * 1f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate the turret to the right
            transform.Translate(Vector3.left * 1f * Time.deltaTime);
        }
    }
    
    private void Shoot()
    {
        // Instantiate is used to create a new instance of an object in Unity.
        // You can access the component of the instantiated object using GetComponent after instantiation
        Bullet shootedBullet = Instantiate(bulletPrefab, turretEndPoint.position, turretEndPoint.rotation).GetComponent<Bullet>();
    }
}
