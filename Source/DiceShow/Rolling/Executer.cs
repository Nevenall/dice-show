using System;
using System.Collections.Generic;
using System.Linq;
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
            var ret = new Executed();

            /// roll Number of dice for each dice in order. 
            // for a start
            // there may be other options for things, like
            // rolemaster style open ended rolling. 
            // do we want to trace the rolling? 
            // maybe we do

            // how do we execute each roll? 
            // we the roller is serialized. which should be ok. 
            // 
            try
            {
                ret.Result = new Result
                {
                    Description = roll.Description,
                    RolledDice = from d in roll.Dice
                                 select new Tuple<Dice, IEnumerable<int>>(d, from idx in Enumerable.Range(1, d.Number)
                                                                             select _roller.Roll(1, d.Sides))
                };

            }
            catch (Exception ex)
            {
                ret.Exception = ex;
            }


            return ret;
        }
    }
}