
using Microsoft.AspNetCore.SignalR;

namespace CoreApp.Hubs {

    public class DiceHub : Hub {

        public DiceHub(IParser parser, IExecute execute) {
            // parser takes the user input and turns it into an executable statemen
            //excute takes a statement and uses a determiner to calculate results
            // 
        }


        /// Method that will parse a dice statement
        /// execute it, 
        /// store the resulting Roll 
        /// then push the result out to all the connected clients. 


    }

}