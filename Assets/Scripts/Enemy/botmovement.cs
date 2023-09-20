using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botmovement : MonoBehaviour
{
    public float speed,turnspeed;
     GameObject target;
    public GameObject[] checks;
    int index = 0;
    float timer=0;
   public bool ischasing=false;
   
   public bool isturning = false;
    public bool moveing;
   
    // Start is called before the first frame update
    void Start()
    {
        if(moveing)
        {
            target = checks[0];
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!ischasing)
        {
            if (moveing)
            {


                // Debug.Log(isturning);
                if (isturning)
                {
                    timer += Time.deltaTime;
                    var lookPos = target.transform.position - transform.position;
                    lookPos.y = 0;
                    var rotation = Quaternion.LookRotation(lookPos);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnspeed);
                    if (rotation == transform.rotation)
                    {
                        timer = 0;
                        isturning = false;
                    }
                    if (timer >= 0.5f)
                    {
                        timer = 0;
                        isturning = false;
                    }
                }
                else
                {

                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
                    if (transform.position == target.transform.position)
                    {

                        // Debug.Log(index);
                        if (index < checks.Length)
                        {

                            target = checks[index];
                            index++;
                        }
                        else
                        {
                            index = 0;
                            target = checks[index];
                        }
                        // Debug.Log(index);
                        isturning = true;

                    }
                }
            }
        }
    }
}
