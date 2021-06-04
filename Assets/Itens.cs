using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itens : MonoBehaviour
{
    [SerializeField]
    GameObject[] ObjetosNoPlayer;
    [SerializeField]
    GameObject[] ObjetosNoMapa;
    [SerializeField]
    GameObject[] Pistas;

    bool LanternaIsActived;
    bool MachadoIsActived;
    bool PeDeCabraIsActived;
    bool CordaIsActived;

    bool LanternaIsOnPlayer;
    bool MachadoIsOnPlayer;
    bool PeDeCabraIsOnPlayer;
    bool CordaIsOnPlayer;

    bool hasItem;

    /*
     * Objetos
     * 
     * Lanterna
     * Machado
     * Pe de cabra
     * Corda
     *
     * Pistas
     * 
     * 1
     * 2
     * 3
     * 4
     * 5
     */

    private void Start()
    {
        for (int i = 0; i < ObjetosNoPlayer.Length; i++)
        {
            ObjetosNoPlayer[i].SetActive(false);
            ObjetosNoMapa[i].SetActive(true);

            Pistas[i].SetActive(true);
        }
        LanternaIsActived = false;
        MachadoIsActived = false;
        PeDeCabraIsActived = false;
        CordaIsActived = false;

        LanternaIsOnPlayer = false;
        MachadoIsOnPlayer = false;
        PeDeCabraIsOnPlayer = false;
        CordaIsOnPlayer = false;
    }
    private void FixedUpdate()
    {
        if (LanternaIsActived)
        {
            LanternaIsActived = false;
            ObjetosNoPlayer[0].SetActive(true);
            ObjetosNoMapa[0].SetActive(false);
            LanternaIsOnPlayer = true;
            hasItem = true;
        }
        if (MachadoIsActived)
        {
            MachadoIsActived = false;
            ObjetosNoPlayer[1].SetActive(true);
            ObjetosNoMapa[1].SetActive(false);
            MachadoIsOnPlayer=true;
            hasItem = true;
        }
        if (PeDeCabraIsActived)
        {
            PeDeCabraIsActived = false;
            ObjetosNoPlayer[2].SetActive(true);
            ObjetosNoMapa[2].SetActive(false);
            PeDeCabraIsOnPlayer = true;
            hasItem = true;
        }
        if (CordaIsActived)
        {
            CordaIsActived = false;
            ObjetosNoPlayer[3].SetActive(true);
            ObjetosNoMapa[3].SetActive(false);
            CordaIsOnPlayer = true;
            hasItem = true;
        }
        dropItem();
    }
    private void dropItem()
    {
        if (hasItem)
        {
            Vector3 position = transform.position;

            if (Input.GetKey(KeyCode.F))
            {
                hasItem = false;
                for (int i = 0; i < ObjetosNoPlayer.Length; i++)
                {
                    ObjetosNoPlayer[i].SetActive(false);
                }
                if (LanternaIsOnPlayer)
                {
                    LanternaIsOnPlayer = false;
                    ObjetosNoMapa[0].transform.position = position;
                    ObjetosNoMapa[0].SetActive(true);
                }
                if (MachadoIsOnPlayer)
                {
                    MachadoIsOnPlayer = false;
                    ObjetosNoMapa[1].transform.position = position;
                    ObjetosNoMapa[1].SetActive(true);
                }
                if (PeDeCabraIsOnPlayer)
                {
                    PeDeCabraIsOnPlayer = false;
                    ObjetosNoMapa[2].transform.position = position;
                    ObjetosNoMapa[2].SetActive(true);
                }
                if (CordaIsOnPlayer)
                {
                    CordaIsOnPlayer = false;
                    ObjetosNoMapa[3].transform.position = position;
                    ObjetosNoMapa[3].SetActive(true);
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!hasItem)
        {
            if (other.gameObject.tag == "Lanterna")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    LanternaIsActived = true;
                }
            }
            if (other.gameObject.tag == "Machado")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    MachadoIsActived = true;
                }
            }
            if (other.gameObject.tag == "Pe de cabra")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    PeDeCabraIsActived = true;
                }
            }
            if (other.gameObject.tag == "Corda")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    CordaIsActived = true;
                }
            }
        }

        if (hasItem)
        {
            if (MachadoIsOnPlayer && other.gameObject.tag == "ObstaculoMachado")
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    other.gameObject.SetActive(false);
                }
            }
            if (PeDeCabraIsOnPlayer && other.gameObject.tag == "ObstaculoPeDeCabra")
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    other.gameObject.SetActive(false);
                }
            }
            if (CordaIsOnPlayer && other.gameObject.tag == "ObstaculoCorda")
            {
                //Função da corda
            }
        }

        if (other.gameObject.tag == "Pistas")
        {
            Debug.Log("Pista coletada");
            other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Lanterna")
        {
            LanternaIsActived = false;
        }
        if (other.tag == "Machado")
        {
            MachadoIsActived = false;
        }
        if (other.gameObject.tag == "Pe de cabra")
        {
            PeDeCabraIsActived = false;
        }
        if (other.tag == "Corda")
        {
            CordaIsActived = false;
        }
    }
}
