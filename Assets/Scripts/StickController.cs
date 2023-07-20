using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    // Start is called before the first frame update
    public int numberOfFireballs = 5;
    public GameObject fireballPrefab;
    public float circleRadius = 2f;
    public float rotationSpeed = 2f;

    private GameObject[] fireballs;
    private float startingAngle;

    private void Start()
    {
        fireballs = new GameObject[numberOfFireballs];
        startingAngle = 360f / numberOfFireballs;

        for (int i = 0; i < numberOfFireballs; i++)
        {
            float currentAngle = i * startingAngle;
            fireballs[i] = InstantiateFireball(currentAngle);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private GameObject InstantiateFireball(float angle)
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        fireball.transform.SetParent(transform);
        fireball.transform.localPosition = Quaternion.Euler(0f, 0f, angle) * Vector3.right * circleRadius;
        return fireball;
    }
}
