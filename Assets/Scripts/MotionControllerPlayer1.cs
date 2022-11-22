using System;
using UnityEngine;
using UnityEngine.UI;



public class MotionControllerPlayer1 : MonoBehaviour
{


    private Vector3[] DirectionM = new Vector3[4];









    public float speed_time_rotation = 3;
    public float speed = 5.0f;
    public float cellSize = 2.0f;//размер ячейки, а также расстояни на которое нужно сдвинуться если была нажата кнопка
    bool isMoving = false;//находимся ли в движении
    GameObject Scr1;
    Vector3 direction;//направление движения
    Vector3 destPos;//позиция куда двигаемся


    [SerializeField] AudioClip MoveSound;
    [SerializeField] AudioClip WinSound;
    [SerializeField] AudioClip LoseSound;

    private AudioSource AudioSource1;


    public bool AudioIsEnabled = true;




    //    private bool isMoveEnd = false; // премещение закончено
    private bool KeyPressed = false; // новое движение
    private bool SoundStepPlayed = false; // новое движение

    private Rigidbody rb;
    int current_direktion = 0;
    int new_direktion = 0;
    private Vector3 newRotation;


    [HideInInspector] private Text Text__info003;
    [HideInInspector] private Text Text__info002;


    private void Start()
    {
        AudioSource1 = GetComponent<AudioSource>();

        Text__info002 = GameObject.Find("Text__info002").GetComponent<Text>();
        Text__info003 = GameObject.Find("Text__info003").GetComponent<Text>();

        DirectionM[0] = Vector3.forward;
        DirectionM[1] = Vector3.right;
        DirectionM[2] = -Vector3.forward;
        DirectionM[3] = -Vector3.right;



    }

    void Update()
    {


        if (isMoving && !SoundStepPlayed)
        {
            SoundStepPlayed = true;
            AudioSource1.PlayOneShot(MoveSound);
        }
        if (!isMoving && KeyPressed)
        {
            SoundStepPlayed = false;
            KeyPressed = false;
        }




        if (isMoving)
        {

            

            KeyPressed = false;

            float step = speed * Time.deltaTime;//расстояние, которое нужно пройти в текущем кадре
            transform.position = Vector3.MoveTowards(transform.position, destPos, step);//двигаем персонажа
                                                                                        //достигли нужной позиции - отключаем движение, включаем ловлю нажатых клавиш
            if (transform.position == destPos) isMoving = false;

            KeyPressed = true;

        }
        else
        {


            current_direktion = new_direktion;
            if (Input.GetKeyDown(KeyCode.W))
            {
                isMoving = true;
                new_direktion = 0;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                isMoving = true;
                new_direktion = 3;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                isMoving = true;
                new_direktion = 2;

            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                isMoving = true;
                new_direktion = 1;
            }
        }
    }
}