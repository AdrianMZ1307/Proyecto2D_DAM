using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPC : MonoBehaviour
{
    private playerController parentScript;

    [SerializeField]
    private GameObject mobileControls;
    [SerializeField]
    private GameObject restartIndicators;
    [SerializeField]
    private GameObject otherRestartIndicators;

    void Awake()
    {
        parentScript = GetComponent<playerController>();
        mobileControls.SetActive(false);
        //restartIndicators.SetActive(true);
        //otherRestartIndicators.SetActive(false);

    }

    void Start()
    {
#if !(UNITY_STANDALONE || UNITY_WEBGL)
        Destroy(this);
        return;
#endif
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            parentScript.Jump(true);
        }
        if (!Input.GetKey(KeyCode.UpArrow))
        {
            parentScript.Jump(false);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            parentScript.Crouch(true);
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            parentScript.Crouch(false);
        }
    }
}
