using System;
using DiceShow.Models;

namespace DiceShow
{
    public class Executer : IExecuter
    {

        private IRoller _roller;
        public Executer(IRoller roller)
        {
            _roller = roller;
        }

        public Executed Execute(Roll roll)
        {


            return new Executed();
        }
    }
}