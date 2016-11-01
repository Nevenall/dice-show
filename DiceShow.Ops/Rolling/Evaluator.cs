
namespace DiceShow.Ops.Rolling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DiceShow.Model;

    public class Executer : IEvaluator
    {

        private IRoller _roller;
        public Executer(IRoller roller)
        {
            _roller = roller;
        }

        public Evaluated Evaluate(Statement roll)
        {
            var ret = new Evaluated();

            try
            {

                // So, core evaluation is pretty basic. 
                // we essencially roll some numebr of dice as a group. 
                // and we have some results., 
                // So, as we develop the results are likely to get diverse. 
                // want can we do about the different results types?
                // maybe there is a base class? 
                // can there be a base class in say typescript?
                // because the real question to me is how to show a diverse set of possiuble results?
                // in a senseable way. 
                // we can have templates for each type. 
                // considering how Vue works that might be nuce. 

                // the ui gets a result object and looks at a type field, or the type name if maybe we can write it in typescript and then 
                // have signalr somehow know what the type is.
                // except now we define the type in two spots that will be out of sync
                // anyway, we have several differnt results types and the ui can look at a string field
                // get the vue template to use for that object based on the string, and there we go
                // or smalltalk style, the result object type defines it's own html template. Which sounds crazy, but as long 
                // as we always use vue i guess htat would work. 
                // but I digress. 
                // instead, I think the ui will look at the result type to determine the template. 
                // So, I can 







                ret.Result = new Result
                {

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