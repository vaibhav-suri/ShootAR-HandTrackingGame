using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetcollider : MonoBehaviour
{
    float speed = 1f;
    float delta = 3f;
    public int decider=1;
    public int health;
    public bool flag;
    public float initialpos;
    public AudioSource hitsound;
    public GameObject explosiontime;
    public IEnumerator destroy(GameObject missile)
    {
        yield return new WaitForSeconds(3f);
        Destroy(missile);
    }
    // Start is called before the first frame update
    void Start()
    {
        initialpos = transform.position.x;
    }
      void OnCollisionEnter(Collision collision)
    {
        hitsound.Play();
        if(collision.collider.tag=="tip")
        {
            print("collide");
            //  collision.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
            //     child.transform.SetParent(newParent);
      //      collision.collider.gameObject.transform.parent = this.gameObject.transform;
            collision.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.collider.gameObject.transform.parent = this.transform;
            //     collision.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            health = health - 1;

        }
        if (collision.collider.tag == "rocket")
        {
            print("rocket");
            collision.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            collision.collider.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
            collision.collider.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            StartCoroutine(destroy(collision.collider.gameObject));
           health= health - 3;
        }
        if(health<=0)
        {
            collision.collider.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();

        }
    }
    // Update is called once per frame
    void Update()
    {
       
        if (flag)
        {
            transform.LookAt(Camera.main.transform);

            if (health > 0)
            {
                float y = Mathf.PingPong(speed * Time.time, delta);
                // decider = decider * -1; 
                Vector3 pos = new Vector3(initialpos + Mathf.Sin(Time.time * 1f) * decider * y, y, transform.position.z);
                transform.position = pos;
            }
            else
            {
                var go = Instantiate(explosiontime, this.transform);
                go.SetActive(true);
                go.transform.parent = GameObject.FindGameObjectWithTag("Ball").transform;
                Destroy(this.gameObject);
            }
        }
    }
}
