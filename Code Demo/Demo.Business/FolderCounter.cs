using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business
{
    public class FolderCounter
    {
        #region Public Methods

        /// <summary>
        /// Gets a list of top level folders under the specified folder
        /// </summary>
        /// <param name="path">The folder to process</param>
        /// <param name="messages">Folders that were not included due to their attributes</param>
        /// <returns>List of top level folders</returns>
        public List<string> CountTopLevelFolders(string path, out string messages)
        {
            List<string> rootFolders = new List<string>();
            StringBuilder messageBuilder = new StringBuilder();

            if (Directory.Exists(path))
            {
                foreach (string currentFolder in Directory.EnumerateDirectories(path))
                {
                    DirectoryInfo info = new DirectoryInfo(currentFolder);

                    if (CanProcessFolder(info))
                    {
                        rootFolders.Add(currentFolder);
                    }
                    else
                    {
                        if (messageBuilder.Length == 0)
                        {
                            messageBuilder.Append("Ignored folder due to attributes: " + Environment.NewLine);
                        }

                        messageBuilder.Append(info.FullName + Environment.NewLine);
                    }
                }
            }
            else
            {
                messageBuilder.Append("Specified path does not exist");
            }

            messages = messageBuilder.ToString();

            return rootFolders;
        }



        /// <summary>
        /// Recursively count all subfolders under specified folder
        /// </summary>
        /// <param name="path">Folder to process</param>
        /// <returns>Count of the number of folders at all levels under this folder</returns>
        public int CountSubFolders(string path)
        {
            int folderCount= 0;

            try
            {
                List<string> folders = Directory.EnumerateDirectories(path).ToList();

                // Count top level folders
                folderCount = folders.Count();

                // Count subfolders
                foreach (string subFolder in folders)
                {
                    folderCount += CountSubFolders(subFolder);
                }
            }
            catch
            {
                // Simply fail and return 0 count for this folder
            }

            return folderCount;
        }

        #endregion

        #region Private Methods

        // Folder that only have the attribut "Directory" can be counted, otherwise, exceptions are thrown
        private bool CanProcessFolder(DirectoryInfo info)
        {
            if (info.Attributes != FileAttributes.Directory)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
