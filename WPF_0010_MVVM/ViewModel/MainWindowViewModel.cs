using System;
using WpfApplication1.Commands;

namespace WpfApplication1.ViewModel
{


    /// <summary>
    /// ViewModel
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {

        
        private string _input;


        /// <summary>
        /// 输入属性.
        /// </summary>
        public string Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
                RaisePropertyChanged("Input");
            }
        }





        private string _display;
        
        /// <summary>
        /// 显示属性.
        /// </summary>
        public string Display
        {
            get
            {
                return _display;
            }
            set
            {
                _display = value;
                RaisePropertyChanged("Display");
            }
        }

        

        /// <summary>
        /// 命令.
        /// </summary>
        public DelegateCommand SetTextCommand { get; set; }
        
        private void SetText(object obj)
        {
            Display = Input;
        }



        /// <summary>
        /// 构造函数.
        /// </summary>
        public MainWindowViewModel()
        {
            SetTextCommand = new DelegateCommand(new Action<object>(SetText));
        }




    }
}
