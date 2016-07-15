using Demo.UI.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.UI
{
    // Delegates to enable background threads of FolderService to update user interface in a thread-safe manner
    delegate void AddRootFoldersCallback(string[] folderNames, string message);
    delegate void FolderCountedCallback(string folder, int count, string messages);
    delegate void CountingFolderCallback(string folder);

    public partial class FolderCounterForm : Form, IFolderServiceCallback
    {
        #region Private Fields

        private FolderServiceClient _folderService = null;

        #endregion

        #region Constructor

        public FolderCounterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void ListAndCount_Click(object sender, EventArgs e)
        {
            // Ensure valid path
            if (Directory.Exists(RootPath.Text))
            {
                FolderCounts.Items.Clear();
                Messages.Clear();

                _folderService = new FolderServiceClient(new InstanceContext(this));

                // Make the service request on a background thread so the UI will remain responsive
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        _folderService.ListAndCountSubFolders(RootPath.Text);
                    }
                    catch (Exception ex)
                    {
                        Messages.Text = ex.Message + Environment.NewLine;
                    }
                });
            }
            else
            {
                MessageBox.Show("Please enter a valid path.");
            }

        }

        #endregion

        #region FolderService callback methods

        /// <summary>
        /// Updates the UI with the folder that is currently being counted
        /// </summary>
        /// <param name="folder">Full folder path</param>
        public void CountingFolder(string folder)
        {
            if (FolderCounts.InvokeRequired)
            {
                CountingFolderCallback callback = new CountingFolderCallback(CountingFolder);
                this.Invoke(callback, new object[] { folder });
            }
            else
            {
                ListViewItem item = FolderCounts.Items.Find(folder, false).FirstOrDefault();
                item.SubItems[1].Text = "Counting...";
            }
        }

        /// <summary>
        /// Updates the UI with the list of top level folders
        /// </summary>
        /// <param name="rootFolders">List of top level folders</param>
        /// <param name="message">Any folders that were ignored due to attributes - hidden, etc.</param>
        public void TopLevelFoldersEnumerated(string[] rootFolders, string message)
        {
            if (FolderCounts.InvokeRequired)
            {
                AddRootFoldersCallback callback = new AddRootFoldersCallback(TopLevelFoldersEnumerated);
                this.Invoke(callback, new object[] { rootFolders, message });
            }
            else
            {
                if (rootFolders.Length > 0)
                {
                    foreach (string currentFolderName in rootFolders)
                    {
                        ListViewItem item = new ListViewItem(new string[] { "", "0" });
                        item.Text = currentFolderName;
                        item.Name = currentFolderName;

                        FolderCounts.Items.Add(item);
                    }

                    if (!string.IsNullOrEmpty(message))
                    {
                        Messages.Text += message;
                    }
                }
                else
                {
                    Messages.Text = "No subfolders found for the specified path.";
                }
            }

        }

        /// <summary>
        /// Updates the UI with the count of a folder's subfolders
        /// </summary>
        /// <param name="folder">Name of the counted folder</param>
        /// <param name="count">Number of subfolders</param>
        /// <param name="messages">Any folder that were ignored due to attributes or length</param>
        public void FolderCounted(string folder, int count, string messages)
        {
            if (FolderCounts.InvokeRequired)
            {
                FolderCountedCallback callback = new FolderCountedCallback(FolderCounted);
                this.Invoke(callback, new object[] { folder, count, messages });
            }
            else
            {
                ListViewItem item = FolderCounts.Items.Find(folder, false).FirstOrDefault();
                item.SubItems[1].Text = count.ToString();
            }
        }

        #endregion
    }
}
