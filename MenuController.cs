
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

/// <summary>
/// Tutorial on Pause with time: 
/// http://www.asteroidbase.com/devlog/9-pausing-without-pausing/
/// </summary>


public class MenuController : MonoBehaviour
{
    [Header("Mouse Menu")]
    public GameObject Navigation;
    public Button HidePanel;
    public Image ShowIcon;
    

    [Header("Turntable")]
    [SerializeField]
    private float TurnSpeed = 5f;
    public GameObject Turntable;
    public Button TurntableButton;
    public Quaternion originalRotation;


    [Header("Animation")]
    public Animator animator;
    public Transform my3DModel;
    public Animator animationEnd;

    public Button playBtn;
    public Button pausBtn;
    public Button stopBtn;
    public PlayableDirector director;
    public GameObject animateCamera;
    public AudioSource Audio;
    public GameObject logo;

    private Vector3 AnimPosition;
    private Quaternion AnimRotation;


    [Header("Camera View")]
    public GameObject cameraTop;
    public GameObject cameraMain;
    public GameObject anCam;

    public Button mainBtn;
    public Button topBtn;
    public Button animBtn;

    private bool isTurning;
    private bool stop = true;
    private bool playBack;
    private bool pause;
    private bool panelActive;
    bool cam;



    void Start()
    {
        animator = my3DModel.GetComponent<Animator>();
        animator.enabled = false;
        animateCamera.SetActive(false);

        pausBtn.GetComponent<Button>().enabled = false;
        pausBtn.GetComponent<Image>().enabled = false;

        cameraTop.SetActive(false);
        cameraMain.SetActive(true);
        anCam.SetActive(false);

        Navigation.SetActive(true);

        originalRotation = transform.rotation;
        ShowIcon.enabled = false;

        director.GetComponent<PlayableDirector>();

        this.AnimPosition = this.transform.position;
        this.AnimRotation = this.transform.rotation;

    }


    void OnEnable()
    {

        TurntableButton.onClick.AddListener(TurnBtn); // stopknapp - reset rotation 

        playBtn.onClick.AddListener(playAnim);
        pausBtn.onClick.AddListener(pauseAnim);
        stopBtn.onClick.AddListener(stopAnim);

        HidePanel.onClick.AddListener(MouseBtn);
      
        mainBtn.onClick.AddListener(mainCam);
        topBtn.onClick.AddListener(topCam);
        animBtn.onClick.AddListener(animCam);

    }

    private void Update()
    {

        if (isTurning)
        {

            Turntable.transform.Rotate(0, TurnSpeed, 0);

            print("Turning");
        }



        if (panelActive) 
        {
            Navigation.SetActive(false);
            print("Menu Disable");

            ShowIcon.enabled = true; 
        }

        else if (!panelActive)
        {
            Navigation.SetActive(true);
            print("Menu active");
        }


        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    public void MouseBtn()
    {
        panelActive = !panelActive;
    }

    public void TurnBtn()
    {
        isTurning = !isTurning;
    }

    public void playAnim()
    {

        if (isTurning)
        {
            isTurning = false;
            Turntable.transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, 0);
        }



        logo.SetActive(true);

        animateCamera.SetActive(true);

        playBtn.GetComponent<Button>().enabled = false;
        playBtn.GetComponent<Image>().enabled = false;

        pausBtn.GetComponent<Button>().enabled = true;
        pausBtn.GetComponent<Image>().enabled = true;

        animator.enabled = true;
        animator.speed = 1;

        Audio.Play();
        director.Play();

        print("Play");

    }

    public void resetTransform()
    {
        if (playBack)
        {
            this.transform.position = this.AnimPosition;
            this.transform.rotation = this.AnimRotation;
        }

    }

    public void pauseAnim()
    {
        playBtn.GetComponent<Button>().enabled = true;
        playBtn.GetComponent<Image>().enabled = true;

        pausBtn.GetComponent<Button>().enabled = false;
        pausBtn.GetComponent<Image>().enabled = false;

        animator.enabled = false;

        Audio.Pause();

        director.Pause();

        print("pause");
    }


    void stopAnim()
    {
        cameraMain.SetActive(true);
        animateCamera.SetActive(false);

        playBtn.GetComponent<Button>().enabled = true;
        playBtn.GetComponent<Image>().enabled = true;

        pausBtn.GetComponent<Button>().enabled = false;
        pausBtn.GetComponent<Image>().enabled = false;


        animator.enabled = true;

        animator.speed = 0;
        animator.Play("animation001", 0, 0f);

        Audio.Stop();
        director.Stop();

        director.Evaluate();

        print("stop");


    }



    void mainCam()
    {
        cameraTop.SetActive(true);
        cameraMain.SetActive(false);
        anCam.SetActive(false);

        TurntableButton.GetComponent<Button>().enabled = false;
        Turntable.transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, 0);
        isTurning = false;
    }

    void topCam()
    {
        cameraTop.SetActive(false);
        cameraMain.SetActive(true);
        anCam.SetActive(false);

        TurntableButton.GetComponent<Button>().enabled = true;


    }

    void animCam()
    {
        cameraTop.SetActive(false);
        cameraMain.SetActive(false);
        anCam.SetActive(true);

    }


}