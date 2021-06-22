using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DMovingController : MonoBehaviour
{
    private Transform characterTransform;
    private Animator characterAnimator;
    private Rigidbody characterRigibody;
    private float vh = 0, vv = 0, sv = 0, svv = 100, jump = 0, jv = 0;

    public GameObject sword;
    public GameObject character;

    private void Start()
    {
        SetCharacterProperty(character, sword);
    }

    public void Update()
    {
        sv = GetAngle(character.transform.position, Input.mousePosition);
        Vector3 mp = Input.mousePosition - (new Vector3(1920 / 2, 1080 / 2));
        sword.transform.localRotation = Quaternion.Lerp(sword.transform.localRotation,
            Quaternion.FromToRotation(Vector3.right, mp.normalized), 0.1f);
        //Debug.Log(Input.mousePosition-(new Vector3(1920/2,1080/2)));
        //if (sv == 0)
        //{
        //    //sv = Random.Range(-360, 360);

        //    if (svv == 600)
        //    {
        //        svv = 100;
        //    }
        //}
        //else if (sv > 0)
        //{
        //    sv -= Time.deltaTime * svv;
        //    if (sv < 0)
        //        sv = 0;
        //    sword.transform.localRotation *= Quaternion.AngleAxis(Time.deltaTime * svv, Vector3.forward);
        //}
        //else if (sv < 0)
        //{
        //    sv += Time.deltaTime * svv;
        //    if (sv > 0)
        //        sv = 0;
        //    sword.transform.localRotation *= Quaternion.AngleAxis(-Time.deltaTime * svv, Vector3.forward);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            //sword.transform.localRotation = Quaternion.AngleAxis(0, Vector3.up);
            //sv = 360;
            //svv = 600;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //characterRigibody.AddRelativeForce(new Vector3(0, 200, 0));
        }

        vh = Input.GetAxis("Horizontal") * 20;
        vv = Input.GetAxis("Vertical") * 20;


        if (vv > 0)
            characterAnimator.SetInteger("direction", 1);
        if (vv < 0)
            characterAnimator.SetInteger("direction", 2);
        if (vh < 0)
            characterAnimator.SetInteger("direction", 3);
        if (vh > 0)
            characterAnimator.SetInteger("direction", 4);
        if (vh == 0 && vv == 0)
            characterAnimator.SetInteger("direction", 0);
        //characterTransform.position += (Vector3.right * vh + Vector3.forward * vv + Vector3.up * jv) * Time.deltaTime * 0.5f;
        characterRigibody.AddRelativeForce(new Vector3(vh, vv, 0) * Time.deltaTime, ForceMode.VelocityChange);

        //Debug.Log(characterRigibody.velocity);
        if (characterRigibody.velocity.x > 2)
            characterRigibody.velocity = new Vector3(2, characterRigibody.velocity.y, characterRigibody.velocity.z);
        if (characterRigibody.velocity.x < -2)
            characterRigibody.velocity = new Vector3(-2, characterRigibody.velocity.y, characterRigibody.velocity.z);
        if (characterRigibody.velocity.y > 2)
            characterRigibody.velocity = new Vector3(characterRigibody.velocity.x, 2, characterRigibody.velocity.z);
        if (characterRigibody.velocity.y < -2)
            characterRigibody.velocity = new Vector3(characterRigibody.velocity.x, -2, characterRigibody.velocity.z);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SetCharacterProperty(GameObject character, GameObject sword)
    {
        characterTransform = character.GetComponent<Transform>();
        characterAnimator = character.GetComponent<Animator>();
        characterRigibody = character.GetComponent<Rigidbody>();
        vh = 0;
    }

    private float GetAngle(Vector3 a, Vector3 b)
    {
        b.x -= a.x;
        b.y -= a.y;

        float deltaAngle = 0;
        if (b.x == 0 && b.y == 0)
        {
            return 0;
        }
        else if (b.x > 0 && b.y > 0)
        {
            deltaAngle = 0;
        }
        else if (b.x > 0 && b.y == 0)
        {
            return 90;
        }
        else if (b.x > 0 && b.y < 0)
        {
            deltaAngle = 180;
        }
        else if (b.x == 0 && b.y < 0)
        {
            return 180;
        }
        else if (b.x < 0 && b.y < 0)
        {
            deltaAngle = -180;
        }
        else if (b.x < 0 && b.y == 0)
        {
            return -90;
        }
        else if (b.x < 0 && b.y > 0)
        {
            deltaAngle = 0;
        }

        float angle = Mathf.Atan(b.x / b.y) * Mathf.Rad2Deg + deltaAngle;
        return angle;
    }
}
