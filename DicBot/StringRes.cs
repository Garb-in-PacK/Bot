using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace DicBot
{
    class StringRes : INotifyPropertyChanged
    {
        private string log;
        private string countFollower;
    

        public string Log
        {
            get { return log; }
            set
            {
                log = value;
                OnPropertyChanged("Log");
            }
        }
        public string CountFollower
        {
            get { return countFollower; }
            set
            {
                countFollower = value;
                OnPropertyChanged("CountFollower");
            }
        }
       

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}