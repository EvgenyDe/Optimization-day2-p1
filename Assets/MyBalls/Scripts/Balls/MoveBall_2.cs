using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall_2 : MonoBehaviour
{
    Vector3 velocity;
    float sides = 30.0f;
    float speedMax = 0.3f;
    private string colorName = "_Color";
    private int hashColorID;
    private Material _material;

    private Renderer _renderer;
    void Start()
    {

        hashColorID = Shader.PropertyToID(colorName);
        _material = this.GetComponent<Renderer>().material;
        
        velocity = new Vector3(Random.Range(0.0f, speedMax),
                        Random.Range(0.0f, speedMax),
                        Random.Range(0.0f, speedMax));

    }

    Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity);

        if (transform.position.x > sides)
        {
            velocity.x = -velocity.x;
        }
        if (transform.position.x < -sides)
        {
            velocity.x = -velocity.x;
        }
        if (transform.position.y > sides)
        {
            velocity.y = -velocity.y;
        }
        if (transform.position.y < -sides)
        {
            velocity.y = -velocity.y;
        }
        if (transform.position.z > sides)
        {
            velocity.z = -velocity.z;
        }
        if (transform.position.z < -sides)
        {
            velocity.z = -velocity.z;
        }

        _material.SetColor(hashColorID, new Color(transform.position.x/sides,
                                                                             transform.position.y/sides,
                                                                           transform.position.z/sides));

    }
}
