using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Managers
{
    public class StudentManager
    {
        Student[] data = new Student[0];

        public void GetSingleStudent(int value)
        {
            string singleStudent = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    singleStudent = $"ID: {data[i].Id} | Name: {data[i].Name} | Surname: {data[i].Surname} " +
                        $"| Birth Date: {data[i].BirhtDate} | Group ID: {data[i].GroupId}";
                    break;
                }
            }
            Console.WriteLine(singleStudent);
        }
        public void EditName(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Change the student name...");
                    string newName = ScanerManager.ReadString("Enter the new name: ");
                    data[i].Name = data[i].Name.Replace(data[i].Name, newName);
                    break;
                }
            }
        }

        public void EditSurname(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Change the student surname...");
                    string newName = ScanerManager.ReadString("Enter the new surname: ");
                    data[i].Surname = data[i].Surname.Replace(data[i].Surname, newName);
                    break;
                }
            }
        }

        public void EditBirthDate(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Change the student birth date...");
                    DateTime newDate = ScanerManager.ReadDate("Enter the new birth date: ");
                    data[i].BirhtDate = newDate;
                    break;
                }
            }
        }

        public void EditGroup(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Change the student group...");
                    int newGroupID = ScanerManager.ReadInteger("Enter the ID of new Group: ");
                    data[i].GroupId = newGroupID;
                    break;
                }
            }
        }

        public void Add(Student entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public Student[] GetAll()
        {
            return data;
        }
    }
}
