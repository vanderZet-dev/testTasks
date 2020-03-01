using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestTasks.Models
{
    public class Person: INotifyPropertyChanged
    {
        #region INotifyRealization
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

        private string firstName;
        public string FirstName
        {
            get { return firstName;}
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string paterName;
        public string PaterName
        {
            get { return paterName; }
            set
            {
                paterName = value;
                OnPropertyChanged("PaterName");
            }
        }

        private string birthPlace;
        public string BirthPlace
        {
            get { return birthPlace; }
            set
            {
                birthPlace = value;
                OnPropertyChanged("BirthPlace");
            }
        }

        private string passport;
        public string Passport
        {
            get { return passport; }
            set
            {
                passport = value;
                OnPropertyChanged("Passport");
            }
        }


        public static implicit operator string(Person obj)
        {
            return obj.FirstName + " " + obj.LastName;
        }

        public static explicit operator Person(string data)
        {
            return new Person() {FirstName = data.Split()[0], LastName = data.Split()[1]};
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Person))
                return false;

            var person = (Person)obj;
            return person.Passport == Passport && person.BirthPlace == BirthPlace;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode() + PaterName.GetHashCode() + BirthPlace.GetHashCode() + Passport.GetHashCode();
        }

        public override string ToString()
        {
            return $"ФИО: {LastName} {FirstName} {PaterName}";
        }
    }
}
