# How to expand/collapse the WPF TreeGrid (SfTreeGrid) by clicking any cell in the row?

How to expand or collapse the WPF TreeGrid (SfTreeGrid) by clicking any cell in the row?

# About the sample

You can expand or collapse the groups by click any cell in caption summary row by overriding [ProcessOnTapped](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.TreeGridRowSelectionController.html#Syncfusion_UI_Xaml_TreeGrid_TreeGridRowSelectionController_ProcessOnTapped_System_Windows_Input_MouseButtonEventArgs_Syncfusion_UI_Xaml_ScrollAxis_RowColumnIndex_) method in [TreeGridRowSelectionController](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.TreeGridRowSelectionController.html) of [WPF TreeGrid](D:\KB\SfTreeGrid\WPF-35862\sample\how-to-expand-collapse-the-wpf-treegrid-by-clicking-any-cell-in-the-row\README.md) (SfTreeGrid).

```c#
this.treeGrid.SelectionController = new TreeGridSelectionControllerExt(this.treeGrid);

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
```
## Requirements to run the demo
 Visual Studio 2015 and above versions
