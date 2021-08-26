using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoDiGolf
{
    class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnumGender Gender { get; set; }
        public bool ClubCard { get; set; }




        public User(int? id, string name, string surname, DateTime dateOfBirth, EnumGender gender, bool clubCard)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ClubCard = clubCard;
        }

        public User() { }

        public virtual string Print()
        {
            return $"{Name}, {Surname} - {DateOfBirth} - {Gender} - {ClubCard}.";
        }

    }
    public enum EnumGender
    {
        male,
        female
    }
}
