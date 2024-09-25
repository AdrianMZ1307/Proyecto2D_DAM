using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMobile : MonoBehaviour
{

    private playerController parentScript;

    [SerializeField]
    private GameObject mobileControls;
    [SerializeField]
    private GameObject restartIndicators;
    [SerializeField]
    private GameObject otherRestartIndicators;
    private gameController gc;
    void Start()
    {
#if (UNITY_STANDALONE || UNITY_WEBGL)
        Destroy(this);
        return;
#endif
        GameObject goController = GameObject.FindGameObjectWithTag("gController");
        if (goController != null)
        {
            gc = goController.GetComponent<gameController>();
        }
        gc.mobile = true;
        parentScript = GetComponent<playerController>();
        mobileControls.SetActive(true);
        //restartIndicators.SetActive(true);
        //otherRestartIndicators.SetActive(false);
    }

    public void Jumping(bool val)
    {
        parentScript.Jump(val);
    }

    public void Crouching(bool val)
    {
        parentScript.Crouch(val);
    }
}
