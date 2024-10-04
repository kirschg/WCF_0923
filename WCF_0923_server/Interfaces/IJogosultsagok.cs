using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_0923_server.Models;

namespace WCF_0923_server.Interfaces
{
        [ServiceContract]
        public interface IJogosultsagok
        {
            //R
            [OperationContract]
            List<Jogosultsagok> JogosultsagokLista_CS();

            //C
            [OperationContract]
            string JogsultsagokAdd_CS(Jogosultsagok jog);

            //U
            [OperationContract]
            string JogsultsagokUpdate_CS(Jogosultsagok jog);

            //D
            [OperationContract]
            string JogsultsagokDelete_CS(int id);

        }
    }
