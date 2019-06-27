using System.Collections.Generic;
using Indico.Custom.Models;

namespace Indico.Custom.Activities.Design
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
