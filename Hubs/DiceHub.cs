

using Microsoft.AspNetCore.SignalR;

namespace DiceStream.Hubs {

    public class DiceHub : Hub {


        private  IParser _parser ;
        private IExecute _execute;
        
        public DiceHub(IParser parser, IExecute execute) {
            // parser takes the user input and turns it into an executable statemen
            //excute takes a statement and uses a determiner to calculate results
            // 
            _parser = parser;
            _execute = execute;


            
        }


        /// Method that will parse a dice statement
        /// execute it, 
        /// store the resulting Roll 
        /// then push the result out to all the connected clients. 


        public object Roll(string rawStatement) {


            /// if we can't parse the rawStatement
           /// So, hopefully we never have a statement so large we need 
           // advanced compiler action to parse it out., 
            // for this case we just want to parse it into a valid statemnt
            // the question is...how do we determine the success? I want to return parse errors to 
            // the user, and maybe the parser result is more then just the statement? it is the parsed data
            // which includes the actually statement if it was successful., 
        
            var parsed = _parser.Parse(rawStatement);
           
           if (parsed.WasSuccessful) {
            var result = _execute.Execute(parsed.Statement);
            /// can either return the result directly back to the requesting browser,
            /// or we could return an ok result and post the rolled data to all clients. 
            // we could throw an exception if the parsing fails. then the errror state comes in througth the fail state of the js promise. I could see either of those being good. 
               return null; /// return ok;
           } else {
                return null; // actually return the error object
           }
           


        } 

    }

}