using System.Collections.Generic;
using Indico.Models.Custom;

namespace Indico.Activities.Design
{
    /// <summary>
    /// Interaction logic for AddDataDesigner.xaml
    /// </summary>
    public partial class AddDataDesigner
    {
        public AddDataDesigner()
        {
            InitializeComponent();
            DataExpression.ExpressionType = typeof(List<CollectionData>);
        }
    }
}
