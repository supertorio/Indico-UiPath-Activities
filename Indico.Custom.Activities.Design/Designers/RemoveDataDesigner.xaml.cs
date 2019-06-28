namespace Indico.Custom.Activities.Design
{
    /// <summary>
    /// Interaction logic for AddDataDesigner.xaml
    /// </summary>
    public partial class RemoveDataDesigner
    {
        public RemoveDataDesigner()
        {
            InitializeComponent();
            ExamplesExpression.ExpressionType = typeof(string[]);
        }
    }
}
