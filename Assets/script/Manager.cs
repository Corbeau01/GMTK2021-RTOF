using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    public bool ActivePlayerKazoo = true;
    public GameObject Kazzoo;
    public GameObject Aza;
    public GameObject KazzooFX;
    public GameObject AzaFX;
    public Transform StartPosition;
    bool ISResetingPositions;
    public GameObject MenuGo;
    bool Menustatre = false;
    private void Start()
    {
        SetActivation();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.F1))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Menustatre = !Menustatre;
            MenuGo.SetActive(Menustatre);
        }
        CheckForDeath();
        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            ActivePlayerKazoo = !ActivePlayerKazoo;
            SetActivation();
        }
        if(ISResetingPositions)
        {
            Kazzoo.transform.position = StartPosition.position;
            Aza.transform.position = StartPosition.position + new Vector3(-2f, 0f, 0f);
            Kazzoo.GetComponent<rope>().ResetRope();
            Kazzoo.GetComponent<DeathTrigger>().InDeadZone = false;
            Aza.GetComponent<DeathTrigger>().InDeadZone = false;
            ISResetingPositions = false;
            Kazzoo.GetComponent<DeathTrigger>().Death = false;
            Aza.GetComponent<DeathTrigger>().Death = false;
        }
    }
    void SetActivation()
    {
        if (ActivePlayerKazoo)
        {
            Kazzoo.GetComponent<PlayerController>().IsActivated = true;
            Aza.GetComponent<PlayerController>().IsActivated = false;
            FindObjectOfType<CameraFollow>().ActivePlayer = Kazzoo.transform;
            KazzooFX.SetActive(true);
            AzaFX.SetActive(false);
        }
        else
        {
            Aza.GetComponent<PlayerController>().IsActivated = true;
            Kazzoo.GetComponent<PlayerController>().IsActivated = false;
            FindObjectOfType<CameraFollow>().ActivePlayer = Aza.transform;
            AzaFX.SetActive(true);
            KazzooFX.SetActive(false);
        }
    }
    void CheckForDeath()
    {
        if(Kazzoo.GetComponent<DeathTrigger>().InDeadZone&&Aza.GetComponent<DeathTrigger>().InDeadZone)
        {
            ISResetingPositions = true;
            
        }
        if (Kazzoo.GetComponent<DeathTrigger>().Death)
        {
            ISResetingPositions = true;
        }
    }
}
