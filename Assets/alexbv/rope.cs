using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class rope : MonoBehaviour
{

public float jointLength;
private float minLength;
public int segments;
public GameObject ropeSegment;
private List<SpringJoint2D> allJoints = new List<SpringJoint2D>();

public GameObject otherPlayer;


    // Start is called before the first frame update
    void Start()
    {
            minLength = jointLength;
            GameObject previous = this.gameObject;  //connectedBody

            int i = 0;
            while(i < segments) {
                i++;
                GameObject newSegment = Instantiate(ropeSegment, this.transform.position + new Vector3(i * jointLength ,0,0), Quaternion.identity);
                allJoints.Add(newSegment.GetComponent<SpringJoint2D>());

                newSegment.GetComponent<SpringJoint2D>().connectedBody = previous.GetComponent<Rigidbody2D>();
                newSegment.GetComponent<SpringJoint2D>().distance = jointLength;

                previous = newSegment;
            }

            otherPlayer.GetComponent<SpringJoint2D>().connectedBody = previous.GetComponent<Rigidbody2D>();
            otherPlayer.GetComponent<SpringJoint2D>().distance = jointLength;

        
    }
    public void ResetRope()
    {
        foreach (SpringJoint2D go in allJoints)
        {
            Destroy(go.gameObject);
        }
        allJoints.Clear();
        jointLength = 0.005f;


        GameObject previous = this.gameObject;  //connectedBody

        int i = 0;
        while (i < segments)
        {
            i++;
            GameObject newSegment = Instantiate(ropeSegment, this.transform.position + new Vector3(i * jointLength, 0, 0), Quaternion.identity);
            allJoints.Add(newSegment.GetComponent<SpringJoint2D>());

            newSegment.GetComponent<SpringJoint2D>().connectedBody = previous.GetComponent<Rigidbody2D>();
            newSegment.GetComponent<SpringJoint2D>().distance = jointLength;

            previous = newSegment;
        }

        otherPlayer.GetComponent<SpringJoint2D>().connectedBody = previous.GetComponent<Rigidbody2D>();
        otherPlayer.GetComponent<SpringJoint2D>().distance = jointLength;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            
        }
                if(Input.GetKey(KeyCode.DownArrow)) {
                    jointLength -= 0.001f;
                }

                if(Input.GetKey(KeyCode.UpArrow)) {
                    jointLength += 0.001f;
                }

                if(jointLength < minLength) {
                    jointLength = minLength;
                }
            

        foreach(SpringJoint2D joint in allJoints) {
            joint.distance = jointLength;
        }
    }
}
