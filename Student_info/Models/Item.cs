using System;
using Xamarin.Forms;

namespace Student_info.Models
{
    public class Item : BindableObject
    {
        public int _id;
        public string _fName;
        public string _lName;
        public string _index;
        public string _gender;
        public string _email;
        public string _password;
        public string _telNumber;
        public string _imgUrl;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string FName
        {
            get
            {
                return _fName;
            }
            set
            {
                _fName = value;
                OnPropertyChanged();
            }
        }
        public string LName
        {
            get
            {
                return _lName;
            }
            set
            {
                _lName = value;
                OnPropertyChanged();
            }
        }
        public string Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public string TelNumber
        {
            get
            {
                return _telNumber;
            }
            set
            {
                _telNumber = value;
                OnPropertyChanged();
            }
        }
        public string ImgUrl
        {
            get
            {
                return _imgUrl;
            }
            set
            {
                _imgUrl = value;
                OnPropertyChanged();
            }
        }




    }
}