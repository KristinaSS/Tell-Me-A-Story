using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharachters : MonoBehaviour
{
    public GameObject avatar1, avatar2, avatar3;


    void Start()
    {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);

    }

    public void SwitchAvatarOne()
    {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);

    }

    public void SwitchAvatarTwo()
    {
        avatar1.gameObject.SetActive(false);
        avatar2.gameObject.SetActive(true);
        avatar3.gameObject.SetActive(false);

    }

    public void SwitchAvatarThree()
    {
        avatar1.gameObject.SetActive(false);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(true);
    }
}
