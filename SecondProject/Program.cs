using System;
using System.IO;


namespace BasicClass
{
    //자동차에 관한 정보
    public class DeliveryVehicle
    {
        //자동차 아이디
        public int vehicleId;
        //배달 목적지 문자열
        public string destination;
        //우선순위 
        public int priority;
    }

    //대기 장소 클래스 정보
    public class DeliveryVehicleManager
    {
        //대기장소 총 개수
        public int numWaitingPlaces;
        //대기장소 안에 차가 있는 배열
        public DeliveryVehicle [][] waitPlaces;
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            //StreamReader로 input.txt에서 입력받는다.
            StreamReader sr = new StreamReader("C:\\Users\\박준형\\source\\repos\\c#_project2\\c#_project2\\INPUT.txt");
            //INPUT에서 줄을 나타내는 line 선언
            int line = 0;
            //대여장소의 수를 뜻한는 total_space 선언
            int total_space = 0;
            
            DeliveryVehicleManager deliveryVehicleManager = new DeliveryVehicleManager();
            
            
            // 입력 파일에 더 이상 읽을 문자가 없을 때 까지 실행 
            while (sr.Peek() >= 0)
            {
                line++;
                
                int id;
                int prio;
                int length;
                
                // 입력파일에 한 줄의 문자열을 읽어와 string배열에 입력하여 split한다.
                string[] tmpreadline = sr.ReadLine().Split();
                
                //첫째줄은 대기장소의 수를 입력받는다.
                if (line == 1)
                {
                    //대기장소를 뜻하는 deliveryVehicleManager 클래스의에 정보를 입력한다.
                    deliveryVehicleManager.numWaitingPlaces = int.Parse(tmpreadline[0]);
                    total_space = int.Parse(tmpreadline[0]);
                    //그리고 입력받은 대기장소에 따른 동적배열을 할당해준다.
                    deliveryVehicleManager.waitPlaces = new DeliveryVehicle[deliveryVehicleManager.numWaitingPlaces][];
                    //모든 대기장소에 대하여 공간을 0씩으로 동적할당을 해준다.
                    for (int i = 0; i < deliveryVehicleManager.numWaitingPlaces; i++)
                    { 
                        deliveryVehicleManager.waitPlaces[i] = new DeliveryVehicle[0];
                    }
                }
                //둘째줄부터는 아래의 코드 실행
                else
                {
                    //ReadyIn을 입력받을 경우
                    if (tmpreadline[0]=="ReadyIn")
                    {
                        //여기서 id-1이 들어가는 대기장소의 인덱스를 뜻한다.
                        id = int.Parse(tmpreadline[1].Substring(1));

                        //해당 대기장소에 차 한대를 추가해줘야 하기 때문에 배열의 크기를 1 늘려준다.
                        length = deliveryVehicleManager.waitPlaces[id - 1].Length;
                        Array.Resize(ref deliveryVehicleManager.waitPlaces[id - 1], length + 1);
                        //또한, 해당 대기장소에 차의 id, 목적지, 우선순위를 기록해둔다.
                        deliveryVehicleManager.waitPlaces[id - 1][length] = new DeliveryVehicle();
                        deliveryVehicleManager.waitPlaces[id - 1][length].vehicleId = int.Parse(tmpreadline[2]);
                        deliveryVehicleManager.waitPlaces[id - 1][length].destination = tmpreadline[3];
                        prio = int.Parse(tmpreadline[4].Substring(1));
                        deliveryVehicleManager.waitPlaces[id - 1][length].priority = prio;

                        //우선순위가 높은 것부터 낮은 순으로 정렬을 아래와 같은 방식으로 해준다.
                        DeliveryVehicle tmp = new DeliveryVehicle();
                        for(int i=0;i< deliveryVehicleManager.waitPlaces[id - 1].Length-1;i++)
                        {
                            for(int j=0; j<deliveryVehicleManager.waitPlaces[id - 1].Length - 1-i;j++)
                            {
                                if (deliveryVehicleManager.waitPlaces[id - 1][j].priority> deliveryVehicleManager.waitPlaces[id - 1][j+1].priority)
                                {
                                    tmp = deliveryVehicleManager.waitPlaces[id - 1][j];
                                    deliveryVehicleManager.waitPlaces[id - 1][j] = deliveryVehicleManager.waitPlaces[id - 1][j + 1];
                                    deliveryVehicleManager.waitPlaces[id - 1][j + 1] = tmp;
                                }
                            }
                        }
                        Console.WriteLine("Vehicle {0} assigned to WaitPlace #{1}", tmpreadline[2], tmpreadline[1].Substring(1));
                    }

                    //Ready를 입력받았을 경우
                    else if (tmpreadline[0]=="Ready")
                    {
                        //대기장소에 차의 수가 가장 적은 것을 찾아야 하기 때문에 set_place라는 변수 생성및 int 최대로 초기화
                        int sel_place=int.MaxValue;
                        //가장 수가 적은 대기장소의 index 선언
                        int index = -1;

                        //가장 수가 적은 대기 장소를 찾는다.
                        for(int i=0;i<total_space;i++)
                        {
                            if (i == 0 || deliveryVehicleManager.waitPlaces[i].Length < sel_place)
                            {
                                sel_place = deliveryVehicleManager.waitPlaces[i].Length;
                                index = i;
                            }
                          
                        }
                        //해당 대기장소에 하나를 추가해줘야 하기 때문에 배열 크기 1 증가
                        length = deliveryVehicleManager.waitPlaces[index].Length;
                        Array.Resize(ref deliveryVehicleManager.waitPlaces[index], length + 1);

                        //해당 대기장소에 차의 정보 입력하기
                        deliveryVehicleManager.waitPlaces[index][length] = new DeliveryVehicle();
                        deliveryVehicleManager.waitPlaces[index][length].vehicleId = int.Parse(tmpreadline[1]);
                        deliveryVehicleManager.waitPlaces[index][length].destination = tmpreadline[2];
                        prio = int.Parse(tmpreadline[3].Substring(1));
                        deliveryVehicleManager.waitPlaces[index][length].priority = prio;

                        //차의 우선순위가 높은것부터 낮은순으로 정렬을 아래와 같이 해준다.
                        DeliveryVehicle tmp = new DeliveryVehicle();
                        for (int i = 0; i < deliveryVehicleManager.waitPlaces[index].Length - 1; i++)
                        {
                            for (int j = 0; j < deliveryVehicleManager.waitPlaces[index].Length - 1 - i; j++)
                            {
                                if (deliveryVehicleManager.waitPlaces[index][j].priority > deliveryVehicleManager.waitPlaces[index][j + 1].priority)
                                {
                                    tmp = deliveryVehicleManager.waitPlaces[index][j];
                                    deliveryVehicleManager.waitPlaces[index][j] = deliveryVehicleManager.waitPlaces[index][j + 1];
                                    deliveryVehicleManager.waitPlaces[index][j + 1] = tmp;
                                }
                            }
                        }
                        Console.WriteLine("Vehicle {0} assigned to WaitPlace #{1}", tmpreadline[1], index+1);
                    }

                    //Status를 입력받았을 경우 대기장소와 차의 정보를 출력하여 준다.
                    else if (tmpreadline[0] == "Status")
                    {
                        Console.WriteLine("************** Delivery Vehicle Info ****************");
                        Console.WriteLine("Number of WaitPlaces: {0}", total_space);
                        for (int i = 0; i < total_space; i++)
                        {
                            length = deliveryVehicleManager.waitPlaces[i].Length;
                            Console.WriteLine("WaitPlace #{0} Number Vehicles: {1}", i+1, length);
                            for(int j=0;j< length; j++)
                            {
                                Console.WriteLine("FNUM: {0} DSET: {1} PRIO: {2}", deliveryVehicleManager.waitPlaces[i][j].vehicleId, deliveryVehicleManager.waitPlaces[i][j].destination, deliveryVehicleManager.waitPlaces[i][j].priority);
                            }
                            
                            Console.WriteLine("-----------------------");
                        }
                        Console.WriteLine("************** End Delivery Vehicle Info ****************");

                    }

                    //Cancel을 입력받았을 경우
                    else if (tmpreadline[0] == "Cancel")
                    {
                        int idx=0;
                        //대기 장소들중에서 입력받은 자동차 id에 해당하는 차 정보를 제거한다.
                        for(int i=0;i<total_space;i++)
                        {
                            length = deliveryVehicleManager.waitPlaces[i].Length;
                            for(int j=0;j< length;j++)
                            {
                                //어느 대기장소에 입력받은 정보의 차가 있는지 확인한다.
                                if (deliveryVehicleManager.waitPlaces[i][j].vehicleId == int.Parse(tmpreadline[1]))
                                {
                                    //입력받은 차가 대기장소의 가장 마지막에 있을 경우 사이즈만 1줄여줌
                                    if (j==length-1)
                                    {
                                        Array.Resize(ref deliveryVehicleManager.waitPlaces[i], length - 1);
                                    }
                                    //대기장소 배열의 중간에서 빠지면 뒤에 있는 것을 앞으로 땡겨줘야 하기 때문에
                                    //아래와 같이 땡겨주고 사이즈를 1줄여준다.
                                    else
                                    {
                                        
                                        for(idx=j;idx<length-1;idx++)
                                        {
                                            deliveryVehicleManager.waitPlaces[i][j] = deliveryVehicleManager.waitPlaces[i][j + 1];
                                            Array.Resize(ref deliveryVehicleManager.waitPlaces[i], length - 1);
                                        }
                                    }
                                    Console.WriteLine("Cancelation of Vehicle {0} completed.", tmpreadline[1]);
                                    break;
                                }
                            }
                        }
                    }

                    //Deliver을 입력받은 경우
                    else if (tmpreadline[0] == "Deliver")
                    {
                        //id-1에 해당하는 값이 해당 대기장소의 index를 뜻한다.
                        id = int.Parse(tmpreadline[1].Substring(1));

                        length = deliveryVehicleManager.waitPlaces[id-1].Length;
                        Console.WriteLine("Vehicle {0} used to deliver.", deliveryVehicleManager.waitPlaces[id - 1][0].vehicleId);
                        
                        //해당 대기장소에 있는 차중 우선순위가 가장 높은 첫번째 차를 배열에서 제거하고 사이즈를 1줄여준다.
                        for (int i = 0; i < length-1; i++)
                        {
                            deliveryVehicleManager.waitPlaces[id-1][i] = deliveryVehicleManager.waitPlaces[id-1][i + 1];
                            Array.Resize(ref deliveryVehicleManager.waitPlaces[id-1], length - 1);
                           
                        }
                    }

                    //Clear를 입력받은 경우
                    else if (tmpreadline[0] == "Clear")
                    {
                        //해당 대기장소의 모든 차를 취소해줘야 하기 때문에 사이즈를 0으로 다시 바꿔준다.
                        id = int.Parse(tmpreadline[1].Substring(1));
                        Console.WriteLine("WaitPlace #{0} cleared.", id);
                        Array.Resize(ref deliveryVehicleManager.waitPlaces[id - 1], 0);
                    }

                    //Quit을 입력받을 경우 반복문을 종료한다.
                    else if (tmpreadline[0] == "Quit")
                    {
                        break;
                    }

                }
                    
            }

            sr.Close();

        }
    }
}