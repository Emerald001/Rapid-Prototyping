using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float scrollSpeed;

    public float maxY;
    public float minY;
    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;

    public bool active;

    void Update() {
        if (!active)
            return;

        var x = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var z = -Input.GetAxis("Vertical") * speed * Time.deltaTime;
        var scrollWheel = Input.mouseScrollDelta.y * scrollSpeed * Time.deltaTime;

        if(transform.position.z >= maxY && z > 0) 
            z = 0;
        if(transform.position.z <= minY && z < 0) 
            z = 0;
        if(transform.position.x >= maxX && x > 0) 
            x = 0;
        if(transform.position.x <= minX && x < 0) 
            x = 0;
        if(transform.position.y >= maxZ && scrollWheel < 0) 
            scrollWheel = 0;
        if(transform.position.y <= minZ && scrollWheel > 0) 
            scrollWheel = 0;

        var newPos = new Vector3(transform.position.x + x, transform.position.y - scrollWheel, transform.position.z + z);

        transform.position = newPos;
    }

    public void EnableCam() {
        StartCoroutine(Sequence());
    }

    public IEnumerator Sequence() {
        for (float i = 0; i < 7; i++) {
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minZ, maxZ), Random.Range(minY, maxY));

            yield return new WaitForSeconds(.1f + (i/20));
        }

        transform.position = new Vector3(0, 20, 0);

        active = true;
    }
}