using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.MaterialProperty;

public class GameManager : MonoBehaviour
{        
    // �����迭 : ũ�Ⱑ ������ �迭, �Ϲ������� ���� �迭
    int[] intArray = new int[5];    
    // c++������ ����Ʈ�� ��ũ�帮��Ʈ�� �ǹ�
    List<int> ints = new List<int>(); // List�� ����Ÿ��, null�� ����Ű�� �ֱ� ������ �������� �Ҵ��ϰ� �� �Ҵ�� ���� �ּҸ� ���� �޾ƿ;�(�ʱ�ȭ) �Ѵ�. �����迭�� ���ʸ� ����
    ArrayList ArrayList = new ArrayList(); // ������ �����ʴ� �����迭, �� �����迭�� �����ʸ� ����    
    // boxing ������ ���·� �ö󰡴� ����( ���� �ö󰥼��� �߻�ȭ)    

    Queue<int> intQueue = new Queue<int>();    
    Stack<int> intStack = new Stack<int>();    

    Dictionary<int, string> textDic = new Dictionary<int, string>();
    Hashtable hashtable = new Hashtable();

    void Start()
    {
        textDic.Add(112, "������");        
        textDic.Add(119, "�ҹ漭");
        


        ArrayList.Add((object)10); // �ڽ�, (c++�� ��ĳ����) �ؼ� ������ (���ʿ� ���͵��� object��) �� �Լ������� ��ڽ��ؼ� ���� �����ִ� ��
        ArrayList.Add("sad");
        ArrayList.Add(30);
        ArrayList.Add(transform.position);
        ArrayList.Add(50);
        Debug.Log(ArrayList[3]);
        
        int num = 10;
        object obj = (object)num; // num�̶�� ���� int�ε� ������ ����(�� �����θ�)�� �ڽ̵Ǽ� ��, object���·� ����ȯ(�ڽ�) - �̶��� ��������� �����ʿ����
        int numB = 10 + (int)obj; // int�� �ٿ�ĳ����, �� ��ڽ� ������Ѵ�. �ѱ涧��, �� �ڽ��Ҷ� �������̾ ���������(��ó��) ����Ҷ�, �� ��ڽ��Ҷ� ���������� ������������ ���־�� �Ѵ�. 
        // ex)
        Debug.Log("dsa"); // ��� ������ ���� �ڽ��ؼ�(object)�� �־���, �ȿ��� ����׷α׸� ���� �� ��ڽ�����

        for(int i = 0; i < 10; i++)
        {
            int inputValue = i * 10;
            ints.Add(inputValue);
            intQueue.Enqueue(inputValue);
            intStack.Push(inputValue);
        }

        
        

        

        //for(int i = 0; i < ints.Count; i++) // List�� ��� ���� ���
        //{
        //    Debug.Log(ints[i]);
        //}

        //while (intQueue.Count > 0)
        //{
        //    Debug.Log(intQueue.Dequeue());
        //}

        //while (intStack.Count > 0)
        //{
        //    Debug.Log(intStack.Pop());
        //}

        //foreach (int value in intStack) // �÷����� ������� ��µ�, stack�� 90���� ��µǴ� �����ϱ� ���⼭���� 90���� ����̵�, ���⿡ �����³���� ������ �������־����
        //{
        //    Debug.Log($"���� {value}");
        //} // foreach�� ���� �÷��Ǹ� �ٲ��൵ ����

        //foreach (int value in intQueue)
        //{
        //    Debug.Log($"ť {value}");
        //}

        //foreach (int value in ints) // IEnumrable�� ������ �ִ� ��鸸 in �� ���� �ִ�. �� ���� ������ �ִٴ� �ǹ̴� ������ ������ �ִٴ� �ǹ�
        //{
        //    Debug.Log($"����Ʈ {value}");
        //}









    }
}
