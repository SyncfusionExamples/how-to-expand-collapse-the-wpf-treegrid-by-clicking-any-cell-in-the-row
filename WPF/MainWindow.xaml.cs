using Syncfusion.UI.Xaml.ScrollAxis;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SfTreeGrid_Demo_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            treeGrid.ItemsSource = (this.DataContext as ViewModel).EmployeeDetails;
            treeGrid.SelectionController = new TreeGridSelectionControllerExt(treeGrid);
        }
    }
    public class TreeGridSelectionControllerExt : TreeGridRowSelectionController
    {
        public TreeGridSelectionControllerExt(SfTreeGrid treeGrid) : base(treeGrid)
        {
        }
        protected override void ProcessOnTapped(MouseButtonEventArgs e, RowColumnIndex currentRowColumnIndex)
        {
            if (currentRowColumnIndex.RowIndex <= this.TreeGrid.GetHeaderIndex())
                return;

            var node = TreeGrid.GetNodeAtRowIndex(currentRowColumnIndex.RowIndex);
            if (node != null)
            {
                if (node.IsExpanded)
                    TreeGrid.CollapseNode(node);
                else if (!node.IsExpanded)
                    TreeGrid.ExpandNode(node);
            }
            base.ProcessOnTapped(e, currentRowColumnIndex);
        }
    }
}
