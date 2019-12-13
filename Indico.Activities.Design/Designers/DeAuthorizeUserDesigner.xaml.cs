using System.Collections.Generic;

namespace Indico.Activities.Design
{
    /// <summary>
    /// Interaction logic for DeAuthorizeUserDesigner.xaml
    /// </summary>
    public partial class DeAuthorizeUserDesigner
    {
        public DeAuthorizeUserDesigner()
        {
            InitializeComponent();
            UserEmailExpression.ExpressionType = typeof(List<string>);
        }
    }
}
