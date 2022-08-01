using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HanoiTowers.Desctop.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        private bool _isExecuting;

        public bool IsExecuting
        {
            get { return _isExecuting; }
            set { _isExecuting = value; }
        }


        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return !_isExecuting;
        }

        public async void Execute(object? parameter)
        {
            _isExecuting = true;

            try
            {
                await ExecuteAsunc(parameter);
            }
            catch(Exception ex)
            {
                OnExeption(ex);
            }
            finally
            {
                _isExecuting = false;
                OnFinally();
            }
        }

        public abstract Task ExecuteAsunc(object? parameter);

        protected void OnCanExecute()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public virtual void OnExeption(Exception ex)
        {
            throw new NotImplementedException($"Excaption handler not implemented.");
        }

        public virtual void OnFinally()
        {

        }
        
    }
}
