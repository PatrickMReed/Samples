using Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[ServiceBehavior(IncludeExceptionDetailInFaults = false, InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class FolderService : IFolderService
    {
        #region Private Fields

        private IFolderServiceCallback _callback = null;

        #endregion

        #region Constructors

        public FolderService()
        {
            _callback = OperationContext.Current.GetCallbackChannel<IFolderServiceCallback>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get the top leve list of subfolders and the counts of their subfolders at all levels
        /// </summary>
        /// <param name="path">Folder to process</param>
        public void ListAndCountSubFolders(string path)
        {
            FolderCounter counter = new FolderCounter();
            string message;

            // Get name of top level folders and return them to the calling UI
            List<string> folders = counter.CountTopLevelFolders(path, out message);
            _callback.TopLevelFoldersEnumerated(folders.ToArray(), message);
            
            // For each folder, create a background thread to count its number of subfolders
            foreach (string currentFolder in folders)
            {
                string target = currentFolder;

                // Create background thread for for this folder
                Task.Factory.StartNew(() => StartSubFolderCountingThread(target));
            }
        }

        #endregion

        #region Private Methods

        // Count the subfolders of this folder, notify UI when starting and finished
        private void StartSubFolderCountingThread(string target)
        {            
            _callback.CountingFolder(target);

            int subFolderCount = 0;
            FolderCounter subFolderCounter = new FolderCounter();
            subFolderCount = subFolderCounter.CountSubFolders(target);

            _callback.FolderCounted(target, subFolderCount, "");
        }

        #endregion
    }
}
