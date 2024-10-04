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
    public interface IFelhasznalok
    {
        //CRUD műveletek

        //R
        [OperationContract]
        List<Felhasznalok> FelhasznalokLista_CS();
        
        //C
        [OperationContract]
        string FelhasznaloAdd_CS(Felhasznalok felhasznalo);

        //U
        [OperationContract]
        string FelhasznaloUpdate_CS(Felhasznalok felhasznalo);

        //D
        [OperationContract]
        string FelhasznaloDelete_CS(int id);
    }
}
