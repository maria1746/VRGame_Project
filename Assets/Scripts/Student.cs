using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Student : MonoBehaviour
{
    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    NavMeshAgent nav;
    Animator anim;
    GameObject person;
    AudioSource audioCovidSource;
    AudioSource audioVaccinatedSource;
    GameObject nowCovid;
    GameObject nowVaccinated;

    private bool isChase;
    private float dist;

    private int forBlink;

    public Transform target;
    public Transform rndTarget;
    public AudioClip audioGetCovid19;
    public AudioClip audioVaccinated;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponentInChildren<MeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        this.audioCovidSource = GameObject.Find("Student/GetCovidSound").GetComponent<AudioSource>();
        this.audioVaccinatedSource = GameObject.Find("Student/VaccinatedSound").GetComponent<AudioSource>();

        nowCovid = GameObject.Find(gameObject.name + "/RedSpiral");
        nowCovid.SetActive(false);
        nowVaccinated = GameObject.Find(gameObject.name + "/BlueSpiral");
        nowVaccinated.SetActive(false);

        // 학생, 적이든 5초마다 목표 바꿈
        InvokeRepeating("ChangeTarget", 0f, 5f);
    }

    void ChangeTarget()
    {
        if (gameObject.tag == "Student" || gameObject.tag == "Vaccinated")
        {
            int ran = Random.Range(1, 9);
            rndTarget = GameObject.Find("InducingCube/Inducing" + ran).transform;
            isChase = true;
        }

        if (gameObject.tag == "Enemy")
        {
            int ran = Random.Range(1, 9);
            rndTarget = GameObject.Find("InducingCube/Inducing" + ran).transform;
            target = FoundStudent();
            isChase = true;
        }
    }

    Transform FoundStudent()
    {
        float distFromMe = 100000f;
        int tempIndex = 0; 
        for (int i = 1; i < 16; i++)
        {
            GameObject student = GameObject.Find("Student/Student" + i);

            if (student.tag == "Student")
            {
                float tempDist = Vector3.Distance(student.transform.position, gameObject.transform.position);

                if (distFromMe > tempDist)
                {
                    distFromMe = tempDist;
                    tempIndex = i;
                }
            }
        }

        if (tempIndex != 0)
        {
            return GameObject.Find("Student/Student" + tempIndex).transform;
        }
        else
        {
            return GameObject.Find("Environment/Plane").transform;
        }
    }

    void Update()
    {
        // 학생인 경우
        if (gameObject.tag == "Student" || gameObject.tag == "Vaccinated") {
            if (gameObject.tag == "Vaccinated")
            {
                // 파란 동전 깜빡임
                if (forBlink < 100)
                {
                    if (forBlink < 80)
                    {
                        nowVaccinated.SetActive(false);
                        forBlink++;
                    }
                    else
                    {
                        nowVaccinated.SetActive(true);
                        forBlink++;
                    }

                    if (forBlink == 100)
                    {
                        forBlink = 0;
                    }
                }
            }

            if (isChase)
            {
                nav.SetDestination(rndTarget.position);
                anim.SetBool("isWalk", true);
            }
            else
            {
                anim.SetBool("isWalk", false);
            }

            
        }

        // 적인 경우
        if (gameObject.tag == "Enemy")
        {
            // 빨간 동전 깜빡임
            if (forBlink < 100)
            {
                if (forBlink < 80)
                {
                    nowCovid.SetActive(false);
                    forBlink++;
                } 
                else
                {
                    nowCovid.SetActive(true);
                    forBlink++;
                }
                
                if (forBlink == 100)
                {
                    forBlink = 0;
                }
            }

            if (isChase)
            {
                dist = Vector3.Distance(target.transform.position, gameObject.transform.position);

                if (dist < 15 && target.tag == "Student")
                {
                    anim.SetBool("isWalk", true);
                    nav.SetDestination(target.position);
                }
                else
                {
                    anim.SetBool("isWalk", true);
                    nav.SetDestination(rndTarget.position);
                }
            }
            else
            {
                anim.SetBool("isWalk", false);
            }
        }
    }

    void FreezeVelocity()
    {
        if (isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        FreezeVelocity();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Enemy" && collision.gameObject.tag == "Student")
        {
            person = collision.gameObject;

            anim.SetBool("isAttack", true);

            collision.gameObject.tag = "Enemy";

            //audioCovidSource.clip = audioGetCovid19;
            audioCovidSource.Play();

            GameObject.Find("Canvas").GetComponent<Score>().isCovid++;
            GameObject.Find("Canvas").GetComponent<Score>().initScore = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("isAttack", false);
        anim.SetBool("isWalk", true);
    }

    public void healing()
    {
        if (gameObject.tag == "Student")
        {
            gameObject.tag = "Vaccinated";

            GameObject.Find("Canvas").GetComponent<Score>().isVaccinated++;
            GameObject.Find("Canvas").GetComponent<Score>().initScore = true;

            //audioVaccinatedSource.clip = audioVaccinated;
            audioVaccinatedSource.Play();
        }
    }
}
