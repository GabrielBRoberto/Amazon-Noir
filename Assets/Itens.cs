using UnityEngine.UI;
using UnityEngine;

public class Itens : MonoBehaviour
{
    [SerializeField]
    GameObject[] ObjetosNoPlayer;
    [SerializeField]
    GameObject[] ObjetosNoMapa;
    [SerializeField]
    GameObject[] Pistas;

    [SerializeField]
    Image[] pistasColetadasUI;
    [SerializeField]
    AudioSource[] efeitosSonoros;

    public GameObject finalCutScene;

    bool LanternaIsActived;
    bool MachadoIsActived;
    bool PeDeCabraIsActived;
    bool CordaIsActived;

    bool LanternaIsOnPlayer;
    bool MachadoIsOnPlayer;
    bool PeDeCabraIsOnPlayer;
    bool CordaIsOnPlayer;

    bool hasItem;

    float timer = 3f;

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
        for (int i = 0; i < pistasColetadasUI.Length; i++)
        {
            pistasColetadasUI[i].enabled = false;
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
        if (hasItem)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
        }
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
                    
                    efeitosSonoros[4].Play();
                    if(timer < 0)
                    {
                        efeitosSonoros[4].Stop();
                        timer = 3;
                    }
                }
            }
            if (other.gameObject.tag == "Machado")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    MachadoIsActived = true;
                    efeitosSonoros[4].Play();
                    if (timer < 0)
                    {
                        efeitosSonoros[4].Stop();
                        timer = 3;
                    }
                }
            }
            if (other.gameObject.tag == "Pe de cabra")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    PeDeCabraIsActived = true;
                    efeitosSonoros[4].Play();
                }
            }
            if (other.gameObject.tag == "Corda")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    CordaIsActived = true;
                    efeitosSonoros[4].Play();
                    if (timer < 0)
                    {
                        efeitosSonoros[4].Stop();
                        timer = 3;
                    }
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
                    efeitosSonoros[1].Play();
                    if (timer < 0)
                    {
                        efeitosSonoros[1].Stop();
                        timer = 3;
                    }
                }
            }
            if (PeDeCabraIsOnPlayer && other.gameObject.tag == "ObstaculoPeDeCabra")
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    other.gameObject.SetActive(false);
                    efeitosSonoros[2].Play();
                    if (timer < 0)
                    {
                        efeitosSonoros[2].Stop();
                        timer = 3;
                    }
                }
            }
            if (CordaIsOnPlayer)
            {
                if (other.gameObject.tag == "CordaDescer1")
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        gameObject.transform.position -= new Vector3(1.079f, 2.1f, 0);
                        efeitosSonoros[3].Play();
                        if (timer < 0)
                        {
                            efeitosSonoros[2].Stop();
                            timer = 3;
                        }
                    }
                }
                if (other.gameObject.tag == "CordaDescer2")
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        gameObject.transform.position -= new Vector3(1.03f, 2.1f, .69f);
                        efeitosSonoros[3].Play();
                    }
                }
                if (other.gameObject.tag == "CordaDescer3")
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        gameObject.transform.position -= new Vector3(.98f, 2.1f, .73f);
                        efeitosSonoros[3].Play();
                    }
                }
                if (other.gameObject.tag == "CordaDescer4")
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        gameObject.transform.position -= new Vector3(-.99f, 2.1f, -.56f);
                        efeitosSonoros[3].Play();
                    }
                }
                if (other.gameObject.tag == "CordaSubir1")
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        gameObject.transform.position += new Vector3(1.079f, 2.1f, 0);
                        efeitosSonoros[3].Play();
                    }
                }
                if (other.gameObject.tag == "CordaSubir2")
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        gameObject.transform.position += new Vector3(1.03f, 2.1f, .69f);
                        efeitosSonoros[3].Play();
                    }
                }
                if (other.gameObject.tag == "CordaSubir3")
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        gameObject.transform.position += new Vector3(.98f, 2.1f, .73f);
                        efeitosSonoros[3].Play();
                    }
                }
                if ( other.gameObject.tag == "CordaSubir4")
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        gameObject.transform.position += new Vector3(-.99f, 2.1f, -.56f);
                        efeitosSonoros[3].Play();
                    }
                } 
            }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pistas")
        {
            Debug.Log("Pista coletada");
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
            
            int j = 0;
            pistasColetadasUI[j].enabled = true;
            j++;

            other.gameObject.SetActive(false);

            for (int i = 0; i < pistasColetadasUI.Length; i++)
            {
                if(pistasColetadasUI[i].enabled == true)
                {
                    finalCutScene.GetComponent<DialogueTrigger>().TriggerDialogue();
                }
            }
        }
    }
}
