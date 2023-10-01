using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.MaterialProperty;

public class GameManager : MonoBehaviour
{        
    // 정적배열 : 크기가 정해진 배열, 일반적으로 쓰던 배열
    int[] intArray = new int[5];    
    // c++에서의 리스트란 링크드리스트를 의미
    List<int> ints = new List<int>(); // List는 참조타입, null을 가리키고 있기 때문에 힙영역에 할당하고 그 할당된 놈의 주소를 먼저 받아와야(초기화) 한다. 가변배열의 제너릭 버전
    ArrayList ArrayList = new ArrayList(); // 꺽새가 붙지않는 가변배열, 즉 가변배열의 논제너릭 버전    
    // boxing 태초의 상태로 올라가는 상태( 위로 올라갈수록 추상화)    

    Queue<int> intQueue = new Queue<int>();    
    Stack<int> intStack = new Stack<int>();    

    Dictionary<int, string> textDic = new Dictionary<int, string>();
    Hashtable hashtable = new Hashtable();

    void Start()
    {
        textDic.Add(112, "경찰서");        
        textDic.Add(119, "소방서");
        


        ArrayList.Add((object)10); // 박싱, (c++의 업캐스팅) 해서 들어감으로 (태초에 모든것들은 object임) 즉 함수내에서 언박싱해서 값을 보여주는 것
        ArrayList.Add("sad");
        ArrayList.Add(30);
        ArrayList.Add(transform.position);
        ArrayList.Add(50);
        Debug.Log(ArrayList[3]);
        
        int num = 10;
        object obj = (object)num; // num이라는 놈은 int인데 태초의 상태(즉 최종부모)로 박싱되서 들어감, object형태로 형변환(박싱) - 이때는 명시적으로 해줄필요없고
        int numB = 10 + (int)obj; // int로 다운캐스팅, 즉 언박싱 해줘야한다. 넘길때는, 즉 박싱할땐 묵시적이어도 상관없지만(위처럼) 사용할땐, 즉 언박싱할땐 묵시적으로 무슨형태인지 까주어야 한다. 
        // ex)
        Debug.Log("dsa"); // 어떤게 들어올지 몰라서 박싱해서(object)로 넣어줌, 안에서 디버그로그를 찍을 땐 언박싱해줌

        for(int i = 0; i < 10; i++)
        {
            int inputValue = i * 10;
            ints.Add(inputValue);
            intQueue.Enqueue(inputValue);
            intStack.Push(inputValue);
        }

        
        

        

        //for(int i = 0; i < ints.Count; i++) // List의 모든 원소 출력
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

        //foreach (int value in intStack) // 컬렉션의 순서대로 출력됨, stack은 90부터 출력되는 순서니까 여기서먼저 90부터 출력이됨, 여기에 들어오는놈들은 순서를 가지고있어야함
        //{
        //    Debug.Log($"스택 {value}");
        //} // foreach를 쓰면 컬렉션만 바꿔줘도 가능

        //foreach (int value in intQueue)
        //{
        //    Debug.Log($"큐 {value}");
        //}

        //foreach (int value in ints) // IEnumrable을 가지고 있는 놈들만 in 에 들어갈수 있다. 이 것을 가지고 있다는 의미는 순서를 가지고 있다는 의미
        //{
        //    Debug.Log($"리스트 {value}");
        //}









    }
}
