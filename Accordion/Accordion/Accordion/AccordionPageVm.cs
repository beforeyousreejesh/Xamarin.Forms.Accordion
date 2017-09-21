using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Accordion
{
    public class AccordionPageVm : INotifyPropertyChanged
    {
        public AccordionPageVm()
        {
            Items = new ObservableCollection<AccordionGorp>();
        }

        private ObservableCollection<AccordionGorp> _items;

        public ObservableCollection<AccordionGorp> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }


        public AccordionPageVm BuildItems()
        {
            var accordionGroups = new List<AccordionGorp>();

            for (int j = 0; j < 5; j++)
            {
                var accordionGroup = new AccordionGorp("Header " + j);

                for (int i = 0; i < 10; i++)
                {
                    var accordionItem = new AccordionItems
                    {
                        Title = "Title " + i + " " + j,
                        Date = DateTime.Now.ToString("ddMMyyyy"),
                        Time = DateTime.Now.ToString("hh:mm"),
                        Place = "Place " + i + " " + j
                    };

                    accordionGroup.Add(accordionItem);
                }

                accordionGroups.Add(accordionGroup);
            }

            Items = new ObservableCollection<AccordionGorp>(accordionGroups);

            return this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AccordionItems : INotifyPropertyChanged
    {
        public AccordionItems()
        {
            ExpandCommand = new Command(Expand);
        }

        public string Title { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Place { get; set; }

        private bool _isExpanded;

        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                _isExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }

        private ICommand _expandCommand;

        public ICommand ExpandCommand
        {
            get
            {
                return _expandCommand;
            }
            set
            {
                _expandCommand = value;
                OnPropertyChanged("ExpandCommand");
            }
        }

        public void Expand()
        {
            IsExpanded = !IsExpanded;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AccordionGorp : ObservableCollection<AccordionItems>
    {
        public AccordionGorp(string header)
        {
            Header = header;
        }

        public string Header { get; set; }
    }
}
