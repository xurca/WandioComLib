using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WandioComLib.Interfaces;
using WandioComLib.Properties;
using WandioComLib.Utils;

namespace WandioComLib.Controls
{
    #region delegates

    #endregion

    [ProgId(Constants.TreeViewClassId)]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ComSourceInterfaces(typeof(ITreeViewEvents))]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public partial class TreeViewControl : UserControl, UI.TreeView
    {
        public TreeViewControl()
        {
            InitializeComponent();
            InitializeDefault();
        }

        public void AddNode(string node)
        {
            treeView1.BeginInvoke(new Action(() => _AddNode(node)));
        }

        public void AddNodes(string[] nodes)
        {
            treeView1.BeginInvoke(new Action(() => _AddNodes(nodes)));
        }

        private void _AddNode(string node)
        {
            treeView1.Nodes.Add(node);
        }

        private void _AddNodes(string[] nodes)
        {
            var nodesArr = Array.ConvertAll(nodes, node => new TreeNode(node));
            treeView1.Nodes.AddRange(nodesArr);
        }

        private void InitializeDefault()
        {
            ImageList imgList = new ImageList();
            imgList.Images.Add(Resource.folder1);
            imgList.Images.Add(Resource.folder2);

            treeView1.ImageList = imgList;
            treeView1.ImageIndex = 1;
            treeView1.SelectedImageIndex = 1;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
