using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class sizePlayer : MonoBehaviour
{
    public GameObject player;

    public int life;

    public bool changed;

    public bool hitted;

    bool meleHitted;

    float invulnerabilityTime;
    bool isInvulnerable;

    public GameObject deathMenu;

    public ParticleSystem hitParticles;

    [SerializeField]
    Image marcoHud;
    //Sounds
    public AudioSource evaporation;
    public AudioSource music;


    //Hited Feedback
    Vector3 initialCameraZoomPos;
    Vector3 zoomedCameraZoomPos;
    GameObject cameraZoomCambiar;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        cameraZoomCambiar = GameObject.FindGameObjectWithTag("Camera");
        initialCameraZoomPos = cameraZoomCambiar.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
        Debug.Log(initialCameraZoomPos);
        zoomedCameraZoomPos = initialCameraZoomPos * 0.85f;

        Time.timeScale =1;
       
        life = 3;
        changed = false;
        hitted = false;
        meleHitted = false;
        invulnerabilityTime = 0;
        isInvulnerable = false;
    }
    float timePassed = 0;
    float maxTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
       
        if (life == 5 && !changed)
        {
            marcoHud.color = new Color(0, 255, 255,255);
            player.transform.localScale = new Vector3(140f, 140f, 140f);
            changed = true;
        }
        if (life == 4 && !changed)
        {
            marcoHud.color = new Color(0, 200, 255,255);
            player.transform.localScale = new Vector3(120f, 120f, 120f);
            changed = true;
        }
        if (life == 3 && !changed)
        {
            marcoHud.color = new Color(0,150,255, 255);
            player.transform.localScale = new Vector3(100f, 100f, 100f);
            changed = true;
        }
        if (life == 2 && !changed)
        {
            marcoHud.color = new Color(0, 80, 180,255);
            player.transform.localScale = new Vector3(80f, 80f, 80f);
            changed = true;
        }
        if (life == 1 && !changed)
        {
            marcoHud.color = new Color(0, 13, 130,255);
            player.transform.localScale = new Vector3(60f, 60f, 60f);
            changed = true;
        }
        if (life <= 0)
        {
            if(timePassed < maxTime)
            {
                timePassed += Time.deltaTime;
            }
            Time.timeScale = Mathf.Lerp(1, 0.05f, timePassed / maxTime);

            Death();
        }
        //Debug.Log(life);
        if (Input.GetKeyDown("k"))
        {
            Death();
        }        
    }
    void HittedFeedbackZoom(float time)
    {
        Sequence hitZoomFeedback = DOTween.Sequence();
        hitZoomFeedback.Append(DOTween.To(() => initialCameraZoomPos, x => cameraZoomCambiar.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = x, zoomedCameraZoomPos, time));
        hitZoomFeedback.Append(DOTween.To(() => zoomedCameraZoomPos, x => cameraZoomCambiar.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = x, initialCameraZoomPos, time));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!isInvulnerable) 
            {
                HittedFeedbackZoom(0.09f);
                evaporation.Play();
                Instantiate(hitParticles, transform.position, transform.rotation);
                life--;
                changed = false;
                isInvulnerable = true;
                Invoke("Invulnerability", 1);
            }
        }
        if (other.CompareTag("BulletEnemy"))
        {
            if (!isInvulnerable)
            {
                HittedFeedbackZoom(0.09f);

                evaporation.Play();
                Instantiate(hitParticles, transform.position, transform.rotation);
                life--;
                changed = false;
                isInvulnerable = true;
                Invoke("Invulnerability", 1);
            }
        }
        if (other.CompareTag("Heal")) 
        {
            if (life <= 4) 
            {
                life++;
                changed = false;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            meleHitted = false;
        }
    }

    private void Death()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        music.Play();
        deathMenu.SetActive(true);
        //Destroy(player.transform.GetChild(0).gameObject);
        player.transform.parent.GetChild(1).gameObject.SetActive(false);
        player.GetComponent<Shooter>().enabled = false;
        player.GetComponent<Movement_2>().enabled = false;
       

    }

    void Invulnerability() 
    {
        isInvulnerable = false;
    }
    
}
