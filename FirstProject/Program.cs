using System;
using System.IO;

namespace BasicClass
{
    //컴퓨터 정보 클래스
    public class Computer
    {

        public int Comid;
        public string Avail = "Y";
        public int UserId = 0;
        public int DR = 0;
        public int DL = 0;
        public int DU = 0;
    }
    //노트북 정보 클래스
    public class Notebook : Computer
    {
        public string type = "Notebook";
        public int Noteid;
        public string avail_internet = "Y";
        public string avail_scientific = "Y";
        public string avail_game = "N";
        public int day_cost = 10000;
    }
    //넷북 정보 클래스
    public class Netbook : Computer
    {
        public string type = "Netbook";
        public int Netid;
        public string avail_internet = "Y";
        public string avail_scientific = "N";
        public string avail_game = "N";
        public int day_cost = 7000;
    }
    //데스크탑 정보 클래스 
    public class Desktop : Computer
    {
        public string type = "Desktop";
        public int Deskid;
        public string avail_internet = "Y";
        public string avail_scientific = "Y";
        public string avail_game = "Y";
        public int day_cost = 13000;
    }

    //User 정보 클래스
    public class User
    {

        public string name;
        public int userid;
        public int computerid = 0;
        public string rent = "N";
        public int lent_day = 0;
        public int use_day = 0;
    }
    //Students 정보 클래스
    public class Students : User
    {
        public string type = "Students";
        public int studid;
        public string avail_internet = "Y";
        public string avail_scientific = "Y";
        public string avail_game = "N";
    }
    //Workers 정보 클래스
    public class Workers : User
    {
        public string type = "OfficeWorkers";
        public int workerid;
        public string avail_internet = "Y";
        public string avail_scientific = "N";
        public string avail_game = "N";
    }
    //Gamers 정보 클래스
    public class Gamers : User
    {
        public string type = "Gamers";
        public int gamerid;
        public string avail_internet = "Y";
        public string avail_scientific = "N";
        public string avail_game = "Y";
    }

    //컴퓨터매니저 클래스(여러 메소드)
    public class ComputerManager
    {
        //출력 메소드- 컴퓨터와 사용자 정보를 모두 출력해준다.
        static public void Print(Computer[] arrComp, User[] arrUser)
        {
            Netbook a;
            Notebook b;
            Desktop c;

            //컴퓨터 정보 출력
            Console.WriteLine("Computer List:");
            int com_length = arrComp.Length;
            for (int i = 0; i < com_length; i++)
            {
                if (arrComp[i] is Netbook)
                {
                    a = arrComp[i] as Netbook;
                    Console.Write("({0}) type: {1}, ComId: {2}, NetId: {3}, Used for: ", i + 1, a.type, a.Comid, a.Netid);
                    if (a.avail_internet == "Y")
                    {
                        Console.Write("internet, ");
                    }
                    if (a.avail_scientific == "Y")
                    {
                        Console.Write("scientific, ");
                    }
                    if (a.avail_game == "Y")
                    {
                        Console.Write("game, ");
                    }

                    if (a.Avail == "Y")
                    {
                        Console.WriteLine("Avail: {0}", a.Avail);
                    }
                    if (a.Avail == "N")
                    {
                        Console.WriteLine("Avail: {0} (UserId:{1},DR:{2},DL:{3},DU:{4})", a.Avail, a.UserId, a.DR, a.DL, a.DU);
                    }

                }
                else if (arrComp[i] is Notebook)
                {
                    b = arrComp[i] as Notebook;
                    Console.Write("({0}) type: {1}, ComId: {2}, NoteId: {3}, Used for: ", i + 1, b.type, b.Comid, b.Noteid);
                    if (b.avail_internet == "Y")
                    {
                        Console.Write("internet, ");
                    }
                    if (b.avail_scientific == "Y")
                    {
                        Console.Write("scientific, ");
                    }
                    if (b.avail_game == "Y")
                    {
                        Console.Write("game, ");
                    }

                    if (b.Avail == "Y")
                    {
                        Console.WriteLine("Avail: {0}", b.Avail);
                    }
                    if (b.Avail == "N")
                    {
                        Console.WriteLine("Avail: {0} (UserId:{1},DR:{2},DL:{3},DU:{4})", b.Avail, b.UserId, b.DR, b.DL, b.DU);
                    }
                }
                else if (arrComp[i] is Desktop)
                {
                    c = arrComp[i] as Desktop;
                    Console.Write("({0}) type: {1}, ComId: {2}, DeskId: {3}, Used for: ", i + 1, c.type, c.Comid, c.Deskid);
                    if (c.avail_internet == "Y")
                    {
                        Console.Write("internet, ");
                    }
                    if (c.avail_scientific == "Y")
                    {
                        Console.Write("scientific, ");
                    }
                    if (c.avail_game == "Y")
                    {
                        Console.Write("game, ");
                    }

                    if (c.Avail == "Y")
                    {
                        Console.WriteLine("Avail: {0}", c.Avail);
                    }
                    if (c.Avail == "N")
                    {
                        Console.WriteLine("Avail: {0} (UserId:{1},DR:{2},DL:{3},DU:{4})", c.Avail, c.UserId, c.DR, c.DL, c.DU);
                    }
                }
            }

            Students d;
            Workers e;
            Gamers f;

            //유저 정보출력
            Console.WriteLine("User List:");
            int user_length = arrUser.Length;
            for (int i = 0; i < user_length; i++)
            {
                if (arrUser[i] is Students)
                {
                    d = arrUser[i] as Students;
                    Console.Write("({0}) type: {1}, Name: {2}, UserId: {3}, StuId: {4}, Used for: ", i + 1, d.type, d.name, d.userid, d.studid);
                    if (d.avail_internet == "Y")
                    {
                        Console.Write("internet, ");
                    }
                    if (d.avail_scientific == "Y")
                    {
                        Console.Write("scientific, ");
                    }
                    if (d.avail_game == "Y")
                    {
                        Console.Write("game, ");
                    }

                    if (d.rent == "N")
                        Console.WriteLine("Rent: {0}", d.rent);
                    if (d.rent == "Y")
                        Console.WriteLine("Rent: {0} (RentCompId: {1})", d.rent, d.computerid);
                }
                else if (arrUser[i] is Workers)
                {
                    e = arrUser[i] as Workers;
                    Console.Write("({0}) type: {1}, Name: {2}, UserId: {3}, WorkerId: {4}, Used for: ", i + 1, e.type, e.name, e.userid, e.workerid);
                    if (e.avail_internet == "Y")
                    {
                        Console.Write("internet, ");
                    }
                    if (e.avail_scientific == "Y")
                    {
                        Console.Write("scientific, ");
                    }
                    if (e.avail_game == "Y")
                    {
                        Console.Write("game, ");
                    }

                    if (e.rent == "N")
                        Console.WriteLine("Rent: {0}", e.rent);
                    if (e.rent == "Y")
                        Console.WriteLine("Rent: {0} (RentCompId: {1})", e.rent, e.computerid);

                }
                else if (arrUser[i] is Gamers)
                {
                    f = arrUser[i] as Gamers;
                    Console.Write("({0}) type: {1}, Name: {2}, UserId: {3}, GamerId: {4}, Used for: ", i + 1, f.type, f.name, f.userid, f.gamerid);
                    if (f.avail_internet == "Y")
                    {
                        Console.Write("internet, ");
                    }
                    if (f.avail_scientific == "Y")
                    {
                        Console.Write("scientific, ");
                    }
                    if (f.avail_game == "Y")
                    {
                        Console.Write("game, ");
                    }

                    if (f.rent == "N")
                        Console.WriteLine("Rent: {0}", f.rent);
                    if (f.rent == "Y")
                        Console.WriteLine("Rent: {0} (RentCompId: {1})", f.rent, f.computerid);

                }
            }
        }

        //A를 입력받았을때 해당 사용자가 어떠한 컴퓨터를 할당받는지 판단하고, 대여 일수를 넣어줌.
        static public void Allocation(Computer[] arrComp, User user, int day, int user_cnt)
        {
            Netbook a;
            Notebook b;
            Desktop c;
            Students d;
            Workers e;
            Gamers f;

            int cnt = 0;
            if (user is Students)
            {
                d = user as Students;
                for (int i = 0; i < arrComp.Length; i++)
                {
                    if (arrComp[i] is Notebook || arrComp[i] is Desktop)
                    {
                        //할당받은 컴퓨터는 Avail을 Y에서 N로 바꿔주어야 한다.
                        if (arrComp[i].Avail == "Y")
                        {
                            arrComp[i].Avail = "N";
                            d.rent = "Y";
                            d.lent_day = day;
                            //인덱스가 아닌 몇번째 컴퓨터인지
                            d.computerid = i + 1;
                            cnt = 1;
                            arrComp[i].UserId = user.userid;
                            arrComp[i].DR = day;
                            arrComp[i].DL = day;

                            Console.WriteLine("Computer #{0} has been assigned to User #{1}", i + 1, user_cnt);
                            Console.WriteLine("==================================");
                        }
                    }
                    if (cnt == 1)
                        break;
                }
            }
            else if (user is Workers)
            {
                e = user as Workers;
                for (int i = 0; i < arrComp.Length; i++)
                {
                    //할당받은 컴퓨터는 Avail을 Y에서 N로 바꿔주어야 한다.
                    if (arrComp[i].Avail == "Y")
                    {
                        arrComp[i].Avail = "N";
                        e.rent = "Y";
                        e.lent_day = day;
                        e.computerid = i + 1;
                        cnt = 1;
                        arrComp[i].UserId = user.userid;
                        arrComp[i].DR = day;
                        arrComp[i].DL = day;


                        Console.WriteLine("Computer #{0} has been assigned to User #{1}", i + 1, user_cnt);
                        Console.WriteLine("==================================");
                    }
                    if (cnt == 1)
                        break;
                }

            }
            else if (user is Gamers)
            {
                f = user as Gamers;
                for (int i = 0; i < arrComp.Length; i++)
                {
                    if (arrComp[i] is Desktop)
                    {
                        //할당받은 컴퓨터는 Avail을 Y에서 N로 바꿔주어야 한다.
                        if (arrComp[i].Avail == "Y")
                        {
                            arrComp[i].Avail = "N";
                            f.rent = "Y";
                            f.lent_day = day;
                            f.computerid = i + 1;
                            cnt = 1;
                            arrComp[i].UserId = user.userid;
                            arrComp[i].DR = day;
                            arrComp[i].DL = day;

                            Console.WriteLine("Computer #{0} has been assigned to User #{1}", i + 1, user_cnt);
                            Console.WriteLine("==================================");
                        }
                    }
                    if (cnt == 1)
                        break;
                }

            }
        }

        //T를 입력받아 하루가 지났을 때 사용자의 사용한 날, 컴퓨터가 사용된 날, 남은 날을 수정해 주어야한다.
        //또한 하루가 지나 대여 일수가 끝났을 때 값들을 초기화해주어야 한다.
        static public int pass_day(Computer[] arrComp, User[] arrUser)
        {
            Netbook a;
            Notebook b;
            Desktop c;

            int cash = 0;
            int length = arrUser.Length;
            int index = -1;
            //모든 유저에 대하여 대여일수가 지났는지 확인해주어야한다.
            for (int i = 0; i < length; i++)
            {
                if (arrUser[i].rent == "Y")
                {
                    arrUser[i].use_day = arrUser[i].use_day + 1;
                    index = arrUser[i].computerid - 1;
                    if (arrComp[index] is Netbook)
                    {
                        a = arrComp[index] as Netbook;
                        a.DL = a.DL - 1;
                        a.DU = a.DU + 1;
                    }
                    if (arrComp[index] is Notebook)
                    {
                        b = arrComp[index] as Notebook;
                        b.DL = b.DL - 1;
                        b.DU = b.DU + 1;
                    }
                    if (arrComp[index] is Desktop)
                    {
                        c = arrComp[index] as Desktop;
                        c.DL = c.DL - 1;
                        c.DU = c.DU + 1;
                    }

                    //대여 일수가 모두 끝났을 경우
                    if (arrUser[i].lent_day == arrUser[i].use_day)
                    {
                        //모두 초기화해주는 과정을 거친다.
                        if (arrComp[index] is Netbook)
                        {
                            cash += (7000 * arrUser[i].lent_day);
                            a = arrComp[index] as Netbook;
                            a.Avail = "Y";
                            a.DR = 0;
                            a.DL = 0;
                            a.DU = 0;
                        }
                        if (arrComp[index] is Notebook)
                        {
                            cash += (10000 * arrUser[i].lent_day);
                            b = arrComp[index] as Notebook;
                            b.Avail = "Y";
                            b.DR = 0;
                            b.DL = 0;
                            b.DU = 0;
                        }
                        if (arrComp[index] is Desktop)
                        {
                            cash += (13000 * arrUser[i].lent_day);
                            c = arrComp[index] as Desktop;
                            c.Avail = "Y";
                            c.DR = 0;
                            c.DL = 0;
                            c.DU = 0;
                        }
                        Console.WriteLine("Time for Computer #{0} has expired. User #{1} has returned Computer #{2} and paid {3}won.", index + 1, i + 1, index + 1, cash);
                        arrUser[i].rent = "N";
                        arrUser[i].computerid = 0;
                        arrUser[i].lent_day = 0;
                        arrUser[i].use_day = 0;
                        arrUser[i].userid = 0;

                    }
                }
            }


            return cash;
        }
        //R을 입력받아 해당 사용자가 받은 컴퓨터를 반납해주어야 하는 경우 초기화 해주어야한다.
        static public int returning(Computer[] arrComp, User arrUser)
        {
            Netbook a;
            Notebook b;
            Desktop c;

            int cash = 0;
            int index = -1;
            if (arrUser.rent == "Y")
            {

                index = arrUser.computerid - 1;
                if (arrComp[index] is Netbook)
                {
                    cash += (7000 * arrUser.use_day);
                    a = arrComp[index] as Netbook;
                    a.Avail = "Y";
                    a.UserId = 0;
                    a.DR = 0;
                    a.DL = 0;
                    a.DU = 0;
                }
                if (arrComp[index] is Notebook)
                {
                    cash += (10000 * arrUser.use_day);
                    b = arrComp[index] as Notebook;
                    b.Avail = "Y";
                    b.UserId = 0;
                    b.DR = 0;
                    b.DL = 0;
                    b.DU = 0;
                }
                if (arrComp[index] is Desktop)
                {
                    cash += (13000 * arrUser.use_day);
                    c = arrComp[index] as Desktop;
                    c.Avail = "Y";
                    c.UserId = 0;
                    c.DR = 0;
                    c.DL = 0;
                    c.DU = 0;
                }
                Console.WriteLine("User #{0} has returned Computer #{1} and paid {2} won.", arrUser.userid, arrUser.computerid, cash);
                arrUser.rent = "N";
                arrUser.computerid = 0;
                arrUser.lent_day = 0;
                arrUser.use_day = 0;
            }
            return cash;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            //StreamReader로 input.txt에서 입력받는다.
            //필자는 해당 컴퓨터의 경로를 입력받아 경로를 아래와 같이 작성하였다.
            StreamReader sr = new StreamReader("C:\\Users\\박준형\\source\\repos\\FirstProgram\\FirstProgram\\input.txt");
            int line = 0;
            int[] type_computer = new int[3];
            int num_computer = 0;
            int com_num = 1;
            int net_num = 1;
            int note_num = 1;
            int desk_num = 1;

            //is,as 사용을 위해 빈 변수 만들어 내기
            Netbook a;
            Notebook b;
            Desktop c;

            Computer[] arrComp = null;
            int user_num = 1;
            int stu_num = 1;
            int worker_num = 1;
            int gamer_num = 1;

            //is,as 사용을 위해 빈 변수 만들어 내기
            Students d;
            Workers e;
            Gamers f;

            int num_user = 0;
            User[] arrUser = null;
            int cnt = 0;
            int total = 0;
            int cash = 0;

            // 입력 파일에 더 이상 읽을 문자가 없을 때 까지 실행 
            while (sr.Peek() >= 0)
            {
                line++;
                // 입력파일에 한 줄의 문자열을 읽어와 string배열에 입력하여 split한다.
                string[] tmpreadline = sr.ReadLine().Split();
                if (line == 1)
                {
                    //총 컴퓨터의 개수를 입력받는다. 6개
                    num_computer = Int32.Parse(tmpreadline[0]);
                }
                else if (line == 2)
                {
                    //컴퓨터의 종류 중 노트북, 데스크톱, 넷북 수를 입력받는다.
                    //index=0은 노트북, index=1은 데스크탑, index=2는 넷북 수
                    for (int i = 0; i < 3; i++)
                    {
                        type_computer[i] = int.Parse(tmpreadline[i]);
                    }

                    //컴퓨터에 각각의 자식을 할당해줌.
                    arrComp = new Computer[num_computer];
                    int index = 0;
                    for (int i = 0; i < type_computer[2]; i++)
                    {
                        arrComp[index] = new Netbook();
                        index++;
                    }
                    for (int i = 0; i < type_computer[0]; i++)
                    {
                        arrComp[index] = new Notebook();
                        index++;
                    }
                    for (int i = 0; i < type_computer[1]; i++)
                    {
                        arrComp[index] = new Desktop();
                        index++;
                    }

                    //각각의 컴퓨터에 comid,netid,noteid,deskid 등 할당하기 
                    for (int i = 0; i < num_computer; i++)
                    {
                        if (arrComp[i] is Netbook)
                        {
                            a = arrComp[i] as Netbook;
                            a.Comid = com_num;
                            com_num++;
                            a.Netid = net_num;
                            net_num++;
                        }
                        else if (arrComp[i] is Notebook)
                        {
                            b = arrComp[i] as Notebook;
                            b.Comid = com_num;
                            com_num++;
                            b.Noteid = note_num;
                            note_num++;
                        }
                        else if (arrComp[i] is Desktop)
                        {
                            c = arrComp[i] as Desktop;
                            c.Comid = com_num;
                            com_num++;
                            c.Deskid = desk_num;
                            desk_num++;
                        }
                    }
                }
                else if (line == 3)
                {
                    //사용자의 수 입력
                    num_user = Int32.Parse(tmpreadline[0]);
                    arrUser = new User[num_user];
                }

                //사용자의 직업과 이름을 확인하여 입력해준다.
                else if (line >= 4 && line < 4 + num_user)
                {
                    if (tmpreadline[0] == "Student")
                    {
                        arrUser[cnt] = new Students();
                        d = arrUser[cnt] as Students;
                        d.name = tmpreadline[1];
                        d.userid = user_num;
                        user_num++;
                        d.studid = stu_num;
                        stu_num++;
                    }
                    else if (tmpreadline[0] == "Worker")
                    {
                        arrUser[cnt] = new Workers();
                        e = arrUser[cnt] as Workers;
                        e.name = tmpreadline[1];
                        e.userid = user_num;
                        user_num++;
                        e.workerid = worker_num;
                        worker_num++;
                    }
                    else if (tmpreadline[0] == "Gamer")
                    {
                        arrUser[cnt] = new Gamers();
                        f = arrUser[cnt] as Gamers;
                        f.name = tmpreadline[1];
                        f.userid = user_num;
                        user_num++;
                        f.gamerid = gamer_num;
                        gamer_num++;
                    }
                    cnt++;
                }
                //이후 Q가 입력될때까지 계속해서 명령어를 입력받는다.
                else
                {
                    //S를 입력받았을 경우 전체정보 출력
                    if (tmpreadline[0] == "S")
                    {
                        Console.WriteLine("Total Cost: {0}", total);
                        ComputerManager.Print(arrComp, arrUser);
                        Console.WriteLine("==================================");
                    }
                    //A가 입력받았을 경우 해당사용자에게 해당 day만큼 대여
                    else if (tmpreadline[0] == "A")
                    {
                        ComputerManager.Allocation(arrComp, arrUser[Int32.Parse(tmpreadline[1]) - 1], Int32.Parse(tmpreadline[2]), Int32.Parse(tmpreadline[1]));
                    }
                    //T가 입력받았을 경우 하루가 지나는 과정을 거친다.
                    else if (tmpreadline[0] == "T")
                    {
                        Console.WriteLine("It has passed one day..");
                        cash = ComputerManager.pass_day(arrComp, arrUser);
                        total += cash;
                        Console.WriteLine("==================================");
                    }
                    //R이 입력받았을 경우 해당 사용자가 대여받은 컴퓨터 반납
                    else if (tmpreadline[0] == "R")
                    {

                        cash = ComputerManager.returning(arrComp, arrUser[Int32.Parse(tmpreadline[1]) - 1]);
                        total += cash;
                        Console.WriteLine("==================================");
                    }
                    //Q가 입력받았을 경우 반복문 종료
                    else if (tmpreadline[0] == "Q")
                    {
                        break;
                    }
                }

            }

            sr.Close();

        }
    }

}