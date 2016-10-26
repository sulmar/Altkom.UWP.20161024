using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Bicycle.Models
{
    public class User : Base
    {
        public int UserId { get; set; }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                _FirstName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _Identifier;
        public string Identifier
        {
            get { return _Identifier; }
            set
            {
                _Identifier = value;

                OnPropertyChanged();
            }
        }

        public bool IsActive { get; set; }

        // C# 6.0
        public string FullName => $"{FirstName} {LastName}";

        public override string ToString() => FullName;
    }
}
