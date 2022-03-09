using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Managers
{
    public class GroupManager
    {
        Group[] data = new Group[0];

        public void Remove(int value)
        {
            int index = Array.IndexOf(data, value);
            for (int i = 0; i < data.Length; i++)
            {
                if (i == index)
                {
                    
                }
            }
        }
        public void GetSingleGroup(int value)
        {
            string singleGroup = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    singleGroup = $"Group ID: {data[i].Id} | Group name: {data[i].Name} | Group speciality: {data[i].Speciality}";
                    break;
                }
            }
            Console.WriteLine(singleGroup);
        }
        public void EditName(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Change the group name...");
                    string newName = ScanerManager.ReadString("Enter the new name: ");
                    data[i].Name = data[i].Name.Replace(data[i].Name, newName);
                    break;
                }
            }
        }
        public void EditSpeciality(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Change the group speciality...");
                    string newSpecialty = ScanerManager.ReadString("Enter the new speciality: ");
                    data[i].Speciality = data[i].Speciality.Replace(data[i].Speciality, newSpecialty);
                    break;
                }
            }
        }
        public void EditNameAndSpeciality(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Change the group name and speciality...");
                    string newName = ScanerManager.ReadString("Enter the new name: ");
                    data[i].Name = data[i].Name.Replace(data[i].Name, newName);
                    string newSpecialty = ScanerManager.ReadString("Enter the new speciality: ");
                    data[i].Speciality = data[i].Speciality.Replace(data[i].Speciality, newSpecialty);
                    break;
                }
            }
        }
        public void Add(Group entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        //public void Remove(Group entity)
        //{
        //    int len = data.Length;
        //    int index = Array.IndexOf(data, entity);
        //    for (int i = index; i < len; i++)
        //    {
        //        data[index] = data[i + 1];
        //    }
        //    Array.Resize(ref data, len - 1);
        //    data[len] = entity;
        //}
        public Group[] GetAll()
        {
            return data;
        }
    }
}
