using WinFormsApp1.Formss;
using WinFormsApp1.Modelss;
using WinFormsApp1.Responsess;
using WinFormsApp1.Utilitiess;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly IBaseRepositoryEx _baseRepositoryEx = null;
        private readonly IHierarchicalPayanarTypeColumnRepository _hierarchicalPayanarTypeColumnRepository = null;
        private readonly IHierarchicalPayanarTypeRepository _hierarchicalPayanarTypeRepository = null;
        private readonly IPayanarTableDesignssRepository _payanarTableDesignssRepository = null;
        private readonly IPayanarTableDesignRepository _payanarTableDesignRepository = null;
        private TreeNode _selectedNode = null;
        public Form1(IBaseRepositoryEx baseRepositoryEx,
            IHierarchicalPayanarTypeColumnRepository hierarchicalPayanarTypeColumnRepository,
            IHierarchicalPayanarTypeRepository hierarchicalPayanarTypeRepository,
            IPayanarTableDesignssRepository payanarTableDesignssRepository,
            IPayanarTableDesignRepository payanarTableDesignRepository)
        {
            _baseRepositoryEx = baseRepositoryEx;
            _hierarchicalPayanarTypeColumnRepository = hierarchicalPayanarTypeColumnRepository;
            _hierarchicalPayanarTypeRepository = hierarchicalPayanarTypeRepository;
            _payanarTableDesignssRepository = payanarTableDesignssRepository;
            _payanarTableDesignRepository = payanarTableDesignRepository;
            InitializeComponent();
        }
        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var response = await _baseRepositoryEx.Read<GetHierarchicalPayanarTypeColumnssResponse, string>("https://localhost:7288/vtree/api/HierarchicalPayanarType/", string.Empty);
            ////var result = await _hierarchicalPayanarTypeColumnRepository.GetMultipleAsync("https://localhost:7288/vtree/api/HierarchicalPayanarType/");
            AddToViews(hierarchicalPayanarTypeTreeView.Nodes, null, response.HierarchicalPayanarTypeColumnss, response.TableDesignss);
            ////PayanarApplication.Instance.TableDesigns = await _payanarTableDesignRepository.GetAsync("https://localhost:7288/vtree/api/PayanarTableDesign", String.Empty);
            PayanarApplication.Instance.TableDesigns = response.TableDesignss;
        }
        private void AddToViews(TreeNodeCollection nodes, IPayanarType parent, IEnumerable<HierarchicalPayanarTypeColumn> hierarchicals, IEnumerable<PayanarTableDesign> tableDesignss)
        {
            foreach (var item in hierarchicals)
            {
                item.Parent = parent;
                var newNode = CreateTreeNode(item.UniqueId, item.Name, item);
                nodes.Add(newNode);
                AddToViews(newNode.Nodes, item, item.Children, tableDesignss);

                foreach (var tableDesign in tableDesignss)
                {
                    if (tableDesign.ParentUniqueId.Equals(item.UniqueId))
                        tableDesign.Parent = item;
                    if (item.IsPayanarTableDesign && item.UniqueId.Equals(tableDesign.UniqueId))
                        item.TableDesign = tableDesign;
                }
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (_selectedNode != null)
            {
                HierarchicalPayanarType type = new HierarchicalPayanarType();
                type.UniqueId = Guid.NewGuid().ToString();
                type.ParentUniqueId = (_selectedNode.Tag as IPayanarType).UniqueId;
                type.Name = $"N{_selectedNode.Nodes.Count + 1}";
                _hierarchicalPayanarTypeRepository.Insert("https://localhost:7288/vtree/api/HierarchicalPayanarType/", type);
                TreeNode newNode = CreateTreeNode(type.UniqueId, type.Name, type);
                _selectedNode.Nodes.Add(newNode);
                _selectedNode.ExpandAll();
            }
        }
        private void hierarchicalPayanarTypeTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _selectedNode = e.Node;
            if (_selectedNode != null)
            {
                addTblButton.Enabled = !(_selectedNode.Tag as IHierarchicalPayanarTypeColumn).IsPayanarTableDesign;
            }
        }
        private async void hierarchicalPayanarTypeTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_selectedNode != null)
            {
                var result = await _hierarchicalPayanarTypeColumnRepository.GetAsync("https://localhost:7288/vtree/api/HierarchicalPayanarType/", (_selectedNode.Tag as IPayanarType).UniqueId);
                ////AddToViews(_selectedNode.Nodes, result);
                _selectedNode.Expand();

                if ((_selectedNode.Tag as IHierarchicalPayanarTypeColumn).IsPayanarTableDesign)
                {
                    PayanarTableRunTimeForm form = new PayanarTableRunTimeForm((_selectedNode.Tag as IHierarchicalPayanarTypeColumn).TableDesign, _baseRepositoryEx, Viewss.PayanarTableRunTimeViewMode.Design);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show(this);
                }
            }
        }
        private TreeNode CreateTreeNode(string uniqueId, string name, IPayanarType type)
        {
            return new TreeNode() { Name = uniqueId, Text = name, Tag = type };
        }

        private void addTblButton_Click(object sender, EventArgs e)
        {
            PayanarTableDesign design = new PayanarTableDesign(Utility.NewUniqueId, (_selectedNode.Tag as PayanarType), true);
            PayanarTableDesignTimeForm form = new PayanarTableDesignTimeForm(design, _payanarTableDesignRepository);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog(this);
        }
    }
}