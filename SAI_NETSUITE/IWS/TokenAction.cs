using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.IWS
{
    class TokenAction
    {
         public string token;
        public string GetToken()
        {
            Connection conn = new Connection();
            string url = "api/Token/GetToken";
            string json = "{\"Username\": \"winservicewms\"," +
                                " \"Password\": \"F3rr3t3r14$\"" +
                                "}";
            string response = conn.POST(url, json,"");
            return response;
            
        }


        public string getLongToken(Token token)
        {

            Connection conn = new Connection();
            string url = "api/Token/GetLongToken";
                string json = "{\"Username\": \"winservicewms\"," +
                                " \"Password\": \"F3rr3t3r14$\"" +
                                "}";
           return  conn.POST(url, json, token.token);

               
        }

        public string refreshToken(Token token)
        { 
         Connection conn = new Connection();
            string url=@"api/Token/RefreshToken";
            return conn.GET(url, token.token);
        }
    
    }
}
