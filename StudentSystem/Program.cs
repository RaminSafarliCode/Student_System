using StudentSystem.Infrustructure;
using StudentSystem.Managers;
using System;
using System.Linq;
using System.Text;

namespace StudentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Student System v.1";

            var groupMgr = new GroupManager();
            var studentMgr = new StudentManager();

        readMenu:
            PrintMenu();

            Menu m = ScanerManager.ReadMenu("Choose from menu: ");
            switch (m)
            {
                case Menu.GroupAdd:
                    Console.Clear();
                    Group g = new Group();
                    g.Name = ScanerManager.ReadString("Enter the group name: ");
                    g.Speciality = ScanerManager.ReadString("Enter the speciality of group: ");

                    groupMgr.Add(g);

                    goto case Menu.GroupsAll;

                case Menu.GroupEdit:
                    Console.Clear();
                    ShowAllGroups(groupMgr);
                    Console.WriteLine("To change name -> 1 | To change speciality -> 2 | To change both -> 3");
                    bool success = int.TryParse(Console.ReadLine(), out int menuNum);
                    if (success && menuNum == 1)
                    {
                        int value = ScanerManager.ReadInteger("Enter the ID of choosen group: ");
                        groupMgr.EditName(value);
                    }
                    else if (success && menuNum == 2)
                    {
                        int value = ScanerManager.ReadInteger("Enter the ID of choosen group: ");
                        groupMgr.EditSpeciality(value);
                    }
                    else if (success && menuNum == 3)
                    {
                        int value = ScanerManager.ReadInteger("Enter the ID of choosen group: ");
                        groupMgr.EditNameAndSpeciality(value);
                    }

                    goto case Menu.GroupsAll;

                case Menu.GroupRemove:
                    Console.Clear();
                    ShowAllGroups(groupMgr);
                    Console.WriteLine("Choose a group from list to delete!");
                    groupMgr.Remove(ScanerManager.ReadInteger("Enter the ID of group: "));
                    goto case Menu.GroupsAll;
                case Menu.GroupSingle:
                    Console.Clear();
                    ShowAllGroups(groupMgr);
                    int idValue = ScanerManager.ReadInteger("Enter the ID of choosen group: ");
                    groupMgr.GetSingleGroup(idValue);
                    goto readMenu;

                case Menu.GroupsAll:
                    Console.Clear();
                    ShowAllGroups(groupMgr);
                    goto readMenu;

                case Menu.StudentAdd:
                    Console.Clear();
                    Student s = new Student();
                    s.Name = ScanerManager.ReadString("Enter the student name: ");
                    s.Surname = ScanerManager.ReadString("Enter the student surname: ");
                    s.BirhtDate = ScanerManager.ReadDate("Enter the student birthdate: ");

                    Console.WriteLine("---------------");
                    ShowAllGroups(groupMgr);
                    Console.WriteLine("---------------");

                    s.GroupId = ScanerManager.ReadInteger("Enter the student group ID: ");

                    studentMgr.Add(s);
                    goto case Menu.StudentsAll;
                case Menu.StudentEdit:
                    Console.Clear();
                    ShowAllStudents(studentMgr);
                    Console.WriteLine("To change name -> 1 | To change surname -> 2 +\n" +
                        "To change birth date -> 3 | To change Group -> 4");
                    bool successN = int.TryParse(Console.ReadLine(), out int menuNumb);
                    if (successN && menuNumb == 1)
                    {
                        int value = ScanerManager.ReadInteger("Enter the ID of choosen student: ");
                        studentMgr.EditName(value);
                    }
                    else if (successN && menuNumb == 2)
                    {
                        int value = ScanerManager.ReadInteger("Enter the ID of choosen student: ");
                        studentMgr.EditSurname(value);
                    }
                    else if (successN && menuNumb == 3)
                    {
                        int value = ScanerManager.ReadInteger("Enter the ID of choosen student: ");
                        studentMgr.EditBirthDate(value);
                    }
                    else if (successN && menuNumb == 4)
                    {
                        int value = ScanerManager.ReadInteger("Enter the ID of choosen student: ");
                        studentMgr.EditGroup(value);
                    }

                    goto case Menu.StudentsAll;
                case Menu.StudentRemove:
                    //Group g1 = groupMgr.GetAll().FirstOrDefault(g => g.Id == 4);
                    //Array.IndexOf(groupMgr.GetAll(), g1);
                    //Gro
                    break;
                case Menu.StudentSingle:
                    Console.Clear();
                    ShowAllStudents(studentMgr);
                    int idValueS = ScanerManager.ReadInteger("Enter the ID of choosen student: ");
                    studentMgr.GetSingleStudent(idValueS);
                    goto readMenu;

                case Menu.StudentsAll:
                    Console.Clear();
                    ShowAllStudents(studentMgr);
                    goto readMenu;
                    break;

                case Menu.All:
                    Console.Clear();
                    ShowAllGroups(groupMgr);
                    ShowAllStudents(studentMgr);
                    goto readMenu;
                case Menu.Exit:
                    goto lEnd;
                default:
                    break;
            }

            lEnd:
            Console.WriteLine("END...");
            Console.WriteLine("To exit program, please click any key!");
            Console.ReadKey();
        }

        static void PrintMenu()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            foreach (var item in Enum.GetNames(typeof(Menu)))
            {
                Menu m = (Menu)Enum.Parse(typeof(Menu), item);
                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine($"{new string('-', Console.WindowWidth)}\n");
        }

        static void ShowAllGroups(GroupManager groupMgr)
        {
            Console.WriteLine("******************** Groups ********************");
            foreach (var item in groupMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }
        static void ShowAllStudents(StudentManager mgr)
        {
            Console.WriteLine("******************** Students ********************");
            foreach (var item in mgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }
    }
}
