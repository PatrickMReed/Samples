using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interfaces
{
    [ServiceContract(CallbackContract = typeof(IFolderServiceCallback))]
    public interface IFolderService
    {
        [OperationContract]
        void ListAndCountSubFolders(string path);
    }

    [ServiceContract]
    public interface IFolderServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void TopLevelFoldersEnumerated(string[] rootFolders, string message);

        [OperationContract(IsOneWay = true)]
        void FolderCounted(string folder, int count, string messages);

        [OperationContract(IsOneWay = true)]
        void CountingFolder(string folder);
    }
}
