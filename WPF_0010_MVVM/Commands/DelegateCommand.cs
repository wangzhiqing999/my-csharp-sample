using System;
using System.Windows.Input;

namespace WpfApplication1.Commands
{


    /// <summary>
    /// WPF 的 ICommand接口，用于绑定GUI事件.
    /// 
    /// 
    /// ICommand接口需要用户定义两个方法：bool CanExecute方法，和void Execute方法。
    /// 
    /// </summary>
    public class DelegateCommand : ICommand
    {

        readonly Action<object> _execute;

        readonly Predicate<object> _canExecute;



        /// <summary>
        /// 构造函数. (仅仅传入 处理的命令)
        /// </summary>
        /// <param name="execute"></param>
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }


        /// <summary>
        /// 构造函数. (传入 处理的命令， 与是否可执行的相关条件)
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }



        public void Execute(object parameter)
        {
            _execute(parameter);
        }



        /// <summary>
        /// CanExecute方法实际上仅对用户说，我可以执行这个命令吗？
        /// 这对管理context是很有用的，你可以执行GUI的动作。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            // 如果没有定义  判断是否可用的判断逻辑， 那么默认命令可用.
            return _canExecute == null ? true : _canExecute(parameter);
        }



        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


    }
}
