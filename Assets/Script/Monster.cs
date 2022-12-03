using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public float speed;

    private Rigidbody2D _myBody;
    
    void Start() {

        _myBody = GetComponent<Rigidbody2D>();
        speed = 6;
    }

    // Update is called once per frame
    void FixedUpdate() {
        _myBody.velocity = new Vector2(speed, _myBody.velocity.y);
    }
}
