using UnityEngine;
using System.Collections;

public class MuteHealth : MonoBehaviour
{
    public static float playerHealth = 100; // �÷��̾�(��Ʈ)�� �ִ� ü��
    public ParticleSystem muteDie; // �ذ� ��ƼŬ �ý����� �ޱ����� ����
    public GameObject menuSet; // �׾��� ���� UI�� ������
    public AudioClip sound; // ȿ������
    public GameObject dieTitle; // �׾��� ���� ����ǥ��
    public static bool playerLose = false;
    private bool execute = true; // �ذ� ��ƼŬ �ý����� �ѹ��� �����ϰ� ���� �ϱ����� ����

    void Start()
    {
        playerHealth = 100; // �����϶� ü�� 100���� ���� �������� �ʿ䰡���� �׷� ü���� 1�� ���ְ���
        playerLose = false; // escŰ�� ������ ���͵Ǵ� �޴��� ǥ������ �ʰ��ϱ� ���� ������. true�� Ȱ��ȭ �Ұ�
    }

    void Update()
    {
        if (playerHealth == 0) // ü���� 0������ �������� �Ǹ�
        {            
            execute = false; 
            playerHealth = 1; // �ѹ��� ����ǰ� �ϱ����ؼ� ü���� 100���� �ٲ������. 0�� �ƴϸ� �ȴ�.
        }

        if (execute == false)
        {
            audio.PlayOneShot(sound);
            playerLose = true; // esc�޴��� Ȳ��ȭ ���� ���ϰ� ���ƹ���
            Instantiate(muteDie, transform.position, transform.rotation); // �ذ� ��ƼŬ �ý����� �����Ѵ�.
            execute = true;
            StartCoroutine("menu");
        }
    }

    IEnumerator menu()
    {
        // �й������ÿ� Ÿ��Ʋ�� ����
        yield return new WaitForSeconds(1f);
        dieTitle.SetActive(true);
        menuSet.SetActive(true);
        Time.timeScale = 0; // �Ͻ�����
    }
}