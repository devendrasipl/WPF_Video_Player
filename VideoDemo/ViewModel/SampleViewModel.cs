using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoDemo.ViewModel
{
    public class SampleViewModel : ObservableObject, ISampleViewModel
    {
        public SampleViewModel()
        {
            PropertyChanged += SampleViewModel_PropertyChanged;
        }

        private string _MessageData;
        public string MessageData
        {
            get
            {
                return _MessageData;
            }

            set
            {
                if (value != _MessageData)
                {
                    _MessageData = value;
                    RaisePropertyChanged("MessageData");
                }
            }
        }

        private void SampleViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) { }


    }
}
