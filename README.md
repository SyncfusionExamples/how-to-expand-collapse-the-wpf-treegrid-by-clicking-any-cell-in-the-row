# How to expand/collapse the WPF TreeGrid (SfTreeGrid) by clicking any cell in the row?

How to expand/collapse the WPF TreeGrid (SfTreeGrid) by clicking any cell in the row?

# About the sample

In SfTreeGrid, you can expand or collapse the groups by click any cell in caption summary row by overriding ProcessOnTapped mathod in TreeGridRowSelectionConverter.

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
