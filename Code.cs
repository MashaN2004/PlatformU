using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Code : MonoBehaviour
{
    Rigidbody rb;
    Transform transf;
    float vert;
    float horz;
    float jump = 15f;
    bool isGround = false;
    static int kol = 0;
    [SerializeField] TextMeshProUGUI textt;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transf = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        vert = Input.GetAxis("Vertical");
        horz = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("space") && isGround == true)
        {

            rb.AddForce(0, jump, 0, ForceMode.Impulse);
        }
        rb.AddRelativeForce(0, 0, vert * 40f);
        transf.Rotate(0, horz, 0);

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Graund")
        {
            rb.drag = 0;
            rb.angularDrag = 0;
            print("gg");
            isGround = true;
        }
        if (col.gameObject.tag == "prize")
        {
            kol += 1;
            print(kol);
            textt.text = "Score: " + kol;
            Destroy(col.gameObject);

        }
        if (kol == 3)
        {
            textt.text = "You win";
        }
        if (col.gameObject.tag == "no")
        {
            textt.text = "You lose";
        }

    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Graund")
        {
            rb.drag = 2;
            rb.angularDrag = 2;
            isGround = false;
        }
    }
}

