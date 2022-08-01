using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowers.Desctop.ViewModel
{
    public class DialogViewModel :ViewModelBase
    {
        public DialogViewModel()
        {

        }

        private int _result;

        public int Result
        {
            get { return _result; }
        }

        private bool isCorrectInput = false;

        public bool IsCorrectInput
        {
            get
            { 
                return isCorrectInput; 
            }
            set
            { 
                isCorrectInput = value; 
            }
        }

        private string _input = string.Empty;

        public string Input
        {
            get
            {
                return _input;
            }
            set
            {
                if(ValidateInput(value))
                {
                    _input = value;
                }
                _input = string.Empty;
            }
        }

        private bool ValidateInput(string input)
        {
            if(!int.TryParse(input, out _result))
            {
                IsCorrectInput = false;
                return false;
            }
            IsCorrectInput = true;
            return true;
        }
    }
}
