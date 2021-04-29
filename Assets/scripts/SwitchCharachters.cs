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

    public void SwitchAvatarKrisi()
    {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);

    }

    public void SwitchAvatarIvo()
    {
        avatar1.gameObject.SetActive(false);
        avatar2.gameObject.SetActive(true);
        avatar3.gameObject.SetActive(false);

    }

    public void SwitchAvatarYuli()
    {
        avatar1.gameObject.SetActive(false);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(true);

    }
}
